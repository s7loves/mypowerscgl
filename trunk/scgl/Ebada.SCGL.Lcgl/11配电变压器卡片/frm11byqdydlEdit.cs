﻿using System;
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
namespace Ebada.Scgl.Lcgl
{
    public partial class frm11byqdydlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_11byqdydl> m_CityDic = new SortableSearchableBindingList<PJ_11byqdydl>();

        public frm11byqdydlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "clrq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "fjtwz");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "ao");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "bo");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "co");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "a");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "b");
            this.spinEdit6.DataBindings.Add("EditValue", rowData, "c");
            this.spinEdit7.DataBindings.Add("EditValue", rowData, "ao2");
            this.spinEdit8.DataBindings.Add("EditValue", rowData, "bo2");
            this.spinEdit9.DataBindings.Add("EditValue", rowData, "co2");
           

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_11byqdydl rowData = null;

        public object RowData {
            get {
                DealPH(rowData);
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_11byqdydl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_11byqdydl>(value as PJ_11byqdydl, rowData);
                }
            }
        }
        //处理不平衡度问题
        private void DealPH(PJ_11byqdydl rowData)
        {
            //负荷不平衡率大于15%走负荷调整子流程，（配变负荷调整记录表每一行走一遍负荷调整子流程）

           

            decimal max = (rowData.a > rowData.b ? rowData.a : rowData.b) > rowData.c ? (rowData.a > rowData.b ? rowData.a : rowData.b) : rowData.c;
            decimal min = (rowData.a < rowData.b ? rowData.a : rowData.b) < rowData.c ? (rowData.a < rowData.b ? rowData.a : rowData.b) : rowData.c;
            decimal per = 0;
            if (max > 0)
            {
                per = (max - min) * 100 / max;
            }
            rowData.bphd = (double)Math.Round(per, 1);

            PS_tqbyq byq = MainHelper.PlatformSqlMap.GetOneByKey<PS_tqbyq>(rowData.byqID);
            
            decimal dl = (rowData.a + rowData.b + rowData.c) / 3;

            // 最大负荷电流低于配变二次额定电流60%或最大负荷电流超过配变额定电流10%
            if (dl < byq.byqCurrentTwo * 0.6M || dl > byq.byqCurrentTwo*0.1M)
            {
                rowData.by1 = "1";
            }
            else
            {
                rowData.by1 = "0";
            }

            
        }
        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "分接头位置", comboBoxEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电压", spinEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电压", spinEdit2.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电压", spinEdit3.Properties);

            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电流", spinEdit4.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电流", spinEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "首端电流", spinEdit6.Properties);

            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "末端电压", spinEdit7.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "末端电压", spinEdit8.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "末端电压", spinEdit9.Properties);


            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_11byqdydl>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
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

       
    }
}