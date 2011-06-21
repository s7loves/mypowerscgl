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
namespace Ebada.Scgl.Lpgl
{
    public partial class frmExcelEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<LP_Temple> m_CityDic = new SortableSearchableBindingList<LP_Temple>();

        public frmExcelEdit() {
            InitializeComponent();
        }
        void dataBind() {
           
            this.textEdit2.DataBindings.Add("EditValue", rowData, "CellName");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "Kind");
            //this.dsoFramerWordControl1.DataBindings.Add("FileDataGzip", rowData, "DocContent");
            byte[] bt = new byte[0];
            rowData.ImageAttachment = bt;
            rowData.SignImg = bt;

        }
        #region IPopupFormEdit Members
        private LP_Temple rowData = null;

        public object RowData {
            get {
                byte[] bt = this.dsoFramerWordControl1.FileDataGzip;
                rowData.ImageAttachment = bt;
                rowData.SignImg = bt;             
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {                    
                    this.rowData = value as LP_Temple;               
                    this.InitComboBoxData();                    
                    dataBind();
                } else {                
                    ConvertHelper.CopyTo<LP_Temple>(value as LP_Temple, rowData);              
                    
                }
            }
        }

        #endregion
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            this.dsoFramerWordControl1.FileDataGzip = this.rowData.DocContent;
        }
        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<LP_Temple>(" WHERE Citylevel = '2'"));
            IList<DicType> list = new List<DicType>();
            list.Add(new DicType("yzgzp", "一种工作票"));
            list.Add(new DicType("ezgzp", "二种工作票"));
            list.Add(new DicType("tdczp", "停电操作票"));
            list.Add(new DicType("sdczp", "送电操作票"));
            list.Add(new DicType("xlqxp", "抢修票"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);

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

        private void frmExcelEdit_FormClosed(object sender, FormClosedEventArgs e)
        {   
            this.dsoFramerWordControl1.FileClose();
            base.Close();
        }

        private void frmExcelEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.dsoFramerWordControl1.FileSave();            
            rowData.DocContent = this.dsoFramerWordControl1.FileDataGzip;          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {       
            this.dsoFramerWordControl1.FileClose();
        }

       
    }
}