use [EbadaScgl]
alter table [PS_gtsbclb] add
	    [sl] [int] null default 0
      
	
go


execute sp_addextendedproperty 'MS_Description', 'ÊýÁ¿' , 'user','dbo', 'TABLE','PS_gtsbclb', 'COLUMN','sl'
