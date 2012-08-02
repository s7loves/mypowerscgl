/**********************************************
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
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC材料返库M : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UC材料返库M() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Model.kc_入库单>(ucTop_FocusedRowChanged);
            splitCC1.Panel1.Text = "返库单列表";
            splitCC1.Panel2.Text = "返库明细表";
        }

        void ucTop_FocusedRowChanged(object sender, kc_入库单 obj) {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = "返库明细：" + (obj != null ? obj.入库单号 : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucBottom.InitColumns();
            ucTop.InitData();
           ucTop.ChildView = ucBottom.GridViewOperation;
        }

    }
}
