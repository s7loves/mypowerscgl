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
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraTab;
namespace Ebada.Scgl.Sbgl
{
    public partial class frmsdgtEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sd_gt> m_CityDic = new SortableSearchableBindingList<sd_gt>();
        private Boolean multipleAdd = false;
        XtraTabPage tqTab, kgTab,byqTab;
        //UCPS_TQ ucps_tq;
        //UCPS_KG ucps_kg;
        //UCPS_TQBYQ ucps_tqbyq;
        public Boolean MultipleAdd {
            get { return multipleAdd; }
            set { multipleAdd = value;
            labelControl5.Visible = value;
            spinEdit8.Visible = value;
            comboBoxEdit1.Enabled = !value;
            comboBoxEdit2.Enabled = !value;
            }
        }
        public int MultipleNum {
            get{
                return Convert.ToInt32(spinEdit8.EditValue);
            }
        }
        public frmsdgtEdit() {
            InitializeComponent();
            xtraTabControl1.TabPages.Remove(xtraTabPage2);
            xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
        }

        void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e) {
            //if (e.Page == tqTab) {
            //    if (ucps_tq == null) {
            //        ucps_tq = new UCPS_TQ();
            //        ucps_tq.Dock = DockStyle.Fill;

            //        ucps_tq.ParentObj = rowData;
            //        ucps_tq.HideList();
            //        ucps_tq.Parent = tqTab;
            //    }
            //} else if (e.Page == kgTab) {
            //    if (ucps_kg == null) {
            //        ucps_kg = new UCPS_KG();
            //        ucps_kg.Dock = DockStyle.Fill;

            //        ucps_kg.ParentObj = rowData;
            //        ucps_kg.HideList();
            //        ucps_kg.Parent = kgTab;
            //    }
            //} else if (e.Page == byqTab) {
            //    if (ucps_tqbyq == null) {
            //        ucps_tqbyq = new UCPS_TQBYQ();
            //        ucps_tqbyq.Dock = DockStyle.Fill;

            //        ucps_tqbyq.ParentGT = rowData;
            //        ucps_tqbyq.HideList();
            //        ucps_tqbyq.Parent = byqTab;
            //    }
            //}
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "gtCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "c1");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gtType");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "gtModle");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "gtHeight");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "gtLon");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "gtLat");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "gtElev");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "gtMs");
            this.spinEdit6.DataBindings.Add("EditValue", rowData, "gtZj");
            this.spinEdit7.DataBindings.Add("EditValue", rowData, "gtSpan");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gtJg");
 

        }
        #region IPopupFormEdit Members
        private sd_gt rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sd_gt;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sd_gt>(value as sd_gt, rowData);
                }
                setImage();
            }
        }
        public string tempID = null;
        private PS_Image temp35Image = null;
        private const string temp35gtid = "1111111112";
        private void gettemp() {
            if (temp35Image != null) return;
            sd_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_gt>(temp35gtid);
            if (gt != null)
                temp35Image = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_Image>(gt.ImageID);
            if (temp35Image != null) tempID = temp35Image.ImageID;
        }
        private void setImage() {
            pictureEdit1.EditValue = null;
            imageData = null;
            image = null;
            tempID = null;
            gettemp();
            if (string.IsNullOrEmpty(rowData.ImageID)) {
                string gtid="0000000002";//
                sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linecode='" + rowData.LineCode + "'");
                if (xl == null) return;
                if (xl.LineVol == "35") {
                    if (temp35Image != null) {
                        pictureEdit1.EditValue = temp35Image.ImageData;
                    }
                    imageData = null;
                    return;
                }
                    gtid = temp35gtid;
               //PS_gt gt=  Client.ClientHelper.PlatformSqlMap.GetOne<PS_gt>("where linecode='"+rowData.LineCode+"' and gtModle='直线杆' and len(imageid)>6 order by gtcode");
                sd_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_gt>(gtid);
                if(gt!=null)
                    image = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_Image>(gt.ImageID);
                if (image != null) {
                    //tempID = image.ImageID;
                    pictureEdit1.EditValue = image.ImageData;
                    image = null;//模板杆塔时需清空，要不会更新模板
                }
            } else {
                image = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_Image>(rowData.ImageID);
                
                if (image != null)
                    pictureEdit1.EditValue = image.ImageData;
                if (rowData.ImageID == tempID && rowData.gtID != "1111111112") {
                    rowData.ImageID = "";
                    image = null;
                }
            }
            
            
            imageData = null;
        }
        PS_Image image = null;
        public PS_Image GetPS_Image() {
            if (image != null && imageData!=null)
                image.ImageData =(byte[]) imageData;
            return image;
        }

        bool showTab2 = false;

        public bool ShowTab2 {
            get { return showTab2; }
            set {
                showTab2 = value;
            }
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Application.DoEvents();
            if (showTab2) {
                UCsd_GTSB gtsb = new UCsd_GTSB();
                gtsb.ParentObj = rowData;
                gtsb.HideList();
                gtsb.Dock = DockStyle.Fill;
                gtsb.Parent = xtraTabPage2;
                xtraTabControl1.TabPages.Add(xtraTabPage2);
                //if (tqTab == null) {
                //    tqTab = new XtraTabPage();
                //    tqTab.Text = "台区";
                //    xtraTabControl1.TabPages.Add(tqTab);
                //    kgTab = new XtraTabPage();
                //    kgTab.Text = "开关";
                //    xtraTabControl1.TabPages.Add(kgTab);
                //    byqTab = new XtraTabPage();
                //    byqTab.Text = "变压器";
                //    xtraTabControl1.TabPages.Add(byqTab);
                //}
            }
        }
        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByGttype(comboBoxEdit4);
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select mc from sd_sbcs where bh like '01%' and len(bh)=5");

            comboBoxEdit3.Properties.Items.AddRange(list);
            //pdsbModelHelper.FillCBoxByGt(comboBoxEdit3);

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

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("杆塔编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmgtEdit_Load(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e) {
            imageData = pictureEdit1.EditValue;
        }
        object imageData;
        public object GetImage() {

            return imageData;
        }
        private void Rotate90() {
            byte[] buff = (byte[])pictureEdit1.EditValue;
            MemoryStream ms = new MemoryStream(buff);
            Bitmap bt = new Bitmap(ms);
            KiRotate90(bt);
            if (bt == null) return;
            string file = Path.GetTempFileName();
            bt.Save(file, ImageFormat.Jpeg);
            if (File.Exists(file)) {
                pictureEdit1.EditValue = File.ReadAllBytes(file);
                File.Delete(file);
            }
            
            ms.Close();
        }
        //旋转
        public static Bitmap KiRotate90(Bitmap img)
        {
            try
            {                
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Rotate90();
        } 
    }
}