USE [EbadaScgl]
alter table [PS_xl] add
	[lineKind] [nvarchar](50) null default '',
    [lineNum] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', 'ȱ�����' , 'user','dbo', 'TABLE','PJ_18gysbpjmx', 'COLUMN','qxlb'
go
