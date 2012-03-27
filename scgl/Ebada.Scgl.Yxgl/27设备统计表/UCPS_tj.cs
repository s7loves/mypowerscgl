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
using System.Data.OleDb;
using System.Collections;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_tj : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_tj> gridViewOperation;

        public event SendDataEventHandler<PS_tj> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;    
        private string parentID = null;
        private PS_tq parentObj;
        private DataTable dt = new DataTable();
        private IList<string> sbList = new List<string>();
        private string sqlSentence = null;
        private IList strTypeList = new ArrayList();
        IList<PS_tj> tjList = new List<PS_tj>();
        public UCPS_tj()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_tj>(gridControl1, gridView1, barManager1);

            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic2;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);
            btSbList.EditValueChanged += new EventHandler(btSbList_EditValueChanged);
            btTQList.EditValueChanged += new EventHandler(btTQList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
            InitComBox();
        }

        void btTQList_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(btTQList.EditValue.ToString()))
            {
                tjList.Clear();
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq where PS_tqsb.tqID = PS_tq.tqID  and PS_tq.tqID = '" + btTQList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq where PS_tqdlbh.tqID = PS_tq.tqID  and PS_tq.tqID = '" + btTQList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                foreach (object[] ob in tqDLBHSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                gridControl1.BeginInit();
                gridControl1.DataSource = tjList;
                gridControl1.EndInit();
            }
        }
        private void InitComBox()
        {
            IList<PS_sbcs> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_sbcs>(" where len(id)=5");
//             dataSetPS_sbcs1.Clear();
//             foreach (PS_sbcs sb in list)
//             {
//                 DataRow dr = dt.NewRow();
//                 dr["bh"] = sb.bh;
//                 dr["mc"] = sb.mc;
//                 dr["xh"] = sb.xh;
//                 dr["ID"] = sb.ID;
//                 dr["ParentID"] = sb.ParentID;
//                // dr["isSelect"] = true;
//                 dt.Rows.Add(dr);
//             }
            repositoryItemCheckedComboBoxEdit1.DataSource = list;
            repositoryItemCheckedComboBoxEdit1.DisplayMember = "mc";
            repositoryItemCheckedComboBoxEdit1.ValueMember = "mc";
          
        }
        void btSbList_EditValueChanged(object sender, EventArgs e)
        {
            //IList<PS_tq> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where gtID='" + btSbList.EditValue.ToString() + "'");
            //repositoryItemLookUpEdit4.DataSource = list;

            if (btTQList.EditValue!=null &&!string.IsNullOrEmpty(btTQList.EditValue.ToString()))
            {
                tjList.Clear();
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq where PS_tqsb.tqID = PS_tq.tqID  and PS_tq.tqID = '" + btTQList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq where PS_tqdlbh.tqID = PS_tq.tqID  and PS_tq.tqID = '" + btTQList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                foreach (object[] ob in tqDLBHSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
            }
            else if (btXlList.EditValue!=null&&!string.IsNullOrEmpty(btXlList.EditValue.ToString()))
            {
                tjList.Clear();
                // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                foreach (object[] ob in gtSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqdlbh.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                foreach (object[] ob in tqDLBHSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
            }
            else if (btGdsList.EditValue!=null)
            {
                IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
                mOrg org = null;
                if (list.Count > 0)
                {
                    org = list[0];
                }
                else
                {
                    tjList.Clear();
                    // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                    IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    foreach (object[] ob in gtSBList)
                    {
                        PS_tj tj = new PS_tj();

                        tj.SBNumber = Convert.ToInt32(ob[0]);
                        tj.SbType = ob[1].ToString();
                        tj.SbName = ob[2].ToString();
                        tjList.Add(tj);
                    }
                    IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    foreach (object[] ob in tqSBList)
                    {
                        PS_tj tj = new PS_tj();

                        tj.SBNumber = Convert.ToInt32(ob[0]);
                        tj.SbType = ob[1].ToString();
                        tj.SbName = ob[2].ToString();
                        tjList.Add(tj);
                    }
                    foreach (object[] ob in tqDLBHSBList)
                    {
                        PS_tj tj = new PS_tj();
                        tj.SBNumber = Convert.ToInt32(ob[0]);
                        tj.SbType = ob[1].ToString();
                        tj.SbName = ob[2].ToString();
                        tjList.Add(tj);
                    }
                }

                if (org != null)
                {
                    IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                    repositoryItemLookUpEdit2.DataSource = xlList;
                    tjList.Clear();
                    // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                    IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    foreach (object[] ob in gtSBList)
                    {
                        PS_tj tj = new PS_tj();

                        tj.SBNumber = Convert.ToInt32(ob[0]);
                        tj.SbType = ob[1].ToString();
                        tj.SbName = ob[2].ToString();
                        tjList.Add(tj);
                    }
                    IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqdlbh.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                    foreach (object[] ob in tqSBList)
                    {
                        PS_tj tj = new PS_tj();

                        tj.SBNumber = Convert.ToInt32(ob[0]);
                        tj.SbType = ob[1].ToString();
                        tj.SbName = ob[2].ToString();
                        tjList.Add(tj);
                    }
                }            
            }
            gridControl1.BeginInit();
            gridControl1.DataSource = tjList;
            gridControl1.EndInit();
        }

        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
            IList<PS_tq> listTQALL = new List<PS_tq>();
            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + btXlList.EditValue.ToString() + "'");
            foreach (PS_gt gt in list)
            {
                IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where gtID='" + gt.gtID + "'");
                foreach (PS_tq tq in listTQ)
                {
                    listTQALL.Add(tq);
                }
            }
            repositoryItemLookUpEdit4.DataSource = listTQALL;
            if (!string.IsNullOrEmpty(btXlList.EditValue.ToString()))
            {
                tjList.Clear();
                // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                foreach (object[] ob in gtSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqdlbh.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode = '" + btXlList.EditValue.ToString() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                foreach (object[] ob in tqDLBHSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                gridControl1.BeginInit();
                gridControl1.DataSource = tjList;
                gridControl1.EndInit();
            }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
            {
                org = list[0];
            }
            else
            {
                tjList.Clear();
                // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                foreach (object[] ob in gtSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                foreach (object[] ob in tqDLBHSBList)
                {
                    PS_tj tj = new PS_tj();
                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
            }

            if (org != null)
            {
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
                tjList.Clear();
                // sqlSentence = "select count(sbModle), sbModle,sbName from PS_gtsb Where sbName in " + getSelectSbName() + " group by sbModle,sbName";
                IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                //IList strTypeList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                foreach (object[] ob in gtSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
                IList tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqdlbh.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                foreach (object[] ob in tqSBList)
                {
                    PS_tj tj = new PS_tj();

                    tj.SBNumber = Convert.ToInt32(ob[0]);
                    tj.SbType = ob[1].ToString();
                    tj.SbName = ob[2].ToString();
                    tjList.Add(tj);
                }
            }
            gridControl1.BeginInit();
            gridControl1.DataSource = tjList;
            gridControl1.EndInit();
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tj);
        }
        public string getSelectSbName()
        {
            object ob =  repositoryItemCheckedComboBoxEdit1.GetCheckedItems();
            //sbList.Clear();
            sbList = ob.ToString().Split(new char []{',' });
            string strWhere=null;
            foreach (string str in sbList)
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere += "(" + "'" + str.Trim() + "'";
                }
                else
                {
                    strWhere += ",'" + str.Trim() + "'";
                }
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere += ")";
            }
            else
            {
                strWhere = "('')";
            }
            return strWhere;
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
        }
        /// <summary>
        /// 隐藏选择列表
        /// </summary>
        public void HideList()
        {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btSbList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar3.Visible = false;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            //repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            //GridColumn bh = new GridColumn();
            //bh.Caption = "种类编号";
            //bh.VisibleIndex = 0;
            //bh.FieldName = "bh";
            //bh.Visible = false;
            //repositoryItemGridLookUpEdit1View.Columns.Add(bh);

            //GridColumn mc = new GridColumn();
            //mc.Caption = "种类名称";
            //mc.VisibleIndex = 0;
            //mc.FieldName = "mc";
            //mc.Visible = true;
            //repositoryItemGridLookUpEdit1View.Columns.Add(mc);

            //GridColumn xh = new GridColumn();
            //xh.Caption = "设备型号";
            //xh.VisibleIndex = 0;
            //xh.FieldName = "xh";
            //xh.Visible = false;
            //repositoryItemGridLookUpEdit1View.Columns.Add(xh);

            //GridColumn gcID = new GridColumn();
            //gcID.Caption = "ID";
            //gcID.VisibleIndex = 0;
            //gcID.FieldName = "ID";
            //gcID.Visible = false;
            //repositoryItemGridLookUpEdit1View.Columns.Add(gcID);

            //GridColumn gcParentID = new GridColumn();
            //gcParentID.Caption = "ParentID";
            //gcParentID.VisibleIndex = 0;
            //gcParentID.FieldName = "ParentID";
            //gcParentID.Visible = false;
            //repositoryItemGridLookUpEdit1View.Columns.Add(gcParentID);

            //GridColumn isSelect = new GridColumn();
            //isSelect.Caption = "是否选择";
            //isSelect.VisibleIndex = 0;
            //isSelect.FieldName = "isSelect";
            //isSelect.Visible = true;
            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //checkEdit.ValueChecked = true;
            //isSelect.ColumnEdit = checkEdit;
            //repositoryItemGridLookUpEdit1View.Columns.Add(isSelect);
            //repositoryItemGridLookUpEdit1View.Click += new EventHandler(repositoryItemGridLookUpEdit1View_Click);


            //repositoryItemGridLookUpEdit1.View = repositoryItemGridLookUpEdit1View;
            //repositoryItemGridLookUpEdit1.DisplayMember = "mc";
            
            DataColumn dcbh = new DataColumn();
            dcbh.ColumnName = "bh";
            dcbh.Caption = "种类编号";
            dt.Columns.Add(dcbh);

            DataColumn dcmc = new DataColumn();
            dcmc.ColumnName = "mc";
            dcmc.Caption = "种类名称";
            dt.Columns.Add(dcmc);

            DataColumn dcxh = new DataColumn();
            dcxh.ColumnName = "xh";
            dcxh.Caption = "设备型号";
            dt.Columns.Add(dcxh);

            DataColumn dcID = new DataColumn();
            dcID.ColumnName = "ID";
            dcID.Caption = "ID";
            dt.Columns.Add(dcID);

            DataColumn dcParentID = new DataColumn();
            dcParentID.ColumnName = "ParentID";
            dcParentID.Caption = "ParentID";
            dt.Columns.Add(dcParentID);

            //DataColumn dcisSelect = new DataColumn();
            //dcisSelect.ColumnName = "isSelect";
            //dcisSelect.Caption = "是否选择";    
            //dt.Columns.Add(dcisSelect);
            //需要隐藏列时在这写代码
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
            hideColumn("SbName");
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PS_tj> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }

        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where tqID='" + value + "' order by sbCode");
                }
                else
                {
                    string tempstr = " 235@$U#u#$";
                    RefreshData(" where tqID='" + tempstr + "' order by sbCode");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_tq ParentObj
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
                    ParentID = value.tqID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle>=0)
            {
                gridControl1.ExportToXls("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
           
           
        }

        private void btSbList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }


    }
}
