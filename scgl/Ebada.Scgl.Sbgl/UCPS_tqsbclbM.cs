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

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_tqsbclbM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPS_tqsbclbM() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PS_tqsbclb>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PS_tqsbclb obj) {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = "台区分类：" + (obj != null ? obj.mc : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucTop.InitColumns();
            ucTop.InitData();
            //ucBottom.ParentID = "0";
            ucBottom.InitColumns();  
           ucTop.ChildView = ucBottom.GridViewOperation;
        }

    }
}
