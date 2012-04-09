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
using System.Threading;
namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    ///  批量增加杆塔设备
    /// </summary>
    public partial class frmgtsbEditM : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_gtsb> m_CityDic = new SortableSearchableBindingList<PS_gtsb>();

        public frmgtsbEditM() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbType");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "C1");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "C2");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "C3");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "C4");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "C5");

            this.spinEdit2.DataBindings.Add("EditValue", rowData, "sbNumber");

        }
        List<itemobj> gtlist;
        public void SetGt(ICollection<PS_gt> gts) {
            gtlist = new List<itemobj>();
            foreach (PS_gt gt in gts) {
                itemobj obj =new itemobj(gt);
                comboBoxEdit10.Properties.Items.Add(obj);
                comboBoxEdit11.Properties.Items.Add(obj);
                gtlist.Add(obj);
            }
            RowData = new PS_gtsb();
            rowData.sbNumber = 1;
        }
        #region IPopupFormEdit Members
        private PS_gtsb rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_gtsb;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_gtsb>(value as PS_gtsb, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
            SetComboBoxData(repositoryItemLookUpEdit1, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(repositoryItemLookUpEdit1_EditValueChanged);
        }

        void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e) {
            DataRow dr = gridView1.GetFocusedDataRow();
            LookUpEdit edit = sender as LookUpEdit;
            object xh = edit.EditValue ;
            if (string.IsNullOrEmpty(xh as string)) return;
            dr["type"] =dr["code"]= xh;
            repositoryItemComboBox2.Properties.Items.Clear();
            dr["name"] = repositoryItemLookUpEdit1.GetDisplayText(xh);
            //System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh  from PS_sbcs where   mc='" + ((ComboBoxEdit)sender).EditValue + "' and xh is not null ");
            //if (mclist.Count > 0)
            //    repositoryItemComboBox2.Properties.Items.AddRange(mclist);
            //else {

            //}
            //rowData.sbName = comboBoxEdit4.Text = comboBoxEdit2.Text;
            repositoryItemComboBox2.Items.AddRange(ComboBoxHelper.GetsbxhList(xh.ToString()));
            //pdsbModelHelper.FillCBox(repositoryItemComboBox2.OwnerEdit, xh.ToString().Substring(0, 2));
        }

        void comboBoxEdit2_EditValueChanged(object sender, EventArgs e) {
            object xh = comboBoxEdit2.EditValue;
            if (string.IsNullOrEmpty(xh as string)) return;
            rowData.sbName = comboBoxEdit4.Text = comboBoxEdit2.Text;
            pdsbModelHelper.FillCBox(comboBoxEdit3, xh.ToString().Substring(0, 2));
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_sbcs> post) {
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
        public void SetComboBoxData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_sbcs> post) {
            comboBox.Properties.Columns.Clear();
            //comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            if (comboBoxEdit10.SelectedIndex == -1) {
                MsgBox.ShowTipMessageBox("请输入启始杆号。");
                comboBoxEdit10.Focus();
                return;
            }
            if (comboBoxEdit11.SelectedIndex == -1) {
                MsgBox.ShowTipMessageBox("请输入终止杆号。");
                comboBoxEdit11.Focus();
                return;
            }

            //if (comboBoxEdit1.Text == "")
            //{
            //    MsgBox.ShowTipMessageBox("启始设备编号不能为空。");
            //    comboBoxEdit1.Focus();
            //    return;
            //}
            save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void save() {
            int begin = comboBoxEdit10.SelectedIndex;
            int end = comboBoxEdit11.SelectedIndex;
            //int bh =1;
            if (string.IsNullOrEmpty(comboBoxEdit2.Text)) {
                MsgBox.ShowTipMessageBox("请选择设备种类");
                comboBoxEdit2.Focus();
                return;
            }
            //if (string.IsNullOrEmpty(comboBoxEdit3.Text)) {
            //    MsgBox.ShowTipMessageBox("请选择设备型号");
            //    comboBoxEdit3.Focus();
            //    return;
            //}
            //if (!int.TryParse(comboBoxEdit1.Text, out bh)) {
            //    bh = 1;
            //}
            //if (bh<0||bh > 999) {
            //    MsgBox.ShowTipMessageBox("编号范围000-999");
            //    return;
            //}
            //if ((bh + end - begin) > 999) {
            //    MsgBox.ShowTipMessageBox("终止编号不能大于999");
            //    return;
            //}
            List<PS_gtsb> gtsblist = new List<PS_gtsb>();

            //for (int i = begin; i <= end; i++) {

            //    PS_gt gt= gtlist[i].Gt;
            //    PS_gtsb gtsb = new PS_gtsb();
            //    Ebada.Core.ConvertHelper.CopyTo(RowData,gtsb);
            //    gtsb.gtID = gt.gtID;
            //    gtsb.sbID =gt.CreateID()+i;
            //    gtsb.sbCode = bh.ToString("000");
            //    gtsblist.Add(gtsb);
            //}
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = begin; i <= end; i++)
                {

                    PS_gt gt = gtlist[i].Gt;
                    int j = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["type"] == null) continue;
                        PS_gtsb gtsb = new PS_gtsb();

                        gtsb.sbName = dr["name"].ToString();
                        gtsb.sbModle = dr["sbgg"].ToString();
                        if (dr["sl"] != null && (dr["sl"].ToString().Trim())!="") 
                            gtsb.sbNumber = Convert.ToInt16( dr["sl"]);
                        gtsb.sbID = gtsb.CreateID();
                        gtsb.gtID = gt.gtID;
                        gtsb.sbID = gt.CreateID() + i;
                        j++;
                        gtsb.sbCode = j.ToString("000");
                        gtsb.sbType = dr["type"].ToString();
                        if (gtsb.sbName == "") continue;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        gtsblist.Add(gtsb);
                    }
                }
            }
            Ebada.Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(gtsblist, null, null);
        }
        private void comboBoxEdit4_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "")
            {
                comboBoxEdit3.Properties.Items.Clear();
                IList<PS_sbcs> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>(" where mc='" + comboBoxEdit4.Text  + "' order by ID");
                for (int i = 0; i < list.Count; i++)
                {

                    comboBoxEdit3.Properties.Items.Add(list[i].xh);
                
                }
            
            }
        }
        class itemobj {
            public PS_gt Gt ;
            public itemobj(PS_gt gt) {
                Gt = gt;
            }
            public override string ToString() {
                return Gt.gth;
            }
        }

        private void frmgtsbEditM_Load(object sender, EventArgs e)
        {
            comboBoxEdit12.Properties.Items.Clear();
            comboBoxEdit12.Properties.NullText="请选择";
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select zl from PS_gtsbclb where ParentID not in (select id from PS_gtsbclb where 1=1)  ");

            comboBoxEdit12.Properties.Items.AddRange(mclist);

            //IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            //string.Format("select distinct mc from PS_sbcs"));
            //if (strlist.Count > 0)
            //    repositoryItemComboBox1.Properties.Items.AddRange(strlist);
        }

        private void comboBoxEdit12_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("type");
            dt.Columns.Add("sbgg");
            dt.Columns.Add("sl");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            IList<PS_gtsbclb> mclist = MainHelper.PlatformSqlMap.GetList<PS_gtsbclb>(" where ParentID  in (select id from PS_gtsbclb where zl='" + comboBoxEdit12.Text + "' and ParentID not in (select id from PS_gtsbclb where 1=1)  ) ");
            foreach (PS_gtsbclb gtsb in mclist)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = gtsb.ID;
                dr["code"] = gtsb.bh;
                dr["type"] = gtsb.bh;
                dr["name"] = gtsb.mc;
                dr["sbgg"] = gtsb.xh;

                dt.Rows.Add(dr);

            }
            gridControl1.DataSource = dt; 
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow(); 
            repositoryItemComboBox2.Properties.Items.Clear();
            dr["name"] = ((ComboBoxEdit)sender).EditValue;
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh  from PS_sbcs where   mc='" + ((ComboBoxEdit)sender).EditValue  + "' and xh is not null ");
            if (mclist.Count > 0)
                repositoryItemComboBox2.Properties.Items.AddRange(mclist);
            else
            {
               
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            dr["type"] = null;
        }
    
    }
}