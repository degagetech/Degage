declare @sdate datetime
declare @edate datetime 
declare @sdate2 datetime
declare @edate2 datetime 
set @sdate='2019-03-15 17:30:01'
set @edate='2019-03-22 17:30:00'
set @sdate2='2019-03-01 00:00:01'
set @edate2='2019-03-22 23:59:59'
----------人员列表-----------------
create  table #emp
(id int,
name varchar(20))
insert into #emp values ('1','陈瑞光')
insert into #emp values ('2','何卓宏')
insert into #emp values ('3','黄启明')
insert into #emp values ('4','区锦锋')
insert into #emp values ('5','苏海涛')
insert into #emp values ('6','王浪静')
insert into #emp values ('7','许院鹏')
insert into #emp values ('8','林志宏')




-------超过10h的单-------------
select  a.ProblemID as ID,d.name AS 项目名称,a.select1 as 医院,
c.DisplayName as 转单人,
a.Title AS 标题,a.BigText1 AS 描述,
a.Float1 as 工作量H into #c10h
  from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,Pts_Records e,Accounts_Department f ,Accounts_Users h ,
Accounts_Department g,pts_problemstate j
where  
 e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
 AND a.ProblemID=e.ProblemID
 AND h.DisplayName<>'董雪娟'
 AND c.DisplayName<>h.DisplayName
 AND g.DeptID=1
 and a.Float1>10
 and  j.statename='已完成待测试'
 and f.DeptName in ('技术支持一部','运维一部')
 --AND f.DeptID IN (1,2,4,5,9,10,11,12,13,14,15,16,17,18,19,20,21,22)
AND e.DateCreated  >=@sdate
and  e.DateCreated<=@edate
ORDER BY a.ProblemID;

----------已分配-----------------

SELECT * 
INTO #temp_Records
FROM Pts_Records a(nolock) WHERE a.DateCreated = (SELECT min(b.DateCreated) FROM Pts_Records b(NOLOCK),
 Pts_ProblemState c(nolock)  WHERE c.ProblemStateID=b.StateID AND c.StateName='已分配' 
 and a.ProblemID=b.ProblemID )
AND a.StateID IN (SELECT d.ProblemStateID FROM Pts_ProblemState d (nolock) 
WHERE d.StateName='已分配') 
and a.DateCreated >=@sdate AND a.DateCreated <=@edate

select d.name AS 项目名称, a.ProblemID as ID,a.CreateTime AS 提单时间, e.DateCreated as 处理时间,
c.DisplayName as 转单人,f.DeptName as 转单人所在部门,h.DisplayName as 接单人,i.TypeName 类型,
g.DeptName as 接单人所在部门,a.Title AS 标题,e.Title as 记录标题,
e.content as 记录描述,t.StateName AS 状态 
into #yfp
from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,#temp_Records e,Accounts_Department f ,
Accounts_Users h ,Accounts_Department g,Pts_ProblemState t,Pts_ProblemType i
where  
 e.CreateUser=c.UserID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
 AND a.ProblemID=e.ProblemID
  AND a.OriginProjectID=i.ProjectID and a.ProblemTypeID=i.ProblemTypeID
 --AND c.DisplayName<>h.DisplayName
 AND d.ProjectID IN ('32','33','40','45','52','56')
 AND e.StateID=t.ProblemStateID
ORDER BY a.ProblemID;

------------------已完成--------------------------
select    a.ProblemID as ID
,convert(varchar(10),a.CreateTime,120) AS 提单时间, 
e.DateCreated as 处理时间,c.DisplayName as 转单人,
f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,g.DeptName as 接单人所在部门,
a.select1 as 医院,a.Title AS 标题,a.BigText1 AS 描述,
e.title AS 转单标题 ,e.content AS 转单内容,
d.name AS 项目名称,j.statename AS 状态,a.Float1 as 工作量H,
convert(varchar(10),a.Deadline,120) 期限 into #wc1
from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,
Pts_Records e,Accounts_Department f 
,Accounts_Users h ,
Accounts_Department g,pts_problemstate j
where  
 e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
 AND a.ProblemID=e.ProblemID
 AND h.DisplayName<>'董雪娟'
 AND c.DisplayName<>h.DisplayName
 AND g.DeptID=1
 and  j.statename='已完成待测试'
 and f.DeptName in ('技术支持一部','运维一部')
 AND f.DeptID IN (1,2,4,5,9,10,11,12,13,14,15,16,17,18,19,20,21,22)
AND e.DateCreated  >=@sdate
and  e.DateCreated<=@edate
ORDER BY a.ProblemID;

select distinct  ID ,转单人, isnull(工作量H,0) 工作量H into #wc2 from #wc1

--------------------------技术一部未处理需求数-----------------------------------
select  d.DeptName 部门, c.DisplayName 当前处理人,a.ProblemID ID,
convert(varchar(10),a.CreateTime,120) 建单时间,
a.Title 标题,a.BigText1 描述,e.[Name] 系统,
isnull(a.Select2,g.name) 模块,a.Select1 医院,b.StateName 状态,
convert(varchar(10),a.Deadline,120) 期限,a.Float1 as 工作量H
  into #xq
  from Pts_Problems a
  left join  pts_problemstate b on a.ProblemStateID=b.ProblemStateID
  left join Accounts_Users  c on a.AssignedTo=c.UserID
  left join Accounts_Department d on  c.DeptID=d.DeptID
  left join Pts_Projects e on a.ProjectID=e.ProjectID
  left join Pts_ProblemCatalogs g(NOLOCK) ON a.ProblemCatalogID=g.ProblemCatalogID
where 
b.statename in('已确认','已分配','未通过','待确定方案','已变更')
AND d.DeptID IN ('22','20')
ORDER BY d.DeptName, c.DisplayName

------------申请变更-------------------------------
select d.name AS 项目名称, a.ProblemID as ID,a.CreateTime AS 提单时间, e.DateCreated as 处理时间,
c.DisplayName as 转单人,f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,g.DeptName as 接单人所在部门,
a.Title AS 标题,e.title 转单标题 ,e.content 转单内容,j.statename 状态 into #sqbg
from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,Pts_Records e,
Accounts_Department f ,Accounts_Users h ,Accounts_Department g,pts_problemstate j
where  
e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
AND a.ProblemID=e.ProblemID
AND c.DisplayName<>h.DisplayName
AND a.ProjectID IN ('32','33','40','45','52','56')
AND j.StateName='申请变更'
AND e.DateCreated  >=@sdate
and  e.DateCreated<=@edate
ORDER BY a.ProblemID;



-----------已变更-------------------------------
select d.name AS 项目名称, a.ProblemID as ID,a.CreateTime AS 提单时间, e.DateCreated as 处理时间,
c.DisplayName as 转单人,f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,g.DeptName as 接单人所在部门,
a.Title AS 标题,e.title 转单标题 ,e.content 转单内容,j.statename 状态 into #ybg
from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,Pts_Records e,
Accounts_Department f ,Accounts_Users h ,Accounts_Department g,pts_problemstate j
where  
e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
AND a.ProblemID=e.ProblemID
AND c.DisplayName<>h.DisplayName
AND a.ProjectID IN ('32','33','40','45','52','56')
AND  j.StateName='已变更'
AND e.DateCreated  >=@sdate
and  e.DateCreated<=@edate
ORDER BY a.ProblemID;



----------------月已完成--------------------------
select    a.ProblemID as ID
,convert(varchar(10),a.CreateTime,120) AS 提单时间, 
e.DateCreated as 处理时间,c.DisplayName as 转单人,f.DeptName as 转单人所在部门,
h.DisplayName as 接单人,g.DeptName as 接单人所在部门,a.select1 as 医院,a.Title AS 标题,a.BigText1 AS 描述,e.title 
AS 转单标题 ,e.content AS 转单内容,
d.name AS 项目名称,j.statename AS 状态,a.Float1 as 工作量H,
convert(varchar(10),a.Deadline,120) 期限 into #ywc1
  from Pts_Problems a ,Accounts_Users  c,Pts_Projects d,Pts_Records e,Accounts_Department f ,Accounts_Users h ,
Accounts_Department g,pts_problemstate j
where  
 e.CreateUser=c.UserID
and e.StateID=j.ProblemStateID
AND c.DeptID=f.DeptID
AND e.AssignTo=h.UserID
AND h.DeptID=g.DeptID
AND a.ProjectID=d.ProjectID
 AND a.ProblemID=e.ProblemID
 AND h.DisplayName<>'董雪娟'
 AND c.DisplayName<>h.DisplayName
 AND g.DeptID=1
 and  j.statename='已完成待测试'
 and f.DeptName in ('技术支持一部','运维一部')
 AND f.DeptID IN (1,2,4,5,9,10,11,12,13,14,15,16,17,18,19,20,21,22)
AND e.DateCreated  >=@sdate2
and  e.DateCreated<=@edate2
ORDER BY a.ProblemID;

select distinct  ID ,转单人, isnull(工作量H,0) 工作量H into #ywc2 from #ywc1




----------已分配-----------------
select #emp.id,name,COUNT(#yfp.ID)提单总数 into #1 from #emp left join   #yfp
on  #emp.name=#yfp.接单人
GROUP  BY name, #emp.id
----------已完成-----------------
select #emp.id,name,count(#wc2.ID) 完成,isnull(sum(工作量H),0)完成工时 into #2  from #emp left join  #wc2
on  #emp.name=#wc2. 转单人
GROUP  BY name, #emp.id
----------剩余单-----------------
select #emp.id,#emp.name,COUNT(#xq.ID)剩余单数 into #3  from  #emp
 left join  #xq
on  #emp.name=#xq. 当前处理人
 group  by  #emp.name, #emp.id
 ----------申请变更-----------------
select #emp.id,#emp.name,COUNT(#sqbg.ID)申请变更 into #4  from  #emp
 left join  #sqbg
on  #emp.name=#sqbg. 转单人
 group  by  #emp.name, #emp.id 
 ----------已变更-----------------
 select #emp.id,#emp.name,COUNT(#ybg.ID)已变更 into #5 from  #emp
 left join  #ybg
on  #emp.name=#ybg. 接单人
 group  by  #emp.name, #emp.id 
----------月已完成-----------------
select #emp.id,name,count(#ywc2.ID) 本月完成,isnull(sum(工作量H),0)本月工时 into #6 from #emp left join  #ywc2
on  #emp.name=#ywc2. 转单人
GROUP  BY name, #emp.id




-----------------------------返工 统计-----------------------------------------
SELECT distinct b.DateCreated ,a.ProblemID,a.ProjectID,a.CreateTime,a.Title ,select1,Select2,a.ProblemCatalogID
INTO #Pts_Problems
FROM Pts_Problems a(nolock) 
left join Pts_Records b(nolock) on a.ProblemID=b.ProblemID
left join pts_problemstate c(nolock) on b.StateID=c.ProblemStateID
WHERE b.DateCreated >=@sdate 
and  b.DateCreated <=@edate 
and c.StateName='未通过' AND a.ProjectID IN ('32','33','45','56','52')

select 
'技术一部' 部门 , 
a.ProblemID as 单号,
h.DisplayName as 处理人 ,
--d.name AS 项目名称, 
case when (isnull(a.Select2,'')<>'' )then a.Select2
         when (isnull(a.Select2,'')=''  and isnull(p.name,'')<>'')then p.name 
         when (isnull(a.Select2,'')=''  and isnull(p.name,'')='') then q.name else '' end 系统,
    a.select1 客户,
' ' 类别,
cast (e.title as varchar(500)) +'  '+cast (e.content as varchar(500))  返工情况
into #fg
  from #Pts_Problems a 
  inner join Pts_Projects d on a.ProjectID=d.ProjectID
  inner join Pts_Records e on a.ProblemID=e.ProblemID
  inner join Accounts_Users  c on e.CreateUser=c.UserID
  inner join Accounts_Department f on c.DeptID=f.DeptID
  inner join Accounts_Users h on e.AssignTo=h.UserID
  inner join Accounts_Department g on h.DeptID=g.DeptID
  inner join pts_problemstate j on e.StateID=j.ProblemStateID AND j.StateName='未通过'
  left join Pts_ProblemCatalogs p(nolock) on a.ProblemCatalogID=p.ProblemCatalogID
  left join Pts_Projects q on a.ProjectID=q.ProjectID

ORDER BY a.ProblemID;



