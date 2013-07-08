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
    public partial class frm_Dgjcjl : FormBase, IPopupFormEdit 
    {
        public frm_Dgjcjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        public string state;
        private sdjls_dgjcjlnr rowData;
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
                    this.rowData = value as sdjls_dgjcjlnr;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_dgjcjlnr>(value as sdjls_dgjcjlnr, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList<sd_gt> gtList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='"+rowData.c1+"'");
            foreach (sd_gt gt in gtList)
            {
                cmbqsgh.Properties.Items.Add(gt.gth);
                cmbzzgh.Properties.Items.Add(gt.gth);
            }
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.c2);
            this.cmbjcr.Properties.Items.AddRange(ryList);
            ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", cmbqxdj);

        }

        private void dataBind()
        {
            this.datejcrq.DataBindings.Add("EditValue", rowData, "jcrq");
            this.cmbqsgh.DataBindings.Add("EditValue", rowData, "qsgtbh");
            this.cmbzzgh.DataBindings.Add("EditValue", rowData, "zzgtbh");
            this.memojcjg.DataBindings.Add("EditValue", rowData, "jcjg");
            this.cmbjcr.DataBindings.Add("EditValue", rowData, "jcr");
            this.memobz.DataBindings.Add("EditValue", rowData, "bz");
            this.cmbqxdj.DataBindings.Add("EditValue", rowData, "qxdj");
        }

        #endregion

        private void frm_Dgjcjl_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rowData.qxdj.Trim()))
            {
                this.cbxqx.Checked = true;
                this.lblqxdj.Visible = true;
                this.cmbqxdj.Visible = true;
            }
        }

        private void cbxqx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxqx.Checked == true)
            {
                this.lblqxdj.Visible = true;
                this.cmbqxdj.Visible = true;
            }
            else
            {
                this.lblqxdj.Visible = false;
                this.cmbqxdj.Visible = false;
                this.cmbqxdj.EditValue = null;
               
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbxqx.Checked)
            {
                if (string.IsNullOrEmpty(cmbqxdj.EditValue.ToString()))
                {
                    MsgBox.ShowWarningMessageBox("请选择缺陷等级!");
                    return;
                }
            }
            else
            {
                rowData.qxdj = string.Empty;
            }
            
            sd_xl xl= Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where LineCode='" + rowData.c1 + "'");
            if (xl == null) 
                return;
            //添加缺陷
            sdjl_06sbxs sbxs= Client.ClientHelper.PlatformSqlMap.GetOne<sdjl_06sbxs>("where orgcode='" + rowData.c2 + "' and LineID='" + xl.LineID + "'");
            sdjl_06sbxsmx sbxsmx = new sdjl_06sbxsmx();
            string orgname = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + rowData.c2 + "'").OrgName; 
            if (sbxs == null)
            {
                sbxs = new sdjl_06sbxs();
                sbxs.OrgCode = rowData.c2;
                sbxs.OrgName = orgname;
                sbxs.LineID = xl.LineID;
                sbxs.LineName = xl.LineName;
                sbxs.xssj = rowData.jcrq;
                sbxs.CreateDate = DateTime.Now;
                Client.ClientHelper.PlatformSqlMap.Create<sdjl_06sbxs>(sbxs);    
            }
            sbxsmx.ParentID = sbxs.ID;
            sbxsmx.OrgCode = rowData.c2;
            sbxsmx.OrgName = orgname;
            sbxsmx.LineID = xl.LineID;
            sbxsmx.LineName = xl.LineName;
            sbxsmx.qxlb = rowData.qxdj;
            sbxsmx.qxnr = rowData.jcjg;
            sbxsmx.xsr = rowData.jcr;
            sbxsmx.xssj = rowData.jcrq;
            sbxsmx.CreateDate = DateTime.Now;
            Client.ClientHelper.PlatformSqlMap.Create<sdjl_06sbxsmx>(sbxsmx);

            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("送电登杆检查记录", "检查结果", memojcjg);
            if (!string.IsNullOrEmpty(memojcjg.EditValue as string))
                rowData.jcjg = memojcjg.EditValue as string;
        }


       

       
    }
}