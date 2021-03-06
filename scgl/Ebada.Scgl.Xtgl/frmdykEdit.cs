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
namespace Ebada.Scgl.Xtgl
{
    public partial class frmdykEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_dyk> m_CityDic = new SortableSearchableBindingList<PJ_dyk>();

        public frmdykEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "dx");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sx");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "bh");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "zjm");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "nr");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "nr2");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "nr3");
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "nr4");
            
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_dyk rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_dyk;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_dyk>(value as PJ_dyk, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_dyk>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
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

      

       

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {
           // PJ_dyk dyk = MainHelper.PlatformSqlMap.GetOneByKey<PJ_dyk>(rowData.ID);
           // ceQuick.Visible = false;
           //if (dyk == null)
           //{
            ceQuick.Checked = false;
           //    ceQuick.Visible = true;
           //}
        }

      
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ceQuick.Visible && ceQuick.Checked)
            {
                string[] nr = rowData.nr.Split(new string[] { "\r\n" },StringSplitOptions.None);
                string[] nr2 = rowData.nr2.Split(new string[] { "\r\n" },StringSplitOptions.None);
                string[] nr3 = rowData.nr3.Split(new string[] { "\r\n" },StringSplitOptions.None);
                string[] nr4 = rowData.nr4.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                long index = Convert.ToInt64(rowData.ID);
                IList<PJ_dyk> li = MainHelper.PlatformSqlMap.GetList<PJ_dyk>("SelectPJ_dykList", " where ParentID='" + rowData.ParentID + "'  order by id desc");
                if (li.Count > 0)
                    index = (Convert.ToInt64(li[0].bh) );
                else
                {
                    index = (Convert.ToInt64(rowData.ParentID) * 100 + 1);
                }
                rowData.nr = nr[0];
                rowData.nr2 = nr2[0];
                rowData.nr3 = nr3[0];
                rowData.nr4 = nr4[0];
                for (int i = 1; i < nr.Length; i++)
                {
                    if (nr[i] == "") continue;
                    PJ_dyk dyk = new PJ_dyk();
                    dyk.ID = (index + i).ToString();
                    dyk.dx = rowData.dx;
                    dyk.sx = rowData.sx;
                    dyk.bh = dyk.ID;
                    dyk.nr = nr[i];
                    dyk.ParentID = rowData.ParentID;
                    if ( nr2.Length >i) dyk.nr2 = nr2[i];
                    if (nr3.Length > i) dyk.nr3 = nr3[i];
                    if (nr4.Length > i) dyk.nr4 = nr4[i];
                    MainHelper.PlatformSqlMap.Create<PJ_dyk>(dyk);
                }
            }
        }

        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            if (rowData.nr.Length > 50)
                rowData.zjm = SelectorHelper.GetPysm(rowData.nr.Substring(0, 50));
            else
                rowData.zjm = SelectorHelper.GetPysm(rowData.nr);

            comboBoxEdit4.Text = rowData.zjm;
        }
    }
}