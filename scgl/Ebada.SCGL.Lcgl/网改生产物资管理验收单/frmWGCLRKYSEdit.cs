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
    public partial class frmWGCLRKYSEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_wgclrkysd> m_CityDic = new SortableSearchableBindingList<PJ_wgclrkysd>();

        public frmWGCLRKYSEdit()
        {
            InitializeComponent();
        }
        void dataBind() {
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "wpdw");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "fpbh");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "dhht");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "ysr");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "wpsl");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "htjg");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "xmtz");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "yfk");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "wpdj");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "ssxm");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "ghdw");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "ssgc");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "jsfzr");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "xmdw");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "zgjz");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "scbh");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "indate");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "czwt");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "Remark");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "jcjg");
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "cljg");
           

        }
        #region IPopupFormEdit Members
        private PJ_wgclrkysd rowData = null;

        public object RowData {
            get {
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_wgclrkysd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_wgclrkysd>(value as PJ_wgclrkysd, rowData);
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
            string.Format("select nr from pj_dyk where  dx='工程材料验收单' and sx like '%{0}%' and nr!=''", "材料名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select distinct mc from PS_sbcs"));
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
            }

            comboBoxEdit2.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='工程材料验收单' and sx like '%{0}%' and nr!=''", "材料规格"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                 strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select distinct xh from PS_sbcs where xh is not null "));
                 if (strlist.Count > 0)
                     comboBoxEdit2.Properties.Items.AddRange(strlist);
                 else
                 {
                     

                 }


            }

            comboBoxEdit3.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='工程材料验收单' and sx like '%{0}%' and nr!=''", "单位"));
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

         
          
           


            comboBoxEdit6.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='工程材料验收单' and sx like '%{0}%' and nr!=''", "厂家"));
            if (strlist.Count > 0)
                comboBoxEdit6.Properties.Items.AddRange(strlist);




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

      
       
        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit6.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ghdw  from PJ_wgclrkysd where 1=1 and wpgg='" + comboBoxEdit2.Text + "' and wpmc='" + comboBoxEdit1.Text + "'");
            comboBoxEdit6.Properties.Items.AddRange(mclist);

         
        }

        private void comboBoxEdit7_TextChanged(object sender, EventArgs e)
        {
            
            comboBoxEdit5.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", 
                "select distinct ssxm  from PJ_wgclrkysd where 1=1 and ssgc='"+comboBoxEdit7.Text+ "' and ssxm!='' ");
            comboBoxEdit5.Properties.Items.AddRange(mclist);
        }

        private void frmCLRKEdit_Load(object sender, EventArgs e)
        {
            PJ_wgclrkysd obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_wgclrkysd>(rowData.ID);
            if (obj == null)
            {
                btnOK.Visible = false; 
                simpleButton4.Visible = true; 
            }
            else
            {
                btnOK.Visible = true; 
                simpleButton4.Visible = false;
            }
            comboBoxEdit7.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_wgclrkysd where 1=1");
            comboBoxEdit7.Properties.Items.AddRange(mclist);

            comboBoxEdit11.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xmdw  from PJ_wgclrkysd where 1=1");
            comboBoxEdit11.Properties.Items.AddRange(mclist);

            comboBoxEdit6.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ghdw  from PJ_wgclrkysd where 1=1");
            comboBoxEdit6.Properties.Items.AddRange(mclist);

            comboBoxEdit9.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ysr  from PJ_wgclrkysd where 1=1");
            comboBoxEdit9.Properties.Items.AddRange(mclist);

            comboBoxEdit10.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct jsfzr  from PJ_wgclrkysd where 1=1");
            comboBoxEdit10.Properties.Items.AddRange(mclist);

            comboBoxEdit12.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct zgjz  from PJ_wgclrkysd where 1=1");
            comboBoxEdit12.Properties.Items.AddRange(mclist);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            SelectorHelper.SelectDyk("工程材料验收单", "存在问题", memoEdit3);
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("工程材料验收单", "处理结果", memoEdit3);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            SelectorHelper.SelectDyk("工程材料验收单", "备注", memoEdit3);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (spinEdit2.Value == 0) {
                MsgBox.ShowTipMessageBox("物品数量不能为0!");
                return;
            }
            rowData.ID = rowData.CreateID();
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            Client.ClientHelper.PlatformSqlMap.Create<PJ_wgclrkysd>(rowData);
            MsgBox.ShowTipMessageBox("添加成功!");
            rowData.ID = rowData.CreateID();
            rowData.wpsl = "0";
            spinEdit2.Value   = 0;
        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit1_EditValueChanged(sender,e);
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            double i1 = 0;
            double i2 = 0;
            i1 = Convert.ToDouble(spinEdit1.Value);
            i2 = Convert.ToDouble(spinEdit2.Value);
            spinEdit3.Value = Convert.ToDecimal(i1 * i2);
            spinEdit4.Value = Convert.ToDecimal(Convert.ToDouble(spinEdit3.Value) * 0.9);
            rowData.htjg = spinEdit3.Value.ToString();
            rowData.yfk = spinEdit4.Value.ToString();
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh  from PS_sbcs where   mc='" + comboBoxEdit1.Text + "' and xh is not null ");
            if (mclist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(mclist);
            else
            {
                mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct nr  from pj_dyk where   sx='" + comboBoxEdit1.Text + "' ");
                if (mclist.Count > 0)
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                else
                {
                    mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_wgclcrkd where  wpmc='" + comboBoxEdit1.Text + "' and ssxm!='' ");
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                }
            }
        }

       

       
      
        
    

      

       

      

       
    }
}