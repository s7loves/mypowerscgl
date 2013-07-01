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
namespace Ebada.Scgl.Yxgl {
    public partial class frmSD07JDZZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_07jdzz> m_CityDic = new SortableSearchableBindingList<sdjl_07jdzz>();
        private string parentID = "";

        public string ParentID {
            get { return parentID; }
            set { parentID = value; }
        }
        public frmSD07JDZZEdit()
        {
            InitializeComponent();
           
        }
        void dataBind() {


            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "LineName");
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "fzxl");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "fzxl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gth");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzwz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbmc");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xhgg");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jddz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tz");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "trdzr");
            this.txtjdxs.DataBindings.Add("EditValue", rowData, "c1");

        }
        #region IPopupFormEdit Members
        private sdjl_07jdzz rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjl_07jdzz>(value as sdjl_07jdzz, rowData);
                    InitComboBoxData();
                }
                if (rowData.xhgg != "") {
                    string[] str = rowData.xhgg.Split("|".ToCharArray());
                    if (str.Length > 1) {
                        comboBoxEdit5.Text = str[0];
                        comboBoxEdit9.Text = str[1];
                    }
                }
            }
        }

        #endregion

        private DataTable lineTable = new DataTable();
        private void InitComboBoxData() {

            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "设备名称", comboBoxEdit4.Properties);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器型号", comboBoxEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器规格", comboBoxEdit9.Properties);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "接地电阻", comboBoxEdit6.Properties);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土质", comboBoxEdit7.Properties);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土壤电阻率", comboBoxEdit8.Properties);

            IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where OrgCode='" + parentID + "' and ParentID='0'");
            lineTable = Ebada.Core.ConvertHelper.ToDataTable((IList)xlList, typeof(sd_xl));
           
            comboBoxEdit10.Properties.Items.Clear();
            for (int i = 0; i < xlList.Count; i++) {
                ListItem ot = new ListItem();
                ot.DisplayMember = xlList[i].LineName;
                ot.ValueMember = xlList[i].LineCode;
                comboBoxEdit10.Properties.Items.Add(ot);
            }
            comboBoxEdit11.TextChanged -= comboBoxEdit11_TextChanged;

            if (rowData.LineName == "") {
                sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_xl>(rowData.LineID);
                if (xl != null) {
                    rowData.LineName = comboBoxEdit10.Text = xl.LineName;
                }
            } else {
                comboBoxEdit10.Text = rowData.LineName;
            }
            comboBoxEdit11.TextChanged += comboBoxEdit11_TextChanged;
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
            
            sd_xl xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl == null) {
                MsgBox.ShowTipMessageBox("线路名称不对，没找到线路。");
                comboBoxEdit10.Focus();
                return;
            }
            if (xl != null) {
                rowData.LineID = xl.LineID;
                rowData.LineName = xl.LineName;
            }
            if (comboBoxEdit4.Text == "") {
                MsgBox.ShowTipMessageBox("保护设备名称不能为空。");
                comboBoxEdit4.Focus();
                return;
            }
            if (comboBoxEdit5.Text == "") {
                MsgBox.ShowTipMessageBox("保护设备型号不能为空。");
                comboBoxEdit5.Focus();
                return;
            }
            if (comboBoxEdit9.Text == "") {
                MsgBox.ShowTipMessageBox("保护设备规格不能为空。");
                comboBoxEdit9.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit6.Text) < 0) {
                MsgBox.ShowTipMessageBox("接地电阻不能为负。");
                comboBoxEdit6.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit8.Text) < 0) {
                MsgBox.ShowTipMessageBox("土壤电阻率不能为负。");
                comboBoxEdit8.Focus();
                return;
            }
            rowData.LineName = comboBoxEdit10.Text;

            rowData.xhgg = comboBoxEdit5.Text + "|" + comboBoxEdit9.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e) {

        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(comboBoxEdit4.EditValue.ToString())) {
                string sbmc = comboBoxEdit4.EditValue.ToString();
                ICollection list = new ArrayList();
                comboBoxEdit5.Properties.Items.Clear();
                //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from PJ_dyk where parentid in(select ID from PJ_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc + "型号"));
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from PJ_dyk where  dx='07接地装置检测记录' and sx like '%{0}%' and nr!=''", sbmc + "型号"));
                if (list.Count > 0)
                    comboBoxEdit5.Properties.Items.AddRange(list);



                comboBoxEdit9.Properties.Items.Clear();
                //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from PJ_dyk where parentid in(select ID from PJ_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc + "型号"));
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from PJ_dyk where  dx='07接地装置检测记录' and sx like '%{0}%' and nr!=''", sbmc + "规格"));
                if (list.Count > 0)
                    comboBoxEdit9.Properties.Items.AddRange(list);
            }


        }

        private void comboBoxEdit2_Properties_EditValueChanged(object sender, EventArgs e) {

        }

        private void comboBoxEdit11_TextChanged(object sender, EventArgs e) {
            DataRow[] rows = lineTable.Select("linename='" + comboBoxEdit11.Text + "'");
            if (rows.Length > 0) return;
            rows = lineTable.Select("xlpy like '" + comboBoxEdit11.Text + "%'");
            IList list = new ArrayList();
            foreach (DataRow row in rows) {
                list.Add(row["LineName"]);
            }
            if (list.Count > 0) {
                comboBoxEdit11.Properties.Items.Clear();
                comboBoxEdit11.Properties.Items.AddRange(list);
                comboBoxEdit11.ShowPopup();
            }
        }

        private void comboBoxEdit10_TextChanged(object sender, EventArgs e) {
            sd_xl xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl != null) {
                comboBoxEdit2.Properties.Items.Clear();
                //comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit11.Properties.Items.Clear();
                comboBoxEdit11.Text = "";
                ICollection list = new ArrayList();
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from sd_gt where   LineCode='{0}' ", xl.LineCode));
                comboBoxEdit2.Properties.Items.AddRange(list);
               
                xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linename='" + comboBoxEdit10.Text + "'");
                if (xl != null) {
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                        "select linename from sd_xl where ParentID='" + xl.LineID + "' and parentid!='0'");
                    comboBoxEdit11.Properties.Items.AddRange(list);
                   
                }

            } else {
                IList list = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName  from sd_xl where xlpy like '" + comboBoxEdit10.Text + "%' and parentID='0'");
                if (list.Count > 0) {
                    comboBoxEdit10.Properties.Items.Clear();
                    comboBoxEdit10.Properties.Items.AddRange(list);
                    comboBoxEdit10.ShowPopup();
                }
            }
        }

       

    }
}