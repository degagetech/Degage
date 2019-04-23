


----------------月底技术二部需求统计-------------begin--------------------------------
------转入
select  
a.ProblemID as ID,
h.DisplayName
into #in
from Pts_Problems a 
inner join Pts_Records e on a.ProblemID=e.ProblemID and e.IsKeyRecord=1
inner join Accounts_Users  c on e.CreateUser=c.UserID  --转单人
inner join Accounts_Department f on c.DeptID=f.DeptID
inner join Accounts_Users h on e.AssignTo=h.UserID  --接单人
inner join pts_problemstate i on e.StateID=i.ProblemStateID --类型 
inner join Accounts_Department g on h.DeptID=g.DeptID
inner join pts_problemstate j on a.ProblemStateID=j.ProblemStateID and j.StateName not like '%关闭%'
inner join Pts_Projects d on a.ProjectID=d.ProjectID 
where 	e.RecordID = 
	(SELECT max(k.RecordID) FROM Pts_Records k(NOLOCK) 
	inner join Pts_ProblemState h(nolock) on k.StateID=h.ProblemStateID  
	inner join Accounts_Users i(nolock) on k.CreateUser=i.UserID
	WHERE
    a.ProblemID=k.ProblemID 
	AND h.StateName in ('已确认','需求确认','待确定方案','返工','已分配') 
	)      
 --c.DisplayName<>h.DisplayName
 AND (g.DeptID=2 or h.DisplayName='丁鹏云' ) --转入技术
--AND e.DateCreated  >='2018-02-26 00:00:00' ----月底前三天
AND e.DateCreated  >=cast(convert(varchar(7), getdate(), 121) + '-01' as datetime)-3 ----月底前三天
ORDER BY a.ProblemID;

------转出
select  
a.ProblemID as ID
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
 AND (f.DeptID=2 or c.DisplayName='丁鹏云')  --技术转出
--AND e.DateCreated  >='2018-03-01 00:00:00'  
AND e.DateCreated  >=cast(convert(varchar(7), getdate(), 121) + '-01' as datetime)
and not exists (Select top 1 1 from #in i where a.ProblemID=i.ID )---排除这时间后转入的
ORDER BY a.ProblemID;

-------当前
select distinct
a.ProblemID as ID
into #now
from Pts_Problems a 
inner join 	pts_problemstate j on  a.ProblemStateID=j.ProblemStateID
inner join 	Pts_Records e on a.ProblemID=e.ProblemID  and e.IsKeyRecord=1
inner join 	pts_problemstate b on e.StateID=b.ProblemStateID
inner join 	Accounts_Users  c on a.AssignedTo=c.UserID and (c.DeptID='2' or c.DisplayName='丁鹏云')
inner join 	Accounts_Department f on  c.DeptID=f.DeptID
where  a.ProjectID in ('38','39','55','44','19','41','49')
and j.StateName not like '%关闭%'
and not exists (Select top 1 1 from #in i where a.ProblemID=i.ID )---排除转入

select * into #Pts_Problems from Pts_Problems where ProblemID in (
select * from #out 
union all
select * from #now 
)

select
	h.DisplayName 当前处理人,
	COUNT(*)
from #Pts_Problems a(nolock)
inner join Accounts_Users h(nolock) on a.AssignedTo=h.UserID
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
inner join pts_problemstate f(nolock) on a.ProblemStateID=f.ProblemStateID
group by h.DisplayName

select
   a.Deadline 计划完成时间,
	a.ProblemID as 单号,
	h.DisplayName 当前处理人,
	e.statename 当前状态,
	f.statename 转单状态,
	a.Title AS 标题,
	a.BigText1 AS 描述
from #Pts_Problems a(nolock)
inner join Accounts_Users h(nolock) on a.AssignedTo=h.UserID
inner join pts_problemstate e(nolock) on a.ProblemStateID=e.ProblemStateID
inner join pts_problemstate f(nolock) on a.ProblemStateID=f.ProblemStateID


drop table #in
drop table #out
drop table #now
drop table #Pts_Problems

----------------月底技术二部需求统计----------------end-----------------------------------  
 
 
--select * from pts_problems where AssignedTo='215'
 


