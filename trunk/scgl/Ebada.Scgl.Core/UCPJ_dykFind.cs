using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client; 

namespace Ebada.Scgl.Core {
    public partial class UCPJ_dykFind : DevExpress.XtraEditors.XtraUserControl, IPopupFind {
        public UCPJ_dykFind() {
            InitializeComponent();
        }
        /// <summary>
        /// 查询条件的字符串
        /// </summary>
       private string GetFilter() {
            string filter = "";

            if(!string.IsNullOrEmpty(textEdit1.Text.Trim()))
                filter = string.Format("bh like '%{0}%' or zjm like '%{1}' ", textEdit1.Text, textEdit2.Text);
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
               return ShowType.Inside;
           }
           set {
               throw new NotImplementedException();
           }
       }

       #endregion

       private void groupControl1_Paint(object sender, PaintEventArgs e) {

       }
    }
}
