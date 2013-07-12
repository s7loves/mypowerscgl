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

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_21 : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<sdjl_21> treeViewOperator;
        private string parentID = "";
        private mOrg parentObj = null;
        [Browsable(false)]
        public TreeViewOperation<sdjl_21> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        public event SendDataEventHandler<sdjl_21> FocusedNodeChanged;
        public event SendDataEventHandler<sdjl_21> AfterAdd;
        public event SendDataEventHandler<sdjl_21> AfterEdit;
        public event SendDataEventHandler<sdjl_21> AfterDelete;
        public UCSD_21()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<sdjl_21>(treeList1, barManager1, null);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            //btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            Init();
        }

        void btGDS_EditValueChanged(object sender, EventArgs e) {
            parentID = btGdsList.EditValue.ToString();
            InitData();
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {
                parentObj = org;
                //IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where LineVol='35' and OrgCode='" + org.OrgCode + "'");
                IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
            }
        }

        void treeViewOperator_AfterDelete(sdjl_21 newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(sdjl_21 newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(sdjl_21 newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as sdjl_21);
        }

        void treeViewOperator_CreatingObject(sdjl_21 newobj) {

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
            treeList1.Columns["gzrjID"].Visible = false;
            treeList1.Columns["c1"].Visible = false;
            treeList1.Columns["c2"].Visible = false;
            treeList1.Columns["c3"].Visible = false;
            treeList1.Columns["c4"].Visible = false;
            treeList1.Columns["c5"].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData(" where OrgCode='" + parentID + "' order by  CreateDate");
        }

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (btXlList.EditValue == null || btXlList.EditValue.ToString() == "") {
                return;
            }
            sd_xl xl = btXlList.EditValue as sd_xl;
            sdjl_21 pj = new sdjl_21();
            pj.CreateDate = DateTime.Now;
            pj.CreateMan = MainHelper.User.UserName;
            pj.LineName = xl.LineName;
            pj.LineCode = xl.LineCode;
            pj.OrgCode = xl.OrgCode;
            pj.OrgName = parentObj.OrgName;
            pj.Remark = "";
            MainHelper.PlatformSqlMap.Create<sdjl_21>(pj);

            InitData();
            //if (MsgBox.ShowAskMessageBox("是否马上生成条图") == DialogResult.OK)
            {

                try {
                    if (ExportToExcel("送电线路条图", "", pj) < 1) return;

                    frm21Template frm = new frm21Template();
                    frm.pjobject = pj;
                    if (frm.ShowDialog() == DialogResult.OK) {
                        Client.ClientHelper.PlatformSqlMap.Update<sdjl_21>(frm.pjobject);
                        //MessageBox.Show("保存成功");
                    }
                } catch (Exception ex) {
                    MsgBox.ShowException(ex);

                }
            }

        }

        

        public static int ExportToExcel(string title, string dw, sdjl_21 pj17) {
            string fname = Application.StartupPath + "\\00记录模板\\送电21线路条图.xls";
            float fxstart = 0, fystart = 0, fwidth = 0, fheight = 0;
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string outfname = Path.GetTempFileName() + ".xls";
            File.Copy(fname, outfname);
            dsoFramerWordControl1.FileOpen(outfname);
            Microsoft.Office.Interop.Excel.Worksheet xx;
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;        
            ExcelAccess ex = new ExcelAccess();
            ex.MyWorkBook = wb;
            ex.MyExcel = wb.Application;
            sd_xl xl = MainHelper.PlatformSqlMap.GetOne<sd_xl>(" where LineCode='" + pj17.LineCode + "'");
            Dictionary<int, NZLength> Dic = new Dictionary<int, NZLength>();
            try {
                if (xl == null) {
                    MsgBox.ShowWarningMessageBox("数据出错，没找到线路");
                    return -1;
                }
                string strLinexh = xl.WireType;//导线型号
                sd_gt gtformer = null;
                IList<sd_gt> gtlis = Client.ClientHelper.PlatformSqlMap.GetList<sd_gt>(" Where LineCode='" + xl.LineCode + "' order by gtcode");
                int h = 1;
                int start = -1;
                int end = -1;
                bool notStart=true;
                decimal sums = 0;
                foreach (sd_gt gt in gtlis)
                {
                    if (gt.gtModle != "直线杆")
                    {
                        if (notStart)
                        {
                            start = h;
                            notStart = false;
                        }
                        sums += gt.gtSpan;
                    }
                    else
                    {
                        notStart = true;
                        end = h - 1;
                        if (start > 0)
                        {
                            Dic.Add(h, new NZLength{Start = start,End = end,Sum = sums});
                        }
                        start = -1;
                        end = -1;
                        sums = 0;
                        
                    }
                    h++;
                }

                gtformer = Client.ClientHelper.PlatformSqlMap.GetOne<sd_gt>(" Where gtID='" + xl.ParentGT + "'");
                gtlis.Insert(0, gtformer);
                //计算页码
                int pagecount = 1, jmax = 15, m = 0, j = 0;
                pagecount = gtlis.Count / 15 + 1;
                int ihang = 8, jlie = 2;
                int i = 0;
                //复制空模板
                for (m = 1; m < pagecount; m++) {
                    ex.CopySheet(1, m);
                    ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
                }
                string[] strname = new string[3];
                strname[0] = "";
                strname[1] = "";
                strname[2] = "";

                if (xl.LineType == "1") {
                    strname[0] = xl.LineName.Split('线')[0] + "线";
                    strname[1] = xl.LineName.Replace(strname[0], "");


                } else
                    if (xl.LineType == "2") {
                        sd_xl xltemp = MainHelper.PlatformSqlMap.GetOne<sd_xl>(" where LineID='" + xl.ParentID + "'");
                        if (xltemp != null)
                            strname[0] = xltemp.LineName;
                        strname[1] = xl.LineName.Replace(xltemp.LineName,"");
                    } else if (xl.LineType == "3") {
                        strname[2] = xl.LineName;
                        sd_xl xltemp = MainHelper.PlatformSqlMap.GetOne<sd_xl>(" where LineID='" + xl.ParentID + "'");
                        if (xltemp != null) {
                            strname[1] = xltemp.LineName;
                            xltemp = MainHelper.PlatformSqlMap.GetOne<sd_xl>(" where LineID='" + xltemp.ParentID + "'");
                            if (xltemp != null) strname[0] = xltemp.LineName;
                        }
                        strname[2].Replace(strname[1], "");
                        strname[1].Replace(strname[0], "");
                    }
                //填写公共项
                for (m = 1; m <= pagecount; m++) {
                    ex.ActiveSheet("Sheet" + m);
                    if(!string.IsNullOrEmpty(strname[0]))
                    ex.SetCellValue(strname[0], 3, 2);
                    if (!string.IsNullOrEmpty(strname[1]))
                    ex.SetCellValue(strname[1], 3, 5);
                    if (!string.IsNullOrEmpty(strname[2]))
                    ex.SetCellValue(strname[2], 3, 11);
                    ex.SetCellValue(xl.LineVol.ToString(), 3, 20);

                }
                ihang = 8;
                jlie = 3;
                int hdRowCount = 1;
                int jyzRowCount = 1;
                int dxRowCount = 1;
                
                int lxRowCount = 1;
                int jstart = 3;
                double dc = 0;
                string strfx = "";
                Excel.Range range;
                for (i = 1; i < gtlis.Count; i++) {
                    if ((i + 0.0) % (jmax) == 1) {

                        jlie = 3;
                        ihang = 8;
                        hdRowCount = 1;
                        jyzRowCount = 1;
                        dxRowCount = 1;
                        
                        lxRowCount = 1;

                    }
                    if (Math.Ceiling((i + 0.0) / (jmax)) > 1) {
                        ex.ActiveSheet("Sheet" + Math.Ceiling((i + 0.0) / (jmax)));
                        xx = wb.Application.Sheets["Sheet" + Math.Ceiling((i + 0.0) / (jmax))] as Microsoft.Office.Interop.Excel.Worksheet;


                    } else {
                        ex.ActiveSheet("Sheet1");
                        xx = wb.Application.Sheets["Sheet1"] as Microsoft.Office.Interop.Excel.Worksheet;
                    }

                    //ex.SetCellValue(i.ToString(), ihang, jlie);

                    ////杆塔数
                    sd_gt gtobj = gtlis[i];
                    
                    //绝缘子
                    //string strSQL = "select distinct sbModle from sd_gtsb Where  gtID='" + gtobj.gtID + "' ";
                    //if (xl.LineVol != "" && Convert.ToDouble(xl.LineVol) >= 10) {
                    //    strSQL += "  and (sbName like '高压%立瓶%' or sbName like '高压%悬垂%' or sbName like '高压%茶台%' )";
                    //} else
                    //    if (xl.LineVol != "" && 0.4 >= Convert.ToDouble(xl.LineVol)) {
                    //        strSQL += "  and (sbName like '低压%立瓶%'  or sbName like '低压%茶台%' )";
                    //    }
                    string strSQL = "select distinct sbModle from sd_gtsb Where  gtID='" + gtobj.gtID + "' ";
                    if (xl.LineVol != "" && Convert.ToDouble(xl.LineVol) >= 10)
                    {
                        strSQL += "  and (sbName like '%绝缘子%' or sbName like '高压%立瓶%' or sbName like '高压%悬垂%' or sbName like '高压%茶台%' )";
                    }
                    else
                        if (xl.LineVol != "" && 0.4 >= Convert.ToDouble(xl.LineVol))
                        {
                            strSQL += "  and (sbName like '低压%立瓶%' or sbName like  '%绝缘子%'  or sbName like '低压%茶台%' )";
                        }
                    IList jyuzlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);

                    //导线型号
                    IList dxlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct sbModle from sd_gtsb  Where sbName like '%导线%' and gtID='" + gtobj.gtID + "'");
                    //导线排列方式
                    IList dxpllist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct C1 from sd_gtsb  Where sbName like '%导线%' and gtID='" + gtobj.gtID + "'");

                    //耐张规格
                    IList hdobj = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from sd_gtsb Where sbName like '%耐张%' and gtID='" + gtobj.gtID + "'");

                    //拉线规格
                    IList lxlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct sbModle from sd_gtsb  Where sbName like '%拉线%' and gtID='" + gtobj.gtID + "'");

                   
                    

                    ihang = 8;
                    ////杆号
                    ex.SetCellValue((i).ToString(), ihang, jlie);
                    ihang++;

                    //转角方向
                    if (gtobj.gtModle.IndexOf("转角") > -1) {
                        if (i != 1 && i < gtlis.Count - 1) {


                            decimal[,] a1 = new decimal[1, 2];
                            decimal[,] a2 = new decimal[1, 2];
                            a1[0, 0] = gtlis[i].gtLat - gtlis[i - 1].gtLat;
                            a1[0, 1] = gtlis[i].gtLon - gtlis[i - 1].gtLon;

                            a2[0, 0] = gtlis[i + 1].gtLat - gtlis[i].gtLat;
                            a2[0, 1] = gtlis[i + 1].gtLon - gtlis[i].gtLon;
                            decimal di = a1[0, 0] * a2[0, 0] + a1[0, 1] * a2[0, 1];
                            double dl = Math.Sqrt(Convert.ToDouble(a1[0, 0] * a1[0, 0] + a1[0, 1] * a1[0, 1]) * Math.Sqrt(Convert.ToDouble(
                                a2[0, 0] * a2[0, 0] + a2[0, 1] * a2[0, 1])));
                            dc = Math.Round(180 * Math.Acos(Convert.ToDouble(di) / Convert.ToDouble(dl)) / 3.1415926, 0);
                            if (gtlis[i].gtLon > gtlis[i - 1].gtLon) {
                                strfx = "右转";
                            } else {
                                strfx = "左转";
                            }
                            if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                ex.SetCellValue(strfx + dc + "度", ihang, jlie);
                            else {

                            }
                        }

                    }
                    ihang++;

                    //杆高（m）
                    if (gtobj != null) {

                        ex.SetCellValue(gtobj.gtHeight.ToString(), ihang, jlie);

                    }
                    ihang++;

                    //电杆种类/杆型
                    if (gtobj != null) {
                        string strtype = "", strzj = "";
                        if (gtobj.gtType.IndexOf("混凝土拔梢杆") > -1) {
                            strtype = "砼";
                        }
                        if (gtobj.gtModle.IndexOf("直线杆") > -1) {
                            strzj = "直";
                        } else if (gtobj.gtModle.IndexOf("分支杆") > -1) {
                            strzj = "分";
                        } else if (gtobj.gtModle.IndexOf("转角杆") > -1) {
                            strzj = "转";
                        } else if (gtobj.gtModle.IndexOf("耐张杆") > -1) {
                            strzj = "耐";
                        } else if (gtobj.gtModle.IndexOf("终端杆") > -1) {
                            strzj = "终";
                        }
                       
                        if (strtype != "" && strzj != "") {
                            ex.SetCellValue(strtype + "/" + strzj, ihang, jlie);
                        } else {
                            ex.SetCellValue(gtobj.gtType + "/" + gtobj.gtModle, ihang, jlie);
                        }
                    }
                    ihang++;
                    //导线排列方式

                    if (hdobj.Count>0 && hdobj[0].ToString().Contains("三角")) {

                        ex.SetCellValue("三角排列", ihang, jlie);
                    } else {
                        ex.SetCellValue("水平排列", ihang, jlie);
                    }
                    
                   
                    ihang++;
                    //导线型号规格（mm2）
                    if (dxlist != null && dxlist.Count > 0) {
                        if (dxlist.Count > dxRowCount) {
                            for (j = dxRowCount; j < dxlist.Count; j++) {
                                range = (Excel.Range)xx.get_Range(xx.Cells[ihang + dxRowCount, "A"], xx.Cells[ihang + dxRowCount, "A"]);
                                range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);

                            }
                            for (int jtem = 1; jtem < dxlist.Count; jtem++) {
                                for (int item = 0; item < 29; item += 2) {
                                    range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + 1 + item]);
                                    range.Merge(Type.Missing);
                                }
                            }
                            dxRowCount = dxlist.Count;
                            range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + dxRowCount - 1, 1]);
                            range.Merge(Type.Missing);
                        }
                        if (dxlist.Count > 0) {

                            for (j = 0; j < dxlist.Count; j++)
                                ex.SetCellValue(dxlist[j].ToString(), ihang + j, jlie);
                        }

                    } else {
                        ex.SetCellValue(strLinexh, ihang, jlie);
                    }

                    ihang += dxRowCount;
                    if (i == 15) {
                        int nn = 0;
                    }
                    //档        距（m）
                    if (gtobj != null && gtobj.gtSpan>0) {
                        if (jlie > 3)
                            ex.SetCellValue(gtobj.gtSpan.ToString(), ihang, jlie - 1);
                        else
                            ex.SetCellValue(gtobj.gtSpan.ToString(), ihang, jlie);
                    }
                    ihang++;

                    //耐张段长度
                    

                    ihang += hdRowCount;

                    //累计长度


                    if (((i + 0.0) % (jmax) == 0 && i > 1) || i == gtlis.Count - 1) {
                        //累计长度
                        double sum = 0;
                        int ista = i, item = i;
                        for (item = i; item > 0; item--) {
                            sd_gt gttemp = gtlis[item];
                            if (gttemp != null) {
                                sum += Convert.ToDouble(gttemp.gtSpan);
                            }
                            if (i < gtlis.Count - 1) {
                                if (item % jmax == 1 && ista != item) {
                                    break;
                                }
                            } else {
                                if (item % jmax == 1) {
                                    break;
                                }
                            }
                        }
                        sum = 0;
                        for (int m1 = 0; m1 < gtlis.Count;m1++ )
                        {
                            sd_gt gttemp = gtlis[m1];
                            if (gttemp != null)
                            {
                                sum += Convert.ToDouble(gttemp.gtSpan);
                            }
                        }
                        ex.SetCellValue(sum.ToString(), ihang, jstart);

                        float gwidth = 13.50F, gheifht = 13.50F;
                        //float gwidth = 10F, gheifht = 10F;
                        Microsoft.Office.Interop.Excel.Shape activShape, oldShape = null, kywShape = null;
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
                        for (int itemp = 0; itemp <= ista - item; itemp++) {

                            range = (Excel.Range)xx.get_Range(xx.Cells[6, itemp * 2 + jstart], xx.Cells[6, itemp * 2 + jstart + 1]);
                            float width = (float)Convert.ToDouble(range.Cells.Width);

                            sd_xl xl2 = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where ParentGT='" + gtlis[item + itemp].gtID + "'");
                            if (xl2 == null) {
                                if (gtlis[item + itemp].gtModle.IndexOf("转角") == -1) {
                                    activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart + width / 2, fystart, gwidth, gheifht);
                                } else {
                                    PJ_tbsj tb2 = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '直角'");
                                    if (tb2 != null) {

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
                                        decimal[,] a1 = new decimal[1, 2];
                                        decimal[,] a2 = new decimal[1, 2];
                                        if (item + itemp < gtlis.Count) {
                                            a1[0, 0] = gtlis[item + itemp].gtLat - gtlis[item + itemp - 1].gtLat;
                                            a1[0, 1] = gtlis[item + itemp].gtLon - gtlis[item + itemp - 1].gtLon;

                                            a2[0, 0] = gtlis[item + itemp + 1].gtLat - gtlis[item + itemp].gtLat;
                                            a2[0, 1] = gtlis[item + itemp + 1].gtLon - gtlis[item + itemp].gtLon;
                                        }
                                        decimal di = a1[0, 0] * a2[0, 0] + a1[0, 1] * a2[0, 1];
                                        double dl = Math.Sqrt(Convert.ToDouble(a1[0, 0] * a1[0, 0] + a1[0, 1] * a1[0, 1]) * Math.Sqrt(Convert.ToDouble(
                                            a2[0, 0] * a2[0, 0] + a2[0, 1] * a2[0, 1])));
                                        dc = Math.Round(180 * Math.Acos(Convert.ToDouble(di) / Convert.ToDouble(dl)) / 3.1415926, 0);
                                        if (gtlis[item + itemp].gtLon > gtlis[item + itemp - 1].gtLon) {
                                            strfx = "右转";
                                        } else {
                                            strfx = "左转";
                                        }
                                        int btw = (int)(bt.Width / 1.33f);
                                        int bth = (int)(bt.Height / 1.33f);
                                        if (btw < width / 2) {
                                            
                                            activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 2 - btw / 2, fystart + gheifht / 2 - bth / 2, btw, bth);
                                            if (strfx == "左转") {
                                                if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                                    activShape.Rotation = (float)(90 - Convert.ToDouble(dc));
                                            } else {
                                                if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                                    activShape.Rotation = (float)(90 + Convert.ToDouble(dc));
                                            }

                                        } else {
                                            activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 5, fystart + gheifht / 2 - bt.Height / 2,bt.Width, bt.Height);
                                            if (strfx == "左转") {
                                                if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                                    activShape.Rotation = (float)(90 - Convert.ToDouble(dc));
                                            } else {
                                                if (dc.ToString() != "NaN" && dc.ToString() != "非数字")
                                                    activShape.Rotation = (float)(90 + Convert.ToDouble(dc));
                                            }

                                        }
                                    }
                                }
                            } else {
                                ex.SetCellValue(xl2.LineName, 5, itemp * 2 + 4);//分支线路
                                PJ_tbsj tb2 = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '分支'");
                                if (tb2 != null) {

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
                                    int btw = (int)(bt.Width / 1.33f);
                                    int bth = (int)(bt.Height / 1.33f);
                                    if (btw < width / 2) {
                                        activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 2 - btw / 2, fystart + gheifht / 2 - bth / 2, btw, bth);
                                    } else {
                                        activShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, fxstart + width / 5, fystart + gheifht / 2 - bth / 2, btw, bth);
                                    }

                                } else {
                                    activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart + width / 2, fystart, gwidth, gheifht);
                                }


                            }
                            //activShape = xx.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, fxstart, fystart, gwidth, gheifht);
                            activShape.Fill.ForeColor.RGB = icolor;
                            if (itemp > 0) { 
                                //IList<sdjl_05jcky> kyxli = MainHelper.PlatformSqlMap.GetList<sdjl_05jcky>(" where gtID='" + gtlis[item + itemp].gtID + "'");
                                IList<PJ_05jcky> kyxli = MainHelper.PlatformSqlMap.GetList<PJ_05jcky>(" where gtID='" + gtlis[item + itemp].gtID + "'");
                               
                                if (kyxli.Count == 0) {
                                   
                                    {
                                        xx.Shapes.AddLine(
                                              oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                              activShape.Left, activShape.Top + activShape.Height / 2);
                                    }
                                } else {
                                    PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + kyxli[0].kymc + "'");
                                    if (tb != null) {
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
                                        int btw = (int)(bt.Width / 1.33f);
                                        int bth = (int)(bt.Height / 1.33f);
                                        if (btw < width / 2) {
                                            kywShape = xx.Shapes.AddPicture(tempfile, MsoTriState.msoFalse, MsoTriState.msoTrue, oldShape.Left + oldShape.Width + width / 2 - btw / 2, oldShape.Top + oldShape.Height / 2 - bth / 2, btw, bth);
                                          
                                            xx.Shapes.AddLine(
                                          oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                          kywShape.Left, oldShape.Top + oldShape.Height / 2);

                                            xx.Shapes.AddLine(
                                          kywShape.Left + (float)(kywShape.Width - 2), kywShape.Top + kywShape.Height / 2,
                                          activShape.Left + 2, kywShape.Top + kywShape.Height / 2);
                                        } else {
                                          

                                            xx.Shapes.AddLine(
                                           oldShape.Left + oldShape.Width, oldShape.Top + oldShape.Height / 2,
                                           kywShape.Left, oldShape.Top + oldShape.Height / 2);

                                            xx.Shapes.AddLine(
                                          kywShape.Left + (float)(kywShape.Width - 1), kywShape.Top + kywShape.Height / 2,
                                          activShape.Left + 1, kywShape.Top + kywShape.Height / 2);
                                        }
                                    }
                                }
                            }
                            //fxstart += gtwidth[itemp];
                            fxstart += width;
                            oldShape = activShape;
                        }
                    }
                    ihang++;

                  
                    //拉线规格/条数
                    if (lxlist != null && lxlist.Count > 0) {

                        if (lxlist.Count > lxRowCount) {
                            for (j = lxRowCount; j < lxlist.Count; j++) {
                                range = (Excel.Range)xx.get_Range(xx.Cells[ihang + lxRowCount, "A"], xx.Cells[ihang + lxRowCount, "A"]);
                                range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                                
                            }
                            for (int jtem = lxRowCount; jtem < lxlist.Count; jtem++) {
                                for (int item = 0; item < 29; item += 2) {
                                    range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jtem, jstart + item], xx.Cells[ihang + jtem, jstart + item + 1]);
                                    range.Merge(Type.Missing);
                                }
                            }
                            lxRowCount = lxlist.Count;
                            range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + lxRowCount - 1, 1]);
                            range.Merge(Type.Missing);
                        }
                        for (j = 0; j < lxlist.Count; j++) {
                            int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from sd_gtsb where sbModle = '" + lxlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                            //int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<sd_gtsb>(" Where sbModle = '" + lxlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                            ex.SetCellValue(lxlist[j].ToString()/* + "/" + icount*/, ihang + j, jlie);

                        }
                    }
                    ihang += lxRowCount;

                    //绝缘子型号/数量
                    if (jyuzlist != null) {

                        if (jyuzlist.Count > jyzRowCount) {
                            for (j = jyzRowCount + 1; j < jyuzlist.Count; j = j+2) {

                                range = (Excel.Range)xx.get_Range(xx.Cells[ihang + jyzRowCount, "A"], xx.Cells[ihang + jyzRowCount, "A"]);
                                range.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);

                                range = (Excel.Range)xx.get_Range(xx.Cells[ihang + j, 2], xx.Cells[ihang + j - 1, 2]);
                                range.Merge(Type.Missing);
                            }
                            jyzRowCount = jyuzlist.Count/2 + jyuzlist.Count%2 == 0?0:1;
                            range = (Excel.Range)xx.get_Range(xx.Cells[ihang, 1], xx.Cells[ihang + jyzRowCount - 1, 1]);
                            range.Merge(Type.Missing);
                        }
                        for (j = 0; j < jyuzlist.Count; j++) {
                            int icount = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select   sum(sbNumber) from sd_gtsb where sbModle = '" + jyuzlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'"));
                            //int icount = Client.ClientHelper.PlatformSqlMap.GetRowCount<sd_gtsb>(" Where sbModle = '" + jyuzlist[j].ToString() + "' and gtID='" + gtobj.gtID + "'");
                            ex.SetCellValue(jyuzlist[j].ToString() /*+ "/" + icount*/, ihang + j/2, jlie + j%2);
                            ex.SetCellValue(icount.ToString(), ihang + j / 2 + 1, jlie + j % 2);

                        }
                    }
                    ihang += jyzRowCount*2 ;
                    jlie += 2;
                }
                
                foreach (int key in Dic.Keys)
                {
                    int page = 1;
                    int page1 = 1;
                    NZLength nzlength = Dic[key];

                    int startcolumn = (nzlength.Start + 1) * 2 - 1;
                    if (startcolumn % 32 == 0)
                    {
                        page = startcolumn / 32;
                    }
                    else
                    {
                        page = startcolumn / 32 + 1;
                    }

                    ex.ActiveSheet(page);
                    
                    int endcolumn = (nzlength.End + 1) * 2 - 1;
                    if (nzlength.End % 32 == 0)
                    {
                        page1 = endcolumn / 32;
                    }
                    else
                    {
                        page1 = endcolumn / 32 + 1;
                    }
                    if (page == page1)
                    {
                        ex.ActiveSheet(page);
                        ex.UnitCells(15, startcolumn % 32, 15, endcolumn % 32);
                        ex.SetCellValue(Math.Round(nzlength.Sum/1000,3).ToString(), 15, startcolumn % 32);
                    }
                    else
                    {
                        ex.ActiveSheet(page);
                        ex.UnitCells(15, startcolumn % 32, 15, 31);
                        ex.SetCellValue(nzlength.Start + "到" + nzlength.End + "杆塔:" + Math.Round(nzlength.Sum/1000,3), 15, startcolumn % 32);
                        for (int tmp = 1; tmp <= page1 - page; tmp++)
                        {
                            ex.ActiveSheet(page + tmp);
                            if (tmp < page1 - page)
                            {
                                ex.UnitCells(15, 3,15, 31);
                                
                            }
                            ex.UnitCells(15, 3, 15, (endcolumn+2) % 32);
                            ex.SetCellValue(nzlength.Start + "到" + nzlength.End + "杆塔:" + Math.Round(nzlength.Sum/1000,3), 15, 3);
                        }
                    }


                }
                ex.ActiveSheet(1);

            } catch (Exception exmess) {
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
        private void barCreat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (treeList1.FocusedNode == null)
                return;

            sdjl_21 obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjl_21>(treeList1.FocusedNode["ID"]);
            if (obj == null)
                return;
            try {
                if (ExportToExcel("送电线路条图", "", obj) < 1) return;

                frm21Template frm = new frm21Template();
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK) {
                    Client.ClientHelper.PlatformSqlMap.Update<sdjl_21>(frm.pjobject);
                    //MessageBox.Show("保存成功");
                }
            } catch (Exception ex) {
                MsgBox.ShowException(ex);
                if (ex.Message.IndexOf("无效") > -1) {
                    SelectorHelper.Execute("taskkill /im EXCEL.EXE /f");
                }
            }
        }
        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (treeList1.FocusedNode != null) {
                //Export17.ExportExcel(treeList1.FocusedNode);
                sdjl_21 obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjl_21>(treeList1.FocusedNode["ID"]);
                if (obj == null)
                    return;
                string fname = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fname = saveFileDialog1.FileName;
                    try {
                        DSOFramerControl ds1 = new DSOFramerControl();
                        ds1.FileDataGzip = obj.BigData;
                        ds1.FileSave(fname, true);
                        ds1.FileClose();
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start(fname);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                        return;
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (treeList1.FocusedNode != null) {
                frm21Template frm = new frm21Template();
                sdjl_21 obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjl_21>(treeList1.FocusedNode["ID"]);
                if (obj == null)
                    return;
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK) {
                    Client.ClientHelper.PlatformSqlMap.Update<sdjl_21>(frm.pjobject);
                    //MessageBox.Show("保存成功");
                }
            }
        }
    }

    public class NZLength
    {
        public int Start { get; set; }

        public int End { get; set; }

        public decimal Sum { get; set; }
    }
}
