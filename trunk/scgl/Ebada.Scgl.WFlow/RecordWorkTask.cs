using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client.Platform;
using System.Data;
using Ebada.SCGL.WFlow.Tool;

namespace Ebada.Scgl.WFlow
{
    public class RecordWorkTask
    {

        
        /// <summary>
        /// 获得用户是否可以启动运行定期分析权限
        /// </summary>
        /// <returns></returns>
        public static  bool HaveDQFXRole()
        {
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所定期分析").Rows.Count > 0 ? true : false;

            }
            else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            {
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局定期分析").Rows.Count > 0 ? true : false;

            }
            else
                return false;
        }
           


    }
}
