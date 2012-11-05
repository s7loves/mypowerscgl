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
    public partial class frm21dyjcdcbkchildEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_21dyjcdcbkchild> m_CityDic = new SortableSearchableBindingList<PJ_21dyjcdcbkchild>();

        public frm21dyjcdcbkchildEdit()
        {
            InitializeComponent();
        }
        private bool isfirstload = true;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }
        void dataBind() {

            this.cobMonth.DataBindings.Add("EditValue", rowData,"month");

            this.cobCbr.DataBindings.Add("EditValue", rowData, "cbr");
            this.spalltime.DataBindings.Add("EditValue", rowData, "alltime");
            this.spuptime.DataBindings.Add("EditValue", rowData, "uptime");
            this.spdowntime.DataBindings.Add("EditValue", rowData, "downtime");
            this.sphegetime.DataBindings.Add("EditValue", rowData, "hegetime");
            this.spcsxl.DataBindings.Add("EditValue", rowData, "csxl");
            this.spcxxl.DataBindings.Add("EditValue", rowData, "cxxl");
            this.sphegel.DataBindings.Add("EditValue", rowData, "hegel");
            this.spbignum.DataBindings.Add("EditValue", rowData, "bignumvalue");
            this.datebigshowtime.DataBindings.Add("EditValue", rowData, "bigshowtime");
            this.spminnum.DataBindings.Add("EditValue", rowData,"minnumvalue");
            this.dateminshowtime.DataBindings.Add("EditValue", rowData,"minshowtime");
            
        }
        #region IPopupFormEdit Members
        private PJ_21dyjcdcbkchild rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                isfirstload = true;
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_21dyjcdcbkchild;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_21dyjcdcbkchild>(value as PJ_21dyjcdcbkchild, rowData);
                }
                spuptime.EditValue = rowData.uptime;
                spdowntime.EditValue = rowData.downtime;
                sphegel.EditValue = rowData.hegetime;

                isfirstload = false;
            }
        }

        #endregion

        private void InitComboBoxData() {

            cobMonth.Properties.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cobMonth.Properties.Items.Add(i);
            }
            cobCbr.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(MainHelper.User.OrgCode));
            
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

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            //PS_tqbyq byq = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PJ_21dyjcdcbkchild>(rowData.byqID);
            ////if (rowData.azrq>byq.InDate)
            ////{
            ////    MsgBox.ShowTipMessageBox("安装时间不能在投放时间之后！");
            ////    return;
            ////}
            //if (rowData.ccrq.Year>1900 && rowData.ccrq < rowData.azrq)
            //{
            //    MsgBox.ShowTipMessageBox("撤除时间不能在安装时间之前！");
            //    return;
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void spalltime_EditValueChanged(object sender, EventArgs e)
        {
            ReJS();
        }

        private void spuptime_EditValueChanged(object sender, EventArgs e)
        {
            ReJS();
        }

        private void spdowntime_EditValueChanged(object sender, EventArgs e)
        {
            ReJS();
        }

        private void ReJS()
        {
            if (isfirstload)
            {
                return;
            }
            int tempall=rowData.alltime;
            int.TryParse(spalltime.EditValue.ToString(), out tempall);
            rowData.alltime=tempall;

             int tempup=rowData.uptime;
            int.TryParse(spuptime.EditValue.ToString(), out tempup);
            rowData.uptime=tempup;

             int tempdown=rowData.downtime;
            int.TryParse(spdowntime.EditValue.ToString(), out tempdown);
            rowData.downtime=tempdown;

            int hegenum = rowData.alltime - rowData.uptime - rowData.downtime;

            if (hegenum>0)
            {
                rowData.hegetime=hegenum;
                sphegetime.EditValue = hegenum;
            }
            else
	        {
                rowData.hegetime=0;
	        }
            if (rowData.alltime>0)
            {
                rowData.csxl = Math.Round(rowData.uptime * 100.0 / rowData.alltime, 1);
                rowData.cxxl = Math.Round(rowData.downtime * 100.0 / rowData.alltime, 1);
                rowData.hegel = Math.Round(rowData.hegetime * 100.0 / rowData.alltime, 1);
            }
        }
        private void sphegetime_EditValueChanged(object sender, EventArgs e)
        {
            if (rowData.alltime > 0)
            {
                rowData.hegel = Math.Round(rowData.hegetime * 100.0 / rowData.alltime, 1);
            }
        }

        private void cobMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isfirstload)
            {
                int tempall = rowData.month;
                int.TryParse(cobMonth.EditValue.ToString(), out tempall);
                rowData.month = tempall;

                rowData.bigshowtime = new DateTime(rowData.bigshowtime.Year, rowData.month, rowData.bigshowtime.Day, rowData.bigshowtime.Hour, rowData.bigshowtime.Minute, rowData.bigshowtime.Second);

                rowData.minshowtime = new DateTime(rowData.minshowtime.Year, rowData.month, rowData.minshowtime.Day, rowData.minshowtime.Hour, rowData.minshowtime.Minute, rowData.minshowtime.Second);
            }
        }
    }
}