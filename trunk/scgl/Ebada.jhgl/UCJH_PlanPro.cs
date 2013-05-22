using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.jhgl
{
    public partial class UCJH_PlanPro : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void GridviewDoubleClickHandler(object sender, string planPro);

        public event GridviewDoubleClickHandler GridviewDoubleClick;
        public string year;
        public string orgcode;
        DataTable dt;
        public UCJH_PlanPro()
        {
            InitializeComponent();
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (GridviewDoubleClick != null)
                GridviewDoubleClick(this, gridView1.GetFocusedRow() as string);
        }

        private void UCJH_WorkContent_Load(object sender, EventArgs e)
        {
            string sql = "select distinct 计划项目 from JH_yearks where parentID ='"
                +year + "' and 单位代码='"+orgcode+"' and 计划项目!=''";

            IList<string> list = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sql);
            gridControl1.DataSource = list;
            this.gridView1.Columns[0].Caption = "计划项目";
            
        }
    }
}
