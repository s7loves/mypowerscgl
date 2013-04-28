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
    /// 台区代码变更
    /// 调用存储过程 exec p_changeTQCode oldcode,newcode,linevol,byuser,type
    /// </summary>
    public partial class frmLineTQwh : FormBase {
        string execsql = "exec p_changeTQCode '{0}','{1}','0.4','{2}','PS_tq'";
        string lineInfo = "";
        string oldcode = "";
        string linevol = "";
        PS_tq xl = null;
        public frmLineTQwh() {
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

            if (nlen !=10) {
                flag = true;
            } 

            Label1:
            if (flag) {
                MsgBox.ShowWarningMessageBox("代码只能输入数字,并且长度等于10");
                return;
            }
            var obj = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>("where tqcode='" + code + "'");
            if (obj != null) {
                PS_tq tq = obj as PS_tq;
                MsgBox.ShowWarningMessageBox(string.Format("已存在代码为{0}的台区\r\n台区名称：{1}\r\n所在线路：{2}",tq.tqCode,tq.tqName,tq.xlCode));
                return;
            }

            string askmsg=string.Format("是否确认将原台区代码 {0} 改为 {1} ！",xl.tqCode,code);
            if (MsgBox.ShowAskMessageBox(askmsg) == DialogResult.OK) {
                Client.ClientHelper.PlatformSqlMap.GetObject("Select", string.Format(execsql, xl.tqCode, code, MainHelper.User.UserName));
                var line = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(string.Format("where tqcode='{0}'", code));
                if (line != null) {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("台区代码：" + line.tqCode);
                    sb.AppendLine("台区名称：" + line.tqName);
                    sb.AppendLine("所在线路代码：" + line.xlCode);
                    sb.AppendLine("所在分支线路代码：" + line.xlCode2);
                    var xlnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_xl>(string.Format("where linecode like '{0}%' and linevol='0.4'", line.tqCode));
                    sb.AppendLine("相关线路数：" + xlnum);

                    var gtnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gt>(string.Format("where linecode in (select linecode from ps_xl where linecode like '{0}%' and linevol='0.4')", line.tqCode));

                    sb.AppendLine("台区杆塔基数：" + gtnum);
                    memoEdit2.Text = sb.ToString();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            //查询
            btnOK.Enabled = false;
            xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(string.Format("where tqcode='{0}'", txOldCode.Text.Trim()));
            if (xl != null) {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("台区代码：" + xl.tqCode);
                sb.AppendLine("台区名称：" + xl.tqName);
                sb.AppendLine("所在线路代码：" + xl.xlCode);
                sb.AppendLine("所在分支线路代码：" + xl.xlCode2);
                var xlnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_xl>(string.Format("where linecode like '{0}%' and linevol='0.4'", xl.tqCode));
                sb.AppendLine("台区线路数：" + xlnum);

                var gtnum = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gt>(string.Format("where linecode in (select linecode from ps_xl where linecode like '{0}%' and linevol='0.4')", xl.tqCode));
                
                sb.AppendLine("线路杆塔基数：" +gtnum);
                btnOK.Enabled = true;
                memoEdit1.Text = sb.ToString();
            }
        }
    }
}
