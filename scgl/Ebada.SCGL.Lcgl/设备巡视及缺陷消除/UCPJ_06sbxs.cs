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
using System.Collections;
using Ebada.Core;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_06sbxs : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_06sbxs> gridViewOperation;

        public event SendDataEventHandler<PJ_06sbxs> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private DataTable gridtable = null;
        public UCPJ_06sbxs()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_06sbxs>(gridControl1, gridView1, barManager1,new frm06sbxsEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_06sbxs>(gridViewOperation_BeforeAdd);
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_06sbxs>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_06sbxs>(gridViewOperation_AfterEdit);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_06sbxs>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_AfterEdit(PJ_06sbxs obj)
        {
            InitData();
        }
        void gridViewOperation_AfterAdd(PJ_06sbxs obj)
        {
            InitData();
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_06sbxs> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_06sbxs> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_06sbxs);
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
            RefreshData(" where OrgCode='" + parentID + "' order by id desc");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(PJ_06sbxs), gridView1.Columns[i].FieldName);

            }
            hideColumn("OrgCode");
            hideColumn("LineID");
            hideColumn("gzrjID");
            //((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            //GridColumn picview = new DevExpress.XtraGrid.Columns.GridColumn();
            //picview.Caption = "消缺限期";
            //picview.Visible = true;
            ////picview.MaxWidth = 300;
            ////picview.MinWidth = 300;
            ////DevExpress.XtraEditors.Repository.RepositoryItem

            //picview.VisibleIndex = 8;
            //picview.FieldName = "Deadline";
            //gridView1.Columns.Add(picview);
            //((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //gridViewOperation.RefreshData(slqwhere);
            if (gridtable != null) gridtable.Rows.Clear();

            IList<PJ_06sbxs> li = MainHelper.PlatformSqlMap.GetList<PJ_06sbxs>("SelectPJ_06sbxsList", slqwhere);
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((IList)li);
                if (!gridtable.Columns.Contains("Deadline")) gridtable.Columns.Add("Deadline", typeof(string));
                DataRow[] drlist = gridtable.Select("qxlb<>'' and xcr='' ");
                string dx = "", sx = "";
                int dayspan1 = 1, dayspan2 = 10, dayspan3 = 30;
                dx = "06设备巡视及缺陷消除记录";
                sx = "紧急缺陷";
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
                if (list.Count > 0)
                {
                    dayspan1 = Convert.ToInt32(list[0]);
                }

                sx = "重大缺陷";
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
                if (list.Count > 0)
                {
                    dayspan2 = Convert.ToInt32(list[0]);
                }
                sx = "一般缺陷";
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
                if (list.Count > 0)
                {
                    dayspan3 = Convert.ToInt32(list[0]);
                }
                foreach (DataRow dr in drlist)
                {
                    DateTime dt = Convert.ToDateTime(dr["xssj"]);

                    switch (dr["qxlb"].ToString())
                    {
                        case "紧急缺陷":
                            dr["Deadline"] = dt.AddDays(dayspan1).ToShortDateString();
                            break;
                        case "重大缺陷":
                            dr["Deadline"] = dt.AddDays(dayspan2).ToShortDateString();
                            break;
                        case "一般缺陷":
                            dr["Deadline"] = dt.AddDays(dayspan3).ToShortDateString();
                            break;
                    }

                }
                if (drlist.Length > 0) li = ConvertHelper.ToIList<PJ_06sbxs>(gridtable);
            }
            
           
           gridControl1.DataSource = li;
        }

        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_06sbxs> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_06sbxs newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.xssj = DateTime.Now;
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
                    RefreshData(" where OrgCode='" + value + "' order by id desc");
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frm06sbxsLine frm = new frm06sbxsLine();
            //frm.orgcode = btGdsList.EditValue.ToString();
            //if (frm.ShowDialog()==DialogResult.OK)
            //{

            //    IList<PJ_06sbxs> pj06list = new List<PJ_06sbxs>();
            //    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxs>(" where LineName='" + frm.linename + "'");
            //    if (pj06list.Count>0)
            //    {
            //        Export06.ExportExcel(pj06list);
            //    }
            //   else
            //    {
            //        MsgBox.ShowTipMessageBox("此线路没有添加巡视情况。");
            //        return;
            //    }
            //}

            Dictionary<string, List<PJ_06sbxs>> diclist = new Dictionary<string, List<PJ_06sbxs>>();
            for (int i = 0; i < gridView1.RowCount;i++ )
            {
                PJ_06sbxs _pj = gridView1.GetRow(i) as PJ_06sbxs;
                if (diclist.ContainsKey(_pj.LineID))
                {
                    diclist[_pj.LineID].Add(_pj);
                }
                else
                {
                    List<PJ_06sbxs> lispj = new List<PJ_06sbxs>();
                    lispj.Add(_pj);
                    diclist[_pj.LineID] = lispj;
                }
            }
            foreach (KeyValuePair<string, List<PJ_06sbxs>> pp in diclist)
            {
                List<PJ_06sbxs> objlist = pp.Value;
                if (objlist.Count > 0)
                {
                    Export06.ExportExcel(objlist);
                }

            }
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentID == null) return;
            frmXSQD pd = new frmXSQD();
            pd.parentobj = ParentObj;
            pd.ShowDialog();
          
        }

    }
}
