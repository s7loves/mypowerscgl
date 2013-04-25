USE [ebadascgl]

GO

Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('员工工作','Ebada.jhgl.FrmSystem','Ebada.jhgl.dll','10','showYGGZ','','Crystal_folder26',1,1,'','system','20130424115608935125','20120407082949687500','')
go
Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('员工工作写实','','','0','','','',1,0,'','yggz','20130424130023669500','0','')
go
update  [mModule] set [Description]='yggz',
[ParentID]='20130424130023669500'
where [Modu_ID]='20130210171939462250';

update  [mModule] set [Description]='yggz',
[ParentID]='20130210171939462250'
where [Modu_ID]='20130210172013743500';

update  [mModule] set [Description]='yggz',
[ParentID]='20130210171939462250'
where [Modu_ID]='20130210172032274750';
update  [mModule] set [Description]='yggz',
[ParentID]='20130210171939462250'
where [Modu_ID]='20130210203628692500'

update  [mModule] set [Description]='yggz',
[ParentID]='20130210171939462250'
where [Modu_ID]='20130225161337754156';

update  [mModule] set [Description]='yggz',
[ParentID]='20130210171939462250'
where [Modu_ID]='20130228100057727250';
go
--Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('周工作计划','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','1','','','Mac_Folder_60',1,0,'','yggz','20130210172013743500','20130210171939462250','')
--Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('部门领导考核','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','2','showdw','','_3',1,0,'','yggz','20130210172032274750','20130210171939462250','')
--Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('主管领导考核','Ebada.jhgl.UCJH_weekmant','Ebada.jhgl.dll','3','showall','','_3',1,0,'','yggz','20130210203628692500','20130210171939462250','')
--Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('员工总分汇总表(月)','Ebada.jhgl.UCJH_weekmanthz','Ebada.jhgl.dll','4','showM','','_3',1,0,'','yggz','20130225161337754156','20130210171939462250','')
--Insert Into [mModule] ([ModuName],[ModuTypes],[AssemblyFileName],[Sequence],[MethodName],[MethodParam],[IconName],[visiableFlag],[ActivityFlag],[IsCores],[Description],[Modu_ID],[ParentID],[Rights]) Values('员工总分汇总表(年)','Ebada.jhgl.UCJH_weekmanthz','Ebada.jhgl.dll','5','showY','','_3',1,0,'','yggz','20130228100057727250','20130210171939462250','')
