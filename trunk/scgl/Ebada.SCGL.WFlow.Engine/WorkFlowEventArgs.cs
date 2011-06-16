using System;
using System.Collections.Generic;
using System.Text;
using Ebada.SCGL.WFlow.Engine;

namespace HF.WorkFlow.Engine
{
    public class WorkFlowEventArgs : EventArgs
    {
        public readonly string WorkFlowId = "";
        public readonly string WorkFlowInsId = "";
        public readonly string WorkTaskId = "";
        public readonly string WorkTaskInsId = "";
        public string ResultMsg = "";
        public WorkFlowEventArgs(WorkFlowRuntime workflowRuntime)
        {
            if (workflowRuntime == null) return;
            this.WorkFlowId = workflowRuntime.WorkFlowId;
            this.WorkFlowInsId = workflowRuntime.WorkFlowInstanceId;
            this.WorkTaskId = workflowRuntime.WorkTaskId;
            this.WorkTaskInsId = workflowRuntime.WorkTaskInstanceId;
        }
    }
}

