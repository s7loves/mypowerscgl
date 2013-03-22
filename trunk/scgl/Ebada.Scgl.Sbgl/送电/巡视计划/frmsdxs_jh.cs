﻿using System;
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
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.Core;
using Ebada.UI.Base;

namespace Ebada.Scgl.Sbgl
{
    public partial class frmsdxs_jh : FormBase, IPopupFormEdit
    {
        public frmsdxs_jh()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private sd_xsjh rowData = null;
        private bool isfirstLoad = true;
        private bool isgtChange = false;
        public bool GetIsGtChange
        {
            get
            {
                return isgtChange;
            }
        }
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
                    this.rowData = value as sd_xsjh;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sd_xsjh>(value as sd_xsjh, rowData);
                }
            }
        }

        private void Initlkue()
        {
            IList<mOrg> listorg = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where 1>0 order by OrgCode,OrgType");
            List<DicType> orgDicTypeList = new List<DicType>();
            foreach (mOrg org in listorg)
            {
                orgDicTypeList.Add(new DicType(org.OrgCode, org.OrgName));
            }
            //SetComboBoxData(lkueStart, "Value", "Key", "请选择", "起始杆塔", dicTypeList);
            SetComboBoxData(lkueOrg, "Value", "Key", "请选择", "单位", orgDicTypeList);
            //是否完成
            List<DicType> wcbDictypeList = new List<DicType>();
            wcbDictypeList.Add(new DicType("完成", "完成"));
            wcbDictypeList.Add(new DicType("未完成", "未完成"));
            SetComboBoxData(lkuewcbj, "Value", "Key", "请选择", "是否完成", wcbDictypeList);
            //任务状态
            List<DicType> flagDictypeList = new List<DicType>();
            flagDictypeList.Add(new DicType("新建", "新建"));
            flagDictypeList.Add(new DicType("发布", "发布"));
            flagDictypeList.Add(new DicType("下载", "下载"));
            flagDictypeList.Add(new DicType("完成", "完成"));
            SetComboBoxData(lkueflag, "Value", "Key", "请选择", "任务状态", flagDictypeList);

        }
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void dataBind()
        {
            this.lkueOrg.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.lkueLine.DataBindings.Add("EditValue", rowData, "LineID");
            this.lkueStartGt.DataBindings.Add("EditValue", rowData, "c1");
            this.lkueEndGt.DataBindings.Add("EditValue", rowData, "c2");
            this.txtVol.DataBindings.Add("EditValue", rowData, "vol");
            this.txtxslb.DataBindings.Add("EditValue", rowData, "xslb");
            this.txtxsnr.DataBindings.Add("EditValue", rowData, "xsnr");
            this.txtsxr.DataBindings.Add("EditValue", rowData, "sxr");
            this.datejhsj.DataBindings.Add("EditValue", rowData, "jhsj");
            this.datexskssj.DataBindings.Add("EditValue", rowData, "xskssj");
            this.datexswcsj.DataBindings.Add("EditValue", rowData, "xswcsj");
            this.lkuewcbj.DataBindings.Add("EditValue", rowData, "wcbj");
            this.memoqxnr.DataBindings.Add("EditValue", rowData, "qxnr");
            this.lkueflag.DataBindings.Add("EditValue", rowData, "flag");
            this.txtcjr.DataBindings.Add("EditValue", rowData, "cjr");
            this.txtfbr.DataBindings.Add("EditValue", rowData, "fbr");
            this.datefbsj.DataBindings.Add("EditValue", rowData, "fbsj");
        }

        #endregion

        private void frmsdxs_jh_Load(object sender, EventArgs e)
        {
            isfirstLoad = false;
        }
        /// <summary>
        /// 单位变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkueOrg_EditValueChanged(object sender, EventArgs e)
        {
            if (lkueOrg.EditValue == null)
                return;
            IList<sd_xl> xlList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>("where OrgCode='"+lkueOrg.EditValue.ToString()+"'");
            List<DicType> xlDictypeList = new List<DicType>();
            foreach (sd_xl xl in xlList)
            {
                xlDictypeList.Add(new DicType(xl.LineCode, xl.LineName));
            }
            SetComboBoxData(lkueLine, "Value", "Key", "请选择", "线路", xlDictypeList);
        }
        /// <summary>
        /// 线路变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkueLine_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkueLine.EditValue == null)
                return;
            rowData.LineName = lkueLine.Text;
            List<DicType> gtDictypeList = new List<DicType>();
            IList<sd_gt> gtList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + lkueLine.EditValue.ToString() + "'");
            foreach (sd_gt gt in gtList)
            {
                gtDictypeList.Add(new DicType(gt.gtCode, gt.gtCode));
            }
            SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
            SetComboBoxData(lkueEndGt, "Value", "Key", "请选择", "终止杆塔", gtDictypeList);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rowData.LineName = lkueLine.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void lkueStartGt_EditValueChanged(object sender, EventArgs e)
        {
            if (!isfirstLoad)
                isgtChange = true;
        }

        private void lkueEndGt_EditValueChanged(object sender, EventArgs e)
        {
            if (!isfirstLoad)
                isgtChange = true; 
            
        }


    }
}