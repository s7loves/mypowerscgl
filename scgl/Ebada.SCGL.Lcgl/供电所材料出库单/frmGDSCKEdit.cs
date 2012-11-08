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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmGDSCKEdit : FormBase, IPopupFormEdit
    {
        ExportGDSCKEdit etdjh = new ExportGDSCKEdit();

        public bool isSet = false;
        #region
        SortableSearchableBindingList<PJ_gdscrk> m_CityDic = new SortableSearchableBindingList<PJ_gdscrk>();
        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_clrkysd,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }

        public DataTable RecordWorkFlowData
        {
            get
            {
                return WorkFlowData;
            }
            set
            {
                WorkFlowData = value;
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }
        public frmGDSCKEdit()
        {
            InitializeComponent();
        }
        #endregion

        #region RowData
        private PJ_gdscrk rowData = null;

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
                    this.rowData = value as PJ_gdscrk;
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_gdscrk>(value as PJ_gdscrk, rowData);
                }

            }
        }
        void dataBind()
        {
            this.comWpmc.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comWpgg.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comWpdw.DataBindings.Add("EditValue", rowData, "wpdw");
            this.comCaiLiaoYT.DataBindings.Add("EditValue", rowData, "yt");
            this.comNum.DataBindings.Add("EditValue", rowData, "num");
            this.spCksl.DataBindings.Add("EditValue", rowData, "cksl");
            this.spWpdj.DataBindings.Add("EditValue", rowData, "wpdj");
            this.comWpcj.DataBindings.Add("EditValue", rowData, "wpcj");
            this.dateindate.DataBindings.Add("EditValue", rowData, "ckdate");
            this.meRemark.DataBindings.Add("EditValue", rowData, "Remark");
            this.spKcsl.DataBindings.Add("EditValue", rowData, "kcsl");
        }

        #endregion

        #region 是否通过验证
        private bool YZ()
        {
            if (rowData.yt.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("输入材料用途！");
                return false;
            }
            else if (rowData.wpmc.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品！");
                return false;
            }
            else if (rowData.wpgg.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品规格！");
                return false;
            }
            else if (rowData.wpdw.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品单位！");
                return false;
            }
            else if (Convert.ToDecimal(rowData.cksl) <= 0)
            {
                MsgBox.ShowAskMessageBox("请输入出库数量！");
                return false;
            }
            return true;
        }
        #endregion

        #region 窗体加载事件、判断是设置库存还是添加物品
        private void frmCLRKEdit_Load(object sender, EventArgs e)
        {
            comWpmc.Properties.Items.Clear();
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from pj_gdscrk as a where id = (select max(ID) from pj_gdscrk as b where b.wpmc=a.wpmc and b.wpgg=a.wpgg and b.wpdw=a.wpdw and b.OrgCode=a.OrgCode and type='入库') and OrgCode='" + rowData.OrgCode + "' and type='入库' and kcsl !='0'");
            comWpmc.Properties.Items.AddRange(list);
        }
        #endregion


        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.Properties.Items.Clear();
            comWpgg.EditValue = null;
            if (comWpmc.EditValue != null && comWpmc.EditValue.ToString().Trim() != "")
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and OrgCode='" + rowData.OrgCode + "'");
                if (list != null && list.Count > 0)
                {
                    comWpgg.Properties.Items.AddRange(list);
                }

                // 查厂家
                comWpcj.Properties.Items.Clear();
                list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpcj from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "'and OrgCode='" + rowData.OrgCode + "'");
                if (list != null && list.Count > 0)
                {
                    comWpcj.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品规格更改
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.Properties.Items.Clear();
            comWpdw.EditValue = null;
            if (comWpgg.EditValue != null && comWpgg.EditValue.ToString().Trim() != "")
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpdw from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "' and OrgCode='" + rowData.OrgCode + "'");
                if (list != null && list.Count > 0)
                {
                    comWpdw.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品单位更改
        decimal kcsl = 0;   // 库存数量
        private void comWpdw_EditValueChanged(object sender, EventArgs e)
        {
            kcsl = 0;
            if (comWpgg.EditValue != null && comWpgg.EditValue.ToString() != "" && comWpdw.EditValue != null && comWpdw.EditValue.ToString().Trim() != "")
            {
                string sql = string.Format("select cast(isnull(sum(cast(wpsl as float)),0) as varchar) from PJ_gdscrk where type='入库' and OrgCode='{0}' and wpmc='{1}' and wpgg='{2}' and wpdw='{3}'", rowData.OrgCode, comWpmc.EditValue, comWpgg.EditValue, comWpdw.EditValue);
                var rkcount = ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", sql);

                sql = string.Format("select cast(isnull(sum(cast(cksl as float)),0) as varchar) from PJ_gdscrk where type='出库' and OrgCode='{0}' and wpmc='{1}' and wpgg='{2}' and wpdw='{3}'", rowData.OrgCode, comWpmc.EditValue, comWpgg.EditValue, comWpdw.EditValue);
                var ckcount = ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", sql);

                kcsl = Convert.ToDecimal(rkcount) - Convert.ToDecimal(ckcount);

                rowData.kcsl = kcsl.ToString();
                spKcsl.EditValue = kcsl;
            }
        }
        #endregion

        #region 备注上的按钮事件
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("供电所材料入库单", "备注", meRemark);
        }
        #endregion

        #region 确定按钮
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!YZ()) return;
            rowData.ID = rowData.CreateID();
            DateTime now = DateTime.Now;
            rowData.lasttime = now;
            rowData.ckdate = now;
            rowData.type = "出库";
            rowData.wpsl = "";
            if (rowData.kcsl == "0")
            {
                comWpmc.Properties.Items.Remove(rowData.wpmc);
            }
            if (isSet)
            {
                Client.ClientHelper.PlatformSqlMap.Create<PJ_gdscrk>(rowData);
            }
            this.DialogResult = DialogResult.OK;
             etdjh.ExportOne(rowData);
        }
        #endregion

        #region 添加并继续按钮
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (!YZ()) return;

            DateTime now = DateTime.Now;
            rowData.lasttime = now;
            rowData.ckdate = now;
            rowData.ID = rowData.CreateID();
            rowData.wpsl = "";
            rowData.type = "出库";
            Client.ClientHelper.PlatformSqlMap.Create<PJ_gdscrk>(rowData);
            MsgBox.ShowTipMessageBox("出库成功！");

            /// 导出
            etdjh.ExportOne(rowData);

            if (!comWpmc.Properties.Items.Contains(rowData.wpmc))
            {
                comWpmc.Properties.Items.Add(rowData.wpmc);
            }

            // 重新初始化数据
            rowData.wpmc = "";
            rowData.wpgg = "";
            rowData.cksl = "";
            rowData.wpcj = "";
            rowData.wpdj = "";
            rowData.cksl = "0";
            rowData.kcsl = "0";

            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' order by id desc");
            if (pnumli.Count == 0)
                rowData.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                rowData.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }
            comNum.EditValue = rowData.num;
            comWpmc.EditValue = null;
            comWpgg.EditValue = null;
            comWpdw.EditValue = null;
            comWpcj.EditValue = null;
            meRemark.EditValue = null;
            spCksl.EditValue = "0";
            spKcsl.EditValue = "0";
        }
        #endregion

        #region 出库数量更改
        private void spCksl_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(spCksl.EditValue.ToString()) < 0)
            {
                spCksl.EditValue = "0";
                rowData.cksl = "0";
                return;
            }
            comWpdw_EditValueChanged(sender, e);
            decimal sl = kcsl - Convert.ToDecimal(spCksl.EditValue.ToString());
            if (sl <= 0)
            {
                sl = 0;
                spCksl.EditValue = kcsl;
                rowData.cksl = kcsl.ToString();
            }

            rowData.kcsl = sl.ToString();
            spKcsl.EditValue = sl;
        }
        #endregion
    }
}