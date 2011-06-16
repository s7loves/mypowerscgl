using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.SCGL.WFlow.Tool
{
    public  class SystemVarItem
    {
        public string VarName = "";
        public string VarType = "";
    }
    public class SystemVarData
    {
        public List<SystemVarItem> SystemVarItems;
        public const string Sys_FlowRunTime = "SYS_流程运行次数";
        public const string Sys_TaskRunTime = "SYS_任务运行次数";
        public SystemVarData()
        {
            SystemVarItems = new List<SystemVarItem>();
            SystemVarItem var = new SystemVarItem();
            var.VarName = Sys_FlowRunTime;
            var.VarType = WorkFlowConst.SYSVarType_int;
            SystemVarItems.Add(var);

            var = new SystemVarItem();
            var.VarName = Sys_TaskRunTime;
            var.VarType = WorkFlowConst.SYSVarType_int;
            SystemVarItems.Add(var);
        }
        public static SystemVarData GetSystemVarData()
        {
            return new SystemVarData();
        }
        public static List<SystemVarItem> GetSystemVarItems()
        {
           SystemVarData varData= SystemVarData.GetSystemVarData();
           return varData.SystemVarItems;
        }
        /// <summary>
        /// 判断是否为系统变量
        /// </summary>
        /// <param name="varName">变量名,不带变量两端的修饰符。</param>
        /// <returns>返回true或者false</returns>
        public static bool isSystemVar(string varName)
        {
            string varflag = varName;
            if (varflag.Length >= 4)
            {
                varflag = varName.Substring(0, 4);
                if (varflag == WorkFlowConst.SYS_VarFlag)
                {
                    return true;
                }
            }
            return false;
        }
        private SystemVarItem getSystemVarItem(string varName)
        {
            foreach (SystemVarItem var in  SystemVarItems)
            {
                if (var.VarName==varName)
                    return var;
            }
            return null;
        }
        public string GetSysVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName)
        {
            string result = "";
            string tmpVarName = "";
            tmpVarName = varName.Substring(2, varName.Length - 4);//去掉两头的<%%>
            SystemVarItem var = getSystemVarItem(varName);
            switch (tmpVarName)
            {
                case Sys_FlowRunTime:
                    {
                        break;
                    }
                case Sys_TaskRunTime:
                    {
                        break;
                    }
                default:
                    {
                        result = "SYS_NULL";
                        break;
                    }
            }
            if (var.VarType == WorkFlowConst.SYSVarType_string) result = "'" + result + "'";
            if (string.IsNullOrEmpty(result)) result = "'" + result + "'";
            return result;
        }
        //private string getValueByParameter(SqlDataItem sqlItem)
        //{
 
        //}
    }
}
