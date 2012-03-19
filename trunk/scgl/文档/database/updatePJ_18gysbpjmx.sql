USE [EbadaScgl]
alter table [PJ_18gysbpjmx] add
	[qxlb] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', 'È±ÏÝÀà±ð' , 'user','dbo', 'TABLE','PJ_18gysbpjmx', 'COLUMN','qxlb'
go
