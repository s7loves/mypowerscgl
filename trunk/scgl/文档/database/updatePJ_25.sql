use [EbadaScgl]
alter table [PJ_25] add
	    [bszz] [nvarchar](50) null default '',
        [fzcs] [nvarchar](max) null default ''
     
	
go


execute sp_addextendedproperty 'MS_Description', '±’À¯◊∞÷√' , 'user','dbo', 'TABLE','PJ_25', 'COLUMN','bszz'
go
execute sp_addextendedproperty 'MS_Description', '∑¿µπÀÕµÁ¥Î ©' , 'user','dbo', 'TABLE','PJ_25', 'COLUMN','fzcs'
go
