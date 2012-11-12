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
    public partial class frm07JDZZJlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_07jdzzjl> m_CityDic = new SortableSearchableBindingList<PJ_07jdzzjl>();

        public frm07JDZZJlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "clrq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tq");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "scz");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "hsz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "jcqk");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jr");
           // this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "jcr");

            this.combLine.DataBindings.Add("EditValue", rowData, "xlid");
            this.combTq.DataBindings.Add("EditValue", rowData, "tqid");
            this.combByq.DataBindings.Add("EditValue", rowData, "byqid");
            this.combKg.DataBindings.Add("EditValue", rowData, "kgid");

        }
        #region IPopupFormEdit Members
        private PJ_07jdzzjl rowData = null;

        public object RowData {
            get {
                getxsr();
                rowData.xlname = combLine.Text;
                rowData.tqname = combTq.Text;
                rowData.byqname = combByq.Text;
                rowData.kgname = combKg.Text;
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_07jdzzjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_07jdzzjl>(value as PJ_07jdzzjl, rowData);
                }
                if (rowData.jr == "")
                {
                    rowData.clrq = DateTime.Now;
                }
                setxsr();
            }
        }

        #endregion
        void setxsr()
        {
            string str = rowData.jcr;
            comboBoxEdit2.EditValue = "";
           comboBoxEdit7.EditValue = "";

           string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
           if (mans.Length >= 1)
           {
               comboBoxEdit2.EditValue = mans[0];
           }
           if (mans.Length >= 2)
           {
               comboBoxEdit7.EditValue = mans[1];
           }
        }
        void getxsr()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit2.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit7.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.jcr = str;
        }
        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "天气", comboBoxEdit1);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "检查情况", comboBoxEdit4);
            //ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "结论", comboBoxEdit6);
            PJ_07jdzz pj = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_07jdzz>(rowData.jdzzID);
            this.comboBoxEdit2.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));
            this.comboBoxEdit7.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm07JDZZJlEdit_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (comboBoxEdit6.Text == "")
            {
                MsgBox.ShowTipMessageBox("结论不能为空。");
                comboBoxEdit6.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

      

      

        

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit5_TextChanged(sender, e);
        }

        private void comboBoxEdit5_TextChanged(object sender, EventArgs e)
        {
            
                double[] dcoe = { 1.05, 1.05, 1, 1.6, 1.9, 2, 2.2, 2.55, 1.6, 1.55, 1.55, 1.35 };
                if (dateEdit1.Text == "") return;
                DateTime dt = Convert.ToDateTime(dateEdit1.Text);
                string dx = "07接地装置检测记录";
                string sx = "季节系数";
                string nr = dt.Month.ToString();
                double dtemp = dcoe[dt.Month - 1], d1 = 0;
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}月' ", dx, sx, nr));
                if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
                {
                    dtemp = Convert.ToDouble(list[0]);
                }
                if (comboBoxEdit5.Text != "")
                {
                    d1 = Convert.ToDouble(comboBoxEdit5.Text);
                }
                else
                {

                }
                rowData.hsz = Convert.ToDecimal(d1 * dtemp);
                comboBoxEdit3.Text = rowData.hsz.ToString();
            
         
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