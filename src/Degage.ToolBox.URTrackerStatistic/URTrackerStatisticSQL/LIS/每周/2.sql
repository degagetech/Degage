

----------超10h-----------------
SELECT * FROM  #c10h
----------已分配-----------------
SELECT * FROM  #yfp
----------已完成-----------------
select * from  #wc1
----------剩余单-----------------
select * from  #xq
----------申请变更-----------------
select * from  #sqbg
----------已变更-----------------
select * from  #ybg
----------月已完成-----------------
select * from  #ywc1

----------返工-----------------
select * from  #fg


select  #emp.name
,提单总数
,申请变更,已变更,完成
,完成工时,剩余单数
,本月完成,本月工时
 from  #emp
left join  #1 on #emp.name=#1.name
left join  #2 on #emp.name=#2.name
left join  #3 on #emp.name=#3.name
left join  #4 on #emp.name=#4.name
left join  #5 on #emp.name=#5.name
left join  #6 on #emp.name=#6.name


--------------删除临时表-----------------
--drop table #emp  drop table #c10h
--drop table #temp_Records    drop table #yfp
--drop table #wc1   drop table #wc2
--drop table #xq    drop table  #sqbg 
--drop table  #ybg 
--drop table #ywc1  drop table #ywc2
--drop table  #1   drop table  #2 
--drop table  #3   drop table  #4 
--drop table  #5   drop table  #6
--drop table  #Pts_Problems   drop table  #fg