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
        //获得整个拼音
        #region =中文转首字字母=
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                //if ((int)c >= 33 && (int)c  <= 126) 
                if ((int)c >= 32 && (int)c <= 126)
                {//字母和符号原样保留 
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母 
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }
        #endregion

        #region =中文字母对照=
        public static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }
        #endregion 
 
        /// <summary>
        /// 显示短语库选择器		
        /// </summary>
        /// <param name="dx">记录表中文名,要和短语库对上，否则没有记录</param>
        /// <param name="sx">属性中文名</param>
        /// <returns></returns>
        public static void SelectDyk(string dx,string sx,MemoEdit txt) {
            //2011.06.20 rabbit edit 
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;                
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    txt.EditValue = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
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
