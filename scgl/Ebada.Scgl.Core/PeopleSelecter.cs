using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
namespace Ebada.Scgl.Core
{
    public partial class PeopleSelecter : DevExpress.XtraEditors.XtraForm
    {
        public PeopleSelecter()
        {
            InitializeComponent();
        }
        public string  OrgCode;
        public mUser User;
        public string UserName = string.Empty;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
        }
        private void InitData()
        {
            //IList<mOrg> orglist = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where OrgType=2");

            //gridControl1.DataSource = orglist;

            //gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView1_RowClick);

            if (OrgCode != null||OrgCode!=string.Empty)
            {
                IList<mUser> urserlist = Client.ClientHelper.PlatformSqlMap.GetList<mUser>(" where OrgCode='" + OrgCode + "'");

                gridControl2.DataSource = urserlist;

            }

        }

        void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            mOrg org = gridView1.GetFocusedRow() as mOrg;
            if (org!=null)
            {
                IList<mUser> urserlist = Client.ClientHelper.PlatformSqlMap.GetList<mUser>(" where OrgCode='"+org.OrgCode+"'");

                gridControl2.DataSource = urserlist;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mUser user = gridView2.GetFocusedRow() as mUser;
            if (user!=null)
            {
                User = user;
                UserName = user.UserName;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}