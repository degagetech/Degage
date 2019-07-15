#  DEGAGE 服务模型

### 远程调用

 #### 常规调用流程解析

   *  填充调用的服务地址与域
    * 与服务地址建立连接
    * 本地解析调用对应的服务元数据
    * 将服务元数据标识与调用发送至服务端
    * 服务端接收到服务元数据标识确定有无对应的服务行为 ，若无返回无效状态信息
   *  尝试构建服务行为的对象

 #### 连接器类型
  * HttpConnector
  * TcpConnector 
  * UdpConnector
  * WSocketConnector 


 #### 数据交换器
 * JsonDataExchanger
 * XmlDataExchanger
 * ProtoBufferDataExchanger
 * StreamDataExchanger