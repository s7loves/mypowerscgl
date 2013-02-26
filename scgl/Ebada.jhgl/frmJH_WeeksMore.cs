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
using System.Collections;

namespace Ebada.jhgl
{
    public partial class frmJH_WeeksMore : FormBase, IPopupFormEdit
    {
        DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
        public List<JH_weekks> jhWeeksList;
        DataTable dt;
        public DataTable GetDataTable
        {
            get
            {
                return dt;
            }
            
        }
        
        public frmJH_WeeksMore()
        {
            InitializeComponent();
            InitTable();
        }
       
        private void InitTable()
        {
            dt = new DataTable();
            dt.Columns.Add("IsSelect", typeof(bool));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("ParentID", typeof(string));
            dt.Columns.Add("_单位代码", typeof(string));
            dt.Columns.Add("_单位名称", typeof(string));
            dt.Columns.Add("_计划项目", typeof(string));
            dt.Columns.Add("_实施内容", typeof(string));
            dt.Columns.Add("_参加人员", typeof(string));
        }

        #region IPopupFormEdit 成员

        public object RowData
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        private void frmJH_WeeksMore_Load(object sender, EventArgs e)
        {
            if (jhWeeksList != null)
            {
                if (jhWeeksList.Count > 0)
                {
                    foreach (JH_weekks jhweeks in jhWeeksList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["IsSelect"] = false;
                        dr["ID"] = jhweeks.ID;
                        dr["ParentID"] = jhweeks.ParentID;
                        dr["_单位代码"] = jhweeks.单位代码;
                        dr["_单位名称"] = jhweeks.单位名称;
                        dr["_计划项目"] = jhweeks.计划项目;
                        dr["_实施内容"] = jhweeks.实施内容;
                        dr["_参加人员"] = jhweeks.参加人员;
                        dt.Rows.Add(dr);
                    }
                    gridControl1.DataSource = dt;
                    InitGridColumn();
                }
                
            }
            
        }

        private void InitGridColumn()
        {
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["_单位代码"].Visible = false;

            gridView1.Columns["IsSelect"].Caption = "选择";
            gridView1.Columns["IsSelect"].ColumnEdit = repositoryItemCheckEdit1;
            repositoryItemCheckEdit1.Click += new EventHandler(repositoryItemCheckEdit1_Click);
            gridView1.Columns["IsSelect"].VisibleIndex = 0;

            gridView1.Columns["_单位名称"].Caption = "单位名称";
            gridView1.Columns["_单位名称"].VisibleIndex = 1;

            gridView1.Columns["_计划项目"].Caption = "计划项目";
            gridView1.Columns["_计划项目"].VisibleIndex = 2;

            gridView1.Columns["_实施内容"].Caption = "实施内容";
            gridView1.Columns["_实施内容"].VisibleIndex = 3;

            gridView1.Columns["_参加人员"].Caption = "参加人员";
            gridView1.Columns["_参加人员"].VisibleIndex = 4;
        }

        void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            CheckEdit cbox = (CheckEdit)sender;
            DataRow drSelect= gridView1.GetFocusedDataRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ID"] == drSelect["ID"])
                {
                    if ((bool)dt.Rows[i]["IsSelect"] == true)
                    {
                        dt.Rows[i]["IsSelect"] = false;
                    }
                    else
                    {
                        dt.Rows[i]["IsSelect"] = true;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
