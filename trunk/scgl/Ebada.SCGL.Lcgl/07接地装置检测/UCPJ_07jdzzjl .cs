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

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_07jdzzjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_07jdzzjl> gridViewOperation;
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                //liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

        public event SendDataEventHandler<PJ_07jdzzjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private PJ_07jdzz parentObj;
        public UCPJ_07jdzzjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_07jdzzjl>(gridControl1, gridView1, barManager1, new frm07JDZZJlEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_07jdzzjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_07jdzzjl>(gridViewOperation_BeforeDelete);
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_07jdzzjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_07jdzzjl>(gridViewOperation_AfterEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_07jdzzjl>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_07jdzzjl>(gridViewOperation_BeforeEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_07jdzzjl> e)
        {
            //lgmqxlast
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(e.ValueOld.ID);
            e.ValueOld.gdstemp = ParentObj.OrgCode;
            if (tempobj != null)
            {
                e.ValueOld.xlid = tempobj.xlid;
                e.ValueOld.xlname = tempobj.xlname;
                e.ValueOld.tqid = tempobj.tqid;
                e.ValueOld.tqname = tempobj.tqname;
                e.ValueOld.byqid = tempobj.byqid;
                e.ValueOld.byqname = tempobj.byqname;
                e.ValueOld.kgid = tempobj.kgid;
                e.ValueOld.kgname = tempobj.kgname;
            }
        }

        void gridViewOperation_AfterDelete(PJ_07jdzzjl obj)
        {
            Delqxmx(obj.ID);
        }

        void gridViewOperation_AfterEdit(PJ_07jdzzjl obj)
        {
            Addqxmx(obj);
        }

        void gridViewOperation_AfterAdd(PJ_07jdzzjl obj)
        {
            Addqxmx(obj);
        }
        //处理缺陷明细  lgmqx
        private void Addqxmx(PJ_07jdzzjl obj)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(obj.ID);
            if (obj.jr != "合格")
            {
                if (tempobj == null || tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                    PJ_qxfl mx = new PJ_qxfl();
                    mx.ID = obj.ID;
                    mx.OrgCode = parentObj.OrgCode;
                    mx.OrgName = parentObj.OrgName;
                    mx.LineID = "05";
                    mx.LineName = parentObj.LineName;
                    mx.xlqd = parentObj.gth;
                    mx.xssj = obj.clrq;
                    mx.xsr = obj.jcr;
                    mx.qxly = "接地装置检测记录";
                    mx.qxnr = "接地电阻检测不合格";
                    mx.qxlb = "一般缺陷";
                    mx.xcqx = mx.xssj.AddMinutes(3).ToShortDateString();

                    //lgmqxlast
                    mx.xlid = obj.xlid;
                    mx.xlname = obj.xlname;
                    mx.tqid = obj.tqid;
                    mx.tqname = obj.tqname;
                    mx.byqid = obj.byqid;
                    mx.byqname = obj.byqname;
                    mx.kgid = obj.kgid;
                    mx.kgname = obj.kgname;

                    MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                }

            }
            else
            {
                if (tempobj != null && tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                }

            }
                 
        }
        private void Delqxmx(string id)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(id);
            if (tempobj != null && tempobj.xcr == string.Empty)
            {
                MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(id);
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_07jdzzjl> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_07jdzzjl> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;


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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_07jdzzjl);
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
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            //gridView1.Columns[9].Visible = false;
            hideColumn("gzrjID");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_07jdzzjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_07jdzzjl newobj)
        {
            if (parentID == null) return;
            newobj.jdzzID = parentID;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;

            newobj.gdstemp = ParentObj.OrgCode;
            newobj.xlid = ParentObj.LineID;

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
                    RefreshData(" where jdzzID='" + value + "' order by CreateDate desc");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PJ_07jdzz ParentObj
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
                    ParentID = value.jdzzID;
                }
            }
        }
    }
}
