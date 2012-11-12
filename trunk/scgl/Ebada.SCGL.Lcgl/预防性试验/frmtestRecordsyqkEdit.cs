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
    public partial class frmtestRecordsyqkEdit : FormBase, IPopupFormEdit {
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
        public frmtestRecordsyqkEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "sbInstallAdress");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbCapacity");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "syPeriod");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "syjg");
            //this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "iswc");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "syProject");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "planExpTime");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "sjExpTime");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "charMan");
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
             this.combLine.DataBindings.Add("EditValue", rowData, "xlid");
            this.combTq.DataBindings.Add("EditValue", rowData, "tqid");
            this.combByq.DataBindings.Add("EditValue", rowData, "byqid");
            this.combKg.DataBindings.Add("EditValue", rowData, "kgid");
        
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_yfsyjl rowData = null;

        public object RowData {
            get {
               
                rowData.xlname = combLine.Text;
                rowData.tqname = combTq.Text;
                rowData.byqname = combByq.Text;
                rowData.kgname = combKg.Text;
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_yfsyjl;
                    rowData.type = _type; 
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_yfsyjl>(value as PJ_yfsyjl, rowData);
                }
                switch (rowData.type)
                {
                    case "避雷器":
                        comboBoxEdit9.Properties.Items.Clear();
                        comboBoxEdit9.Properties.Items.Add("合格");
                        comboBoxEdit9.Properties.Items.Add("绝缘阻值低于2000兆欧");
                        comboBoxEdit9.Properties.Items.Add("绝缘阻值低于1000兆欧");
                        break;
                    case "变压器":
                    case "断路器":
                    case "电容器":
                        comboBoxEdit9.Properties.Items.Clear();
                        comboBoxEdit9.Properties.Items.Add("合格");
                        comboBoxEdit9.Properties.Items.Add("不合格");
                        break;
                        break;



                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            comboBoxEdit5.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备安装位置", comboBoxEdit5);
            comboBoxEdit1.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备型号", comboBoxEdit1);
            comboBoxEdit3.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验周期", comboBoxEdit3);
            comboBoxEdit4.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "容量", comboBoxEdit4);
            comboBoxEdit6.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "落实人", comboBoxEdit6);
            comboBoxEdit7.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit7);
            comboBoxEdit8.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit8);
            comboBoxEdit9.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "实验结果", comboBoxEdit9);
            comboBoxEdit10.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "是否完成", comboBoxEdit10);

            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + rowData.gdstemp + "'and linevol='10'");
            combLine.Properties.Items.Clear();
            for (int i = 0; i < xlList.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = xlList[i].LineName;
                ot.ValueMember = xlList[i].LineCode;
                combLine.Properties.Items.Add(ot);
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

      
      

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {
            string str = rowData.syMan;
            string[] mans = str.Split(new char[1] { ' ' });
            if (mans.Length >= 2)
            {
                comboBoxEdit7.Text = mans[0];
                comboBoxEdit8.Text = mans[1];
            }
        }

      

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (comboBoxEdit7.Text!="")
                rowData.syMan = comboBoxEdit7.Text;
            if (rowData.syMan != "" && comboBoxEdit8.Text!="")
                rowData.syMan += " "+comboBoxEdit8.Text;
            else if (rowData.syMan == "")
                rowData.syMan =  comboBoxEdit8.Text;
        }

        private void ReSetSelectValue()
        {
            string xlcode = string.Empty;
            if (combLine.EditValue != null)
            {
                xlcode = combLine.EditValue.ToString();
            }
            if (xlcode.Length == 6)
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode='{0}' ", xlcode));
                combTq.Properties.Items.Clear();
                for (int i = 0; i < xlList.Count; i++)
                {
                    ListItem ot = new ListItem();
                    ot.DisplayMember = xlList[i].tqName;
                    ot.ValueMember = xlList[i].tqCode;
                    combTq.Properties.Items.Add(ot);
                }
            }
            else
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode2='{0}' ", xlcode));
                combTq.Properties.Items.Clear();
                for (int i = 0; i < xlList.Count; i++)
                {
                    ListItem ot = new ListItem();
                    ot.DisplayMember = xlList[i].tqName;
                    ot.ValueMember = xlList[i].tqCode;
                    combTq.Properties.Items.Add(ot);
                }
            }

            IList<PS_tqbyq> byqlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tqbyq>(string.Format("where   left(byqcode,3)='{0}' ", rowData.gdstemp));
            combByq.Properties.Items.Clear();
            for (int i = 0; i < byqlist.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = byqlist[i].byqName;
                ot.ValueMember = byqlist[i].byqCode;
                combByq.Properties.Items.Add(ot);
            }



            IList<PS_kg> kglist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_kg>(string.Format("where gtID in ( SELECT gtID FROM ps_gt WHERE lineCode='{0}' ", xlcode));
            combKg.Properties.Items.Clear();
            for (int i = 0; i < kglist.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = kglist[i].kgName;
                ot.ValueMember = kglist[i].kgCode;
                combKg.Properties.Items.Add(ot);
            }

        }

        private void combLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReSetSelectValue();

        }

      
    }
}