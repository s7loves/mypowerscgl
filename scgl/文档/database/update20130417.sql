use ebadascgl
go
--修改杆塔表
alter table ps_gt add
gtNode nvarchar(10) null,--线路中是否有连接作用的支撑点
c1 nvarchar(50) null,
c2 nvarchar(50) null,
c3 nvarchar(50) null,
c4 nvarchar(50) null,                                                                                                   
c5 nvarchar(50) null
go

--修改线路表
alter table ps_xl add
lineCount int not null default 0,--导线根数
leadwire nvarchar(50) null --导线线制
go
--修改变压器表

alter table ps_tqbyq add
jlType nvarchar(10) not null default '是',--高压侧计量（是、否）
azType nvarchar(50) not null default '台架式',--安装方式（台架式、配电房等）
isCount nvarchar(10) not null default '是' --是否计数
go