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
namespace Ebada.Scgl.Xtgl
{
    public partial class frmOrgEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<mOrg> m_CityDic = new SortableSearchableBindingList<mOrg>();

        public frmOrgEdit()
        {
            InitializeComponent();
            textEdit1.KeyPress += new KeyPressEventHandler(textEdit1_KeyPress);
            checkEdit2.Hide();
        }

        void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        void dataBind()
        {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "OrgName");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");
            //this.checkEdit1.DataBindings.Add("EditValue", rowData, "C1");

        }
        #region IPopupFormEdit Members
        private mOrg rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as mOrg;
                    this.InitComboBoxData();
                    dataBind();
                    checkEdit1.Checked = false;
                }
                else
                {
                    ConvertHelper.CopyTo<mOrg>(value as mOrg, rowData);
                    checkEdit1.Checked = false;
                    checkEdit2.Checked = false;
                    if (rowData.C1 == "是")
                        checkEdit1.Checked = true;
                    //if (rowData.C4 == "是")
                    //    checkEdit2.Checked = true;
                }
                oldOrgCode = rowData.OrgCode;
                if (rowData.OrgID.Length == 3)
                    textEdit1.Properties.ReadOnly = true;
                else
                    textEdit1.Properties.ReadOnly = false;
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<mOrg>(" WHERE Citylevel = '2'"));
            IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
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

        private string oldOrgCode = "";
        private string newOrgCode = "";

        private void btnOK_Click(object sender, EventArgs e)
        {
            rowData.C1 = checkEdit1.Checked ? "是" : "否";
            newOrgCode = textEdit1.EditValue.ToString();
            int num;
            if (textEdit1.Text.Length == 3)
            {
                if (int.TryParse(textEdit1.Text, out num))
                {
                    if (oldOrgCode != newOrgCode)
                    {
                        var org = MainHelper.PlatformSqlMap.GetOne<mOrg>(" where OrgCode='" + newOrgCode + "'");
                        if (org != null)
                        {
                            MsgBox.ShowWarningMessageBox("已存在该编号！");
                        }
                        else
                        {
                            
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MsgBox.ShowWarningMessageBox("编号只能为三位数字！");
                    textEdit1.Focus();
                }
            }
        }
    }
}