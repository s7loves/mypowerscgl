USE [EbadaScgl]
alter table [PS_kg] add
	[kgkind] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '�������' , 'user','dbo', 'TABLE','PS_kg', 'COLUMN','kgkind'
go


