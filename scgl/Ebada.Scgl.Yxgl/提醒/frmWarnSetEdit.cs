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
using System.Data.SqlClient;
using System.Reflection;
namespace Ebada.Scgl.Yxgl
{
    public partial class frmWarnSetEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<WarnSet> m_CityDic = new SortableSearchableBindingList<WarnSet>();

        public frmWarnSetEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.cobtype.DataBindings.Add("EditValue", rowData, "Type");
            this.cobTable.DataBindings.Add("EditValue", rowData, "TableName");
            this.lkufield.DataBindings.Add("EditValue", rowData, "FieldName");
            this.lkuorg.DataBindings.Add("EditValue", rowData, "OrgField");
            this.cobLinkID.DataBindings.Add("EditValue", rowData, "LinkID");
            this.chkIsUse.DataBindings.Add("EditValue", rowData, "IsUse");
            this.memoRemark.DataBindings.Add("EditValue", rowData, "Remark");


            this.cobWarnType.DataBindings.Add("EditValue", rowData, "WarnType");
            this.sporderdays.DataBindings.Add("EditValue", rowData, "OrderDays");
            this.spSpaceDays.DataBindings.Add("EditValue", rowData, "SpaceDays");
            this.spBeforeDays.DataBindings.Add("EditValue", rowData,"BeforeDays");
            this.spAfterDays.DataBindings.Add("EditValue", rowData,  "AfterDays");
        }
        #region IPopupFormEdit Members
        private WarnSet rowData = null;
        
        public object RowData {
            get {
                rowData.FieldCNName = lkufield.Text;
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as WarnSet;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<WarnSet>(value as WarnSet, rowData);
                }
                if (rowData.Type==string.Empty)
                {
                    WarnSetType();
                    rowData.Type = resultlist[0];
                }
                if (rowData.WarnType == string.Empty)
                {
                    WarningType();
                    rowData.WarnType = warningtype[1];
                }
            }
        }

        #endregion

        private static List<string> resultlist = new List<string>();
        public static ICollection WarnSetType()
        {
            if (resultlist.Count==0)
            {
                resultlist.Add("实验");
                resultlist.Add("检修");
                resultlist.Add("记录");
            }
            return resultlist;
        }
        public static string WarinType1 = "每月";
        public static string WarinType2 = "间隔日";

        private static List<string> warningtype = new List<string>();
        public static ICollection WarningType()
        {
            if (warningtype.Count == 0)
            {
                warningtype.Add(WarinType1);
                warningtype.Add(WarinType2);
            }
            return warningtype;
        }
        private void InitComboBoxData() {


            cobtype.Properties.Items.AddRange(WarnSetType());
            cobWarnType.Properties.Items.AddRange(WarningType());
            cobTable.Properties.Items.AddRange(GetDataTableNameList());
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


       

        public static List<string > GetDataTableNameList( )
        {

            List<string> returnlist = new List<string>();

            string connstr = MainHelper.PlatformSqlMap.GetConnectionString();

            SqlConnection conn = new SqlConnection(connstr);
            string[] strarray = connstr.Split(';');

            string databasename = strarray[1].Replace("database=", "");

            string sql = "use " + databasename + " EXEC sp_tables";

            try
            {
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                DataRow[] rows = dt.Select("TABLE_TYPE='TABLE' or TABLE_TYPE='VIEW'");
                foreach (DataRow row1 in rows)
                {
                    returnlist.Add(row1["TABLE_NAME"].ToString());
                }
               
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return returnlist;
        }

        private void cobTable_SelectedValueChanged(object sender, EventArgs e)
        {
            IList<DicType> list = GetFieldByTableName(cobTable.Text);
            SetComboBoxData(lkufield, "Value", "Key", "", "", list);
            SetComboBoxData(lkuorg, "Value", "Key", "", "", list);
        }
        public static IList<DicType> GetFieldByTableName(string tablename)
        {
            IList<DicType> list = new List<DicType>();
            if (tablename==string.Empty)
            {
                return list;
            }
            

            string TName ="Ebada.Scgl.Model."+ tablename;
            System.Reflection.Assembly ass = Assembly.LoadFrom(Application.StartupPath+"/Ebada.Scgl.Model.dll"); //加载DLL

            Type[] types = ass.GetTypes();
           
            System.Type t = ass.GetType(TName);//获得类型
            PropertyInfo[] properties = t.GetProperties(); 
             foreach (PropertyInfo property in properties) 
            {
                object[] attrs =property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                string tt= (attrs[0] as DisplayNameAttribute).DisplayName;
                 tt=property.Name+tt;
                list.Add(new DicType(property.Name, tt));
            } 

            return list;
        }

        private void cobWarnType_EditValueChanged(object sender, EventArgs e)
        {
            if (cobWarnType.EditValue!=null)
            {
                string str = cobWarnType.EditValue.ToString();
                if (str == WarinType1)
                {
                    groupBox2.Enabled = true;
                    groupBox4.Enabled = false;
                    
                }
                else
                {
                    groupBox2.Enabled = false;
                    groupBox4.Enabled = true;
                }
            }
        }
       
    }
}