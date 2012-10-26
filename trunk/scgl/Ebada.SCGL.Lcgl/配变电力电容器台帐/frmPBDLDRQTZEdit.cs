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
    public partial class frmPBDLDRQTZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_pbdldrqtz> m_CityDic = new SortableSearchableBindingList<PJ_pbdldrqtz>();

        public frmPBDLDRQTZEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "pdName");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "lineName");
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
        private PJ_pbdldrqtz rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_pbdldrqtz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_pbdldrqtz>(value as PJ_pbdldrqtz, rowData);
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

        private void InitComboBoxData() {

            //填充下拉列表数据
            comboBoxEdit3.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "电压等级"));
            comboBoxEdit3.Properties.Items.AddRange(strlist);

            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='配变电力电容器台帐' and sx like '%{0}%' and nr!=''", "电容器型号"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("15GH-F");
                comboBoxEdit5.Properties.Items.Add("BFFR11-100-3W");
            }
            comboBoxEdit10.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='配变电力电容器台帐' and sx like '%{0}%' and nr!=''", "容量"));
            if (strlist.Count > 0)
                comboBoxEdit10.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit10.Properties.Items.Add("15");
                comboBoxEdit10.Properties.Items.Add("50");
            }
            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='配变电力电容器台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("闽东电机厂");
                comboBoxEdit4.Properties.Items.Add("指月集团有限公司");
            }
            comboBoxEdit8.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='配变电力电容器台帐' and sx like '%{0}%' and nr!=''", "投切方式"));
            if (strlist.Count > 0)
                comboBoxEdit8.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit8.Properties.Items.Add("手动");
                comboBoxEdit8.Properties.Items.Add("自动");
            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select tqName from PS_tq where   left(tqID,{1})='{0}' ", rowData.OrgCode, rowData.OrgCode.Length));
            // string.Format("select LineName from ps_xl where orgcode='{0}' and len(linecode)=6", rowData.OrgCode));
            //  where LineVol='10'
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {

            }
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select LineName from ps_xl where orgcode='{0}'and LineType='1' and  LineVol='10'", rowData.OrgCode));
           
            if (strlist.Count > 0)
                comboBoxEdit6.Properties.Items.AddRange(strlist);
            else
            {

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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }


      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("配变电力电容器台帐", "备注", memoEdit3);
        }

       
    }
}