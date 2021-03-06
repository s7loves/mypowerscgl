update dbo.E_LevelSeason set levelNum=(select  count(*) from dbo.E_Level where SeasonID=dbo.E_LevelSeason.ID);
/****** 对象:  Trigger [dbo].[Trigger_Level_UpdataChat]    脚本日期: 11/21/2013 21:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[Trigger_Level_UpdataChat]
   ON  [dbo].[E_Level]
   AFTER  INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    insert into dbo.E_LevelChat(ByScol1) Values('');
	SET NOCOUNT ON;
    declare @SeasonID nvarchar(50),@num int
   if(exists(select 1 from inserted))
     set @SeasonID=(select SeasonID from inserted )
   if(exists(select 1 from deleted))
     set @SeasonID=(select SeasonID from deleted )
   if(@SeasonID is not NULL)
    begin
    set @num=(select count(*) from dbo.E_Level where SeasonID=@SeasonID)
    update dbo.E_LevelSeason set LevelNum=@num where ID=@SeasonID;
    end
    -- Insert statements for trigger here

END


/****** 对象:  Trigger [dbo].[Trigger_Season_UpdataChat]    脚本日期: 11/16/2013 12:23:01 ******/
SET ANSI_NULLS ON
