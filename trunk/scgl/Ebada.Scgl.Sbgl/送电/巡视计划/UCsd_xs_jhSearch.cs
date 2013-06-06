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

namespace Ebada.Scgl.Sbgl
{
    public partial class UCsd_xs_jhSearch : DevExpress.XtraEditors.XtraUserControl
    {
        public UCsd_xs_jhSearch()
        {
            InitializeComponent();
            uCsdxs_jh1.isSearch = true;
            uCsdxs_jhnr1.issearch = true;
            uCsd_xsxm1.issearch = true;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitLkue();
            

        }

        private void InitLkue()
        {
            IList<mOrg> listorg = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where 1>0 order by OrgCode,OrgType");
            List<DicType> orgDicTypeList = new List<DicType>();
            foreach (mOrg org in listorg)
            {
                orgDicTypeList.Add(new DicType(org.OrgCode, org.OrgName));
            }
            SetCheckComboBoxData(this.checkcomOrg, "Value", "Key", "请选择", "单位", orgDicTypeList);
            List<DicType> wcbjList = new List<DicType>();
            wcbjList.Add(new DicType("完成", "完成"));
            wcbjList.Add(new DicType("未完成", "未完成"));
            SetCheckComboBoxData(this.lkuewcbj, "Value", "Key", "请选择", "单位", wcbjList);
        }

        private void Init()
        {
            uCsdxs_jh1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sd_xsjh>(uCsdxs_jh1_FocusedRowChanged);
            
           
        }
        void uCsdxs_jh1_FocusedRowChanged(object sender, Ebada.Scgl.Model.sd_xsjh obj)
        {
            if (obj == null)
                return;
            uCsdxs_jhnr1.ParentObj = obj;
            uCsd_xsxm1.ParentObj = obj;
        }

        #region 绑定数据
        public void SetCheckComboBoxData(DevExpress.XtraEditors.CheckedComboBoxEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Items.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(valueMember, "ID"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(displayMember, cnStr)});
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
        public static void SetData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
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

        #endregion

        private void checkcomOrg_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(checkcomOrg.EditValue.ToString())) 
                return;
            string sql = "where OrgCode in ('" + this.checkcomOrg.EditValue.ToString().Replace(" ", "").Replace(",", "','") + "')";

            IList<sd_xl> xlList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_xl>(sql);
            List<DicType> xlDictypeList = new List<DicType>();
            foreach (sd_xl xl in xlList)
            {
                xlDictypeList.Add(new DicType(xl.LineCode, xl.LineName));
            }
            SetCheckComboBoxData(this.checkcomLine, "Value", "Key", "请选择", "线路", xlDictypeList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "where 1>0";
            if (!string.IsNullOrEmpty(this.checkcomOrg.EditValue.ToString()))
            {
                 sql += " and OrgCode in ('" + this.checkcomOrg.EditValue.ToString().Replace(" ", "").Replace(",", "','") + "')";
            }
            if (!string.IsNullOrEmpty(this.checkcomLine.EditValue.ToString()))
            {
                sql += " and LineID in ('" + this.checkcomLine.EditValue.ToString().Replace(" ", "").Replace(",", "','") + "')";

            }
            if (!string.IsNullOrEmpty(this.lkuewcbj.EditValue.ToString()))
            {
                sql += " and wcbj in ('" + this.lkuewcbj.EditValue.ToString().Replace(" ","").Replace(",","','") + "')";
            }
            uCsdxs_jh1.RefreshData(sql);
        }

        private void btPlayback_Click(object sender, EventArgs e) {
            uCsdxs_jh1.Playback();
        }

    }
}
