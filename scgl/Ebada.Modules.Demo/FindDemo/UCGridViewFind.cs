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
    public partial class UCGridViewFind : DevExpress.XtraEditors.XtraUserControl,IPopupFind {
        public UCGridViewFind() {
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


        #region IPopupFind 成员

       public event FindDataEventHandler FindEvent;
       public event EventHandler HideEvent;
       #endregion

       private void btReset_Click(object sender, EventArgs e) {
           textEdit1.Text = "";
       }

       private void btFind_Click(object sender, EventArgs e) {
           if (FindEvent != null)
               FindEvent(null, GetFilter());
       }

       private void btHide_Click(object sender, EventArgs e) {
           HideEvent(this, null);
       }


       #region IPopupFind 成员


       public ShowType ShowType {
           get {
               return ShowType.Default ;
           }
           set {
               throw new NotImplementedException();
           }
       }

       #endregion
    }
}
