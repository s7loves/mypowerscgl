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
using Ebada.Scgl.Sbgl;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmtestRecordEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_yfsyjl> m_CityDic = new SortableSearchableBindingList<PJ_yfsyjl>();
        UCPopupLine poptq = new UCPopupLine();
        private string _type = null;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;

            }
        }
        public frmtestRecordEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbModle");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "sl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbCapacity");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "syPeriod");
            spinEdit1.DataBindings.Add("EditValue", rowData, "syPeriod");

            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "syProject");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "preExpTime");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "planExpTime");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "charMan");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");

            this.poptq.DataBindings.Add("EditValue", rowData, "sbInstallAdress");
            poptq.Bounds = lkueTq.Bounds;
            lkueTq.Hide();
            poptq.Parent = lkueTq.Parent;
            poptq.Visible = true;
            switch (rowData.type)
            {
                case "变压器":
                    labelControl3.Text = "容量";
                    labelControl3.Visible = true;
                    comboBoxEdit4.Visible = true;
                    spinEdit2.Visible = false;
                    //this.poptq.DataBindings.Add("EditValue", rowData, "tqid");
                    break;
                case "避雷器":
                    labelControl3.Text = "数量";
                    labelControl3.Visible = true;
                    spinEdit2.Visible = true;
                    poptq.Visible = true;
                    lkueTq.Visible = false;
                    break;
                case "断路器":
                    labelControl3.Text = "数量";
                    labelControl3.Visible = true;
                    spinEdit2.Visible = true;
                    // this.poptq.DataBindings.Add("EditValue", rowData, "kgid");

                    break;
                case "电容器":
                    labelControl3.Text = "数量";
                    labelControl3.Visible = true;
                    spinEdit2.Visible = true;
                    break;



            }
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_yfsyjl rowData = null;

        public object RowData
        {
            get
            {
                rowData.sbInstallAdress = poptq.Text;
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PJ_yfsyjl;
                    rowData.type = _type;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_yfsyjl>(value as PJ_yfsyjl, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            //comboBoxEdit5.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备安装位置", comboBoxEdit5);
            //comboBoxEdit1.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "设备型号", comboBoxEdit1);
            //comboBoxEdit3.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "试验周期", comboBoxEdit3);
            //comboBoxEdit4.Properties.Items.Clear();
            //ComboBoxHelper.FillCBoxByDyk("预防性试验", "容量", comboBoxEdit4);
            comboBoxEdit6.Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("预防性试验", "落实人", comboBoxEdit6);
            IList li;

            poptq.Properties.PopupFormSize = new Size(poptq.Properties.PopupFormSize.Width, 200);
            poptq.EditValueChanged += new EventHandler(popTq_EditValueChanged);

            switch (rowData.type)
            {
                case "变压器":
                    // IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where left(xlcode,3)='{0}'", rowData.OrgCode));
                    //IList<PS_tqbyq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tqbyq>(string.Format("where left(tqID,3)='{0}'", rowData.OrgCode));
                    IList<Hashtable> xlList = Client.ClientHelper.PlatformSqlMap.GetList<Hashtable>("Select",
                        string.Format("SELECT     PS_xl.LineName + left(RIGHT(PS_gt.gtCode, 4),3) AS name, PS_tqbyq.byqID AS id, PS_tqbyq.byqModle, PS_tqbyq.byqCapcity"
                                          +" FROM         PS_gt INNER JOIN"
                                          +" PS_xl ON PS_gt.LineCode = PS_xl.LineCode INNER JOIN"
                                          +" PS_tqbyq INNER JOIN"
                                          +" PS_tq ON PS_tqbyq.tqID = PS_tq.tqID ON PS_gt.gtID = PS_tq.gtID"                       
                        +" WHERE     (LEFT(PS_tqbyq.tqID, 3) = '{0}')", rowData.OrgCode));
                    
                    this.poptq.DisplayField = "name";
                    this.poptq.ValueField = "id";
                    if (xlList.Count != 0)
                    {
                        poptq.DataSource = xlList;
                    }
                    #region
                    //if (comboBoxEdit5.Properties.Items.Count < 2)
                    //{
                    //    li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select linename from ps_xl where OrgCode = '{0}'and linevol='{1}'", rowData.OrgCode, "10"));
                    //    comboBoxEdit5.Properties.Items.AddRange(li);
                    //}
                    //if (comboBoxEdit1.Properties.Items.Count == 0)
                    //{

                    //    comboBoxEdit1.Properties.Items.Add("SJ");
                    //    comboBoxEdit1.Properties.Items.Add("S7");
                    //    comboBoxEdit1.Properties.Items.Add("S9");
                    //    comboBoxEdit1.Properties.Items.Add("S11");
                    //}
                    //if (comboBoxEdit4.Properties.Items.Count == 0)
                    //{

                    //    comboBoxEdit4.Properties.Items.Add("10");
                    //    comboBoxEdit4.Properties.Items.Add("20");
                    //    comboBoxEdit4.Properties.Items.Add("30");
                    //    comboBoxEdit4.Properties.Items.Add("50");
                    //    comboBoxEdit4.Properties.Items.Add("63");
                    //    comboBoxEdit4.Properties.Items.Add("80");
                    //    comboBoxEdit4.Properties.Items.Add("100");
                    //    comboBoxEdit4.Properties.Items.Add("125");
                    //    comboBoxEdit4.Properties.Items.Add("160");
                    //    comboBoxEdit4.Properties.Items.Add("200");
                    //    comboBoxEdit4.Properties.Items.Add("250");
                    //    comboBoxEdit4.Properties.Items.Add("315");
                    //    comboBoxEdit4.Properties.Items.Add("400");
                    //    comboBoxEdit4.Properties.Items.Add("500");
                    //    comboBoxEdit4.Properties.Items.Add("630");
                    //    comboBoxEdit4.Properties.Items.Add("1000");
                    //    comboBoxEdit4.Properties.Items.Add("2000");
                    //}
                    //if (comboBoxEdit3.Properties.Items.Count == 0)
                    //{

                    //    comboBoxEdit3.Properties.Items.Add("SJ");
                    //    comboBoxEdit3.Properties.Items.Add("S7");
                    //    comboBoxEdit3.Properties.Items.Add("S9");
                    //}
                    if (comboBoxEdit6.Properties.Items.Count == 0)
                    {
                        li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select UserName from mUser where OrgCode = ('{0}')", rowData.OrgCode));
                        comboBoxEdit6.Properties.Items.AddRange(li);
                    }
                    if (comboBoxEdit7.Properties.Items.Count == 0)
                    {
                        comboBoxEdit7.Properties.Items.Add("交流耐压");
                        comboBoxEdit7.Properties.Items.Add("绕组绝缘电阻");
                        comboBoxEdit7.Properties.Items.Add("绝缘油试验");
                        comboBoxEdit7.Properties.Items.Add("绕组直流电阻");
                    }
                    #endregion
                    break;
                case "避雷器":

                    //if (comboBoxEdit5.Properties.Items.Count < 2)
                    //{
                    //    li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select linename from PS_xl where OrgCode = '{0}' and linevol='{1}'", rowData.OrgCode, "10"));
                    //    comboBoxEdit5.Properties.Items.AddRange(li);
                    //}
                    //if (comboBoxEdit1.Properties.Items.Count == 0)
                    //{

                    //    comboBoxEdit1.Properties.Items.Add("FZ-10/50(阀型)");
                    //    comboBoxEdit1.Properties.Items.Add("Y(H)5WS-17/50");
                    //}
                    //IList<PS_tq> tqlist = ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_MytqList", " and LEFT(tq.tqCode,3)='" + rowData.OrgCode + "'");
                    IList<Hashtable> tqlist = ClientHelper.PlatformSqlMap.GetList<Hashtable>("Select",
                        string.Format("(SELECT     PS_xl.LineName + RIGHT(PS_gt.gtCode, 4) AS name, PS_gt.gtID AS id,PS_gtsb.sbModle"
                                    + " FROM         PS_kg INNER JOIN"
                                    + " PS_gt ON PS_kg.gtID = PS_gt.gtID INNER JOIN"
                                    + " PS_xl ON PS_gt.LineCode = PS_xl.LineCode INNER JOIN"
                                    + " PS_gtsb ON PS_gt.gtID = PS_gtsb.gtID"
                                    + " WHERE (LEFT(PS_kg.gtID, 3) = '{0}') AND ps_gtsb.sbname='避雷器'  )"
                                    + " union "
                                    + " ( SELECT     PS_xl.LineName + RIGHT(PS_gt.gtCode, 4) AS name,PS_gt.gtID AS id,PS_tqsb.sbModle"
                                    + " FROM         PS_tqbyq INNER JOIN"
                                    + " PS_tq ON PS_tqbyq.tqID = PS_tq.tqID INNER JOIN"
                                    + " PS_gt ON PS_tq.gtID = PS_gt.gtID INNER JOIN"
                                    + " PS_xl ON PS_gt.LineCode = PS_xl.LineCode INNER JOIN"
                                    + " PS_tqsb ON PS_tq.tqID = PS_tqsb.tqID"
                                    + " WHERE (LEFT(PS_tqbyq.tqID, 3) = '{1}') AND PS_tqsb.sbname='避雷器')"
                        , rowData.OrgCode, rowData.OrgCode));
                    lkueTq.Properties.ValueMember = "id";
                    //lkueTq.Properties.DisplayField = "name";
                    //lkueTq.Properties.DataSource = tqlist;
                    //if(lkueTq.Properties.Columns.Count<1)
                    //lkueTq.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 100, "请选择"));
                    //lkueTq.EditValueChanged += new EventHandler(lkueTq_EditValueChanged);

                    //改用带查找的控件

                    this.poptq.DisplayField = "name";
                    this.poptq.ValueField = "id";
                    if (tqlist.Count != 0)
                    {
                        poptq.DataSource = tqlist;
                    }


                    if (comboBoxEdit6.Properties.Items.Count == 0)
                    {
                        li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select UserName from mUser where OrgCode = ('{0}')", rowData.OrgCode));
                        comboBoxEdit6.Properties.Items.AddRange(li);
                    }
                    if (comboBoxEdit7.Properties.Items.Count == 0)
                    {
                        comboBoxEdit7.Properties.Items.Add("绝缘电阻");
                        comboBoxEdit7.Properties.Items.Add("工频放电电压");
                        comboBoxEdit7.Properties.Items.Add("底座绝缘电阻");
                    }
                    break;
                case "断路器":
                    #region
                    //if (comboBoxEdit5.Properties.Items.Count < 2)
                    //{
                    //    li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select linename from PS_xl where OrgCode = '{0}' and linevol='{1}'", rowData.OrgCode, "10"));
                    //    comboBoxEdit5.Properties.Items.AddRange(li);
                    //}
                    //if (comboBoxEdit1.Properties.Items.Count == 0)
                    //{

                    //    comboBoxEdit1.Properties.Items.Add("ZW8-10-630");
                    //    comboBoxEdit1.Properties.Items.Add("ZW32-10-630");
                    //    comboBoxEdit1.Properties.Items.Add("智能型-10-630");
                    //    comboBoxEdit1.Properties.Items.Add("SF6-10-630");
                    //}

                    if (comboBoxEdit6.Properties.Items.Count == 0)
                    {
                        li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select UserName from mUser where OrgCode = ('{0}')", rowData.OrgCode));
                        comboBoxEdit6.Properties.Items.AddRange(li);
                    }
                    if (comboBoxEdit7.Properties.Items.Count == 0)
                    {
                        comboBoxEdit7.Properties.Items.Add("绝缘电阻");
                        comboBoxEdit7.Properties.Items.Add("交流耐压");
                        comboBoxEdit7.Properties.Items.Add("导电回路电阻");
                        comboBoxEdit7.Properties.Items.Add("分合闸磁铁线圈的绝缘电阻和直流电阻");
                    }
                    #endregion
                    IList<Hashtable> kgList = Client.ClientHelper.PlatformSqlMap.GetList<Hashtable>("Select", string.Format("SELECT     PS_xl.LineName + RIGHT(PS_gt.gtCode, 4) AS name, PS_kg.kgID AS id,PS_kg.kgModle FROM   PS_kg INNER JOIN PS_gt ON PS_kg.gtID = PS_gt.gtID INNER JOIN PS_xl ON PS_gt.LineCode = PS_xl.LineCode  where left(PS_kg.gtID,3)='{0}' AND PS_xl.LineVol='10'", rowData.OrgCode));
                    this.poptq.DisplayField = "name";
                    this.poptq.ValueField = "id";
                    if (kgList.Count != 0)
                    {
                        poptq.DataSource = kgList;
                    }
                    break;
                case "电容器":

                    //if (comboBoxEdit5.Properties.Items.Count < 2)
                    //{
                    //    li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select linename from PS_xl where OrgCode = '{0}' and linevol='{1}'", rowData.OrgCode, "10"));
                    //    comboBoxEdit5.Properties.Items.AddRange(li);
                    //}
                    if (comboBoxEdit1.Properties.Items.Count == 0)
                    {

                        comboBoxEdit1.Properties.Items.Add("100Kvar");
                        comboBoxEdit1.Properties.Items.Add("120Kvar");
                        comboBoxEdit1.Properties.Items.Add("150Kvar");
                        comboBoxEdit1.Properties.Items.Add("200 Kvar");
                        comboBoxEdit1.Properties.Items.Add("400 Kvar");
                        comboBoxEdit1.Properties.Items.Add("800 Kvar");
                    }


                    if (comboBoxEdit6.Properties.Items.Count == 0)
                    {
                        li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select UserName from mUser where OrgCode = ('{0}')", rowData.OrgCode));
                        comboBoxEdit6.Properties.Items.AddRange(li);
                    }
                    if (comboBoxEdit7.Properties.Items.Count == 0)
                    {
                        comboBoxEdit7.Properties.Items.Add("极对壳绝缘电阻");
                        comboBoxEdit7.Properties.Items.Add("电容值");
                        comboBoxEdit7.Properties.Items.Add("并联电阻值测量");
                        comboBoxEdit7.Properties.Items.Add("渗漏油检查");
                    }

                    break;



            }
        }

        void lkueTq_EditValueChanged(object sender, EventArgs e)
        {
            if (rowData.type == "避雷器")
            {
                comboBoxEdit1.EditValue = ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select sbModle from PS_tqsb where sbName='避雷器' and PS_tqsb.tqID='" + lkueTq.EditValue + "'");
            }
        }

        #region 设备安装位置改变
        void popTq_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = poptq.GetDataRow();

            if (row == null) return;
            switch (rowData.type)
            {
                case "变压器":
                    if (row != null)
                    {
                        comboBoxEdit1.EditValue = row["byqModle"];
                        rowData.sbModle = row["byqModle"].ToString();
                        comboBoxEdit4.EditValue = row["byqCapcity"];
                        rowData.sbCapacity = Convert.ToInt32(row["byqCapcity"]);
                    }
                    break;
                case "断路器":
                    comboBoxEdit1.EditValue = row["kgModle"];
                    rowData.sbModle = row["kgModle"].ToString();
                    break;
                case "避雷器":
                    comboBoxEdit1.EditValue = row["sbModle"];
                    rowData.sbModle = row["sbModle"].ToString();
                    break;
            }
        }
        #endregion

        #region
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
            InitComboBoxData();
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

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (memoEdit2.Text.IndexOf(comboBoxEdit7.Text) == -1)
            //{
            //    //if (memoEdit2.Text == "")
            //        memoEdit2.Text = comboBoxEdit7.Text;
            //    //else
            //    //{
            //    //    memoEdit2.Text +="," +comboBoxEdit7.Text;
            //    //}
            //    rowData.syProject = memoEdit2.Text;
            //}

        }





        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {
            double i = Convert.ToDouble(spinEdit1.Value);
            dateEdit2.EditValue = Convert.ToDateTime(dateEdit3.EditValue).AddMonths(Convert.ToInt32(i * (12))).ToString("yyyy-MM-dd");
            rowData.planExpTime = Convert.ToDateTime(Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd"));
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            //rowData.sbInstallAdress = popTq.EditValue.ToString();
        }

        #region 试验周期改变
        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            double i = Convert.ToDouble(spinEdit1.Value);
            dateEdit2.EditValue = Convert.ToDateTime(dateEdit3.EditValue).AddMonths(Convert.ToInt32(i * (12))).ToString("yyyy-MM-dd");
            rowData.planExpTime = Convert.ToDateTime(Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd"));
        }
        #endregion
    }
}