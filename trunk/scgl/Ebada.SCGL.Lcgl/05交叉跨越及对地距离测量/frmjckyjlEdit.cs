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
    public partial class frmjckyjlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_05jckyjl> m_CityDic = new SortableSearchableBindingList<PJ_05jckyjl>();

        public frmjckyjlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "clrq");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "scz",false, DataSourceUpdateMode.OnValidation);
            this.textEdit1.DataBindings.Add("EditValue", rowData, "qw");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "clrqz");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "jr");

            this.combLine.DataBindings.Add("EditValue", rowData, "xlid");
            this.combTq.DataBindings.Add("EditValue", rowData, "tqid");
            this.combByq.DataBindings.Add("EditValue", rowData, "byqid");
            this.combKg.DataBindings.Add("EditValue", rowData, "kgid");
        }
        #region IPopupFormEdit Members
        private PJ_05jckyjl rowData = null;

        public object RowData {
            get {
                getqqry();

                rowData.xlname = combLine.Text;
                rowData.tqname = combTq.Text;
                rowData.byqname = combByq.Text;
                rowData.kgname = combKg.Text;

                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_05jckyjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_05jckyjl>(value as PJ_05jckyjl, rowData);
                }
                setqqry();
                if (rowData.jr == "")
                {
                    rowData.clrq = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "结论", comboBoxEdit2);

            PJ_05jcky pj= Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_05jcky>(rowData.jckyID);
            this.comboBoxEdit1.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));
            this.comboBoxEdit3.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(pj.OrgCode));

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
        void setqqry()
        {
            string str = rowData.clrqz;
            comboBoxEdit1.EditValue = "";
            comboBoxEdit3.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit1.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit3.EditValue = mans[1];
            }

           
        }
        void getqqry()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit1.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit3.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.clrqz = str;
            
           
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
            if (comboBoxEdit2.Text == "")
            {
                MsgBox.ShowTipMessageBox("结论不能为空。");
                comboBoxEdit2.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
        private void ReSetSelectValue()
        {
            string xlcode=string.Empty;
            if (combLine.EditValue!=null)
            {
                xlcode=combLine.EditValue.ToString();
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



            IList<PS_kg> kglist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_kg>(string.Format("where gtID in ( SELECT gtID FROM ps_gt WHERE lineCode='{0}' ",xlcode));
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