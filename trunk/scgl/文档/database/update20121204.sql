

update mModule set ModuName='断路器试验实施情况记录' where  Modu_ID='20121109152525435750';

update mModule set ModuName='变压器试验实施情况记录' where  Modu_ID='20121109152451560750';

update mModule set ModuName='电容器试验实施情况记录' where  Modu_ID='20121109152528513875';

update mModule set ModuName='避雷器试验实施情况记录' where  Modu_ID='20121109152527967000';

update mModule set ModuName='供电所春查实施情况记录' where  Modu_ID='20120115213042092875';

update mModule set ModuName='供电所春查实施情况记录' where  Modu_ID='20120115213042092875';

insert into mModule(ModuName,ModuTypes,AssemblyFileName,Sequence,visiableFlag,ActivityFlag,Modu_ID,ParentID) 
	values('供电所秋查实施情况记录','Ebada.Scgl.Lcgl.UCPJ_CQCSSQK','Ebada.Scgl.Lcgl.dll','0','1','0','20120115213042092876','20121108151134947125');

update WF_WorkTaskModle set Modu_ID='20120115213042092875' where taskControlId='20121204151310753125';
update WF_WorkTaskModle set Modu_ID='20120115213042092876' where taskControlId='20121204151230831250';