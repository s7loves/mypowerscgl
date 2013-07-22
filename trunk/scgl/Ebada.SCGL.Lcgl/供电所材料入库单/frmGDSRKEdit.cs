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
using DevExpress.XtraRichEdit.API.Word;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmGDSRKEdit : FormBase, IPopupFormEdit
    {

        /// <summary>
        /// 设置库存
        /// </summary>
        public bool SetKC { get; set; }

        ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
        #region
        SortableSearchableBindingList<PJ_gdscrk> m_CityDic = new SortableSearchableBindingList<PJ_gdscrk>();
        private bool isWorkflowCall = true;
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
        public frmGDSRKEdit()
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
                    InitComboBoxData();
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
            this.comCaiLiaoLY.DataBindings.Add("EditValue", rowData, "ly");
            this.comNum.DataBindings.Add("EditValue", rowData, "num");
            this.spWpsl.DataBindings.Add("EditValue", rowData, "wpsl");
            this.spWpdj.DataBindings.Add("EditValue", rowData, "wpdj");
            this.comWpcj.DataBindings.Add("EditValue", rowData, "wpcj");
            this.dateindate.DataBindings.Add("EditValue", rowData, "indate");
            this.meRemark.DataBindings.Add("EditValue", rowData, "Remark");
            this.spKcsl.DataBindings.Add("EditValue", rowData, "kcsl");
        }

        //填充下拉列表数据
        private void InitComboBoxData()
        {
            //new PS_sbcs().xh
            comWpmc.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select mc from PS_sbcs where len(bh)=5");
            if (strlist.Count > 0) comWpmc.Properties.Items.AddRange(strlist);

            comWpdw.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select nr from pj_dyk where  dx='公用属性' and sx like '%单位%' and len(nr)>0");
            if (strlist.Count > 0)
            {
                comWpdw.Properties.Items.AddRange(strlist);
            }
            else
            {
                comWpdw.Properties.Items.Add("根");
                comWpdw.Properties.Items.Add("片");
                comWpdw.Properties.Items.Add("个");
                comWpdw.Properties.Items.Add("付");

                comWpdw.Properties.Items.Add("套");
                comWpdw.Properties.Items.Add("块");
                comWpdw.Properties.Items.Add("Kg");
                comWpdw.Properties.Items.Add("米");

                comWpdw.Properties.Items.Add("台");
                comWpdw.Properties.Items.Add("卷");
                comWpdw.Properties.Items.Add("捆");
                comWpdw.Properties.Items.Add("组");
            }
        }
        #endregion

        #region 是否通过验证
        private bool YZ()
        {
            if (rowData.ly.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请选择材料来源！");
                return false;
            }
            else if (rowData.wpmc.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请输入物品名称！");
                return false;
            }
            else if (rowData.wpgg.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请输入物品规格！");
                return false;
            }
            else if (rowData.wpdw.Trim() == "")
            {
                MsgBox.ShowTipMessageBox("请输入物品单位！");
                return false;
            }
            else if (Convert.ToDecimal(rowData.wpsl) <= 0)
            {
                MsgBox.ShowTipMessageBox("请输入入库数量！");
                return false;
            }
            return true;
        }
        #endregion

        #region 窗体加载填充物品
        private void frmCLRKEdit_Load(object sender, EventArgs e)
        {
            if (comWpmc.Properties.Items.Count <= 0)
            {
                //IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from PJ_gdscrk");
                //if (list != null && list.Count > 0)
                //{
                //    for (int i = 0; i < list.Count; i++)
                //    {
                //        if (!comWpmc.Properties.Items.Contains(list[i]))
                //        {
                //            comWpmc.Properties.Items.Add(list[i]);
                //        }
                //    }
                //}
                //IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  dx='非生产物资入库单' and sx like '%{0}%' and nr!=''", "材料名称"));
                //comWpmc.Properties.Items.AddRange(list);
            }
            spKcsl.BackColor = Color.White;
        }
        #endregion

        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            //comWpgg.Properties.Items.Clear();
            //if (comWpmc.EditValue != null && comWpmc.EditValue.ToString().Trim() != "")
            //{
            //    IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "'");
            //    if (list != null && list.Count > 0)
            //    {
            //        comWpgg.Properties.Items.AddRange(list);
            //    }

            //    // 查厂家
            //    comWpcj.Properties.Items.Clear();
            //    list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpcj from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "'");
            //    if (list != null && list.Count > 0)
            //    {
            //        comWpcj.Properties.Items.AddRange(list);
            //    }
            //}

            comWpgg.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct bh from PS_sbcs where mc='" + comWpmc.Text + "'");
            if (mclist != null && mclist.Count > 0)
            {
                mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh from PS_sbcs where mc='" + comWpmc.Text + "' and len(xh)>0;");
                if (mclist.Count > 0) comWpgg.Properties.Items.AddRange(mclist);
            }

            GetKcsl();
        }
        #endregion

        #region 物品规格更改
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            //comWpdw.Properties.Items.Clear();
            //if (comWpgg.EditValue != null && comWpgg.EditValue.ToString().Trim() != "")
            //{
            //    IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpdw from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "'");
            //    if (list != null && list.Count > 0)
            //    {
            //        comWpdw.Properties.Items.AddRange(list);
            //    }
            //}

            comWpcj.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpcj  from PJ_clcrkd where type = '撤旧材料入库单' or type = '撤旧材料入库单原始库存' and wpgg='" + comWpgg.EditValue + "' and wpmc='" + comWpmc.EditValue + "'");
            comWpcj.Properties.Items.AddRange(mclist);
            GetKcsl();
        }
        #endregion

        #region 物品单位更改
        int cksl = 0;   // 库存数量
        private void comWpdw_EditValueChanged(object sender, EventArgs e)
        {
            GetKcsl();
        }
        #endregion

        #region 查找物品剩余库存
        private void GetKcsl()
        {
            string kcls = "0";

            if (comWpmc.EditValue != null && comWpmc.EditValue.ToString().Trim() != "")
            {
                if (comWpgg.EditValue != null && comWpgg.EditValue.ToString().Trim() != "")
                {
                    if (comWpdw.EditValue != null && comWpdw.EditValue.ToString().Trim() != "")
                    {
                        IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select top 1 kcsl from PJ_gdscrk where wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "' and wpdw='" + comWpdw.EditValue + "' and OrgCode='" + rowData.OrgCode + "' order by id desc");
                        if (list != null && list.Count > 0)
                        {
                            kcls = list[0].ToString();
                        }
                    }
                }
            }
            spKcsl.EditValue = kcls;
            rowData.kcsl = kcls;
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
            //rowData.indate = now;
            rowData.ckdate = now;
            rowData.type = "入库";
            rowData.wpsl = spWpsl.EditValue.ToString();

            if (!comWpmc.Properties.Items.Contains(rowData.wpmc))
            {
                comWpmc.Properties.Items.Add(rowData.wpmc);
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
            rowData.indate = now;
            rowData.ID = rowData.CreateID();
            rowData.type = "入库";
            Client.ClientHelper.PlatformSqlMap.Create<PJ_gdscrk>(rowData);
            MsgBox.ShowTipMessageBox("添加成功!");

            /// 导出
            etdjh.ExportOne(rowData);

            if (!comWpmc.Properties.Items.Contains(rowData.wpmc))
            {
                comWpmc.Properties.Items.Add(rowData.wpmc);
            }

            // 重新初始化数据
            rowData.wpmc = "";
            rowData.wpgg = "";
            rowData.wpsl = "";
            rowData.wpcj = "";
            rowData.wpdj = "";

            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' order by ID desc");
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
            spWpsl.EditValue = "0";
            spKcsl.EditValue = "0";

            // 创建工作流
            //if (isWorkflowCall)
            //{
            //    isWorkflowCall = false;
            //    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            //    mrwt.ModleRecordID = rowData.ID;
            //    mrwt.RecordID = currRecord.ID;
            //    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            //    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
            //    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            //    mrwt.ModleTableName = rowData.GetType().ToString();
            //    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
            //    mrwt.CreatTime = DateTime.Now;
            //    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            //}
        }
        #endregion
    }
}