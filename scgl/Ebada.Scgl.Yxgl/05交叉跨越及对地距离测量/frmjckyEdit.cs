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
    public partial class frmjckyEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_05jcky> m_CityDic = new SortableSearchableBindingList<PJ_05jcky>();

        public frmjckyEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gtID");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kywz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "kygh");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "kymc");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "ssdw");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "jb");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "gdjl");

        }
        #region IPopupFormEdit Members
        private PJ_05jcky rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_05jcky;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_05jcky>(value as PJ_05jcky, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
         
            IList<PJ_dyk> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "05交叉跨越及对地距离测量记录", "规 定 距 离 不小于(m)"));
            object[] yylist = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                yylist[i] = list[i].nr;
            }
            this.spinEdit1.Properties.Items.AddRange(yylist);
            IList<PJ_dyk> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "05交叉跨越及对地距离测量记录", "被跨越物名称"));
            object[] yylist2 = new object[list2.Count];
            for (int i = 0; i < list2.Count; i++)
            {
                yylist2[i] = list2[i].nr;
            }
            this.comboBoxEdit5.Properties.Items.AddRange(yylist2);
            IList<PJ_dyk> list3 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "05交叉跨越及对地距离测量记录", "所属单位"));
            object[] yylist3 = new object[list3.Count];
            for (int i = 0; i < list3.Count; i++)
            {
                yylist3[i] = list3[i].nr;
            }
            this.comboBoxEdit6.Properties.Items.AddRange(yylist3);
            IList<PJ_dyk> list4 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid!=''", "05交叉跨越及对地距离测量记录", "级别"));
            object[] yylist4 = new object[list4.Count];
            for (int i = 0; i < list4.Count; i++)
            {
                yylist4[i] = list4[i].nr;
            }
            this.comboBoxEdit7.Properties.Items.AddRange(yylist4);



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
    }
}