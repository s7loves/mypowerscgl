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
using Ebada.Scgl.WFlow;
using System.IO;
using DevExpress.Utils;
using Ebada.Core;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_dlwzt : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_gypdxldlwzt> gridViewOperation;

        public event SendDataEventHandler<PJ_gypdxldlwzt> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private DataTable gridtable = null;
        private bool isWorkflowCall = false;
        private GridColumn picview;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_gypdxldlwzt,LP_Record";
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
                if (isWorkflowCall)
                {
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        if (fjly == null) fjly = new frmModleFjly();
                        barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    }
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            if (wt.Description != "")
                                SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "")
                                    TaskOverButton.Caption = wt.Description;
                                liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            }

                    }

                }
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

        public UCPJ_dlwzt()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_gypdxldlwzt>(gridControl1, gridView1, barManager1, new frmdlwztEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_gypdxldlwzt>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_gypdxldlwzt>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_gypdxldlwzt>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_gypdxldlwzt>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_AfterAdd(PJ_gypdxldlwzt newobj)
        {
            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = newobj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = newobj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                currRecord.DocContent = newobj.BigData;
                MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            }
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_gypdxldlwzt> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_gypdxldlwzt> e)
        {


            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + e.Value.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_gypdxldlwzt> e)
        {
            if (parentID == null)
                e.Cancel = true;
            e.Value.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            e.Value.CreateMan = m_UserBase.RealName;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (gridtable == null)
            {
                gridtable = new DataTable();
            }
            //dt.Columns.Add
            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
            
            if (org != null)
            {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }
            

        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_gypdxldlwzt);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            //RefreshData("");
            //if (MainHelper.UserOrg != null)
            //{
            //    string strSQL = "where OrgCode='" + MainHelper.UserOrg.OrgCode + "' ";
            //    RefreshData(strSQL);
            //}


            string str = " where  1=1 ";   
            if (gridtable != null) gridtable.Rows.Clear();

            IList<PJ_gypdxldlwzt> li = MainHelper.PlatformSqlMap.GetList<PJ_gypdxldlwzt>("SelectPJ_gypdxldlwztList", str);
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((System.Collections.IList)li);

            }
            else
            {
                if (gridtable == null) gridtable = new DataTable();
                gridtable.Columns.Clear();
                gridtable.Columns.Add("OrgName");
                gridtable.Columns.Add("OrgCode");
                gridtable.Columns.Add("CreateMan");
                gridtable.Columns.Add("CreateDate", typeof(DateTime));
                gridtable.Columns.Add("Remark");
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView1.Columns)
            {
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            }
            if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image");
            int i = 0;
            for (i = 0; i < gridtable.Rows.Count; i++)
            {

                //gridtable.Rows[i]["Image"] = RecordWorkTask.WorkFlowBitmap(gridtable.Rows[i]["ID"].ToString(), imageEdit1.PopupFormSize);
                gridtable.Rows[i]["Image"] = "查看";
            }

            gridControl1.DataSource = gridtable;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(PJ_gypdxldlwzt), gridView1.Columns[i].FieldName);
            }

            picview = new DevExpress.XtraGrid.Columns.GridColumn();
            picview.Caption = "流程图";
            picview.Visible = true;
            //picview.MaxWidth = 300;
            //picview.MinWidth = 300;
            //gridControl1.RepositoryItems.Add(imageEdit1);

            //picview.ColumnEdit = imageEdit1;
            //DevExpress.XtraEditors.Repository.RepositoryItem

            //this.picview.VisibleIndex =1;
            //picview.FieldName = "Image";
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
            this.picview.VisibleIndex = 1;
            picview.FieldName = "Image";
            gridView1.Columns.Add(picview);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();

            gridView1.Columns.Add(picview);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();

          
            
            
           
            //hideColumn("OrgName");
            hideColumn("OrgCode");

            hideColumn("S1");
            hideColumn("S2");
            hideColumn("S3");
            hideColumn("BigData");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //if (isWorkflowCall)
            //{
            //    if (slqwhere == "") slqwhere = " where 1=1";
            //    slqwhere = slqwhere + " and id  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by ID desc";

            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_gypdxldlwzt> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_gypdxldlwzt newobj)
        {
           if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where OrgCode ='" + value + "'");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentID = null;
                }
                else
                {
                    ParentID = value.OrgID;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridView1.FocusedRowHandle > -1)
            //{
            //    frm25Template frm = new frm25Template();
            //    frm.pjobject = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_gypdxldlwzt;
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        Client.ClientHelper.PlatformSqlMap.Update<PJ_gypdxldlwzt>(frm.pjobject);
            //       MessageBox.Show("保存成功");
            //    }
            //}
            
        }



        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                PJ_gypdxldlwzt OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_gypdxldlwzt;
                if (OBJECT.BigData != null)
                {
                    if (OBJECT.BigData.Length != 0)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        string fname = "";
                        saveFileDialog1.Filter = "Microsoft Excel (*." + OBJECT.S1 + ")|*." + OBJECT.S1 + "";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            fname = saveFileDialog1.FileName;
                            WriteDoc(OBJECT.BigData, fname );
                        
                            if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                                return;

                            System.Diagnostics.Process.Start(fname);
                        }
                    }
                   

                }
                
            }
        }

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_gypdxldlwzt newobj = new PJ_gypdxldlwzt();
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            frmdlwztEdit frm = new frmdlwztEdit();
            frm.RowData = newobj;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MainHelper.PlatformSqlMap.Create<PJ_gypdxldlwzt>(newobj);
                InitData();
            }
        }

        private void btReRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }
        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            PJ_gypdxldlwzt currRecord = new PJ_gypdxldlwzt();
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
            frmdlwztEdit frm = new frmdlwztEdit();
            frm.RowData = currRecord;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MainHelper.PlatformSqlMap.Update<PJ_gypdxldlwzt>(currRecord);
                InitData();
            }
        }
        private void btReDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["OrgName"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }

            try
            {
                RecordWorkTask.DeleteRecord(dr["ID"].ToString());
                MainHelper.PlatformSqlMap.DeleteByWhere<PJ_gypdxldlwzt>(" where id ='" + dr["ID"].ToString() + "'");
                InitData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int ihand = gridView1.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridView1.GetDataRow(ihand);
            //Bitmap objBitmap = RecordWorkTask.WorkFlowBitmap(dr["ID"].ToString(), new Size(1024, 768));
            //string tempPath = Path.GetTempPath();
            //string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + ".png";
            //if (objBitmap != null)
            //{


                //objBitmap.Save(tempfile, System.Drawing.Imaging.ImageFormat.Png);
                try
                {
                    //System.Diagnostics.Process.Start("explorer.exe", tempfile);
                    //SelectorHelper.Execute("rundll32.exe %Systemroot%\\System32\\shimgvw.dll,ImageView_Fullscreen " + tempfile);
                    GisHelper.ShowDlt(dr["OrgCode"].ToString());
                }
                catch(Exception ex)
                {

                    MsgBox.ShowWarningMessageBox("出错："+ex.Message);
                }
            //}
        }
        public static void WriteDoc(byte[] img,  string filename)
        {
            BinaryWriter bw;
            FileStream fs;
            try
            {
                byte[] newbt = new byte[img.Length - 10];
                for (int i = 0; i < newbt.Length; i++)
                {
                    newbt[i] = img[i];
                }
                byte[] _excbt = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    _excbt[i] = img[img.Length - 10 + i];
                }
            

                fs = new FileStream( filename , FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(newbt);
                bw.Flush();
                bw.Close();
                fs.Close();
                
                //System.Diagnostics.Process.Start("C:\\" + filename + "." + Exc);
            }
            catch
            {

            }
        }
        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void TaskOverButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            if (fjly == null) fjly = new frmModleFjly();
            fjly.btn_Submit_Click(sender, e);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }

        private void liuchenBarClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strmess = "";
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联信息?") != DialogResult.OK)
            {
                return;
            }
            if (RecordWorkTask.DeleteModleRelationRecord(currRecord, WorkFlowData, ref strmess))
            {
                MsgBox.ShowTipMessageBox("清除成功");
            }
            else
            {
                MsgBox.ShowTipMessageBox("清除失败: " + strmess);
            }


        }

        private void barFJLY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName != "Image" && gridView1.FocusedColumn.FieldName != "Status")
                e.Cancel = true;

        }

    }
}
