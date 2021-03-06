
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		rabbit
-- Create date: 2013.2.22
-- Last Editdate:2013.2.28
-- Description:	修改台区代码
-- =============================================
ALTER PROCEDURE [dbo].[p_changeTQCode]
	@OldCode  varchar(50) = '', 
	@NewCode  varchar(50) ='',
@LineVol	  varchar(50)='0.4',
	@user		  varchar(50)='',
	@type		  varchar(50)='PS_tq'
AS
BEGIN
	
--增加变更日志
begin try   
     begin tran 
insert into ps_linechanged 
select @OldCode,@NewCode,@LineVol,@type,@user,getdate(),'','','';
--更新台区代码
update a set tqCode=@NewCode
from ps_tq a where tqCode=@OldCode;

--更新线路代码
update a set LineCode=replace(LineCode,@OldCode,@NewCode) 
from ps_xl a where linecode like @OldCode+'%' and linevol='0.4';
--更新线路ParentID
update ps_xl set parentid=@NewCode where parentid=@OldCode and linevol='0.4';

--更新杆塔代码
update a set gtCode = replace(gtCode,@OldCode,@NewCode) 
from ps_gt a where linecode in
(
select linecode from ps_xl where linecode like @NewCode+'%' and linevol='0.4'
);
--更新出线杆塔号
update ps_xl set parentgt = replace(parentgt,@OldCode,@NewCode) 
where linecode like @NewCode+'%' and linevol=@LineVol;

--更新所属供电所
update ps_xl set orgcode = substring(@NewCode,1,3)
where linecode like @NewCode+'%' and linevol=@LineVol;

--更新变压器
update a set byqcode = replace(byqCode,@OldCode,@NewCode) 
from ps_tqbyq a where  byqcode like @OldCode+'%';

commit tran    
end try   
begin catch   
     rollback tran    
end catch   

END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

