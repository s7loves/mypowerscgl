using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Netron.GraphLib.UI;
using System.IO;
using ShapesLib;
using Netron.GraphLib;
using ShapesLib.BasicShapes;
using Netron.GraphLib.Entitology;
using System.Drawing.Imaging;
using System.ComponentModel;
using DevExpress.XtraBars;
using Ebada.Client;
using System.Collections;
using Ebada.Client.Platform;
using System.Text;
using ScglShapesLib;
using Ebada.Scgl.Sbgl.变电;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis.变电站接线图
{
    public partial class UCXianLuTu : DevExpress.XtraEditors.XtraUserControl
    {
        #region Form
        private frmChooseBD_SBTZ chooseForm;
        private frmSBTZ frmsbtz;

        #endregion

        PropertyGrid propertyGrid;
        GraphShapesView shapesView;
        public event Netron.GraphLib.FileInfo OnSaved;
        public bool IsInternal = false;//是否是内嵌的图形编辑
        public UCXianLuTu()
        {
            InitializeComponent();
            CreateDockControl();
            graphControl1.ShowGrid = true;
            //graphControl1.Snap = true;
            this.graphControl1.OnDiagramSaved += new Netron.GraphLib.FileInfo(graphControl1_OnDiagramSaved);

            this.LoadShape(Application.StartupPath + "\\ScglShapesLib.dll");
            splitContainerControl1.Panel1.Controls.Add(shapesView);
            
            shapesView.Dock = DockStyle.Fill;
            splitContainerControl1.Panel2.Controls.Add(propertyGrid);
            propertyGrid.Dock = DockStyle.Fill;
            splitContainerControl1.SplitterPosition = 320;
        }

        public GraphControl GraphControl
        {
            get
            {
                return graphControl1;
            }
        }

        void graphControl1_OnDiagramSaved(object sender, System.IO.FileInfo info)
        {
            if (OnSaved != null)
            {
                OnSaved(this, info);
            }
        }

        private void CreateDockControl()
        {
            //属性
            this.propertyGrid = new PropertyGrid();

            this.shapesView = new GraphShapesView();
        }

        public void LoadShape(string filepath)
        {
            shapesView.AddLibrary(filepath);
            shapesView.ShowAs(Netron.GraphLib.ShapesView.Icons);
            graphControl1.AddLibrary(filepath);
        }
        private void graphControl1_OnShowProperties(object sender, object[] props)
        {
            this.propertyGrid.SelectedObjects = props;
            return;
            IList<BaseProperty> list = new List<BaseProperty>();
            foreach (object obj in props)
            {
                if (obj is PropertyBag)
                {
                    BaseProperty property = null;
                    if ((obj as PropertyBag).Owner is Shape)
                    {
                        string name = (obj as PropertyBag).Owner.GetType().Name;
                        switch (name)
                        {
                            case "TaskShape":
                                property = new TaskProperty((obj as PropertyBag).Owner as TaskShape);
                                break;
                            case "ImageShape":
                                property = new ImageShapeProperty((obj as PropertyBag).Owner as ImageShape);
                                break;
                            default:
                                property = new BaseProperty((obj as PropertyBag).Owner as Shape);
                                break;
                        }
                        list.Add(property);
                    }
                    else
                    {
                        this.propertyGrid.SelectedObject = obj;
                        return;
                    }

                }
            }
            BaseProperty[] array = new BaseProperty[list.Count];
            list.CopyTo(array, 0);
            this.propertyGrid.SelectedObjects = array;
        }

        /// <summary>
        /// 接线图名称
        /// </summary>
        [DisplayName("接线图名称")]
        public string Caption
        {
            set
            {
                groupControl1.Text = value;
            }
        }

        #region 控件大小改变自动调整左侧分页布局
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //splitContainerControl1.SplitterPosition = dockPanel1.Height / 2;
        }
        #endregion

        #region 是否显示编辑栏
        private bool showBar = false;
        [DisplayName("是否显示编辑栏")]
        public bool ShowBar
        {
            get
            {
                return showBar;
            }
            set
            {
                showBar = value;
                this.bar1.Visible = showBar;
                this.bar2.Visible = showBar;
                this.bar3.Visible = showBar;
                this.dockPanel1.Enabled = showBar;
            }
        }
        #endregion

        #region 某供电站的线路图数据
        private TX_bdzjxt rowDate;
        public TX_bdzjxt RowDate
        {
            get
            {
                rowDate.LastTime = DateTime.Now;
                rowDate.LastUserName = MainHelper.User.UserName;
                rowDate.Nml = graphControl1.GetNML();
                return rowDate;
            }
            set
            {
                if (value == null)
                    return;
                rowDate = value;
                barInfo.Caption = "信息：上次修改时间：" + rowDate.LastTime + "   修改人：" + rowDate.LastUserName;
                if (rowDate.Nml.Trim() != "")
                {
                    this.OpenStr(rowDate.Nml);
                }
                else
                {
                    graphControl1.NewDiagram(true);
                }

                graphControl1.Focus();
            }
        }

        private string orgCode;
        [DisplayName("部门Code")]
        public string OrgCode
        {
            get
            {
                return orgCode;
            }
            set
            {
                if (value == null)
                    return;
                orgCode = value;
                Hashtable result = (Hashtable)ClientHelper.PlatformSqlMap.GetObject("Select", "Select ID,OrgCode,Nml,LastTime,LastUserName from TX_bdzjxt where OrgCode='" + orgCode + "'");
                TX_bdzjxt tx = new TX_bdzjxt();
                if (result == null)
                {
                    tx.OrgCode = this.orgCode;
                    tx.ID = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                    tx.LastTime = DateTime.Now;
                    tx.LastUserName = MainHelper.User.UserName;
                    tx.Nml = "";
                }
                else
                {
                    tx.OrgCode = this.orgCode;
                    tx.ID = result["ID"].ToString();
                    tx.LastTime = Convert.ToDateTime(result["LastTime"]);
                    tx.LastUserName = result["LastUserName"].ToString();
                    tx.Nml = result["Nml"].ToString();
                }
                this.RowDate = tx;
                graphControl1.Refresh();
            }
        }
        #endregion

        #region 打开（文本）
        /// <summary>
        /// 打开（文本）
        /// </summary>
        /// <param name="nml"></param>
        public void OpenStr(string nml)
        {
            this.graphControl1.OpenNMLFragment(nml);
        }
        #endregion

        #region 得到设计的文本内容
        /// <summary>
        /// 设计的文本内容
        /// </summary>
        /// <returns></returns>
        public string GetNml()
        {
            return this.graphControl1.GetNML();
        }
        #endregion

        #region barmanager菜单栏各个按钮单击事件
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mNew":
                case "tNew":
                    NewFile();
                    break;
                case "mOpen":
                case "tOpen":
                    OpenFile();
                    break;
                case "mSave":
                case "tSave":
                    Save();
                    break;
                case "mSaveAs":
                case "tSaveAs":
                    SaveAs();
                    break;
                case "mSaveAsImg":
                    SaveAsImg();
                    break;
                case "mSaveToClipboard":
                    graphControl1.CopyAsImage();
                    break;
                case "mCopy":
                case "tCopy":
                    graphControl1.Copy();
                    break;
                case "mCut":
                case "tCut":
                    graphControl1.Cut();
                    break;
                case "mPast":
                case "tPast":
                    graphControl1.Paste();
                    break;
                case "mDelete":
                case "tDelete":
                    graphControl1.Delete();
                    break;
                case "mSelectAll":
                    graphControl1.SelectAll(true);
                    break;
                case "mCancelSelectAll":
                    graphControl1.Deselect();
                    break;
                case "mToBig":
                    graphControl1.Zoom *= 1.1f;
                    break;
                case "mToSmall":
                    graphControl1.Zoom /= 1.1f;
                    break;
                case "mShowGrid":
                    graphControl1.ShowGrid = !graphControl1.ShowGrid;
                    break;


                default:
                    break;
            }
        }

        #region 新建
        /// <summary>
        /// 新建
        /// </summary>
        private void NewFile()
        {
            if (MsgBox.ShowAskMessageBox("新建操作将清空现有的图形，是否继续？") == DialogResult.OK)
            {
                graphControl1.NewDiagram(true);
                if (!IsInternal)
                    graphControl1.FileName = string.Empty;
            }
        }
        #endregion

        #region 打开
        /// <summary>
        /// 打开
        /// </summary>
        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename == "" || filename == null)
                    MessageBox.Show("非法文件名！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        string oldFile = graphControl1.FileName;
                        graphControl1.NewDiagram(true);
                        graphControl1.OpenNML(filename);
                        if (IsInternal)
                            graphControl1.FileName = oldFile;
                        else
                            graphControl1.FileName = filename;
                    }
                    catch
                    {
                        MsgBox.ShowWarningMessageBox("文件解析错误，文件格式非法！");
                    }
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" if exists(select 1 from TX_bdzjxt where orgcode='" + orgCode + "') ");
            sql.Append(" begin ");
            #region 修改语句
            sql.Append("update TX_bdzjxt set Nml='" + RowDate.Nml + "',LastTime='" + RowDate.LastTime + "',LastUserName='" + RowDate.LastUserName + "' where OrgCode='" + RowDate.OrgCode + "'");
            #endregion
            sql.Append(" end ");
            sql.Append(" else ");
            #region 添加语句
            sql.Append(string.Format(" insert into TX_bdzjxt(ID,OrgCode,Nml,LastTime,LastUserName) values('{0}','{1}','{2}','{3}','{4}') ", RowDate.ID, RowDate.OrgCode, RowDate.Nml, RowDate.LastTime, RowDate.LastUserName));
            #endregion

            ClientHelper.PlatformSqlMap.Update("Update", sql.ToString());

            string filename = graphControl1.FileName;
            if (File.Exists(filename))
            {
                graphControl1.SaveNMLAs(filename);
            }
        }
        #endregion

        #region 另存为
        /// <summary>
        /// 另存为
        /// </summary>
        private void SaveAs()
        {
            saveFileDialog1.Filter = "NML files (*.nml)|*.nml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                graphControl1.SaveNMLAs(filename);
                MsgBox.ShowTipMessageBox("图形被保存到 '" + filename + "'");
            }
        }
        #endregion

        #region 另存为图片
        /// <summary>
        /// 另存为图片
        /// </summary>
        private void SaveAsImg()
        {
            saveFileDialog1.Filter = "jpg files (*.jpg)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                graphControl1.SaveImage(filename, true, ImageFormat.Jpeg);
                MsgBox.ShowTipMessageBox("图形被保存到 '" + filename + "'");
            }
        }
        #endregion

        #endregion

        #region 右键菜单
        private void graphControl1_OnShapeMenuItemClick(object sender, Shape shape)
        {
            MenuItem menu = sender as MenuItem;
            switch (menu.Text)
            {
                case "设备参数":
                    ShowData(shape);
                    break;
                case "重置设备":
                    ResetData(shape);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 显示设备属性
        /// <summary>
        /// 显示设备属性
        /// </summary>
        /// <param name="shape"></param>
        private void ShowData(Shape shape)
        {
            if (shape is BaseShape)
            {
                BaseShape bs = shape as BaseShape;

                if (string.IsNullOrEmpty(bs.DeviceID))
                {
                    if (chooseForm == null || chooseForm.IsDisposed)
                    {
                        chooseForm = new frmChooseBD_SBTZ();
                    }
                    chooseForm.OrgCode = orgCode;
                    chooseForm.MC = bs.DeviceType;
                    if (chooseForm.ShowDialog() == DialogResult.OK)
                    {
                        // 选择的设备sb_id
                        string sb_id = chooseForm.sb_id;

                        if (frmsbtz == null || frmsbtz.IsDisposed)
                        {
                            frmsbtz = new frmSBTZ();
                        }

                        BD_SBTZ rowData = ClientHelper.PlatformSqlMap.GetOne<BD_SBTZ>(" where sb_id='" + sb_id + "'");
                        if (rowData != null)
                        {
                            frmsbtz.RowData = rowData;
                            if (frmsbtz.ShowDialog() == DialogResult.OK)
                            {
                                rowData = frmsbtz.RowData as BD_SBTZ;
                                bs.DeviceID = rowData.sb_id;
                            }
                        }
                    }
                }
                else if (bs.DeviceID != null)
                {
                    if (frmsbtz == null || frmsbtz.IsDisposed) {
                        frmsbtz = new frmSBTZ();
                    }
                    BD_SBTZ rowData = ClientHelper.PlatformSqlMap.GetOne<BD_SBTZ>(" where sb_id='" + bs.DeviceID + "'");
                    if (rowData != null)
                    {
                        frmsbtz.RowData = rowData;
                        if (frmsbtz.ShowDialog() == DialogResult.OK)
                        {
                            rowData = frmsbtz.RowData as BD_SBTZ;

                            PS_Image image = frmsbtz.GetPS_Image();
                            if (frmsbtz.GetImage() != null) {
                                if (rowData.c3 == "" || image == null) {
                                    image = new PS_Image();
                                    image.ImageName = "变电设备照片";
                                    image.ImageType = "bd";
                                    image.ImageData = (byte[])frmsbtz.GetImage();
                                    rowData.c3 = image.ImageID;
                                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, rowData, null);
                                } else {

                                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, new object[] { rowData, image }, null);
                                }

                            } else {
                                Client.ClientHelper.PlatformSqlMap.Update<BD_SBTZ>(rowData);

                            }
                        }
                    }
                }
            }
        } 
        #endregion

        #region 重置设备
        /// <summary>
        /// 重置设备
        /// </summary>
        /// <param name="shape"></param>
        private void ResetData(Shape shape)
        {
            if (shape is BaseShape)
            {
                BaseShape bs = shape as BaseShape;
                bs.DeviceID = null;
            }
        }
        #endregion

        private void btClose_ItemClick(object sender, ItemClickEventArgs e) {
            FindForm().Close();
        }
    }

    #region 线路接线图 - 实体类
    /// <summary>
    /// 线路接线图(表)
    /// </summary>
    public class TX_bdzjxt
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 变电站ID
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 接线图
        /// </summary>
        public string Nml { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastUserName { get; set; }
    }
    #endregion
}