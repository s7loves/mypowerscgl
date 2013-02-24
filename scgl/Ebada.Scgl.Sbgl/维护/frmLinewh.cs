using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client;
using Ebada.UI.Base;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 线路代码变更
    /// 调用存储过程 exec p_changeLineCode oldcode,newcode,linevol,byuser,type
    /// </summary>
    public partial class frmLinewh : FormBase {
        string execsql = "exec p_changeLineCode '{0}','{1}','{2}','{3}','PS_xl'";
        string lineInfo = "";
        string oldcode = "";
        string linevol = "";
        PS_xl xl = null;
        public frmLinewh() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            btnOK.Enabled = false;
        }
        private void ucPopupLine1_EditValueChanged(object sender, EventArgs e) {

        }

        private void btnOK_Click(object sender, EventArgs e) {
            string code = txNewCode.Text.Trim() ;
            if (code== "") return;
            long ncode=0;
            bool flag=false;
            if (!long.TryParse(code, out ncode)) {
                flag = true;
                goto Label1;
            }
            int nlen = code.Length;

            if (nlen < 10 && nlen != 6) {
                flag = true;
            } else if(((nlen-10)%3)>0) {
                flag = true;
            }

            Label1:
            if (flag) {
                MsgBox.ShowWarningMessageBox("代码只能输入数字,并且长度只能是6，10，13，16。。。");
                return;
            }
            string askmsg=string.Format("是否确认将原线路代码 {0} 改为 {1} ！",xl.LineCode,code);
            if (MsgBox.ShowAskMessageBox(askmsg) == DialogResult.OK) {
                Client.ClientHelper.PlatformSqlMap.GetObject("Select", string.Format(execsql, xl.LineCode, code, xl.LineVol,MainHelper.User.UserName));
                var line = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(string.Format("where linecode='{0}'", code));
                if (line != null) {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("线路代码：" + line.LineCode);
                    sb.AppendLine("线路名称：" + line.LineName);
                    sb.AppendLine("电压等级：" + line.LineVol);
                    var xlnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_xl>(string.Format("where linecode like '{0}%' and linevol='{1}'", line.LineCode, line.LineVol));
                    sb.AppendLine("相关线路数：" + xlnum);

                    var gtnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gt>(string.Format("where linecode in (select linecode from ps_xl where linecode like '{0}%' and linevol='{1}')", line.LineCode, line.LineVol));

                    sb.AppendLine("线路杆塔基数：" + gtnum);
                    memoEdit2.Text = sb.ToString();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            //查询
            btnOK.Enabled = false;
            xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(string.Format("where linecode='{0}'", txOldCode.Text.Trim()));
            if (xl != null) {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("线路代码：" + xl.LineCode);
                sb.AppendLine("线路名称：" + xl.LineName);
                sb.AppendLine("电压等级：" + xl.LineVol);
                var xlnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_xl>(string.Format("where linecode like '{0}%' and linevol='{1}'", xl.LineCode, xl.LineVol));
                sb.AppendLine("相关线路数：" + xlnum);

                var gtnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gt>(string.Format("where linecode in (select linecode from ps_xl where linecode like '{0}%' and linevol='{1}')", xl.LineCode, xl.LineVol));
                
                sb.AppendLine("线路杆塔基数：" +gtnum);
                btnOK.Enabled = true;
                memoEdit1.Text = sb.ToString();
            }
        }
    }
}
