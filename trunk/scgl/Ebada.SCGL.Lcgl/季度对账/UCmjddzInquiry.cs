/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-2-28
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
using Ebada.Core;
using System.Collections;
using Ebada.Scgl.WFlow;
using DevExpress.XtraEditors.Repository;
using Ebada.Scgl.Core;
using DevExpress.Utils;
using System.IO;
using Ebada.UI.Base;
using DevExpress.XtraBars;
using Ebada.Components;
using Ebada.SCGL.WFlow.Tool;
using System.Threading;

namespace Ebada.Scgl.Lcgl {

    public partial class UCmjddzInquiry : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_clcrkd> gridViewOperation;
        private static string strKind;
        public static string GetParentKind()
        {
            return strKind;
        }
        private static string status;
        public static string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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
        private string strOrgName = "";
        public string StrOrgName
        {

            set
            {
                strOrgName = value;
               
            }
        }
        public event SendDataEventHandler<PJ_clcrkd> FocusedRowChanged;
        private string parentID;
       
        private DataTable gridtable = null;
        //private RepositoryItemImageEdit imageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        public UCmjddzInquiry()
        {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<PJ_clcrkd>(gridControl1, gridView1, barManager1,new frmLP());            
            //gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            //gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_clcrkd>(gridViewOperation_BeforeAdd);
            //gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_clcrkd>(gridViewOperation_BeforeEdit);
            //gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_clcrkd>(gridViewOperation_AfterAdd);
            //gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_clcrkd>(gridViewOperation_AfterEdit);
            //gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            //gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<PJ_clcrkd>(gridViewOperation_BeforeInsert);
            //gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_clcrkd>(gridViewOperation_BeforeUpdate);
            initColumns();
        }
     
        
        void gridViewOperation_AfterEdit(PJ_clcrkd obj)
        {

        }
        void gridViewOperation_AfterAdd(PJ_clcrkd obj)
        {

        }
        
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_clcrkd> e)
        {
            Status = "edit";
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_clcrkd> e)
        {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<PJ_clcrkd> e)
        {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            

            
        }
        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            

        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int ihand = gridView1.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridView1.GetDataRow(ihand);
            Bitmap objBitmap = RecordWorkTask.WorkFlowBitmap(dr["ID"].ToString(), new Size(1024, 768));
            string tempPath = Path.GetTempPath();
            string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + ".png";
            if (objBitmap != null)
            {


                objBitmap.Save(tempfile, System.Drawing.Imaging.ImageFormat.Png);
                try
                {
                    //System.Diagnostics.Process.Start("explorer.exe", tempfile);
                    SelectorHelper.Execute("rundll32.exe %Systemroot%\\System32\\shimgvw.dll,ImageView_Fullscreen " + tempfile);
                }
                catch
                {


                }
            }
        }
  
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_clcrkd> e)
        {
            Status = "add";
            //if (string.IsNullOrEmpty(parentID)) {
            //    e.Cancel = true;
            //    MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");
            //}
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_clcrkd);
            //获得编辑按钮的状态
            if (gridView1.FocusedRowHandle>-1)
            {
               DataRow dr = gridView1.GetFocusedDataRow();

               this.btEditfrm.Caption = dr["Status"].ToString();
            }
            
           
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_clcrkd> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_clcrkd newobj)
        {

        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                
                string str=" where 1>1";
                if (value == "") {
                    str = "";
                    parentID = null;
                } else {
                    parentID = value;

                    if (!string.IsNullOrEmpty(parentID)) {
                        str = string.Format("where kind='{0}'", parentID);
                    }
                }
                //gridViewOperation.RefreshData(str);
                InitData(parentID);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  
        private void InitData(string kind)
        {
            //gridViewOperation.RefreshData(kind);
            if (gridtable != null) gridtable.Rows.Clear();

            IList<PJ_clcrkd> li = MainHelper.PlatformSqlMap.GetList<PJ_clcrkd>("SelectPJ_clcrkdList", strSQL + "  order by type,cast( indate as datetime)");
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((IList)li);

            }
            else
            {
                if (gridtable == null) gridtable = new DataTable();
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView1.Columns)
            {
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            }
            if (!gridtable.Columns.Contains("xh")) gridtable.Columns.Add("xh", typeof(string));
            if (!gridtable.Columns.Contains("wpjz")) gridtable.Columns.Add("wpjz", typeof(string));
            int i = 1;
            double dsum1 = 0;//入库单
            double dsum2 = 0;//出库单
            double dsum3 = 0;//材料单
            double dsum4 = 0;//库存单
            double djzsum1 = 0;//入库单
            double djzsum2 = 0;//出库单
            double djzsum3 = 0;//材料单
            double djzsum4 = 0;//材料单
            bool bfind1 = false;//入库单
            bool bfind2 = false;//出库单
            bool bfind3 = false;//材料单
            foreach (DataRow dr in gridtable.Rows)
            {
                dr["xh"] = i++;
                if (dr["wpsl"].ToString() == "") dr["wpsl"] = 0;
                if (dr["wpdj"].ToString() == "") dr["wpdj"] = 0;
                if (dr["type"].ToString().IndexOf ("入库单")>0)
                {
                    dsum1 += Convert.ToDouble(dr["wpsl"]);
                    dr["wpjz"] = Convert.ToDouble(dr["wpsl"]) * Convert.ToDouble(dr["wpdj"]);
                    djzsum1 += Convert.ToDouble(dr["wpjz"]);
                    dsum4 += Convert.ToDouble(dr["kcsl"]) ;
                    djzsum4 += Convert.ToDouble(dr["kcsl"]) * Convert.ToDouble(dr["wpdj"]);
                    bfind1=true;
                }
                else
                    if (dr["type"].ToString().IndexOf("出库单") > 0)
                    {

                        dsum2 += Convert.ToDouble(dr["cksl"]);
                        dr["wpjz"] = Convert.ToDouble(dr["cksl"]) * Convert.ToDouble(dr["wpdj"]);
                        djzsum2 += Convert.ToDouble(dr["wpjz"]);
                        bfind2 = true;
                    }
                    else
                        if (dr["type"].ToString().IndexOf("材料单") > 0)
                        {

                            dsum3 += Convert.ToDouble(dr["cksl"]);
                            dr["wpjz"] = Convert.ToDouble(dr["cksl"]) * Convert.ToDouble(dr["wpdj"]);
                            djzsum3 += Convert.ToDouble(dr["wpjz"]);
                            bfind3 = true;
                        }

            }
            
            if (bfind1)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "入库单";
                dr1["wpmc"] = "入库合计";
                dr1["wpsl"] = dsum1;
                dr1["wpjz"] = djzsum1;
                gridtable.Rows.Add(dr1);
            }
            if (bfind2)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "出库单";
                dr1["wpmc"] = "出库合计";
                dr1["wpsl"] = dsum2;
                dr1["wpjz"] = djzsum2;
                gridtable.Rows.Add(dr1);
            }
            if (bfind3)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "材料单";
                dr1["wpmc"] = "出库合计";
                dr1["wpsl"] = dsum3;
                dr1["wpjz"] = djzsum3;
                gridtable.Rows.Add(dr1);
            }
            if (gridtable.Rows.Count > 0)
            {
                DataRow dr2 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr2["type"] = "现有库存";
                dr2["wpmc"] = "库存合计";
                dr2["wpsl"] = dsum4;
                dr2["wpjz"] = djzsum4;
                gridtable.Rows.Add(dr2);
                IList wpli = MainHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select distinct wpmc from PJ_clcrkd {0} ", strSQL));
                foreach (string wpmc in wpli)
                {
                    IList wpggli = MainHelper.PlatformSqlMap.GetList("SelectOneStr",
                   string.Format("select distinct wpgg from PJ_clcrkd {0} ", strSQL));
                    string stryskc = "",//原始库存
                     strjzyskc = "",//原始库存价值

                     strrks = "",//入库数
                     strjzrks = "",//入库数价值

                     strcks = "",//出库数 
                     strjzcks = "",//出库数价值

                     strxykc = "",//现有库存
                    strjzxykc = "";//现有库存价值
                    List<string> sli = new List<string>();
                    sli.Add("工程材料");
                    sli.Add("撤旧材料");
                    sli.Add("非生产物资");
                    foreach (string strtype in sli)
                    {
                        if (strSQL.IndexOf(strtype) < 0 && strSQL.IndexOf("type") > -1) continue;
                        foreach (string wpgg in wpggli)
                        {
                            stryskc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select wpsl from PJ_clcrkd where  wpmc='{0}' and wpgg='{1}'  and type = '{2}原始库存' ",
                                wpmc, wpgg, strtype));
                            strjzyskc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as int)*cast(wpdj as float)) as nvarchar(50)) from PJ_clcrkd where  wpmc='{0}' and wpgg='{1}'  and type = '{2}原始库存' ", wpmc, wpgg, strtype));

                            strrks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as int)) as nvarchar(50)) from PJ_clcrkd   {2}  and wpmc='{0}' and wpgg='{1}'  and type = '{3}入库单' ",
                                 wpmc, wpgg, strSQL, strtype));
                            strjzrks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as int)*cast(wpdj as float)) as nvarchar(50)) from PJ_clcrkd   {2}  and wpmc='{0}' and wpgg='{1}'  and type = '{3}入库单' ", wpmc, wpgg, strSQL, strtype));

                            strcks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(cksl as int)) as nvarchar(50))  from PJ_clcrkd   {2} and  wpmc='{0}' and wpgg='{1}'  and type='{3}出库单' ",
                                wpmc, wpgg, strSQL, strtype));
                            strjzcks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(cksl as int)*cast(wpdj as float)) as nvarchar(50))  from PJ_clcrkd   {2} and  wpmc='{0}' and wpgg='{1}'  and type='{3}出库单' ",
                                wpmc, wpgg, strSQL, strtype));

                            strxykc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(kcsl as int)) as nvarchar(12))  from PJ_clcrkd {2} and  wpmc='{0}' and wpgg='{1}' and type = '{3}入库单'   ",
                                wpmc, wpgg, strSQL, strtype));
                            strjzxykc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(kcsl as int)*cast(wpdj as float)) as nvarchar(50))  from PJ_clcrkd {2} and  wpmc='{0}' and wpgg='{1}' and type = '{3}入库单' ",
                                wpmc, wpgg, strSQL, strtype));

                            DataRow dr1;
                            if (strSQL.IndexOf("type") == -1 || strSQL.IndexOf("%" + strtype + "%") > 0 || strSQL.IndexOf("入库单") > 0)
                            {
                                dr1 = gridtable.NewRow();
                                //dr1["xh"] = i++;x
                                dr1["type"] = strtype + "入库单合计";
                                dr1["wpmc"] = wpmc;
                                dr1["wpgg"] = wpgg;
                                dr1["wpsl"] = strrks;
                                dr1["wpjz"] = strjzrks;
                                gridtable.Rows.Add(dr1);
                            }

                            if (strSQL.IndexOf("type") == -1 || strSQL.IndexOf("%" + strtype + "%") > 0 || strSQL.IndexOf("出库单") > 0)
                            {
                                dr1 = gridtable.NewRow();
                                dr1["type"] = strtype + "出库单合计";
                                dr1["wpmc"] = wpmc;
                                dr1["wpgg"] = wpgg;
                                dr1["wpsl"] = strcks;
                                dr1["wpjz"] = strjzcks;
                                gridtable.Rows.Add(dr1);
                            }


                            dr1 = gridtable.NewRow();
                            dr1["type"] = strtype + "原始库存";
                            dr1["wpmc"] = wpmc;
                            dr1["wpgg"] = wpgg;
                            dr1["wpsl"] = stryskc;
                            dr1["wpjz"] = strjzyskc;
                            gridtable.Rows.Add(dr1);



                            dr1 = gridtable.NewRow();
                            dr1["type"] = strtype + "现有库存";
                            dr1["wpmc"] = wpmc;
                            dr1["wpgg"] = wpgg;
                            dr1["wpsl"] = strxykc;
                            dr1["wpjz"] = strjzxykc;
                            gridtable.Rows.Add(dr1);


                        }

                    }
                }
            }
            gridControl1.DataSource = gridtable; 
        }

   
   
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName != "Image" && gridView1.FocusedColumn.FieldName != "Status")
                e.Cancel = true;
        }

        private void btDeletefrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["Number"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }

            try
            {


                RecordWorkTask.DeleteRecord(dr["ID"].ToString());
                MainHelper.PlatformSqlMap.DeleteByWhere<PJ_clcrkd>(" where id ='" + dr["ID"].ToString() + "'");
                InitData(strKind);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void barBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barSus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private string CheckFileName(string filename)
        {
            
            return "";
        }
      
    
        private void btRefresh1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData(strKind);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
        }

        private void btReExport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

   
   

    }
}
