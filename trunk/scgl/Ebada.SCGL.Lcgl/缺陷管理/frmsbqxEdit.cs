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
using Ebada.Scgl.WFlow;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmsbqxEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_qxfl> m_CityDic = new SortableSearchableBindingList<PJ_qxfl>();


        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_qxfl,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;

            }
        }

        public DataTable RecordWorkFlowData
        {
            get
            {
                return WorkFlowData;
            }
            set
            {
                WorkFlowData = value;
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
            }
        }

        public frmsbqxEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {


            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xlqd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "xssj");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxlb");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "qxnr", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "xcrq");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_qxfl rowData = null;

        public object RowData
        {
            get
            {
                getxsr();
                getxcr();
                return rowData;
            }
            set
            {
                if (value == null) return;

                if (rowData == null)
                {
                    this.rowData = value as PJ_qxfl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_qxfl>(value as PJ_qxfl, rowData);
                    this.InitComboBoxData();
                }
                setxsr();
                setxcr();
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表

            //comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit5.Properties.Items.AddRange(ryList);
            //comboBoxEdit6.Properties.Items.AddRange(ryList);
            comboBoxEdit7.Properties.Items.AddRange(ryList);

            //ICollection linelist = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<PS_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where OrgCode='" + rowData.OrgCode + "'");
            SetComboBoxData(lookUpEdit1, "LineName", "LineID", "选择线路", "", xllit);

            //巡视区段
            // ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视区段", comboBoxEdit2.Properties);


            //ICollection qxlist = ComboBoxHelper.GetQxlb();//获取缺陷类别
            //缺陷类别GetQxlb
            ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);

            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视人", comboBoxEdit3.Properties);

            //comboBoxEdit4.Properties.Items.AddRange(qxlist);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_xl> post)
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
        void setxsr()
        {
            string str = rowData.xsr;
            comboBoxEdit3.EditValue = "";
            comboBoxEdit6.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit3.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit6.EditValue = mans[1];
            }
        }
        void getxsr()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit3.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit6.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xsr = str;
        }
        void setxcr()
        {
            string str = rowData.xcr;
            comboBoxEdit5.EditValue = "";
            comboBoxEdit7.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit5.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit7.EditValue = mans[1];
            }
        }
        void getxcr()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit5.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit7.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xcr = str;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lookUpEdit1.Text))
            {
                rowData.LineID = lookUpEdit1.EditValue.ToString();
                rowData.LineName = lookUpEdit1.Text;
                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit6.Properties.Items.Clear();
                IList<PJ_sbxsqd> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PJ_sbxsqd>(" where LineCode='" + rowData.LineID + "'");
                foreach (PJ_sbxsqd xsqd in xllit)
                {
                    comboBoxEdit2.Properties.Items.Add(xsqd.XsqdName);
                    comboBoxEdit3.Properties.Items.Add(xsqd.XSR1);
                    comboBoxEdit6.Properties.Items.Add(xsqd.XSR2);
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("缺陷记录", "缺陷内容", memoEdit1);

        }



        private void comboBoxEdit3_Properties_SelectedValueChanged(object sender, EventArgs e)
        {
            //string xsry = comboBoxEdit3.Properties.GetDisplayText(null);
            ////comboBoxEdit3.EditValue = "";
            //comboBoxEdit6.EditValue = "";
            //string[] mans = xsry.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            //if (mans.Length >= 1)
            //{
            //    comboBoxEdit3.EditValue = mans[0];
            //}
            //if (mans.Length >= 2)
            //{
            //    comboBoxEdit6.EditValue = mans[1];
            //}

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            string xsqdname = comboBoxEdit2.EditValue.ToString();
           PJ_sbxsqd ps = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_sbxsqd>("where XsqdName='"+xsqdname+"'and LineCode='"+rowData.LineID+"' ");
            if (ps!=null)
            {
                comboBoxEdit3.EditValue = ps.XSR1;
                comboBoxEdit6.EditValue = ps.XSR2;
            }
        }

        private void comboBoxEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR1 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.Properties.Items.AddRange(list);

            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR2 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            comboBoxEdit6.Properties.Items.Clear();
            comboBoxEdit6.Properties.Items.AddRange(list); 
        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {

            DateTime dt = Convert.ToDateTime(rowData.xssj );
            string dx = "", sx = "";
            int dayspan1 = 1, dayspan2 = 10, dayspan3 = 30;
            dx = "06设备巡视及缺陷消除记录";
            sx = "紧急缺陷";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0)
            {
                dayspan1 = Convert.ToInt32(list[0]);
            }

            sx = "重大缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0)
            {
                dayspan2 = Convert.ToInt32(list[0]);
            }
            sx = "一般缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
            if (list.Count > 0)
            {
                dayspan3 = Convert.ToInt32(list[0]);
            }
            if (comboBoxEdit4.EditValue == null) return;
            switch (comboBoxEdit4.EditValue.ToString())
                {
                    case "紧急缺陷":
                        rowData .xcqx = dt.AddDays(dayspan1).ToShortDateString();
                        break;
                    case "重大缺陷":
                        rowData.xcqx = dt.AddDays(dayspan2).ToShortDateString();
                        break;
                    case "一般缺陷":
                        rowData.xcqx = dt.AddDays(dayspan3).ToShortDateString();
                        break;
                }
            dateEdit3.Text = rowData.xcqx;

          
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit4_EditValueChanged(sender ,e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strmes = "";
            PJ_qxfl sbxs = RowData as PJ_qxfl;
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(sbxs.ID);
            if (obj == null&& isWorkflowCall)
            {

              
                if (isWorkflowCall)
                {
                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ModleRecordID = sbxs.ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.ModleTableName = sbxs.GetType().ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.CreatTime = DateTime.Now;
                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                }

            }
           
        }

        






    }
}