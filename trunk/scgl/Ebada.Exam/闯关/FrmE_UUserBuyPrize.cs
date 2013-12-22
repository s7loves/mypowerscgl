using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;
using System.IO;

namespace Ebada.Exam
{
    public partial class FrmE_UUserBuyPrize :FormBase{
       
        public FrmE_UUserBuyPrize()
        {
            InitializeComponent();
        }

        public E_Prize CurrPrize;
       

        void dataBind()
        {

          
            
        }
        private E_Prize rowData = null;
        E_UserScore userscore;
        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                this.rowData = value as E_Prize;
                this.spPriceScore.EditValue = rowData.Price;
                this.spPrizeLeftNum.EditValue = rowData.CurrentNum;

                 userscore= MainHelper.PlatformSqlMap.GetOne<E_UserScore>(" where UserID='" + MainHelper.User.UserID + "'");
                 labShowScore.Text = "您当前可用分数为：[" + userscore.CurrtenScore + "]";
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int m = (int)spBuyNum.Value;
            if (m == 0)
            {
                MsgBox.ShowWarningMessageBox("最少兑换1件！");
                return;
            }

            if (userscore.CurrtenScore < m * rowData.Price)
            {
                MsgBox.ShowWarningMessageBox("您的分数不足，无法兑换！");
                return;
            }

            E_UserPrizeRecord eup = new E_UserPrizeRecord();
            eup.UserID = MainHelper.User.UserID;
            eup.PrizeID = rowData.ID;
            eup.PrizeNum = m;
            eup.SendTime = DateTime.Now;
            MainHelper.PlatformSqlMap.Create<E_UserPrizeRecord>(eup);
            this.DialogResult = DialogResult.OK;
        }

   

       
    }
}
