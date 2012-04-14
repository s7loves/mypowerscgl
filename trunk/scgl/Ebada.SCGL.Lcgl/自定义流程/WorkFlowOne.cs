using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Scgl.WFlow;
using Ebada.Client;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Utils;

namespace Ebada.Scgl.Lcgl
{
    public partial class WorkFlowOne : FormBase
    {
        public WorkFlowOne()
        {
            InitializeComponent();
        }
        public void WorkFlowOne_DG(string strname)
        {
            //InitializeComponent();
            //ucpJ_03yxfx1.RecordIkind = "定期分析";
            //ucpJ_03yxfx1.InitColumns();
            //ucpJ_03yxfx1.InitData();
            //mModule md = MainHelper.PlatformSqlMap.GetOne<mModule>("where ModuName='" + this.Text  + "'");
            WF_WorkFlow wf=MainHelper.PlatformSqlMap.GetOne<WF_WorkFlow>("where FlowCaption='" + strname + "'");
            if (wf != null)
            {
                this.uCmLPRecord1.ParentObj = wf;

                this.Show();
            }
            else
            {
                MsgBox.ShowWarningMessageBox("strname参数不对，没找到 " + strname + " 对应的流程！");
                this.uCmLPRecord1.ParentObj = null;
                this.Show();
            }


        }

       


       



    
  
       

      

       
    }
}
