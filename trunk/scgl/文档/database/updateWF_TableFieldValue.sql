USE [EbadaScgl]
alter table [WF_TableFieldValue] add
	[FieldName] [nvarchar](100) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '�ֶ�����' , 'user','dbo', 'TABLE','WF_TableFieldValue', 'COLUMN','FieldName'


