using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Exam
{
    public partial class FrmE_PaperEdit : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_PaperEdit()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            //string tkid = lkueEBank.EditValue.ToString();

            ////删除除它题库的设置
            //string sqlwhere = " where ESETID='" + rowData.ID + "' and BySCol1='" + tkid + "'";
            //IList<E_R_ESetPro> eresblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
            //if (eresblist.Count == 0)
            //{
            //    IList<E_R_EBankPro> erblist = Client.ClientHelper.PlatformSqlMap.GetList<E_R_EBankPro>(" where EBID='" + tkid + "'");
            //    for (int i = 0; i < erblist.Count; i++)
            //    {
            //        E_R_ESetPro er = new E_R_ESetPro();
            //        er.ID += i;
            //        er.ESETID = rowData.ID;
            //        er.PROID = erblist[i].PROID;
            //        er.BySCol1 = tkid;
            //        Client.ClientHelper.PlatformSqlMap.Create<E_R_ESetPro>(er);
            //    }
            //    IList<E_R_ESetPro> eresblist2 = Client.ClientHelper.PlatformSqlMap.GetList<E_R_ESetPro>(sqlwhere);
            //    gridControl1.DataSource = eresblist2;
            //}
            //else
            //{
            //    gridControl1.DataSource = eresblist;
            //}
            //gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDic;
        }

        /// <summary>
        /// 按当前规则生成随机试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandPaper_Click(object sender, EventArgs e)
        {

        }
    }
}