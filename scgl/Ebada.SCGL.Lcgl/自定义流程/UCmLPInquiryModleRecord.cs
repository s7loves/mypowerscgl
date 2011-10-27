using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCmLPInquiryModleRecord : DevExpress.XtraEditors.XtraUserControl
    {

        public UCmLPInquiryModleRecord()
        {
            InitializeComponent();
        }

        private  string tableName;
        public  string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }
        private  string keyobj;
        public  string Keyobj
        {
            get
            {
                return keyobj;
            }
            set
            {
                keyobj = value;
            }
        }
        private string strSQL = "";
        public string StrSQL
        {

            set
            {
                strSQL = value;
                InitData(strSQL);
            }
        }
        private void InitData(string strSQL)
        {

            //gridViewOperation.RefreshData(str);




            IList li = MainHelper.PlatformSqlMap.GetList("Select"+tableName+"List", strSQL);
            
            //foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView1.Columns)
            //{
            //    gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            //    gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            //}
            //if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(Bitmap));
            //if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(string));
            //int i = 0;
            //for (i = 0; i < gridtable.Rows.Count; i++)
            //{

            //    //gridtable.Rows[i]["Image"] = RecordWorkTask.WorkFlowBitmap(gridtable.Rows[i]["ID"].ToString(), imageEdit1.PopupFormSize);
            //    gridtable.Rows[i]["Image"] = "查看";
            //}

            gridControl1.DataSource = li;
        }
    }
}
