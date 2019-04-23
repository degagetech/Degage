


---02.技术支持二部处理情况统计

	
-----------------------------返工 统计-----------------------------------------
SELECT distinct  * from (
SELECT distinct 

case when d.DisplayName in ('李嘉怡','黄冠祺','李拥强','聂先职','高雪媚') then '技术二部EMR' else '技术二部HIS' end 部门,
  a.ProblemID as 单号,
  d.DisplayName as   当前处理人,
  case when (isnull(a.Select2,'')<>'' )then a.Select2 else  p.name end 系统,
  a.select1 客户,
  ''  类别,
 ''  返工情况 
FROM Pts_Problems a(nolock) 
inner join Pts_Records b(nolock) on a.ProblemID=b.ProblemID
inner join pts_problemstate c(nolock) on b.StateID=c.ProblemStateID
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID
left join Pts_ProblemCatalogs p on a.ProblemCatalogID=p.ProblemCatalogID
WHERE 
a.ProjectID IN ('38','39','55','44','19','41','49','57')
and c.StateName='返工' and b.DateCreated >='2019-02-22 00:00:00' ---本周返工
and (d.DeptID='2' or  d.DisplayName='丁鹏云')
union all
SELECT distinct 
case when d.DisplayName in ('李嘉怡','黄冠祺','李拥强','聂先职','高雪媚') then '技术二部EMR' else '技术二部HIS' end 部门,
  a.ProblemID as 单号,
  d.DisplayName as   当前处理人,
  case when (isnull(a.Select2,'')<>'' )then a.Select2 else  p.name end 系统,
  a.select1 客户,
  ''  类别,
 ''  返工情况 
FROM Pts_Problems a(nolock) 
inner join Pts_Records b(nolock) on a.ProblemID=b.ProblemID 
inner join pts_problemstate c(nolock) on a.ProblemStateID=c.ProblemStateID 
inner join Accounts_Users d(nolock) on b.AssignTo=d.UserID and b.StateID='266'
left join Pts_ProblemCatalogs p on a.ProblemCatalogID=p.ProblemCatalogID
WHERE 
a.ProjectID IN ('38','39','55','44','19','41','49','57')
and c.StateName='返工'   --返工还未处理
and (d.DeptID='2' or  d.DisplayName='丁鹏云')
)a


----3.
SELECT distinct a.ProblemID,a.ProjectID,b.DateCreated,a.Title 
--INTO #Pts_Problems
FROM Pts_Problems a(nolock) 
left join Pts_Records b(nolock) on a.ProblemID=b.ProblemID
left join pts_problemstate c(nolock) on b.StateID=c.ProblemStateID
WHERE b.DateCreated >'2019-02-22 00:00:00' 
and c.StateName='返工' AND a.ProjectID IN ('47','48','49','50','53','57')

---4


