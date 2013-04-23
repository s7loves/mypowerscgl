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
using Ebada.Scgl.Sbgl;
namespace Ebada.Scgl.Yxgl {
    public partial class frmSDxsDialog : FormBase, IPopupFormEdit {

        public frmSDxsDialog()
        {
            InitializeComponent();
        }
        SortableSearchableBindingList<sdjl_sbxsqd> m_CityDic = new SortableSearchableBindingList<sdjl_sbxsqd>();
        public string orgcode = "";
        public string lineid = "";
        UCPopupSelectorBase xlselector;
        UCPopupLine popLine = new UCPopupLine();
        private void frm06sbxsLine_Load(object sender, EventArgs e) {

            //ICollection linelist = ComboBoxHelper.GetGdsxl(orgcode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);

        }
        
        //private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    linename = comboBoxEdit1.EditValue.ToString();
        //}

        void dataBind() {
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineCode");
            
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xsqdName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "XSR1");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "XSR2");
            popLine.Parent = lookUpEdit1.Parent;
            popLine.Bounds = lookUpEdit1.Bounds;
            lookUpEdit1.Hide();
            this.popLine.DataBindings.Add("EditValue", rowData, "LineCode");
        }
        #region IPopupFormEdit Members
        private sdjl_sbxsqd rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_sbxsqd;
                    this.InitComboBoxData();

                    if (lineid != "") {
                        rowData.LineCode = lineid;
                    }
                    dataBind();

                } else {
                    this.InitComboBoxData();
                    ConvertHelper.CopyTo<sdjl_sbxsqd>(value as sdjl_sbxsqd, rowData);                    
                }

            }
        }

        #endregion

        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(orgcode);//获取供电所人员列表

            //comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit3.Properties.Items.AddRange(ryList);
            //comboBoxEdit6.Properties.Items.AddRange(ryList);
            comboBoxEdit4.Properties.Items.AddRange(ryList);

            //ICollection linelist = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<sd_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>(" where OrgCode='" + orgcode + "'");
            popLine.DataSource = xllit;
            SetComboBoxData(lookUpEdit1, "LineName", "LineID", "选择线路", "", xllit);
            //createXlSeach();
            //xlselector.DataSource = Ebada.Core.ConvertHelper.ToDataTable((IList)xllit, typeof(PS_xl));
            //xlselector.SetColumnsVisible("LineName");
            //xlselector.SetFilterColumns("xlpy");
            
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<sd_xl> post) {
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

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

    }
}