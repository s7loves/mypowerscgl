use [EbadaScgl]
alter table [WF_TableFieldValue] add
	    [Bigdata] [image] NULL
       
	
go


execute sp_addextendedproperty 'MS_Description', '�ĵ�����' , 'user','dbo', 'TABLE','WF_TableFieldValue', 'COLUMN','Bigdata'
go
