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
    public partial class frmSD_fsyyxjl : FormBase, IPopupFormEdit 
    {
        public frmSD_fsyyxjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_fsgyxjl rowData; 
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
                    this.rowData = value as sdjls_fsgyxjl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_fsgyxjl>(value as sdjls_fsgyxjl, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            combldr.Properties.Items.AddRange(ryList);
            cmbjhr.Properties.Items.AddRange(ryList);
            cmbzxr.Properties.Items.AddRange(ryList);

            ComboBoxHelper.FillCBoxByDyk("05反事故演习记录", "演习地点", cmbyxdd);
           

        }

        private void dataBind()
        {
            this.dateyxrq.DataBindings.Add("EditValue", rowData, "yxrq");
            this.cmbyxdw.DataBindings.Add("EditValue", rowData, "yxdw");
            this.timekssj.DataBindings.Add("EditValue", rowData, "kssj");
            this.timejssj.DataBindings.Add("EditValue", rowData, "jssj");
            this.cmbyxdd.DataBindings.Add("EditValue", rowData, "yxdd");
            this.cmbyxtm.DataBindings.Add("EditValue", rowData, "yxtm");
            this.combldr.DataBindings.Add("EditValue", rowData, "ldr");
            this.cmbjhr.DataBindings.Add("EditValue", rowData, "jhr");
            this.memojlpj.DataBindings.Add("EditValue", rowData, "jljpj");
            this.memocs.DataBindings.Add("EditValue", rowData, "ndcs");
            this.cmbzxr.DataBindings.Add("EditValue", rowData, "zxr");
            this.datezgqx.DataBindings.Add("EditValue", rowData, "zgxq");
            this.cmbqzldr.DataBindings.Add("EditValue", rowData, "qzldr");
            this.cmbqzjhr.DataBindings.Add("EditValue", rowData, "qzjhr");
        }

        #endregion
        /// <summary>
        /// 演习题目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnyxtm_Click(object sender, EventArgs e)
        {
            frmSDyxfa frm = new frmSDyxfa();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.cmbyxtm.EditValue = frm.yxfa.yxtm;
                rowData.yxtm = frm.yxfa.yxtm;
                rowData.yxtmID = frm.yxfa.ID;
            }

        }

        private void btnnrcs_Click(object sender, EventArgs e)
        {
            PJ_dyk dyk = SelectorHelper.SelectDyk("05反事故演习记录", "结论和措施", memojlpj, memocs);

            if (dyk != null)
            {
                rowData.jljpj = dyk.nr;
                rowData.ndcs = dyk.nr2;
            }
            else
            {
                MsgBox.ShowWarningMessageBox("无相关信息,请在短语库维护模块中填写：05反事故演习记录|结论和措施 信息");
            }
        }

        
    }
}