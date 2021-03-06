USE [ebadascgl]
GO
/****** 对象:  StoredProcedure [dbo].[p_changeLineCode]    脚本日期: 02/23/2013 17:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		rabbit
-- Create date: 2013.2.22
-- Description:	修改线路代码
-- =============================================
CREATE PROCEDURE [dbo].[p_changeLineCode]
	@OldLineCode  varchar(50) = '', 
	@NewLineCode  varchar(50) ='',
	@LineVol	  varchar(50)='',
	@user		  varchar(50)='',
	@type		  varchar(50)='PS_xl'
	
AS
BEGIN
	SET NOCOUNT ON;
--增加变更日志
begin try   
     begin tran 
insert into ps_linechanged 
select @OldLineCode,@NewLineCode,@LineVol,@type,@user,getdate(),'','','';
--更新线路代码

update a set LineCode=replace(LineCode,@OldLineCode,@NewLineCode) 
from ps_xl a where linecode like @OldLineCode+'%' and linevol=@LineVol;
--更新杆塔代码
update a set gtCode = LineCode+gth
from ps_gt a where linecode in
(
select linecode from ps_xl where linecode like @NewLineCode+'%' and linevol=@LineVol
);
if(@LineVol='10')
begin
--更新台区所属线路代码
update a set xlcode2=replace(xlcode2,@OldLineCode,@NewLineCode) 
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

commit tran    
end try   
begin catch   
     rollback tran    
end catch   
END



