﻿/**********************************************
系统:企业ERP
模块:  
作者:Rabbit
创建时间:2011-6-2
最后一次修改:2011-6-2
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_14aqgjM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCSD_14aqgjM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucpJ_14aqgj1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<sdjl_aqgj>(ucpJ_14aqgj1_FocusedRowChanged);
            
        }

        void ucpJ_14aqgj1_FocusedRowChanged(object sender, sdjl_aqgj obj)
        {
            ucpJ_14aqgjsy1.ParentID = "";
            ucpJ_14aqgjsy1.PSObj = null;
            ucpJ_14aqgjsy1.PSObj = obj;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
