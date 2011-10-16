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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Ebada.Scgl.Lpgl {

    public partial class UCmLPRecord : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<LP_Record> gridViewOperation;
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
        public event SendDataEventHandler<LP_Record> FocusedRowChanged;
        private string parentID;
        private LP_Temple parentObj;
        private GridColumn picview;
        private DataTable gridtable = null;
        //private RepositoryItemImageEdit imageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        public UCmLPRecord() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<LP_Record>(gridControl1, gridView1, barManager1,new frmLP());            
            //gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeEdit);
            gridViewOperation.AfterAdd += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterEdit);
            //gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            //gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeInsert);
            //gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeUpdate);
            initColumns();
        }
     
        
        void gridViewOperation_AfterEdit(LP_Record obj)
        {

        }
        void gridViewOperation_AfterAdd(LP_Record obj)
        {

        }
        
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<LP_Record> e)
        {
            Status = "edit";
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<LP_Record> e)
        {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<LP_Record> e)
        {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(LP_Record), gridView1.Columns[i].FieldName);
            }
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["Content"].Visible = false;
            gridView1.Columns["DocContent"].Visible = false;
            gridView1.Columns["SignImg"].Visible = false;
            gridView1.Columns["SortID"].Visible = false;
            gridView1.Columns["ImageAttachment"].Visible = false;
            gridView1.Columns["Kind"].Visible = false;

            gridView1.Columns["Number"].VisibleIndex=0 ;
            gridView1.Columns["Number"].Width = 150;
            gridView1.Columns["Status"].VisibleIndex = 1;
            gridView1.Columns["Status"].Width = 100;
            gridView1.Columns["LastChangeTime"].VisibleIndex = 2;
            gridView1.Columns["LastChangeTime"].Width = 200;
            gridView1.Columns["CreateTime"].VisibleIndex = 4;
            gridView1.Columns["CreateTime"].Width = 200;


            //gridView1.Columns["OrgName"].Visible = false;
            //gridView1.Columns["Password"].ColumnEdit = repositoryItemTextEdit1;
            //repositoryItemTextEdit1.EditValueChanged += new EventHandler(repositoryItemTextEdit1_EditValueChanged);
           
            if (picview == null)
            {
                //imageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
                //((System.ComponentModel.ISupportInitialize)(this.imageEdit1)).BeginInit();
                //// 
                //// imageEdit1
                //// 
                //this.imageEdit1.AutoHeight = false;
                //this.imageEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                //this.imageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                //    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                //this.imageEdit1.Name = "imageEdit1";
                //this.imageEdit1.PopupFormSize = new System.Drawing.Size(1200, 600); 
                //((System.ComponentModel.ISupportInitialize)(this.imageEdit1)).EndInit();

                picview = new DevExpress.XtraGrid.Columns.GridColumn();
                picview.Caption = "流程图";
                picview.Visible = true;
                //picview.MaxWidth = 300;
                //picview.MinWidth = 300;
                //gridControl1.RepositoryItems.Add(imageEdit1);

                //picview.ColumnEdit = imageEdit1;
                //DevExpress.XtraEditors.Repository.RepositoryItem

                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
                this.repositoryItemHyperLinkEdit1.AutoHeight = false;
                this.repositoryItemHyperLinkEdit1.Caption = "查看";
                this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
                this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
                this.picview.Caption = "流程图";
                this.picview.ColumnEdit = this.repositoryItemHyperLinkEdit1;
                this.picview.VisibleIndex =1;
                picview.FieldName = "Image";
                gridView1.Columns.Add(picview);
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            }
            gridView1.Columns["OrgName"].Visible = false;
        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int ihand = gridView1.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridView1.GetDataRow(ihand);
            Bitmap objBitmap = RecordWorkTask.WorkFlowBitmap(dr["ID"].ToString(),new Size (1024 ,768));
            string tempPath = Path.GetTempPath();
            string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + ".png";
            if (objBitmap != null)
            {


                objBitmap.Save(tempfile,System.Drawing.Imaging.ImageFormat.Png     );
                try
                {
                    //System.Diagnostics.Process.Start("explorer.exe", tempfile);
                    SelectorHelper.Execute("rundll32.exe %Systemroot%\\System32\\shimgvw.dll,ImageView_Fullscreen "+tempfile ); 
                }
                catch {
                    
                
                }
            }
        }
  

        void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e) {
            
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<LP_Record> e)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as LP_Record);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<LP_Record> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(LP_Record newobj)
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
        public LP_Temple ParentObj {
            get { return parentObj; }
            set {
                    string str=" where 1>1";
                    parentObj = value;
                    if (value == null) {
                        str = "";
                       // parentID = null;
                       strKind = null;
                    } else {
                      // ParentID = value.LPID;
                        strKind = value.Kind;
                        
                        if (!string.IsNullOrEmpty(value.Kind)) {
                            str = string.Format("where kind='{0}'", value.Kind);
                        }
                    }
                    //gridViewOperation.RefreshData(str);
                    InitData(value.Kind);
            }
        }
        private void InitData(string kind)
        {
            string str = string.Format("where kind='{0}'", kind);             
            //gridViewOperation.RefreshData(str);
            string str2 = MainHelper.UserOrg.OrgName;
            if (str2.IndexOf("局") == -1)
            {
                str = str + " and OrgName='" + MainHelper.UserOrg.OrgName + "'";

            }
            
            if (gridtable != null) gridtable.Rows.Clear();

            IList<LP_Record> li = MainHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", str);
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
            if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(string));
            int i = 0;
            for (i = 0; i < gridtable.Rows.Count; i++)
            {

                gridtable.Rows[i]["Image"] = "查看";
            }

            gridControl1.DataSource = gridtable; 
        }
        private void btAddfrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (!RecordWorkTask.HaveRunNewGZPRole(ParentObj.Kind, MainHelper.User.UserID)) return;
            frmLP frm = new frmLP();
            LP_Record lpr = new LP_Record();
            frm.Status = "add";
            frm.Kind = ParentObj.Kind;
            frm.ParentTemple = ParentObj;

            lpr.Status = RecordWorkTask.GetGZPRecordSartStatus(ParentObj.Kind, MainHelper.User.UserID);
            //lpr.Status = "填票";
            //frm.RowData = lpr;
            frm.CurrRecord = lpr;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InitData(ParentObj.Kind);
            }
        }

        private void btEditfrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle<0)
            {
                return;
            }
           
            frmLP frm = new frmLP();
            frm.Status = "edit";
            frm.ParentTemple = ParentObj;
            frm.Kind = ParentObj.Kind;         
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "") 
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            frm.CurrRecord = currRecord;
            if (currRecord.ID.IndexOf("N") > -1)
            {
                MsgBox.ShowWarningMessageBox("此记录有新模块创建，请使用升级模块操作!");
                return;
            }
            if (!RecordWorkTask.HaveRunRecordRole(currRecord.ID, MainHelper.User.UserID)) return;
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
            frm.RecordWorkFlowData = dt;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InitData(ParentObj.Kind);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName != "Image")
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
                MainHelper.PlatformSqlMap.DeleteByWhere<LP_Record>(" where id ='" + dr["ID"].ToString() + "'");
                InitData(parentObj.Kind);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void barBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认退回 【" + dr["Number"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }

            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
           
            if (dt.Rows.Count > 0)
            {
                if (!RecordWorkTask.HaveWorkFlowBackRole(dt.Rows[0]["WorkTaskId"].ToString(), dt.Rows[0]["WorkFlowId"].ToString()))
                {
                    MsgBox.ShowWarningMessageBox("当前节点不能退回.设置里没有允许退回，退回失败!");
                    return;
                }
                string strmes = RecordWorkTask.RunWorkFlowBack(MainHelper.User.UserID, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString());
                if (strmes.IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                else
                {

                    currRecord.Status = RecordWorkTask.GetWorkFlowTaskCaption(dt.Rows[0]["WorkTaskInsId"].ToString());
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                    InitData(parentObj.Kind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            }
            else
            {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,退回失败!");
            }
        }

        private void barChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Kind != "yzgzp")
            {
                MsgBox.ShowTipMessageBox("只有一种票可以变更负责人，变更负责人失败!");
                return;
            }
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认变更 【" + dr["Number"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }

            if (currRecord.Status != "确认")
            {
                MsgBox.ShowTipMessageBox("当前节点不能变更负责人，变更负责人失败!");
                return;
            }
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
            if (dt.Rows.Count > 0)
            {
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(),"变更");
                if (strmes.IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("更改失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                else
                {


                    InitData(parentObj.Kind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            }
            else
            {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,变更负责人失败!");
            }
        }

        private void barSus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认 【" + dr["Number"].ToString() + "】 延期?") != DialogResult.OK)
            {
                return;
            }
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Status != "确认")
            {
                MsgBox.ShowTipMessageBox("当前节点不能延期，延期失败!");
                return;
            }
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
            if (dt.Rows.Count > 0)
            {
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), "延期");
                if (strmes.IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                else
                {


                    InitData(parentObj.Kind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            }
            else
            {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,延期失败!");
            }
        }
        public int[] GetCellPos(string cellpos)
        {
            cellpos = cellpos.Replace("|", "");
            return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
        }
        /// <summary>
        ///设置保护工作表
        /// </summary>
        private void LockExcel(ExcelAccess ea)
        {
            Excel.Workbook wb = ea.MyWorkBook as Excel.Workbook;
            Excel.Worksheet xx = ea.MyExcel.ActiveSheet as Excel.Worksheet;
            xx.Protect("MyPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing);
            xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            wb.SheetBeforeDoubleClick += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
        }

        protected void wb_SheetBeforeDoubleClick(object Sh, Microsoft.Office.Interop.Excel.Range Target, ref bool Cancel)
        {
            if ((bool)(Target.Locked))
            {
                Cancel = true;
            }
        }

        /// <summary>
        /// 去保护工作表
        /// </summary>
        private void unLockExcel(ExcelAccess ea)
        {
            try
            {
                Excel.Workbook wb = ea.MyWorkBook as Excel.Workbook;
                Excel.Worksheet xx = ea.MyExcel.ActiveSheet as Excel.Worksheet;
                xx.Unprotect("MyPassword");
                xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                wb.SheetBeforeDoubleClick -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            }
            catch { }
        }
        private void barReExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Status != "存档")
            {
                MsgBox.ShowTipMessageBox("安监未审核,不能导出!");
                return;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = "";
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {
                    DSOFramerControl ds1 = new DSOFramerControl();
                    ds1.FileDataGzip = currRecord.DocContent ;
                    //ds1.FileOpen(ds1.FileName);
                    ds1.FileSave(fname,true);
                    
                    ExcelAccess ea = new ExcelAccess();
                    ea.Open(fname);
                    char pchar = '|';
                    Excel.Workbook wb = ds1.AxFramerControl.ActiveDocument as Excel.Workbook;
                    Excel.Worksheet xx = wb.Application.Sheets[1] as Excel.Worksheet;
                    IList<LP_Temple> templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID ='" + ParentObj.LPID + "' and isExplorer='1' Order by SortID");
                    LockExcel(ea);
                    unLockExcel(ea);

                    foreach (LP_Temple lp in templeList)
                    {
                        string[] arrCellpos = lp.CellPos.Split(pchar);
                        for (int i = 0; i < arrCellpos.Length && arrCellpos[i] != ""; i++)
                        {
                            ea.SetCellValue("", GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1]);

                        }

                    }
                    ea.ShowExcel();
                    ds1.FileClose();
                    ds1.Dispose ();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message ); 
                    MsgBox.ShowWarningMessageBox ("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                    return;
                }
            }


        }

        private void barReChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
             DataTable dt = RecordWorkTask.GetRecordWorkFlowData2(dr["ID"].ToString());
            if (dt.Rows.Count > 0)
            {
                frmWFChange fw = new frmWFChange();
                fw.groupBox1.Text = dt.Rows[0]["FlowInsCaption"].ToString();
                fw.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                if (fw.ShowDialog() != DialogResult.OK)
                    return;
                //请求确认
                if (MsgBox.ShowAskMessageBox("确认更改 【" + dr["Number"].ToString() + "】状态为"+fw.WorkTaskCaption  +"?") != DialogResult.OK)
                {
                    return;
                }
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), fw.WorkTaskCaption);
                if (strmes.IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                else
                {


                    InitData(parentObj.Kind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            }
            else
            {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,延期失败!");
            }
        }

        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            frmTemplate fm = new frmTemplate();
            LP_Record currRecord = new LP_Record();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData2(dr["ID"].ToString());
            fm.RecordWorkFlowData = dt;
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image")
                {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }

            fm.ParentTemple = ParentObj;
            fm.pjobject = currRecord;
            fm.ShowDialog();
            InitData(parentObj.Kind);
        }

    }
}
