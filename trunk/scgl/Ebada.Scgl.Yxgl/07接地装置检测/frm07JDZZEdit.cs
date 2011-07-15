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
namespace Ebada.Scgl.Yxgl
{
    public partial class frm07JDZZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_07jdzz> m_CityDic = new SortableSearchableBindingList<PJ_07jdzz>();
        private string parentID = "";

        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        public frm07JDZZEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "fzxl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gth");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzwz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbmc");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xhgg");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jddz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tz");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "trdzr");
            if (rowData.xhgg != "")
            {
                string[] str=rowData.xhgg.Split("|".ToCharArray());
                if (str.Length > 1)
                {
                    comboBoxEdit5.Text = str[0];
                    comboBoxEdit9.Text = str[1];
                }
            }

        }
        #region IPopupFormEdit Members
        private PJ_07jdzz rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_07jdzz>(value as PJ_07jdzz, rowData);
                    InitComboBoxData();
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "设备名称", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器型号", comboBoxEdit5);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器规格", comboBoxEdit9);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "接地电阻", comboBoxEdit6);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土质", comboBoxEdit7);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土壤电阻率", comboBoxEdit8);
           
            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + parentID + "'and LineType='1'");
            comboBoxEdit1.Properties.DataSource = xlList;
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

     

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxEdit1.EditValue.ToString()))
            {
                ICollection list = new ArrayList();
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from PS_gt where   LineCode='{0}' ", comboBoxEdit1.EditValue.ToString()));
                //ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
                comboBoxEdit2.Properties.Items.AddRange(list);
                IList<PS_xl> listXL = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where ParentID='" + comboBoxEdit1.EditValue.ToString() + "'and LineType IN ('1','2')");
                lookUpEdit1.Properties.DataSource = listXL;
            }
          

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text=="")
            {
                MsgBox.ShowTipMessageBox("线路名称不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            if (comboBoxEdit4.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备名称不能为空。");
                comboBoxEdit4.Focus();
                return;
            }
            if (comboBoxEdit5.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备型号不能为空。");
                comboBoxEdit5.Focus();
                return;
            }
            if (comboBoxEdit9.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备规格不能为空。");
                comboBoxEdit9.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit6.Text)<0)
            {
                MsgBox.ShowTipMessageBox("接地电阻不能为负。");
                comboBoxEdit6.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit8.Text) < 0)
            {
                MsgBox.ShowTipMessageBox("土壤电阻率不能为负。");
                comboBoxEdit8.Focus();
                return;
            }
            rowData.LineName = comboBoxEdit1.Text;

            rowData.xhgg = comboBoxEdit5.Text + "|" + comboBoxEdit9.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxEdit2.EditValue.ToString()))
            {
                IList<PS_tq> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(" where gtID='" + comboBoxEdit2.EditValue.ToString() + "' order by tqName");
                for (int i = 0; i < list.Count; i++)
                {
                    comboBoxEdit3.Properties.Items.Add(list[i].Adress);
                }
            }
           
        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxEdit4.EditValue.ToString()))
            {
                string sbmc = comboBoxEdit4.EditValue.ToString();
                ICollection list = new ArrayList();
                comboBoxEdit5.Properties.Items.Clear();
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where parentid in(select ID from pj_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc+"型号"));
                if (list.Count > 0)
                    comboBoxEdit5.Properties.Items.AddRange(list);
            }
           
          
        }
    }
}