using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmSBBZQSBGMXB4Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_sbbzqsbgmxb4> m_CityDic = new SortableSearchableBindingList<PJ_sbbzqsbgmxb4>();

        public frmSBBZQSBGMXB4Edit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sssbmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sssswz");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sssbbh");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "statuts");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xw");
            //this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "hj");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_sbbzqsbgmxb4 rowData = null;

        public object RowData {
            get {
                rowData.sssbbh = spinEdit1.Text + "," + spinEdit2.Text + "," + spinEdit3.Text;
                rowData.S1 = spinEdit6.Text + "," + spinEdit5.Text + "," + spinEdit4.Text + "," + spinEdit7.Text;
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_sbbzqsbgmxb4;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_sbbzqsbgmxb4>(value as PJ_sbbzqsbgmxb4, rowData);
                }
                string[] numbstr = rowData.sssbbh.Split(',');
                if (numbstr.Length>0)
                {
                    try
                    {
                        int a = 1;
                        int.TryParse(numbstr[0], out a);
                        spinEdit1.EditValue = a;
                        int b= 1;
                        int.TryParse(numbstr[1], out b);
                        spinEdit2.EditValue = b;
                        int c = 1;
                        int.TryParse(numbstr[2], out c);
                        spinEdit3.EditValue = c;

                    }
                    catch 
                    {
                        spinEdit1.EditValue = spinEdit2.EditValue = spinEdit3.EditValue = 0;
                    }
                   
                }
                else
                {
                    spinEdit1.EditValue = spinEdit2.EditValue = spinEdit3.EditValue = 0;
                }

                string[] numbstr1 = rowData.S1.Split(',');
                if (numbstr1.Length > 0)
                {
                    try
                    {
                        int a = 1;
                        int.TryParse(numbstr1[0], out a);
                        spinEdit6.EditValue = a;
                        int b = 1;
                        int.TryParse(numbstr1[1], out b);
                        spinEdit5.EditValue = b;
                        int c = 1;
                        int.TryParse(numbstr1[2], out c);
                        spinEdit4.EditValue = c;
                        int d = 1;
                        int.TryParse(numbstr1[3], out d);
                        spinEdit7.EditValue = c;

                    }
                    catch
                    {
                        spinEdit6.EditValue = spinEdit5.EditValue = spinEdit4.EditValue = spinEdit7.EditValue = 0;
                    }

                }
                else
                {
                    spinEdit1.EditValue = spinEdit2.EditValue = spinEdit3.EditValue = 0;
                }
            }
        }

        #endregion




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void InitComboBoxData() {
           
            //填充下拉列表数据
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.Add("相序牌");

            comboBoxEdit2.Properties.Items.Clear();
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName from PS_xl where OrgCode ='" + rowData.OrgCode + "' and linevol='10'");
            comboBoxEdit2.Properties.Items.AddRange(list);

            comboBoxEdit4.Properties.Items.Clear();
            comboBoxEdit4.Properties.Items.Add("缺失");
            comboBoxEdit4.Properties.Items.Add("变更");
            comboBoxEdit4.Properties.Items.Add("新增");

            //comboBoxEdit1.Properties.Items.Clear();
            //IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表四' and sx like '%{0}%' and nr!=''", "所属设备名称"));
            //if (strlist.Count > 0)
            //    comboBoxEdit1.Properties.Items.AddRange(strlist);
            //else
            //{
            //    comboBoxEdit1.Properties.Items.Add("变台、变电亭、箱式配电站");
            //    //comboBoxEdit1.Properties.Items.Add("变电亭");
            //    //comboBoxEdit1.Properties.Items.Add("箱式配电站");
            //    //comboBoxEdit1.Properties.Items.Add("开关");
            //}

            //comboBoxEdit2.Properties.Items.Clear();
            // strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表四' and sx like '%{0}%' and nr!=''", "所属设备位置"));
            //if (strlist.Count > 0)
            //    comboBoxEdit2.Properties.Items.AddRange(strlist);
            //else
            //{
            //  comboBoxEdit2.Properties.Items.Add( MainHelper.UserOrg.OrgName);
            //   //  MainHelper.UserOrg.OrgName
            //}

            //comboBoxEdit3.Properties.Items.Clear();
            //// strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            ////string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表四' and sx like '%{0}%' and nr!=''", "所属设备编号"));
            ////if (strlist.Count > 0)
            ////    comboBoxEdit3.Properties.Items.AddRange(strlist);
            ////else
            ////{
            ////    comboBoxEdit3.Properties.Items.Add("1#");
            ////    comboBoxEdit3.Properties.Items.Add("2#");
            ////    comboBoxEdit3.Properties.Items.Add("3#");
            ////    comboBoxEdit3.Properties.Items.Add("8#");
            ////    comboBoxEdit3.Properties.Items.Add("9#");
            ////    comboBoxEdit3.Properties.Items.Add("13#");
            ////    comboBoxEdit3.Properties.Items.Add("15#");
            ////    comboBoxEdit3.Properties.Items.Add("20#");

            ////}
            //for (int i = 0; i < 301; i++)
            //{
            //    comboBoxEdit3.Properties.Items.Add(i + "号");
            //}

         
          
           

            //comboBoxEdit4.Properties.Items.Clear();
            //string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表四' and sx like '%{0}%' and nr!=''", "状态");
            //if (strlist.Count > 0)
            //    comboBoxEdit4.Properties.Items.AddRange(strlist);
            //else
            //{
            //    comboBoxEdit4.Properties.Items.Add("缺失");
            //    comboBoxEdit4.Properties.Items.Add("变更");
            //    comboBoxEdit4.Properties.Items.Add("新增");

            //}

           

            //comboBoxEdit5.Properties.Items.Clear();
            //string.Format("select nr from pj_dyk where  dx='设备标志缺失变更明细表四' and sx like '%{0}%' and nr!=''", "相位");
            //if (strlist.Count > 0)
            //    comboBoxEdit5.Properties.Items.AddRange(strlist);
            //else
            //{
            //    comboBoxEdit5.Properties.Items.Add("高压A相");
            //    comboBoxEdit5.Properties.Items.Add("高压B相");
            //    comboBoxEdit5.Properties.Items.Add("高压C相");
            //    comboBoxEdit5.Properties.Items.Add("低压A相");
            //    comboBoxEdit5.Properties.Items.Add("低压B相");
            //    comboBoxEdit5.Properties.Items.Add("低压C相");
            //    comboBoxEdit5.Properties.Items.Add("低压0相");

            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        

       
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("设备标志缺失变更明细表四", "备注", memoEdit3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

      

      

      

       

      

       
    }
}