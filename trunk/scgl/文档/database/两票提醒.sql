INSERT INTO [PJ_znts] ([ID],[szdx],[sql],[tjsql],[xsgs],[type],[S1],[S2],[S3]) values (N'20120331145603545875',N'两票提醒',N'select * from dbo.LP_Record where id in (select RecordID from WFP_RecordWorkTaskIns where  workflowinsid in ( select workflowinsid  from (  select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription  from WF_WorkTaskInstanceView  WHERE  ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId=''{userid}'') ) OR  (OperContent = ''ALL'')) and  (OperStatus=''0'') and (Status=''1'') and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' ) and isSubWorkflow=0 union   select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription from WF_WorkTaskInsAccreditView where  AccreditToUserId=''{userid}'' and AccreditStatus=''1'' and status=''1'' and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' )   union   select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription from WF_WorkTaskInstanceView where UserId=''{userid}'' and (status=''1'' or status=''2'') and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' )) a   ))   and OrgName in (select orgname from morg where orgcode=''{orgcode}'')',N'select * from dbo.LP_Record where id in (select RecordID from WFP_RecordWorkTaskIns where  workflowinsid in ( select workflowinsid  from (  select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription  from WF_WorkTaskInstanceView  WHERE  ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId=''{userid}'') ) OR  (OperContent = ''ALL'')) and  (OperStatus=''0'') and (Status=''1'') and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' ) and isSubWorkflow=0 union   select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription from WF_WorkTaskInsAccreditView where  AccreditToUserId=''{userid}'' and AccreditStatus=''1'' and status=''1'' and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' )   union   select Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption,TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId,OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription from WF_WorkTaskInstanceView where UserId=''{userid}'' and (status=''1'' or status=''2'') and (FlowInsCaption=''电力线路第一种工作票'' or FlowInsCaption=''电力线路第二种工作票''  or FlowInsCaption=''电力线路事故应急抢修单''  or FlowInsCaption=''电力线路倒闸操作票'' )) a   )  and OrgName in (select orgname from morg where orgcode=''{orgcode}'')',N'{orgname}有 {gs}个两票记录需要处理',N'显示信息',N'',N'',N'')