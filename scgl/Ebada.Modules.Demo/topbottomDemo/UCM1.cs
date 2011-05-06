/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-3-1
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
    /// 上下两部分示例
    /// </summary>
    public partial class UCM1 : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 两个GridView，上下分
        /// </summary>
        public UCM1() {
            InitializeComponent();
            ucTop1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Platform.Model.mOrg>(ucTop1_FocusedRowChanged);
            ucTop1.ChildView = ucBottom1.GridViewOperation;
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucTop1.GridViewOperation.RefreshData(null);
        }
        void ucTop1_FocusedRowChanged(object sender, Ebada.Platform.Model.mOrg obj) {
            ucBottom1.ParentID = obj.Org_ID;
            splitCC1.Panel2.Text = "职员单位：" + (obj != null ? obj.cnName : "");
        }
    }
}
