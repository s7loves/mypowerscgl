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
using DevExpress.XtraTab;
namespace Ebada.Scgl.Sbgl {
    public partial class frmtqEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tq> m_CityDic = new SortableSearchableBindingList<PS_tq>();
        private string gdsCode;
        UCPS_TQSB ucps_tqsb;
        UCPS_TQBYQ ucps_tqbyq;
        UCPS_TQDLBH ucps_tqdlbh;
        XtraTabPage tqsbTab, tqdlbhTab, byqTab;
        public string GdsCode {
            get { return gdsCode; }
            set { gdsCode = value; ComboBoxHelper.Fillgdsry(comboBoxEdit9, gdsCode); }
        }
        private string lineCode;

        public string LineCode {
            get { return lineCode; }
            set { lineCode = value; }
        }


        public frmtqEdit() {
            InitializeComponent();
            xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            comboBoxEdit5.EditValueChanged+=new EventHandler(comboBoxEdit5_EditValueChanged);
        }

        void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e) {
            if (e.Page == tqsbTab) {
                if (ucps_tqsb == null) {
                    ucps_tqsb = new UCPS_TQSB();
                    ucps_tqsb.Dock = DockStyle.Fill;

                    ucps_tqsb.ParentObj = rowData;
                    ucps_tqsb.HideList();
                    ucps_tqsb.Parent = tqsbTab;
                }
            } else if (e.Page == tqdlbhTab) {
                if (ucps_tqdlbh == null) {
                    ucps_tqdlbh = new UCPS_TQDLBH();
                    ucps_tqdlbh.Dock = DockStyle.Fill;

                    ucps_tqdlbh.ParentObj = rowData;
                    ucps_tqdlbh.HideList();
                    ucps_tqdlbh.Parent = tqdlbhTab;
                }
            } else if (e.Page == byqTab) {
                if (ucps_tqbyq == null) {
                    ucps_tqbyq = new UCPS_TQBYQ();
                    ucps_tqbyq.Dock = DockStyle.Fill;

                    ucps_tqbyq.ParentObj = rowData;
                    ucps_tqbyq.HideList();
                    ucps_tqbyq.Parent = byqTab;
                }
            }
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tqCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "tqName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "Adress");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "xlCode");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xlCode2");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "gtID");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "Owner");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "cby");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "cfy");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Contractor");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Class");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "bttype");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "bcdr");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "ddj");
            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "jj");
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "nfy");
            this.comboBoxEdit18.DataBindings.Add("EditValue", rowData, "zmfs");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "Lowlossrate");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "tclr");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "hclr");

            //this.spinEdit4.DataBindings.Add("EditValue", rowData, "zmfs");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "dxbs");
            this.spinEdit6.DataBindings.Add("EditValue", rowData, "sxbs");

            this.dateEdit1.DataBindings.Add("EditValue", rowData, "InDate");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "btkind");


        }
        #region IPopupFormEdit Members
        private PS_tq rowData = null;
        private Boolean isnew = false;
        public object RowData {
            get {
                PS_tq tq = new PS_tq();
                ConvertHelper.CopyTo(rowData, tq);
                return tq;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tq;
                    if (string.IsNullOrEmpty(gdsCode))
                        GdsCode = rowData.tqCode.Substring(0, 3);
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tq>(value as PS_tq, rowData);
                }
                if (rowData.tqCode == "") {
                    GdsCode = rowData.tqCode.Substring(0, 3);
                    rowData.InDate = DateTime.Now;
                }
                isnew = false;
                if (rowData.tqName == "")
                    isnew = true;
            }
        }
        bool showTab2 = false;

        public bool ShowTab2 {
            get { return showTab2; }
            set {
                showTab2 = value;
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); simpleButton1.Show();
            if ("rabbit赵建明付岩张发冯富玲刘振远赵忠田".Contains(MainHelper.User.UserName) && !isnew) {
                simpleButton1.Show();
                simpleButton3.Show();
                simpleButton4.Show();
            } else {
                //simpleButton1.Hide();
                simpleButton3.Hide();
                simpleButton4.Hide();
            }
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            if (showTab2) {
                if (tqsbTab == null) {
                    byqTab = new XtraTabPage();
                    byqTab.Text = "变压器";
                    xtraTabControl1.TabPages.Add(byqTab);
                    tqdlbhTab = new XtraTabPage();
                    tqdlbhTab.Text = "电流动作保护器";
                    xtraTabControl1.TabPages.Add(tqdlbhTab);
                    tqsbTab = new XtraTabPage();
                    tqsbTab.Text = "其它设备";
                    xtraTabControl1.TabPages.Add(tqsbTab);
                }
            }
        }
        #endregion

        private void InitComboBoxData() {
            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + gdsCode + "' and linevol='10'");
            comboBoxEdit4.Properties.DataSource = xlList;
            comboBoxEdit5.Properties.DataSource = xlList;
            comboBoxEdit12.Properties.Items.Clear();
            ICollection list = new ArrayList();
            comboBoxEdit12.Properties.Items.Clear();
            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where parentid in(select ID from pj_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc + "型号"));
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='台区' and sx = '{0}' and nr!=''", "变台型号"));
            if (list.Count > 0)
                comboBoxEdit12.Properties.Items.AddRange(list);
            else {
                comboBoxEdit12.Properties.Items.Add("砖台");
                comboBoxEdit12.Properties.Items.Add("落地台");
                comboBoxEdit12.Properties.Items.Add("H台");
                comboBoxEdit12.Properties.Items.Add("箱式变");
            }
            comboBoxEdit13.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "完好类型"));
            if (strlist.Count > 0)
                comboBoxEdit13.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit13.Properties.Items.Add("一类");
                comboBoxEdit13.Properties.Items.Add("二类");
                comboBoxEdit13.Properties.Items.Add("三类");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
             string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "产权"));
            if (strlist.Count > 0)
                comboBoxEdit6.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit6.Properties.Items.Add("局属");
                comboBoxEdit6.Properties.Items.Add("自备");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
             string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "运行班次"));
            if (strlist.Count > 0)
                comboBoxEdit10.Properties.Items.AddRange(strlist);
            else {
                comboBoxEdit10.Properties.Items.Add("一班");
                comboBoxEdit10.Properties.Items.Add("二班");
                comboBoxEdit10.Properties.Items.Add("三班");
            }
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

        private void btnOK_Click(object sender, EventArgs e) {
            if (comboBoxEdit1.Text == "") {
                MsgBox.ShowTipMessageBox("台区编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit6_Properties_Click(object sender, EventArgs e) {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='台区' and sx='产权' and parentid=''");
            if (parentObj != null) {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    comboBoxEdit6.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }
        }

        private void comboBoxEdit10_Properties_Click(object sender, EventArgs e) {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='台区' and sx='运行班次' and parentid=''");
            if (parentObj != null) {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    comboBoxEdit10.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }
        }

        private void comboBoxEdit5_EditValueChanged(object sender, EventArgs e) {
            //分支线路改变时刷新杆塔号
            string linecode = comboBoxEdit5.EditValue.ToString();
            if (string.IsNullOrEmpty(linecode)) return;
            lookUpEdit1.Properties.DataSource = ClientHelper.PlatformSqlMap.GetList<PS_gt>("Where linecode='" + linecode + "'");
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            SbFuns.CountTQLen(rowData.tqCode);
            MsgBox.ShowTipMessageBox("计算完毕。");
        }
        void simpleButton4_Click(object sender, EventArgs e) {
            //恢复经纬度

            SbFuns.RestoreGTLatLngTQ(rowData.tqCode);
            Client.MsgBox.ShowTipMessageBox("恢复完成。");
        }

        void simpleButton3_Click(object sender, EventArgs e) {
            //备份经纬度

            SbFuns.BackupGTLatLngTQ(rowData.tqCode);
            Client.MsgBox.ShowTipMessageBox("备份完成。");
        }

    }
}