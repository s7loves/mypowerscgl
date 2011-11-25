USE [EbadaScgl]
alter table [PS_xl] add
	[lineKind] [nvarchar](50) null default '',
    [lineNum] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '完好类型' , 'user','dbo', 'TABLE','PS_xl', 'COLUMN','lineKind'
go


execute sp_addextendedproperty 'MS_Description', '线路号' , 'user','dbo', 'TABLE','PS_xl', 'COLUMN','lineNum'
