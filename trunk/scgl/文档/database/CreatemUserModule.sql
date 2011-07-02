use [EbadaScgl]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mUserModule]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mUserModule](
	[ID] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[mMouleID] [nvarchar](50) NULL,
	[SortID] [int] NULL,
	[mMouleName] [nvarchar](100) NULL,
	[mMouleParentID] [nvarchar](50) NULL
) ON [PRIMARY]
END
