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
    public partial class frm_sgzayc : FormBase, IPopupFormEdit 
    {
        public frm_sgzayc()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_sgzayc rowData;
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
                    this.rowData = value as bdjl_sgzayc;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_sgzayc>(value as bdjl_sgzayc, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.datefssj.DataBindings.Add("EditValue", rowData, "fssj");
            this.txtxz.DataBindings.Add("EditValue", rowData, "xz");
            this.txtjt.DataBindings.Add("EditValue", rowData, "jt");
            this.memofsjg.DataBindings.Add("EditValue", rowData, "fsjg");
            this.txtsgssqk.DataBindings.Add("EditValue", rowData, "sgsxqk");
            this.memoyyjzrfx.DataBindings.Add("EditValue", rowData, "yyjfzfx");
            this.memodc.DataBindings.Add("EditValue", rowData, "dc");
        }

        #endregion

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            SelectorHelper.SelectDyk("变电事故、障碍及异常运行记录", "事故障碍异常信息", memofsjg, memoyyjzrfx, memodc);

        }
    }
}