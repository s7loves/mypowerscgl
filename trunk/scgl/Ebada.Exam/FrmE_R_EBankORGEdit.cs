using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;

namespace Ebada.Exam
{
    public partial class FrmE_R_EBankORGEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_R_EBankORG> m_CityDic = new SortableSearchableBindingList<E_R_EBankORG>();
        public FrmE_R_EBankORGEdit()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Refresh();
        }
        private void Refresh()
        {
            string sqlwhere = " where EBID='" + _ebid + "'";
            IList<E_R_EBankORG> erorglist = ClientHelper.PlatformSqlMap.GetListByWhere<E_R_EBankORG>(sqlwhere);

            string str = string.Empty;
            foreach (E_R_EBankORG item in erorglist)
            {
                str += item.ORGID + ",";
            }
            if (str.Length > 2)
            {
                str = str.Substring(0, str.Length - 1);
            }
            uCmOrgTree1.OrgIDs = str;
        }
        private string _ebid = string.Empty;
        public string Ebid
        {
            set
            {
                if (value != null)
                {
                    this._ebid = value ;
                    
                }
               
            }
        }
        void dataBind()
        {

            //this.lkueorg.DataBindings.Add("EditValue", rowData, "ORGID");

        }
        private E_R_EBankORG rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {

                //if (value != null)
                //{
                //    this.rowData = value as E_R_EBankORG;
                //    string sqlwhere = " where EBID='" + rowData.EBID + "'";
                //    IList<E_R_EBankORG> erorglist = ClientHelper.PlatformSqlMap.GetListByWhere<E_R_EBankORG>(sqlwhere);

                //    string str = string.Empty;
                //    foreach (E_R_EBankORG item in erorglist)
                //    {
                //        str += item.ORGID + ",";
                //    }
                //    if (str.Length > 2)
                //    {
                //        str = str.Substring(0, str.Length - 1);
                //    }
                //    uCmOrgTree1.OrgIDs = str;
                //}
                //else
                //{
                //    uCmOrgTree1.OrgIDs = string.Empty;
                //}
               
            }
        }

        private void InitComboBoxData()
        {
            //IList<mOrg> orglist = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("");
            //SetComboBoxData(lkueorg, "OrgName", "OrgCode", "请选择", "单位", orglist);
        }
        char spchar = ',';
        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (lkueorg.EditValue == null)
            //{
            //    MsgBox.ShowWarningMessageBox("请选择组织机构！");
            //    return;
            //}
            //IList<E_R_EBankORG> list = Client.ClientHelper.PlatformSqlMap.GetList<E_R_EBankORG>(" where ORGID='" + lkueorg.EditValue.ToString() + "' and EBID='" + rowData.EBID + "'");
            //if (list.Count > 0 && rowData.ID != list[0].ID)
            //{
            //    MsgBox.ShowWarningMessageBox("该题库已添加名为【" + lkueorg.Text + "】的组织机构！");
            //    return;
            //}
            string OrgIDs = uCmOrgTree1.GetOrgIDS();
            string[] strarry = OrgIDs.Split(spchar);
            if (strarry.Length > 0)
            {
                string sqlwhere = " where EBID='" + _ebid + "'";
                ClientHelper.PlatformSqlMap.DeleteByWhere<E_R_EBankORG>(sqlwhere);
                for (int i = 0; i < strarry.Length; i++)
                {
                    if (strarry[i]!=string.Empty)
                    {
                        E_R_EBankORG ereb = new E_R_EBankORG();
                        ereb.ID += i;
                        ereb.EBID = _ebid;
                        ereb.ORGID = strarry[i];
                        ClientHelper.PlatformSqlMap.Create<E_R_EBankORG>(ereb);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<mOrg> post)
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
    }
}
