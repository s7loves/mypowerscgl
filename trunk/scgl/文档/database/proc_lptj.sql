USE [ebadascgl]
GO
/****** 对象:  StoredProcedure [dbo].[proc_lptj]    脚本日期: 06/18/2012 17:35:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--两票统计
CREATE proc [dbo].[proc_lptj] 
@year int
as 

SET NOCOUNT ON

declare @tjb   table
(
id int identity ,
dw varchar(50),
hg1 int,
bhg1 int,
yzx1 int,
zf1 int,
zxl1 int,
hgl1 int,
hj1 int,
hg2 int,
bhg2 int,
yzx2 int,
zf2 int,
zxl2 int,
hgl2 int,
hj2 int
)
--insert into @tjb values('宝山供电所',@year,2,3,4,5,6,7,1,2,3,4,5,6,7);
insert into @tjb select orgname,0,0,0,0,0,0,0,0,0,0,0,0,0,0 from morg where parentid in ('200','300') order by orgcode
insert into @tjb values('送变电工区',0,0,0,0,0,0,0,0,0,0,0,0,0,0);

select count(bj) as hg,orgname into #t1 from lp_record where 
year(createtime)=@year 
and bj='合格'
and (kind like '%gzp%' or kind like '%czp%' or kind like '%工作票%')
group by orgname

select count(bj) as bhg,orgname into #t2 from lp_record where 
year(createtime)=@year 
and bj='不合格'
and (kind like '%gzp%' or kind like '%czp%' or kind like '%工作票%')
group by orgname
select count(bj) as zf,orgname into #t3 from lp_record where 
year(createtime)=@year 
and bj='作废'
and (kind like '%gzp%' or kind like '%czp%' or kind like '%工作票%')
group by orgname

update a set a.hg1 =b.hg from @tjb a,#t1 b where a.dw=b.orgname;
--select * from #t1

update a set a.bhg1 =b.bhg from @tjb a,#t2 b where a.dw=b.orgname;
--select * from #t2
update a set a.zf1 =b.zf from @tjb a,#t3 b where a.dw=b.orgname;
--select * from #t3


--insert into 
update @tjb set yzx1=hg1+bhg1,yzx2=hg2+bhg2
update @tjb set hj1=yzx1+zf1,hj2=yzx2+zf2
update @tjb set hgl1=hg1*100/yzx1 where yzx1>0
update @tjb set hgl2=hg2*100/yzx2 where yzx2>0
update @tjb set zxl1=yzx1*100/hj1 where hj1>0
update @tjb set zxl2=yzx2*100/hj2 where hj2>0
select * from @tjb;


