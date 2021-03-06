set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		rabbit
-- Create date: 2013.2.22
-- Last Editdate:2013.2.28
-- Description:	修改线路代码
-- =============================================
ALTER PROCEDURE [dbo].[p_changeLineCode]
	@OldLineCode  varchar(50) = '', 
	@NewLineCode  varchar(50) ='',
	@LineVol	  varchar(50)='',
	@user		  varchar(50)='p',
	@type		  varchar(50)='PS_xl'
	
AS
BEGIN
	SET NOCOUNT ON;
--增加变更日志
begin try   
     begin tran 
insert into ps_linechanged 
select @OldLineCode,@NewLineCode,@LineVol,@type,@user,getdate(),'','','';

if(@LineVol='10')
begin
	--更新台区所属线路代码

	update a set xlcode2=replace(xlcode2,@OldLineCode,@NewLineCode) 
--select * 
	from ps_tq a where xlcode2 in 
	(
	select linecode from ps_xl where linecode like @OldLineCode+'%' and linevol=@LineVol
	)
	if(len(@OldLineCode)=6)
	begin
		update a set xlcode=replace(xlcode,@OldLineCode,@NewLineCode) 
		from ps_tq a where xlcode in 
		(
		select linecode from ps_xl where linecode like @OldLineCode+'%' and linevol=@LineVol
		)

	end
end

--更新线路代码

update a set LineCode=replace(LineCode,@OldLineCode,@NewLineCode) 
from ps_xl a where linecode like @OldLineCode+'%' and linevol=@LineVol;
--更新杆塔代码
update a set gtCode = replace(gtCode,@OldLineCode,@NewLineCode) 
from ps_gt a where linecode in
(
select linecode from ps_xl where linecode like @NewLineCode+'%' and linevol=@LineVol
);
--更新出线杆塔号
update ps_xl set parentgt = replace(parentgt,@OldLineCode,@NewLineCode) 
where linecode like @NewLineCode+'%' and linevol=@LineVol;
if(len(@NewLineCode)=6)
begin
--更新所属供电所
update ps_xl set orgcode = substring(@NewLineCode,1,3)
where linecode like @NewLineCode+'%' and linevol=@LineVol;

end


commit tran    
end try   
begin catch   
     rollback tran    
end catch   
END





