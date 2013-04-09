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

namespace Ebada.Scgl.Sbgl
{
    public partial class frm_xdjl : FormBase, IPopupFormEdit
    {
        public frm_xdjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_xdjl rowData;
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
                    this.rowData = value as bdjl_xdjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_xdjl>(value as bdjl_xdjl, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtOrgName.DataBindings.Add("EditValue", rowData, "c1");
            this.datexdsj.DataBindings.Add("EditValue", rowData, "xdsj");
            this.txtxdflr.DataBindings.Add("EditValue", rowData, "xdflr");
            this.txtxdslr.DataBindings.Add("EditValue", rowData, "xdslr");
            this.txtxdxl.DataBindings.Add("EditValue", rowData, "xdxl");
            this.txtxddl.DataBindings.Add("EditValue", rowData, "xddl");
            this.datesdsj.DataBindings.Add("EditValue", rowData, "sdsj");
            this.txtsdflr.DataBindings.Add("EditValue", rowData, "sdflr");
            this.txtsdslr.DataBindings.Add("EditValue", rowData, "sdslr");
            this.txtsddl.DataBindings.Add("EditValue", rowData, "xdsdl");
            this.txtxdzhdl.DataBindings.Add("EditValue", rowData, "xdzhdl");
            this.txtbz.DataBindings.Add("EditValue", rowData, "bz");

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
            if (Convert.ToDateTime(datesdsj.EditValue) < Convert.ToDateTime(datexdsj.EditValue))
            {
                MsgBox.ShowWarningMessageBox("送电时间必须晚于限电时间!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
       
    }
}