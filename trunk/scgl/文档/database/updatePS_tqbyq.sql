USE [EbadaScgl]
alter table [PS_tqbyq] add
	[byqkind] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '�������' , 'user','dbo', 'TABLE','PS_tqbyq', 'COLUMN','byqkind'
go


