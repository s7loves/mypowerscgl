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
using Ebada.Scgl.Sbgl;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmtestRecordsyqkEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_yfsyjl> m_CityDic = new SortableSearchableBindingList<PJ_yfsyjl>();
        UCPopupLine popLine = new UCPopupLine();

        UCPopupLine popByq = new UCPopupLine();
        UCPopupLine popTq = new UCPopupLine();
        UCPopupLine popKg = new UCPopupLine();

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
           

            popLine.Bounds = lkueLine.Bounds;
            lkueLine.Hide();
            popLine.Parent = lkueLine.Parent;

            this.popLine.DataBindings.Add("EditValue", rowData, "xlid");
            //this.popLine.DisplayField = "mc";
            //this.popLine.ValueField = "bh";
            //this.popLine.DataSource = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh");
            this.popLine.EditValueChanged += lkueLine_EditValueChanged;

            popTq.Bounds = lkueTq.Bounds;
            lkueTq.Hide();
            popTq.Parent = lkueTq.Parent;

            this.popTq.DataBindings.Add("EditValue", rowData, "tqid");
            this.popTq.DisplayField = "tqName";
            this.popTq.ValueField = "tqID";

            popByq.Bounds = lkueByq.Bounds;
            lkueByq.Hide();
            popByq.Parent = lkueByq.Parent;

            this.popByq.DataBindings.Add("EditValue", rowData, "byqid");
            this.popByq.DisplayField = "byqName";
            this.popByq.ValueField = "byqID";


            popKg.Bounds = lkueKg.Bounds;
            lkueKg.Hide();
            popKg.Parent = lkueKg.Parent;

            this.popKg.DataBindings.Add("EditValue", rowData, "kgid");
            this.popKg.DisplayField = "kgName";
            this.popKg.ValueField = "kgID";

        }
        #region IPopupFormEdit Members
        private PJ_yfsyjl rowData = null;

        public object RowData {
            get {

                rowData.xlname = popLine.Text;
                rowData.tqname = popTq.Text;
                rowData.byqname = popByq.Text;
                rowData.kgname = popKg.Text;
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

            //comboBoxEdit5.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备安装位置", comboBoxEdit5);
            //comboBoxEdit1.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备型号", comboBoxEdit1);
            //comboBoxEdit3.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验周期", comboBoxEdit3);
            //comboBoxEdit4.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "容量", comboBoxEdit4);
            //comboBoxEdit6.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "落实人", comboBoxEdit6);
            //comboBoxEdit7.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit7);
            //comboBoxEdit8.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验人", comboBoxEdit8);
            //comboBoxEdit9.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "实验结果", comboBoxEdit9);
            //comboBoxEdit10.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "是否完成", comboBoxEdit10);

            //popLine.Properties.PopupFormSize = new Size(popLine.Properties.PopupFormSize.Width, 200);

            //popByq.Properties.PopupFormSize = new Size(popByq.Properties.PopupFormSize.Width, 200);
            //popTq.Properties.PopupFormSize = new Size(popTq.Properties.PopupFormSize.Width, 200);
            //popKg.Properties.PopupFormSize = new Size(popKg.Properties.PopupFormSize.Width, 200);


            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + rowData.gdstemp + "'and linevol='10'");
            if (xlList.Count > 0)
            {
                this.popLine.DataSource = xlList;
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
            if (popLine.EditValue != null)
            {
                if (popLine.GetDataRow() != null)
                {
                    xlcode = popLine.GetDataRow()["LineCode"].ToString();
                  //popLine.DataSource = xlcode;   //ZJM
                }


            }
            if (xlcode.Length == 6)
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode='{0}' ", xlcode));
                if (xlList.Count != 0)
                {
                    popTq.DataSource = xlList;
                }

            }
            else
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode2='{0}' ", xlcode));

                if (xlList.Count != 0)
                {
                    popTq.DataSource = xlList;
                }
            }

            IList<PS_tqbyq> byqlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tqbyq>(string.Format("where   left(byqcode,3)='{0}' ", rowData.gdstemp));
            if (byqlist.Count != 0)
            {
                popByq.DataSource = byqlist;
            }


            IList<PS_kg> kglist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_kg>(string.Format("where gtID in ( SELECT gtID FROM ps_gt WHERE lineCode='{0}') ", xlcode));
            if (kglist.Count != 0)
            {
                popKg.DataSource = kglist;
            }
        }

       
        private void lkueLine_EditValueChanged(object sender, EventArgs e)
        {
            ReSetSelectValue();
        }

      
    }
}