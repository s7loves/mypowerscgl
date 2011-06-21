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
    public partial class UCPJ_18gysbpjM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_18gysbpjM()
        {
            InitializeComponent();
            ////接收行焦点改变事件
            ucpJ_18gysbpj1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_18gysbpj>(ucpJ_18gysbpj1_FocusedRowChanged);            
        }

        void ucpJ_18gysbpj1_FocusedRowChanged(object sender, PJ_18gysbpj obj)
        {
            ucpJ_18gysbpjmx1.PSObj = obj;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
