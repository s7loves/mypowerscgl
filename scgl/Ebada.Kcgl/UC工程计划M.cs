/**********************************************
系统:企业ERP
模块:  
作者:Rabbit
创建时间:2012-8-8
最后一次修改:2012-8-8
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
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC工程计划M : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UC工程计划M() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Model.kc_工程类别>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, kc_工程类别 obj) {
            ucBottom.ParentObj = obj;
            splitCC1.Panel1.Text = "工程列表";
            splitCC1.Panel2.Text = "工程计划明细：" + (obj != null ? obj.工程类别 : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucTop.InitData();
           ucTop.ChildView = ucBottom.GridViewOperation;
        }

    }
}
