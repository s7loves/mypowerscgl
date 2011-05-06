/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-3-2
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client;

namespace Ebada.Modules.Demo {
    public partial class UCBottomFind : DevExpress.XtraEditors.XtraUserControl,IPopupFind {
        public UCBottomFind() {
            InitializeComponent();
        }
        /// <summary>
        /// 查询条件的字符串
        /// </summary>
       private string GetFilter() {
            string filter = "";

            if(!string.IsNullOrEmpty(textEdit1.Text.Trim()))
                filter = string.Format("Empolyee_Name like '%{0}%'", textEdit1.Text);
            return filter;
        }
       protected override void OnLoad(EventArgs e) {
           base.OnLoad(e);
           if (showtype == ShowType.DropDown)
               btHide.Hide();
       }
       
       private void btReset_Click(object sender, EventArgs e) {
           textEdit1.Text = "";
       }

       private void btFind_Click(object sender, EventArgs e) {
           if (FindEvent != null)
               FindEvent(null, GetFilter());
       }

       private void btHide_Click(object sender, EventArgs e) {
           if(HideEvent!=null)
               HideEvent(this, null);
       }


       #region IPopupFind 成员
       ShowType showtype=ShowType.DropDown ;

       public event FindDataEventHandler FindEvent;
       public event EventHandler HideEvent;

       public ShowType ShowType {
           get {
               return showtype;
           }
           set {
               showtype = value;
               if (showtype == ShowType.DropDown)
                   btHide.Hide();               
           }
       }

       #endregion
    }
}
