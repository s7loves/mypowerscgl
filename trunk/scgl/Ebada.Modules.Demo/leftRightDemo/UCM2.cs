/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-2-28
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Modules.Demo {
    /// <summary>
    /// 左右两部分示例
    /// </summary>
    public partial class UCM2 : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 左TreeList右GridView，
        /// </summary>
        public UCM2() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucLeft1.FocusedNodeChanged += new Ebada.Client.SendDataEventHandler<Ebada.Platform.Model.VOrgLevel>(ucLeft1_FocusedNodeChanged);
            ucLeft1.ChildView = ucRight1.GridViewOperation;
        }

        void ucLeft1_FocusedNodeChanged(object sender, Ebada.Platform.Model.VOrgLevel obj) {
            ucRight1.ParentID = obj!=null?obj.Org_ID:null;
            splitCC1.Panel2.Text = "职员单位：" + (obj != null ? obj.cnName : "");
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucLeft1.InitData();
        }

    }
}
