using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using Ebada.Client;
using Ebada.Components;

namespace Ebada.Scgl.Sbgl {
    public partial class frmGtDel : FormBase {
        string mtype = "杆塔";//设备
        public frmGtDel(string type) {
            InitializeComponent();
            mtype = type;
            this.Text += "-" + mtype;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        List<itemobj> gtlist;
        public void SetGt(ICollection<PS_gt> gts) {
            gtlist = new List<itemobj>();
            foreach (PS_gt gt in gts) {
                itemobj obj = new itemobj(gt);
                comboBoxEdit10.Properties.Items.Add(obj);
                comboBoxEdit11.Properties.Items.Add(obj);
                gtlist.Add(obj);
            }
        }
        class itemobj {
            public PS_gt Gt;
            public itemobj(PS_gt gt) {
                Gt = gt;
            }
            public override string ToString() {
                return Gt.gth;
            }
        }
        private bool save() {
            int begin = comboBoxEdit10.SelectedIndex;
            int end = comboBoxEdit11.SelectedIndex;
            bool flag = true;
            if(begin>end){
                MsgBox.ShowWarningMessageBox("启始杆号不能大于终止杆号!");
                flag = false;
                goto ret;
            }
           
            if (begin == -1) {
                MsgBox.ShowTipMessageBox("请选择启始杆号!");
                flag = false;
                goto ret;
            }
            if (end == -1) {
                MsgBox.ShowTipMessageBox("请选择终止杆号!");
                flag = false;
                goto ret;
            }
            if (MsgBox.ShowAskMessageBox(string.Format("删除{0}-{1}的所有{2},确定吗?",gtlist[begin].Gt.gth, gtlist[end].Gt.gth, mtype)) == DialogResult.OK) {
                List<string> list = new List<string>();
                for (int i = begin; i <= end; i++) {
                    PS_gt gt = gtlist[i].Gt;
                    list.Add("'" + gt.gtID + "'");
                }
                SqlQueryObject so1 = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from ps_gt where gtid in ("+string.Join(",",list.ToArray())+")");
                List<SqlQueryObject> listso = new List<SqlQueryObject>();
                if (mtype == "杆塔") {
                    listso.Add(so1);
                }
                SqlQueryObject so2 = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from ps_gtsb where gtid  in (" + string.Join(",", list.ToArray()) + ")");
                listso.Add(so2);
                try {
                    ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(listso);
                } catch {
                    flag = false;
                }

            } else {
                flag = false;
            }
            ret:
            return flag;
        }
        private void btnOK_Click(object sender, EventArgs e) {
            
                if (save())
                    DialogResult = DialogResult.OK;
                
        }
    }
}
