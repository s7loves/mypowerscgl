USE [EbadaScgl]
alter table [PJ_22] add
	[tdxlgt] [nvarchar](50) null default '',
	[tdcz1xz] [bit] NULL,
	[tdcz1cz] [bit] NULL,
	[tdcz2xz] [bit] NULL,
	[tdcz2cz] [bit] NULL,
	[tdcz3xz] [bit] NULL,
	[tdcz3cz] [bit] NULL,
	[tdcz4xz] [bit] NULL,
	[tdcz4cz] [bit] NULL,
	[tdcz5xz] [bit] NULL,
	[tdcz5cz] [bit] NULL,
	[tdcz6xz] [bit] NULL,
	[tdcz6cz] [bit] NULL,
	[tdcz7xz] [bit] NULL,
	[tdcz7cz] [bit] NULL,
	[tdcz8xz] [bit] NULL,
	[tdcz8cz] [bit] NULL,
	[tdczjxname1] [nvarchar](50) null default '',
	[tdczjxname2] [nvarchar](50) null default '',
	[tdczjxname3] [nvarchar](50) null default '',
	[sdcz1xz] [bit] NULL,
	[sdcz1cz] [bit] NULL,
	[sdcz2xz] [bit] NULL,
	[sdcz2cz] [bit] NULL,
	[sdcz3xz] [bit] NULL,
	[sdcz3cz] [bit] NULL,
	[sdcz4xz] [bit] NULL,
	[sdcz4cz] [bit] NULL,
	[sdcz5xz] [bit] NULL,
	[sdcz5cz] [bit] NULL,
	[sdcz6xz] [bit] NULL,
	[sdcz6cz] [bit] NULL,
	[sdcz7xz] [bit] NULL,
	[sdcz7cz] [bit] NULL,
	[sdcz8xz] [bit] NULL,
	[sdcz8cz] [bit] NULL,
	[sdczjxname1] [nvarchar](50) null default '',
	[sdczjxname2] [nvarchar](50) null default ''
go


execute sp_addextendedproperty 'MS_Description', '停电线路杆号' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdxlgt'
GO
execute sp_addextendedproperty 'MS_Description', '拉开低压开关选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz1xz'
GO
execute sp_addextendedproperty 'MS_Description', '拉开低压开关操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz1cz'
GO
execute sp_addextendedproperty 'MS_Description', '拉开低压刀闸（保险）选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz2xz'
GO
execute sp_addextendedproperty 'MS_Description', '拉开低压刀闸（保险）操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz2cz'
GO
execute sp_addextendedproperty 'MS_Description', '拉开高压开关（跌落式熔断器）选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz3xz'
GO
execute sp_addextendedproperty 'MS_Description', '拉开高压开关（跌落式熔断器）操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz3cz'
GO
execute sp_addextendedproperty 'MS_Description', '在变压器高压套管端子处验明三相确无电压选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz4xz'
GO
execute sp_addextendedproperty 'MS_Description', '在变压器高压套管端子处验明三相确无电压操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz4cz'
GO
execute sp_addextendedproperty 'MS_Description', '在变压器高压套管端子处挂地#线一组选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz5xz'
GO
execute sp_addextendedproperty 'MS_Description', '在变压器高压套管端子处挂地#线一组操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz5cz'
GO
execute sp_addextendedproperty 'MS_Description', '在低压侧验明三相确无电压选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz6xz'
GO
execute sp_addextendedproperty 'MS_Description', '在低压侧验明三相确无电压操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz6cz'
GO
execute sp_addextendedproperty 'MS_Description', '在低压侧挂#地线一组选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz7xz'
GO
execute sp_addextendedproperty 'MS_Description', '在低压侧挂#地线一组操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz7cz'
GO
execute sp_addextendedproperty 'MS_Description', '在工作地点挂#小地线选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz8xz'
GO
execute sp_addextendedproperty 'MS_Description', '在工作地点挂#小地线操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz8cz'
GO
execute sp_addextendedproperty 'MS_Description', '在变压器高压套管端子处挂地#线名称' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname1'
GO
execute sp_addextendedproperty 'MS_Description', '在低压侧挂#地线名称' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname2'
GO
execute sp_addextendedproperty 'MS_Description', '在工作地点挂#小地线名称' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname3'
GO
execute sp_addextendedproperty 'MS_Description', '检查相位是否正确选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz1xz'
GO
execute sp_addextendedproperty 'MS_Description', '检查相位是否正确操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz1cz'
GO
execute sp_addextendedproperty 'MS_Description', '拆除工作地点小地线选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz2xz'
GO
execute sp_addextendedproperty 'MS_Description', '拆除工作地点小地线操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz2cz'
GO
execute sp_addextendedproperty 'MS_Description', '拆出低压侧选择#线一组选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz3xz'
GO
execute sp_addextendedproperty 'MS_Description', '拆出低压侧选择#线一组操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz3cz'
GO
execute sp_addextendedproperty 'MS_Description', '拆除变压器高压套管端子处#地线一组选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz4xz'
GO
execute sp_addextendedproperty 'MS_Description', '拆除变压器高压套管端子处#地线一组操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz4cz'
GO
execute sp_addextendedproperty 'MS_Description', '合上高压开关（跌落式熔断器）选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz5xz'
GO
execute sp_addextendedproperty 'MS_Description', '合上高压开关（跌落式熔断器）操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz5cz'
GO
execute sp_addextendedproperty 'MS_Description', '合上低压开关选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz6xz'
GO
execute sp_addextendedproperty 'MS_Description', '合上低压开关操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz6cz'
GO
execute sp_addextendedproperty 'MS_Description', '合上低压刀闸（保险）选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz7xz'
GO
execute sp_addextendedproperty 'MS_Description', '合上低压刀闸（保险）操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz7cz'
GO
execute sp_addextendedproperty 'MS_Description', '检查用户是否有电选择' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz8xz'
GO
execute sp_addextendedproperty 'MS_Description', '检查用户是否有电操作' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz8cz'
GO
execute sp_addextendedproperty 'MS_Description', '拆出低压侧选择#线名称' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdczjxname1'
GO
execute sp_addextendedproperty 'MS_Description', '拆除变压器高压套管端子处#地线名称' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdczjxname2'
GO
