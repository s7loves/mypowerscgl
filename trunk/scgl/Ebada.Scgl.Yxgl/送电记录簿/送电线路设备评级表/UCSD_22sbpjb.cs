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
    public partial class UCSD_22sbpjb : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<sdjls_sbpjb> treeViewOperator;
        private string parentID = "";
        private mOrg parentObj = null;
        [Browsable(false)]
        public TreeViewOperation<sdjls_sbpjb> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        public event SendDataEventHandler<sdjls_sbpjb> FocusedNodeChanged;
        public event SendDataEventHandler<sdjls_sbpjb> AfterAdd;
        public event SendDataEventHandler<sdjls_sbpjb> AfterEdit;
        public event SendDataEventHandler<sdjls_sbpjb> AfterDelete;
        public UCSD_22sbpjb()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<sdjls_sbpjb>(treeList1, barManager1, null);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
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
                IList<sd_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where  OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
            }
        }

        void treeViewOperator_AfterDelete(sdjls_sbpjb newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(sdjls_sbpjb newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(sdjls_sbpjb newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as sdjls_sbpjb);
        }

        void treeViewOperator_CreatingObject(sdjls_sbpjb newobj) {

        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (this.Site != null) return;
            barCreat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }
        public void Init() {
            treeList1.Columns["pddj"].Visible = false;
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
            treeViewOperator.RefreshData(" where OrgCode='" + parentID + "' order by  pjrq");
        }

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (btXlList.EditValue == null || btXlList.EditValue.ToString() == "") {
                return;
            }
            sd_xl xl = btXlList.EditValue as sd_xl;
            sdjls_sbpjb pj = new sdjls_sbpjb();
            pj.pjrq = DateTime.Now;
            //pj.pddj = "一级";
            pj.pjfzr = MainHelper.User.UserName;
            pj.LineName = xl.LineName;
            pj.LineCode = xl.LineCode;
            pj.OrgCode = xl.OrgCode;
            pj.OrgName = parentObj.OrgName;
            pj.Remark = "";
            MainHelper.PlatformSqlMap.Create<sdjls_sbpjb>(pj);

            InitData();
            //if (MsgBox.ShowAskMessageBox("是否马上生成条图") == DialogResult.OK)
            {

                try {
                    if (ExportToExcel("送电线路设备评级表", "", pj) < 1) return;

                    frm22sbpjbTemplate frm = new frm22sbpjbTemplate();
                    frm.pjobject = pj;
                    if (frm.ShowDialog() == DialogResult.OK) {
                        Client.ClientHelper.PlatformSqlMap.Update<sdjls_sbpjb>(frm.pjobject);
                        //MessageBox.Show("保存成功");
                    }
                } catch (Exception ex) {
                    MsgBox.ShowException(ex);

                }
            }

        }

        public static int ExportToExcel(string title, string dw, sdjls_sbpjb pj17) {
            string fname = Application.StartupPath + "\\00记录模板\\送电线路设备评级表.xls";
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
            try {
                if (xl == null) {
                    MsgBox.ShowWarningMessageBox("数据出错，没找到线路");
                    return -1;
                }
                string strLinexh = xl.WireType;//导线型号
                
                IList<sd_gt> gtlis = Client.ClientHelper.PlatformSqlMap.GetList<sd_gt>(" Where LineCode='" + xl.LineCode + "' order by gtcode");
                
                ex.ActiveSheet(1);
                //设置线路值
                ex.SetCellValue(xl.LineName, 4, 3);
                ex.SetCellValue(xl.LineVol, 4, 5);
                ex.SetCellValue(xl.WireLength.ToString(), 4, 7);
                ex.SetCellValue(xl.InDate.Year.ToString(), 4, 9);
                ex.SetCellValue(xl.InDate.Month.ToString(), 4, 11);
                //评级日期
                ex.SetCellValue(DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日", 5, 3);

                //杆塔
                ex.SetCellValue(gtlis.Count.ToString(), 6, 3);//合计
                ex.SetCellValue(gtlis.Count.ToString(), 7, 3);//一类
                //导地线
                ex.SetCellValue(xl.WireLength.ToString(), 10, 3);//合计
                ex.SetCellValue(xl.WireLength.ToString(), 11, 3);//一类
                //绝缘子
                string sql = "in (";
                foreach (sd_gt gt in gtlis)
                { 
                    sql+="'"+gt.gtID+"',";
                }
                sql = sql.Substring(0, sql.Length - 1) + ")";
                string strSQL = "select  sbModle from sd_gtsb Where  gtID " + sql;
                
                IList jdzzList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                if (xl.LineVol != "" && Convert.ToDouble(xl.LineVol) >= 10)
                {
                    strSQL += "  and (sbName like '高压%立瓶%' or sbName like '高压%悬垂%' or sbName like '高压%茶台%' )";
                }
                else
                    if (xl.LineVol != "" && 0.4 >= Convert.ToDouble(xl.LineVol))
                    {
                        strSQL += "  and (sbName like '低压%立瓶%'  or sbName like '低压%茶台%' )";
                    }

                IList jyuzlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);

                ex.SetCellValue(jyuzlist.Count.ToString(), 14, 3);
                ex.SetCellValue(jyuzlist.Count.ToString(), 15, 3);
                //接地装置
                ex.SetCellValue(jdzzList.Count.ToString(), 18, 3);
                ex.SetCellValue(jdzzList.Count.ToString(), 19, 3);

                //其它
                
                //评定等级
                ex.SetCellValue("一级", 25, 3);
                //评级负责人
                if (MainHelper.User != null)
                {
                    ex.SetCellValue(MainHelper.User.UserName, 26, 3);
                }
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

            sdjls_sbpjb obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjls_sbpjb>(treeList1.FocusedNode["ID"]);
            if (obj == null)
                return;
            try {
                if (ExportToExcel("送电线路条图", "", obj) < 1) return;

                frm22sbpjbTemplate frm = new frm22sbpjbTemplate();
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK) {
                    Client.ClientHelper.PlatformSqlMap.Update<sdjls_sbpjb>(frm.pjobject);
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
                sdjls_sbpjb obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjls_sbpjb>(treeList1.FocusedNode["ID"]);
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
                frm22sbpjbTemplate frm = new frm22sbpjbTemplate();
                sdjls_sbpjb obj = MainHelper.PlatformSqlMap.GetOneByKey<sdjls_sbpjb>(treeList1.FocusedNode["ID"]);
                if (obj == null)
                    return;
                frm.pjobject = obj;
                if (frm.ShowDialog() == DialogResult.OK) {
                    Client.ClientHelper.PlatformSqlMap.Update<sdjls_sbpjb>(frm.pjobject);
                    //MessageBox.Show("保存成功");
                }
            }
        }
    }
}
