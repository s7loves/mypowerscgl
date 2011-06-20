/**********************************************
系统:企业ERP
模块:职员维护  
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
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

namespace Ebada.Scgl.Xsfx {
    /// <summary>
    /// 机构职员维护
    /// </summary>
    public partial class UCmLineLoss : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 左TreeList右GridView，
        /// </summary>
        public UCmLineLoss() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucLeft1.FocusedNodeChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_xl>(ucLeft1_FocusedNodeChanged);
           
        }

        void ucLeft1_FocusedNodeChanged(object sender, Ebada.Scgl.Model.PS_xl obj)
        {
            ucRight1.ParentObj = obj;
            splitCC1.Panel2.Text = obj != null ? obj.LineName : "";
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucLeft1.InitData();
            
        }

    }
}
