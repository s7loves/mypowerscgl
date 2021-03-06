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
    public partial class frm07JDZZEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_07jdzz> m_CityDic = new SortableSearchableBindingList<PJ_07jdzz>();
        private string parentID = "";

        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        public frm07JDZZEdit()
        {
            InitializeComponent();
            //lookUpEdit1.Properties.AutoSearchColumnIndex = 2;
        }
        void dataBind()
        {


            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            //this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "LineName");
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "fzxl");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "fzxl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gth");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzwz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbmc");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xhgg");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jddz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tz");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "trdzr");
            

        }
        #region IPopupFormEdit Members
        private PJ_07jdzz rowData = null;

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
                    this.rowData = value as PJ_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_07jdzz>(value as PJ_07jdzz, rowData);
                    InitComboBoxData();
                }
                if (rowData.xhgg != "") {
                    string[] str = rowData.xhgg.Split("|".ToCharArray());
                    if (str.Length > 1) {
                        comboBoxEdit5.Text = str[0];
                        comboBoxEdit9.Text = str[1];
                    }
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {

            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "设备名称", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器型号", comboBoxEdit5);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器规格", comboBoxEdit9);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "接地电阻", comboBoxEdit6);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土质", comboBoxEdit7);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土壤电阻率", comboBoxEdit8);

            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + parentID + "'and linevol='10'");
            comboBoxEdit1.Properties.DataSource = xlList;
            //lookUpEdit1.Properties.DataSource = xlList;
            comboBoxEdit10.Properties.Items.Clear();
            for (int i = 0; i < xlList.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = xlList[i].LineName;
                ot.ValueMember = xlList[i].LineCode;
                comboBoxEdit10.Properties.Items.Add(ot);
            }

            if (rowData.LineName == "")
            {
                if (comboBoxEdit10.Properties.Items.Count > 0)
                comboBoxEdit10.SelectedIndex = 0;
            }
            else
            {
                comboBoxEdit10.Text = rowData.LineName;
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



        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (comboBoxEdit1.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("线路名称不能为空。");
            //    comboBoxEdit1.Focus();
            //    return;
            //}

            PS_xl xl = null;
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl == null)
            {
                MsgBox.ShowTipMessageBox("线路名称不能对，没找到线路。");
                comboBoxEdit10.Focus();
                return;
            }
            if (xl != null)
            {
                rowData.LineID = xl.LineID;
                rowData.LineName = xl.LineName;
            }
            if (comboBoxEdit4.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备名称不能为空。");
                comboBoxEdit4.Focus();
                return;
            }
            if (comboBoxEdit5.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备型号不能为空。");
                comboBoxEdit5.Focus();
                return;
            }
            if (comboBoxEdit9.Text == "")
            {
                MsgBox.ShowTipMessageBox("保护设备规格不能为空。");
                comboBoxEdit9.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit6.Text) < 0)
            {
                MsgBox.ShowTipMessageBox("接地电阻不能为负。");
                comboBoxEdit6.Focus();
                return;
            }
            if (Convert.ToDouble(comboBoxEdit8.Text) < 0)
            {
                MsgBox.ShowTipMessageBox("土壤电阻率不能为负。");
                comboBoxEdit8.Focus();
                return;
            }
            rowData.LineName = comboBoxEdit10.Text;

            rowData.xhgg = comboBoxEdit5.Text + "|" + comboBoxEdit9.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxEdit4.EditValue.ToString()))
            {
                string sbmc = comboBoxEdit4.EditValue.ToString();
                ICollection list = new ArrayList();
                comboBoxEdit5.Properties.Items.Clear();
                //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where parentid in(select ID from pj_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc + "型号"));
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='07接地装置检测记录' and sx like '%{0}%' and nr!=''", sbmc + "型号"));
                if (list.Count > 0)
                    comboBoxEdit5.Properties.Items.AddRange(list);



                comboBoxEdit9.Properties.Items.Clear();
                //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where parentid in(select ID from pj_dyk where len(parentid)=0 and sx like '%{0}%')", sbmc + "型号"));
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='07接地装置检测记录' and sx like '%{0}%' and nr!=''", sbmc + "规格"));
                if (list.Count > 0)
                    comboBoxEdit9.Properties.Items.AddRange(list);
            }


        }

        private void comboBoxEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit11_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBoxEdit10_TextChanged(object sender, EventArgs e)
        {
            PS_xl xl = null; comboBoxEdit10.ShowPopup();
            xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit10.Text + "'");
            if (xl != null)
            {
                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit11.Properties.Items.Clear();
                comboBoxEdit11.Text = "";
                ICollection list = new ArrayList();
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from PS_gt where   LineCode='{0}' ", xl.LineCode));
                //ICollection list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + comboBoxEdit1.EditValue.ToString() + "'");
                comboBoxEdit2.Properties.Items.AddRange(list);
                //IList<PS_xl> listXL = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where ParentID='" + comboBoxEdit1.EditValue.ToString() + "'and LineType IN ('1','2')");
                //lookUpEdit1.Properties.DataSource = listXL; 
                //xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit10.Text + "'");
                if (xl != null)
                {
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                        "select linename from PS_xl where ParentID='" + xl.LineID + "'and LineType IN ('1','2') ");
                    comboBoxEdit11.Properties.Items.AddRange(list);
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select Adress from PS_tq where   left(tqCode,{1})='{0}' ", xl.LineID.ToString(), xl.LineID.ToString().Length));
                    comboBoxEdit3.Properties.Items.AddRange(list);
                }
                //IList list1 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select Adress from PS_tq where   left(tqCode,{1})='{0}' ", comboBoxEdit1.EditValue.ToString(), comboBoxEdit1.EditValue.ToString().Length));
                //comboBoxEdit3.Properties.Items.AddRange(list1);
                //for (int i = 0; i < list.Count; i++)
                //{
                //    comboBoxEdit3.Properties.Items.Add(list[i].Adress);
                //}
            }
            else
            { 
            
            }
        }

        /// <summary>
        /// 改变线路名后刷新支线路名称和杆塔号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit10_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit11.Properties.Items.Clear();
            comboBoxEdit11.EditValue = "";
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.EditValue = "";
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = "";
            //取得线路code
            Ebada.Scgl.Model.PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<Ebada.Scgl.Model.PS_xl>("WHERE LineName='" + comboBoxEdit10.EditValue + "'");

            //取线路ID
            if (xl == null) return;
            string lineID = xl.LineID;

            //取得下一级线路列表
            IList zxl = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("SELECT lineName FROM PS_XL WHERE parentID='{0}'", lineID));

            comboBoxEdit11.Properties.Items.Clear();
            comboBoxEdit11.EditValue = string.Empty;
            comboBoxEdit11.Properties.Items.AddRange(zxl);
            if (comboBoxEdit11.Properties.Items.Count > 0)
            {
                comboBoxEdit11.SelectedIndex = 0;
            }
            else
            {
                //刷新杆塔号
                IList gt = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("SELECT gtCode FROM PS_GT WHERE LineCode = '{0}'", xl.LineCode));

                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit2.EditValue = string.Empty;
                comboBoxEdit2.Properties.Items.AddRange(gt);
                if (comboBoxEdit2.Properties.Items.Count > 0)
                    comboBoxEdit2.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// 改变支线路名后刷新分线路名称和杆塔号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit11_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.EditValue = "";
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = "";
            //comboBoxEdit11
            //取得线路code
            Ebada.Scgl.Model.PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<Ebada.Scgl.Model.PS_xl>("WHERE LineName='" + comboBoxEdit11.EditValue + "'");
            //取线路ID
            if (xl == null) return;
            string lineID = xl.LineID;
            //取得下一级线路列表
            IList fxl = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("SELECT lineName FROM PS_XL WHERE parentID LIKE '{0}%'", lineID));
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.EditValue = string.Empty;
            comboBoxEdit3.Properties.Items.AddRange(fxl);
            if (comboBoxEdit3.Properties.Items.Count > 0)
            {
                comboBoxEdit3.SelectedIndex = 0;
            }
            else
            {
                //刷新杆塔号
                IList gt = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("SELECT gtCode FROM PS_GT WHERE  LineCode = '{0}'", xl.LineCode));

                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit2.EditValue = string.Empty;
                comboBoxEdit2.Properties.Items.AddRange(gt);
                if (comboBoxEdit2.Properties.Items.Count > 0)
                    comboBoxEdit2.SelectedIndex = 0;
            }


        }
        /// <summary>
        /// 分线路名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit3_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = "";
            //comboBoxEdit11
            //取得线路code
            Ebada.Scgl.Model.PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<Ebada.Scgl.Model.PS_xl>("WHERE LineName='" + comboBoxEdit3.EditValue + "'");
            //取线路ID
            if (xl == null) return;
            string lineID = xl.LineID;
            //刷新杆塔号
            IList gt = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("SELECT gtCode FROM PS_GT WHERE  LineCode = '{0}'", xl.LineCode));

            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = string.Empty;
            comboBoxEdit2.Properties.Items.AddRange(gt);
            if (comboBoxEdit2.Properties.Items.Count > 0)
                comboBoxEdit2.SelectedIndex = 0;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
        
     




    }
}