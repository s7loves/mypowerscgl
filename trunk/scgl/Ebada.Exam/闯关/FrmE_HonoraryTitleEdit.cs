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

namespace Ebada.Exam
{
    public partial class FrmE_HonoraryTitleEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_HonoraryTitle> m_CityDic = new SortableSearchableBindingList<E_HonoraryTitle>();
        public FrmE_HonoraryTitleEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData,"HonoraryTitle");
            this.mtxtDesc.DataBindings.Add("EditValue", rowData, "Desc");
            this.spStart.DataBindings.Add("EditValue", rowData,  "StartScore");
            this.spEnd.DataBindings.Add("EditValue", rowData, "EndScore");
        }
        private E_HonoraryTitle rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as E_HonoraryTitle;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_HonoraryTitle>(value as E_HonoraryTitle, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pname = txtName.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("称号不能为空！");
                return;
            }
            int startscore = int.Parse(spStart.EditValue.ToString());
            int endscore = int.Parse(spEnd.EditValue.ToString());

            if (startscore>=endscore)
            {
                MsgBox.ShowWarningMessageBox("终止分数必须大于起始分数！");
                return;
            }

            string sql = " where StartScore<=" + startscore + " and " + startscore + " <=EndScore";

            int recordnum1 = MainHelper.PlatformSqlMap.GetRowCount<E_HonoraryTitle>(sql);
            if (recordnum1 > 0)
            {
                string sql2=" select top 1 EndScore from E_HonoraryTitle order by EndScore desc";
                int maxscore = (int)MainHelper.PlatformSqlMap.GetObject("SelectE_HonoraryTitleEndScoreBySql", sql2);
                MsgBox.ShowWarningMessageBox("起始分数【" + startscore + "】 设置不合理，请正确填写起始分数，建议设为["+(maxscore+1)+"]！");
                return;
            }



            this.DialogResult = DialogResult.OK;
        }

      

       
    }
}
