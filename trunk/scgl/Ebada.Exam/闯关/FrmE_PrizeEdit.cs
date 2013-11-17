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
    public partial class FrmE_PrizeEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_Prize> m_CityDic = new SortableSearchableBindingList<E_Prize>();
        public FrmE_PrizeEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtPrizeName.DataBindings.Add("EditValue", rowData, "PrizeName");
            this.mtxtDesc.DataBindings.Add("EditValue", rowData, "Desc");
            this.spPrice.DataBindings.Add("EditValue", rowData, "Price");
            this.spAllNum.DataBindings.Add("EditValue", rowData, "AllNum");
            this.txtType.DataBindings.Add("EditValue", rowData, "Type");
            this.txtSelectChar.DataBindings.Add("EditValue", rowData, "SelectChar");
            this.dateBeginDate.DataBindings.Add("EditValue", rowData, "BeginDate");
            this.dateEndDate.DataBindings.Add("EditValue", rowData, "EndDate");
            this.memoOther.DataBindings.Add("EditValue", rowData, "Other");
        }
        private E_Prize rowData = null;

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
                    this.rowData = value as E_Prize;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_Prize>(value as E_Prize, rowData);
                }
                if (rowData.Image.Length>0)
                {
                    pictureEdit1.EditValue = rowData.Image;

                }
                else
                {
                     pictureEdit1.EditValue =new byte[]{};
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
            string pname = txtPrizeName.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("奖品名称不能为空！");
                return;
            }

            if (txtType.Text.Trim().Length==0)
            {
                MsgBox.ShowWarningMessageBox("分类不能为空！");
                return;
            }


            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Filter = " 图片|*.jpg;*.png;*.jpeg;*.bmp";
            frm.Title = "请选择奖品图片";
            if (frm.ShowDialog()==DialogResult.OK)
            {
                string fName = frm.FileName;
                using (FileStream fs = new FileStream(fName, FileMode.Open))
                {
                    byte[] imgbt = new byte[fs.Length];
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        imgbt = br.ReadBytes(Convert.ToInt32(fs.Length));
                        pictureEdit1.EditValue = imgbt;
                        rowData.Image = imgbt;
                        pictureEdit1.Refresh();
                    }
                }
            }
        }

      

       
    }
}
