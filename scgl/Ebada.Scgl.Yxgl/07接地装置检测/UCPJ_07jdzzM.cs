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
    public partial class UCPJ_07jdzzM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_07jdzzM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_07jdzz>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PJ_07jdzz obj)
        {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = " " + (obj != null ? obj.OrgName : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            splitCC1.Panel1.Text = "接地装置";
            splitCC1.Panel1.Text = "接地装置检测记录";
        }


    }
}
