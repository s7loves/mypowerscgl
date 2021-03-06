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
    public partial class frmBDSDLDRQTZEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_bdsdldrqtz> m_CityDic = new SortableSearchableBindingList<PJ_bdsdldrqtz>();

        public frmBDSDLDRQTZEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select edVol from PJ_bdsdldrqtz");
            comboBoxEdit3.Properties.Items.AddRange(list);
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "OrgName");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "zzdz");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "edVol");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "drqModle");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbFactory");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "sbnum");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Capcity");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "tqfs");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "inDate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");




        }
        #region IPopupFormEdit Members
        private PJ_bdsdldrqtz rowData = null;

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
                    this.rowData = value as PJ_bdsdldrqtz;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_bdsdldrqtz>(value as PJ_bdsdldrqtz, rowData);
                }

            }
        }

        #endregion




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList post)
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

        private void InitComboBoxData()
        {
            //填充下拉列表数据
            comboBoxEdit2.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select OrgName from mOrg where 5=5  AND ORGTYPE='2'"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {

            }
            //填充下拉列表数据
            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='变电所电力电容器台帐' and sx like '%{0}%' and nr!=''", "电容器型号"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("15GH-F");
                comboBoxEdit5.Properties.Items.Add("BFFR11-100-3W");
            }
            comboBoxEdit10.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='变电所电力电容器台帐' and sx like '%{0}%' and nr!=''", "容量"));
            if (strlist.Count > 0)
                comboBoxEdit10.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit10.Properties.Items.Add("100");
                comboBoxEdit10.Properties.Items.Add("120");
                comboBoxEdit10.Properties.Items.Add("150");
            }
            comboBoxEdit4.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='变电所电力电容器台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("闽东电机厂");
                comboBoxEdit4.Properties.Items.Add("指月集团有限公司");
            }
            comboBoxEdit8.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='线路电力电容器台帐' and sx like '%{0}%' and nr!=''", "投切方式"));
            if (strlist.Count > 0)
                comboBoxEdit8.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit8.Properties.Items.Add("手动");
                comboBoxEdit8.Properties.Items.Add("自动");
            }
            dateEdit1.DateTime = DateTime.Now;

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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }





        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("线路电力电容器台帐", "备注", memoEdit3);
        }


        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit6.EditValue = comboBoxEdit2.Text;
        }


    }
}