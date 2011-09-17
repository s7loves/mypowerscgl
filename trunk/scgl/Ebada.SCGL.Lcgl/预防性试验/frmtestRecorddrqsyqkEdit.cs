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
    public partial class frmtestRecorddrqsyqkEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_yfsyjl> m_CityDic = new SortableSearchableBindingList<PJ_yfsyjl>();

        private string _type = null;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;

            }
        }
        public frmtestRecorddrqsyqkEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "sbInstallAdress");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbCapacity");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "syPeriod");
            //this.comboBoxEdit7.DataBindings.Add("EditValue", rowData2, "syPeriod");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "syProject");
            //this.memoEdit3.DataBindings.Add("EditValue", rowData2, "syProject");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "planExpTime");
            //this.dateEdit4.DataBindings.Add("EditValue", rowData2, "preExpTime");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "sjExpTime");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData2, "planExpTime");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "charMan");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "charMan");
            //this.comboBoxEdit9.DataBindings.Add("EditValue", rowData2, "charMan");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "syjg");
            //this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "iswc");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");
            switch (rowData.type )
            {
                case "变压器":
                    labelControl3.Visible = true;
                    comboBoxEdit4.Visible = true;
                    break;
                case "避雷器":
                case "断路器":
                case "电容器":
                    labelControl8.Visible = true;
                    comboBoxEdit2.Visible = true;
                    labelControl8.Visible = true;
                    comboBoxEdit2.Visible = true;
                    break;


            
            }
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_yfsyjl rowData = null;
        private PJ_yfsyjl rowData2 = null;
        public object RowData {
            get {
                return rowData;
            }
            set {
                
                if (value == null) return;
                
                if (rowData == null) {
                    this.rowData = value as PJ_yfsyjl;
                    IList<PJ_yfsyjl> li = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", "where xh='" + rowData.xh + "'and type ='" + rowData.type + "' order by CreateDate");
                    if (li.Count == 2)
                    {
                        rowData2 = new PJ_yfsyjl();
                        ConvertHelper.CopyTo<PJ_yfsyjl>(li[0], this.rowData);
                        ConvertHelper.CopyTo<PJ_yfsyjl>(li[1], rowData2);

                    }
                    else
                    {
                        rowData2 = new PJ_yfsyjl();
                        ConvertHelper.CopyTo<PJ_yfsyjl>(this.rowData, rowData2);
                        rowData2.ID = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                        rowData2.type = rowData.type;
                    }
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_yfsyjl>(value as PJ_yfsyjl, rowData);
                    IList<PJ_yfsyjl> li = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", "where xh='" + rowData.xh + "'and type ='" + rowData.type + "' order by CreateDate");
                    if (li.Count == 2)
                    {
                        ConvertHelper.CopyTo<PJ_yfsyjl>(li[0], this.rowData);
                        ConvertHelper.CopyTo<PJ_yfsyjl>(li[1], rowData2);

                    }
                    else
                    {

                        ConvertHelper.CopyTo<PJ_yfsyjl>(this.rowData, rowData2);
                        rowData2.ID = DateTime.Now.ToString("yyyyMMddHHmmssffffff");                      
                    }
                }
                comboBoxEdit7.Text=rowData2.syPeriod;
                memoEdit3.Text=rowData2.syProject;
                comboBoxEdit9.Text=rowData2.charMan;

               
                dateEdit1.EditValue = rowData2.sjExpTime;
                dateEdit4.EditValue = rowData2.planExpTime;

                //comboBoxEdit14.Text = rowData2.iswc;
                comboBoxEdit13.Text = rowData2.syjg; 

            }
        }

        #endregion

        private void InitComboBoxData()
        {
            comboBoxEdit5.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备安装位置", comboBoxEdit5);
            comboBoxEdit1.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备型号", comboBoxEdit1);
            comboBoxEdit3.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验周期", comboBoxEdit3);
            comboBoxEdit7.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验周期", comboBoxEdit7);
            comboBoxEdit4.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "容量", comboBoxEdit4);
            comboBoxEdit6.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "落实人", comboBoxEdit6);
            comboBoxEdit9.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "落实人", comboBoxEdit9);
            comboBoxEdit8.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit8);
            comboBoxEdit10.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit10);
            comboBoxEdit12.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "实验结果", comboBoxEdit12);
            comboBoxEdit13.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "实验结果", comboBoxEdit13);
            comboBoxEdit11.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "是否完成", comboBoxEdit11);
            comboBoxEdit14.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "是否完成", comboBoxEdit14);
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


        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {
            InitComboBoxData();
            string str = rowData.syMan;
            string[] mans = str.Split(new char[1] { ' ' });
            if (mans.Length >= 2)
            {
                comboBoxEdit8.Text = mans[0];
                comboBoxEdit15.Text = mans[1];
            }
            str = rowData2.syMan;
            mans = str.Split(new char[1] { ' ' });
            if (mans.Length >= 2)
            {
                comboBoxEdit10.Text = mans[0];
                comboBoxEdit16.Text = mans[1];
            }
        }

       

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("预防性试验", "试验项目", memoEdit2);
            rowData.syProject = memoEdit2.EditValue.ToString();  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rowData2.sbInstallAdress = rowData.sbInstallAdress;
            rowData2.sl = rowData.sl;
            rowData2.sbModle = rowData.sbModle;
            rowData2.Remark = rowData.Remark;
            rowData2.syPeriod = comboBoxEdit7.Text ;
            rowData2.syProject = memoEdit3.Text;
            rowData2.planExpTime = Convert.ToDateTime(dateEdit4.Text);
            rowData2.sjExpTime  = Convert.ToDateTime(dateEdit1.Text);
            rowData2.charMan = comboBoxEdit9.Text;
            rowData2.syjg  = comboBoxEdit13.Text;

            if (comboBoxEdit8.Text != "")
                rowData.syMan = comboBoxEdit8.Text;
            if (rowData.syMan != "" && comboBoxEdit15.Text != "")
                rowData.syMan += " " + comboBoxEdit15.Text;
            else if (rowData.syMan == "")
                rowData.syMan = comboBoxEdit15.Text;

            if (comboBoxEdit10.Text != "")
                rowData2.syMan = comboBoxEdit10.Text;
            if (rowData2.syMan != "" && comboBoxEdit16.Text != "")
                rowData2.syMan += " " + comboBoxEdit16.Text;
            else if (rowData2.syMan == "")
                rowData2.syMan = comboBoxEdit16.Text;

            PJ_yfsyjl ob = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_yfsyjl>(rowData2.ID);
            if (ob == null)
            {
                //IList caplist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", 
                IList li  = MainHelper.PlatformSqlMap.GetList("SelectOneInt", " select distinct xh from PJ_yfsyjl where  OrgCode='" + rowData2.OrgCode + "' and  type='" + rowData2.type + "'");
                rowData2.xh = li.Count+1;
                rowData.xh = rowData2.xh;
                rowData.CreateDate = DateTime.Now;
                rowData2.CreateDate = rowData.CreateDate.AddSeconds(1) ;
                if (rowData.ID == rowData2.ID)
                {

                    rowData2.ID = DateTime.Now.AddMilliseconds(1).ToString("yyyyMMddHHmmssffffff");
                }
                Client.ClientHelper.PlatformSqlMap.Create<PJ_yfsyjl>(rowData2);

            }
            else
            {
                Client.ClientHelper.PlatformSqlMap.Update<PJ_yfsyjl>(rowData2);

            
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("预防性试验", "试验项目", memoEdit3);
            rowData2.syProject = memoEdit3.EditValue.ToString();  
        }

       
     

       
      
    }
}