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
using System.Collections;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_sbtj : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_tjsb> gridViewOperation;
        private DataTable dt = new DataTable();
        public event SendDataEventHandler<PS_tjsb> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        IList gtsbList;
        IList gtsbListAll;
        public UCPJ_sbtj()
        {
            InitializeComponent();
            //initImageList();
            gridViewOperation = new GridViewOperation<PS_tjsb>(gridControl1, gridView1, barManager1);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            Hashtable htall = new Hashtable();
            htall.Add("selectType", 0);
            gtsbListAll = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbName", htall);
            btXlList.EditValueChanged += new EventHandler(repositoryItemLookUpEdit2_EditValueChanged);           
        }

        void btSelectList_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        void repositoryItemLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            //this.ParentID = barEditItem2.EditValue.ToString();
        }

        void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e) {
            //
            string linecode = btXlList.EditValue==null?"":btXlList.EditValue.ToString();
            IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where left(tqcode,{0})='{1}'", linecode.Length, linecode));
            repositoryItemLookUpEdit3.DataSource = xlList;
           // RefreshData(string.Format("where left(tqcode,{0})='{1}'", linecode.Length, linecode));
            RefreshData();

        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_tjsb> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_tjsb> e)
        {
            if (parentID == null)
                e.Cancel = true;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            btSelectList.Edit = DicTypeHelper.TjDic;            
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic2;
            btSelectList.EditValueChanged += new EventHandler(btSelectList_EditValueChanged);
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
            {
                org = list[0];
            }
            else
            {
                repositoryItemLookUpEdit2.DataSource = null;
            }

            if (org != null) {
                ParentObj = org;
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                PS_xl xlTemp = new PS_xl();
                xlTemp.LineCode = "0";
                xlTemp.LineID = "0";
                xlTemp.LineName = "所有线路";
                xlList.Insert(0,xlTemp);
                repositoryItemLookUpEdit2.DataSource = xlList;                
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }
            RefreshData();
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tjsb);
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
            //RefreshData(" where ParentID='" + parentID + "' order by CreateDate desc");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            dt.Clear();
            dt = new DataTable();
           // dt.Columns.Add();
            //需要隐藏列时在这写代码
            int selectType = 0; 
            string orgCode = null;
            string lineCode = null;
            if (btSelectList.EditValue != null)
            {
                selectType = Convert.ToInt32(btSelectList.EditValue);
            }
            if (btGdsList.EditValue != null)
            {
                orgCode = btGdsList.EditValue.ToString();
                if (orgCode=="0"&&selectType == 1)
                {
                    selectType = 0;
                }
            }
            else
            {
                selectType = 0;
            }
            if (btXlList.EditValue!=null)
            {
                lineCode = btXlList.EditValue.ToString();
                if (lineCode=="0"&& selectType == 2)
                {
                    selectType = 1;
                }
            }
            else if (btGdsList.EditValue!=null)
            {
                selectType = 1;
            }
            Hashtable ht =new Hashtable();
            ht.Add("selectType", selectType);
            ht.Add("lineCode", lineCode);
            ht.Add("orgCode", orgCode);
            gtsbList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbName", ht);

            foreach (string str in gtsbListAll)
            {
                if (gtsbList.Contains(str)&& (gridView1.Columns.ColumnByName(str)==null))
                {
                    GridColumn gc = new GridColumn();
                    gc.Caption = str;
                    gc.Name = str;
                    gc.FieldName = str;
                    //gc.Visible = true;
                    gridView1.Columns.Add(gc);
                    gridView1.Columns[str].Visible = true;
                }
                else if (!gtsbList.Contains(str))
                {
                    if (gridView1.Columns.ColumnByName(str)!=null)
                    {
                        gridView1.Columns.Remove(gridView1.Columns.ColumnByName(str));
                    }
                }

            }
            dt.Reset();
            foreach (GridColumn col in gridView1.Columns)
            {
                DataColumn dc = new DataColumn();
                dc.Caption = col.GetCaption();
                dc.ColumnName = col.FieldName;                
                dt.Columns.Add(dc);
            }

            //hideColumn("ParentID");
            //hideColumn("gzrjID");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData()
        {
            gridViewOperation.BindingList.Clear();
            InitColumns();
            dt.Rows.Clear();
            //gridControl1.DataSource = null;
            if (btSelectList.EditValue!=null)
            {
                if (btSelectList.EditValue.ToString() == "1")
                {
                    if (btGdsList.EditValue != null&&btGdsList.EditValue.ToString() == "0")
                    {
                        IList<ViewGds> list = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
                        foreach (ViewGds gds in list)
                        {
                            string orgCode = gds.OrgCode;
                            DataRow dr = dt.NewRow();
                            Hashtable ht = new Hashtable();
                            ht.Add("orgCode", orgCode);
                            ht.Add("lineCode", "");
                            ht.Add("selectType", 1);
                            object byqCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCountbyProc", ht);
                            dr["SbName"] = gds.OrgName;
                            dr["ByqNumber"] = byqCount;
                            ht.Add("owner", "");
                            object byqSum = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht);
                            dr["ByqCapcity"] = byqSum;
                            object xlmaxgdbj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlmaxgdbjbyProc", ht);
                            dr["Radius"] = xlmaxgdbj;
                            ht.Add("lineVol", "10");
                            ht.Add("lineType", "");
                            object xllength10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht);
                            dr["Lengthsum"] = xllength10;
                            Hashtable ht2 = new Hashtable();
                            ht2.Add("orgCode", orgCode);
                            ht2.Add("lineCode", "");
                            ht2.Add("selectType", 1);
                            ht2.Add("lineType", "2");
                            ht2.Add("lineVol", "10");
                            object xlcountbranch10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlcountbyProc", ht2);
                            dr["LineNumber"] = xlcountbranch10;
                            Hashtable ht3 = new Hashtable();
                            ht3.Add("orgCode", orgCode);
                            ht3.Add("lineCode", "");
                            ht3.Add("selectType", 1);
                            ht3.Add("lineType", "1");
                            ht3.Add("lineVol", "10");
                            object xllength10main = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht3);
                            dr["LengthMain"] = xllength10main;
                            Hashtable ht4 = new Hashtable();
                            ht4.Add("orgCode", orgCode);
                            ht4.Add("lineCode", "");
                            ht4.Add("selectType", 1);
                            ht4.Add("lineType", "");
                            ht4.Add("lineVol", "0.4");
                            object xlength04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht4);
                            dr["LengthLow"] = xlength04;
                            Hashtable ht5 = new Hashtable();
                            ht5.Add("orgCode", orgCode);
                            ht5.Add("lineCode", "");
                            ht5.Add("selectType", 1);
                            ht5.Add("lineType", "2");
                            ht5.Add("lineVol", "10");
                            object xlength10branch = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht5);
                            dr["LengthBranch"] = xlength10branch;
                            Hashtable ht6 = new Hashtable();
                            ht6.Add("orgCode", orgCode);
                            ht6.Add("lineCode", "");
                            ht6.Add("selectType", 1);
                            ht6.Add("lineVol", "10");
                            object gtcount10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht6);
                            dr["NumbergtHigh"] = gtcount10;
                            Hashtable ht7 = new Hashtable();
                            ht7.Add("orgCode", orgCode);
                            ht7.Add("lineCode", "");
                            ht7.Add("selectType", 1);
                            ht7.Add("lineVol", "0.4");
                            object gtcount04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht7);
                            dr["NumbergtLow"] = gtcount04;
                            Hashtable ht8 = new Hashtable();
                            ht8.Add("orgCode", orgCode);
                            ht8.Add("lineCode", "");
                            ht8.Add("selectType", 1);
                            ht8.Add("owner", "");
                            object btcount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht8);
                            dr["NumberBT"] = btcount;
                            Hashtable ht9 = new Hashtable();
                            ht9.Add("orgCode", orgCode);
                            ht9.Add("lineCode", "");
                            ht9.Add("selectType", 1);
                            ht9.Add("owner", "局属");
                            object btcountju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht9);
                            dr["NumberBureau"] = btcountju;
                            object byqSumju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht9);
                            dr["CapcityBureau"] = byqSumju;
                            Hashtable ht10 = new Hashtable();
                            ht10.Add("orgCode", orgCode);
                            ht10.Add("lineCode", "");
                            ht10.Add("selectType", 1);
                            ht10.Add("owner", "自备");
                            object btcountzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht10);
                            dr["NumberPerson"] = btcountzi;
                            object byqSumzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht10);
                            dr["CapcityPerson"] = byqSumzi;
                            foreach (string str in gtsbList)
                            {
                                Hashtable ht11 = new Hashtable();
                                ht11.Add("orgCode", orgCode);
                                ht11.Add("lineCode", "");
                                ht11.Add("selectType", 1);
                                ht11.Add("sbName", str);
                                object sbCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbCount", ht11);
                                dr[str] = sbCount;
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                    else if (btGdsList.EditValue != null)
                    {
                        string orgCode = btGdsList.EditValue.ToString();
                        DataRow dr = dt.NewRow();
                        Hashtable ht = new Hashtable();
                        ht.Add("orgCode", orgCode);
                        ht.Add("lineCode", "");
                        ht.Add("selectType", 1);
                        object byqCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCountbyProc", ht);
                        dr["SbName"] = DicTypeHelper.GdsDic2.GetDisplayText(btGdsList.EditValue);
                        dr["ByqNumber"] = byqCount;
                        ht.Add("owner", "");
                        object byqSum = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht);
                        dr["ByqCapcity"] = byqSum;
                        object xlmaxgdbj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlmaxgdbjbyProc", ht);
                        dr["Radius"] = xlmaxgdbj;
                        ht.Add("lineVol", "10");
                        ht.Add("lineType", "");
                        object xllength10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht);
                        dr["Lengthsum"] = xllength10;
                        Hashtable ht2 = new Hashtable();
                        ht2.Add("orgCode", orgCode);
                        ht2.Add("lineCode", "");
                        ht2.Add("selectType",1);
                        ht2.Add("lineType", "2");
                        ht2.Add("lineVol", "10");
                        object xlcountbranch10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlcountbyProc", ht2);
                        dr["LineNumber"] = xlcountbranch10;
                        Hashtable ht3 = new Hashtable();
                        ht3.Add("orgCode", orgCode);
                        ht3.Add("lineCode", "");
                        ht3.Add("selectType",1);
                        ht3.Add("lineType", "1");
                        ht3.Add("lineVol", "10");
                        object xllength10main = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht3);
                        dr["LengthMain"] = xllength10main;
                        Hashtable ht4 = new Hashtable();
                        ht4.Add("orgCode", orgCode);
                        ht4.Add("lineCode", "");
                        ht4.Add("selectType",1);
                        ht4.Add("lineType", "");
                        ht4.Add("lineVol", "0.4");
                        object xlength04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht4);
                        dr["LengthLow"] = xlength04;
                        Hashtable ht5 = new Hashtable();
                        ht5.Add("orgCode", orgCode);
                        ht5.Add("lineCode", "");
                        ht5.Add("selectType",1);
                        ht5.Add("lineType", "2");
                        ht5.Add("lineVol", "10");
                        object xlength10branch = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht5);
                        dr["LengthBranch"] = xlength10branch;
                        Hashtable ht6 = new Hashtable();
                        ht6.Add("orgCode", orgCode);
                        ht6.Add("lineCode", "");
                        ht6.Add("selectType", 1);
                        ht6.Add("lineVol", "10");
                        object gtcount10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht6);
                        dr["NumbergtHigh"] = gtcount10;
                        Hashtable ht7 = new Hashtable();
                        ht7.Add("orgCode", orgCode);
                        ht7.Add("lineCode", "");
                        ht7.Add("selectType",1);
                        ht7.Add("lineVol", "0.4");
                        object gtcount04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht7);
                        dr["NumbergtLow"] = gtcount04;
                        Hashtable ht8 = new Hashtable();
                        ht8.Add("orgCode", orgCode);
                        ht8.Add("lineCode", "");
                        ht8.Add("selectType",1);
                        ht8.Add("owner", "");
                        object btcount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht8);
                        dr["NumberBT"] = btcount;
                        Hashtable ht9 = new Hashtable();
                        ht9.Add("orgCode", orgCode);
                        ht9.Add("lineCode", "");
                        ht9.Add("selectType",1);
                        ht9.Add("owner", "局属");
                        object btcountju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht9);
                        dr["NumberBureau"] = btcountju;
                        object byqSumju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht9);
                        dr["CapcityBureau"] = byqSumju;
                        Hashtable ht10 = new Hashtable();
                        ht10.Add("orgCode", orgCode);
                        ht10.Add("lineCode", "");
                        ht10.Add("selectType",1);
                        ht10.Add("owner", "自备");
                        object btcountzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht10);
                        dr["NumberPerson"] = btcountzi;
                        object byqSumzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht10);
                        dr["CapcityPerson"] = byqSumzi;
                        foreach (string str in gtsbList)
                        {
                            Hashtable ht11 = new Hashtable();
                            ht11.Add("orgCode", orgCode);
                            ht11.Add("lineCode", "");
                            ht11.Add("selectType",1);
                            ht11.Add("sbName", str);
                            object sbCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbCount", ht11);
                            dr[str] = sbCount;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                else if (btSelectList.EditValue.ToString() == "2")
                {
                    if (btXlList.EditValue != null&&btXlList.EditValue.ToString() == "0")
                    {
                         string orgCode = btGdsList.EditValue.ToString();
                         if (orgCode!=null&&orgCode!="")
                         {
                             IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + orgCode + "'");
                             foreach (PS_xl xl in xlList)
                             {
                                 string lineCode = xl.LineCode;
                                 DataRow dr = dt.NewRow();
                                 Hashtable ht = new Hashtable();
                                 ht.Add("orgCode", orgCode);
                                 ht.Add("lineCode", lineCode);
                                 ht.Add("selectType", 2);
                                 object byqCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCountbyProc", ht);
                                 dr["SbName"] = xl.LineName;
                                 dr["ByqNumber"] = byqCount;
                                 ht.Add("owner", "");
                                 object byqSum = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht);
                                 dr["ByqCapcity"] = byqSum;
                                 object xlmaxgdbj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlmaxgdbjbyProc", ht);
                                 dr["Radius"] = xlmaxgdbj;
                                 ht.Add("lineVol", "10");
                                 ht.Add("lineType", "");
                                 object xllength10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht);
                                 dr["Lengthsum"] = xllength10;
                                 Hashtable ht2 = new Hashtable();
                                 ht2.Add("orgCode", orgCode);
                                 ht2.Add("lineCode", lineCode);
                                 ht2.Add("selectType", 2);
                                 ht2.Add("lineType", "2");
                                 ht2.Add("lineVol", "10");
                                 object xlcountbranch10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlcountbyProc", ht2);
                                 dr["LineNumber"] = xlcountbranch10;
                                 Hashtable ht3 = new Hashtable();
                                 ht3.Add("orgCode", orgCode);
                                 ht3.Add("lineCode", lineCode);
                                 ht3.Add("selectType", 2);
                                 ht3.Add("lineType", "1");
                                 ht3.Add("lineVol", "10");
                                 object xllength10main = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht3);
                                 dr["LengthMain"] = xllength10main;
                                 Hashtable ht4 = new Hashtable();
                                 ht4.Add("orgCode", orgCode);
                                 ht4.Add("lineCode", lineCode);
                                 ht4.Add("selectType", 2);
                                 ht4.Add("lineType", "");
                                 ht4.Add("lineVol", "0.4");
                                 object xlength04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht4);
                                 dr["LengthLow"] = xlength04;
                                 Hashtable ht5 = new Hashtable();
                                 ht5.Add("orgCode", orgCode);
                                 ht5.Add("lineCode", lineCode);
                                 ht5.Add("selectType", 2);
                                 ht5.Add("lineType", "2");
                                 ht5.Add("lineVol", "10");
                                 object xlength10branch = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht5);
                                 dr["LengthBranch"] = xlength10branch;
                                 Hashtable ht6 = new Hashtable();
                                 ht6.Add("orgCode", orgCode);
                                 ht6.Add("lineCode", lineCode);
                                 ht6.Add("selectType", 2);
                                 ht6.Add("lineVol", "10");
                                 object gtcount10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht6);
                                 dr["NumbergtHigh"] = gtcount10;
                                 Hashtable ht7 = new Hashtable();
                                 ht7.Add("orgCode", orgCode);
                                 ht7.Add("lineCode", lineCode);
                                 ht7.Add("selectType", 2);
                                 ht7.Add("lineVol", "0.4");
                                 object gtcount04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht7);
                                 dr["NumbergtLow"] = gtcount04;
                                 Hashtable ht8 = new Hashtable();
                                 ht8.Add("orgCode", orgCode);
                                 ht8.Add("lineCode", lineCode);
                                 ht8.Add("selectType", 2);
                                 ht8.Add("owner", "");
                                 object btcount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht8);
                                 dr["NumberBT"] = btcount;
                                 Hashtable ht9 = new Hashtable();
                                 ht9.Add("orgCode", orgCode);
                                 ht9.Add("lineCode", lineCode);
                                 ht9.Add("selectType", 2);
                                 ht9.Add("owner", "局属");
                                 object btcountju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht9);
                                 dr["NumberBureau"] = btcountju;
                                 object byqSumju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht9);
                                 dr["CapcityBureau"] = byqSumju;
                                 Hashtable ht10 = new Hashtable();
                                 ht10.Add("orgCode", orgCode);
                                 ht10.Add("lineCode", lineCode);
                                 ht10.Add("selectType", 2);
                                 ht10.Add("owner", "自备");
                                 object btcountzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht10);
                                 dr["NumberPerson"] = btcountzi;
                                 object byqSumzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht10);
                                 dr["CapcityPerson"] = byqSumzi;
                                 foreach (string str in gtsbList)
                                 {
                                     Hashtable ht11 = new Hashtable();
                                     ht11.Add("orgCode", orgCode);
                                     ht11.Add("lineCode", lineCode);
                                     ht11.Add("selectType", 2);
                                     ht11.Add("sbName", str);
                                     object sbCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbCount", ht11);
                                     dr[str] = sbCount;
                                 }
                                 dt.Rows.Add(dr);
                             }
                         }                      
                        
                    }
                    else if (btXlList.EditValue != null)    
                     {
                         string orgCode = btGdsList.EditValue.ToString();
                         string lineCode = btXlList.EditValue.ToString();
                         DataRow dr = dt.NewRow();
                         Hashtable ht = new Hashtable();
                         ht.Add("orgCode", orgCode);
                         ht.Add("lineCode", lineCode);
                         ht.Add("selectType", 2);
                         object byqCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCountbyProc", ht);
                         dr["SbName"] = repositoryItemLookUpEdit2.GetDisplayText(btXlList.EditValue);
                         dr["ByqNumber"] = byqCount;
                         ht.Add("owner", "");
                         object byqSum = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht);
                         dr["ByqCapcity"] = byqSum;
                         object xlmaxgdbj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlmaxgdbjbyProc", ht);
                         dr["Radius"] = xlmaxgdbj;
                         ht.Add("lineVol", "10");
                         ht.Add("lineType", "");
                         object xllength10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht);
                         dr["Lengthsum"] = xllength10;
                         Hashtable ht2 = new Hashtable();
                         ht2.Add("orgCode", orgCode);
                         ht2.Add("lineCode", lineCode);
                         ht2.Add("selectType", 2);
                         ht2.Add("lineType", "2");
                         ht2.Add("lineVol", "10");
                         object xlcountbranch10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlcountbyProc", ht2);
                         dr["LineNumber"] = xlcountbranch10;
                         Hashtable ht3 = new Hashtable();
                         ht3.Add("orgCode", orgCode);
                         ht3.Add("lineCode", lineCode);
                         ht3.Add("selectType", 2);
                         ht3.Add("lineType", "1");
                         ht3.Add("lineVol", "10");
                         object xllength10main = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht3);
                         dr["LengthMain"] = xllength10main;
                         Hashtable ht4 = new Hashtable();
                         ht4.Add("orgCode", orgCode);
                         ht4.Add("lineCode", lineCode);
                         ht4.Add("selectType", 2);
                         ht4.Add("lineType", "");
                         ht4.Add("lineVol", "0.4");
                         object xlength04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht4);
                         dr["LengthLow"] = xlength04;
                         Hashtable ht5 = new Hashtable();
                         ht5.Add("orgCode", orgCode);
                         ht5.Add("lineCode", lineCode);
                         ht5.Add("selectType",2);
                         ht5.Add("lineType", "2");
                         ht5.Add("lineVol", "10");
                         object xlength10branch = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht5);
                         dr["LengthBranch"] = xlength10branch;
                         Hashtable ht6 = new Hashtable();
                         ht6.Add("orgCode", orgCode);
                         ht6.Add("lineCode", lineCode);
                         ht6.Add("selectType", 2);
                         ht6.Add("lineVol", "10");
                         object gtcount10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht6);
                         dr["NumbergtHigh"] = gtcount10;
                         Hashtable ht7 = new Hashtable();
                         ht7.Add("orgCode", orgCode);
                         ht7.Add("lineCode", lineCode);
                         ht7.Add("selectType", 2);
                         ht7.Add("lineVol", "0.4");
                         object gtcount04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht7);
                         dr["NumbergtLow"] = gtcount04;
                         Hashtable ht8 = new Hashtable();
                         ht8.Add("orgCode", orgCode);
                         ht8.Add("lineCode", lineCode);
                         ht8.Add("selectType", 2);
                         ht8.Add("owner", "");
                         object btcount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht8);
                         dr["NumberBT"] = btcount;
                         Hashtable ht9 = new Hashtable();
                         ht9.Add("orgCode", orgCode);
                         ht9.Add("lineCode", lineCode);
                         ht9.Add("selectType",2);
                         ht9.Add("owner", "局属");
                         object btcountju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht9);
                         dr["NumberBureau"] = btcountju;
                         object byqSumju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht9);
                         dr["CapcityBureau"] = byqSumju;
                         Hashtable ht10 = new Hashtable();
                         ht10.Add("orgCode", orgCode);
                         ht10.Add("lineCode", lineCode);
                         ht10.Add("selectType", 2);
                         ht10.Add("owner", "自备");
                         object btcountzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht10);
                         dr["NumberPerson"] = btcountzi;
                         object byqSumzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht10);
                         dr["CapcityPerson"] = byqSumzi;
                         foreach (string str in gtsbList)
                         {
                             Hashtable ht11 = new Hashtable();
                             ht11.Add("orgCode", orgCode);
                             ht11.Add("lineCode", lineCode);
                             ht11.Add("selectType",2);
                             ht11.Add("sbName", str);
                             object sbCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbCount", ht11);
                             dr[str] = sbCount;
                         }
                         dt.Rows.Add(dr);
                     }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    Hashtable ht = new Hashtable();
                    ht.Add("orgCode", "");
                    ht.Add("lineCode", "");
                    ht.Add("selectType", 0);
                    object byqCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCountbyProc", ht);
                    dr["SbName"] = "绥化电业局";
                    dr["ByqNumber"] = byqCount;
                    ht.Add("owner", "");
                    object byqSum = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht);
                    dr["ByqCapcity"] = byqSum;
                    object xlmaxgdbj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlmaxgdbjbyProc", ht);
                    dr["Radius"] = xlmaxgdbj;
                    ht.Add("lineVol", "10");
                    ht.Add("lineType", "");
                    object xllength10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc",ht);
                    dr["Lengthsum"] = xllength10;
                    Hashtable ht2 = new Hashtable();
                    ht2.Add("orgCode", "");
                    ht2.Add("lineCode", "");
                    ht2.Add("selectType", 0);
                    ht2.Add("lineType", "2");
                    ht2.Add("lineVol", "10");
                    object xlcountbranch10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlcountbyProc", ht2);
                    dr["LineNumber"] = xlcountbranch10;
                    Hashtable ht3 = new Hashtable();
                    ht3.Add("orgCode", "");
                    ht3.Add("lineCode", "");
                    ht3.Add("selectType", 0);
                    ht3.Add("lineType", "1");
                    ht3.Add("lineVol", "10");
                    object xllength10main = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht3);
                    dr["LengthMain"] = xllength10main;
                    Hashtable ht4 = new Hashtable();
                    ht4.Add("orgCode", "");
                    ht4.Add("lineCode", "");
                    ht4.Add("selectType", 0);
                    ht4.Add("lineType", "");
                    ht4.Add("lineVol", "0.4");
                    object xlength04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht4);
                    dr["LengthLow"] = xlength04;
                    Hashtable ht5 = new Hashtable();
                    ht5.Add("orgCode", "");
                    ht5.Add("lineCode", "");
                    ht5.Add("selectType", 0);
                    ht5.Add("lineType", "2");
                    ht5.Add("lineVol", "10");
                    object xlength10branch = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllengthbyProc", ht5);
                    dr["LengthBranch"] = xlength10branch;
                    Hashtable ht6 = new Hashtable();
                    ht6.Add("orgCode", "");
                    ht6.Add("lineCode", "");
                    ht6.Add("selectType", 0);
                    ht6.Add("lineVol", "10");
                    object gtcount10 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht6);
                    dr["NumbergtHigh"] = gtcount10;
                    Hashtable ht7 = new Hashtable();
                    ht7.Add("orgCode", "");
                    ht7.Add("lineCode", "");
                    ht7.Add("selectType", 0);
                    ht7.Add("lineVol", "0.4");
                    object gtcount04 = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqcountbyProc", ht7);
                    dr["NumbergtLow"] = gtcount04;
                    Hashtable ht8 = new Hashtable();
                    ht8.Add("orgCode", "");
                    ht8.Add("lineCode", "");
                    ht8.Add("selectType", 0);
                    ht8.Add("owner", "");
                    object btcount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht8);
                    dr["NumberBT"] = btcount;
                    Hashtable ht9 = new Hashtable();
                    ht9.Add("orgCode", "");
                    ht9.Add("lineCode", "");
                    ht9.Add("selectType", 0);
                    ht9.Add("owner", "局属");
                    object btcountju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht9);
                    dr["NumberBureau"] = btcountju;
                    object byqSumju = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht9);
                    dr["CapcityBureau"] = byqSumju;
                    Hashtable ht10 = new Hashtable();
                    ht10.Add("orgCode", "");
                    ht10.Add("lineCode", "");
                    ht10.Add("selectType", 0);
                    ht10.Add("owner", "自备");
                    object btcountzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCountbyProc", ht10);
                    dr["NumberPerson"] = btcountzi;
                    object byqSumzi = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity_sumbyProc", ht10);
                    dr["CapcityPerson"] = byqSumzi;
                    foreach (string str in gtsbList)
                    {
                        Hashtable ht11 = new Hashtable();
                        ht11.Add("orgCode", "");
                        ht11.Add("lineCode", "");
                        ht11.Add("selectType", 0);
                        ht11.Add("sbName", str);
                        object sbCount = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbCount", ht11);
                        dr[str] = sbCount;
                    }
                    dt.Rows.Add(dr);
                }
            }         
            
            //gridControl1.DataSource = dt;
         
            gridControl1.DataSource = dt;
            
            gridView1.RefreshData();
            foreach (GridColumn gc in gridView1.Columns)
            {
                gc.Caption = dt.Columns[gc.FieldName].Caption;
            }
            
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PS_tjsb> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_tjsb newobj)
        {

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
                    RefreshData(" where ParentID='" + value + "' order by CreateDate desc");
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

        private void btExport0_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }



    }
}
