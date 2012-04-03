using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using Ebada.Scgl.Model;
using DevExpress.XtraGrid.Columns;

namespace Ebada.Scgl.Gis.Device {
    public partial class frmXLSbtj : XtraForm {
        private PS_xl m_xl;
        public frmXLSbtj() {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            InitColumns();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridView1.OptionsView.ShowAutoFilterRow = false;
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Application.DoEvents();
            InitData();
        }
        protected virtual void simpleButton1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
        protected virtual void simpleButton2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void InitData(){
            IList<PS_tj> tjList = new List<PS_tj>();
            IList<mOrg> orgList = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + m_xl.OrgCode + "'");
            mOrg org = null;
            string strOwner = "";
            if (orgList.Count>0)
            {
                org = orgList[0];
                strOwner = org.OrgName;
            }
            IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + m_xl.LineCode + "' group by sbModle,sbName");
            //IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + str.Trim() + "' group by sbModle,sbName");
            foreach (object[] ob in gtSBList)
            {
                PS_tj tj = new PS_tj();
                tj.SmOrg = strOwner;
                tj.SbOwner = m_xl.LineName;
                tj.SBNumber = Convert.ToInt32(ob[0]);
                tj.SbType = ob[1].ToString();
                tj.SbName = ob[2].ToString();
                tjList.Add(tj);
            }
            gridControl1.DataSource = tjList;
//             foreach (GridColumn c in gridView1.Columns)
//             {
//                 c.Visible = false;
// 
//             }
            try
            {
                gridView1.Columns["SmOrg"].Visible = false;
                //gridView1.Columns["SbType"].Visible = true;
                //gridView1.Columns["SBNumber"].Visible = true;
                gridView1.Columns["SbOwner"].VisibleIndex = 0;
                gridView1.Columns["SbOwner"].Caption = "线路";
                gridView1.Columns["SbName"].VisibleIndex = 1;
                gridView1.Columns["SbType"].VisibleIndex = 2;
                gridView1.Columns["SBNumber"].VisibleIndex = 3;               
            }
            catch { }
//             foreach (object[] ob in tqSBList)
//             {
//                 PS_tj tj = new PS_tj();
//                 string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
//                 tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
//                 tj.SbOwner = strOwner;
//                 tj.SBNumber = Convert.ToInt32(ob[0]);
//                 tj.SbType = ob[1].ToString();
//                 tj.SbName = ob[2].ToString();
//                 tjList.Add(tj);
//             }
        }
        protected virtual void InitColumns() {

        }
        public virtual object GetSelected() {

            return gridView1.GetFocusedRow();
        }
        public void SetXL(PS_xl xl)
        {
            m_xl = xl;
        }
    }
}
