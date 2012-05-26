use ebadascgl
--修改分段线路字段长度200-1000
alter table ps_xl alter column SectionalizedMessage nvarchar(1000);