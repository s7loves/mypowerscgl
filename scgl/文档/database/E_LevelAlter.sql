
/****** 对象:  Table [dbo].[E_LevelChat]    脚本日期: 11/16/2013 12:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_LevelChat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatTime] [datetime] NULL CONSTRAINT [DF_E_LevelChat_CreatTime]  DEFAULT (getdate()),
	[ByScol1] [nvarchar](50) NULL,
	[BySco2] [nvarchar](50) NULL,
 CONSTRAINT [PK_E_LevelChat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



/****** 对象:  Trigger [dbo].[Trigger_Level_UpdataChat]    脚本日期: 11/16/2013 12:22:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[Trigger_Level_UpdataChat]
   ON  [dbo].[E_Level]
   AFTER  INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    insert into dbo.E_LevelChat(ByScol1) Values('');
	SET NOCOUNT ON;

    -- Insert statements for trigger here

END


/****** 对象:  Trigger [dbo].[Trigger_Season_UpdataChat]    脚本日期: 11/16/2013 12:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[Trigger_Season_UpdataChat]
   ON  [dbo].[E_LevelSeason]
   AFTER  INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    insert into dbo.E_LevelChat(ByScol1) Values('');
	SET NOCOUNT ON;

    -- Insert statements for trigger here

END



/****** 对象:  Trigger [dbo].[Trigger_LevStop_UpdataChat]    脚本日期: 11/16/2013 12:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[Trigger_LevStop_UpdataChat]
   ON  [dbo].[E_LevelStop]
   AFTER  INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    insert into dbo.E_LevelChat(ByScol1) Values('');
	SET NOCOUNT ON;

    -- Insert statements for trigger here

END
