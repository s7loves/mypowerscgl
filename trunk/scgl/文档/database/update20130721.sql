USE [ebadascgl]
GO
/****** 对象:  StoredProcedure [dbo].[p_buildxlpath]    脚本日期: 07/21/2013 17:11:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_buildxlpath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_buildxlpath]
go
--生成线路路径
create PROCEDURE [dbo].[p_buildxlpath]  
as
SET NOCOUNT ON;
print '生成10kv线路路径';
declare @code nvarchar(50);
declare @name nvarchar(100);
declare @path nvarchar(250);
declare @precode nvarchar(50) ;

set @precode='';
declare  @t1 table (
rowid int,
lineid nvarchar(50),
linecode nvarchar(50),
linename nvarchar(50),
parentid nvarchar(50),
path nvarchar (250)
);
insert into @t1 
select row_number()over(order by linecode), lineid,linecode,linename,parentid,linenamepath from ps_xl where linevol>=10.0;

update @t1 set path=linename where len(linecode)=6 or CHARINDEX(' ',linename)>0;

update t1 set path=t2.linename+' '+t1.linename
from @t1 t1,
(select * from @t1 
 where len(linecode)=6) t2

where len(t1.linecode)=10 and CHARINDEX(' ',t1.linename)<1 and t1.parentid=t2.lineid
--3级
--4级及以上
declare @count int ;
set @count=0;
while(@count<4)
begin
update t1 set path=t2.path+' '+t1.linename
from @t1 t1,
(select * from @t1 
 where len(linecode)=(10+3*@count)) t2

where len(t1.linecode)=(13+3*@count) and CHARINDEX(' ',t1.linename)<1 and t1.parentid=t2.lineid

set @count=@count+1
end
update a1 set a1.linename=a2.linename from ps_xl a1,@t1 a2 where a1.lineid=a2.lineid
select * from @t1;
/*
declare mycursor cursor for 
select linecode,linename
from ps_xl 
where linevol>=10.0 order by linecode;
--SELECT 数据行数 = @@CURSOR_ROWS
open mycursor
fetch mycursor into @code,@name;

while (@@fetch_status >= 0) begin

exec(N' delete from '+ @name)

fetch mycursor into @code,@name;


end 

close  mycursor
deallocate  mycursor
*/

go

exec [p_buildxlpath]