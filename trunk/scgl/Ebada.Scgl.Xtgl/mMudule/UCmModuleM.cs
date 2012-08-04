﻿/**********************************************
系统:企业ERP
模块:职员维护  
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
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

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 机构职员维护
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCmModuleM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 左TreeList右GridView，
        /// </summary>
        public UCmModuleM() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucLeft1.FocusedNodeChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mModule>(ucLeft1_FocusedNodeChanged);
            ucLeft1.ChildView = ucRight1.GridViewOperation;
        }

        void ucLeft1_FocusedNodeChanged(object sender, Ebada.Scgl.Model.mModule obj) {
            ucRight1.ParentObj = obj;
            splitCC1.Panel2.Text = "操作所在模块：" + (obj != null ? obj.ModuName : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            //ucLeft1.InitData();
            
        }

    }
}
