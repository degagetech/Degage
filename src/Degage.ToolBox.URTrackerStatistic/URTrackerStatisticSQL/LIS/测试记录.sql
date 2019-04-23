---------检验    已发布（版本号）-------------
declare  @sdate  datetime
declare  @edate  datetime
set @sdate='2019-03-15 09:30:01'
set @edate='2019-03-22 09:30:00'
select  a.select1 as 医院,a.Select2 系统名称,a.ProblemID as 单号,a.BigText1 AS 问题描述,k.TypeName  as   类型,convert(varchar(10),a.CreateTime,120) as  受理时间,'是'  as   是否修改,a.Float1 as 工作量,'完成' as 完成情况,c.DisplayName as 测试人,e.DateCreated as 测试时间,'' as 版本号,e.content AS 备注 
INTO #a
from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,Pts_Records e,Accounts_Department f ,Accounts_Users h ,Accounts_Department g,pts_problemstate j, Pts_ProblemType k
where  
e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID AND a.ProblemID=e.ProblemID
AND h.DisplayName<>'董雪娟' AND c.DisplayName<>h.DisplayName
and a.ProblemTypeID=k.ProblemTypeID
and  j.statename in ('已发布（版本号）','关闭')and  d.name ='LIS.NET项目'
and  f.DeptName='项目管理中心'
AND e.DateCreated   >=@sdate and  e.DateCreated <=@edate
and a.select1 not IN ('深圳滨海医院','山东烟台毓璜顶医院','深圳市人民医院') and a.Select2 like '检验系统%'
ORDER BY e.DateCreated



select ProblemID,DisplayName 处理人,min(DateCreated)   完成日期
into #b from #a left join  Pts_Records  on  #a.单号=Pts_Records.ProblemID
LEFT  JOIN  pts_problemstate ON StateID=ProblemStateID
LEFT JOIN  Accounts_Users ON Accounts_Users.UserID=CreateUser
where    StateName='已完成待测试'
AND  Accounts_Users.DEPTID IN ('20','22')
group by  ProblemID,DisplayName 


select #a.医院,系统名称,单号,问题描述,类型,受理时间,是否修改,工作量,处理人,完成日期,完成情况,测试人,测试时间,版本号,备注 from  #a,#b
where  #a.单号=#b.ProblemID
order by  测试时间


--drop  table  #a
--drop  table  #b
