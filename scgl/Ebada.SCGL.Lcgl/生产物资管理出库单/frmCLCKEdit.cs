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
    public partial class frmCLCKEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_clcrkd> m_CityDic = new SortableSearchableBindingList<PJ_clcrkd>();

        public frmCLCKEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "wpdw");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "wpsl");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "wpdj");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "wpcj");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "ssgc");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "yt");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "cksl");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "zkcsl");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "lqdw");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "ssxm");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "indate");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "ckdate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_clcrkd rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_clcrkd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_clcrkd>(value as PJ_clcrkd, rowData);
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
            string.Format("select nr from pj_dyk where  dx='工程材料出库单' and sx like '%{0}%' and nr!=''", "材料名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit1.Properties.Items.Add("水泥杆");
                comboBoxEdit1.Properties.Items.Add("横担");
                comboBoxEdit1.Properties.Items.Add("拉板");
                comboBoxEdit1.Properties.Items.Add("联担");
                comboBoxEdit1.Properties.Items.Add("U型抱箍");
                comboBoxEdit1.Properties.Items.Add("拉板抱箍");
                comboBoxEdit1.Properties.Items.Add("高压立瓶");
                comboBoxEdit1.Properties.Items.Add("悬式绝缘子");
                comboBoxEdit1.Properties.Items.Add("合成针式绝缘子");

                comboBoxEdit1.Properties.Items.Add("耐张线夹");
                comboBoxEdit1.Properties.Items.Add("楔型耐张线夹");
                comboBoxEdit1.Properties.Items.Add("平行挂板");
                comboBoxEdit1.Properties.Items.Add("直角挂板");
                comboBoxEdit1.Properties.Items.Add("U型挂环");
                comboBoxEdit1.Properties.Items.Add("球头挂环");
                comboBoxEdit1.Properties.Items.Add("碗头挂板");
                comboBoxEdit1.Properties.Items.Add("延长环");
                comboBoxEdit1.Properties.Items.Add("并沟线夹");

                comboBoxEdit1.Properties.Items.Add("绝缘并沟线夹");
                comboBoxEdit1.Properties.Items.Add("拉线棒");
                comboBoxEdit1.Properties.Items.Add("拉线盘");
                comboBoxEdit1.Properties.Items.Add("拉盘U卡子");
                comboBoxEdit1.Properties.Items.Add("楔形线夹");
                comboBoxEdit1.Properties.Items.Add("UT线夹");
                comboBoxEdit1.Properties.Items.Add("拉线绝缘子");
                comboBoxEdit1.Properties.Items.Add("钢线卡子");
                comboBoxEdit1.Properties.Items.Add("钢绞线");

                comboBoxEdit1.Properties.Items.Add("镀锌铁线");
                comboBoxEdit1.Properties.Items.Add("接地极");
                comboBoxEdit1.Properties.Items.Add("螺栓");
                comboBoxEdit1.Properties.Items.Add("钢芯铝绞线");
                comboBoxEdit1.Properties.Items.Add("10KV钢芯耐候线");
                comboBoxEdit1.Properties.Items.Add("铜铝过度线夹");
                comboBoxEdit1.Properties.Items.Add("铜铝线鼻子");
                comboBoxEdit1.Properties.Items.Add("电缆");
                comboBoxEdit1.Properties.Items.Add("10KV电缆头");

                comboBoxEdit1.Properties.Items.Add("低压茶台");
                comboBoxEdit1.Properties.Items.Add("低压立瓶");
                comboBoxEdit1.Properties.Items.Add("隔离开关");
                comboBoxEdit1.Properties.Items.Add("隔离开关担");
                comboBoxEdit1.Properties.Items.Add("高压熔断器");
                comboBoxEdit1.Properties.Items.Add("避雷器");
                comboBoxEdit1.Properties.Items.Add("跌落开关");
                comboBoxEdit1.Properties.Items.Add("氧化锌避雷器");
                comboBoxEdit1.Properties.Items.Add("电流互感器");

                comboBoxEdit1.Properties.Items.Add("漏电开关");
                comboBoxEdit1.Properties.Items.Add("理石闸");
                comboBoxEdit1.Properties.Items.Add("低压隔离开关");
                comboBoxEdit1.Properties.Items.Add("胶盖刀闸");
                comboBoxEdit1.Properties.Items.Add("变台计量箱");
                comboBoxEdit1.Properties.Items.Add("电度表");
                comboBoxEdit1.Properties.Items.Add("杆上居民表箱");
                comboBoxEdit1.Properties.Items.Add("墙上居民表箱");
                comboBoxEdit1.Properties.Items.Add("绝缘绑线");

                comboBoxEdit1.Properties.Items.Add("黑胶布");
                comboBoxEdit1.Properties.Items.Add("高压熔丝");
                comboBoxEdit1.Properties.Items.Add("低压保险片");
            }

            comboBoxEdit2.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='工程材料出库单' and sx like '%{0}%' and nr!=''", "材料规格"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit2.Properties.Items.Add("YB-15-8");
                comboBoxEdit2.Properties.Items.Add("YB-15-10");
                comboBoxEdit2.Properties.Items.Add("YB-19-12");
                comboBoxEdit2.Properties.Items.Add("YB-19-15");
                comboBoxEdit2.Properties.Items.Add("aYB-19-18");
                comboBoxEdit2.Properties.Items.Add("cYB-19-21");
                comboBoxEdit2.Properties.Items.Add("<63x6x2240");
                comboBoxEdit2.Properties.Items.Add("<75x7x2240");
                comboBoxEdit2.Properties.Items.Add("<80x8x3500");
                comboBoxEdit2.Properties.Items.Add("<63x6x1500x700");
                comboBoxEdit2.Properties.Items.Add("<50x5x1500");
                comboBoxEdit2.Properties.Items.Add("<63x6x1500");
                comboBoxEdit2.Properties.Items.Add("<70x7x1500");
                comboBoxEdit2.Properties.Items.Add("'-60x6x1100");
                comboBoxEdit2.Properties.Items.Add("'-60*6*970");

                comboBoxEdit2.Properties.Items.Add("'-50x5x770");
                comboBoxEdit2.Properties.Items.Add("'-60x6x770");
                comboBoxEdit2.Properties.Items.Add("'-70x7x770");
                comboBoxEdit2.Properties.Items.Add("'-50x5x260");
                comboBoxEdit2.Properties.Items.Add("'-50x5x220");
                comboBoxEdit2.Properties.Items.Add("'-40x4x200 ");
                comboBoxEdit2.Properties.Items.Add("'-40x4x260  ");
                comboBoxEdit2.Properties.Items.Add("M16xD150");
                comboBoxEdit2.Properties.Items.Add("M16xD190");
                comboBoxEdit2.Properties.Items.Add("M16xD210");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD160");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD170");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD190");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD210");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD220");

                comboBoxEdit2.Properties.Items.Add("'-50x5xD230");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD170");
                comboBoxEdit2.Properties.Items.Add("'-50x5xD190");
                comboBoxEdit2.Properties.Items.Add("P-15T");

                comboBoxEdit2.Properties.Items.Add("XP-7C");
                comboBoxEdit2.Properties.Items.Add("XP-7Q");
                comboBoxEdit2.Properties.Items.Add("NLD-1");
                comboBoxEdit2.Properties.Items.Add("NLD-2");

                comboBoxEdit2.Properties.Items.Add("NLD-3");
                comboBoxEdit2.Properties.Items.Add("NLD-4");
                comboBoxEdit2.Properties.Items.Add("J10NL-  ");
                comboBoxEdit2.Properties.Items.Add("PS-7");

                comboBoxEdit2.Properties.Items.Add("Z-7");
                comboBoxEdit2.Properties.Items.Add("U-7");
                comboBoxEdit2.Properties.Items.Add("Q-7");
                comboBoxEdit2.Properties.Items.Add("W-7");

                comboBoxEdit2.Properties.Items.Add("PH-7");
                comboBoxEdit2.Properties.Items.Add("JB-1");
                comboBoxEdit2.Properties.Items.Add("16x200");
                comboBoxEdit2.Properties.Items.Add("200x400x800");

                comboBoxEdit2.Properties.Items.Add("U-18");
                comboBoxEdit2.Properties.Items.Add("NX-1");
                comboBoxEdit2.Properties.Items.Add("NUT-1");
                comboBoxEdit2.Properties.Items.Add("J-4.5");
                comboBoxEdit2.Properties.Items.Add("JK-1");
                comboBoxEdit2.Properties.Items.Add("GJ-25");
                comboBoxEdit2.Properties.Items.Add("GJ-35");

                comboBoxEdit2.Properties.Items.Add("GJ-50");
                comboBoxEdit2.Properties.Items.Add("GJ-70");
                comboBoxEdit2.Properties.Items.Add("GJ-100");
                comboBoxEdit2.Properties.Items.Add("10#");
                comboBoxEdit2.Properties.Items.Add("<50x5x2500x4");
                comboBoxEdit2.Properties.Items.Add("<50x5x2500x6");

                comboBoxEdit2.Properties.Items.Add("M16x35");
                comboBoxEdit2.Properties.Items.Add("M16x50");
                comboBoxEdit2.Properties.Items.Add("M16x75");
                comboBoxEdit2.Properties.Items.Add("M16x100");
                comboBoxEdit2.Properties.Items.Add("M16x125");
                comboBoxEdit2.Properties.Items.Add("M16x150");

                comboBoxEdit2.Properties.Items.Add("M16x200");
                comboBoxEdit2.Properties.Items.Add("M16x225");
                comboBoxEdit2.Properties.Items.Add("M16x250");
                comboBoxEdit2.Properties.Items.Add("M16x275");
                comboBoxEdit2.Properties.Items.Add("M16x300");
                comboBoxEdit2.Properties.Items.Add("M16x350");

                comboBoxEdit2.Properties.Items.Add("M16x400");
                comboBoxEdit2.Properties.Items.Add("LGJ-25");
                comboBoxEdit2.Properties.Items.Add("LGJ-35");
                comboBoxEdit2.Properties.Items.Add("LGJ-50");
                comboBoxEdit2.Properties.Items.Add("LGJ-70");
                comboBoxEdit2.Properties.Items.Add("LGJ-95");

                comboBoxEdit2.Properties.Items.Add("LGJ-120");
                comboBoxEdit2.Properties.Items.Add("JKLGYJ-35");
                comboBoxEdit2.Properties.Items.Add("JKLGYJ-50");
                comboBoxEdit2.Properties.Items.Add("JKLGYJ-70");
                comboBoxEdit2.Properties.Items.Add("JKLGYJ-95");
                comboBoxEdit2.Properties.Items.Add("JKLGYJ-120");

                comboBoxEdit2.Properties.Items.Add("SLG-1B");
                comboBoxEdit2.Properties.Items.Add("DTL-25");
                comboBoxEdit2.Properties.Items.Add("DTL-35");
                comboBoxEdit2.Properties.Items.Add("DTL-50");
                comboBoxEdit2.Properties.Items.Add("DTL-70");
                comboBoxEdit2.Properties.Items.Add("DTL-95");


                comboBoxEdit2.Properties.Items.Add("VLV-");
                comboBoxEdit2.Properties.Items.Add("ED-1");
                comboBoxEdit2.Properties.Items.Add("ED-2");
                comboBoxEdit2.Properties.Items.Add("PD-1T");
                comboBoxEdit2.Properties.Items.Add("PD-2T");
                comboBoxEdit2.Properties.Items.Add("GW9-10/200");

                comboBoxEdit2.Properties.Items.Add("RW11-10/200");
                comboBoxEdit2.Properties.Items.Add("Y5WS-12.7/50");
                comboBoxEdit2.Properties.Items.Add("RW11-200");
                comboBoxEdit2.Properties.Items.Add("LQG-30/5");
                comboBoxEdit2.Properties.Items.Add("LQG-50/5");
                comboBoxEdit2.Properties.Items.Add("LQG-75/5");


                comboBoxEdit2.Properties.Items.Add("LQG-100/5");
                comboBoxEdit2.Properties.Items.Add("LQG-150/5");
                comboBoxEdit2.Properties.Items.Add("LQG-200/5");
                comboBoxEdit2.Properties.Items.Add("LQG-300/5");
                comboBoxEdit2.Properties.Items.Add("LQG-400/5");
                comboBoxEdit2.Properties.Items.Add("LQG-500/5");

                comboBoxEdit2.Properties.Items.Add("LQG-600/5");
                comboBoxEdit2.Properties.Items.Add("LQG-750/5");
                comboBoxEdit2.Properties.Items.Add("LQG-800/5");
                comboBoxEdit2.Properties.Items.Add("DZ15L-40A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-63A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-100A");


                comboBoxEdit2.Properties.Items.Add("DZ15L-160A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-200A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-250A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-400A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-500A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-630A");
                comboBoxEdit2.Properties.Items.Add("DZ15L-1000A");
                comboBoxEdit2.Properties.Items.Add("HRT0-100/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-150/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-200/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-300/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-400/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-500/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-600/3");
                comboBoxEdit2.Properties.Items.Add("HRT0-1000/3");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-200A");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-400A");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-500A");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-600A");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-800A");
                comboBoxEdit2.Properties.Items.Add("DWJ5-500/380-1000A");
                comboBoxEdit2.Properties.Items.Add("HK1-30/3");


                comboBoxEdit2.Properties.Items.Add("HK1-50/3");
                comboBoxEdit2.Properties.Items.Add("HK1-75/3");
                comboBoxEdit2.Properties.Items.Add("2表");
                comboBoxEdit2.Properties.Items.Add("4表");
                comboBoxEdit2.Properties.Items.Add("6表");
                comboBoxEdit2.Properties.Items.Add("8表");
                comboBoxEdit2.Properties.Items.Add("9表");
                comboBoxEdit2.Properties.Items.Add("5A");


                comboBoxEdit2.Properties.Items.Add("10A");
                comboBoxEdit2.Properties.Items.Add("15A");
                comboBoxEdit2.Properties.Items.Add("20A");
                comboBoxEdit2.Properties.Items.Add("25A");
                comboBoxEdit2.Properties.Items.Add("30A");
                comboBoxEdit2.Properties.Items.Add("50A");
                comboBoxEdit2.Properties.Items.Add("100A");
                comboBoxEdit2.Properties.Items.Add("150A");


                comboBoxEdit2.Properties.Items.Add("200A");
                comboBoxEdit2.Properties.Items.Add("250A");
                comboBoxEdit2.Properties.Items.Add("300A");
                comboBoxEdit2.Properties.Items.Add("400A");
                comboBoxEdit2.Properties.Items.Add("600A");




            }

            comboBoxEdit3.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='工程材料出库单' and sx like '%{0}%' and nr!=''", "单位"));
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

         
          
           

            //comboBoxEdit4.Properties.Items.Clear();
            //for (int i = 1; i <= 500; i++)
            //{
            //    comboBoxEdit4.Properties.Items.Add(i);
                
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

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

       
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("工程材料出库单", "备注", memoEdit3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void frmCLCKEdit_Load(object sender, EventArgs e)
        {
            //labelTip.Text = "";
            //spinEdit1.Properties.MinValue = 0;
            //spinEdit1.Properties.Increment =1;
            comboBoxEdit2_TextChanged(sender, e);
            spinEdit2.Properties.MaxValue = Convert.ToDecimal(rowData.cksl);
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2_TextChanged(sender, e);
        }

        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxEdit1.Text != "" && comboBoxEdit3.Text != "")
            //{
            //    string strSQL= "select   sum(cast(wpsl as int))  from PJ_clcrkd  where 1=1 and wpmc='" + comboBoxEdit1.Text
            //        + "'  and wpgg='" + comboBoxEdit2.Text + "' and id!='"+rowData.ID+"' ";
            //    if (rowData.OrgName != "物流中心")
            //    {
            //        strSQL = strSQL + " and OrgName='" +rowData.OrgName+ "'";
            //    }
            //    IList li = MainHelper.PlatformSqlMap.GetList("SelectOneInt", strSQL
            //       );
            //    if (li.Count > 0 && li[0]!=null && li[0].ToString() != "")
            //    {
            //        spinEdit1.Properties.MaxValue = Convert.ToDecimal(li[0]);
            //    }
            //    else
            //    {
            //        spinEdit1.Properties.MaxValue = 0;
            //    }
            //    labelTip.Text = "当前规格物品" + comboBoxEdit1.Text + "最大库存:" + spinEdit1.Properties.MaxValue.ToString();
            //}
            //else
            //{
            //    labelTip.Text = "";
            //}
        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            long i = 0;
            rowData.zkcsl = (Convert.ToInt64(rowData.zkcsl) +Convert.ToInt64(spinEdit2.Value)
                - Convert.ToInt64(rowData.cksl)).ToString();
            comboBoxEdit10.Text = rowData.zkcsl;
            rowData.lasttime = DateTime.Now;  
        }

        

      

       

      

       
    }
}