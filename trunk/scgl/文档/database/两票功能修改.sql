USE [EbadaScgl]
GO
update dbo.LP_Temple set ParentID='6360bcc1-0483-4720-a883-14bb76fd8901',CellName='������·��һ�ֹ���Ʊ' 
where  CellName='һ�ֹ���Ʊ'

update dbo.LP_Temple set ParentID='c29f4b8d-94a1-4432-8153-5bdad6c8a0bb',CellName='������·�ڶ��ֹ���Ʊ' 
where  CellName='���ֹ���Ʊ'

update dbo.LP_Temple set ParentID='db285921-68dc-4508-b86c-4ba46c9ee2ad',CellName='������·��բ����Ʊ' 
where  CellName='��բ����Ʊ'


update dbo.LP_Temple set ParentID='733294eb-2364-473a-999a-05c59fe38027',CellName='������·�¹�Ӧ�����޵�' 
where  CellName='Ӧ�����޵�'

INSERT INTO [WF_WorkFlow] ([WorkFlowId],[FlowCaption],[WFClassId],[Version],[Status],[CreateUserId],[CreateDateTime],[IsSignOut],[SignOutUserId],[WorkCalendarId],[Description],[MgrUrl]) values ('cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','������ר�����','e90d2e90-6b15-49a0-a6b6-986c88b15b69','','1','','07 25 2011  9:10PM','','','','','20110621140825182625')

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('8df5840a-9ead-429d-9870-7392ba932a05','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','2','','�����ڵ�1',392,168,'','',' ',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('8f4de2d5-9674-4711-a6cd-26791406d4e3','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','3','','����˼��',261,276,'','','1',0)
INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('c56c0fbb-5016-40bc-b481-71e073d3538a','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','1','','��д',82,128,'','','1',0)

INSERT INTO [WF_WorkTask] ([WorkTaskId],[WorkFlowId],[TaskTypeId],[TaskTypeAndOr],[TaskCaption],[iXPosition],[iYPosition],[Description],[Commands],[OperRule],[IsJumpSelf]) values ('cf8fa14e-e025-49dd-ab45-422a3324fc7d','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','3','','�쵼���',94,232,'','','1',0)

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('56d02bf6-4189-440c-b137-a523a6eca120','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','c56c0fbb-5016-40bc-b481-71e073d3538a','cf8fa14e-e025-49dd-ab45-422a3324fc7d','','','','','�ύ',0)

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('6a833d4b-57da-4c4f-b606-7f62dd47b2ca','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','8f4de2d5-9674-4711-a6cd-26791406d4e3','8df5840a-9ead-429d-9870-7392ba932a05','','','','','�ύ',0)

INSERT INTO [WF_WorkLink] ([WorkLinkId],[WorkFlowId],[StartTaskId],[EndTaskId],[Condition],[Description],[BreakX],[BreakY],[CommandName],[Priority]) values ('c72b1605-aee6-4f98-bf63-66dd5f1242c9','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','cf8fa14e-e025-49dd-ab45-422a3324fc7d','8f4de2d5-9674-4711-a6cd-26791406d4e3','','','','','�ύ',0)

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('58406504-834b-4480-818a-4358120f7bbe','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','8f4de2d5-9674-4711-a6cd-26791406d4e3','�ύ','�ύ')

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('5d774969-979b-44a1-b288-5dfac201833f','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','cf8fa14e-e025-49dd-ab45-422a3324fc7d','�ύ','�ύ')

INSERT INTO [WF_WorkTaskCommands] ([CommandId],[WorkFlowId],[WorkTaskId],[CommandName],[Description]) values ('1b8aff30-4062-490e-bcde-a411cfa4897a','cbd2ebd3-dedc-40b7-8acc-0e6f8f5883bb','c56c0fbb-5016-40bc-b481-71e073d3538a','�ύ','�ύ')
