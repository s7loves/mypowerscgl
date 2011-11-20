USE [EbadaScgl]
alter table [WF_TableFieldValue] add
	[FieldName] [nvarchar](100) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '×Ö¶ÎÃû³Æ' , 'user','dbo', 'TABLE','WF_TableFieldValue', 'COLUMN','FieldName'


