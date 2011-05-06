using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Platform.Model;
using Ebada.Client.Platform.Dictionary;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;

namespace Ebada.Modules.Demo
{
    public partial class frmEmpolyeesEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<mPost> m_PostDic = new SortableSearchableBindingList<mPost>();
        private string m_PostID = string.Empty;

        public string PostID
        {
            set { this.m_PostID = value; }
            get 
            {
                object ID = this.cltPost.Properties.KeyValue;

                if (null != ID && ID.ToString().Trim() != "" && ID.ToString().Trim().Length > 0)
                    this.m_PostID = this.cltPost.Properties.KeyValue.ToString();

                return this.m_PostID;
            }
        }

        public frmEmpolyeesEdit()
        {
            InitializeComponent();

            this.btnPostDic.Click += new EventHandler(btnPostDic_Click);
        }

        Empolyees GetEmpolyeesData()
        {
            Empolyees empolyees = this.m_Empolyees;
            empolyees.User_ID = this.txtUser_ID.Text;
            empolyees.Password = this.txtPassword.Text;
            empolyees.Tel = this.txtTel.Text;
            empolyees.Empolyee_Name = this.txtEmpolyee_Name.Text;
            empolyees.Enabled = this.ckEnabled.Checked ? "1" : "0";
            empolyees.alias = this.txtAlias.Text;
            empolyees.Fax = this.txtFax.Text;
            empolyees.Email = this.txtEmail.Text;
            empolyees.Remark = this.txtRemark.Text;

            return empolyees;
        }

        void SetEmpolyeesData(Empolyees empolyees)
        {
            this.m_Empolyees = empolyees;
            this.InitComboBoxData();

            this.txtUser_ID.Text = empolyees.User_ID;
            this.txtPassword.Text = empolyees.Password;
            this.txtTel.Text = empolyees.Tel;
            this.txtEmpolyee_Name.Text = empolyees.Empolyee_Name;
            this.ckEnabled.Checked = empolyees.Enabled == "1" ? true : false;
            this.txtAlias.Text = empolyees.alias;
            this.txtFax.Text = empolyees.Fax;
            this.txtEmail.Text = empolyees.Email;
            this.txtRemark.Text = empolyees.Remark;
        }

        #region IPopupFormEdit Members
        private Empolyees m_Empolyees = null;

        public object RowData
        {
            get
            {
                return GetEmpolyeesData();
            }
            set
            {
                this.m_Empolyees = value as Empolyees;
                SetEmpolyeesData(this.m_Empolyees);
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            this.m_PostDic.Clear();
            this.m_PostDic.Add(MainHelper.GetSqlMap<mPost>().GetList<mPost>(null));
            this.SetComboBoxData(this.cltPost, "PostSName", "Post_ID", "请选择", "岗位名称", this.m_PostDic);

            if (null != this.m_PostID && this.m_PostID.Trim().Length > 0)
                this.cltPost.Properties.KeyValue = this.m_PostID;
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, SortableSearchableBindingList<mPost> post)
        {
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

        void btnPostDic_Click(object sender, EventArgs e)
        {
            FrmDictionary frmPostDic = new FrmDictionary("");

            if (frmPostDic.ShowDialog() == DialogResult.OK)
            {
                //PositionDictionary postDic = frmPostDic.NowPostDic;
                //this.cltPost.Properties.KeyValue = postDic.Post_ID;
            }
        }
    }
}