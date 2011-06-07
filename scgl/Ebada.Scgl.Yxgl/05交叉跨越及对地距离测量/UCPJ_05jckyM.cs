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

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_05jckyM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_05jckyM() {
            InitializeComponent();
            //接收行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_05jcky>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PJ_05jcky obj)
        {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = "跨越物：" + (obj != null ? obj.kymc : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
