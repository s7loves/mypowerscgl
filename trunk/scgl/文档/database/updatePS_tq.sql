USE [EbadaScgl]
alter table [PS_tq] add
	[bttype] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '±‰Ã®–Õ∫≈' , 'user','dbo', 'TABLE','PS_tq', 'COLUMN','bttype'


