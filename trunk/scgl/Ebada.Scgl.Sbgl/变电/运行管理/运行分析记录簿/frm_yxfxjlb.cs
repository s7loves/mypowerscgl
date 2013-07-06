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
    public partial class frm_yxfxjlb : FormBase, IPopupFormEdit 
    {
        public frm_yxfxjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_yxfxjlb rowData;
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
                    this.rowData = value as bdjl_yxfxjlb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_yxfxjlb>(value as bdjl_yxfxjlb, rowData);
                }
            }
        }

        private void Initlkue()
        {
            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            this.cmbxcjry.Properties.DataSource = userTypeList;
            this.cmbxcjry.Properties.ValueMember = "Key";
            this.cmbxcjry.Properties.DisplayMember = "Value";
        }

        private void dataBind()
        {
            this.daterq.DataBindings.Add("EditValue", rowData, "sj");
            this.cmbxcjry.DataBindings.Add("EditValue", rowData, "cjry");
            this.memonr.DataBindings.Add("EditValue", rowData, "nr");
            this.memojl.DataBindings.Add("EditValue", rowData, "jl");

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
            SelectorHelper.SelectDyk("变电运行分析记录", "内容", memonr);
            if (!string.IsNullOrEmpty(memonr.EditValue as string))
                rowData.nr = memonr.EditValue as string;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电运行分析记录", "结论", memojl);
            if (!string.IsNullOrEmpty(memojl.EditValue as string))
                rowData.jl = memojl.EditValue as string;

        }

    }
}