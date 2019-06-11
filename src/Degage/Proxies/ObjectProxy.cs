using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;
namespace Degage.Proxies
{
    /// <summary>
    /// 提供基础代理辅助方法
    /// </summary>
    public abstract class BaseObjectProxy
    {
        /// <summary>
        /// 当前是否因为编译环境问题而禁用了代理类型的动态创建
        /// </summary>
        public static Boolean DisabledProxyTypeDynamicCreate { get; private set; } = false;

#if !NETSTANDARD2_0
        /// <summary>
        /// 用于承载动态代理类型的公用模块
        /// </summary>
        public static ModuleBuilder ModuleBuilder { get; private set; }
        /// <summary>
        /// 记录基元值类型与 Load IL 指令的映射关系
        /// </summary>
        public static Dictionary<Type, OpCode> BaseValueTypeLdOpCodeTable { get; private set; }
        =new Dictionary<Type, OpCode>();
#endif
        static BaseObjectProxy()
        {

#if !NETSTANDARD2_0
            String assemblyName = "ProxyDynamicAssembly";
            String moudleName = "ProxyDynamicMoudle";
            AssemblyBuilder assemblyBuilder = null;

            var ldOpCodeTable = BaseObjectProxy.BaseValueTypeLdOpCodeTable;
            ldOpCodeTable.Add(typeof(System.Boolean), OpCodes.Ldind_I1);
            ldOpCodeTable.Add(typeof(System.Int16), OpCodes.Ldind_I2);
            ldOpCodeTable.Add(typeof(System.Int32), OpCodes.Ldind_I4);
            ldOpCodeTable.Add(typeof(System.Int64), OpCodes.Ldind_I8);
            ldOpCodeTable.Add(typeof(System.Double), OpCodes.Ldind_R8);
            ldOpCodeTable.Add(typeof(System.Single), OpCodes.Ldind_R4);
            ldOpCodeTable.Add(typeof(System.UInt16), OpCodes.Ldind_U2);
            ldOpCodeTable.Add(typeof(System.UInt32), OpCodes.Ldind_U4);


#endif



#if NETSTANDARD2_0
            BaseObjectProxy.DisabledProxyTypeDynamicCreate = true;
            return;
#elif NETSTANDARD2_1
               AssemblyBuilder assemblyBuilder = null;
               assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                     assemblyNameObj,
              AssemblyBuilderAccess.RunAndCollect);
#endif
#if !NETSTANDARD2_0

            //在当前程序域中构建程序集信息
            AppDomain domain = AppDomain.CurrentDomain;

            //构建一个程序集
            AssemblyName assemblyNameObj = new AssemblyName(assemblyName);
            assemblyNameObj.Version = new Version(1, 0, 0, 0);

            assemblyNameObj.CultureInfo = Thread.CurrentThread.CurrentCulture;

            assemblyBuilder = domain.DefineDynamicAssembly(
                  assemblyNameObj,
                  AssemblyBuilderAccess.RunAndCollect);

            //在程序集中构建基本模块
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moudleName);

            BaseObjectProxy.ModuleBuilder = moduleBuilder;
#endif

        }

        /// <summary>
        /// 方法调用拦截器的集合
        /// </summary>
        public IList<IMethodInterceptor> MethodInterceptors { get; private set; }

        /// <summary>
        /// 通过指定的被代理类型初始化 <see cref="BaseObjectProxy"/> 实例
        /// </summary>
        public BaseObjectProxy()
        {
            this.MethodInterceptors = new List<IMethodInterceptor>();
        }

#if !NETSTANDARD2_0
        /// <summary>
        /// 获取基元值类型对应的 LdOpCode，若无则返回 <see cref="OpCodes.Ldobj"/>
        /// <param name="type"></param>
        /// <returns></returns>
        public static OpCode GetBaseValueTypeLdOpCode(Type type)
        {
            var opCode = OpCodes.Ldobj;
            if (BaseObjectProxy.BaseValueTypeLdOpCodeTable.ContainsKey(type))
            {
                opCode = BaseObjectProxy.BaseValueTypeLdOpCodeTable[type];
            }
            return opCode;
        }
#endif
    }
    /// <summary>
    /// 提供对指定类型的各类成员的拦截能力
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectProxy<T> : BaseObjectProxy
    {
        /// <summary>
        /// 针对于此被代理类创建的动态代理类的类型
        /// </summary>
        public static Type ProxyType { get; protected set; }
        /// <summary>
        /// 被代理的方法的集合
        /// </summary>
        protected static MethodInfo[] ProxiedMethodInfos { get; private set; }
        /// <summary>
        /// 已被忽略的被代理成员的集合
        /// </summary>
        protected static HashSet<MemberInfo> IgnoreProxiedMemberTable { get; private set; }
        /// <summary>
        /// 代理对象
        /// </summary>
        public T Proxy { get; protected set; }

        /// <summary>
        /// 被代理的对象的类型
        /// </summary>
        public Type ProxiedType { get; protected set; }

        public ObjectProxy()
        {
            this.ProxiedType = typeof(T);
            var proxiedType = this.ProxiedType;
            //代理类型只能为接口、抽象类、类。
            var checkProxyType = proxiedType.IsInterface || proxiedType.IsAbstract || proxiedType.IsClass;
            if (!checkProxyType)
            {
                throw new Exception(TextResources.E_ObjectFactoryProxyTypeInvaild);
            }
            var proxyType = ObjectProxy<T>.ProxyType;
            var proxy = Activator.CreateInstance(proxyType, this);
            this.Proxy = (T)proxy;
        }
        static ObjectProxy()
        {
            ObjectProxy<T>.IgnoreProxiedMemberTable = new HashSet<MemberInfo>();
            ObjectProxy<T>.ProxiedMethodInfos = ObjectProxy<T>.GetProxiedTypeMethodInfos(typeof(T));
            ObjectProxy<T>.ProxyType = ObjectProxy<T>.CreateDynamicProxyType(typeof(T));

        }

        /// <summary>
        /// 判断指定的被代理类的类型成员是否应该被忽略代理
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static Boolean IgnoredProxiedMember(MemberInfo member)
        {
            return ObjectProxy<T>.IgnoreProxiedMemberTable.Contains(member);
        }
        /// <summary>
        /// 获取被代理类型所有可代理的方法
        /// </summary>
        public static MethodInfo[] GetProxiedTypeMethodInfos(Type proxiedType)
        {
            List<MethodInfo> result = new List<MethodInfo>();
            List<MethodInfo> methodInfos = new List<MethodInfo>();

            var objectType = typeof(Object);
            var disposeType = typeof(IDisposable);

            //如果此代理类为接口，则还需要遍历此接口继承的父接口
            if (proxiedType.IsInterface)
            {
                Queue<Type> interfaceTypeQueue = new Queue<Type>();
                interfaceTypeQueue.Enqueue(proxiedType);

                while (interfaceTypeQueue.Count > 0)
                {
                    var interfaceType = interfaceTypeQueue.Dequeue();
                    methodInfos.AddRange(interfaceType.GetMethods());
                    var subs = interfaceType.GetInterfaces();
                    if (subs.Length > 0)
                    {
                        foreach (var sub in subs)
                        {
                            interfaceTypeQueue.Enqueue(sub);
                        }
                    }
                }
            }
            else
            {
                methodInfos.AddRange(proxiedType.GetMethods());
            }


            foreach (var methodInfo in methodInfos)
            {
                //忽略对 Object 的代理
                if (methodInfo.DeclaringType == objectType)
                {
                    continue;
                }
                //忽略对 IDisposable 的代理
                if (methodInfo.DeclaringType == disposeType)
                {
                    if (!methodInfo.IsAbstract)
                    {
                        continue;
                    }
                    else
                    {
                        ObjectProxy<T>.IgnoreProxiedMemberTable.Add(methodInfo);
                    }
                }
                //检测此方法是否应用了忽略特性，若是，则跳过
                var noProxy = methodInfo.GetCustomAttributes(typeof(NoProxyAttribute), false);
                if (noProxy.Length > 0)
                {
                    if (!methodInfo.IsAbstract)
                    {
                        continue;
                    }
                    else
                    {
                        ObjectProxy<T>.IgnoreProxiedMemberTable.Add(methodInfo);
                    }
                }
                result.Add(methodInfo);
            }


            return result.ToArray();
        }
        /// <summary>
        ///  处理对代理类方法的调用
        /// </summary>
        /// <param name="proxiedMethodIndex">被代理方法的索引</param>
        /// <param name="proxy">动态代理类的实例，常为 当前调用此方法的实例</param>
        /// <param name="parameterValues">方法调用的参数值</param>
        public Object HandleProxyMethod(
            Int32 proxiedMethodIndex,
            Object proxy,
            Object[] parameterValues)
        {
            var proxiedMethodInfo = ObjectProxy<T>.ProxiedMethodInfos[proxiedMethodIndex];
            if (ObjectProxy<T>.IgnoredProxiedMember(proxiedMethodInfo))
            {
                var formatInfo = String.Format(TextResources.EF_IgnoredProxiedMemberWithAbstract, proxiedMethodInfo.Name);
                throw new ObjectProxyException(formatInfo);
            }
            MethodInterceptArgs args = new MethodInterceptArgs();
            Object returnValue = null;
            foreach (var interceptor in this.MethodInterceptors)
            {
                returnValue = interceptor.InovkeHandle(proxy, this.ProxiedType, proxiedMethodInfo, parameterValues, args);
                if (args.AbortException != null)
                {
                    throw args.AbortException;
                }
            }
            if (args.Handled)
            {
                return returnValue;
            }

            //如果未处理并且方法不为抽象方法，则尝试执行方法的原始代码
            if (!args.Handled && !proxiedMethodInfo.IsAbstract)
            {
                try
                {
                    //调用基类的方法实现
                    //通过此方法调用很明显会产生循环调用的错误
                    //proxiedMethodInfo.Invoke(proxy,parameterValues);
                    //其始终执行的为动态类构建的新方法

                    IntPtr pFunc = proxiedMethodInfo.MethodHandle.GetFunctionPointer();
                    Type methodGenericType = null;
                    //如果无返回值则使用 Action<>，否则使用 Func<>
                    if (proxiedMethodInfo.ReturnType == typeof(void))
                    {
                        var parameters = proxiedMethodInfo.GetParameters();
                        if (parameters.Length > 0)
                        {
                            Type[] parameterTypes = new Type[parameters.Length];
                            for (Int32 i = 0; i < parameters.Length; i++)
                            {
                                parameterTypes[i] = parameters[i].ParameterType;
                            }
                            methodGenericType = typeof(Action<>).MakeGenericType(parameterTypes);
                        }
                        //如果没有参数，则不使用 Action 的泛型版本
                        else
                        {
                            methodGenericType = typeof(Action);
                        }
                    }
                    else
                    {
                        var parameters = proxiedMethodInfo.GetParameters();
                        Type[] parameterTypes = new Type[parameters.Length+1];
                        for (Int32 i = 0; i < parameters.Length; i++)
                        {
                            parameterTypes[i] = parameters[i].ParameterType;
                        }
                        parameterTypes[parameters.Length] = proxiedMethodInfo.ReturnParameter.ParameterType;
                        methodGenericType = typeof(Func<>).MakeGenericType(parameterTypes);
                    }
                    var ftn = proxiedMethodInfo.MethodHandle.GetFunctionPointer();
                    var baseMethod = (Delegate)Activator.CreateInstance(methodGenericType, proxy, ftn);
                    var result = baseMethod.DynamicInvoke(parameterValues);
                    return result;
                }
                catch (Exception exc)
                {
                    foreach (var interceptor in this.MethodInterceptors)
                    {
                        var returnObject = interceptor.ExceptionHandle(exc, proxy, this.ProxiedType, proxiedMethodInfo, parameterValues, args);
                        if (args.ExceptionHandled)
                        {
                            return returnObject;
                        }
                    }
                    if (!args.ExceptionHandled)
                    {
                        throw exc;
                    }
                }
            }
            var errorInfo = String.Format(TextResources.EF_ProxiedMethodHandleErrorFormat, proxiedMethodInfo.ToString());
            throw new ObjectProxyException(errorInfo);
        }

        protected static Type CreateDynamicProxyType(Type proxiedType)
        {
            Type type = null;
            if (BaseObjectProxy.DisabledProxyTypeDynamicCreate)
            {
                throw new Exception(TextResources.E_CLRNotSupported);
            }
#if !NETSTANDARD2_0
            //在模块中构建类型
            String typeName = proxiedType.FullName + "DynamicProxy";

            Type parentType = typeof(Object);
            var interfaceTypes = new List<Type>
            {
                //typeof(IDisposable)
            };

            //若被代理类型为类或者抽象类，则动态类型的父类应该为此，否则为 Object
            if ((proxiedType.IsClass || proxiedType.IsAbstract) && !proxiedType.IsInterface)
            {
                parentType = proxiedType;
            }

            //若被代理类为接口，则动态类的接口中应该添加此
            if (proxiedType.IsInterface)
            {
                interfaceTypes.Add(proxiedType);
            }

            TypeBuilder typeBuilder = BaseObjectProxy.ModuleBuilder.DefineType(
                typeName,
                TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed,
                parentType,
                interfaceTypes.ToArray());

            //为类型定义一个 对象代理 字段，方便后续使用此字段调用辅助函数，避免将辅助函数定义在动态类中
            FieldBuilder proxyField = typeBuilder.DefineField(
              "_objectProxy",
               typeof(BaseObjectProxy),
              FieldAttributes.Private);

            //获取父类的默认构造函数
            ConstructorInfo defaultConstructorInfo = parentType.GetConstructor(new Type[] { });

            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
               new Type[] { typeof(BaseObjectProxy) });

            ILGenerator iLGenerator = constructorBuilder.GetILGenerator();

            //通过构造函数参数为 _objectProxy 字段赋值
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, proxyField);

            //调用基类的构造函数
            //为动态类生成一个构造函数
            if (defaultConstructorInfo != null)
            {
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Call, defaultConstructorInfo);
            }
            iLGenerator.Emit(OpCodes.Ret);

            DynamicImplementProxiedMethod(proxiedType, typeBuilder, proxyField);
            type = typeBuilder.CreateType();
#endif

            return type;
        }

#if !NETSTANDARD2_0
        /// <summary>
        /// 为指定的动态代理类型实现所有可代理的方法
        /// </summary>
        /// <param name="proxiedType">被代理类的类型</param>
        /// <param name="proxyTypeBuilder">代理类的组件器</param>
        /// <param name="proxyField">对象代理字段</param>
        public static void DynamicImplementProxiedMethod(
            Type proxiedType,
            TypeBuilder proxyTypeBuilder,
            FieldBuilder proxyField)
        {
            var methodInfos = ObjectProxy<T>.ProxiedMethodInfos;
            Int32 methodIndex = 0;
            Type voidType = typeof(void);
            foreach (var methodInfo in methodInfos)
            {
                //获取方法的参数信息
                var parameterInfos = methodInfo.GetParameters();
                var parameterCount = parameterInfos.Length;
                Type[] parameterTypeInfos = new Type[parameterInfos.Length];
                for (Int32 j = 0; j < parameterCount; ++j)
                {
                    parameterTypeInfos[j] = parameterInfos[j].ParameterType;
                }
                //为动态类声明方法
                MethodBuilder methodBuilder = proxyTypeBuilder.DefineMethod(
                          methodInfo.Name,
                          MethodAttributes.Public | MethodAttributes.Virtual,
                          CallingConventions.Standard,
                          methodInfo.ReturnType,
                          parameterTypeInfos
                  );

                var handleMethodInfo = typeof(ObjectProxy<T>).GetMethod(nameof(ObjectProxy<T>.HandleProxyMethod), BindingFlags.Public | BindingFlags.Instance);

                //实现方法内部
                ILGenerator iLGenerator = methodBuilder.GetILGenerator();

                //定义 parameterValues 变量
                LocalBuilder parameterValues = null;
                if (parameterCount > 0)
                {
                    parameterValues = iLGenerator.DeclareLocal(typeof(System.Object[]));
                }

                //加载 _objectProxy 字段
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld,proxyField);

                iLGenerator.Emit(OpCodes.Ldc_I4, methodIndex);

                //加载 this 对象
                iLGenerator.Emit(OpCodes.Ldarg_0);

                //加载 parameterValues 参数至栈顶
                if (parameterValues != null)
                {
                    iLGenerator.Emit(OpCodes.Ldc_I4, parameterCount);
                    iLGenerator.Emit(OpCodes.Newarr, typeof(Object));
                    iLGenerator.Emit(OpCodes.Stloc, parameterValues.LocalIndex);
                    for (Int32 k = 0; k < parameterCount; k++)
                    {
                        //推送数组引用到堆栈上
                        iLGenerator.Emit(OpCodes.Ldloc, parameterValues.LocalIndex);
                        //将数组索引推送到堆栈上
                        iLGenerator.Emit(OpCodes.Ldc_I4, k);
                        //第一个参数为this对象本身，所以该用 k+1
                        iLGenerator.Emit(OpCodes.Ldarg, k + 1);
                        if (parameterTypeInfos[k].IsValueType)
                        {
                            //若参数值为值类型，则还需要装箱
                            iLGenerator.Emit(OpCodes.Box, parameterTypeInfos[k]);
                        }
                        iLGenerator.Emit(OpCodes.Stelem_Ref);
                    }
                    iLGenerator.Emit(OpCodes.Ldloc, parameterValues.LocalIndex);
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Ldnull);
                }

                //将调用转移到 ObjectProxy 对象上
                iLGenerator.Emit(OpCodes.Call, handleMethodInfo);

                //处理方法的返回值
                if (!methodInfo.ReturnType.Equals(voidType))
                {
                    if (methodInfo.ReturnType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Unbox, methodInfo.ReturnType);
                        if (methodInfo.ReturnType.IsEnum)
                        {
                            iLGenerator.Emit(OpCodes.Ldind_I4);
                        }
                        else if (!methodInfo.ReturnType.IsPrimitive)
                        {
                            iLGenerator.Emit(OpCodes.Ldobj, methodInfo.ReturnType);
                        }
                        else
                        {
                            var opCode = BaseObjectProxy.GetBaseValueTypeLdOpCode(methodInfo.ReturnType);
                            iLGenerator.Emit(opCode);
                        }
                    }
                }
                else
                {
                    //如果方法本身没有返回值，此时应该清除栈顶的数据
                    iLGenerator.Emit(OpCodes.Pop);
                }

                iLGenerator.Emit(OpCodes.Ret);
                ++methodIndex;
            }
        }
#endif
    }
}
