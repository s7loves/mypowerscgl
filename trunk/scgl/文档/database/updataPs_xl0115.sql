use [EbadaScgl]
alter table PS_xl alter column LineP decimal(18,5)
alter table PS_xl alter column LineQ decimal(18,5)
alter table PS_xl alter column TheoryLoss decimal(18,5)
alter table PS_xl add  [TotalT] decimal(18,5) null default 0
go
execute sp_addextendedproperty 'MS_Description', 'Ͷ������ʱ��' , 'user','dbo', 'TABLE','PS_xl', 'COLUMN','TotalT'
go