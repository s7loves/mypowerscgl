USE [EbadaScgl]
alter   table   WF_TableUsedField  add   [FieldName]   [nvarchar](50) 
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WF_TableUsedField', @level2type=N'COLUMN',@level2name=N'FieldName'
