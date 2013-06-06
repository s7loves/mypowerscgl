/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using DevExpress.XtraEditors.Repository;
using System.Data.OleDb;
using System.Threading;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCYcjcb : DevExpress.XtraEditors.XtraUserControl
    {
        GridViewOperation<xxgx_ycjc> gridviewOperation;
        private string basesql = "where 1>0";
        public UCYcjcb()
        {
            InitializeComponent();
            initImageList();
            gridviewOperation = new GridViewOperation<xxgx_ycjc>(gridControl1, gridView1, barManager1);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitCombox();
            InitColumns();//初始列
            InitData(string.Empty);//初始数据
        }

        private void InitCombox()
        {
            string sqlxl = "select distinct xlmc from xxgx_ycjc  where rtrim(ltrim(xlmc))<>'' order by xlmc";
            string sqljhdmc = "select distinct jldmc from xxgx_ycjc  where rtrim(ltrim(jldmc))<>'' order by jldmc";
            IList<string> xlList= Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlxl);
            IList<string> jhdmcList = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqljhdmc);

            RepositoryItem rItemxl;
            IList<DicType> xlDicList = new List<DicType>();
            foreach (string xlmc in xlList)
            {
                xlDicList.Add(new DicType(xlmc, xlmc));
            }
            rItemxl = new LookUpDicType(xlDicList);
            barxl.Edit = rItemxl;

            RepositoryItem rItemjhdmc;
            IList<DicType> jhdDicList = new List<DicType>();
            foreach (string jhdmc in jhdmcList)
            {
                jhdDicList.Add(new DicType(jhdmc, jhdmc));
            }
            rItemjhdmc = new LookUpDicType(jhdDicList);
            barjldmc.Edit = rItemjhdmc;
        }

        
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
       
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData(string sql)
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            if (string.IsNullOrEmpty(sql))
                sql = basesql;
            IList<xxgx_ycjc> ycjcList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<xxgx_ycjc>(sql);
            gridControl1.DataSource = ycjcList;
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            dEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dEdit.Mask.EditMask = "yyyy-MM-dd HH:mm";
            dEdit.Mask.UseMaskAsDisplayFormat = true;
            gridView1.Columns["sj"].ColumnEdit = dEdit;
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("wgdn");
        }
      
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                IList<xxgx_ycjc> pjlist = new List<xxgx_ycjc>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    xxgx_ycjc _pj = gridView1.GetRow(i) as xxgx_ycjc;
                    pjlist.Add(_pj);
                }
                ExportYcjcb.ExportExcel(pjlist);
                
            }
            else
            {
                return;
            }
        }

        private void barxl_EditValueChanged(object sender, EventArgs e)
        {
            string sql = GetSql();
            InitData(sql);
        }

        private string GetSql()
        {
            string sql = string.Empty;
            if (!string.IsNullOrEmpty(barxl.EditValue as string))
                sql += " and xlmc='"+barxl.EditValue.ToString()+"'";
            if (!string.IsNullOrEmpty(barjldmc.EditValue as string))
                sql += " and jldmc='"+barjldmc.EditValue.ToString()+"'";
            if (barStartTime.EditValue != null && barEndTime.EditValue != null)
            {
                sql += " and cast(sj as datetime) between '" + Convert.ToDateTime(barStartTime.EditValue.ToString().Substring(0, barStartTime.EditValue.ToString().Length - 3))
                    + "' and '" + Convert.ToDateTime(barEndTime.EditValue.ToString().Substring(0, barEndTime.EditValue.ToString().Length - 3))+"'";
            }
            sql = basesql + sql;
            return sql;
        }

        private void barjldmc_EditValueChanged(object sender, EventArgs e)
        {
            string sql = GetSql();
            InitData(sql);

        }

        private void barStartTime_EditValueChanged(object sender, EventArgs e)
        {
            string sql = GetSql();
            InitData(sql);
            
        }

        private void barEndTime_EditValueChanged(object sender, EventArgs e)
        {
            string sql = GetSql();
            InitData(sql);
        }

        private void btInport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            string filename = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            if (string.IsNullOrEmpty(filename))
                return;
            List<xxgx_ycjc> ycjcList = new List<xxgx_ycjc>();
            try
            {
                ycjcList = ReadExcel(filename);
            }
            catch
            {
                MsgBox.ShowWarningMessageBox("导入数据错误!请检查Excel文件格式!");
                return;
            }
            
            if (ycjcList.Count > 0)
            {
                try
                {
                    foreach (xxgx_ycjc yc in ycjcList)
                    {
                        Client.ClientHelper.PlatformSqlMap.Create<xxgx_ycjc>(yc);
                    }
                    MsgBox.ShowSuccessfulMessageBox("导入数据成功!");
                }
                catch (Exception ex)
                {
                    MsgBox.ShowWarningMessageBox("导入数据失败!");
                    //数据回滚
                    foreach (xxgx_ycjc yc in ycjcList)
                    {
                        Client.ClientHelper.PlatformSqlMap.Delete<xxgx_ycjc>(yc);
                    }
                    
                }
            }
            InitData(string.Empty);

        }


        private List<xxgx_ycjc>  ReadExcel(string sExcelFile)
        {       
            DataTable ExcelTable;
            List<xxgx_ycjc> ycjcList = new List<xxgx_ycjc>();
            DataSet ds = new DataSet();    
            //Excel的连接      
            OleDbConnection objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sExcelFile + ";" + "Extended Properties=Excel 8.0;"); 
            objConn.Open();    
            DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null); 
            string tableName = schemaTable.Rows[0][2].ToString().Trim();//获取 Excel 的表名，默认值是sheet1    
            string strSql = "select * from [" + tableName + "]";      
            OleDbCommand objCmd = new OleDbCommand(strSql, objConn);    
            OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);    
            myData.Fill(ds, tableName);//填充数据      
            objConn.Close();   
            ExcelTable = ds.Tables[tableName];
            foreach (DataRow dr in ExcelTable.Rows)
            {
                xxgx_ycjc  ycjc= new xxgx_ycjc();
                Random rd = new Random();
                ycjc.id = ycjc.id + rd.Next(1000, 10000);
                Thread.Sleep(38);
                ycjc.id += rd.Next(100, 1000);
                ycjc.sj = dr["时间"].ToString();
                ycjc.xlmc = dr["线路名称"].ToString();
                ycjc.jldmc = dr["计量点名称"].ToString();
                ycjc.bh = dr["表号"].ToString();
                ycjc.zxygzdn = getDouble(dr["正向有功总电能"].ToString());
                ycjc.fl1zxygdn = getDouble(dr["费率1正向有功电能"].ToString());
                ycjc.fl2zxygdn = getDouble(dr["费率2正向有功电能"].ToString());
                ycjc.fl3zxygdn = getDouble(dr["费率3正向有功电能"].ToString());
                ycjc.fl4zxygdn = getDouble(dr["费率4正向有功电能"].ToString());
                ycjc.fxygzdn = getDouble(dr["反向有功总电能"].ToString());
                ycjc.fl1fxygdn = getDouble(dr["费率1反向有功电能"].ToString());
                ycjc.fl2fxygdn = getDouble(dr["费率2反向有功电能"].ToString());
                ycjc.fl3fxygdn = getDouble(dr["费率3反向有功电能"].ToString());
                ycjc.fl4fxygdn = getDouble(dr["费率4反向有功电能"].ToString());
                ycjc.zxwgzdn = getDouble(dr["正向无功总电能"].ToString());
                ycjc.fl1zxwgdn = getDouble(dr["费率1正向无功电能"].ToString());
                ycjc.fl2zxwgdn = getDouble(dr["费率2正向无功电能"].ToString());
                ycjc.fl3zxwgdn = getDouble(dr["费率3正向无功电能"].ToString());
                ycjc.fl4zxwgdn = getDouble(dr["费率4正向无功电能"].ToString());
                ycjc.fxwgzdn = getDouble(dr["反向无功总电能"].ToString());
                ycjc.fl1fxwgdn = getDouble(dr["费率1反向无功电能"].ToString());
                ycjc.fl2fxwgdn = getDouble(dr["费率2反向无功电能"].ToString());
                ycjc.fl3fxwgdn = getDouble(dr["费率3反向无功电能"].ToString());
                ycjc.fl4fxwgdn = getDouble(dr["费率4反向无功电能"].ToString());
                ycjcList.Add(ycjc);
            }

            return ycjcList;
            
        }
        private double? getDouble(string str)
        {
            double? n=null;
            if (string.IsNullOrEmpty(str))
            {
                
                return n;
            }
            double retdouble = 0;
            if (!double.TryParse(str, out retdouble))
            {
                return n;
            }
            return retdouble;
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("改数据删除后不可恢复，确定要删除吗?") == DialogResult.OK)
            {
                xxgx_ycjc ycjc = gridView1.GetFocusedRow() as xxgx_ycjc;
                Client.ClientHelper.PlatformSqlMap.Delete<xxgx_ycjc>(ycjc);
                InitData(GetSql());
            }
            
        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.barxl.EditValue = null;
            this.barjldmc.EditValue = null;
            this.barStartTime.EditValue = null;
            this.barEndTime.EditValue = null;
            InitData(string.Empty);
        }

        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData(string.Empty);
        }
    
    }
}
