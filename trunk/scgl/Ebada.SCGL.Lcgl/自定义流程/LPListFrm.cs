using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class LPListFrm : Form
    {
        public LPListFrm()
        {
            InitializeComponent();
        }


        private void LPListFrm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        public void InitData()
        {
            IList<LP_Record> lpList = MainHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", "");
            gridControl1.DataSource = lpList;
        }

        private void add_yzgzp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LPFrm frm = new LPFrm();
            frm.Kind = "yzgzp";
            frm.Status = "add";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
        }

        private void edit_yzgzp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LPFrm frm = new LPFrm();
            frm.Kind = "yzgzp";
            frm.Status = "edit";
            LP_Record record = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>((gridView1.GetFocusedRow() as LP_Record).ID);
            if (record!=null)
            {
                frm.CurrRecord = record;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    InitData();
                }
            }
        }
    }
}
