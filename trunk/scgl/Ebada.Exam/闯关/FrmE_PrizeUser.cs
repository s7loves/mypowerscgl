using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;

namespace Ebada.Exam
{
    public partial class FrmE_PrizeUser : FormBase
    {
        public FrmE_PrizeUser()
        {
            InitializeComponent();
            ucE_PrizeLeft1.afterchexiao += new UCE_PrizeLeft.AfterChexiao(ucE_PrizeLeft1_afterchexiao);
        }

        void ucE_PrizeLeft1_afterchexiao()
        {
            ucE_UserPrizeRecordBy1.InitData();
        }
    }
}
