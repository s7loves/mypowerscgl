using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
namespace Ebada.Scgl.Sbgl {
    public partial class frmsdxlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sd_xl> m_CityDic = new SortableSearchableBindingList<sd_xl>();

        public frmsdxlEdit() {
            InitializeComponent();
            simpleButton1.Click += new EventHandler(simpleButton1_Click);
            simpleButton3.Click += new EventHandler(simpleButton3_Click);
            simpleButton4.Click += new EventHandler(simpleButton4_Click);
            simpleButton5.Click += new EventHandler(simpleButton5_Click);
        }
        UCPS_XLSec xlSec = null;
        void simpleButton5_Click(object sender, EventArgs e) {

            //groupControl1.Text = rowData.LineName;
            //if (xlSec == null) {
            //    xlSec = new UCPS_XLSec(rowData);
            //    xlSec.Dock = DockStyle.Fill;
            //    groupControl2.Controls.Add(xlSec);

            //} else {
            //    xlSec.ParentObj = rowData;
            //}
            //bool flag = groupBox1.Visible;
            //if (simpleButton5.Text == "线路信息") {
            //    flag = false;
            //} else {
            //    flag = true;
            //}
            //groupBox1.Visible = !flag;
            //groupControl1.Visible = false;
            //groupControl2.Visible = flag;
            //if (flag) {
            //    simpleButton5.Text = "线路信息";
            //    simpleButton2.Text = "杆塔信息";
            //} else {
            //    simpleButton5.Text = "分段信息";
            //    simpleButton2.Text = "杆塔信息";
            //}
        }
        void dataBind() {
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "InDate");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "WireLength");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "TotalLength");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "TheoryLoss");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "ActualLoss");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "K");
            this.spinEdit6.DataBindings.Add("EditValue", rowData, "LineP");
            this.spinEdit8.DataBindings.Add("EditValue", rowData, "LineQ");
            this.spinEdit7.DataBindings.Add("EditValue", rowData, "TotalT");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineType");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "LineCode");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "LineNamePath");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "LineVol");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "OrgCode2");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Owner");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Contractor");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "RunState");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "LineGtbegin");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "LineGtend");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "WireType");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "ParentGT");//分支杆号
            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "lineKind");//完好类型
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "lineNum");//线路类型
            this.comboBoxEdit18.DataBindings.Add("EditValue", rowData, "xlpy");//线路类型

        }
        #region IPopupFormEdit Members
        private sd_xl rowData = null;

        public object RowData {
            get {
                sd_xl xl = new sd_xl();
                ConvertHelper.CopyTo(rowData, xl);
                return xl;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sd_xl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sd_xl>(value as sd_xl, rowData);
                }
                if (rowData.LineType == "") {
                    rowData.InDate = DateTime.Now;
                    rowData.RunState = "运行";
                }
                isnew = false;
                if (rowData.LineVol == "") {
                    rowData.LineVol = "35";

                }
                if (rowData.LineName == "")
                    isnew = true;
            }
        }
        bool isnew = false;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); simpleButton1.Show();
            this.Invoke(new MethodInvoker(initParentGtList));
            if ("rabbit赵建明管理员付岩张发冯富玲刘振远赵忠田".Contains(MainHelper.User.UserName) && !isnew)
            {
                simpleButton1.Show();
                simpleButton2.Show();
            } else {
                //simpleButton1.Hide();
                simpleButton2.Hide();
            }
            groupControl1.Hide();
            groupBox1.Show();
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);


        }
        #endregion
        private void initParentGtList() {
            //初始分支杆号
            string sql = string.Format("select a.gtcode from sd_gt a ,sd_xl b where a.LineCode=b.Linecode and b.LineID='{0}'", rowData.ParentID);
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
            comboBoxEdit15.Properties.Items.Clear();
            comboBoxEdit15.Properties.Items.AddRange(list);
        }
        private void InitComboBoxData() {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where C1='是' order by orgcode");//生产单位
            comboBoxEdit7.Properties.DataSource = list;
            IList<mOrg> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mOrg>(" where orgtype='2'");//变电所
            comboBoxEdit8.Properties.DataSource = list2;
            pdsbModelHelper.FillCBox(comboBoxEdit14, pdsbModelHelper.dxxh);
            ComboBoxHelper.Fillgdsry(comboBoxEdit10, rowData.OrgCode);
            this.comboBoxEdit14.Properties.Items.AddRange(ComboBoxHelper.GetLineTye());
            ICollection strlist = new ArrayList();
            comboBoxEdit16.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "完好类型"));
            if (strlist.Count > 0)
                comboBoxEdit16.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit16.Properties.Items.Add("一类");
                comboBoxEdit16.Properties.Items.Add("二类");
                comboBoxEdit16.Properties.Items.Add("三类");
            }
            comboBoxEdit17.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "线路类型"));
            if (strlist.Count > 0)
                comboBoxEdit17.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit17.Properties.Items.Add("四线");
                comboBoxEdit17.Properties.Items.Add("二线");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
             string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "产权"));
            if (strlist.Count > 0)
                comboBoxEdit9.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit9.Properties.Items.Add("局属");
                comboBoxEdit9.Properties.Items.Add("自备");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
             string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "运行状态"));
            if (strlist.Count > 0)
                comboBoxEdit11.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit11.Properties.Items.Add("运行");
                comboBoxEdit11.Properties.Items.Add("暂停");
            }
            //this.comboBoxEdit5.Properties.Items.AddRange(ComboBoxHelper.GetVoltage()); 
            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电压等级"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }
        void simpleButton1_Click(object sender, EventArgs e) {
            spinEdit2.Value = rowData.TotalLength = (int)SbFuns.CountLineLen(rowData);
            spinEdit1.Value = rowData.WireLength;
            if (rowData.LineCode.Length == 6) {
                Client.ClientHelper.PlatformSqlMap.Update("Update", string.Format("update sd_xl set TotalLength={0},WireLength={1} where lineid='{2}'",rowData.TotalLength,rowData.WireLength,rowData.LineID));
               rowData.gdbj=(int)SbFuns.jsgdbj(rowData.LineCode);
            }
            MsgBox.ShowTipMessageBox("计算完毕。");
        }
        private void btnOK_Click(object sender, EventArgs e) {
            if (comboBoxEdit2.Text == "") {
                MsgBox.ShowTipMessageBox("线路编号不能为空。");
                comboBoxEdit2.Focus();
                return;
            }
            if (comboBoxEdit3.Text == "") {
                MsgBox.ShowTipMessageBox("线路名称不能为空。");
                comboBoxEdit3.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        UCsd_GT gt = null;
        private void simpleButton2_Click(object sender, EventArgs e) {
            groupControl1.Text = rowData.LineName;
            if (gt == null) {
                gt = new UCsd_GT(rowData);
                gt.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(gt);

            } else {
                gt.ParentObj = rowData;
            }
            bool flag = groupBox1.Visible;
            if (simpleButton2.Text == "线路信息") {
                flag = false;
            } else {
                flag = true;
            }
            groupBox1.Visible = !flag;
            groupControl1.Visible = flag;
            groupControl2.Visible = false;
            if (flag) {
                simpleButton2.Text = "线路信息";
                simpleButton5.Text = "分段信息";
            } else {
                simpleButton2.Text = "杆塔信息";
                simpleButton5.Text = "分段信息";
            }
        }
        void simpleButton4_Click(object sender, EventArgs e) {
            //恢复经纬度

            //SbFuns.RestoreGTLatLng(rowData.LineCode);
            //Client.MsgBox.ShowTipMessageBox("恢复完成。");
        }

        void simpleButton3_Click(object sender, EventArgs e) {
            //备份经纬度
            //SbFuns.BackupGTLatLng(rowData.LineCode);
            //Client.MsgBox.ShowTipMessageBox("备份完成。");
        }
        private void groupControl1_VisibleChanged(object sender, EventArgs e) {
            simpleButton3.Visible = groupControl1.Visible;
            simpleButton4.Visible = groupControl1.Visible;
        }

        private void labelControl17_Click(object sender, EventArgs e) {

        }

        private void frmxlEdit_FormClosing(object sender, FormClosingEventArgs e) {
            simpleButton2.Text = "杆塔信息";
            simpleButton5.Text = "分段信息";
        }

        private void comboBoxEdit3_TextChanged(object sender, EventArgs e) {
            rowData.xlpy = SelectorHelper.GetPysm(rowData.LineName);
            comboBoxEdit8.Text = rowData.xlpy;
            //IList list = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName  from sd_xl where xlpy like '%"+comboBoxEdit3.Text +"%'");
            //if (list.Count > 0)
            //{
            //    comboBoxEdit3.Properties.Items.Clear();
            //    comboBoxEdit3.Properties.Items.AddRange(list);
            //}
        }

    }
}