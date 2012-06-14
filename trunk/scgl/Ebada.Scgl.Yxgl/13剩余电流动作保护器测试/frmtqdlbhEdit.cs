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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmtqdlbhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqdlbh> m_CityDic = new SortableSearchableBindingList<PS_tqdlbh>();

        public frmtqdlbhEdit() {
            InitializeComponent();
        }
        private string lineCode = "";
        private string orgcode = "";
        public string LineCode
        {
            get { return lineCode; }
            set { lineCode = value; }
        }
        public string OrgCode
        {
            get { return orgcode; }
            set { orgcode = value; }
        }
        void dataBind() {



            this.textEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "Number");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "MadeDate");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "InDate");
            this.dateEdit5.DataBindings.Add("EditValue", rowData, "InstallDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "State");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "glr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "dzdl");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "tqID");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "InstallAdress");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "dzsj");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Factory");
            //this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "tqID");


        }
        #region IPopupFormEdit Members
        private PS_tqdlbh rowData = null;

        public object RowData {
            get {
                rowData.dzsj = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqdlbh;
                    rowData.sbCode = DateTime.Now.ToString("yyyymmddhhmmss");
                    if (!string.IsNullOrEmpty(rowData.dzsj))
                    {
                        dateEdit1.DateTime = Convert.ToDateTime(rowData.dzsj);
                    }
                   
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    this.InitComboBoxData();
                    ConvertHelper.CopyTo<PS_tqdlbh>(value as PS_tqdlbh, rowData);
                }
                if(rowData.sbCode==""){
                    rowData.InstallDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                    rowData.MadeDate = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "额定漏电动作电流", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "型号", comboBoxEdit2);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "制造厂名", comboBoxEdit9);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "额定漏电动作时间", comboBoxEdit7);
            ComboBoxHelper.FillCBoxByDyk("13剩余电流动作保护器测试记录", "运行情况", comboBoxEdit1);

            //IList<PS_tq> listtq = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where xlCode='" + lineCode + "'");
            //comboBoxEdit5.Properties.DataSource = listtq
            ICollection list = new ArrayList();
            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select tqName from PS_tq where   left(tqCode,{1})='{0}' ", lineCode,lineCode.Length));
            ////ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
            //comboBoxEdit5.Properties.Items.AddRange(list);
          
            IList<PS_tq> listXL = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>( string.Format("where left(tqID,{1})='{0}' ", OrgCode,OrgCode.Length));
            //comboBoxEdit5.Properties.DataSource = listXL;
            SetComboBoxData(comboBoxEdit5, "tqName", "tqID", "台区名称", "", listXL);
            comboBoxEdit11.Properties.Items.Clear();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select tqName from PS_tq where   left(tqID,{1})='{0}' ", OrgCode, OrgCode.Length));
            
            comboBoxEdit11.Properties.Items.AddRange(list);
            comboBoxEdit10.Properties.Items.Clear();
            for (int i = 0; i < listXL.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = listXL[i].tqName;
                ot.ValueMember = listXL[i].tqName;
                comboBoxEdit10.Properties.Items.Add(ot);
            }

            if (rowData.tqName == "")
            {
                if (comboBoxEdit10.Properties.Items.Count > 0)
                    comboBoxEdit10.SelectedIndex = 0;
            }
            else
            {
                //PS_tq tq = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tq>(rowData.tqID);
                comboBoxEdit10.Text = rowData.tqName;
            }
            ICollection ryList = ComboBoxHelper.GetGdsRy(OrgCode);//获取供电所人员列表
            comboBoxEdit3.Properties.Items.AddRange(ryList);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_tq> post)
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

      

     
        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (comboBoxEdit5.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("台区名称不能为空。");
            //    comboBoxEdit5.Focus();
            //    return;
            //}
            PS_tq tq = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(" where tqName='" + comboBoxEdit10.Text + "'");
            if (tq == null)
            {
                rowData.tqName = comboBoxEdit10.Text;
                //MsgBox.ShowTipMessageBox("台区名称不能为空。");
                //comboBoxEdit5.Focus();
                //return;
            }
            else
            {
                rowData.tqID = tq.tqID;
                rowData.tqName = tq.tqName;
            }
           
            //if (textEdit1.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("设备编号不能为空。");
            //    textEdit1.Focus();
            //    return;
            //}
            //if (rowData.InstallDate>rowData.InDate)
            //{
            //    MsgBox.ShowTipMessageBox("安装日期不能大于投运日期。");
            //    textEdit1.Focus();
            //    return;
            //}
            //rowData.tqName = comboBoxEdit5.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
        private void comboBoxEdit5_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxEdit5.Text))
            {
                PS_tq pt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tq>(comboBoxEdit5.EditValue.ToString());
                comboBoxEdit11.Properties.Items.Add(pt.Adress);
            }
         
        }

        private void comboBoxEdit10_TextChanged(object sender, EventArgs e)
        {
            PS_tq tq = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(" where tqName='" + comboBoxEdit10.Text + "'");
            if (tq != null)
            {
                PS_tq pt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tq>(tq.tqID.ToString());
                comboBoxEdit11.Properties.Items.Add(pt.Adress);
            }
        }
    }
}