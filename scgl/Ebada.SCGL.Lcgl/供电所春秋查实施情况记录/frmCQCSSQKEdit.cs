﻿using System;
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
    public partial class frmCQCSSQKEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_cqcssqk> m_CityDic = new SortableSearchableBindingList<PJ_cqcssqk>();

        public frmCQCSSQKEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {


            this.memoEdit1.DataBindings.Add("EditValue", rowData, "kzlr");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "ssrq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "zcr");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cjr");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "jclx");

            this.memoEdit2.DataBindings.Add("EditValue", rowData, "js");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_cqcssqk rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PJ_cqcssqk;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_cqcssqk>(value as PJ_cqcssqk, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            comboBoxEdit1.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='春秋查内查发现问题及整改落实情况记录' and sx like '%{0}%' and nr!=''", "落实情况"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {

                comboBoxEdit1.Properties.Items.Add("已落实");
                comboBoxEdit1.Properties.Items.Add("未落实");


            }
            comboBoxEdit1.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='春秋查内查发现问题及整改落实情况记录' and sx like '%{0}%' and nr!=''", "落实人"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit1.Properties.Items.Add("所长");
                comboBoxEdit1.Properties.Items.Add("班长");
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select UserName from mUser where 5=5    AND OrgCode IN ( select OrgCode from mOrg where 5=5  AND OrgName ='{0}' )", rowData.OrgName));
                comboBoxEdit1.Properties.Items.AddRange(strlist);
            }
            comboBoxEdit2.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='春秋查内查发现问题及整改落实情况记录' and sx like '%{0}%' and nr!=''", "督办人"));
            if (strlist.Count > 0)
            {
                for (int i = 0; i < strlist.Count; i++)
                {
                    comboBoxEdit2.Properties.Items.Add(strlist[i]);
                }
            }
            else
            {

                comboBoxEdit2.Properties.Items.Add("全所职工");
                comboBoxEdit2.Properties.Items.Add("所长");
                strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select UserName from mUser where 5=5    AND OrgCode IN ( select OrgCode from mOrg where 5=5  AND OrgName ='{0}' )", rowData.OrgName));
                for (int i = 0; i < strlist.Count; i++)
                {
                    comboBoxEdit2.Properties.Items.Add(strlist[i]);
                }

            }


            comboBoxEdit3.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='春秋查内查发现问题及整改落实情况记录' and sx like '%{0}%' and nr!=''", "检查类型"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {

                comboBoxEdit3.Properties.Items.Add("春查");
                comboBoxEdit3.Properties.Items.Add("秋查");


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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
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





        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("供电所春秋查实施情况记录", "开展内容", memoEdit1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("供电所春秋查实施情况记录", "记事", memoEdit2);
        }



    }
}