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

namespace Ebada.Scgl.Sbgl
{
    public partial class frm_ddczzl : FormBase, IPopupFormEdit
    {
        public frm_ddczzl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_ddzczl rowData;
        public object RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as bdjl_ddzczl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_ddzczl>(value as bdjl_ddzczl, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtlb.DataBindings.Add("EditValue", rowData, "lb");
            this.datekssj.DataBindings.Add("EditValue", rowData, "kssj");
            this.txtdd.DataBindings.Add("EditValue", rowData, "dd");
            this.txtbds.DataBindings.Add("EditValue", rowData, "bds");
            this.txtzlbh.DataBindings.Add("EditValue", rowData, "zlbh");
            this.memonr.DataBindings.Add("EditValue", rowData, "nr");
            this.timezzsj.DataBindings.Add("EditValue", rowData, "zzsj");

        }

        private void Initlkue()
        {
            ////10代表避雷器
            //string sqlsbmc = "select distinct a2 from BD_SBTZ where OrgCode='" + rowData.OrgCode + "' and rtrim(ltrim(a2))!='' and sbtype='16'";
            //IList<string> ls = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            //List<DicType> sbmcList = new List<DicType>();
            //foreach (string mc in ls)
            //{
            //    sbmcList.Add(new DicType(mc, mc));
            //}
            ////SetComboBoxData(lkueblqmc, "Value", "Key", "请选择", "避雷器名称", sbmcList);
            //ComboBoxHelper.FillCBoxByDyk("变电调度操作指令", "调度", this.txtdd);
            //ComboBoxHelper.FillCBoxByDyk("变电调度操作指令", "变电所", this.txtbds);
            ComboBoxHelper.FillCBoxByDyk("变电调度操作指令", "指令编号", this.txtzlbh);


            string sqlsbmc = "select username  from mUser where OrgCode='032'";
            ICollection ryList = (ICollection)Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            txtdd.Properties.Items.AddRange(ryList);
        }

        //SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
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

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电调度操作指令", "内容", memonr);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PeopleSelecter frm = new PeopleSelecter();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                txtbds.Text = frm.UserName;
            }
        }
    }
}