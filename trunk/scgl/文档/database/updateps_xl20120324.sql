
alter table [PS_xl] add
	[xlpy] [nvarchar](50) null default ''
    
	
go


execute sp_addextendedproperty 'MS_Description', '��·ƴ��' , 'user','dbo', 'TABLE','PS_xl', 'COLUMN','xlpy'
