USE [EbadaScgl]
alter table [PS_xl] add
	[SectionalizedMessage] [nvarchar](200) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '��·�ֶ���Ϣ' , 'user','dbo', 'TABLE','PS_xl', 'COLUMN','SectionalizedMessage'
go