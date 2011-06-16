using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;

namespace Ebada.SCGL.WFlow.Tool
{
    public class DesignerHelper
    {
        public static bool IsPower(string userId, string operationId)
        {
            if (PowerData.IsPower(userId, operationId))
            {
                return true;
            }
            else
            {
                MsgBox.ShowWarningMessageBox ("用户 " + userId + " 没有 " + operationId + " 的操作权限!");
                return false;
            }
        }
    }
}
