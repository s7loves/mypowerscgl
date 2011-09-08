USE [EbadaScgl]
alter table LP_Record add
  
   OrgName               nvarchar(50)         null default ''
   

go
alter table LP_Temple add
  
   isExplorer               int         null default ((0))


go


execute sp_addextendedproperty 'MS_Description', 
   '单位名称',
   'user', 'dbo', 'table', 'LP_Record', 'column', 'OrgName'
go
execute sp_addextendedproperty 'MS_Description', 
   '是否导出',
   'user', 'dbo', 'table', 'LP_Temple', 'column', 'isExplorer'
go