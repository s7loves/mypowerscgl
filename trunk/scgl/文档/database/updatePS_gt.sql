USE [EbadaScgl]
alter table [PS_gt] add
	[dxplfs] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '�������з�ʽ' , 'user','dbo', 'TABLE','PS_gt', 'COLUMN','dxplfs'
go


