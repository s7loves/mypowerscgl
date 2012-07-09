use ebadascgl
if (object_id('trig_lprecord_update', 'tr') is not null)    drop trigger trig_lprecord_update

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		<rabbit>
-- Create date: <2012.7.9>
-- Description:	<status�ı��Ƿ���,������Ʊ�ϸ���>
-- =============================================
create TRIGGER [trig_lprecord_update]
   ON [dbo].[LP_Record] after   UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

declare @status nvarchar(50),@id nvarchar(50)

select @status = status,@id=id from inserted

if(@status='ǩ��')
begin
	update lp_record  set bj='�ϸ�' where id=@id
end

END


