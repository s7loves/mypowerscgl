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
    public partial class UC材料退货M : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UC材料退货M() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Model.kc_退货单>(ucTop_FocusedRowChanged);
            splitCC1.Panel1.Text = "退货单列表";
            splitCC1.Panel2.Text = "退货明细表";
        }

        void ucTop_FocusedRowChanged(object sender, kc_退货单 obj) {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = "退货明细：" + (obj != null ? obj.退货单号 : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucBottom.InitColumns();
            ucTop.InitData();
           ucTop.ChildView = ucBottom.GridViewOperation;
        }

    }
}
