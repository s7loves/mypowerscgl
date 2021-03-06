﻿using System;
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
namespace Ebada.Scgl.Lcgl
{
    public partial class frm16Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_16> m_CityDic = new SortableSearchableBindingList<PJ_16>();

        public frm16Edit() {
            InitializeComponent();
        }
        void dataBind() {


           
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineCode");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            this.buttonEdit1.DataBindings.Add("EditValue", rowData, "BigData");
           
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_16 rowData = null;

        public object RowData {
            get {
                PS_xl px = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(rowData.LineCode);
                if (string.IsNullOrEmpty(rowData.LineName))
                {
                    rowData.LineName = px.LineName;
                }
                return rowData;
            }
            set {
                if (value == null) return;
                
                if (rowData == null) {
                    this.rowData = value as PJ_16;
                   
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    
                    ConvertHelper.CopyTo<PJ_16>(value as PJ_16, rowData);
                  
                    this.InitComboBoxData();
                    
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_16>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
          
            IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where len(linecode)=6 and OrgCode ='" + rowData.OrgCode + "'or OrgCode2='" + rowData.OrgCode + "'");
            //this.SetComboBoxData(this.lookUpEdit1, "LineName", "LineID", "请选择", "线路名称", list);
            comboBoxEdit10.Properties.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = list[i].LineName;
                ot.ValueMember = list[i].LineCode;
                comboBoxEdit10.Properties.Items.Add(ot);
            }

            if (rowData.LineName == "")
            {
                if (comboBoxEdit10.Properties.Items.Count > 0)
                    comboBoxEdit10.SelectedIndex = 0;
            }
            else
            {
                comboBoxEdit10.Text = rowData.LineName;
            }
            this.buttonEdit1.Text = "";
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_xl> post)
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //this.rowData.LineName = this.lookUpEdit1.SelectedText;
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            //this.rowData.LineName = this.lookUpEdit1.s;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.rowData.LineName = this.lookUpEdit1.Text;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = openFileDialog1.FileName;
                rowData.BigData = Ecommon.GetImageBate(openFileDialog1.FileName);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (buttonEdit1.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("文档内容不能为空。");
            //    return;
            //}
            PS_xl xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl == null)
            {
                MsgBox.ShowTipMessageBox("线路名称不能对，没找到线路。");
                comboBoxEdit10.Focus();
                return;
            }
            if (xl != null)
            {
                rowData.LineCode = xl.LineCode;
                rowData.LineName = xl.LineName;
            }
            if (rowData.BigData == null)
            {
                rowData.BigData = new byte[0];
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit10_TextChanged(object sender, EventArgs e)
        {
            PS_xl xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl!= null)
            {
                rowData.LineName = comboBoxEdit10.Text;
                rowData.LineCode = xl.LineCode;

            }
        }

    }
}