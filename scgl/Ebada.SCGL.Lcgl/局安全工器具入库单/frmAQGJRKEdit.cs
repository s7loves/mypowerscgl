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
using System.Threading;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmAQGJRKEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_anqgjcrkd> m_CityDic = new SortableSearchableBindingList<PJ_anqgjcrkd>();

        public frmAQGJRKEdit()
        {
            InitializeComponent();
        }
        void dataBind() {
            
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "wpdw");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "type");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "num");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "wpsl");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "wpdj");;
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "zkcsl");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "indate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_anqgjcrkd rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_anqgjcrkd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_anqgjcrkd>(value as PJ_anqgjcrkd, rowData);
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
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='局安全工器具入库单' and sx like '%{0}%' and nr!=''", "材料名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
            //    strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select distinct mc from PS_sbcs "));
            //    if (strlist.Count > 0)
            //        comboBoxEdit1.Properties.Items.AddRange(strlist);
            //    else
            //    {
                    
            //    }
            }

            comboBoxEdit2.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='局安全工器具入库单' and sx like '%{0}%' and nr!=''", "材料规格"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
            //    strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select distinct xh from PS_sbcs where xh is not null "));
            //    if (strlist.Count > 0)
            //        comboBoxEdit1.Properties.Items.AddRange(strlist);
            //    else
            //    {
                    

            //    }


            }

            comboBoxEdit3.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='局安全工器具入库单' and sx like '%{0}%' and nr!=''", "单位"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("根");
                comboBoxEdit3.Properties.Items.Add("片");
                comboBoxEdit3.Properties.Items.Add("个");
                comboBoxEdit3.Properties.Items.Add("付");

                comboBoxEdit3.Properties.Items.Add("套");
                comboBoxEdit3.Properties.Items.Add("块");
                comboBoxEdit3.Properties.Items.Add("Kg");
                comboBoxEdit3.Properties.Items.Add("米");

                comboBoxEdit3.Properties.Items.Add("台");
                comboBoxEdit3.Properties.Items.Add("卷");
                comboBoxEdit3.Properties.Items.Add("捆");
                comboBoxEdit3.Properties.Items.Add("组");

            }

         
          
           


           



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

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

       
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("安全工器具入库单", "备注", memoEdit3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        //private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    double injg = 0;
        //    double innum = 0;
        //     injg = Convert.ToDouble(spinEdit1.Value);
        //     innum = Convert.ToDouble(spinEdit2.Value);

        //}

      
        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            rowData.kcsl = spinEdit2.Value.ToString();
            long i = 0;
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneInt",
                "select  sum(cast(kcsl as int) )  from PJ_anqgjcrkd where (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存')"
                + " and wpmc='" + comboBoxEdit1.Text + "' "
                + " and wpgg='" + comboBoxEdit2.Text + "' and id!='" + rowData.ID + "' ");
            if (mclist[0]!=null)i=Convert.ToInt64(mclist[0].ToString());
            rowData.zkcsl = (Convert.ToInt64(rowData.kcsl) + i).ToString();
            comboBoxEdit10.Text = rowData.zkcsl;
            rowData.lasttime = DateTime.Now;  
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit2_EditValueChanged(sender, e);
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh  from PS_sbcs where   mc='" + comboBoxEdit1.Text + "' and xh is not null ");
            if (mclist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(mclist);
            else
            {
                mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct nr  from pj_dyk where   sx='" + comboBoxEdit1.Text + "'");
                if (mclist.Count > 0)
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                else
                {
                    mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_clcrkd where  wpmc='" + comboBoxEdit1.Text + "' and ssxm!='' ");
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                }
            }
        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            

            spinEdit2_EditValueChanged(sender, e);
        }

        private void comboBoxEdit7_TextChanged(object sender, EventArgs e)
        {
            spinEdit2_EditValueChanged(sender, e);
          
        }

        private void frmCLRKEdit_Load(object sender, EventArgs e)
        {

            comboBoxEdit8.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct num  from PJ_clcrkd where type = '撤旧材料入库单' or type = '撤旧材料入库单原始库存'");
            
            PJ_anqgjcrkd obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_anqgjcrkd>(rowData.ID);
            if (obj == null)
            {
                btnOK.Visible = false;
                simpleButton4.Visible = true;
                comboBoxEdit8.Properties.Items.Add(rowData.num);
            }
            else
            {
                btnOK.Visible = true;
                simpleButton4.Visible = false;
            }
            comboBoxEdit8.Properties.Items.AddRange(mclist);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            rowData.ID = rowData.CreateID();
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            Client.ClientHelper.PlatformSqlMap.Create<PJ_anqgjcrkd>(rowData);
            MsgBox.ShowTipMessageBox("添加成功!");
            rowData.ID = rowData.CreateID();
        }

      
        
    

      

       

      

       
    }
}