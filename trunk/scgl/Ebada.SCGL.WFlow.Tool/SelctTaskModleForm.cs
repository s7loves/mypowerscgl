using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client.Platform;
using Ebada.Core;
using System.Collections;
using Ebada.Scgl.Model;
using System.Reflection;
using System.Globalization;
using Ebada.UI.Base;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SelctTaskModleForm : FormBase
    {
        public SelctTaskModleForm()
        {
            InitializeComponent();
        }
        DataTable mdt = new DataTable();
        DataTable bdt = new DataTable();
        private void SelctModleForm_Load(object sender, EventArgs e)
        {

            treeList1.BeginInit();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;
            string sqlwhere = " where 1=0";
            sqlwhere = "  a " +
               "where a.modu_id in (select b.modu_id from rRoleModul b " +
               "inner join rUserRole c on b.roleid=c.roleid " +
               "where a.visiableflag=1" + " and c.userid='" + MainHelper.User.UserID + "' and ModuTypes != 'hide')";
            sqlwhere = "where ModuTypes != 'hide' order by Sequence";
            IList mlist = MainHelper.PlatformSqlMap.GetList("SelectmModuleList", sqlwhere);
            if (mlist.Count == 0)
            {
                mdt = new DataTable();
            }
            else
            {
                mdt = ConvertHelper.ToDataTable(mlist);
            }
            treeList1.DataSource = mdt;
            treeList1.EndInit();
            bdt.Columns.Add("butname",typeof(string));
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(treeList1.FocusedNode["Modu_ID"]);

            if ((mUserModule)MainHelper.PlatformSqlMap.GetObject("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' and mMouleID='" + obj.Modu_ID + "'") != null)
            {
                return;
            }
            if (obj.AssemblyFileName == "") return;
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory+obj.AssemblyFileName);
            Type tp = assembly.GetType(obj.ModuTypes);
            object fromCtrl;
            if (obj.MethodName == "")////窗体的构造函数不需要参数
                fromCtrl = Activator.CreateInstance(tp);
            else//窗体的构造函数需要参数
                fromCtrl = Activator.CreateInstance(tp, obj.MethodName);
            if (fromCtrl is UserControl)
            {
                UserControl fromCtrl2 = fromCtrl as UserControl;
                foreach (Control c in fromCtrl2.Controls)
                    {
                        switch(c.GetType().FullName)
                        {
                            case "DevExpress.XtraEditors.SplitContainerControl":
                                DevExpress.XtraEditors.SplitContainerControl sc = c as DevExpress.XtraEditors.SplitContainerControl;
                                sc.Visible = false;
                                sc.Name = sc.Name;
                                break;
                        }

                    }
                }
             
        }
    
 

 

    }
}
