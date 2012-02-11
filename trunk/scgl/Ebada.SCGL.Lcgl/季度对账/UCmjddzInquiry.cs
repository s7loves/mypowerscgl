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
       
        private DataTable gridtable = null;
        //private RepositoryItemImageEdit imageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        public UCmjddzInquiry()
        {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<LP_Record>(gridControl1, gridView1, barManager1,new frmLP());            
            //gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            //gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeAdd);
            //gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeEdit);
            //gridViewOperation.AfterAdd += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterAdd);
            //gridViewOperation.AfterEdit += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterEdit);
            //gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            //gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeInsert);
            //gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeUpdate);
            //initColumns();
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
            

            //gridView1.Columns["OrgName"].Visible = false;
            //gridView1.Columns["Password"].ColumnEdit = repositoryItemTextEdit1;
            //repositoryItemTextEdit1.EditValueChanged += new EventHandler(repositoryItemTextEdit1_EditValueChanged);
            //((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            //if (picview == null)
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

                
                //picview.MaxWidth = 300;
                //picview.MinWidth = 300;
                //gridControl1.RepositoryItems.Add(imageEdit1);

                //picview.ColumnEdit = imageEdit1;
                //DevExpress.XtraEditors.Repository.RepositoryItem

                //this.picview.VisibleIndex =1;
                //picview.FieldName = "Image";
                
            }
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
  
        private void InitData(string kind)
        {
           
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
                MainHelper.PlatformSqlMap.DeleteByWhere<LP_Record>(" where id ='" + dr["ID"].ToString() + "'");
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
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as LP_Record);
            //获得编辑按钮的状态
            this.btEditfrm.Caption = (gridView1.GetFocusedRow() as LP_Record).Status;
        }

   
        void copyData(LP_Temple lp,IList<LP_Temple> templeList)
        {
            if (templeList.Count == 0) return;
             string flowid=lp.ParentID;
            int i = 1;
            List<LP_Temple> list = new List<LP_Temple>();
            string workflowid = flowid;
            IList<WF_WorkTask> wftli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where WorkFlowId='" + workflowid + "' and  TaskTypeId!='2' order by TaskTypeId");
            foreach (WF_WorkTask wft in wftli)
            {
                //保存关联模块
                WorkFlowTask.DeleteAllModle(wft.WorkTaskId);
                mModule mu = MainHelper.PlatformSqlMap.GetOne<mModule>("where ModuName='表单执行平台'  and ModuTypes='Ebada.Scgl.Lcgl.frmLP'");
                WorkFlowTask.SetTaskUserModle(mu.Modu_ID, wft.WorkFlowId, wft.WorkTaskId);
                //保存关联表单
                WorkFlowTask.DeleteAllControls(wft.WorkTaskId);
                WorkFlowTask.DeleteAllTableField(wft.WorkFlowId, wft.WorkTaskId);
                string sqlStr = " where  WorkTaskId='" + wft.WorkTaskId + "'";

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskControls>(sqlStr);
                WorkFlowTask.SetTaskUserCtrls(templeList[0].ParentID, workflowid, wft.WorkTaskId);
            }
            i = 1;
            foreach (LP_Temple obj in templeList)
            {
                obj.SortID = i;
                if (obj.SignImg == null)
                {
                    obj.SignImg = new byte[0];
                }
                if (obj.ImageAttachment == null)
                {
                    obj.ImageAttachment = new byte[0];
                }
                if (obj.DocContent == null)
                {
                    obj.DocContent = new byte[0];
                }
                i++;
                if (obj.CellName == "6.3 其他安全措施和注意事项" && obj.Status=="")
                {
                    obj.Status = "填票";
                }
                
                if (obj.CellName.IndexOf("终了时间") > -1)
                {
                    obj.WordCount = "dd日 HH:mm";
                }
                else
                    if (obj.CellName.IndexOf("同意执行时间") > -1)
                    {
                        obj.WordCount = "MM-dd日 HH:mm";
                    }
                    else
                    if (obj.CellName.IndexOf("时间") > -1)
                        {
                            obj.WordCount = "yyyy-MM-dd HH:mm";
                        }

                if (obj.SqlSentence == "SelectmOrgList where parentid='0'")
                {
                    obj.SqlSentence = "Select OrgName  from mOrg where parentid='0'";
                    obj.SqlColName = "";
                }

                if (obj.SqlSentence.IndexOf( "SelectmUserList where  OrgName ='@1'")>-1)
                {
                    obj.SqlSentence = "Select UserName  from mUser where OrgName='{1}'";
                    obj.SqlColName = "";
                }
                
                if (lp.CellName == "电力线路第一种工作票")
                {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "工作票";
                    }
                }
                if (lp.CellName == "电力线路第二种工作票")
                {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "Sheet1";
                    }
                }

                if (lp.CellName == "电力线路倒闸操作票")
                {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "Sheet1";
                    }
                }
                if (lp.CellName == "电力线路事故应急抢修单")
                {
                    if (obj.KindTable == "")
                    {
                        obj.KindTable = "Sheet1";
                    }
                }


                if (obj.SqlSentence == "SelectmOrgList where parentid=(select OrgID From mOrg where OrgName='@1')")
                //if (obj.SqlSentence == "Select OrgName  from mOrg where  parentid=(select OrgID From mOrg where OrgName={1})")
                {
                    obj.SqlSentence = "Select OrgName  from mOrg where  parentid=(select OrgID From mOrg where OrgName='{1}')";
                    obj.SqlColName = "";
                }
                WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOne<WF_WorkTask>(
                    "where WorkFlowId='" + workflowid + "'  and TaskCaption='" + obj.Status + "'");
                if (wt == null)
                {
                    continue;
                }
                WF_TableUsedField tuf = MainHelper.PlatformSqlMap.GetOne<WF_TableUsedField>("where FieldName='" + obj.CellName +
                    "'  and UserControlId='" + obj.ParentID + "'");
                if (tuf == null)
                {
                    WF_TableUsedField um = new WF_TableUsedField();
                    um.ID = um.CreateID();
                    um.UserControlId = obj.ParentID;
                    um.FieldName = obj.CellName;
                    um.FieldId = obj.LPID;
                    um.WorkflowId = workflowid;
                    um.WorktaskId = wt.WorkTaskId;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    MainHelper.PlatformSqlMap.Create<WF_TableUsedField>(um);
                }
                list.Add(obj);
            }
            List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            if (list.Count > 0)
            {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
           
        
        }
        private void barCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            //CreatWF_TableFieldValueView
            //MainHelper.PlatformSqlMap.Update("CreatWF_TableFieldValueView",null);
          LP_Temple temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路第一种工作票'  and Status=''");
          IList<LP_Temple> templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
              "where ParentID ='" + temple.LPID + "' Order by SortID");
          copyData(temple,templeList);
        temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路第二种工作票'  and Status=''");
        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
              "where ParentID ='" + temple.LPID + "' Order by SortID");
        copyData(temple,templeList);
        temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路倒闸操作票'  and Status=''");
        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
              "where ParentID ='" + temple.LPID + "' Order by SortID");
        copyData(temple,templeList);
        temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路事故应急抢修单'  ");
        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
              "where ParentID ='" + temple.LPID + "' Order by SortID");
        copyData(temple,templeList);
        MsgBox.ShowTipMessageBox("执行完毕");
        }

    }
}
