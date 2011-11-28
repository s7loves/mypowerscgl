USE [EbadaScgl]
alter table [PS_gt] add
	[dxplfs] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '导线排列方式' , 'user','dbo', 'TABLE','PS_gt', 'COLUMN','dxplfs'
go


