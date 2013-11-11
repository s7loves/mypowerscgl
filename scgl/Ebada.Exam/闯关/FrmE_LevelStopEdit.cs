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
    public partial class FrmE_LevelStopEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_LevelStop> m_CityDic = new SortableSearchableBindingList<E_LevelStop>();
        public FrmE_LevelStopEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "Name");
            this.mtxtDesc.DataBindings.Add("EditValue", rowData, "Desc");
            this.spSequence.DataBindings.Add("EditValue", rowData, "Sequence");

            this.txtpd.DataBindings.Add("EditValue", rowData, "PdNumAndLevel");
            this.txtds.DataBindings.Add("EditValue", rowData, "DxNumAndLevel");
            this.txtddx.DataBindings.Add("EditValue", rowData,"DDxNumAndLevel");


        }
        private E_LevelStop rowData = null;

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
                    this.rowData = value as E_LevelStop;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_LevelStop>(value as E_LevelStop, rowData);
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
                MsgBox.ShowWarningMessageBox("站点名不能为空！");
                return;
            }
            string sql1 = " where LevelID='"+rowData.LevelID+"' and  ID!='" + rowData.ID + "'  and Name='" + pname + "'";
            int recordnum1 = MainHelper.PlatformSqlMap.GetRowCount<E_LevelStop>(sql1);
            if (recordnum1 > 0)
            {
                MsgBox.ShowWarningMessageBox("站点名【" + recordnum1 + "】 已存在，请正确填写站点名！");
                return;
            }


            string sql2 = " where  LevelID='" + rowData.LevelID + "' and  ID!='" + rowData.ID + "'  and Sequence=" + rowData.Sequence;
            int recordnum2=MainHelper.PlatformSqlMap.GetRowCount<E_LevelStop>(sql2);
            if (recordnum2>0)
            {
                MsgBox.ShowWarningMessageBox("序号 【"+rowData.Sequence+"】 已存在，请正确编号！");
                return;
            }
            //计算试题总数
            rowData.QuestionAllNUM = CommentHelper.GetQuestionNum(rowData.PdNumAndLevel) + CommentHelper.GetQuestionNum(rowData.DxNumAndLevel) + CommentHelper.GetQuestionNum(rowData.DDxNumAndLevel);

            this.DialogResult = DialogResult.OK;
        }

      

       
    }
}
