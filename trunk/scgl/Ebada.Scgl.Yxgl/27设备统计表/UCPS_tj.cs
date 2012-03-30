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
            RefreshGridControlData("TQ");
        }
        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGridControlData("XL");
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
            RefreshGridControlData("SB");
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGridControlData("GDS");
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
            //需要隐藏列时在这写代码
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
           // hideColumn("SbName");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="stTtype">刷新类型：GDS(按单位），XL（按线路），TQ（按台区），SB（按设备）</param>
        private void RefreshGridControlData(string stTtype)
        {
            IList tqSBList = new List<object[]>();
            IList gtSBList = new List<object[]>();
            IList<string> xlStringList = new List<string>();
            IList<string> tqStringList = new List<string>();
            tjList.Clear();
            switch (stTtype)
            {
                case "GDS":
                    if (btGdsList.EditValue!=null)
                    {                       
                        IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
                        mOrg org = null;
                        if (list.Count > 0)
                        {
                            org = list[0];
                        }
                        else
                        {
                            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where LEN(lineCode) = 6");
                            repositoryItemCheckedComboBoxEdit3.DataSource = xlList;
                            repositoryItemCheckedComboBoxEdit3.DisplayMember = "LineName";
                            repositoryItemCheckedComboBoxEdit3.ValueMember = "LineCode";
                            IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqListByWhere", ",PS_xl,mOrg where PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode");

                            repositoryItemCheckedComboBoxEdit2.DataSource = listTQ;
                            repositoryItemCheckedComboBoxEdit2.DisplayMember = "tqName";
                            repositoryItemCheckedComboBoxEdit2.ValueMember = "tqID";  

                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");              

                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            // IList tqDLBHSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqdlbhRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }                  

                        if (org != null)
                        {
                            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where LEN(lineCode) = 6 and OrgCode='" + org.OrgCode + "'");
                            repositoryItemCheckedComboBoxEdit3.DataSource = xlList;
                            repositoryItemCheckedComboBoxEdit3.DisplayMember = "LineName";
                            repositoryItemCheckedComboBoxEdit3.ValueMember = "LineCode";
                            IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqListByWhere", ",PS_xl,mOrg where PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode='" + org.OrgCode + "'");

                            repositoryItemCheckedComboBoxEdit2.DataSource = listTQ;
                            repositoryItemCheckedComboBoxEdit2.DisplayMember = "tqName";
                            repositoryItemCheckedComboBoxEdit2.ValueMember = "tqID";                    
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");                
     
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
 
                    }
  
                    break;
                case "XL":
                    if (!string.IsNullOrEmpty(repositoryItemCheckedComboBoxEdit3.GetCheckedItems().ToString()))
                    {
                        xlStringList = repositoryItemCheckedComboBoxEdit3.GetCheckedItems().ToString().Split(new char[]{','});

                        foreach (string str in xlStringList)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
  
                    }
                    else
                    {
                        RefreshGridControlData("SB");
                    }
                    break;
                case "TQ":
                    if (!string.IsNullOrEmpty(repositoryItemCheckedComboBoxEdit2.GetCheckedItems().ToString()))
                    {     
                        tqStringList = repositoryItemCheckedComboBoxEdit2.GetCheckedItems().ToString().Split(new char[]{','});
                        foreach (string str in tqStringList)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and linevol='0.4' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            //tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq where PS_tqsb.tqID = PS_tq.tqID  and PS_tq.tqID = '" +str.Trim() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit2.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit2.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
                        
                     }
                    else
                    {
                        RefreshGridControlData("SB");
                    }
                    break;
                case "SB":
                    if (!string.IsNullOrEmpty(repositoryItemCheckedComboBoxEdit2.GetCheckedItems().ToString()))
                    {
                        tqStringList = repositoryItemCheckedComboBoxEdit2.GetCheckedItems().ToString().Split(new char[] { ',' });
                        foreach (string str in tqStringList)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and linevol='0.4' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq where PS_tqsb.tqID = PS_tq.tqID  and PS_tq.tqID = '" + str.Trim() + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit2.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit2.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(repositoryItemCheckedComboBoxEdit3.GetCheckedItems().ToString()))
                    {
                        xlStringList = repositoryItemCheckedComboBoxEdit3.GetCheckedItems().ToString().Split(new char[] { ',' });
                        foreach (string str in xlStringList)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineCode like '" + str.Trim() + "%' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
                                tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
                                tj.SbOwner = strOwner;
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
   
                    }
                    else if (btGdsList.EditValue != null)
                    {
                        IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
                        mOrg org = null;
                        if (list.Count > 0)
                        {
                            org = list[0];
                        }
                        else
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }

                        if (org != null)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
                    }
                    break;
                default:
                    {
                        IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
                        mOrg org = null;
                        if (list.Count > 0)
                        {
                            org = list[0];
                        }
                        else
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", " Where sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = "全局";
                                tj.SbOwner = "全局";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }

                        if (org != null)
                        {
                            gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt,PS_xl,mOrg where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            tqSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqsbRowCountByWhere", ",PS_tq,PS_xl,mOrg where PS_tqsb.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and mOrg.OrgCode = '" + org.OrgCode + "' and sbName in " + getSelectSbName() + " group by sbModle,sbName");
                            foreach (object[] ob in gtSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                            foreach (object[] ob in tqSBList)
                            {
                                PS_tj tj = new PS_tj();
                                tj.SmOrg = org.OrgName;
                                tj.SbOwner = "全所";
                                tj.SBNumber = Convert.ToInt32(ob[0]);
                                tj.SbType = ob[1].ToString();
                                tj.SbName = ob[2].ToString();
                                tjList.Add(tj);
                            }
                        }
                    }
                    break;
            }

            gridControl1.BeginInit();
            gridControl1.DataSource = tjList;
            gridControl1.EndInit();
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
