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
namespace Ebada.Scgl.Yxgl {
    public partial class frmSD08JDZZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_07jdzz> m_CityDic = new SortableSearchableBindingList<sdjl_07jdzz>();

        #region 属性
        private string orgcode;
        public string OrgCode
        {
            get { return orgcode; }
            set 
            {
                if(value!=null)
                {
                    orgcode = value;
                }
            }
        }

        private string orgname;
        public string OrgName
        {
            get { return orgname; }
            set
            {
                if (value != null)
                {
                    orgname = value;
                }
            }
        }

        private string linecode;
        public string LineCode
        {
            get { return linecode; }
            set
            {
                if (value != null)
                {
                    linecode = value;

                }
            }
        }

        private string linename;
        public string LineName
        {
            get { return linename; }
            set
            {
                if (value != null)
                {
                    linename = value; 
                }
            }
        }
        #endregion
       

        public frmSD08JDZZEdit()
        {
            InitializeComponent();
           
        }
        void dataBind() {
            this.cmbgth.DataBindings.Add("EditValue", rowData, "gth");
            this.txtgtxs.DataBindings.Add("EditValue", rowData, "gzwz");
            this.txtjdxs.DataBindings.Add("EditValue", rowData, "sbmc");
            this.spejddz.DataBindings.Add("EditValue", rowData, "jddz");
            this.datejcrq.DataBindings.Add("EditValue", rowData, "CreateDate");
            this.spescz.DataBindings.Add("EditValue", rowData, "trdzr");
            this.spehsz.DataBindings.Add("EditValue", rowData, "tz");
            this.txtjcqk.DataBindings.Add("EditValue", rowData, "xhgg");
            this.cmbjl.DataBindings.Add("EditValue", rowData, "fzxl");
            this.cmbjcr.DataBindings.Add("EditValue", rowData, "CreateMan");
        }
        #region IPopupFormEdit Members
        private sdjl_07jdzz rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjl_07jdzz>(value as sdjl_07jdzz, rowData);
                    
                }
                
            }
        }

        #endregion

       
        private void InitComboBoxData() {
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from sd_gt where   LineCode='{0}' ", rowData.LineID));
            cmbgth.Properties.Items.AddRange(list);

            this.cmbjl.Properties.Items.AddRange(new string[] { "合格", "不合格" });

            this.cmbjcr.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(rowData.OrgCode));
            ComboBoxHelper.FillCBoxByDyk("送电接地装置检测记录", "检测情况", txtjcqk);
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
        private void btnOK_Click(object sender, EventArgs e) {
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbgth_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbgth.EditValue as string))
                return;
            string gth = this.cmbgth.EditValue as string;
            sd_gt gt= Client.ClientHelper.PlatformSqlMap.GetOne<sd_gt>("where gth='"+gth+"'");
            if (gt == null)
                return;
            this.txtgtxs.EditValue = gt.gtModle;
            rowData.gzwz = gt.gtModle;
            this.txtjdxs.EditValue = gt.c2;
            rowData.sbmc = gt.c2;
        }

        private void spescz_TextChanged(object sender, EventArgs e)
        {
            double[] dcoe = { 1.05, 1.05, 1, 1.6, 1.9, 2, 2.2, 2.55, 1.6, 1.55, 1.55, 1.35 };
            if (datejcrq.Text == "") return;
            DateTime dt = Convert.ToDateTime(datejcrq.Text);
            string dx = "07接地装置检测记录";
            string sx = "季节系数";
            string nr = dt.Month.ToString();
            double dtemp = dcoe[dt.Month - 1], d1 = 0;
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from PJ_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}月' ", dx, sx, nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dtemp = Convert.ToDouble(list[0]);
            }
            if (spescz.Text != "")
            {
                d1 = Convert.ToDouble(spescz.Text);
            }
            rowData.tz = (d1 * dtemp).ToString();
            spehsz.Text = rowData.tz;

        }
    }
}