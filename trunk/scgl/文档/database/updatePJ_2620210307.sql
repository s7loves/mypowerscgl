USE [EbadaScgl]
alter table [PJ_26] add
	[xybh] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', 'Э����' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','xybh'
go

alter table [PJ_26] add
	[lineVol] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '��·��ѹ' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','lineVol'
go

alter table [PJ_26] add
	[fxwt] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '��������' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','fxwt'
go

alter table [PJ_26] add
	[clcs] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '�����ʩ' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','clcs'
go