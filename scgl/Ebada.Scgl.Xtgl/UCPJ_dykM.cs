/**********************************************
系统:企业ERP
模块:  
作者:Rabbit
创建时间:2011-6-2
最后一次修改:2011-6-2
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using DevExpress.XtraBars;
using Ebada.Client;

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_dykM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_dykM() {
            InitializeComponent();
            //接收TreeList行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_dyk>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PJ_dyk obj) {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = "内容所在类别：" + (obj != null ? obj.dx : "");
        }

        void ucTop_AfterEdit(PJ_dyk obj)
        {
            //ucBottom.ParentObj = obj;
            //splitCC1.Panel2.Text = "内容所在类别：" + (obj != null ? obj.dx : "");
            Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("UPDATE  dbo.PJ_dyk SET dx='{0}',sx='{1}' WHERE ParentID='{2}'", obj.dx, obj.sx, obj.ID));

            ucBottom.ParentObj = obj;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ucBottom.ParentID = "0";
            ucBottom.barCopy.Visibility = BarItemVisibility.Always;
            ucBottom.InitColumns();
            ucTop.barCopy.Visibility = BarItemVisibility.Never;
            ucTop.InitColumns();
            ucTop.InitData();
           ucTop.ChildView = ucBottom.GridViewOperation;
           ucTop.GridViewOperation.AfterEdit +=new ObjectEventHandler<PJ_dyk>(ucTop_AfterEdit);
        }

    }
}
