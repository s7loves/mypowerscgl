using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

namespace Ebada.Exam
{
    public partial class FrmE_ExamResult : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_ExamResult()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ucE_ExamResult1.ShowExamGL = true;
        }
    }
}