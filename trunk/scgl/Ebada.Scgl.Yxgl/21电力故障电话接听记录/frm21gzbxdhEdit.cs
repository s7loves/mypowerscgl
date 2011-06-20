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
namespace Ebada.Scgl.Yxgl
{
    public partial class frm21gzbxdhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_21gzbxdh> m_CityDic = new SortableSearchableBindingList<PJ_21gzbxdh>();

        public frm21gzbxdhEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            this.textEdit1.DataBindings.Add("EditValue", rowData, "yhdz");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "gzjk");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "djr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "clr");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "lxfs");
            
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_21gzbxdh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_21gzbxdh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_21gzbxdh>(value as PJ_21gzbxdh, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_21gzbxdh>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;

            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            if (ryList.Count > 0)
            {
                this.comboBoxEdit3.Properties.Items.AddRange(ryList);
                this.comboBoxEdit4.Properties.Items.AddRange(ryList);
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

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit6_Properties_Click(object sender, EventArgs e)
        {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='21电力故障电话接听记录' and sx='故障简况' and parentid=''");
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBoxEdit6.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }


            }
        }
    }
}