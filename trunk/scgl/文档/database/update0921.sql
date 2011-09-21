USE [EbadaScgl]
alter table [PJ_04sgzayc] add
	[charMan] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '处理人' , 'user','dbo', 'TABLE','PJ_04sgzayc', 'COLUMN','charMan'
GO
alter table [PS_kg] add
	[kgfgb] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '开关互感器变比' , 'user','dbo', 'TABLE','PS_kg', 'COLUMN','kgfgb'
GO
