
------------------------以下为"研发项目处理情况统计"用----------


-----------------------------本周完成---------------begin-------------------
select
	a.ProblemID as ID,
	--bb.RecordID as RecordID,
	c.DisplayName 转单人,
	d.DisplayName 接单人,
	b.DateCreated 转单时间,
	isnull(g.TypeName,'需求') 类型,
	a.Float1 工作量H,
	f.statename 转单状态,
	e.statename 目前状态,
	b.Title 转单标题,
	b.content AS 转单内容,
	a.Title AS 标题,
	a.BigText1 AS 描述		
from Pts_Problems a(nolock)
inner join Pts_Records b(nolock) on a.ProblemID=b.ProblemID  --and b.IsKeyRecord='1'  ---排除评论的记录
inner join Accounts_Users c(nolock) on b.CreateUser=c.UserID --转单人
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID --and d.DeptID='1'  --转到项目管理中心 
inner join pts_problemstate f(nolock) on b.StateID=f.ProblemStateID
left join Pts_ProblemType g(nolock) on a.ProblemTypeID=g.ProblemTypeID --类型
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
where  b.RecordID = 
	(SELECT min(g.RecordID) FROM Pts_Records g(NOLOCK) 
	inner join Pts_ProblemState h(nolock) on g.StateID=h.ProblemStateID  
	inner join Accounts_Users i(nolock) on g.CreateUser=i.UserID 
	WHERE a.ProblemID=g.ProblemID
	and h.StateName in ('已完成待测试') 
	and i.DeptID in ('5','24','25')  ---研发转出 
	)
	and a.ProjectID in ('47','48','49','50','53','57')
	and b.DateCreated >='2019-02-22 00:00:00'  AND b.DateCreated<'2019-03-01 00:00:00'
   order by a.ProblemID
   
-----------------------------本周完成--------------end-------------------
   


----------------截止到周四，技术剩余单-------------begin--------------------------------

------转入
select  
a.ProblemID as ID,
a.ProblemTypeID as TypeID,
c.DisplayName name,
f.DeptName dept
into #in
from Pts_Problems a 
inner join Pts_Records e on a.ProblemID=e.ProblemID and e.IsKeyRecord=1
inner join Accounts_Users  c on e.CreateUser=c.UserID  --转单人
inner join Accounts_Department f on c.DeptID=f.DeptID
inner join Accounts_Users h on e.AssignTo=h.UserID  --接单人
inner join Accounts_Department g on h.DeptID=g.DeptID
inner join pts_problemstate j on a.ProblemStateID=j.ProblemStateID and j.StateName not like '%关闭%'
inner join Pts_Projects d on a.ProjectID=d.ProjectID
where  
 c.DisplayName<>h.DisplayName
 AND g.DeptID in ('5','24','25')  --转入研发
AND e.DateCreated  >='2019-03-01 00:00:00'
ORDER BY a.ProblemID;

------转出
select  
a.ProblemID as ID,
a.ProblemTypeID as TypeID,
c.DisplayName name,
f.DeptName dept
into #out
from Pts_Problems a 
inner join Pts_Records e on a.ProblemID=e.ProblemID and e.IsKeyRecord=1
inner join Accounts_Users  c on e.CreateUser=c.UserID  --转单人
inner join Accounts_Department f on c.DeptID=f.DeptID
inner join Accounts_Users h on e.AssignTo=h.UserID  --接单人
inner join Accounts_Department g on h.DeptID=g.DeptID
inner join pts_problemstate j on a.ProblemStateID=j.ProblemStateID and j.StateName not like '%关闭%'
inner join Pts_Projects d on a.ProjectID=d.ProjectID
where  
 c.DisplayName<>h.DisplayName
 AND f.DeptID in ('5','24','25')  --研发转出
AND e.DateCreated  >='2019-03-01 00:00:00'
and not exists (Select top 1 1 from #in i where a.ProblemID=i.ID )---排除这时间后转入的
ORDER BY a.ProblemID;

-------当前
select distinct
a.ProblemID as ID,
a.ProblemTypeID as TypeID,
c.DisplayName name,
--b.statename 转单状态,
f.DeptName dept
into #now
from Pts_Problems a 
inner join 	pts_problemstate j on  a.ProblemStateID=j.ProblemStateID
inner join 	Pts_Records e on a.ProblemID=e.ProblemID  and e.IsKeyRecord=1
inner join 	pts_problemstate b on e.StateID=b.ProblemStateID
inner join 	Accounts_Users  c on a.AssignedTo=c.UserID and c.DeptID in ('5','24','25')
inner join 	Accounts_Department f on  c.DeptID=f.DeptID
where  a.ProjectID in ('47','48','49','50','53','57')
and j.StateName not like '%关闭%'
and not exists (Select top 1 1 from #in i where a.ProblemID=i.ID )---排除转入

select name 当前处理人,count(id) 需求单数 from
(
select * from #out WHERE isnull(TypeID,'0') 
in ( '0','127','136','138','139','141','142','144','146','147','149','151','152','164','166','167','179') --需求
union all
select * from #now WHERE isnull(TypeID,'0') 
in ( '0','127','136','138','139','141','142','144','146','147','149','151','152','164','166','167','179') --需求
)a  group by name

select name 当前处理人,count(id) 缺陷单数 from
(
select * from #out WHERE TypeID in ( '135','137','140','143','145','148','150','163','165','178') --缺陷
union all
select * from #now WHERE TypeID in ( '135','137','140','143','145','148','150','163','165','178') --缺陷
)a  group by name



drop table #in
drop table #out
drop table #now


----------------截止到周四，技术剩余单-----------end-----------------------------------  

--------------------------超过24小时未确认回复--------------------begin---------
select 
    '确认' as 标志,
    DATEDIFF(DAY,b.DateCreated,GETDATE())  超时,
    b.DateCreated 已确认时间,
   isnull(b.DateCreated,GETDATE()) 已分配时间,
	a.ProblemID as ID,
	b.RecordID as RecordID,
	c.DisplayName 转单人,
	d.DisplayName 接单人,
	b.DateCreated 转单时间,
	f.statename 转单状态,
	g.DisplayName 当前处理人,
	e.statename 当前状态,
	b.Title 转单标题,
	b.content AS 转单内容,
	a.Title AS 标题,
	a.BigText1 AS 描述
from Pts_Problems a(nolock)
inner join Pts_Records b(nolock) on a.ProblemID=b.ProblemID 
inner join Accounts_Users c(nolock) on b.CreateUser=c.UserID
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID
inner join Accounts_Users g(nolock) on a.AssignedTo=g.UserID
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
inner join pts_problemstate f(nolock) on b.StateID=f.ProblemStateID
where 
	b.RecordID = 
	(SELECT min(g.RecordID) FROM Pts_Records g(NOLOCK), Pts_ProblemState h(nolock)  
	WHERE g.StateID=h.ProblemStateID AND h.StateName in ('需求确认','已确认') and a.ProblemID=g.ProblemID)
	and d.DeptID in ('5','24','25') 
	and b.DateCreated>'2019-02-22 00:00:00'  
	and f.statename=e.statename  ---转单状态与当前单状态一致，说明未处理
	--and DATEDIFF(hour,b.DateCreated,GETDATE())>48
	and DATEDIFF(DAY,b.DateCreated,GETDATE())>1
	and a.ProjectID in ('47','48','49','50','53','57')
	and g.DeptID in ('5','24','25')
union all
select
   '分配' as 标志,
   DATEDIFF(DAY,bb.DateCreated,isnull(b.DateCreated,GETDATE())) 超时,
   bb.DateCreated 已确认时间,
   isnull(b.DateCreated,GETDATE()) 已分配时间,
	a.ProblemID as ID,
	b.RecordID as RecordID,
	c.DisplayName 转单人,
	d.DisplayName 接单人,
	b.DateCreated 转单时间,
	f.statename 转单状态,
	g.DisplayName 当前处理人,
	e.statename 当前状态,
	b.Title 转单标题,
	b.content AS 转单内容,
	a.Title AS 标题,
	a.BigText1 AS 描述
from Pts_Problems a(nolock)
left join Pts_Records b(nolock) on a.ProblemID=b.ProblemID 
                   and b.RecordID = 
	(SELECT min(g.RecordID) FROM Pts_Records g(NOLOCK), Pts_ProblemState h(nolock)  
	WHERE g.StateID=h.ProblemStateID AND h.StateName in ('已分配') and a.ProblemID=g.ProblemID)
inner join Pts_Records bb(nolock) on a.ProblemID=bb.ProblemID 
inner join Accounts_Users c(nolock) on bb.CreateUser=c.UserID
inner join Accounts_Users d(nolock) on bb.AssignTo=d.UserID
inner join Accounts_Users g(nolock) on a.AssignedTo=g.UserID
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
inner join pts_problemstate f(nolock) on bb.StateID=f.ProblemStateID
where 	 bb.DateCreated>'2019-02-22 00:00:00'  --时间过滤
	and	bb.RecordID = 
	(SELECT max(g.RecordID) FROM Pts_Records g(NOLOCK), Pts_ProblemState h(nolock)  
	WHERE g.StateID=h.ProblemStateID AND h.StateName in ('已确认') and a.ProblemID=g.ProblemID
	             )      
	and d.DeptID in ('5','24','25') 
	and (DATEDIFF(DAY,bb.DateCreated,isnull(b.DateCreated,GETDATE()))>1 or b.Title not like '%2018-%') --未分配取当前时间对比
	and a.ProjectID in ('47','48','49','50','53','57')
	and g.DeptID in ('5','24','25')
	
--------------------------超过24小时未分配回复--------------------end---------


------------------------超时 统计-------------begin----------------------
--已完成
SELECT * INTO #temp_Records
FROM Pts_Records a(nolock) 
WHERE a.DateCreated = (
	SELECT min(b.DateCreated) FROM Pts_Records b(NOLOCK), Pts_ProblemState c(nolock)  
	WHERE c.ProblemStateID=b.StateID AND c.StateName='已完成待测试' and a.ProblemID=b.ProblemID ) 
and a.DateCreated >='2019-02-22 00:00:00' AND a.DateCreated<'2019-03-01 00:00:00'
--未完成
SELECT * INTO #temp_Problems
FROM Pts_Problems a(nolock) 
WHERE a.ProblemID NOT in (
	SELECT b.ProblemID FROM Pts_Records b(NOLOCK), Pts_ProblemState c(nolock)  
	WHERE c.ProblemStateID=b.StateID AND c.StateName='已完成待测试' GROUP BY b.ProblemID ) --未完成
AND a.ProblemStateID NOT IN (
	SELECT c.ProblemStateID FROM Pts_ProblemState c(NOLOCK) WHERE c.StateName LIKE '%关闭%')  --非关闭
AND a.ProblemID in (
	SELECT b.ProblemID FROM Pts_Records b(NOLOCK), Pts_ProblemState c(nolock)  
	WHERE c.ProblemStateID=b.StateID AND c.StateName='已分配' GROUP BY b.ProblemID )  --已分配
and  a.ProjectID IN ('47','48','49','50','53','57')

select DATEDIFF(DAY,CONVERT(VARCHAR(10),a.Deadline,121),e.DateCreated) 超时, 
d.name AS 项目名称, 
a.ProblemID as ID,
a.CreateTime AS 提单时间, 
e.DateCreated as 处理时间,
(CONVERT(VARCHAR(10),a.Deadline,121)+ ' 23:59:59') 期限,
c.DisplayName as 转单人,
f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,
g.DeptName as 接单人所在部门,
a.Title AS 标题,
e.Title as 记录标题,
e.content as 记录描述,
t.StateName AS 状态
  from Pts_Problems a 
  inner join Pts_Projects d on a.ProjectID=d.ProjectID
  inner join #temp_Records e on a.ProblemID=e.ProblemID
  inner join Accounts_Users  c on e.CreateUser=c.UserID
  inner join Accounts_Department f on c.DeptID=f.DeptID
  inner join Accounts_Users h on e.AssignTo=h.UserID
  inner join Accounts_Department g on h.DeptID=g.DeptID
  inner join Pts_ProblemState t on e.StateID=t.ProblemStateID
where  
 d.ProjectID IN ('47','48','49','50','53','57')
 AND c.DisplayName<>h.DisplayName
 AND DATEDIFF(DAY,CONVERT(VARCHAR(10),a.Deadline,121),e.DateCreated)>0
 AND e.DateCreated >='2019-02-22 00:00:00' AND e.DateCreated<'2019-03-01 00:00:00'
UNION ALL
select DATEDIFF(DAY,(CONVERT(VARCHAR(10),a.Deadline,121)),GETDATE()) 超时,
d.name AS 项目名称, 
a.ProblemID as ID,
a.CreateTime AS 提单时间, 
'' as 处理时间,
(CONVERT(VARCHAR(10),a.Deadline,121)+ ' 23:59:59') 期限,
'' as 转单人,
'' as 转单人所在部门,
c.DisplayName as 接单人,
'' as 接单人所在部门,
a.Title AS 标题,
'' as 记录标题,
'' as 记录描述,
t.StateName AS 状态
  from #temp_Problems a 
  inner join Pts_Projects d on  a.ProjectID=d.ProjectID
  inner join Pts_ProblemState t on a.ProblemStateID=t.ProblemStateID
  inner join Accounts_Users c on a.AssignedTo=c.UserID and c.DeptID='5'
where   
 DATEDIFF(DAY,GETDATE(),(CONVERT(VARCHAR(10),a.Deadline,121)))<0
 AND a.Deadline<'2019-03-01 00:00:00'


DROP TABLE #temp_Records;
DROP TABLE #temp_Problems;
----------------------超时 统计---------------end---------------------




 
---------------------------------已确认统计-------------------------------------------------
select f.Name AS 项目名称,a.ProblemID as ID,a.CreateTime AS 提单时间,e.DateCreated as 处理时间,
h.DisplayName as 转单人,g.StateName as 转单状态,c.DisplayName as 接单人,d.TypeName 类型,
a.Title AS 标题,e.Title as 记录标题,e.content as 记录描述,isnull(a.Text6,a.Text5) as BUG来源ID,a.BigText2 as BUG来源描述,
b.StateName AS 状态 from pts_problems a 
inner join Pts_ProblemState b on a.ProblemStateID=b.ProblemStateID --当前状态
inner join Pts_Records e on a.ProblemID=e.ProblemID --转单记录
inner join Accounts_Users c on e.AssignTo=c.UserID --接单人
inner join Accounts_Users h on e.CreateUser=h.UserID --转单人
inner join Pts_ProblemType d on a.ProblemTypeID=d.ProblemTypeID --类型
inner join Pts_Projects f on a.ProjectID=f.ProjectID --项目
inner join Pts_ProblemState g on e.StateID=g.ProblemStateID --转单状态
where  
e.StateID IN (SELECT f.ProblemStateID FROM Pts_ProblemState f (nolock) WHERE f.StateName='已确认')
and e.DateCreated >= '2019-02-22 00:00:00' AND e.DateCreated <'2019-03-01 00:00:00'
and a.ProjectID in ('47','48','49','50','53','57')
and c.DeptID in ('5','24','25') 



-------------------------------申请变更 统计--------------------------------------
select d.name AS 项目名称, 
a.ProblemID as ID,
a.CreateTime AS 提单时间, 
e.DateCreated as 处理时间,
c.DisplayName as 转单人,
f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,
g.DeptName as 接单人所在部门,
a.Title AS 标题,
e.title 转单标题 ,
e.content 转单内容,
j.statename 状态
  from Pts_Problems a 
  inner join Pts_Projects d on a.ProjectID=d.ProjectID
  inner join Pts_Records e on a.ProblemID=e.ProblemID
  inner join Accounts_Users  c on e.CreateUser=c.UserID
  inner join Accounts_Department f on c.DeptID=f.DeptID and f.DeptID  in ('5','24','25') 
  inner join Accounts_Users h on e.AssignTo=h.UserID
  inner join Accounts_Department g on h.DeptID=g.DeptID
  inner join pts_problemstate j on e.StateID=j.ProblemStateID AND j.StateName='申请变更'
where 
a.ProjectID IN ('47','48','49','50','53','57')
and c.DisplayName<>h.DisplayName
AND e.DateCreated >= '2019-02-22 00:00:00' AND e.DateCreated <'2019-03-01 00:00:00'
ORDER BY a.ProblemID;


-----------------------------已变更 统计-------------------------------------------------

select d.name AS 项目名称, 
a.ProblemID as ID,
a.CreateTime AS 提单时间, 
e.DateCreated as 处理时间,
c.DisplayName as 转单人,
f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,
g.DeptName as 接单人所在部门,
a.Title AS 标题,
e.title 转单标题 ,
e.content 转单内容,
j.statename 状态
  from Pts_Problems a 
  inner join Pts_Projects d on a.ProjectID=d.ProjectID
  inner join Pts_Records e on  a.ProblemID=e.ProblemID
  inner join Accounts_Users  c on e.CreateUser=c.UserID
  inner join Accounts_Department f on c.DeptID=f.DeptID
  inner join Accounts_Users h on e.AssignTo=h.UserID
  inner join Accounts_Department g on h.DeptID=g.DeptID and g.DeptID in ('5','24','25') 
  inner join pts_problemstate j on e.StateID=j.ProblemStateID AND j.StateName='已变更'
where  
   a.ProjectID IN ('47','48','49','50','53','57')
AND c.DisplayName<>h.DisplayName
AND e.DateCreated>='2019-02-22 00:00:00' AND e.DateCreated<'2019-03-01 00:00:00'
ORDER BY a.ProblemID;



