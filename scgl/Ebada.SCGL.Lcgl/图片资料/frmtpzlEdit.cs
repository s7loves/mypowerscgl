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
    public partial class frmtpzlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_tbsj> m_CityDic = new SortableSearchableBindingList<PJ_tbsj>();

        public frmtpzlEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "picName");
            
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_tbsj rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_tbsj;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_tbsj>(value as PJ_tbsj, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='图片资料' and sx like '%{0}%' and nr!=''", "图片名称"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {




                
              

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //string parentid ="";
            //IList<mModule> mli = MainHelper.PlatformSqlMap.GetList<mModule>(" where ModuName like  '%仓储管理%' and ModuTypes!='hide' order by Modu_ID ");
            //foreach (mModule md in mli)
            //{
            //    mModule mdtem = new mModule();
            //    ConvertHelper.CopyTo<mModule>(md, mdtem);
            //    mdtem.Modu_ID = mdtem.CreateID();
            //    parentid = mdtem.Modu_ID;
            //    mdtem.ModuName = "物流中心仓储管理";
            //    MainHelper.PlatformSqlMap.Create<mModule>(mdtem);
            //}

            //mli = MainHelper.PlatformSqlMap.GetList<mModule>(" where  parentid='" + mli[0].Modu_ID + "'");
            //foreach (mModule md in mli)
            //{
            //    mModule mdtem = new mModule();
            //    ConvertHelper.CopyTo<mModule>(md, mdtem);
            //    mdtem.Modu_ID = mdtem.CreateID();
            //    mdtem.ModuName = "物流中心" + mdtem.ModuName;
            //    mdtem.ParentID = parentid;
            //    MainHelper.PlatformSqlMap.Create<mModule>(mdtem);
            //    IList<mModule> mli2 = MainHelper.PlatformSqlMap.GetList<mModule>(" where parentid='" + md.Modu_ID + "'");
            //    foreach (mModule md2 in mli2)
            //    {
            //        mModule mdtem2 = new mModule();
            //        ConvertHelper.CopyTo<mModule>(md2, mdtem2);
            //        mdtem2.Modu_ID = mdtem2.CreateID();
            //        mdtem2.ParentID = md.Modu_ID;
            //        mdtem2.ModuName = "物流中心" + mdtem2.ModuName;
            //        mdtem2.ModuTypes = mdtem2.ModuTypes.Replace("WG", "");
            //        mdtem2.ParentID = "";
            //        MainHelper.PlatformSqlMap.Create<mModule>(mdtem2);


            //    }
            //}
            openFileDialog1.Filter = "常见图片文件(*.bmp,*.jpg,*.ico,*.png)|*.bmp;*.jpg;*.ico;*.png|bmp文件(*.bmp)|*.bmp|jpg文件(*.jpg)|*.jpg|ico文件(*.ico)|*.ico|png文件(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = openFileDialog1.FileName;
                rowData.picImage = Ecommon.GetImageBate(openFileDialog1.FileName);
                string[] str_name =  buttonEdit1.Text.Split("\\".ToCharArray());
                string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
                byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
                string Exc = System.Text.Encoding.Default.GetString(Excbyte);
                rowData.S1 ="."+ Exc;
            }
        }

      
    }
}