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
    public partial class UCPJ_13dlbhM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_13dlbhM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PS_tqdlbh>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PS_tqdlbh obj)
        {
            ucBottom.ParentObj = obj;
            if (ucTop.gds!=null)
            {
                ucBottom.gds = ucTop.gds;
            }
            
            splitCC1.Panel2.Text = " " + (obj != null ? obj.tqName : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
