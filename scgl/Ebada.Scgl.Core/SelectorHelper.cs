using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Core {
    /// <summary>
    /// 选择器助手
    /// </summary>
    public class SelectorHelper {
        /// <summary>
        /// 显示短语库选择器		
        /// </summary>
        /// <param name="dx">记录表中文名,要和短语库对上，否则没有记录</param>
        /// <param name="sx">属性中文名</param>
        /// <returns></returns>
        public static void SelectDyk(string dx,string sx,MemoEdit txt) {
            //2011.06.20 rabbit edit 
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    txt.EditValue += dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }

        }
        /// <summary>
        /// 多级短语时使用此方法
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="sx"></param>
        /// <param name="txt">最多4级</param>
        /// <returns></returns>
        public static PJ_dyk SelectDyk(string dx, string sx, params TextEdit[] txt) {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null) {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                    dyk = dlg.ucpJ_dykSelector1.GetSelectedRow();
                    int len = txt.Length>4?4:txt.Length;
                    for (int i = 0; i < len; i++) {
                        if (i==0)
                            txt[i].EditValue = dyk.nr;
                        else if (i ==1)
                            txt[i].EditValue = dyk.nr2;
                        else if (i==2)
                            txt[i].EditValue = dyk.nr3;
                        else if (i==3)
                            txt[i].EditValue = dyk.nr4;
                    }
                }
            }
            return dyk;
        }
    }
}
