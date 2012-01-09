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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmxsDialog : FormBase, IPopupFormEdit
    {

        public frmxsDialog()
        {
            InitializeComponent();
        }
        SortableSearchableBindingList<PJ_sbxsqd> m_CityDic = new SortableSearchableBindingList<PJ_sbxsqd>();
        public string orgcode = "";
        public string linename = "";
        private void frm06sbxsLine_Load(object sender, EventArgs e)
        {

            //ICollection linelist = ComboBoxHelper.GetGdsxl(orgcode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
        }


        //private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    linename = comboBoxEdit1.EditValue.ToString();
        //}

        void dataBind()
        {


            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xsqdName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "XSR1");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "XSR2");
         

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_sbxsqd rowData = null;

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
                    this.rowData = value as PJ_sbxsqd;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_sbxsqd>(value as PJ_sbxsqd, rowData);
                    this.InitComboBoxData();
                }
               
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            ICollection ryList = ComboBoxHelper.GetGdsRy(orgcode);//获取供电所人员列表

            //comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit3.Properties.Items.AddRange(ryList);
            //comboBoxEdit6.Properties.Items.AddRange(ryList);
            comboBoxEdit4.Properties.Items.AddRange(ryList);

            //ICollection linelist = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<PS_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where OrgCode='" + orgcode + "'");
            SetComboBoxData(lookUpEdit1, "LineName", "LineID", "选择线路", "", xllit);

            ////巡视区段
            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视区段", comboBoxEdit2.Properties);

            ////ICollection qxlist = ComboBoxHelper.GetQxlb();//获取缺陷类别
            ////缺陷类别GetQxlb
            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);

            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视人", comboBoxEdit3.Properties);

            //comboBoxEdit4.Properties.Items.AddRange(qxlist);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_xl> post)
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
      
    }
}