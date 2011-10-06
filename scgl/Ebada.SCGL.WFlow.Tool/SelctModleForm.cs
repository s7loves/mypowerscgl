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

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SelctModleForm : Form
    {
        public SelctModleForm()
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
            //object instance = null;//模块接口
            // object result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, this, ref instance);
            //    if (result is UserControl) {
                    
            //    }
            //    if (instance is Form)
            //    {
            //        Form fb = instance as Form;
            //    }
            object instance = null;//模块接口
            object uc = Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, this, ref instance);
            if (uc is UserControl)
            {
                UserControl fromCtrl = uc as UserControl;
                    foreach (Control c in fromCtrl.Controls)
                    {
                     
                        //Control c1 = c as Button;
                        //if (c1 != null)
                        //{
                        //    c1.Text = "This is A Button";
                        //}
                        switch(c.GetType().FullName)
                        {
                            case "DevExpress.XtraEditors.SplitContainerControl":
                                DevExpress.XtraEditors.SplitContainerControl sc = c as DevExpress.XtraEditors.SplitContainerControl;

                                sc.Name = sc.Name;
                                break;
                        }

                    }
                }
             if (instance is Form)
             {

             }
            
        }
        public static object Execute(string assemblyName, string className, string methodName, object[] paramValues, Form mdi, ref object classInstance)
        {
            int num;
            if (assemblyName == null)
            {
                assemblyName = string.Empty;
            }
            if ((className == null) || (className == string.Empty))
            {
                return null;
            }
            if (string.IsNullOrEmpty(methodName))
            {
                methodName = "Show";
            }
            if (paramValues == null)
            {
                paramValues = new object[0];
            }
            object obj2 = null;
            Type type = Assembly.GetExecutingAssembly().GetType(className);
            if (null == type)
            {
                type = ((assemblyName == string.Empty) ? Assembly.GetExecutingAssembly() : Assembly.LoadFrom(Application.StartupPath + @"\" + assemblyName)).GetType(className, true);
            }
            Type[] types = new Type[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                types[num] = paramValues[num].GetType();
            }
            MethodInfo method = type.GetMethod(methodName, types);
            if (method == null)
            {
                return obj2;
            }
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != paramValues.Length)
            {
                return obj2;
            }
            object[] objArray = new object[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                objArray[num] = Convert.ChangeType(paramValues[num], parameters[num].ParameterType, CultureInfo.InvariantCulture);
            }
            if (classInstance == null)
            {
                classInstance = method.IsStatic ? null : Activator.CreateInstance(type);
            }
            if ((classInstance is Form) && (mdi != null))
            {
               // ((Form)classInstance).MdiParent = mdi;
                classInstance = mdi;
            }
            else if (classInstance is UserControl)
            {
                return classInstance;
            }
            return method.Invoke(classInstance, objArray);
        }

 

 

    }
}
