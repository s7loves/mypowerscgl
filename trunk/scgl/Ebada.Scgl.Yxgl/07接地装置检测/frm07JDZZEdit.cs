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
    public partial class frm07JDZZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_07jdzz> m_CityDic = new SortableSearchableBindingList<PJ_07jdzz>();

        public frm07JDZZEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gth");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzwz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbmc");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xhgg");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jddz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tz");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "trdzr");

        }
        #region IPopupFormEdit Members
        private PJ_07jdzz rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_07jdzz>(value as PJ_07jdzz, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            IList<PJ_dyk> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "设备名称"));
            object[] yylist = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                yylist[i] = list[i].nr;
            }
            this.comboBoxEdit4.Properties.Items.AddRange(yylist);
            IList<PJ_dyk> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "变压器型号"));
            object[] yylist2 = new object[list2.Count];
            for (int i = 0; i < list2.Count; i++)
            {
                yylist2[i] = list2[i].nr;
            }
            this.comboBoxEdit5.Properties.Items.AddRange(yylist2);
            IList<PJ_dyk> list3 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "变压器规格"));
            object[] yylist3 = new object[list3.Count];
            for (int i = 0; i < list3.Count; i++)
            {
                yylist3[i] = list3[i].nr;
            }
            this.comboBoxEdit9.Properties.Items.AddRange(yylist3);
            IList<PJ_dyk> list4 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "接地电阻"));
            object[] yylist4 = new object[list4.Count];
            for (int i = 0; i < list4.Count; i++)
            {
                yylist4[i] = list4[i].nr;
            }
            this.comboBoxEdit6.Properties.Items.AddRange(yylist4);
            IList<PJ_dyk> list5 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "土质"));
            object[] yylist5 = new object[list5.Count];
            for (int i = 0; i < list5.Count; i++)
            {
                yylist5[i] = list5[i].nr;
            }
            this.comboBoxEdit7.Properties.Items.AddRange(yylist5);
            IList<PJ_dyk> list6 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "07接地装置检测记录", "土壤电阻率"));
            object[] yylist6 = new object[list6.Count];
            for (int i = 0; i < list6.Count; i++)
            {
                yylist6[i] = list6[i].nr;
            }
            this.comboBoxEdit8.Properties.Items.AddRange(yylist6);



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

        private void frm07JDZZEdit_Load(object sender, EventArgs e)
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
    }
}