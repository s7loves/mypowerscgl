using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;

namespace Ebada.Scgl.Yxgl
{
    public partial class frm_jyzjcjl : FormBase, IPopupFormEdit 
    {
        public frm_jyzjcjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_jyzcsjl rowData;
        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as sdjls_jyzcsjl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_jyzcsjl>(value as sdjls_jyzcsjl, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from sd_gt where   LineCode='{0}' ", rowData.LineID));
            cmbgh.Properties.Items.AddRange(list);
            ICollection gxList = new ArrayList();
            gxList = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select distinct gtModle from sd_gt where LineCode='{0}'", rowData.LineID));
            cmbgx.Properties.Items.AddRange(gxList);
            ComboBoxHelper.FillCBoxByDyk("10绝缘子测试记录", "绝缘子型号", this.cmbjyzxh.Properties);
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.c2);//获取供电所人员列表
            cmbsyfzr.Properties.Items.AddRange(ryList);

        }

        private void dataBind()
        {
            //单位名称
            this.txtdwmc.DataBindings.Add("EditValue", rowData, "ParentID");
            this.txtlineName.DataBindings.Add("EditValue", rowData, "LineName");
            this.datecssj.DataBindings.Add("EditValue", rowData, "cssj");
            this.dateclsj.DataBindings.Add("EditValue", rowData, "clsj");
            this.cmbgh.DataBindings.Add("EditValue", rowData, "gh");
            this.cmbgx.DataBindings.Add("EditValue", rowData, "gx");
            this.cmbjyzxh.DataBindings.Add("EditValue", rowData, "jyzxh");
            this.cmbsyfzr.DataBindings.Add("EditValue", rowData, "syfzr");
            this.memojyzwz.DataBindings.Add("EditValue", rowData, "lzjyzwz");
            this.memoclqk.DataBindings.Add("EditValue", rowData, "c1");
            this.memobz.DataBindings.Add("EditValue", rowData, "bz");
            this.spelzs.DataBindings.Add("EditValue", rowData, "c3");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnjyzwz_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("绝缘子", "位置", this.memojyzwz);
            if (!string.IsNullOrEmpty(memojyzwz.EditValue as string))
                rowData.lzjyzwz = memojyzwz.EditValue as string;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("绝缘子", "处理情况", memoclqk);
            if (!string.IsNullOrEmpty(memoclqk.EditValue as string))
                rowData.c1 = memoclqk.EditValue as string;
        }
    }
}