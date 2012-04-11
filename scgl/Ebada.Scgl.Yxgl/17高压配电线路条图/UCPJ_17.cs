/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-5-23
最后一次修改:2011-5-23
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Components;
using Ebada.Client;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;
using FarPoint.Win.Spread;
using System.Collections;
using System.IO;
using Microsoft.Office.Core;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_17 : DevExpress.XtraEditors.XtraUserControl {

        //TreeViewOperation<PS_xl> treeViewOperator;
        //private string parentID = "";
        //[Browsable(false)]
        //public TreeViewOperation<PS_xl> TreeViewOperator {
        //    get { return treeViewOperator; }
        //    set { treeViewOperator = value; }
        //}
        
        //public event SendDataEventHandler<PS_xl> FocusedNodeChanged;
        //public event SendDataEventHandler<PS_xl> AfterAdd;
        //public event SendDataEventHandler<PS_xl> AfterEdit;
        //public event SendDataEventHandler<PS_xl> AfterDelete;
        //public UCPJ_17() {
        //    InitializeComponent();
        //    treeViewOperator = new TreeViewOperation<PS_xl>(treeList1, barManager1,null);
        //    treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
        //    treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
        //    treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
        //    treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
        //    treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
        //    btGDS.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
        //    Init();
        //}

        //void btGDS_EditValueChanged(object sender, EventArgs e)
        //{
        //    parentID = btGDS.EditValue.ToString();
        //    InitData();
        //}

        //void treeViewOperator_AfterDelete(PS_xl newobj) {
        //    if (AfterDelete != null)
        //        AfterDelete(treeList1, newobj);
        //}

        //void treeViewOperator_AfterEdit(PS_xl newobj) {
        //    if (AfterAdd != null)
        //        AfterEdit(treeList1, newobj);
        //}

        //void treeViewOperator_AfterAdd(PS_xl newobj) {
        //    if (AfterAdd != null)
        //        AfterAdd(treeList1, newobj);
        //}

        //void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
        //    if (FocusedNodeChanged != null)
        //        FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as PS_xl);
        //}

        //void treeViewOperator_CreatingObject(PS_xl newobj) {
        //}
        TreeViewOperation<PJ_17> treeViewOperator;
        private string parentID = "";
        private mOrg parentObj = null;
        [Browsable(false)]
        public TreeViewOperation<PJ_17> TreeViewOperator
        {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        public event SendDataEventHandler<PJ_17> FocusedNodeChanged;
        public event SendDataEventHandler<PJ_17> AfterAdd;
        public event SendDataEventHandler<PJ_17> AfterEdit;
        public event SendDataEventHandler<PJ_17> AfterDelete;
        public UCPJ_17()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<PJ_17>(treeList1, barManager1, null);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            Init();
        }

        void btGDS_EditValueChanged(object sender, EventArgs e)
        {
            parentID = btGdsList.EditValue.ToString();
            InitData();
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                parentObj = org;
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where LineVol='10' and OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
            }
        }

        void treeViewOperator_AfterDelete(PJ_17 newobj)
        {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(PJ_17 newobj)
        {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(PJ_17 newobj)
        {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as PJ_17);
        }

        void treeViewOperator_CreatingObject(PJ_17 newobj)
        {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }
        public void Init() {

            //treeList1.Columns["OrgCode"].Visible = true;
            //treeList1.Columns["LineType"].Visible = false;
            //treeList1.Columns["LineNamePath"].Visible = false;
            //treeList1.Columns["LineGtbegin"].Visible = false;
            //treeList1.Columns["LineGtend"].Visible = false;
            //treeList1.Columns["WireLength"].Visible = false;
            //treeList1.Columns["TotalLength"].Visible = false;
            //treeList1.Columns["ActualLoss"].Visible = false;


            //treeList1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
            //treeList1.Columns["OrgCode2"].ColumnEdit = DicTypeHelper.BdsDic;
            //treeList1.Columns["Owner"].ColumnEdit = DicTypeHelper.OwnerDic;
            //treeList1.Columns["RunState"].ColumnEdit = DicTypeHelper.RunState;
            //btGDS.Edit = DicTypeHelper.GdsDic;

            treeList1.Columns["gzrjID"].Visible = false;

            //btGdsList.Edit = DicTypeHelper.GdsDic;
            //IList<PS_xl> xlList = null;
            //if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {
            //    xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where LineVol='10' and OrgCode='" + MainHelper.User.OrgCode + "'");
            //} else {
            //    xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where LineVol='10' ");
            //}
            //repositoryItemLookUpEdit2.DataSource = xlList;
            //if (this.Site == null)
            //    InitData();

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData(" where OrgCode='" + parentID + "' order by linetype,linecode");
            treeViewOperator.RefreshData(" where OrgCode='" + parentID + "' order by  CreateDate");
        }

        

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btXlList.EditValue == null|| btXlList.EditValue.ToString()=="" )
            {
                return;
            }
            PS_xl xl= btXlList.EditValue as PS_xl;
            PJ_17 pj = new PJ_17();
            pj.CreateDate = DateTime.Now;
            pj.CreateMan = MainHelper.User.UserName;
            pj.LineName = xl.LineName;
            pj.LineCode = xl.LineCode;
            pj.OrgCode  = xl.OrgCode ;
            pj.OrgName = parentObj.OrgName;
            pj.Remark ="";
            MainHelper.PlatformSqlMap.Create<PJ_17>(pj);

            InitData();
            //if (MsgBox.ShowAskMessageBox("是否马上生成条图") == DialogResult.OK)
            {
                
                try
                {
                    if (ExportToExcel("高压配电线路条图", "", pj) < 1) return;

                    frm17Template frm = new frm17Template();
                    frm.pjobject = pj;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Client.ClientHelper.PlatformSqlMap.Update<PJ_17>(frm.pjobject);
                        //MessageBox.Show("保存成功");
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex);  

                }
            }
            
        }
     

        public static int ExportToExcel(string title, string dw, PJ_17 pj17)
        {
            string fname = Application.StartupPath + "\\00记录模板\\17线路条图.xls";
            float fxstart = 0, fystart = 0, fwidth = 0, fheight = 0;
             DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
             string outfname = Path.GetTempPath()+ "~"+Guid.NewGuid().ToString()+".xls";
             File.Copy(fname, outfname);
             dsoFramerWordControl1.FileOpen(outfname);
             Microsoft.Office.Interop.Excel.Worksheet xx;
             Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
             ExcelAccess ex = new ExcelAccess();
             ex.MyWorkBook = wb;
             ex.MyExcel = wb.Application;
             PS_xl xl = MainHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + pj17.LineCode + "'");
             try
             {
                 if (xl == null)
                 {
                     MsgBox.ShowWarningMessageBox("数据出错，没找到线路");
                     return -1;
                 }
                 PS_gt gtformer = null;
                 IList<PS_gt> gtlis = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(" Where LineCode='" + xl.LineCode + "' order by gth");
                 gtformer = Client.ClientHelper.PlatformSqlMap.GetOne<PS_gt>(" Where gtID='" + xl.ParentGT + "'");
                 gtlis.Insert(0, gtformer);
                 //计算页码
                 int pagecount = 1, jmax = 15, m = 0, j = 0;
                 pagecount = gtlis.Count / 15 + 1;
                 int ihang = 8, jlie = 2;
                 int i = 0;
                 //复制空模板
                 for (m = 1; m < pagecount; m++)
                 {
                     ex.CopySheet(1, m);
                     ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
                 }
                 string[] strname = new string[3];
                 strname[0] = "";
                 strname[1] = "";
                 strname[2] = "";

                 if (xl.LineType == "1")
                 {
                     strname[0] = xl.LineName.Split('线')[0];
                     strname[1] = xl.LineName.Replace(strname[0] + "线", "");


                 }
                 else
                     if (xl.LineType == "2")
                     {
                         PS_xl xltemp = MainHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + xl.ParentID + "'");
                         if (xltemp!=null)
                         strname[0] = xltemp.LineName;
                         strname[1] = xl.LineName;
                     }
                     else if (xl.LineType == "3")
                     {
                         PS_xl xltemp = MainHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + xl.ParentID + "'");
                         if (xltemp != null)
                         {
                             strname[1] = xltemp.LineName;
                             xltemp = MainHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + xltemp.ParentID + "'");
                             if (xltemp != null) strname[0] = xltemp.LineName;
                         }
                     }
                 //填写公共项
                 for (m = 1; m <= pagecount; m++)
                 {
                     ex.ActiveSheet("Sheet" + m);
                     ex.SetCellValue( strname[0], 3, 2);
                     ex.SetCellValue( strname[1], 3, 5);
                     ex.SetCellValue( strname[2], 3, 11);
                     ex.SetCellValue(xl.LineVol.ToString(), 3, 20);

                 }
                 ihang = 8;
                 jlie = 3;
                 int hdRowCount = 1;
                 int jyzRowCount = 1;
                 int dxRowCount = 1;
                 int btRowCount = 1;
                 int blqRowCount =1;
                 int kgRowCount = 1;
                 int lxRowCount = 1;
                 int jstart = 3;
                 Excel.Range range;
                 for (i = 1; i < gtlis.Count; i++)
                 {
                     if ((i + 0.0) % (jmax) == 1)
                     {

                         jlie = 3;
                         ihang = 8;
                         hdRowCount = 1;
                         jyzRowCount = 1;
                         dxRowCount = 1;
                         btRowCount = 1;
                         blqRowCount = 1;
                         kgRowCount = 1;
                         lxRowCount = 1;
                   
                     }
                     if (Math.Ceiling((i + 0.0) / (jmax)) > 1)
                     {
                         ex.ActiveSheet("Sheet" + Math.Ceiling((i + 0.0) / (jmax)));
                         xx = wb.Application.Sheets["Sheet" + Math.Ceiling((i + 0.0) / (jmax))] as Microsoft.Office.Interop.Excel.Worksheet;


                     }
                     else
                     {
                         ex.ActiveSheet("Sheet1");
                         xx = wb.Application.Sheets["Sheet1"] as Microsoft.Office.Interop.Excel.Worksheet;
                     }
                     
                     //ex.SetCellValue(i.ToString(), ihang, jlie);
                     
                     ////杆塔数
                     PS_gt gtobj = gtlis[i ];
                     //if (gtobj == null)
                     //{
                     //    if ((i + 0.0) % (jmax) == 0&&i>1)
                     //    {
                     //        //累计长度
                     //        double sum = 0;
                     //        for (int item = i; item < i + 15 && item < gtlis.Count; item++)
                     //        {
                     //            PS_gt gttemp = gtlis[item];
                     //            if (gttemp != null)
                     //            {
                     //                sum += Convert.ToDouble(gttemp.gtSpan);
                     //            }
                     //        }
                     //        ex.SetCellValue(sum.ToString(), ihang, 2);
                     //    }
                     //    jlie += 2;
                     //    continue;

                     //}
                     //绝缘子
                     string strSQL = "select distinct sbModle from PS_gtsb Where  gtID='" + gtobj.gtID + "' ";
                     if (xl.LineVol != "" && Convert.ToDouble(xl.LineVol) >= 10)
                     {
                         strSQL+= "  and (sbName like '高压%立瓶%' or sbName like '高压%悬垂%' or sbName like '高压%茶台%' )";
                     }
                     else
                         if (xl.LineVol != "" && 0.4 >= Convert.ToDouble(xl.LineVol))
                         {
                             strSQL+= "  and (sbName like '低压%立瓶%'  or sbName like '低压%茶台%' )";
                         }

                     IList jyuzlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);

                     //变台
                     //IList btlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from PS_gtsb Where sbName like '%变压器%' and gtID='" + gtobj.gtID + "'");
                     IList btlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct bttype from PS_tq Where   gtID='" + gtobj.gtID + "'");

                     //避雷器
                     IList blqlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from PS_gtsb Where sbName='避雷器' and gtID='" + gtobj.gtID + "'");

                     //开关
                     IList kglist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct kgModle from PS_kg Where gtID='" + gtobj.gtID + "'");

                     //导线型号
                     IList dxlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct sbModle from PS_gtsb  Where sbName like '%导线%' and gtID='" + gtobj.gtID + "'");
                     //导线排列方式
                     IList dxpllist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct C1 from PS_gtsb  Where sbName like '%导线%' and gtID='" + gtobj.gtID + "'");

                     //横担规格
                     IList hdobj = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from PS_gtsb Where sbName like '%横担%' and gtID='" + gtobj.gtID + "'");

                     //拉线规格
                     IList lxlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from PS_gtsb  Where sbName like '%拉线%' and gtID='" + gtobj.gtID + "'");
                    
                     IList ilisttemp = null;
                     //if (hdobj.Count < 3)
                     //{
                     //   hdobj.Add("横担1");
                     //   hdobj.Add("横担2");
                     //   hdobj.Add("横担3");
                     //}
                     //if (jyuzlist.Count < 9)
                     //{
                     //    jyuzlist.Add("jyz1");
                     //    jyuzlist.Add("jyz2");
                     //    jyuzlist.Add("jyz3");
                     //    jyuzlist.Add("jyz4");
                     //    jyuzlist.Add("jyz3");
                     //    jyuzlist.Add("jyz5");
                     //    jyuzlist.Add("jyz6");
                     //    jyuzlist.Add("jyz7");
                     //    jyuzlist.Add("jyz8");
                     //    jyuzlist.Add("jyz9");
                     //}

                     //if (dxlist.Count < 3)
                     //{
                     //    dxlist.Add("dxlist1");
                     //    dxlist.Add("dxlist2");
                     //    dxlist.Add("dxlist3");
                     //    dxlist.Add("dxlist4");
                     //}

                     //if (btlist.Count < 3)
                     //{
                     //    btlist.Add("btlist1");
                     //    btlist.Add("btlist2");
                     //    btlist.Add("btlist3");
                     //}

                     //if (blqlist.Count < 3)
                     //{
                     //    blqlist.Add("blqlist1");
                     //    blqlist.Add("blqlist2");
                     //    blqlist.Add("blqlist3");
                     //}

                     //if (kglist.Count < 3)
                     //{
                     //    kglist.Add("kglist1");
                     //    kglist.Add("kglist2");
                     //    kglist.Add("kglist3");
                     //}

                     //if (lxlist.Count < 3)
                     //{
                     //    lxlist.Add("lxlist1");
                     //    lxlist.Add("lxlist2");
                     //    lxlist.Add("kglist3");
                     //}


                     ihang = 8;
                     ////杆号
                     ex.SetCellValue((i).ToString(), ihang, jlie);
                     ihang++;

                     //转角方向
                     if (gtobj.gtModle.IndexOf("转角") > -1)
                     {
                         if (i != 1 && i < gtlis.Count - 1)
                         {
                             
                             string strfx = "";
                             decimal[,] a1 = new decimal[1, 2];
                             decimal[,] a2 = new decimal[1, 2];
                             a1[0, 0] = gtlis[i].gtLat - gtlis[i - 1].gtLat;
                             a1[0, 1] = gtlis[i].gtLon - gtlis[i - 1].gtLon;

                             a2[0, 0] = gtlis[i + 1].gtLat - gtlis[i].gtLat;
                             a2[0, 1] = gtlis[i + 1].gtLon - gtlis[i].gtLon;
                             decimal di = a1[0, 0] * a2[0, 0] + a1[0, 1] * a2[0, 1];
                             double dl = Math.Sqrt(Convert.ToDouble(a1[0, 0] * a1[0, 0] + a1[0, 1] * a1[0, 1]) * Math.Sqrt(Convert.ToDouble(
                                 a2[0, 0] * a2[0, 0] + a2[0, 1] * a2[0, 1])));
                             double dc = Math.Round(180 * Math.Acos(Convert.ToDouble(di) / Convert.ToDouble(dl)) / 3.1415926, 0);
                             if (gtlis[i].gtLon > gtlis[i - 1].gtLon)
                             {
                                 strfx = "右转";
                             }
                             else
                             {
                                 strfx = "左转";
                             }
                             if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                 ex.SetCellValue(strfx + dc + "度", ihang, jlie);
                             else
                             {

                             }
                         }

                     }
                     ihang++;

                     //杆高（m）
                     if (gtobj != null)
                     {

                         ex.SetCellValue(gtobj.gtHeight.ToString(), ihang, jlie);

                     }
                     ihang++;

                     //电杆种类/杆型
                     if (gtobj != null)
                     {
                         if (gtobj.gtType+"/" +gtobj.gtModle == "混凝土拔梢杆/直线杆")
                         {
                             ex.SetCellValue("砼/直", ihang, jlie);
                         }
                         else
                             if (gtobj.gtModle == ("直线杆"))
                             {
                                 ex.SetCellValue("直", ihang, jlie);
                             }
                             else
                                 if (gtobj.gtType.IndexOf("混凝土") > -1)
                                 {
                                     ex.SetCellValue("砼" + gtobj.gtModle, ihang, jlie);
                                 }
                                 else
                                 {
                                     ex.SetCellValue(gtobj.gtType+"/"+gtobj.gtModle, ihang, jlie);
                                 }
                     }
                     ihang++;
                     //导线排列方式

                     //if (gtobj.dxplfs == "")
                     //{

                     //    ex.SetCellValue("水平", ihang, jlie);
                     //}
                     //else
                     //{
                     //    ex.SetCellValue(gtobj.dxplfs, ihang, jlie);
                     //}
                     if (((i + 0.0) % (jmax) == 0 && i > 1) || i == gtlis.Count)
                     {
                         //合并同类项
                         string stplrname = "";
                         int ista = i, item = i, jlietemp = jlie;
                         for (item = i; item > 1; item--)
                         {
                             PS_gt gttemp = gtlis[item - 1];
                             PS_gt gttemp2 = gtlis[item - 2];
                             IList dxpllist2 =null;
                             IList dxpllist3 =null;
                             string str1 = "", str2 = "";
                             if (gttemp!=null)
                             {
                             dxpllist2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                                 "select distinct C1 from PS_gtsb  Where sbName like '%导线%' and gtID='" + gttemp.gtID + "'");
                             if (dxpllist2.Count > 0) str1 = dxpllist2[0].ToString();
                             }
                             if (gttemp2 != null)
                             {
                                 dxpllist3 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                                     "select distinct C1 from PS_gtsb  Where sbName like '%导线%' and gtID='" + gttemp2.gtID + "'");
                                 if (dxpllist3.Count > 0) str2 = dxpllist3[0].ToString();
                             }

                             if (gttemp2 == null || str2 == str1)
                             {
                                 if (jlietemp > 4)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang, jlietemp], xx.Cells[ihang, jlietemp - 2]);
                                     range.Merge(Type.Missing);
                                     if ((item % jmax == 2 && ista != item) || jlietemp==5)
                                     {
                                         if (str1 != "")
                                             ex.SetCellValue(str1, ihang, jlietemp - 2);
                                         else
                                             ex.SetCellValue("水平", ihang, jlietemp - 2);

                                     }
                                 }
                             }
                             else
                             {
                                 ex.SetCellValue(str1, ihang, jlietemp);
                             }
                             jlietemp = jlietemp - 2;
                             if (item % jmax == 2 && ista != item)
                             {
                                 break;
                             }

                         }
                     }

                     ihang++;
                     //导线型号规格（mm2）
                     if (dxlist != null && dxlist.Count > 0)
                     {
                         if (dxlist.Count > dxRowCount)
                         {
                             for (j = dxRowCount; j < dxlist.Count; j++)
                             {
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang + dxRowCount, "A"], xx.Cells[ihang + dxRowCount, "A"]);
                                 range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);

                             }
                             for (int jtem = 1; jtem < dxlist.Count; jtem++)
                             {
                                 for (int item = 0; item < 29; item += 2)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + 1 + item]);
                                     range.Merge(Type.Missing);
                                 }
                             }
                             dxRowCount = dxlist.Count;
                             range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + dxRowCount - 1, 1]);
                             range.Merge(Type.Missing);
                         }
                         if (dxlist.Count > 0)
                         {

                             for (j = 0; j < dxlist.Count; j++)
                                 ex.SetCellValue(dxlist[j].ToString(), ihang + j, jlie);
                         }

                     }

                     ihang += dxRowCount;

                     //档        距（m）
                     if (gtobj != null)
                     {
                         if (jlie > 2)
                             ex.SetCellValue(gtobj.gtSpan.ToString(), ihang, jlie - 1);
                         else
                             ex.SetCellValue(gtobj.gtSpan.ToString(), ihang, jlie);
                     }
                     ihang++;
                     //累计长度


                     if (((i + 0.0) % (jmax) == 0 && i > 1) || i == gtlis.Count-1)
                     {
                         //累计长度
                         double sum = 0;
                         int ista = i, item = i;
                         for (item = i; item > 0; item--)
                         {
                             PS_gt gttemp = gtlis[item - 1];
                             if (gttemp != null)
                             {
                                 sum += Convert.ToDouble(gttemp.gtSpan);
                             }
                             if (i < gtlis.Count)
                             {
                                 if (item % jmax == 1 && ista != item)
                                 {
                                     break;
                                 }
                             }
                             else
                             {
                                 if (item % jmax == 1 && ista != item)
                                 {
                                     break;
                                 }
                             }
                         }
                         ex.SetCellValue(sum.ToString(), ihang, jstart);

                         float gwidth = 13.50F, gheifht = 13.50F;
                         Microsoft.Office.Interop.Excel.Shape activShape, oldShape = null,kywShape=null;
                         int icolor = (int)(((uint)Color.White.B << 16) | (ushort)(((ushort)Color.White.G << 8) | Color.White.R));
                         range = (Excel.Range)xx.get_Range(xx.Cells[6, 1], xx.Cells[6, 1]);
                         fxstart = (float)Convert.ToDouble(range.Cells.Width);
                         range = (Excel.Range)xx.get_Range(xx.Cells[6, 2], xx.Cells[6, 2]);
                         fxstart += (float)Convert.ToDouble(range.Cells.Width);
                         range = (Excel.Range)xx.get_Range(xx.Cells[1, 1], xx.Cells[5, 1]);
                         fystart = (float)Convert.ToDouble(range.Cells.Height);
                         range = (Excel.Range)xx.get_Range(xx.Cells[6, 1], xx.Cells[6, 1]);
                         fystart = fystart + (float)(Convert.ToDouble(range.Cells.Height) / 2);
                         activShape = null;
                         for (int itemp = 0; itemp <= ista - item; itemp++)
                         {

                             range = (Excel.Range)xx.get_Range(xx.Cells[6, itemp*2 + jstart], xx.Cells[6, itemp*2 + jstart+1]);
                             float width = (float)Convert.ToDouble(range.Cells.Width);

                             PS_xl xl2 = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where ParentGT='" +gtlis[item + itemp].gtID+ "'");
                             if (xl2 == null)
                             {
                                 if (gtlis[item + itemp].gtModle.IndexOf("转角") == -1)
                                 {
                                     activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart + width / 2, fystart, gwidth, gheifht);
                                 }
                                 else
                                 {
                                     PJ_tbsj tb2 = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '转角'");
                                     if (tb2 != null)
                                     {

                                         string tempPath = Path.GetTempPath();
                                         string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb2.S1;
                                         FileStream fs;
                                         fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                                         BinaryWriter bw = new BinaryWriter(fs);
                                         bw.Write(tb2.picImage);
                                         bw.Flush();
                                         bw.Close();
                                         fs.Close();
                                         Image im = Bitmap.FromFile(tempfile);
                                         Bitmap bt = new Bitmap(im);
                                         if (bt.Width < width / 2)
                                         {
                                             activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 2 - bt.Width / 2, fystart + gheifht / 2 - bt.Height / 2, bt.Width, bt.Height);


                                         }
                                         else
                                         {
                                             activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 5, fystart + gheifht / 2 - bt.Height / 2, width / 2, bt.Height);

                                         }
                                     }
                                 }
                             }
                             else
                             {
                                 ex.SetCellValue(xl.LineName, 5, itemp * 2 + 4);
                                 PJ_tbsj tb2 = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '分支'");
                                 if (tb2 != null)
                                 {
                                     
                                     string tempPath = Path.GetTempPath();
                                     string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb2.S1;
                                     FileStream fs;
                                     fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                                     BinaryWriter bw = new BinaryWriter(fs);
                                     bw.Write(tb2.picImage);
                                     bw.Flush();
                                     bw.Close();
                                     fs.Close();
                                     Image im = Bitmap.FromFile(tempfile);
                                     Bitmap bt = new Bitmap(im);
                                     if (bt.Width < width / 2)
                                     {
                                         activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 2 - bt.Width / 2, fystart + gheifht/2 - bt.Height / 2, bt.Width, bt.Height);
                                       

                                     }
                                     else
                                     {
                                         activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 5, fystart + gheifht / 2 - bt.Height / 2, width / 2, bt.Height);
                                        
                                        
                                     }
                                     
                                     
                                 }
                                 else
                                 {
                                     activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart + width / 2, fystart, gwidth, gheifht);
                                 }


                             }
                             //activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart, fystart, gwidth, gheifht);
                             activShape.Fill.ForeColor.RGB = icolor;
                             if (itemp > 0)
                             {
                                 IList<PJ_05jcky> kyxli = MainHelper.PlatformSqlMap.GetList<PJ_05jcky>(" where gtID='" + gtlis[item + itemp].gtID + "'");
                                 if (kyxli.Count == 0)
                                 {
                                     //Texture Image Recognition Algorithm Based on Steerable Pyramid Transform
                                     xx.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorStraight,
                                         oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                         activShape.Left - (oldShape.Left + oldShape.Width), 0);
                                     //xx.Shapes.AddLine(
                                     //      oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                     //      activShape.Left, activShape.Top + activShape.Height / 2);
                                 }
                                 else
                                 {
                                     PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + kyxli[0].kymc  + "'");
                                     if (tb != null)
                                     {
                                         string tempPath = Path.GetTempPath();
                                         string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb.S1;
                                         FileStream fs;
                                         fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                                         BinaryWriter bw = new BinaryWriter(fs);
                                         bw.Write(tb.picImage);
                                         bw.Flush();
                                         bw.Close();
                                         fs.Close();
                                         Image im = Bitmap.FromFile(tempfile);
                                         Bitmap bt = new Bitmap(im);
                                         if (bt.Width < width / 2)
                                         {
                                             kywShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, oldShape.Left + oldShape.Width + width / 2 - bt.Width / 2, oldShape.Top + oldShape.Height / 2 - bt.Height / 2, bt.Width, bt.Height);
                                             xx.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorStraight,
                                            oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                            kywShape.Left - (oldShape.Left + oldShape.Width), 0);

                                             xx.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorStraight,
                                           kywShape.Left + (float)(kywShape.Width - 2), kywShape.Top + kywShape.Height / 2,
                                           activShape.Left - (kywShape.Left + kywShape.Width - 2), 0);
                                         }
                                         else
                                         {
                                             kywShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, oldShape.Left + oldShape.Width + width / 5, oldShape.Top + oldShape.Height / 2 - bt.Height / 2, width / 2, bt.Height);
                                             xx.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorStraight,
                                            oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                            kywShape.Left - (oldShape.Left + oldShape.Width), 0);

                                             xx.Shapes.AddConnector(Microsoft.Office.Core.MsoConnectorType.msoConnectorStraight,
                                           kywShape.Left + (float)(kywShape.Width - 1), kywShape.Top + kywShape.Height / 2,
                                           activShape.Left - (kywShape.Left + kywShape.Width -1), 0);
                                         
                                         }
                                         //Image im = Bitmap.FromFile(tempfile);
                                         //Bitmap bt = new Bitmap(im);
                                         //DataObject dataObject = new DataObject();
                                         //dataObject.SetData(DataFormats.Bitmap, bt);
                                         //Clipboard.SetDataObject(dataObject, true);

                                     }
                                 }
                             }
                             //fxstart += gtwidth[itemp];
                             fxstart += width;
                             oldShape = activShape;
                         }
                     }
                     ihang++;

                     //横担
                     if (hdobj != null && hdobj.Count>0)
                     {
                        
                             
                             if (hdobj.Count>hdRowCount)
                             {
                                 for (j = hdRowCount; j < hdobj.Count; j++)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + hdRowCount, "A"], xx.Cells[ihang + hdRowCount, "A"]);
                                     range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                     for (int item = 0; item < 29; item += 2)
                                     {
                                         range = (Excel.Range)xx.get_Range(xx.Cells[ihang + hdRowCount, jstart + item], xx.Cells[ihang + hdRowCount, jstart+1 + item]);
                                         range.Merge(Type.Missing);
                                     }
                                 }

                                 hdRowCount = hdobj.Count;
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + hdRowCount-1, 1]);
                                 range.Merge(Type.Missing);
                             }
                             for (j = 0; j < hdobj.Count; j++)
                             {
                                 ex.SetCellValue(hdobj[j].ToString(), ihang+j, jlie);
                                 //if (j + 1 < hdobj.Count)
                                 //{
                                 //    range = (Excel.Range)xx.get_Range(xx.Cells[ihang + 1, 1], xx.Cells[ihang + 1, 1]);
                                 //    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                                 //    ihang++;
                                 //}
                             }
                         
                     }
                     ihang+=hdRowCount;
                     //拉线规格/条数
                     if (lxlist != null && lxlist.Count > 0)
                     {

                         if (lxlist.Count > lxRowCount)
                         {
                             for (j = lxRowCount; j < lxlist.Count; j++)
                             {
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang + lxRowCount, "A"], xx.Cells[ihang + lxRowCount, "A"]);
                                 range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                 for (int item = 0; item < 29; item += 2)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + 1, jstart + item], xx.Cells[ihang + 1, jstart+1 + item]);
                                     range.Merge(Type.Missing);
                                 }
                             }

                             lxRowCount = lxlist.Count;
                             range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + lxRowCount - 1, 1]);
                             range.Merge(Type.Missing);
                         }
                         for (j = 0; j < lxlist.Count; j++)
                         {
                          int icount=Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt","select   sum(sbNumber) from PS_gtsb where sbModle = '" + lxlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                             //int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gtsb>(" Where sbModle = '" + lxlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                             ex.SetCellValue(lxlist[j].ToString() + "/" + icount, ihang + j, jlie);

                         }


                     }
                     ihang += lxRowCount;

                     //绝缘子型号/数量
                     if (jyuzlist != null)
                     {
                         
                             if (jyuzlist.Count > jyzRowCount)
                             {
                                 for (j = jyzRowCount; j < jyuzlist.Count; j++)
                                 {

                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jyzRowCount, "A"], xx.Cells[ihang + jyzRowCount, "A"]);
                                     range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                    
                                 }
                                 for (int jtem = 0; jtem < jyuzlist.Count; jtem++)
                                 {
                                     for (int item = 0; item < 29; item += 2)
                                     {
                                         range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart+1 + item]);
                                         range.Merge(Type.Missing);
                                     }
                                 }
                                 jyzRowCount = jyuzlist.Count;
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + jyzRowCount - 1, 1]);
                                 range.Merge(Type.Missing);
                             }
                             for (j = 0; j < jyuzlist.Count; j++)
                             {
                                 int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from PS_gtsb where sbModle = '" + jyuzlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                                 //int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gtsb>(" Where sbModle = '" + jyuzlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                                 ex.SetCellValue(jyuzlist[j].ToString() + "/" + icount, ihang+j, jlie);
                              
                             }
                     
                         
                     }
                     ihang += jyzRowCount;


                    
                   

                     //变台型式
                     if (btlist != null)
                     {
                         if (btlist.Count > 0)
                         {
                             //ilisttemp = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct sbCode from PS_gtsb  Where  sbModle = '" + btlist[0].ToString() + "' and gtID='" + gtobj.gtID + "'");
                             ilisttemp = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct byqModle from PS_tqbyq  Where tqID  in ( select tqID from PS_tq where  gtID='" + gtobj.gtID + "')");
                             if (ilisttemp.Count > btRowCount)
                             {
                                 for (j = btRowCount; j < btlist.Count; j++)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + btRowCount+1, "A"], xx.Cells[ihang + btRowCount+1, "A"]);
                                     range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                    
                                 }
                                 for (int jtem = 1; jtem < btlist.Count; jtem++)
                                 {
                                     for (int item = 0; item < 29; item += 2)
                                     {
                                         range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + 1 + item]);
                                         range.Merge(Type.Missing);
                                     }
                                 }

                                 btRowCount = ilisttemp.Count;
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang+1, 1], xx.Cells[ihang + btRowCount+1 - 1, 1]);
                                 range.Merge(Type.Missing);
                             }
                             if (btlist.Count == 1)
                                 ex.SetCellValue(btlist[0].ToString(), ihang, jlie);
                             //else
                             //{
                             //    j = j;
                             //}
                             for (j = 0; j < ilisttemp.Count; j++)
                             {
                                 //int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from PS_gtsb where sbCode='" + ilisttemp[0].ToString() + "' and  sbModle = '" + btlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                                 ////int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gtsb>(" Where sbCode='" + ilisttemp[0].ToString() + "' and  sbModle = '" + btlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                                 //PS_gtsb gtsbtemp = Client.ClientHelper.PlatformSqlMap.GetOne<PS_gtsb>(" Where sbCode='" + ilisttemp[0].ToString() + "' and sbModle = '" + btlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                                 int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   count(*) from PS_tqbyq where byqModle='" + ilisttemp[j].ToString() + "'   and tqID  in ( select tqID from PS_tq where  gtID='" + gtobj.gtID + "')"));
                                 PS_tqbyq gtsbtemp = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tqbyq>(" Where byqModle='" + ilisttemp[j].ToString() + "'   and tqID  in ( select tqID from PS_tq where  gtID='" + gtobj.gtID + "')");
                                 if (gtsbtemp != null)
                                 {
                                     //PS_sbcs sbcstemp = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_sbcs>(gtsbtemp.sbType + ilisttemp[0].ToString());
                                     //if (sbcstemp != null)
                                     //{
                                         //ex.SetCellValue(sbcstemp.xh + "/" + icount.ToString(), ihang + j + 1, jlie);
                                     //}
                                     if (gtsbtemp.byqModle.IndexOf("-") < 0)
                                     {
                                         ex.SetCellValue(gtsbtemp.byqModle + "/" + icount.ToString(), ihang + j + 1, jlie);
                                     }
                                     else
                                     {
                                         ex.SetCellValue(gtsbtemp.byqModle.Substring(0, gtsbtemp.byqModle.IndexOf("-")) + "/" + icount.ToString(), ihang + j + 1, jlie);
                                     }
                                 }
                             }
                         }

                     }
                     ihang += btRowCount+1;

                     //避雷器型号/数量
                     if (blqlist != null && btlist.Count>0)
                     {
                        
                             if (blqlist.Count > blqRowCount)
                             {
                                
                                 for (j = blqRowCount; j < blqlist.Count; j++)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + blqRowCount, "A"], xx.Cells[ihang + blqRowCount, "A"]);
                                     range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                   
                                 }
                                 for (int jtem = 0; jtem < blqlist.Count; jtem++)
                                 {
                                     for (int item = 0; item < 29; item += 2)
                                     {
                                         range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + 1 + item]);
                                         range.Merge(Type.Missing);
                                     }
                                 }
                                 blqRowCount = blqlist.Count;
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + blqRowCount - 1, 1]);
                                 range.Merge(Type.Missing);
                             }
                             for (j = 0; j < blqlist.Count; j++)
                             {
                                 int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from PS_gtsb  Where sbModle = '" + blqlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                                // int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_gtsb>(" Where sbModle = '" + blqlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                                 ex.SetCellValue(blqlist[j].ToString() + "/" + icount, ihang+j, jlie);
                              
                             }
                         

                     }
                     ihang += blqRowCount;

                     //开关型号/数量
                     if (kglist != null && kglist.Count>0)
                     {
                         
                             if (kglist.Count > kgRowCount)
                             {
                              
                                 for (j = kgRowCount; j < kglist.Count; j++)
                                 {
                                     range = (Excel.Range)xx.get_Range(xx.Cells[ihang + kgRowCount, "A"], xx.Cells[ihang + kgRowCount, "A"]);
                                     range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                    
                                 }
                                 for (int jtem = 0; jtem < kglist.Count; jtem++)
                                 {
                                     for (int item = 0; item < 29; item += 2)
                                     {
                                         range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + 1 + item]);
                                         range.Merge(Type.Missing);
                                     }
                                 }
                                 kgRowCount = kglist.Count;
                                 range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + kgRowCount - 1, 1]);
                                 range.Merge(Type.Missing);
                             }
                             for (j = 0; j < kglist.Count; j++)
                             {
                                 try
                                 {
                                     int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from PS_gtsb  Where sbModle = '" + kglist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                                     //int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<PS_kg>(" Where kgModle = '" + kglist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                                     ex.SetCellValue(kglist[j].ToString() + "/" + icount, ihang + j, jlie);
                                 }
                                 catch { }
                                
                             }
                         

                     }
                     ihang += kgRowCount;

                  
                     
                     jlie += 2;
                 }
                
               






             

                 //#region 画图形
                 //dsoFramerWordControl1.FileOpen(outfname);
                 //Microsoft.Office.Interop.Excel.Workbook wb;
                 //Microsoft.Office.Interop.Excel.Worksheet xx;
                 //try
                 //{
                 //    wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
                 //    xx = wb.Application.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                 //}
                 //catch (Exception err)
                 //{
                 //    dsoFramerWordControl1.FileClose();
                 //    throw new Exception("excel的打开方式不对，有可能装有wps", err);
                 //}
                 //Excel.Range range;
                 //if (lieindex < 1)
                 //    range = (Excel.Range)xx.get_Range(xx.Cells[5, 1], xx.Cells[RowCount, ColumnCount]);
                 //else
                 //    range = (Excel.Range)xx.get_Range(xx.Cells[5, 1], xx.Cells[RowCount, lieindex + 2]);

                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;
                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThick;
                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                 //range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;

               
                
             }
             catch(Exception exmess)
             {
                 MsgBox.ShowTipMessageBox(exmess.Message.ToString());
             }
             dsoFramerWordControl1.FileSave();
             pj17.BigData = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
            //#endregion
            //System.Diagnostics.Process.Start(outfname);
            return 1;
        }
        private void barCreat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;

            PJ_17 obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_17>(treeList1.FocusedNode["ID"]);
            if (obj == null)
                return;
            try
            {
                if (ExportToExcel("高压配电线路条图", "", obj) < 1) return;

                frm17Template frm = new frm17Template();
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_17>(frm.pjobject);
                    //MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);

            }
        }
        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                //Export17.ExportExcel(treeList1.FocusedNode);
                PJ_17 obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_17>(treeList1.FocusedNode["ID"]);
                if (obj == null)
                    return;
                string fname = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = saveFileDialog1.FileName;
                    try
                    {
                        DSOFramerControl ds1 = new DSOFramerControl();
                        ds1.FileDataGzip  = obj.BigData;
                        ds1.FileSave(fname, true);
                        ds1.FileClose();
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start(fname);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                        return;
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                frm17Template frm = new frm17Template();
                PJ_17 obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_17>(treeList1.FocusedNode["ID"]);
                if (obj == null)
                    return;
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_17>(frm.pjobject);
                    //MessageBox.Show("保存成功");
                }
            }
        }
    }
}
