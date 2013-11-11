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
    public partial class UCE_LevelM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCE_LevelM()
        {
            InitializeComponent();
            ucE_LevelSeason1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.E_LevelSeason>(ucE_LevelSeason1_FocusedRowChanged);
            ucE_Level1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.E_Level>(ucE_Level1_FocusedRowChanged);
           
        }

        void ucE_LevelSeason1_FocusedRowChanged(object sender, Ebada.Scgl.Model.E_LevelSeason obj)
        {
            if (obj!=null)
            {
                ucE_Level1.ParentID = obj.ID;
                ucE_LevelStop1.ParentIDA = obj.ID;
            }
        }
        void ucE_Level1_FocusedRowChanged(object sender, Ebada.Scgl.Model.E_Level obj)
        {
            if (obj != null)
            {
                ucE_LevelStop1.ParentIDB = obj.ID;
            }
            else
            {
                ucE_LevelStop1.ParentIDB ="";
            }
        }
       
       

      
        
    }
}
