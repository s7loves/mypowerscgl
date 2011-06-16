USE [EbadaScgl]
go
IF not EXISTS(select * from WFModul  where [SelfCode]='0000')
BEGIN
INSERT INTO [WFModul] ([SelfCode],[FatherCode],[Caption],[Memo],[NodeType],[Leverl],[FullPosition],[IsVisable],[DllFileName],[DllClassName],[DllMethodName],[FormName],[BlankWindows],[MouseIsClick],[ImageIndex],[SDIWindows]) values ('0000','####','工作流平台管理工具','工作流平台管理工具','NullType',0,'0000',1,'','','','',0,1,0,0)

END
go

if not EXISTS(select * from [WFModul]  where [SelfCode]='0003')
BEGIN
INSERT INTO [WFModul] ([SelfCode],[FatherCode],[Caption],[Memo],[NodeType],[Leverl],[FullPosition],[IsVisable],[DllFileName],[DllClassName],[DllMethodName],[FormName],[BlankWindows],[MouseIsClick],[ImageIndex],[SDIWindows]) values ('0003','0000','流程管理','流程管理','Window',1,'0000-0003',1,'HF.WorkFlow.Designer.dll','HF.WorkFlow.Designer.fmWorkFlowIDE','fmWorkFlowIDE','',0,0,5,0)

END

go

if not EXISTS(select * from [WF_WorkFlowClass]  where [FatherId]='####')
BEGIN
INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('1','工作流模板','####','eee',0,NULL)

END

go

if not EXISTS(select * from [WF_FrmworkParamer]  where [DBId]='000003')
BEGIN
INSERT INTO [WF_FrmworkParamer] ([DBId],[FlagCode],[FlagText],[FlagValue],[Memo],[CreateTime]) values ('000003','WorkFlow','流程号','1003','流程流水号','08 17 2006 10:21AM')

END

go

if not EXISTS(select * from [WF_WorkFlow]  where [WorkFlowId]='8dfd3bd9-880a-47a7-81b3-97513976606d')
BEGIN
INSERT INTO [WF_WorkFlow] ([WorkFlowId],[FlowCaption],[WFClassId],[Version],[Status],[CreateUserId],[CreateDateTime],[IsSignOut],[SignOutUserId],[WorkCalendarId],[Description],[MgrUrl]) values ('8dfd3bd9-880a-47a7-81b3-97513976606d','测试1','545bfa8b-fe2d-4748-b033-385a24c0da3c','','1','','01  1 1900 12:00AM','','','','测试','')

END

go

if not EXISTS(select * from [WF_WorkLink]  where [WorkLinkId]='3cdb8cf7-2753-4cb2-bd26-398dd8908ab9')
BEGIN
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('3cdb8cf7-2753-4cb2-bd26-398dd8908ab9','8dfd3bd9-880a-47a7-81b3-97513976606d','07107519-b7fb-4fb3-bcf6-b72f2645fcef','405e5981-54f1-4d3a-9650-eb6a56a7a129','','','','','交互提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('ad7a7e59-6e98-42e9-a9fc-d5b4934d6371','8dfd3bd9-880a-47a7-81b3-97513976606d','405e5981-54f1-4d3a-9650-eb6a56a7a129','84077ea3-3de0-42fd-a39e-88311af42de4','','','','','知道了',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('b41b730a-0c9f-4964-908b-5f77db34f591','8dfd3bd9-880a-47a7-81b3-97513976606d','6294b547-d9ff-4f84-ac5d-0a275fd7bb28','07107519-b7fb-4fb3-bcf6-b72f2645fcef','','','141','192','提交',0)

END

go

if not EXISTS(select * from [WF_WorkTask]  where [WorkTaskId]='07107519-b7fb-4fb3-bcf6-b72f2645fcef')
BEGIN
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('07107519-b7fb-4fb3-bcf6-b72f2645fcef','8dfd3bd9-880a-47a7-81b3-97513976606d','3','','交互节点1',155,219,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('405e5981-54f1-4d3a-9650-eb6a56a7a129','8dfd3bd9-880a-47a7-81b3-97513976606d','5','','查看节点1',238,92,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('6294b547-d9ff-4f84-ac5d-0a275fd7bb28','8dfd3bd9-880a-47a7-81b3-97513976606d','1','','启动节点1',53,88,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('84077ea3-3de0-42fd-a39e-88311af42de4','8dfd3bd9-880a-47a7-81b3-97513976606d','2','','结束节点1',381,163,'','',' ',0)

END

go

if not EXISTS(select * from [WF_WorkTaskCommands]  where [CommandId]='82437fc4-872d-4687-b750-fac3e195646e')
BEGIN

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('82437fc4-872d-4687-b750-fac3e195646e','8dfd3bd9-880a-47a7-81b3-97513976606d','405e5981-54f1-4d3a-9650-eb6a56a7a129','知道了','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('bc71840b-10c8-4b03-aaf1-5bb54910d8d3','8dfd3bd9-880a-47a7-81b3-97513976606d','6294b547-d9ff-4f84-ac5d-0a275fd7bb28','提交','开始')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('c1f52f88-f400-46a5-84bd-a8542946d021','8dfd3bd9-880a-47a7-81b3-97513976606d','07107519-b7fb-4fb3-bcf6-b72f2645fcef','交互提交','交互提交')

END

go

--if not EXISTS(select * from [WF_WorkTaskControls]  where [taskControlId]='20110616161544908125')
--BEGIN
--INSERT INTO [WF_WorkTaskControls] ([taskControlId],[WorkflowId],[UserControlId],[WorktaskId],[ControlType]) values ('20110616161544908125','8dfd3bd9-880a-47a7-81b3-97513976606d','','6294b547-d9ff-4f84-ac5d-0a275fd7bb28','')
--INSERT INTO [WF_WorkTaskControls] ([taskControlId],[WorkflowId],[UserControlId],[WorktaskId],[ControlType]) values ('20110616161554205000','8dfd3bd9-880a-47a7-81b3-97513976606d','','07107519-b7fb-4fb3-bcf6-b72f2645fcef','')
--INSERT INTO [WF_WorkTaskControls] ([taskControlId],[WorkflowId],[UserControlId],[WorktaskId],[ControlType]) values ('20110616161600720625','8dfd3bd9-880a-47a7-81b3-97513976606d','','405e5981-54f1-4d3a-9650-eb6a56a7a129','')
--
--END
--
--go
if not EXISTS(select * from [mModule]  where [Modu_ID]=N'20110616105756342250')
BEGIN

INSERT INTO [mModule] ([Modu_ID],[ModuTypes],[ModuName],[AssemblyFileName],[Sequence],[IsCores],[Description],[ParentID],[MethodName],[IconName],[ActivityFlag],[visiableFlag]) values (N'20110616105756342250',N'Ebada.SCGL.WFlow.Test.WorkFlowTest',N'工作流测试',N'Ebada.SCGL.WFlow.Test.dll',0,N'',N'',N'0',N'',N'',0,1)

END

go

if not EXISTS(select * from [WF_Operator]  where [OperatorId]='1ef4bc44-20d7-45ad-b49d-6051c8c75571')
BEGIN

INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('1ef4bc44-20d7-45ad-b49d-6051c8c75571','8dfd3bd9-880a-47a7-81b3-97513976606d','07107519-b7fb-4fb3-bcf6-b72f2645fcef','',9,'ALL',0,'所有人',1,'所有人')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('387c53b5-2ca9-4a16-9755-39c75d837c21','8dfd3bd9-880a-47a7-81b3-97513976606d','405e5981-54f1-4d3a-9650-eb6a56a7a129','',1,'',0,'流程启动者',1,'流程启动者')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('ce4101fc-df83-4efe-8dc1-f5fcc2426b05','8dfd3bd9-880a-47a7-81b3-97513976606d','6294b547-d9ff-4f84-ac5d-0a275fd7bb28','',9,'ALL',0,'所有人',1,'所有人')

END

go
if not EXISTS(select * from [WF_WorkFlowClass]  where [WFClassId]='1')
BEGIN
INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('1','工作流模板','####','eee',0,NULL)


END
if not EXISTS(select * from [WF_WorkFlowClass]  where [WFClassId]='545bfa8b-fe2d-4748-b033-385a24c0da3c')
BEGIN
INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('545bfa8b-fe2d-4748-b033-385a24c0da3c','sdds','1','dd',1,'')

END

go