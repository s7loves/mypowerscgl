using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//专业管理
namespace Ebada.Exam
{
    public partial class UcEBNK : DevExpress.XtraEditors.XtraUserControl
    {
        public UcEBNK()
        {
            InitializeComponent();
            ucE_QBank1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.E_QBank>(ucE_QBank1_FocusedRowChanged);
        }
       
        void ucE_QBank1_FocusedRowChanged(object sender, Ebada.Scgl.Model.E_QBank obj)
        {
            if (obj!=null)
            {
                ucE_R_EBankORG1.ParentID = obj.ID;
                ucE_R_EBankPro1.ParentID = obj.ID;
            }
            
        }

      
        
    }
}
