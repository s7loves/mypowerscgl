USE [ebadascgl]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gps_carrier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gps_carrier](
	[carrier_id] [nvarchar](50) NOT NULL,
	[carrier_type] [nvarchar](50) NULL,
	[model] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[color] [nvarchar](50) NULL,
	[plate] [nvarchar](50) NULL,
	[owner] [nvarchar](50) NULL,
	[driver] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[last_modify] [nvarchar](50) NULL,
	[rowversion] [timestamp] NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_gps_carrier] PRIMARY KEY CLUSTERED 
(
	[carrier_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'载体类型,car' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'carrier_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'model'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年份' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'year'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'颜色' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'color'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车牌号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'plate'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车辆所属' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'owner'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'司机' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'driver'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'phone'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改者' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_carrier', @level2type=N'COLUMN', @level2name=N'last_modify'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gps_device]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gps_device](
	[device_id] [int] IDENTITY(1,1) NOT NULL,
	[device_serial] [nvarchar](50) NULL,
	[device_type] [nvarchar](50) NULL,
	[device_model] [nvarchar](50) NULL,
	[device_expire] [datetime] NULL,
	[device_desc] [nvarchar](50) NULL,
	[device_state] [nvarchar](50) NULL,
	[device_made_date] [datetime] NULL,
	[software_version] [nvarchar](50) NULL,
	[system_version] [nvarchar](50) NULL,
	[last_modify] [nvarchar](50) NULL,
	[rowversion] [timestamp] NULL,
	[device_owner] [nvarchar](50) NULL,
	[phone_number] [nvarchar](50) NULL,
	[sim_id] [nvarchar](50) NULL,
	[carrier_id] [nvarchar](50) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_gps_device] PRIMARY KEY CLUSTERED 
(
	[device_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gps_device]') AND name = N'IX_gps_device_serial')
CREATE UNIQUE NONCLUSTERED INDEX [IX_gps_device_serial] ON [dbo].[gps_device] 
(
	[device_serial] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [trig_gps_device_delete]
   ON  [dbo].[gps_device]
   AFTER  DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id int;
	select @id =device_id from deleted;
    delete from gps_position_now where device_id=@id;
	delete from gps_position where device_id=@id;

END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [trig_gps_device_insert]
   ON  [dbo].[gps_device]
   AFTER  INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id int;
	select @id =device_id from inserted;
    insert into gps_position_now(device_id) values(@id);

END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备标识(IMEI)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_serial'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_model'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_expire'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_desc'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状态,0-未启用,1-启用' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_state'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_made_date'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软件版本' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'software_version'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统版本' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'system_version'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改者' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'last_modify'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'rowversion'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备所属' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'device_owner'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_device', @level2type=N'COLUMN', @level2name=N'phone_number'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gps_position]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gps_position](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[device_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[lng] [float] NULL,
	[lat] [float] NULL,
	[lng2] [float] NULL,
	[lat2] [float] NULL,
	[altitude] [float] NULL,
	[speed] [float] NULL,
	[direction] [float] NULL,
	[position_type] [int] NULL,
	[gps_realtime_position] [datetime] NULL,
	[lbs_info] [nvarchar](500) NULL,
	[g_force] [float] NULL,
	[distance_from_last_gps] [float] NULL,
	[carrier_acc] [int] NULL,
	[status_byte] [int] NULL,
	[status_string] [nvarchar](500) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_gps_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gps_position]') AND name = N'IX_gps_position_date')
CREATE NONCLUSTERED INDEX [IX_gps_position_date] ON [dbo].[gps_position] 
(
	[date] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gps_position]') AND name = N'IX_gps_position_deviceid')
CREATE NONCLUSTERED INDEX [IX_gps_position_deviceid] ON [dbo].[gps_position] 
(
	[device_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'date'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'lng'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'lat'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'lng2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'lat2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'altitude'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'speed'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方向' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'direction'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定位类型,gps|基站' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'position_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定位时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'gps_realtime_position'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基站信息' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'lbs_info'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'与前一点距离' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position', @level2type=N'COLUMN', @level2name=N'distance_from_last_gps'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gps_position_now]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gps_position_now](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[device_id] [int] NULL,
	[date] [datetime] NULL CONSTRAINT [DF_gps_position_now_date]  DEFAULT (getdate()),
	[lng] [float] NULL CONSTRAINT [DF_gps_position_now_lng]  DEFAULT ((0)),
	[lat] [float] NULL CONSTRAINT [DF_gps_position_now_lat]  DEFAULT ((0)),
	[lng2] [float] NULL CONSTRAINT [DF_gps_position_now_lng2]  DEFAULT ((0)),
	[lat2] [float] NULL CONSTRAINT [DF_gps_position_now_lat2]  DEFAULT ((0)),
	[altitude] [float] NULL CONSTRAINT [DF_gps_position_now_altitude]  DEFAULT ((0)),
	[speed] [float] NULL CONSTRAINT [DF_gps_position_now_speed]  DEFAULT ((0)),
	[direction] [float] NULL CONSTRAINT [DF_gps_position_now_direction]  DEFAULT ((0)),
	[position_type] [int] NULL CONSTRAINT [DF_gps_position_now_position_type]  DEFAULT ((0)),
	[gps_realtime_position] [datetime] NULL CONSTRAINT [DF_gps_position_now_gps_realtime_position]  DEFAULT (getdate()),
	[lbs_info] [nvarchar](500) NULL,
	[g_force] [float] NULL,
	[distance_from_last_gps] [float] NULL CONSTRAINT [DF_gps_position_now_distance_from_last_gps]  DEFAULT ((0)),
	[carrier_acc] [int] NULL,
	[status_byte] [int] NULL CONSTRAINT [DF_gps_position_now_status_byte]  DEFAULT ((0)),
	[status_string] [nvarchar](500) NULL,
	[c1] [nvarchar](50) NULL,
	[c2] [nvarchar](50) NULL,
	[c3] [nvarchar](50) NULL,
 CONSTRAINT [PK_gps_position_now] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<rabbit>
-- Create date: <2013.05.22>
-- Description:	<插入新位置信息时触发>
-- =============================================
CREATE TRIGGER [trig_gps_position_now_update]
   ON  [dbo].[gps_position_now]
   AFTER  update
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	insert into gps_position select[device_id]
      ,[date]
      ,[lng]
      ,[lat]
      ,[lng2]
      ,[lat2]
      ,[altitude]
      ,[speed]
      ,[direction]
      ,[position_type]
      ,[gps_realtime_position]
      ,[lbs_info]
      ,[g_force]
      ,[distance_from_last_gps]
      ,[carrier_acc]
      ,[status_byte]
      ,[status_string]
      ,[c1]
      ,[c2]
      ,[c3] from inserted
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'date'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'lng'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'lat'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'lng2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'lat2'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'altitude'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'speed'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方向' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'direction'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定位类型,gps|基站' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'position_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定位时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'gps_realtime_position'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基站信息' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'lbs_info'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'与前一点距离' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'gps_position_now', @level2type=N'COLUMN', @level2name=N'distance_from_last_gps'

