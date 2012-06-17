﻿/**********************************************
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

    public partial class UCmLPRecord : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<LP_Record> gridViewOperation;
        private static string strKind;
        public static string GetParentKind() {
            return strKind;
        }
        private static string status;
        public static string Status {
            get {
                return status;
            }
            set {
                status = value;
            }
        }
        public event SendDataEventHandler<LP_Record> FocusedRowChanged;
        private string parentID;
        private WF_WorkFlow parentObj;
        private GridColumn picview;
        private DataTable gridtable = null;
        //private RepositoryItemImageEdit imageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        public UCmLPRecord() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<LP_Record>(gridControl1, gridView1, barManager1, new frmLP());
            //gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeEdit);
            gridViewOperation.AfterAdd += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<LP_Record>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            //gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeInsert);
            //gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeUpdate);
            initColumns();
        }
        DSOFramerControl ds1 = null;

        void gridViewOperation_AfterEdit(LP_Record obj) {

        }
        void gridViewOperation_AfterAdd(LP_Record obj) {

        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<LP_Record> e) {
            Status = "edit";
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<LP_Record> e) {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<LP_Record> e) {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            for (int i = 0; i < gridView1.Columns.Count; i++) {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(LP_Record), gridView1.Columns[i].FieldName);
            }
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["Content"].Visible = false;
            gridView1.Columns["DocContent"].Visible = false;
            gridView1.Columns["SignImg"].Visible = false;
            gridView1.Columns["SortID"].Visible = false;
            gridView1.Columns["ImageAttachment"].Visible = false;
            gridView1.Columns["Kind"].Visible = false;

            gridView1.Columns["Number"].VisibleIndex = 0;
            gridView1.Columns["Number"].Width = 150;
            gridView1.Columns["Status"].VisibleIndex = 1;
            gridView1.Columns["Status"].Width = 100;
            //gridView1.Columns["LastChangeTime"].VisibleIndex = 2;
            //gridView1.Columns["LastChangeTime"].Width = 200;
            //gridView1.Columns["CreateTime"].VisibleIndex = 4;
            //gridView1.Columns["CreateTime"].Width = 200;
            gridView1.Columns["LastChangeTime"].VisibleIndex = -1;
            gridView1.Columns["CreateTime"].VisibleIndex = -1;

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

                picview = new DevExpress.XtraGrid.Columns.GridColumn();
                picview.Caption = "流程";
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
                this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
                this.repositoryItemHyperLinkEdit1.AutoHeight = false;
                this.repositoryItemHyperLinkEdit1.Caption = "查看";
                this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
                this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
                this.picview.Caption = "流程图";
                this.picview.ColumnEdit = this.repositoryItemHyperLinkEdit1;
                this.picview.VisibleIndex = 1;
                picview.FieldName = "Image";
                gridView1.Columns.Add(picview);
                this.gridView1.Columns["Status"].ColumnEdit = this.repositoryItemHyperLinkEdit2;
                this.repositoryItemHyperLinkEdit2.AutoHeight = false;
                this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
                this.repositoryItemHyperLinkEdit2.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit2_Click);
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();

                gridView1.Columns.Add(picview);
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            }
        }
        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e) {
            btEditfrm_ItemClick(sender, null);

        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e) {
            int ihand = gridView1.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridView1.GetDataRow(ihand);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
            frmViewTemplate fm = new frmViewTemplate();
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
            fm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(dt, currRecord);
            fm.CurrRecord = currRecord;
            fm.Kind = strKind;
            fm.Status = "edit";
            fm.ShowDialog();
            //Bitmap objBitmap = RecordWorkTask.WorkFlowBitmap(dr["ID"].ToString(), new Size(1024, 768));
            //string tempPath = Path.GetTempPath();
            //string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + ".png";
            //if (objBitmap != null)
            //{


            //    objBitmap.Save(tempfile, System.Drawing.Imaging.ImageFormat.Png);
            //    try
            //    {
            //        //System.Diagnostics.Process.Start("explorer.exe", tempfile);
            //        SelectorHelper.Execute("rundll32.exe %Systemroot%\\System32\\shimgvw.dll,ImageView_Fullscreen " + tempfile);
            //    }
            //    catch
            //    {


            //    }
            //}
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<LP_Record> e) {
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
            if (gridView1.FocusedRowHandle > -1) {
                DataRow dr = gridView1.GetFocusedDataRow();

                this.btEditfrm.Caption = dr["Status"].ToString();
            }


        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<LP_Record> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(LP_Record newobj) {

        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {

                string str = " where 1>1";
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
        public WF_WorkFlow ParentObj {
            get { return parentObj; }
            set {
                string str = " where 1>1";
                parentObj = value;
                if (value == null) {
                    str = "";
                    // parentID = null;
                    strKind = null;
                    InitData("");
                } else {
                    // ParentID = value.LPID;
                    //if (value.FlowCaption == "电力线路倒闸操作票")
                    //{
                    //    strKind = "dzczp";
                    //    InitData("dzczp");
                    //}
                    //else if (value.FlowCaption == "电力线路第一种工作票")
                    //{
                    //    strKind = "yzgzp";
                    //    InitData("yzgzp");
                    //}
                    //else if (value.FlowCaption == "电力线路第二种工作票")
                    //{
                    //    strKind = "ezgzp";
                    //    InitData("ezgzp");
                    //}
                    //else if (value.FlowCaption == "电力线路事故应急抢修单")
                    //{
                    //    strKind = "xlqxp";
                    //    InitData("xlqxp");
                    //}
                    //else
                    {
                        strKind = value.FlowCaption;
                        InitData(value.FlowCaption);
                    }
                }
                //gridViewOperation.RefreshData(str);

            }
        }
        private void InitData(string kind) {
            string str = "";
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();

            mUser user = MainHelper.PlatformSqlMap.GetOne<mUser>(" where UserID='" + m_UserBase.UserID + "'");
            //gridViewOperation.RefreshData(str);
            if (kind == "电力线路倒闸操作票" || kind == "dzczp") {
                strKind = "dzczp";
                str = string.Format("where kind='{0}' or kind='dzczp' and OrgName='{1}'", kind, user.OrgName);
                if (m_UserBase.LoginName != "rabbit" && user.OrgName.IndexOf("安全监察部") == -1 && user.OrgName.IndexOf("局领导") == -1)
                    str = string.Format("where (kind='{0}' or kind='dzczp'and OrgName='{1}')", kind, user.OrgName);
                else
                    str = string.Format("where kind='{0}' or kind='dzczp'", kind);
            } else if (kind == "电力线路第一种工作票" || kind == "yzgzp") {
                strKind = "yzgzp";
                if (m_UserBase.LoginName != "rabbit" && user.OrgName.IndexOf("安全监察部") == -1 && user.OrgName.IndexOf("局领导") == -1)
                    str = string.Format("where (kind='{0}' or kind='yzgzp') and OrgName='{1}'", kind, user.OrgName);
                else
                    str = string.Format("where kind='{0}' or kind='yzgzp'", kind);

            } else if (kind == "电力线路第二种工作票" || kind == "ezgzp") {
                strKind = "ezgzp";
                if (m_UserBase.LoginName != "rabbit" && user.OrgName.IndexOf("安全监察部") == -1 && user.OrgName.IndexOf("局领导") == -1)
                    str = string.Format("where (kind='{0}' or kind='ezgzp') and OrgName='{1}'", kind, user.OrgName);
                else
                    str = string.Format("where kind='{0}' or kind='ezgzp'", kind);
            } else if (kind == "电力线路事故应急抢修单" || kind == "xlqxp") {
                strKind = "xlqxp";
                if (m_UserBase.LoginName != "rabbit" && user.OrgName.IndexOf("安全监察部") == -1 && user.OrgName.IndexOf("局领导") == -1)
                    str = string.Format("where (kind='{0}' or kind='xlqxp') and OrgName='{1}'", kind, user.OrgName);
                else
                    str = string.Format("where (kind='{0}' or kind='xlqxp')", kind);
            } else {
                strKind = kind;
                //if (MainHelper.User.UserName != "rabbit" && user.OrgName.IndexOf("安全监察部") == -1 && user.OrgName.IndexOf("局领导") == -1)
                //    str = string.Format("where kind='{0}' and OrgName='{1}'", kind, user.OrgName);
                //else
                str = string.Format("where kind='{0}' ", kind);
            }
            str = str + " order by CreateTime desc";
            if (gridtable != null) gridtable.Rows.Clear();

            IList<LP_Record> li = MainHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", str);
            if (li.Count != 0) {
                gridtable = ConvertHelper.ToDataTable((IList)li);

            } else {
                if (gridtable == null) gridtable = new DataTable();
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView1.Columns) {
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            }
            //if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(Bitmap));
            if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(string));
            int i = 0;
            for (i = 0; i < gridtable.Rows.Count; i++) {

                //gridtable.Rows[i]["Image"] = RecordWorkTask.WorkFlowBitmap(gridtable.Rows[i]["ID"].ToString(), imageEdit1.PopupFormSize);
                gridtable.Rows[i]["Image"] = "查看";
            }

            gridControl1.DataSource = gridtable;
            if (parentObj == null) return;
            object obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where PowerName='全程跟踪' and WorkFlowId='" + parentObj.WorkFlowId + "' and WorkTaskId='" + parentObj.WorkFlowId + "'");
            if (obj == null) {
                barView.Visibility = BarItemVisibility.Never;
            } else {
                barView.Visibility = BarItemVisibility.Always;
            }
            if (parentObj.FlowCaption == "电力线路第一种工作票") {
                barChange.Visibility = BarItemVisibility.Always;
                barSus.Visibility = BarItemVisibility.Always;
            } else {
                barChange.Visibility = BarItemVisibility.Never;
                barSus.Visibility = BarItemVisibility.Never;
            }

        }
        private void btAddfrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MainHelper.UserOrg == null) return;

            if (!RecordWorkTask.HaveRunNewGZPRole(strKind, MainHelper.User.UserID)) return;
            DataTable recordWorkFlowData = null;
            object obj = RecordWorkTask.GetNewWorkTaskModle(strKind, MainHelper.User.UserID);
            if (obj == null) {
                MsgBox.ShowWarningMessageBox("出错，未找到对应的模块，请检查模板设置!");
                return;
            }
            LP_Record lpr = new LP_Record();
            lpr.ID = "N" + lpr.CreateID();
            lpr.Kind = strKind;
            lpr.CreateTime = DateTime.Now.ToString();
            lpr.OrgName = MainHelper.UserOrg.OrgName;
            if (obj is frmLP) {
                frmLP frm = new frmLP();
                frm.strxiestatus = "add";
                frm.Status = "add";
                frm.Kind = strKind;
                string[] strtemp = RecordWorkTask.RunNewGZPRecord(lpr.ID, strKind, MainHelper.User.UserID, false);

                //frm.ParentTemple = RecordWorkTask.GetNewWorkTaskTemple(strKind, MainHelper.User.UserID);

                //frm.RecordWorkFlowData = RecordWorkTask.GetGZPRecordSartWorkData(ParentObj.FlowCaption, MainHelper.User.UserID);
                frm.RecordWorkFlowData = RecordWorkTask.GetRecordWorkFlowData(lpr.ID, MainHelper.User.UserID);
                recordWorkFlowData = frm.RecordWorkFlowData;
                if (frm.RecordWorkFlowData == null) {
                    MsgBox.ShowWarningMessageBox("出错，未找到该流程信息，请检查模板设置!");
                }
                frm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(frm.RecordWorkFlowData, lpr);
                if (frm.ParentTemple == null) {
                    MsgBox.ShowWarningMessageBox("出错，未找到该节点关联的表单，请检查模板设置!");
                }
                lpr.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg, frm.ParentTemple.LPID, lpr.Kind);
                lpr.Status = frm.RecordWorkFlowData.Rows[0]["TaskCaption"].ToString();
                //lpr.Status = "填票";
                //frm.RowData = lpr;
                frm.CurrRecord = lpr;
                MainHelper.PlatformSqlMap.Create<LP_Record>(lpr);
                frm.ShowDialog();
                InitData(strKind);
            } else {


                string[] strtemp = RecordWorkTask.RunNewGZPRecord(lpr.ID, strKind, MainHelper.User.UserID, false);
                if (strtemp[0].IndexOf("未提交至任何人") > -1) {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                recordWorkFlowData = RecordWorkTask.GetRecordWorkFlowData(lpr.ID, MainHelper.User.UserID);
                if (recordWorkFlowData == null) {
                    MsgBox.ShowWarningMessageBox("出错，未找到该流程信息，请检查模板设置!");

                }
                LP_Temple ParentTemple = RecordWorkTask.GetWorkTaskTemple(recordWorkFlowData, lpr);
                if (ParentTemple == null)
                    lpr.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg,"", strKind);
                else
                    lpr.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg, ParentTemple.LPID,strKind);

                lpr.Status = recordWorkFlowData.Rows[0]["TaskCaption"].ToString();
                MainHelper.PlatformSqlMap.Create<LP_Record>(lpr);

                if (obj.GetType().GetProperty("IsWorkflowCall") != null)
                    obj.GetType().GetProperty("IsWorkflowCall").SetValue(obj, true, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }
                if (obj.GetType().GetProperty("CurrRecord") != null)
                    obj.GetType().GetProperty("CurrRecord").SetValue(obj, lpr, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }


                if (obj.GetType().GetProperty("ParentTemple") != null)
                    obj.GetType().GetProperty("ParentTemple").SetValue(obj, ParentTemple, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }

                if (obj.GetType().GetProperty("RecordWorkFlowData") != null)
                    obj.GetType().GetProperty("RecordWorkFlowData").SetValue(obj, recordWorkFlowData, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }

                if (obj is UserControl) {
                    FormBase dlg = new FormBase();
                    dlg.Text = ((UserControl)obj).Name;
                    dlg.MdiParent = MainHelper.MainForm;
                    dlg.Controls.Add((UserControl)obj);
                    ((UserControl)obj).Dock = DockStyle.Fill;
                    dlg.Show();
                } else
                    if (obj is Form) {
                        if (obj is frmyxfxWorkFlowEdit) {
                            PJ_03yxfx yxfx = new PJ_03yxfx();
                            yxfx.OrgCode = MainHelper.UserOrg.OrgCode;
                            yxfx.OrgName = MainHelper.UserOrg.OrgName;
                            if (parentObj.FlowCaption.IndexOf("定期分析") > 0)
                                yxfx.type = "定期分析";
                            else
                                if (parentObj.FlowCaption.IndexOf("专题分析") > 0)
                                    yxfx.type = "专题分析";
                            ((frmyxfxWorkFlowEdit)obj).RecordStatus = 0;
                            yxfx.rq = DateTime.Now;
                            ((frmyxfxWorkFlowEdit)obj).RowData = yxfx;

                        } else if (obj is frmsbqxWorkFlowEdit) {

                            PJ_qxfl qxfl = new PJ_qxfl();
                            qxfl = new PJ_qxfl();
                            qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                            qxfl.OrgName = MainHelper.UserOrg.OrgName;
                            ((frmsbqxWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmWorkFlow06sbxsEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_06sbxsmx'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_06sbxsmx qxfl = new PJ_06sbxsmx();
                            if (li.Count > 0) {
                                PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);


                                qxfl = MainHelper.PlatformSqlMap.GetOne<PJ_06sbxsmx>(" where CONVERT(varchar, CreateDate, 120 ) =  '" + qxfltemp.CreateDate + "'"
                                    + " and LineID='" + qxfltemp.LineID + "'"
                                    + " and OrgCode='" + qxfltemp.OrgCode + "'"
                                     + " and qxlb='" + qxfltemp.qxlb + "'"
                                     + " and xsr='" + qxfltemp.xsr + "'"
                                     + " and xlqd='" + qxfltemp.xlqd + "'"
                                    );
                                if (qxfl == null) {
                                    qxfl = new PJ_06sbxsmx();
                                    qxfl.CreateDate = qxfltemp.CreateDate;
                                    qxfl.LineID = qxfltemp.LineID;
                                    qxfl.LineName = qxfltemp.LineName;
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.qxlb = qxfltemp.qxlb;
                                    qxfl.qxnr = qxfltemp.qxnr;
                                    qxfl.xssj = qxfltemp.xssj;
                                    qxfl.xsr = qxfltemp.xsr;
                                    qxfl.xcqx = qxfltemp.xcqx;
                                    qxfl.xlqd = qxfltemp.xlqd;
                                    qxfl.CreateDate = DateTime.Now;
                                    qxfl.CreateMan = MainHelper.User.UserName;
                                    //MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(qxfl);

                                    //WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                    //mrwt.ModleRecordID = qxfl.ID;
                                    //mrwt.RecordID = lpr.ID;
                                    //mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                    //mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                    //mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                    //mrwt.ModleTableName = qxfl.GetType().ToString();
                                    //mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                    //mrwt.CreatTime = DateTime.Now;
                                    //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                                }
                            } else {
                                qxfl = new PJ_06sbxsmx();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                qxfl.CreateDate = DateTime.Now;
                                qxfl.CreateMan = MainHelper.User.UserName;
                                //MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(qxfl);

                                //WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                //mrwt.ModleRecordID = qxfl.ID;
                                //mrwt.RecordID = lpr.ID;
                                //mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                //mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                //mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                //mrwt.ModleTableName = qxfl.GetType().ToString();
                                //mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                //mrwt.CreatTime = DateTime.Now;
                                //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            }

                            ((frmWorkFlow06sbxsEdit)obj).RowData = qxfl;

                        } else if (obj is frm08SBTDJXWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_qxfl'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_08sbtdjx qxfl = new PJ_08sbtdjx();
                            if (li.Count > 0) {
                                PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);
                                li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                               + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_08sbtdjx'"
                                 + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                                if (li.Count > 0) {
                                    qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_08sbtdjx>(li[0].ModleRecordID);
                                } else {
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.LineID = qxfltemp.LineID;
                                    qxfl.LineName = qxfltemp.LineName;
                                    qxfl.jxnr = qxfltemp.qxnr;
                                    if (qxfltemp.qxlb == "紧急缺陷") {
                                        qxfl.tdxz = "事故停电";
                                    } else
                                        if (qxfltemp.qxlb == "重大缺陷") {
                                            qxfl.tdxz = "临时停电";
                                        } else
                                            if (qxfltemp.qxlb == "一般缺陷") {
                                                qxfl.tdxz = "一般缺陷";
                                            }
                                    qxfl.CreateDate = DateTime.Now;
                                    qxfl.CreateMan = MainHelper.User.UserName;
                                    MainHelper.PlatformSqlMap.Create<PJ_08sbtdjx>(qxfl);

                                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                    mrwt.ModleRecordID = qxfl.ID;
                                    mrwt.RecordID = lpr.ID;
                                    mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                    mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                    mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                    mrwt.ModleTableName = qxfl.GetType().ToString();
                                    mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                    mrwt.CreatTime = DateTime.Now;
                                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                                }

                            } else {
                                qxfl = new PJ_08sbtdjx();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                qxfl.CreateDate = DateTime.Now;
                                string str = " where RecordID='" + lpr.ID + "'"
                             + " and  FieldName='类别' order by id";
                                WF_TableFieldValue mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str
                                 );
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.tdxz = mrv.ControlValue;
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_08sbtdjx>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = lpr.ID;
                                mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            }

                            ((frm08SBTDJXWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmsgzaycWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_08sbtdjx'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_04sgzayc qxfl = new PJ_04sgzayc();
                            if (li.Count > 0) {
                                PJ_08sbtdjx qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_08sbtdjx>(li[0].ModleRecordID);
                                qxfl.OrgCode = qxfltemp.OrgCode;
                                qxfl.OrgName = qxfltemp.OrgName;
                                qxfl.sdsj = qxfltemp.sdsj;
                                qxfl.tdsj = qxfltemp.tdsj;
                                qxfl.gtdsj = "";
                                TimeSpan span = qxfl.sdsj.Subtract(qxfl.tdsj);
                                if (span.Days > 0)
                                    qxfl.gtdsj += span.Days + "天";
                                if (span.Hours > 0)
                                    qxfl.gtdsj += span.Hours + "时";
                                if (span.Minutes > -1)
                                    qxfl.gtdsj += span.Minutes + "分";
                                qxfl.fsdd = qxfltemp.jxnr;
                                qxfl.CreateDate = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<PJ_04sgzayc>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = lpr.ID;
                                mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            } else {
                                qxfl = new PJ_04sgzayc();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                MainHelper.PlatformSqlMap.Create<PJ_04sgzayc>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = lpr.ID;
                                mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frmsgzaycWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmTDJHWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_tdjh'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_tdjh qxfl = new PJ_tdjh();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_tdjh>(li[0].ModleRecordID);

                            } else {
                                li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_qxfl'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                                qxfl = new PJ_tdjh();
                                if (li.Count > 0) {
                                    PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.SQOrgname = qxfltemp.OrgName;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.JXNR = qxfltemp.qxnr;
                                    qxfl.S1 = "缺陷管理流程";
                                } else {
                                    qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                    qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_tdjh>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = lpr.ID;
                                mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frmTDJHWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frm24WorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + lpr.ID + "'"
                             + " and  WorkFlowId='" + recordWorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_24'"
                               + " and  WorkFlowInsId='" + recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_24 qxfl = new PJ_24();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_24>(li[0].ModleRecordID);

                            } else {
                                string str = " where RecordID='" + lpr.ID + "'"
                             + " and  FieldName='申请原因' order by id";
                                WF_TableFieldValue mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str
                              );
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.nr = mrv.ControlValue;
                                }
                                str = " where RecordID='" + lpr.ID + "'"
                              + " and  FieldName='供电所名称' order by id";
                                mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str
                               );
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    mOrg org = MainHelper.PlatformSqlMap.GetOne<mOrg>(" where orgname='" + mrv.ControlValue + "'");
                                    if (org != null)
                                        qxfl.ParentID = org.OrgID;
                                }
                                qxfl.CreateDate = DateTime.Now;
                                qxfl.CreateMan = MainHelper.User.UserName;
                                if (qxfl.BigData == null || qxfl.BigData.Length == 0) {
                                    qxfl.BigData = new byte[0];
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_24>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = lpr.ID;
                                mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frm24WorkFlowEdit)obj).RowData = qxfl;

                        }


                        if (((Form)obj).ShowDialog() == DialogResult.OK) {
                            if (obj is WorkFlowLineSelectForm) {
                                workFlowFormShow(lpr);
                            }
                        }
                    }
                InitData(strKind);
            }

            IList wfli = MainHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct tlcid from WF_WorkTastTrans where slcid='" +
                         recordWorkFlowData.Rows[0]["WorkFlowId"]
                         + "' and cdfs like '下拉%' ");
            foreach (string strwf in wfli) {
                WF_WorkFlow wf = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlow>(strwf);
                LP_Record lp = new LP_Record();
                lp.ID = "N" + lp.CreateID();
                lp.Kind = wf.FlowCaption;
                lp.CreateTime = DateTime.Now.ToString();
                lp.OrgName = MainHelper.UserOrg.OrgName;
                lp.ParentID = lpr.ID;
                RecordWorkTask.RunNewGZPRecord(lp.ID, lp.Kind, MainHelper.User.UserID, false);
                DataTable dttemp = RecordWorkTask.GetRecordWorkFlowData(lp.ID, MainHelper.User.UserID);
                lp.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg, "", lp.Kind);
                lp.Status = dttemp.Rows[0]["TaskCaption"].ToString();
                MainHelper.PlatformSqlMap.Create<LP_Record>(lp);
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            }
            //获得编辑按钮的状态
            this.btEditfrm.Caption = lpr.Status;
        }
        private void workFlowFormShow(LP_Record currRecord) {
            workFlowFormShow(currRecord, null);
        }
        /// <summary>
        /// 打开节点窗口
        /// </summary>
        /// <param name="currRecord"></param>
        /// <param name="dtret"></param>
        private void workFlowFormShow(LP_Record currRecord, DataTable dtret) {
            DataTable dtall = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
            DataTable dt = new DataTable();
            if (dtret == null) {
                if (dtall.Rows.Count < 1) {
                    if (currRecord.Status == "存档") {
                        frmTemplate fm = new frmTemplate();
                        fm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(dt, currRecord);
                        fm.CurrRecord = currRecord;
                        fm.Kind = strKind;
                        fm.Status = "edit";
                        fm.ShowDialog();
                    } else {
                        IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + currRecord.ID + "'");
                        if (wf.Count > 0) {
                            WF_WorkFlowInstance wfi = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlowInstance>(wf[0].WorkFlowInsId);

                            string struser = RecordWorkTask.GetWorkFlowTaskOperator(wf[0].WorkTaskInsId);
                            MsgBox.ShowTipMessageBox("没有操作此记录的权限，此记录操作者为 " + struser + " !");
                        }
                    }
                    return;
                }
                if (dtall.Rows.Count == 1 || currRecord.Status.IndexOf("|") == -1) {
                    dt = dtall;
                } else {
                    WorkFlowTaskSelectForm wfts = new WorkFlowTaskSelectForm();
                    wfts.RecordWorkFlowData = dtall;
                    if (wfts.ShowDialog() == DialogResult.OK) {
                        dt = wfts.RetWorkFlowData;
                    } else {
                        return;
                    }
                }
            } else {
                dt = dtret;
            }
            if (!RecordWorkTask.HaveRunRecordRole(currRecord.ID, MainHelper.User.UserID)) return;
            object obj = RecordWorkTask.GetWorkTaskModle(dt);
            if (obj == null) {
                return;
            }

            if (obj is frmLP) {
                frmLP frm = new frmLP();
                //frm.Status = "edit";
                frm.Status = RecordWorkTask.GetWorkTaskStatus(dt, currRecord);

                frm.CurrRecord = currRecord;
                frm.strxiestatus = "edit";

                frm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(dt, currRecord);
                if (frm.ParentTemple == null) {
                    MsgBox.ShowWarningMessageBox("出错，未找到该节点关联的表单，请检查模板设置!");
                    //return;
                }

                frm.Kind = strKind;
                frm.RecordWorkFlowData = dt;
                if (frm.ShowDialog() == DialogResult.OK) {
                    InitData(strKind);
                }
            } else {
                if (obj.GetType().GetProperty("IsWorkflowCall") != null)
                    obj.GetType().GetProperty("IsWorkflowCall").SetValue(obj, true, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持IsWorkflowCall，请咨询开发人员!");
                    return;
                }
                if (obj.GetType().GetProperty("CurrRecord") != null)
                    obj.GetType().GetProperty("CurrRecord").SetValue(obj, currRecord, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持CurrRecord，请咨询开发人员!");
                    return;
                }


                if (obj.GetType().GetProperty("ParentTemple") != null)
                    obj.GetType().GetProperty("ParentTemple").SetValue(obj, RecordWorkTask.GetWorkTaskTemple(dt, currRecord), null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持ParentTemple，请咨询开发人员!");
                    return;
                }

                if (obj.GetType().GetProperty("RecordWorkFlowData") != null)
                    obj.GetType().GetProperty("RecordWorkFlowData").SetValue(obj, dt, null);
                else {
                    MsgBox.ShowWarningMessageBox("模块不支持RecordWorkFlowData，请咨询开发人员!");
                    return;
                }
                if (obj is UserControl) {

                    FormBase dlg = new FormBase();
                    dlg.Text = ((UserControl)obj).Name;
                    dlg.MdiParent = MainHelper.MainForm;
                    dlg.Controls.Add((UserControl)obj);
                    ((UserControl)obj).Dock = DockStyle.Fill;
                    dlg.Show();
                } else
                    if (obj is Form) {
                        if (obj is frmyxfxWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_03yxfx'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_03yxfx yxfx = new PJ_03yxfx();
                            if (li.Count > 0) {
                                yxfx = MainHelper.PlatformSqlMap.GetOneByKey<PJ_03yxfx>(li[0].ModleRecordID);

                            } else {
                                yxfx = new PJ_03yxfx();
                                yxfx.OrgCode = MainHelper.UserOrg.OrgCode;
                                yxfx.OrgName = MainHelper.UserOrg.OrgName;
                                if (parentObj.FlowCaption.IndexOf("定期分析") > 0)
                                    yxfx.type = "定期分析";
                                else
                                    if (parentObj.FlowCaption.IndexOf("专题分析") > 0)
                                        yxfx.type = "专题分析";
                                ((frmyxfxWorkFlowEdit)obj).RecordStatus = 0;
                                yxfx.rq = DateTime.Now;
                                ((frmyxfxWorkFlowEdit)obj).RowData = yxfx;
                            }
                            switch (dt.Rows[0]["TaskInsCaption"].ToString()) {
                                case "填写":
                                    ((frmyxfxWorkFlowEdit)obj).RecordStatus = 0;
                                    break;
                                case "领导检查":
                                    ((frmyxfxWorkFlowEdit)obj).RecordStatus = 1;
                                    break;
                                case "检查人检查":
                                    ((frmyxfxWorkFlowEdit)obj).RecordStatus = 2;
                                    break;

                            }
                            yxfx.rq = DateTime.Now;
                            ((frmyxfxWorkFlowEdit)obj).RowData = yxfx;

                        } else if (obj is frmsbqxWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "'" + " and ModleTableName='Ebada.Scgl.Model.PJ_qxfl'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_qxfl qxfl = new PJ_qxfl();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);

                            } else {
                                qxfl = new PJ_qxfl();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;

                            }

                            ((frmsbqxWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmWorkFlow06sbxsEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                              + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_06sbxsmx'"
                                + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_06sbxsmx qxfl = new PJ_06sbxsmx();
                            if (li.Count > 0) {
                                PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);


                                qxfl = MainHelper.PlatformSqlMap.GetOne<PJ_06sbxsmx>(" where CONVERT(varchar, CreateDate, 120 ) =  '" + qxfltemp.CreateDate + "'"
                                    + " and LineID='" + qxfltemp.LineID + "'"
                                    + " and OrgCode='" + qxfltemp.OrgCode + "'"
                                     + " and qxlb='" + qxfltemp.qxlb + "'"
                                     + " and xsr='" + qxfltemp.xsr + "'"
                                     + " and xlqd='" + qxfltemp.xlqd + "'"
                                    );
                                if (qxfl == null) {
                                    qxfl = new PJ_06sbxsmx();
                                    qxfl.CreateDate = qxfltemp.CreateDate;
                                    qxfl.LineID = qxfltemp.LineID;
                                    qxfl.LineName = qxfltemp.LineName;
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.qxlb = qxfltemp.qxlb;
                                    qxfl.qxnr = qxfltemp.qxnr;
                                    qxfl.xssj = qxfltemp.xssj;
                                    qxfl.xsr = qxfltemp.xsr;
                                    qxfl.xcqx = qxfltemp.xcqx;
                                    qxfl.xlqd = qxfltemp.xlqd;
                                    qxfl.CreateDate = DateTime.Now;
                                    qxfl.CreateMan = MainHelper.User.UserName;
                                    //MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(qxfl);

                                    //WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                    //mrwt.ModleRecordID = qxfl.ID;
                                    //mrwt.RecordID = lpr.ID;
                                    //mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                    //mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                    //mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                    //mrwt.ModleTableName = qxfl.GetType().ToString();
                                    //mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                    //mrwt.CreatTime = DateTime.Now;
                                    //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                                }
                            } else {
                                qxfl = new PJ_06sbxsmx();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                qxfl.CreateDate = DateTime.Now;
                                qxfl.CreateMan = MainHelper.User.UserName;
                                //MainHelper.PlatformSqlMap.Create<PJ_06sbxs>(qxfl);

                                //WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                //mrwt.ModleRecordID = qxfl.ID;
                                //mrwt.RecordID = lpr.ID;
                                //mrwt.WorkFlowId = recordWorkFlowData.Rows[0]["WorkFlowId"].ToString();
                                //mrwt.WorkFlowInsId = recordWorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                                //mrwt.WorkTaskId = recordWorkFlowData.Rows[0]["WorkTaskId"].ToString();
                                //mrwt.ModleTableName = qxfl.GetType().ToString();
                                //mrwt.WorkTaskInsId = recordWorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                                //mrwt.CreatTime = DateTime.Now;
                                //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            }


                            ((frmWorkFlow06sbxsEdit)obj).RowData = qxfl;

                        } else if (obj is frm08SBTDJXWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_qxfl'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_08sbtdjx qxfl = new PJ_08sbtdjx();
                            if (li.Count > 0) {
                                PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);
                                li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                               + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_08sbtdjx'"
                                 + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                                if (li.Count > 0) {
                                    qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_08sbtdjx>(li[0].ModleRecordID);
                                } else {
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.LineID = qxfltemp.LineID;
                                    qxfl.LineName = qxfltemp.LineName;
                                    qxfl.jxnr = qxfltemp.qxnr;
                                    if (qxfltemp.qxlb == "紧急缺陷") {
                                        qxfl.tdxz = "事故停电";
                                    } else
                                        if (qxfltemp.qxlb == "重大缺陷") {
                                            qxfl.tdxz = "临时停电";
                                        } else
                                            if (qxfltemp.qxlb == "一般缺陷") {
                                                qxfl.tdxz = "一般缺陷";
                                            }
                                    qxfl.CreateDate = DateTime.Now;
                                    qxfl.CreateMan = MainHelper.User.UserName;
                                    MainHelper.PlatformSqlMap.Create<PJ_08sbtdjx>(qxfl);

                                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                    mrwt.ModleRecordID = qxfl.ID;
                                    mrwt.RecordID = currRecord.ID;
                                    mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                    mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                    mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                    mrwt.ModleTableName = qxfl.GetType().ToString();
                                    mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                    mrwt.CreatTime = DateTime.Now;
                                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                                }

                            } else {
                                qxfl = new PJ_08sbtdjx();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                qxfl.CreateDate = DateTime.Now;
                                string str = " where RecordID='" + currRecord.ID + "'"
                             + " and  FieldName='类别' order by id";
                                WF_TableFieldValue mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str
                                 );
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.tdxz = mrv.ControlValue;
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_08sbtdjx>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = currRecord.ID;
                                mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            }

                            ((frm08SBTDJXWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmsgzaycWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_08sbtdjx'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_04sgzayc qxfl = new PJ_04sgzayc();
                            if (li.Count > 0) {
                                PJ_08sbtdjx qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_08sbtdjx>(li[0].ModleRecordID);
                                qxfl.OrgCode = qxfltemp.OrgCode;
                                qxfl.OrgName = qxfltemp.OrgName;
                                qxfl.sdsj = qxfltemp.sdsj;
                                qxfl.tdsj = qxfltemp.tdsj;
                                qxfl.gtdsj = "";
                                TimeSpan span = qxfl.sdsj.Subtract(qxfl.tdsj);
                                if (span.Days > 0)
                                    qxfl.gtdsj += span.Days + "天";
                                if (span.Hours > 0)
                                    qxfl.gtdsj += span.Hours + "时";
                                if (span.Minutes > -1)
                                    qxfl.gtdsj += span.Minutes + "分";
                                qxfl.fsdd = qxfltemp.jxnr;
                                qxfl.CreateDate = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<PJ_04sgzayc>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = currRecord.ID;
                                mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                            } else {
                                qxfl = new PJ_04sgzayc();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                MainHelper.PlatformSqlMap.Create<PJ_04sgzayc>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = currRecord.ID;
                                mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frmsgzaycWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frmTDJHWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_tdjh'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_tdjh qxfl = new PJ_tdjh();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_tdjh>(li[0].ModleRecordID);

                            } else {
                                li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_qxfl'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                                qxfl = new PJ_tdjh();
                                if (li.Count > 0) {
                                    PJ_qxfl qxfltemp = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(li[0].ModleRecordID);
                                    qxfl.OrgCode = qxfltemp.OrgCode;
                                    qxfl.SQOrgname = qxfltemp.OrgName;
                                    qxfl.OrgName = qxfltemp.OrgName;
                                    qxfl.JXNR = qxfltemp.qxnr;
                                    qxfl.S1 = "缺陷管理流程";
                                } else {
                                    qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                    qxfl.OrgName = MainHelper.UserOrg.OrgName;
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_tdjh>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = currRecord.ID;
                                mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frmTDJHWorkFlowEdit)obj).RowData = qxfl;

                        } else if (obj is frm24WorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and ModleTableName='Ebada.Scgl.Model.PJ_24'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_24 qxfl = new PJ_24();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_24>(li[0].ModleRecordID);

                            } else {
                                string str = " where RecordID='" + currRecord.ID + "'"
                             + " and  FieldName='申请原因' order by id";
                                WF_TableFieldValue mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str);
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.nr = mrv.ControlValue;
                                }
                                str = " where RecordID='" + currRecord.ID + "'"
                              + " and  FieldName='供电所名称' order by id";
                                mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str
                               );
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    mOrg org = MainHelper.PlatformSqlMap.GetOne<mOrg>(" where orgname='" + mrv.ControlValue + "'");
                                    if (org != null)
                                        qxfl.ParentID = org.OrgID;
                                }
                                qxfl.CreateDate = DateTime.Now;
                                qxfl.CreateMan = MainHelper.User.UserName;
                                if (qxfl.BigData == null || qxfl.BigData.Length == 0) {
                                    qxfl.BigData = new byte[0];
                                }
                                MainHelper.PlatformSqlMap.Create<PJ_24>(qxfl);

                                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                                mrwt.ModleRecordID = qxfl.ID;
                                mrwt.RecordID = currRecord.ID;
                                mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                                mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                                mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                                mrwt.ModleTableName = qxfl.GetType().ToString();
                                mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                                mrwt.CreatTime = DateTime.Now;
                                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                            }

                            ((frm24WorkFlowEdit)obj).RowData = qxfl;

                        }
                            //年度技改工程计划
                          else if (obj is frmJGGCJHWorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "'" + " and ModleTableName='Ebada.Scgl.Model.PJ_jggcjh'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_jggcjh qxfl = new PJ_jggcjh();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_jggcjh>(li[0].ModleRecordID);

                            } else {
                                qxfl = new PJ_jggcjh();
                                qxfl.OrgName = "绥化市郊农电局";
                                string str = " where RecordID='" + currRecord.ID + "'"
                                + " and  FieldName='申请单位' order by id";
                                WF_TableFieldValue mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str);
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.OrgName = mrv.ControlValue;
                                }
                                str = " where RecordID='" + currRecord.ID + "'"
                                + " and  FieldName='申请改造项目' order by id";
                                mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str);
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.ProjectName = mrv.ControlValue;
                                }
                                str = " where RecordID='" + currRecord.ID + "'"
                                + " and  FieldName='主要工程量' order by id";
                                mrv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(str);
                                //qxfl = new PJ_24();
                                if (mrv != null) {
                                    qxfl.ProjecNR = mrv.ControlValue;
                                }

                            }

                            ((frmJGGCJHWorkFlowEdit)obj).RowData = qxfl;

                        }
                            //26电力线路防护通知书
                          else if (obj is frm26WorkFlowEdit) {
                            IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                             + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "'" + " and ModleTableName='Ebada.Scgl.Model.PJ_26'"
                               + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                            PJ_26 qxfl = new PJ_26();
                            if (li.Count > 0) {
                                qxfl = MainHelper.PlatformSqlMap.GetOneByKey<PJ_26>(li[0].ModleRecordID);

                            } else {
                                qxfl = new PJ_26();


                            }

                            ((frm26WorkFlowEdit)obj).RowData = qxfl;

                        }
                        if (((Form)obj).ShowDialog() == DialogResult.OK) {
                            if (obj is WorkFlowLineSelectForm) {

                                workFlowFormShow(currRecord, ((WorkFlowLineSelectForm)obj).RetWorkFlowData);
                            }
                        }
                    }
                InitData(strKind);
            }
            //获得编辑按钮的状态
            this.btEditfrm.Caption = currRecord.Status;
        }
        private void btEditfrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) {
                return;
            }
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
            workFlowFormShow(currRecord);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e) {
            if (gridView1.FocusedColumn.FieldName != "Image" && gridView1.FocusedColumn.FieldName != "Status")
                e.Cancel = true;
        }

        private void btDeletefrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
            if (currRecord.OrgName != MainHelper.User.OrgName && MainHelper.User.OrgName != "局领导") {
                MsgBox.ShowWarningMessageBox("删除出错,不是本单位的记录，无权删除！");
                return;
            }
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["Number"].ToString() + "】?") != DialogResult.OK) {
                return;
            }

            try {


                RecordWorkTask.DeleteRecord(dr["ID"].ToString());
                MainHelper.PlatformSqlMap.DeleteByWhere<LP_Record>(" where id ='" + dr["ID"].ToString() + "'");
                InitData(strKind);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void barBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认退回 【" + dr["Number"].ToString() + "】?") != DialogResult.OK) {
                return;
            }
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }

            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);

            if (dt.Rows.Count > 0) {
                if (!RecordWorkTask.HaveWorkFlowBackRole(dt.Rows[0]["WorkTaskId"].ToString(), dt.Rows[0]["WorkFlowId"].ToString())) {
                    MsgBox.ShowWarningMessageBox("当前节点不能退回.设置里没有允许退回，退回失败!");
                    return;
                }
                string strmes = RecordWorkTask.RunWorkFlowBack(MainHelper.User.UserID, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString());
                if (strmes.IndexOf("未提交至任何人") > -1) {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                } else {

                    currRecord.LastChangeTime = DateTime.Now.ToString();
                    currRecord.Status = RecordWorkTask.GetWorkFlowTaskCaption(dt.Rows[0]["WorkTaskInsId"].ToString());
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                    InitData(strKind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
                this.btEditfrm.Caption = currRecord.Status;
            } else {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,退回失败!");
            }
        }

        private void barChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Kind != "yzgzp") {
                MsgBox.ShowTipMessageBox("只有一种票可以变更负责人，变更负责人失败!");
                return;
            }
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认变更 【" + dr["Number"].ToString() + "】?") != DialogResult.OK) {
                return;
            }

            if (currRecord.Status != "确认") {
                MsgBox.ShowTipMessageBox("当前节点不能变更负责人，变更负责人失败!");
                return;
            }
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
            if (dt.Rows.Count > 0) {
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), "变更");
                if (strmes.IndexOf("未提交至任何人") > -1) {
                    MsgBox.ShowTipMessageBox("更改失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                } else {


                    InitData(strKind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
                this.btEditfrm.Caption = currRecord.Status;
            } else {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,变更负责人失败!");
            }
        }

        private void barSus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认 【" + dr["Number"].ToString() + "】 延期?") != DialogResult.OK) {
                return;
            }
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Status != "确认") {
                MsgBox.ShowTipMessageBox("当前节点不能延期，延期失败!");
                return;
            }
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
            if (dt.Rows.Count > 0) {
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), "延期");
                if (strmes.IndexOf("未提交至任何人") > -1) {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                } else {


                    InitData(strKind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            } else {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,延期失败!");
            }
        }
        private string CheckFileName(string filename) {
            if (!File.Exists(filename + ".xls")) {
                return filename + ".xls";
            } else {
                for (int i = 2; ; i++) {
                    if (!File.Exists(filename + "(" + string.Format("{0}", i) + ").xls")) {
                        return filename + "(" + string.Format("{0}", i) + ").xls";
                    }
                }

            }
            return "";
        }
        private void barReExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            int i = 0;
            //string exploreKind = "";
            if (ds1 == null) ds1 = new DSOFramerControl();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(dr["ID"].ToString(), MainHelper.User.UserID);
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + currRecord.ID + "'");
            if (currRecord.Status != "存档") {

                if (dt.Rows.Count > 0) {
                    if (!RecordWorkTask.HaveWorkFlowAllExploreRole(dt.Rows[0]["WorkTaskId"].ToString(), dt.Rows[0]["WorkFlowId"].ToString())) {
                        if (!RecordWorkTask.HaveRunRecordRole(currRecord.ID, MainHelper.User.UserID)) {
                            MsgBox.ShowWarningMessageBox("没有运行权限，导出失败!");
                            return;
                        }
                        //if (!RecordWorkTask.HaveWorkFlowExploreRole(dt.Rows[0]["WorkTaskId"].ToString(), dt.Rows[0]["WorkFlowId"].ToString()))
                        //{
                        //    MsgBox.ShowWarningMessageBox("没有导出权限，导出失败!");
                        //    return;
                        //}

                    }
                } else {
                    MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,导出失败!");
                    return;
                }
            }//流程没结束
            else if (!RecordWorkTask.HaveFlowEndExploreRole(currRecord.Kind)) {
                MsgBox.ShowTipMessageBox("流程结束后不允许导出,导出失败!");
                return;

            }//流程结束
            if (currRecord.ID.IndexOf("N") == -1 || parentObj.FlowCaption.IndexOf("定期分析") > -1 || parentObj.FlowCaption.IndexOf("专题分析") > -1 || parentObj.FlowCaption.IndexOf("电力线路") > -1)
            //if (currRecord.ID.IndexOf("N") == -1 || parentObj.FlowCaption.IndexOf("定期分析") > -1 || parentObj.FlowCaption.IndexOf("专题分析") > -1 )
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                string fname = "";
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fname = saveFileDialog1.FileName;

                    try {


                        ds1.FileDataGzip = currRecord.DocContent;
                        ds1.FileSave(fname, true);
                        ds1.FileClose();
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start(fname);
                    } catch (Exception ex) {
                        ds1.FileClose();
                        Console.WriteLine(ex.Message);
                        MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");

                    }
                }
                return;
            }//是旧记录
            Hashtable templehs = RecordWorkTask.GetExploerLP_TempleList(dt, currRecord);

            if (templehs.Count > 1) {
                DataTable templedt = new DataTable();
                templedt.Columns.Add("Checked", typeof(bool));
                templedt.Columns.Add("Index", typeof(string));
                templedt.Columns.Add("Name", typeof(string));
                ArrayList akeys = new ArrayList(templehs.Keys);
                for (i = 0; i < akeys.Count; i++) {
                    object obj = akeys[i];
                    DataRow templedr = templedt.NewRow();
                    if (obj is LP_Temple) {
                        WF_WorkTaskInstance wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(templehs[akeys[i]]);
                        if (wt != null) {
                            templedr["Name"] = wt.TaskInsCaption + "-申报表单";
                            templedr["Checked"] = 1;
                            templedr["Index"] = i;
                            templedt.Rows.Add(templedr);

                        }

                    } else if (obj is string) {

                        LP_Temple taskTemple = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(akeys[i]);
                        if (taskTemple != null) {
                            templedr["Name"] = taskTemple.CellName;
                            templedr["Checked"] = 1;
                            templedr["Index"] = i;
                            templedt.Rows.Add(templedr);

                        }
                    }
                }
                frmExploreSelect frmes = new frmExploreSelect();
                frmes.SourceDt = templedt;
                if (frmes.ShowDialog() == DialogResult.OK && frmes.CheckIndehs.Count > 0) {

                    string fname = "";
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK) {
                        fname = fbd.SelectedPath + "\\";

                        ArrayList checkkeys = new ArrayList(frmes.CheckIndehs.Keys);
                        for (i = 0; i < checkkeys.Count; i++) {
                            object obj = akeys[Convert.ToInt32(checkkeys[i])];

                            try {
                                if (obj is LP_Temple) {


                                    ds1.FileDataGzip = ((LP_Temple)obj).DocContent;
                                    //ds1.FileOpen(ds1.FileName);
                                    ds1.FileSave(CheckFileName(fname + frmes.CheckIndehs[checkkeys[i]]), true);
                                    ds1.FileClose();

                                } else if (obj is string) {

                                    LP_Temple taskTemple = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(akeys[Convert.ToInt32(checkkeys[i])]);
                                    if (taskTemple != null) {

                                        WF_WorkTaskInstance worktaskins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(templehs[akeys[Convert.ToInt32(checkkeys[i])]]);
                                        LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + taskTemple.LPID + "' and SortID=1");
                                        if (lp != null) {
                                            WF_TableFieldValue wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + lp.ParentID + "'"
                                              + " and   WorkflowId='" + worktaskins.WorkFlowId + "'"
                                              + " and   RecordId='" + currRecord.ID + "'"
                                              + " and   WorkFlowInsId='" + worktaskins.WorkFlowInsId + "'"
                                              + " and   FieldId='" + lp.LPID + "'"
                                             );
                                            if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0) {

                                                ds1.FileDataGzip = wfv.Bigdata;
                                            } else {
                                                RecordWorkTask.iniTableRecordData(ref taskTemple, ds1, currRecord, worktaskins.WorkFlowId,
                                               worktaskins.WorkFlowInsId, true);
                                                ds1.FileDataGzip = taskTemple.DocContent;
                                            }
                                        } else {
                                            RecordWorkTask.iniTableRecordData(ref taskTemple, ds1, currRecord, worktaskins.WorkFlowId,
                                                worktaskins.WorkFlowInsId, true);
                                            ds1.FileDataGzip = taskTemple.DocContent;
                                        }
                                        //ds1.FileOpen(ds1.FileName);
                                        ds1.FileSave(CheckFileName(fname + taskTemple.CellName), true);
                                        ds1.FileClose();

                                    }
                                }
                            } catch (Exception ex) {


                                ds1.FileSave();
                                ds1.FileClose();
                                Console.WriteLine(ex.Message);
                                MsgBox.ShowWarningMessageBox("出错" + ex.Message + " ，无法保存" + frmes.CheckIndehs[checkkeys[i]] + "。请用其他文件名保存文件，或将文件存至其他位置。");
                                break;
                            }


                        }//循环所有选择的表单
                        if (MsgBox.ShowAskMessageBox("导出成功，是否所在文件夹？") != DialogResult.OK)
                            return;
                        System.Diagnostics.Process.Start(fname);
                    }
                }
            }//表单不止一个
            else if (templehs.Count == 1) {
                ArrayList akeys = new ArrayList(templehs.Keys);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                string fname = "";
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fname = saveFileDialog1.FileName;

                    try {

                        if (akeys[0] is LP_Temple) {
                            ds1.FileDataGzip = ((LP_Temple)akeys[0]).DocContent;
                            ds1.FileSave(fname, true);
                            ds1.FileClose();
                        } else if (akeys[0] is string) {

                            LP_Temple taskTemple = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(akeys[0]);
                            if (taskTemple != null) {
                                if (taskTemple.CellName.IndexOf("电力线路") == -1 || 1 == 1) {
                                    WF_WorkTaskInstance worktaskins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(templehs[akeys[0]]);
                                    LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + taskTemple.LPID + "' and SortID=1");
                                    if (lp != null) {
                                        WF_TableFieldValue wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + lp.ParentID + "'"
                                          + " and   WorkflowId='" + worktaskins.WorkFlowId + "'"
                                          + " and   RecordId='" + currRecord.ID + "'"
                                          + " and   WorkFlowInsId='" + worktaskins.WorkFlowInsId + "'"
                                          + " and   FieldId='" + lp.LPID + "'"
                                         );
                                        if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0) {

                                            ds1.FileDataGzip = wfv.Bigdata;
                                        } else {
                                            WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>(" where WorkflowId='" + wf[0].WorkFlowId
                                        + "' and WorktaskId='" + wf[0].WorkTaskId + "'");
                                            if (wtc != null) {

                                            }

                                            //RecordWorkTask.iniTableRecordData(ref taskTemple, currRecord, wf[0].WorkFlowId, wf[0].WorkFlowInsId, true);
                                            currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
                                            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                                            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                                            if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
                                            RecordWorkTask.iniTableRecordData(ref taskTemple, ds1, currRecord, worktaskins.WorkFlowId, worktaskins.WorkFlowInsId, true);
                                            ds1.FileDataGzip = taskTemple.DocContent;
                                        }
                                    } else {
                                        WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>(" where WorkflowId='" + wf[0].WorkFlowId
                                        + "' and WorktaskId='" + wf[0].WorkTaskId + "'");
                                        if (wtc != null) {

                                        }
                                        //WF_WorkTaskInstance worktaskins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(templehs[akeys[0]]);
                                        //RecordWorkTask.iniTableRecordData(ref taskTemple, currRecord, wf[0].WorkFlowId, wf[0].WorkFlowInsId, true);
                                        currRecord = MainHelper.PlatformSqlMap.GetOneByKey<LP_Record>(currRecord.ID);
                                        if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                                        if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                                        if (currRecord.DocContent == null) currRecord.DocContent = new byte[0];
                                        RecordWorkTask.iniTableRecordData(ref taskTemple, ds1, currRecord, worktaskins.WorkFlowId, worktaskins.WorkFlowInsId, true);
                                        ds1.FileDataGzip = taskTemple.DocContent;
                                    }
                                } else {
                                    ds1.FileDataGzip = currRecord.DocContent;
                                }

                                ds1.FileSave(fname, true);
                                ds1.FileClose();

                            }
                        }
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start(fname);
                    } catch (Exception ex) {
                        ds1.FileSave();
                        ds1.FileClose();
                        Console.WriteLine(ex.Message);
                        MsgBox.ShowWarningMessageBox("出错" + ex.Message + " ，无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                        return;
                    }
                    ds1.Dispose();
                    ds1 = null;
                }
            }

        }

        private void barReChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LP_Record currRecord = new LP_Record();
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (currRecord.Status == "存档") {
                MsgBox.ShowTipMessageBox("该流程已经结束!");
                return;
            }
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData2(dr["ID"].ToString());
            if (dt.Rows.Count > 0) {
                frmWFChange fw = new frmWFChange();
                fw.Text = dt.Rows[0]["FlowInsCaption"].ToString() + "流程跳转";
                fw.groupBox1.Text = dt.Rows[0]["FlowInsCaption"].ToString();
                fw.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                if (fw.ShowDialog() != DialogResult.OK)
                    return;
                //请求确认
                if (MsgBox.ShowAskMessageBox("确认更改 【" + dr["Number"].ToString() + "】状态为" + fw.WorkTaskCaption + "?") != DialogResult.OK) {
                    return;
                }
                string strmes = RecordWorkTask.RunGZPWorkFlowChange(MainHelper.User.UserID, currRecord, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), fw.WorkTaskCaption);
                if (strmes.IndexOf("未提交至任何人") > -1) {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                } else {


                    InitData(strKind);
                    MsgBox.ShowTipMessageBox(strmes);

                }
            } else {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,延期失败!");
            }
        }

        private void btRefresh1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            InitData(strKind);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as LP_Record);
            //获得编辑按钮的状态
            this.btEditfrm.Caption = (gridView1.GetFocusedRow() as LP_Record).Status;
        }

        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle < 0) return;
            frmTemplate fm = new frmTemplate();
            LP_Record currRecord = new LP_Record();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            DataTable dt = RecordWorkTask.GetRecordWorkFlowData2(dr["ID"].ToString());
            fm.RecordWorkFlowData = dt;
            foreach (DataColumn dc in gridtable.Columns) {
                if (dc.ColumnName != "Image") {
                    if (dc.DataType.FullName.IndexOf("Byte[]") < 0)
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);
                    else if (dc.DataType.FullName.IndexOf("Byte[]") > -1 && DBNull.Value != dr[dc.ColumnName] && dr[dc.ColumnName].ToString() != "")
                        currRecord.GetType().GetProperty(dc.ColumnName).SetValue(currRecord, dr[dc.ColumnName], null);

                }
            }
            if (!RecordWorkTask.HaveRunRecordFollowRole(currRecord.ID, MainHelper.User.UserID)) return;
            object obj = RecordWorkTask.GetWorkTaskModle(dt);
            if (obj == null) {
                return;
            }

            if (obj is frmLP) {
                fm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(dt, currRecord);
                fm.CurrRecord = currRecord;
                fm.Kind = strKind;
                fm.Status = "edit";
                fm.ShowDialog();
                InitData(strKind);
            } else
                if (obj is UCPJ_23) {
                    fm.ParentTemple = RecordWorkTask.GetWorkTaskTemple(dt, currRecord);
                    fm.CurrRecord = currRecord;
                    fm.Kind = strKind;
                    fm.Status = "edit";
                    fm.ShowDialog();
                    InitData(strKind);
                } else {
                    return;
                    if (obj.GetType().GetProperty("RecordWorkFlowData") != null)
                        obj.GetType().GetProperty("RecordWorkFlowData").SetValue(obj, dt, null);
                    else {
                        MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                        return;
                    }
                    if (obj.GetType().GetProperty("IsWorkflowCall") != null)
                        obj.GetType().GetProperty("IsWorkflowCall").SetValue(obj, true, null);
                    else {
                        MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                        return;
                    }
                    if (obj.GetType().GetProperty("CurrRecord") != null)
                        obj.GetType().GetProperty("CurrRecord").SetValue(obj, currRecord, null);
                    else {
                        MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                        return;
                    }

                    if (obj.GetType().GetProperty("ParentTemple") != null)
                        obj.GetType().GetProperty("ParentTemple").SetValue(obj, RecordWorkTask.GetWorkTaskTemple(dt, currRecord), null);
                    else {
                        MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                        return;
                    }
                    if (obj is UserControl) {

                        FormBase dlg = new FormBase();
                        dlg.Text = ((UserControl)obj).Name;
                        dlg.MdiParent = MainHelper.MainForm;
                        dlg.Controls.Add((UserControl)obj);
                        ((UserControl)obj).Dock = DockStyle.Fill;
                        dlg.Show();
                    } else
                        if (obj is Form) {
                            if (obj is frmyxfxWorkFlowEdit) {
                                IList<WF_ModleRecordWorkTaskIns> li = MainHelper.PlatformSqlMap.GetListByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + currRecord.ID + "'"
                                 + " and  WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "'"
                                   + " and  WorkFlowInsId='" + dt.Rows[0]["WorkFlowInsId"].ToString() + "' order by CreatTime desc");
                                PJ_03yxfx yxfx = new PJ_03yxfx();
                                if (li.Count > 0) {
                                    yxfx = MainHelper.PlatformSqlMap.GetOneByKey<PJ_03yxfx>(li[0].ModleRecordID);

                                } else {
                                    yxfx = new PJ_03yxfx();
                                    yxfx.OrgCode = MainHelper.UserOrg.OrgCode;
                                    yxfx.OrgName = MainHelper.UserOrg.OrgName;
                                    if (parentObj.FlowCaption.IndexOf("定期分析") > 0)
                                        yxfx.type = "定期分析";
                                    else
                                        if (parentObj.FlowCaption.IndexOf("专题分析") > 0)
                                            yxfx.type = "专题分析";
                                    ((frmyxfxWorkFlowEdit)obj).RecordStatus = 0;
                                    yxfx.rq = DateTime.Now;
                                    ((frmyxfxWorkFlowEdit)obj).RowData = yxfx;
                                }
                                ((frmyxfxWorkFlowEdit)obj).RecordStatus = -1;
                                yxfx.rq = DateTime.Now;
                                ((frmyxfxWorkFlowEdit)obj).RowData = yxfx;

                            } else if (obj is frmsbqxWorkFlowEdit) {
                                PJ_qxfl qxfl = new PJ_qxfl();
                                qxfl.OrgCode = MainHelper.UserOrg.OrgCode;
                                qxfl.OrgName = MainHelper.UserOrg.OrgName;

                                ((frmsbqxWorkFlowEdit)obj).RowData = qxfl;

                            }
                            ((Form)obj).ShowDialog();
                        }
                    InitData(strKind);

                }
        }
        void copyData(LP_Temple lp, IList<LP_Temple> templeList) {
            if (templeList.Count == 0) return;
            string flowid = lp.ParentID;
            int i = 1;
            List<LP_Temple> list = new List<LP_Temple>();
            string workflowid = flowid;
            IList<WF_WorkTask> wftli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where WorkFlowId='" + workflowid + "' and  TaskTypeId!='2' order by TaskTypeId");
            foreach (WF_WorkTask wft in wftli) {
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
            foreach (LP_Temple obj in templeList) {
                obj.SortID = i;
                if (obj.SignImg == null) {
                    obj.SignImg = new byte[0];
                }
                if (obj.ImageAttachment == null) {
                    obj.ImageAttachment = new byte[0];
                }
                if (obj.DocContent == null) {
                    obj.DocContent = new byte[0];
                }
                i++;
                if (obj.CellName == "6.3 其他安全措施和注意事项" && obj.Status == "") {
                    obj.Status = "填票";
                }

                if (obj.CellName.IndexOf("终了时间") > -1) {
                    obj.WordCount = "dd日 HH:mm";
                } else
                    if (obj.CellName.IndexOf("同意执行时间") > -1) {
                        obj.WordCount = "MM-dd日 HH:mm";
                    } else
                        if (obj.CellName.IndexOf("时间") > -1) {
                            obj.WordCount = "yyyy-MM-dd HH:mm";
                        }

                if (obj.SqlSentence == "SelectmOrgList where parentid='0'") {
                    obj.SqlSentence = "Select OrgName  from mOrg where parentid='0'";
                    obj.SqlColName = "";
                }

                if (obj.SqlSentence.IndexOf("SelectmUserList where  OrgName ='@1'") > -1) {
                    obj.SqlSentence = "Select UserName  from mUser where OrgName='{1}'";
                    obj.SqlColName = "";
                }

                if (lp.CellName == "电力线路第一种工作票") {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "工作票";
                    }
                }
                if (lp.CellName == "电力线路第二种工作票") {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "Sheet1";
                    }
                }

                if (lp.CellName == "电力线路倒闸操作票") {
                    //if (obj.KindTable == "")
                    {
                        obj.KindTable = "Sheet1";
                    }
                }
                if (lp.CellName == "电力线路事故应急抢修单") {
                    if (obj.KindTable == "") {
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
                if (wt == null) {
                    continue;
                }
                WF_TableUsedField tuf = MainHelper.PlatformSqlMap.GetOne<WF_TableUsedField>("where FieldName='" + obj.CellName +
                    "'  and UserControlId='" + obj.ParentID + "'");
                if (tuf == null) {
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
            if (list.Count > 0) {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);


        }
        private void barCopy_ItemClick(object sender, ItemClickEventArgs e) {
            //CreatWF_TableFieldValueView
            //MainHelper.PlatformSqlMap.Update("CreatWF_TableFieldValueView",null);
            LP_Temple temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路第一种工作票'  and Status=''");
            IList<LP_Temple> templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                "where ParentID ='" + temple.LPID + "' Order by SortID");
            copyData(temple, templeList);
            temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路第二种工作票'  and Status=''");
            templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                  "where ParentID ='" + temple.LPID + "' Order by SortID");
            copyData(temple, templeList);
            temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路倒闸操作票'  and Status=''");
            templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                  "where ParentID ='" + temple.LPID + "' Order by SortID");
            copyData(temple, templeList);
            temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where cellname='电力线路事故应急抢修单'  ");
            templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                  "where ParentID ='" + temple.LPID + "' Order by SortID");
            copyData(temple, templeList);
            MsgBox.ShowTipMessageBox("执行完毕");
        }

    }
}
