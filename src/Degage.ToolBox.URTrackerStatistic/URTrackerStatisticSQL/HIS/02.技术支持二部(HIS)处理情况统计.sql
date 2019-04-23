 ------------------------以下为"技术支持处理情况统计"用--------------------
----------更新URT单结束时间----------------------------begin--------------------------------
---获取已分配单的单号和摘要（计划完成时间）--
SELECT a.ProblemID,a.Title,a.DateCreated
INTO #temp_Records
FROM Pts_Records a(nolock)
inner join Pts_Problems d(nolock)  on a.ProblemID = d.ProblemID
WHERE a.DateCreated = (SELECT max(b.DateCreated)  ---取最近时间，包含已变更的
						FROM Pts_Records b(NOLOCK), 
						Pts_ProblemState c(nolock)  
						WHERE c.ProblemStateID=b.StateID 
						AND c.StateName='已分配' 
						and a.ProblemID=b.ProblemID
						AND ISDATE(b.Title)=1 -- 日期格式
						 )
AND a.StateID in ('427','249','260','443','303','332','346','366','376','396','412','458') ---分别对应的“已分配状态”
and d.ProjectID in ('19','38','39','41','44','47','48','50','51','53','55','57')
AND a.Title<>'----事务转移----'
and not exists 
(select top 1 1 from Pts_Records a where a.StateID in ('434','268','471','311','420','466') and a.ProblemID=d.ProblemID)  ---268同意变更,排除已变更
and a.DateCreated >= convert(char(10),GETDATE()-1,120)

select a.ProblemID,
case when ISNUMERIC(LEFT(c.Title,1))=1 then CONVERT(varchar(10),LEFT(c.Title,10),21)
when ISNUMERIC(right(c.Title,1))=1 then CONVERT(varchar(10),RIGHT(c.Title,10),21)
ELSE null END  [endtime]
into #Pts_Problems
from Pts_Problems a(nolock)
inner join Pts_ProblemState b(nolock) on a.ProblemStateID = b.ProblemStateID and a.ProjectID = b.ProjectID
inner join #temp_Records c(nolock) on a.ProblemID = c.ProblemID 
where a.ProjectID in ('19','38','39','41','44','47','48','50','51','53','55','57')
AND c.Title<>'----事务转移----'

update pp set pp.Deadline = pp1.endtime  from Pts_Problems pp 
inner join #Pts_Problems pp1 on pp.ProblemID=pp1.ProblemID 
where  
convert(varchar(10),pp.Deadline,120) <> pp1.endtime
AND ISDATE(pp1.endtime)=1  --输入的文本可以转化为日期
AND CASE WHEN ISDATE(pp1.endtime)=1 THEN CAST(pp1.endtime AS DATETIME) ELSE GETDATE()-1 END >= convert(char(10),GETDATE(),120)--排除计划时间小于当前时间的

drop table #Pts_Problems
drop table #temp_Records

-----------更新URT单结束时间-------------------------------end---------------------------------------


-----------------------------本周完成---------------begin-------------------
select
case when (c.DisplayName in ('李嘉怡','黄冠祺','李拥强','聂先职','王燕滨','谢红梅','张磊')) then '技术二部EMR' else '技术二部HIS' end 部门,
	a.ProblemID as ID,
	--bb.RecordID as RecordID,
	c.DisplayName 转单人,
	d.DisplayName 接单人,
	b.DateCreated 转单时间,
	g.TypeName 类型,
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
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID and d.DeptID='1'  --转到项目管理中心 
inner join pts_problemstate f(nolock) on b.StateID=f.ProblemStateID
inner join Pts_ProblemType g(nolock) on a.ProblemTypeID=g.ProblemTypeID --类型
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
where  b.RecordID = 
	(SELECT min(g.RecordID) FROM Pts_Records g(NOLOCK) 
	inner join Pts_ProblemState h(nolock) on g.StateID=h.ProblemStateID  
	inner join Accounts_Users i(nolock) on g.CreateUser=i.UserID 
	WHERE a.ProblemID=g.ProblemID
	and h.StateName in ('已完成待测试','需求更新') 
	and (i.DeptID in ('2','25') or (i.DeptID in ('12') and DisplayName='丁鹏云' ))  ---技术部转出,含研发二部高雪媚处理的电子病历需求
	)
	and a.ProjectID in ('38','39','55','44','19','41','49','57')
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
 AND (g.DeptID=2     or (g.DeptID='12' and h.DisplayName='丁鹏云')) --转入技术
AND e.DateCreated  >='2019-02-22 00:00:00'
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
 AND (f.DeptID=2  or (f.DeptID=12 and c.DisplayName='丁鹏云'))  --技术转出
AND e.DateCreated  >='2019-02-22 00:00:00'
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
inner join 	Accounts_Users  c on a.AssignedTo=c.UserID and   (c.DeptID='2' or (c.DeptID='12' and C.DisplayName='丁鹏云'))
inner join 	Accounts_Department f on  c.DeptID=f.DeptID
where  a.ProjectID in ('38','39','55','44','19','41','49','57')
and j.StateName not like '%关闭%'
and not exists (Select top 1 1 from #in i where a.ProblemID=i.ID )---排除转入

select 
case when (name in ('李嘉怡','黄冠祺','李拥强','聂先职','王燕滨','谢红梅','张磊')) then '技术二部EMR' else '技术二部HIS' end 部门,
name 当前处理人,count(id) 需求单数 from
(
select * from #out WHERE TypeID in ('107','109','172','127','53','117','144') --需求
union all
select * from #now WHERE TypeID in ('107','109','172','127','53','117','144') --需求
)a  group by name

select 
case when (name in ('李嘉怡','黄冠祺','李拥强','聂先职','王燕滨','谢红梅','张磊')) then '技术二部EMR' else '技术二部HIS' end 部门,
name 当前处理人,count(id) 缺陷单数 from
(
select * from #out WHERE TypeID in ('106','108','171','126','52','116','143') --缺陷
union all
select * from #now WHERE TypeID in ('106','108','171','126','52','116','143') --缺陷
)a  group by name

drop table #in
drop table #out
drop table #now


----------------截止到周四，技术剩余单-----------end-----------------------------------  


--------------------------超过24小时未确认回复(不符1)--------------------begin---------
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
	and (d.DeptID='2'  or (d.DeptID='12' and d.DisplayName='丁鹏云'))
	and b.DateCreated>'2019-02-22 00:00:00'  
	and f.statename=e.statename  ---转单状态与当前单状态一致，说明未处理
	--and DATEDIFF(hour,b.DateCreated,GETDATE())>48
	and DATEDIFF(DAY,b.DateCreated,GETDATE())>1
	and a.ProjectID in ('38','39','55','44','19','41','49','57')
	and (g.DeptID='2'or (g.DeptID='12' and g.DisplayName='丁鹏云'))
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
	and (d.DeptID='2' or (d.DeptID='12' and d.DisplayName='丁鹏云'))
	and (DATEDIFF(DAY,bb.DateCreated,isnull(b.DateCreated,GETDATE()))>1 or (b.Title not like '%2016-%' and b.Title not like '%2017-%')) --未分配取当前时间对比
	and a.ProjectID in ('38','39','55','44','19','41','49','57')
	and (g.DeptID='2' or (g.DeptID='12' and d.DisplayName='丁鹏云'))
	and DATEDIFF(DAY,bb.DateCreated,isnull(b.DateCreated,GETDATE()))<>0
--------------------------超过24小时未分配回复--------------------end---------


------------------------超时 统计(不符2)-------------begin----------------------
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
and  a.ProjectID IN ('38','39','55','44','19','41','49','57')

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
 d.ProjectID IN ('38','39','55','44','19','41','49','57')
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
  inner join Accounts_Users c on a.AssignedTo=c.UserID --and c.DeptID='2'
where   
 DATEDIFF(DAY,GETDATE(),(CONVERT(VARCHAR(10),a.Deadline,121)))<0
 AND a.Deadline<'2019-03-01 00:00:00'
 and t.StateName not in ('需求确认','需求更新')


DROP TABLE #temp_Records;
DROP TABLE #temp_Problems;
----------------------超时 统计---------------end---------------------


---------------------------------已确认 统计-------------------------------------------------
select f.Name AS 项目名称,a.ProblemID as ID,a.CreateTime AS 提单时间,e.DateCreated as 处理时间,
h.DisplayName as 转单人,g.StateName as 转单状态,c.DisplayName as 接单人,d.TypeName 类型,
a.Title AS 标题,e.Title as 记录标题,e.content as 记录描述,b.StateName AS 状态 
from pts_problems a 
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
and a.ProjectID in ('38','39','55','41','49','19','44') 
and (c.DeptID='2' or (c.DeptID='12' and c.DisplayName='丁鹏云'))


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
  inner join Accounts_Department f on c.DeptID=f.DeptID and (f.DeptID='2' or (f.DeptID='12' and c.DisplayName='丁鹏云'))
  inner join Accounts_Users h on e.AssignTo=h.UserID
  inner join Accounts_Department g on h.DeptID=g.DeptID
  inner join pts_problemstate j on e.StateID=j.ProblemStateID AND j.StateName='申请变更'
where 
a.ProjectID IN ('38','39','55','44','19','41','49','57')
and c.DisplayName<>h.DisplayName
AND e.DateCreated >= '2019-02-22 00:00:00' AND e.DateCreated <'2019-03-01 00:00:00'
--20171218GY
and e.RecordID=(SELECT max(g.RecordID) FROM Pts_Records g(NOLOCK) 
	inner join Pts_ProblemState h(nolock) on g.StateID=h.ProblemStateID  
	inner join Accounts_Users i(nolock) on g.CreateUser=i.UserID
	WHERE
    a.ProblemID=g.ProblemID 
	and h.StateName in ('申请变更') 
	and (i.DeptID='2' or (i.DeptID='12' and i.DisplayName='丁鹏云'))  ---技术转入申请变更
	and g.DateCreated >= '2019-02-22 00:00:00' AND g.DateCreated <'2019-03-01 00:00:00'
	)      ---取最后转入记录 
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
  inner join Accounts_Department g on h.DeptID=g.DeptID and (g.DeptID='2' or (g.DeptID='12' and h.DisplayName='丁鹏云'))
  inner join pts_problemstate j on e.StateID=j.ProblemStateID AND j.StateName='已变更'
where  
   a.ProjectID IN ('38','39','55','44','19','41','49','57')
AND c.DisplayName<>h.DisplayName
AND e.DateCreated>='2019-02-22 00:00:00' AND e.DateCreated<'2019-03-01 00:00:00'
--20171218GY
and e.RecordID=(SELECT max(g.RecordID) FROM Pts_Records g(NOLOCK) 
	inner join Pts_ProblemState h(nolock) on g.StateID=h.ProblemStateID  
	inner join Accounts_Users i(nolock) on g.AssignTo=i.UserID
	WHERE
    a.ProblemID=g.ProblemID 
	and h.StateName in ('已变更') 
	and (i.DeptID='2' or (i.DeptID='12' and i.DisplayName='丁鹏云'))  ---已变更
	and g.DateCreated >= '2019-02-22 00:00:00' AND g.DateCreated <'2019-03-01 00:00:00'
	)      ---取最后转入记录 
ORDER BY a.ProblemID;









---------统计计划时间超两周数据--------
select
   DATEDIFF(DAY,b.DateCreated,a.Deadline) 天数,
   isnull(b.DateCreated,GETDATE()) 分配时间,
	a.ProblemID as ID,
	c.DisplayName 转单人,
	d.DisplayName 接单人,
    a.Deadline 结束时间,
	f.statename 转单状态,
	g.DisplayName 当前处理人,
	e.statename 当前状态,
	b.Title 转单标题,
	b.content AS 转单内容,
	bb.Title AS 审核标题,
	bb.content AS 审核内容,
	a.Title AS 标题,
	a.BigText1 AS 描述
from Pts_Problems a(nolock)
left join Pts_Records b(nolock) on a.ProblemID=b.ProblemID 
                   and b.RecordID = 
	(SELECT max(g.RecordID) FROM Pts_Records g(NOLOCK), Pts_ProblemState h(nolock)  
	WHERE g.StateID=h.ProblemStateID AND h.StateName in ('已分配') 
	    and a.ProblemID=g.ProblemID
		AND ISDATE(g.Title)=1 -- 日期格式
		)
inner join Accounts_Users c(nolock) on b.CreateUser=c.UserID
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID and d.DeptID='2' 
inner join Accounts_Users g(nolock) on a.AssignedTo=g.UserID and g.DeptID='2'
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
inner join pts_problemstate f(nolock) on b.StateID=f.ProblemStateID
left join Pts_Records bb(nolock) on a.ProblemID=bb.ProblemID 
                   and bb.RecordID = 
	(SELECT max(g.RecordID) FROM Pts_Records g(NOLOCK), Pts_ProblemState h(nolock)  
	WHERE g.StateID=h.ProblemStateID AND h.StateName in ('时限审核') 
	    and a.ProblemID=g.ProblemID
		)
where 	 b.DateCreated>'2019-02-22 00:00:00'  
	and (DATEDIFF(DAY,b.DateCreated, a.Deadline))>14
	--and (DATEDIFF(DAY,'2017-02-28',a.Deadline))>15 --2017-02-28起
	and a.ProjectID in ('38','39','55','44','19','41','49','57')
	
	

