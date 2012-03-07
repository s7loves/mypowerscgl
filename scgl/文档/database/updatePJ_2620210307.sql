USE [EbadaScgl]
alter table [PJ_26] add
	[xybh] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '协议编号' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','xybh'
go

alter table [PJ_26] add
	[lineVol] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '线路电压' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','lineVol'
go

alter table [PJ_26] add
	[fxwt] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '发现问题' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','fxwt'
go

alter table [PJ_26] add
	[clcs] [nvarchar](50) null default '' 
	
go


execute sp_addextendedproperty 'MS_Description', '处理措施' , 'user','dbo', 'TABLE','PJ_26', 'COLUMN','clcs'
go