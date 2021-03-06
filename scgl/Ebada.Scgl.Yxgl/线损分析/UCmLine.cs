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
using Ebada.Scgl.Core;

namespace Ebada.Scgl.Yxgl{

    [ToolboxItem(false)]
    public partial class UCmLine : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_xl> gridViewOperation;
        
        public event SendDataEventHandler<PS_xl> FocusedRowChanged;
        private string parentID;
        private PS_xl parentObj;
        public UCmLine() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<PS_xl>(gridControl1, gridView1, barManager1);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            //gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_xl>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            initColumns();
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() { 
            //foreach (GridColumn gc in gridView1.Columns)
            //{
            //    gc.Visible = false;
            //}
            //gridView1.Columns["LineID"].Visible = false;
            //gridView1.Columns["LineCode"].Visible = true;
            gridView1.Columns["ParentID"].Visible = false;

            gridView1.Columns["LineNamePath"].Visible = false;
            //gridView1.Columns["OrgCode"].Visible = true;
            //gridView1.Columns["OrgCode2"].Visible = true;
            //gridView1.Columns["RunState"].Visible = true;

            //gridView1.Columns["WireType"].Visible = true;
            //gridView1.Columns["WireLength"].Visible = true;
            //gridView1.Columns["TotalLength"].Visible = true;
            //gridView1.Columns["TheoryLoss"].Visible = true;
            //gridView1.Columns["ActualLoss"].Visible = true;
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_xl> e) {
            if (string.IsNullOrEmpty(parentID))
            {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择机构后增加职员！");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_xl);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PS_xl> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_xl newobj) {

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
                        str = string.Format("where LineID='{0}'", parentID);
                    }
                }
                gridViewOperation.RefreshData(str);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_xl ParentObj
        {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.LineID;
                }
            }
        }

        private void btLineLoss_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PS_xl currentLine = gridView1.GetFocusedRow() as PS_xl;
            if (currentLine!=null)
            {
                //List<PS_xl> list = LineLossHelper.GetChildrenList(currentLine.LineID);
                //foreach (PS_xl line in list)
                //{
                currentLine.TheoryLoss = LineLossHelper.Loss(currentLine);
                Client.ClientHelper.PlatformSqlMap.Update<PS_xl>(currentLine);
                //}
            }
            string str = " where 1>1";
            str = string.Format("where LineID='{0}'", parentID);
            gridViewOperation.RefreshData(str);
        }

        private void btAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PS_xl currentLine = gridView1.GetFocusedRow() as PS_xl;
            List<string> strList = new List<string>();
            LineAnaly lineAnaly = LineLossHelper.LineLossAnaly(currentLine);
            if (currentLine!=null)
            {
                if (currentLine.TheoryLoss==0)
                {
                    MessageBox.Show("请进行线损计算后再运行线损分析！");
                    return;
                }
                else
                {
                    if ((currentLine.ActualLoss-currentLine.TheoryLoss)/currentLine.LineP>Convert.ToDecimal(0.05))
                    {
                        strList.Add("管理线损过大，存在偷、漏、差、误等不良现象。");
                    }
                    else if (lineAnaly.FixLossWeight - lineAnaly.VariableLossWeight > Convert.ToDecimal(0.1) || lineAnaly.LossRate - lineAnaly.EconomyLossRate > Convert.ToDecimal(0.1))
                    {
                        strList.Add("轻载，应积极发展用电负荷，更换高能耗变压器，调整大马拉小车的变压器，降低电压运行水平，减少变压器层次等措施。");
                    }
                    else if (lineAnaly.FixLossWeight - lineAnaly.VariableLossWeight < -Convert.ToDecimal(0.1) || lineAnaly.LossRate - lineAnaly.EconomyLossRate < -Convert.ToDecimal(0.1))
                    {
                        strList.Add("超负荷运行，应改造卡脖子和迂回线路，缩短供电半径，提高电压运行水平，无功补偿，调整负荷曲线，减小峰谷差，三相平衡，更换过载变压器等措施。");
                    }
                }
                if (strList.Count>0)
                {
                    ExcelAccess ex = new ExcelAccess();
                   // ex.ActiveSheet(0);
                    ex.CreateExcel();
                    ex.CreateWorkSheet("13");
                    Ecommon.CreatandWritesheet(ex, strList, strList.Count, 1, 1);
                }
            }
        }

    }
}
