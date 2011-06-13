using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Core {
    /// <summary>
    /// 选择器助手
    /// </summary>
    public class SelectorHelper {
        /// <summary>
        /// 显示短语库选择器
        /// 1001		PJ_01gzrj	js		工作日记\记事				
        /// 1002		PJ_02aqhd	hdnr		02安全活动\活动内容				
        /// </summary>
        /// <param name="dx">记录表对象名，如PJ_01gzrj</param>
        /// <param name="sx">属性名</param>
        /// <returns></returns>
        public static PJ_dyk SelectDyk(string dx,string sx) {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null) {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                    dyk = dlg.ucpJ_dykSelector1.GetSelectedRow();
                }
            }

            return dyk;
        }
    }
}
