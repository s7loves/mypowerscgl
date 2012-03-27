use [EbadaScgl]
alter table [PJ_23] add
	    [linename] [nvarchar](50) null default '',
        [fzlinename] [nvarchar](50) null default '',
        [gh] [nvarchar](50) null default ''
	
go


execute sp_addextendedproperty 'MS_Description', '线路' , 'user','dbo', 'TABLE','PJ_23', 'COLUMN','linename'
go
execute sp_addextendedproperty 'MS_Description', '分支' , 'user','dbo', 'TABLE','PJ_23', 'COLUMN','fzlinename'
go
execute sp_addextendedproperty 'MS_Description', '杆号' , 'user','dbo', 'TABLE','PJ_23', 'COLUMN','gh'
go