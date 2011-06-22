USE [EbadaScgl]
go
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619152027758625',N'001',N'局定期分析编辑',N'局定期分析编辑',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619160204661500',N'002',N'供电所定期编辑',N'供电所定期编辑',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619160437395875',N'003',N'供电所定期分析领导检查',N'领导检查',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619160519036500',N'004',N'供电所定期分析检查人检查',N'检查人检查',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619185626545875',N'005',N'局定期分析领导检查',N'领导检查',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110619185656295875',N'006',N'局定期分析检查人检查',N'检查人检查',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110622161216245750',N'007',N'局专题分析编辑',N'局专题分析编辑',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110622161309386375',N'008',N'局专题分析领导检查',N'领导检查',N'',N'',N'',N'',N'')
INSERT INTO [mRole] ([RoleID],[RoleCode],[RoleName],[RoleType],[C1],[C2],[C3],[C4],[C5]) values (N'20110622161350120750',N'009',N'局专题分析检查人检查',N'检查人检查',N'',N'',N'',N'',N'')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619152027758625',N'010011')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619160204661500',N'201006')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619160437395875',N'201001')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619160519036500',N'201003')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619185626545875',N'010001')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110619185656295875',N'010008')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110622161216245750',N'010011')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110622161309386375',N'010001')
INSERT INTO [rUserRole] ([RoleID],[UserID]) values (N'20110622161350120750',N'010008')

INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('70ce81a8-e387-4217-a41d-ff218867d72e','定期分析','7d06f704-6d40-4f53-8b54-7407d2bb981b','',2,'')

INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('7d06f704-6d40-4f53-8b54-7407d2bb981b','运行分析','1','',1,'')

INSERT INTO [WF_WorkFlowClass] ([WFClassId],[Caption],[FatherId],[Description],[clLevel],[clMgrUrl]) values ('e90d2e90-6b15-49a0-a6b6-986c88b15b69','专题分析','7d06f704-6d40-4f53-8b54-7407d2bb981b','',2,'')

INSERT INTO [WF_WorkFlow] ([WorkFlowId],[FlowCaption],[WFClassId],[Version],[Status],[CreateUserId],[CreateDateTime],[IsSignOut],[SignOutUserId],[WorkCalendarId],[Description],[MgrUrl]) values ('60ddf044-555f-46b0-a5a7-ec39aceb7f77','供电所定期分析','70ce81a8-e387-4217-a41d-ff218867d72e','','1','','06 19 2011  6:11PM','','','','','')
INSERT INTO [WF_WorkFlow] ([WorkFlowId],[FlowCaption],[WFClassId],[Version],[Status],[CreateUserId],[CreateDateTime],[IsSignOut],[SignOutUserId],[WorkCalendarId],[Description],[MgrUrl]) values ('9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','局定期分析','70ce81a8-e387-4217-a41d-ff218867d72e','','1','','06 19 2011  6:11PM','','','','','')
INSERT INTO [WF_WorkFlow] ([WorkFlowId],[FlowCaption],[WFClassId],[Version],[Status],[CreateUserId],[CreateDateTime],[IsSignOut],[SignOutUserId],[WorkCalendarId],[Description],[MgrUrl]) values ('e7bb7987-6b20-480a-b54f-228998b7a4fb','局专题分析','e90d2e90-6b15-49a0-a6b6-986c88b15b69','','1','','06 22 2011  4:09PM','','','','局专题分析','')

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('0c530cff-1b56-4004-9efd-89c0b0828944','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','c288338e-a790-413d-be68-92355a992d94','c7774f3f-e447-4cd2-a6bf-0c5723db0956','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('2160f2dc-9c89-4269-a3a5-b19e91bd9267','e7bb7987-6b20-480a-b54f-228998b7a4fb','12090ad2-a208-46bf-9d8d-af2f11c0fe31','af7eeb91-6668-4e36-9959-118d61c94416','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('2b5b8589-f4e6-4666-8773-23dfe1dce6dc','60ddf044-555f-46b0-a5a7-ec39aceb7f77','6fde5c86-7dcd-4459-92c9-ac8ff60f59ea','a5a5417c-0eef-44aa-9c33-d6bf3eb2b081','','','','','提交',0)

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('90fca301-abcc-43b2-9ea3-6a4306787e4a','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','423088b1-1e03-4aa7-bac7-0aa0870286d3','c288338e-a790-413d-be68-92355a992d94','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('93f36262-8292-4e34-8a23-aa276f8c4d49','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','06627b8d-33a3-4269-ae3f-59cba9417e2a','423088b1-1e03-4aa7-bac7-0aa0870286d3','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('ab4e8342-d383-4172-a539-41c46fa8b111','e7bb7987-6b20-480a-b54f-228998b7a4fb','27d57d54-0440-4fbb-9347-2028bc460efc','12090ad2-a208-46bf-9d8d-af2f11c0fe31','','','','','提交',0)

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('d727233e-476e-4192-a8f6-7f8c4f3c143c','60ddf044-555f-46b0-a5a7-ec39aceb7f77','a5a5417c-0eef-44aa-9c33-d6bf3eb2b081','d5911a98-5ef3-430d-b1e9-cc54240d999c','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('e2da125b-95c0-4350-be6e-1c95ac0b5888','e7bb7987-6b20-480a-b54f-228998b7a4fb','af7eeb91-6668-4e36-9959-118d61c94416','2b5f5713-d01b-42e8-92da-153d1604047f','','','','','提交',0)
INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('ef40df97-13b2-4964-a8c8-a4b6e704eaaa','60ddf044-555f-46b0-a5a7-ec39aceb7f77','d5911a98-5ef3-430d-b1e9-cc54240d999c','195deeb4-46eb-45f0-804d-1831df281ca4','','','','','提交',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('06627b8d-33a3-4269-ae3f-59cba9417e2a','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','1','','启动节点1',114,142,'','','1',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('12090ad2-a208-46bf-9d8d-af2f11c0fe31','e7bb7987-6b20-480a-b54f-228998b7a4fb','3','','领导检查',160,280,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('195deeb4-46eb-45f0-804d-1831df281ca4','60ddf044-555f-46b0-a5a7-ec39aceb7f77','2','','结束节点1',480,160,'','',' ',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('27d57d54-0440-4fbb-9347-2028bc460efc','e7bb7987-6b20-480a-b54f-228998b7a4fb','1','','启动节点1',90,176,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('2b5f5713-d01b-42e8-92da-153d1604047f','e7bb7987-6b20-480a-b54f-228998b7a4fb','2','','结束节点1',401,188,'','',' ',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('423088b1-1e03-4aa7-bac7-0aa0870286d3','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','3','','领导检查',142,230,'','','1',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('6fde5c86-7dcd-4459-92c9-ac8ff60f59ea','60ddf044-555f-46b0-a5a7-ec39aceb7f77','1','','启动节点1',166,162,'','','1',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('a5a5417c-0eef-44aa-9c33-d6bf3eb2b081','60ddf044-555f-46b0-a5a7-ec39aceb7f77','3','','领导检查',243,246,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('af7eeb91-6668-4e36-9959-118d61c94416','e7bb7987-6b20-480a-b54f-228998b7a4fb','3','','检查人检查',322,295,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('c288338e-a790-413d-be68-92355a992d94','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','3','','检查人检查',310,286,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('c7774f3f-e447-4cd2-a6bf-0c5723db0956','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','2','','结束节点1',489,138,'','',' ',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('d5911a98-5ef3-430d-b1e9-cc54240d999c','60ddf044-555f-46b0-a5a7-ec39aceb7f77','3','','检查人检查',415,270,'','','1',0)
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('36774ebb-a9c5-474c-8451-9115ab7c3e00','e7bb7987-6b20-480a-b54f-228998b7a4fb','12090ad2-a208-46bf-9d8d-af2f11c0fe31','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('36d3a802-f76c-49a5-bb8d-0a174ce51919','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','c288338e-a790-413d-be68-92355a992d94','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('51c18111-9871-4be7-b0f3-f3acb9ea281e','60ddf044-555f-46b0-a5a7-ec39aceb7f77','fa912d70-1ee6-43a4-9abb-9f0adba0ca95','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('566c1c0e-ced9-45ef-b5cd-a2d038fcb29e','e7bb7987-6b20-480a-b54f-228998b7a4fb','27d57d54-0440-4fbb-9347-2028bc460efc','提交','提交')

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('884e1f54-ad34-45a5-8d5e-04c43141122e','60ddf044-555f-46b0-a5a7-ec39aceb7f77','990477ad-2026-4205-85c4-eac78cb4cc73','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('9e487a2b-6564-4351-9de7-1129fa72acc9','e7bb7987-6b20-480a-b54f-228998b7a4fb','af7eeb91-6668-4e36-9959-118d61c94416','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('bbb68d0e-60a3-4bcb-9ebe-9f2a7afd9462','60ddf044-555f-46b0-a5a7-ec39aceb7f77','a5a5417c-0eef-44aa-9c33-d6bf3eb2b081','提交','提交')

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('bd2ff7c0-4ed3-4f2b-83c9-0f3b36c2259d','60ddf044-555f-46b0-a5a7-ec39aceb7f77','d5911a98-5ef3-430d-b1e9-cc54240d999c','提交','提交')

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('c46d9ec1-9faa-468e-8724-a7c340ce1194','60ddf044-555f-46b0-a5a7-ec39aceb7f77','6fde5c86-7dcd-4459-92c9-ac8ff60f59ea','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('e2e706df-d614-4279-afe2-630da8916edb','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','06627b8d-33a3-4269-ae3f-59cba9417e2a','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('e54680e2-301c-42ab-a9c8-a706a89978d6','60ddf044-555f-46b0-a5a7-ec39aceb7f77','18f09b8b-bff0-4d08-ae9c-dba7073ea7d6','提交','提交')
INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('ef2108b0-fdb3-49fc-b688-7b8291112cc4','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','423088b1-1e03-4aa7-bac7-0aa0870286d3','提交','提交')

INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('2cdecca1-8091-4174-84f7-a3595265b1a6','e7bb7987-6b20-480a-b54f-228998b7a4fb','af7eeb91-6668-4e36-9959-118d61c94416','',5,'20110622161350120750',0,'局专题分析检查人检查',1,'局专题分析检查人检查')

INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('5c9f5c3a-8db9-4475-ace0-43f8d0c32287','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','06627b8d-33a3-4269-ae3f-59cba9417e2a','',5,'20110619152027758625',0,'局定期分析编辑',1,'局定期分析编辑')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('6e059ab6-5746-427e-bf66-5098aca97ffe','60ddf044-555f-46b0-a5a7-ec39aceb7f77','d5911a98-5ef3-430d-b1e9-cc54240d999c','',5,'20110619160519036500',0,'供电所定期分析检查人检查',1,'供电所定期分析检查人检查')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('76ade741-47b6-468f-8e15-6413939be67e','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','c288338e-a790-413d-be68-92355a992d94','',5,'20110619185656295875',0,'局定期分析检查人检查',1,'局定期分析检查人检查')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('79aca401-23bc-466c-9b1d-7ec03b57f0ff','60ddf044-555f-46b0-a5a7-ec39aceb7f77','a5a5417c-0eef-44aa-9c33-d6bf3eb2b081','',5,'20110619160437395875',0,'供电所定期分析领导检查',1,'供电所定期分析领导检查')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('8f74a5ca-b28f-42ab-b8fc-848a722de383','60ddf044-555f-46b0-a5a7-ec39aceb7f77','6fde5c86-7dcd-4459-92c9-ac8ff60f59ea','',5,'20110619160204661500',0,'供电所定期编辑',1,'供电所定期编辑')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('a3b4d9e8-9436-4370-92bd-7b394e48f88f','e7bb7987-6b20-480a-b54f-228998b7a4fb','12090ad2-a208-46bf-9d8d-af2f11c0fe31','',5,'20110622161309386375',0,'局专题分析领导检查',1,'局专题分析领导检查')

INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('d9bac8a3-69f5-406e-8452-2a1c329c7008','9cfb08c8-3d8d-483b-bd37-8c5a1af764d4','423088b1-1e03-4aa7-bac7-0aa0870286d3','',5,'20110619185626545875',0,'局定期分析领导检查',1,'局定期分析领导检查')
INSERT INTO [WF_Operator] ([OperatorId],[WorkFlowId],[WorkTaskId],[NextType],[OperType],[OperContent],[Relation],[Description],[InorExclude],[OperDisplay]) values ('f74c4edd-a60b-4c33-9d7f-f0a60116dd5a','e7bb7987-6b20-480a-b54f-228998b7a4fb','27d57d54-0440-4fbb-9347-2028bc460efc','',5,'20110622161216245750',0,'局专题分析编辑',1,'局专题分析编辑')