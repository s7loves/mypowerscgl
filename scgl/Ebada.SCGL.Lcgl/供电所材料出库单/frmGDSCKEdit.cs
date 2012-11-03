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

        /// <summary>
        /// 设置库存
        /// </summary>
        public bool SetKC { get; set; }

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
            this.comCaiLiaoYT.DataBindings.Add("EditValue", rowData, "ly");
            this.comNum.DataBindings.Add("EditValue", rowData, "num");
            this.spCksl.DataBindings.Add("EditValue", rowData, "wpsl");
            this.spWpdj.DataBindings.Add("EditValue", rowData, "wpdj");
            this.comWpcj.DataBindings.Add("EditValue", rowData, "wpcj");
            this.dateindate.DataBindings.Add("EditValue", rowData, "indate");
            this.meRemark.DataBindings.Add("EditValue", rowData, "Remark");
            this.spKcsl.DataBindings.Add("EditValue", rowData, "kcsl");
        }

        #endregion

        #region 是否通过验证
        private void YZ()
        {
            if (rowData.yt.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("输入材料用途！");
            }
            else if (rowData.wpmc.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品！");
            }
            else if (rowData.wpgg.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品规格！");
            }
            else if (rowData.wpdw.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择出库物品单位！");
            }
            else if (Convert.ToInt32(rowData.cksl) <= 0)
            {
                MsgBox.ShowAskMessageBox("请输入出库数量！");
            }
        }
        #endregion

        #region 窗体加载事件、判断是设置库存还是添加物品
        private void frmCLRKEdit_Load(object sender, EventArgs e)
        {
            if (SetKC)
            {
                btnOK.Visible = false;
                simpleButton4.Visible = true;
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from PJ_gdscrk where OrgCode='" + rowData.OrgCode + "' and type='原始入库材料'");
                if (list != null && list.Count > 0)
                {
                    comWpmc.Properties.Items.AddRange(list);
                }
            }
            else
            {
                btnOK.Visible = true;
                simpleButton4.Visible = false;
            }
        }
        #endregion

        #region 添加并继续按钮
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            YZ();

            rowData.ID = rowData.CreateID();
            Client.ClientHelper.PlatformSqlMap.Create<PJ_gdscrk>(rowData);
            MsgBox.ShowTipMessageBox("出库成功！");

            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and (type='原始入库材料' or type='设置库存' or type='出库') order by id desc ");
            if (pnumli.Count == 0)
                rowData.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                rowData.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }

            rowData.ID = rowData.CreateID();
            rowData.type = "出库";
            comNum.EditValue = rowData.num;
            comWpmc.EditValue = null;
            spCksl.EditValue = "0";

            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = rowData.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = rowData.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }
        }
        #endregion

        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.Properties.Items.Clear();
            comWpgg.EditValue = null;
            if (comWpmc.EditValue != null && comWpmc.EditValue.ToString().Trim() != "")
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and type='原始入库材料'");
                if (list != null && list.Count > 0)
                {
                    comWpgg.Properties.Items.AddRange(list);
                }

                // 查厂家
                comWpcj.Properties.Items.Clear();
                list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpcj from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "'");
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
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpdw from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "' and type='原始入库材料'");
                if (list != null && list.Count > 0)
                {
                    comWpdw.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品单位更改
        int cksl = 0;   // 库存数量
        private void comWpdw_EditValueChanged(object sender, EventArgs e)
        {
            comWpcj.EditValue = null;
            if (comWpgg.EditValue != null && comWpgg.EditValue.ToString() != "" && comWpdw.EditValue != null && comWpdw.EditValue.ToString().Trim() != "")
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select top 1 kcsl from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "' and wpdw='" + comWpdw.EditValue + "' and OrgCode='" + rowData.OrgCode + "' and type='原始入库材料'");
                if (list != null && list.Count > 0)
                {
                    spKcsl.EditValue = list[0].ToString();
                    rowData.kcsl = list[0].ToString();
                    cksl = Convert.ToInt32(list[0]);
                }
                else
                {
                    cksl = 0;
                    MsgBox.ShowWarningMessageBox("不存在该物品！");
                    spKcsl.EditValue = "0";
                    rowData.kcsl = "0";
                    spCksl.Enabled = false;
                }
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
            YZ();
            rowData.ckdate = DateTime.Now;
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 出库数量更改
        private void spCksl_EditValueChanged(object sender, EventArgs e)
        {
            if (spCksl.EditValue != null)
            {
                spKcsl.EditValue = cksl - Convert.ToInt32(spCksl.EditValue.ToString());
            }
        }
        #endregion
    }
}