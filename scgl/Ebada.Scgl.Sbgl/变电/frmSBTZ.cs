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
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.Core;
using Ebada.UI.Base;

namespace Ebada.Scgl.Sbgl.变电
{
    public partial class frmSBTZ : FormBase, IPopupFormEdit
    {
        private bool isfirst = false;
        
        DevExpress.XtraEditors.PictureEdit pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
        public frmSBTZ()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private BD_SBTZ rowData = null;
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
                    this.rowData = value as BD_SBTZ;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<BD_SBTZ>(value as BD_SBTZ, rowData);
                }
                //setImage();
            }
        }

        

        #endregion

        private void dataBind()
        {
            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "mc");
        }
        //起始位置11、11 |128、8;size 337:21|
        //垂直增加33  
        private void frmSBTZ_Load(object sender, EventArgs e)
        {
            //lable一个字符站12个宽度
            this.xtraTabControl1.TabPages.Clear();
            this.splitContainerControl1.Panel2.Controls.Clear();
            //lable起始位置
            int startlblw = 11;
            int startlblh = 11;
            //textbox起始位置
            int starttextw = 180;
            int starttexth = 8;
            int addh = 33;
            int pageNumber = 1;
            IList<BD_SBTZ_SX> sbsxList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<BD_SBTZ_SX>("where zldm='" + rowData.sbtype + "' order by convert(int,norder)");
            int[] widthArr = new int[sbsxList.Count / 11 + 1];
            for (int i = 0; i < widthArr.Length; i++)
            {
                widthArr[i] = GetMaxLblWidth(i, sbsxList);
            }
                if (sbsxList.Count > 0)
                {
                    DevExpress.XtraTab.XtraTabPage XtraPage = null;
                    int i = 1;
                    foreach (BD_SBTZ_SX sbsx in sbsxList)
                    {
                        if (i > 100 || XtraPage == null)
                        {
                            XtraPage = new DevExpress.XtraTab.XtraTabPage();
                            XtraPage.Name = "xtrpage" + pageNumber;
                            XtraPage.Text = string.Format("变电设备第{0}页", pageNumber);
                            this.xtraTabControl1.TabPages.Add(XtraPage);
                            XtraPage.AutoScroll = true;
                            pageNumber++;
                        }
                        if (i > 100)
                        {
                            i = 1;
                            startlblw = 11;
                            startlblh = 11;
                            starttextw = 180;
                            starttexth = 8;
                        }
                        DevExpress.XtraEditors.LabelControl lbl = new DevExpress.XtraEditors.LabelControl();
                        lbl.Name = lbl + sbsx.sxcol;
                        lbl.Text = sbsx.sxname.Trim();
                        lbl.Location = new Point(startlblw, startlblh);

                        //DevExpress.XtraEditors.TextEdit txtEdit = new DevExpress.XtraEditors.TextEdit();
                        Control txtEdit = createControl(sbsx);
                        txtEdit.Name = sbsx.sxcol;
                        //txtEdit.DataBindings.Add("EditValue", rowData, sbsx.sxcol);
                        txtEdit.Size = new Size(337, 21);
                        //txtEdit.Location = new Point(starttextw, starttexth);
                        txtEdit.Location = new Point(widthArr[pageNumber - 2] + 40, starttexth);
                        
                        XtraPage.Controls.Add(lbl);
                        XtraPage.Controls.Add(txtEdit);
                        startlblh += 33;
                        starttexth += 33;
                        i++;
                    }
                    XtraPage = new DevExpress.XtraTab.XtraTabPage();
                    XtraPage.Name = "xtrPagePicture";
                    XtraPage.Text = "变电设备照片";
                    this.xtraTabControl1.TabPages.Add(XtraPage);
                    GroupBox grpbox = new GroupBox();
                    grpbox.Location = new Point(0, 0);
                    grpbox.Text = "照片";
                    grpbox.Name = "grppicture";
                    //grpbox.Dock = DockStyle.Top;
                    grpbox.Dock = DockStyle.Fill;
                    grpbox.Size = new Size(565, 386);
                    XtraPage.Controls.Add(grpbox);

                    pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
                    pictureEdit1.Dock = DockStyle.Fill;
                    pictureEdit1.Name = "pictureEdit1";
                    grpbox.Controls.Add(pictureEdit1);
                    pictureEdit1.EditValueChanged += new EventHandler(pictureEdit1_EditValueChanged);


                    DevExpress.XtraEditors.SimpleButton btnOk = new DevExpress.XtraEditors.SimpleButton();
                    btnOk.Name = "btnOk";
                    btnOk.Text = "确定";
                    btnOk.Location = new Point(357, 9);
                    btnOk.Click += new EventHandler(btnOk_Click);
                    btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                    DevExpress.XtraEditors.SimpleButton btnCancel = new DevExpress.XtraEditors.SimpleButton();
                    btnCancel.Name = "btnCancel";
                    btnCancel.Text = "取消";
                    btnCancel.Location = new Point(461, 9);
                    btnCancel.Click += new EventHandler(btnCancel_Click);
                    btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                    this.splitContainerControl1.Panel2.Controls.Add(btnOk);
                    this.splitContainerControl1.Panel2.Controls.Add(btnCancel);

                }
            setImage();

        }
        private Control createControl(BD_SBTZ_SX sbsx) {
            Control c = createControl(sbsx.sxtype);
            if (sbsx.sxtype == "下拉列表" || sbsx.sxtype=="1") {
                DevExpress.XtraEditors.ComboBoxEdit box = c as DevExpress.XtraEditors.ComboBoxEdit;
                switch (sbsx.boxtype) {
                    case "查询":

                        try {
                            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sbsx.boxvalue);
                            box.Properties.Items.AddRange(list);
                        } catch { }
                        break;
                    default:
                        box.Properties.Items.AddRange(sbsx.boxvalue.Split('|'));
                        break;
                }
            }
            if (sbsx.sxtype == "日期" || sbsx.sxtype == "2") {
                var cdate = c as DateEditEx;
                cdate.BindingData(rowData, sbsx.sxcol);
                //c.DataBindings.Add("EditValue", rowData, sbsx.sxcol, true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "yyyy-MM-dd");
            } else {
                c.DataBindings.Add("EditValue", rowData, sbsx.sxcol);
            }
            return c;
        }
        Control createControl(string name) {
            Control c = null;
            switch (name) {
                case "日期":
                case "2":
                    var cdate = new DateEditEx();
                    cdate.Properties.EditMask = "yyyy-MM-dd";
                    cdate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                    cdate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cdate.Properties.EditFormat.FormatString = "yyyy-MM-dd";

                    c = cdate;
                    break;
                case "下拉列表":
                case "1":
                    c = new DevExpress.XtraEditors.ComboBoxEdit();
                    break;
                case "整数":
                    var c1 = new DevExpress.XtraEditors.SpinEdit();
                    c1.Properties.IsFloatValue = false;
                    c = c1;
                    break;
                case "小数":
                    var c2 = new DevExpress.XtraEditors.SpinEdit();
                    c2.Properties.IsFloatValue = true;
                    c = c2;
                    break;
                case "文本":
                case "0":
                default:
                    c = new DevExpress.XtraEditors.TextEdit();
                    break;
            }
            return c;
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 获取lable最大宽度
        /// </summary>
        /// <param name="i">第几个Tab页</param>
        /// <param name="sbsxList">计算列表</param>
        /// <returns></returns>
        private int GetMaxLblWidth(int i, IList<BD_SBTZ_SX> sbsxList)
        {
            int retMax = 0;
            int start = i * 10;
            int end = (i + 1) * 10-1;
            if (end >= sbsxList.Count)
            {
                end = sbsxList.Count-1;
            }
            for (int j = start; j <= end; j++)
            {
                if (sbsxList[j].sxname.ToString().Trim().Length * 9 > retMax)
                {
                    retMax = sbsxList[j].sxname.ToString().Trim().Length * 9;
                }
            }
                return retMax;
        }

        void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            imageData = pictureEdit1.EditValue;
            if (imageData == null)
            {
                imageData = new byte[] { 0 };
            }
            if (image == null)
                image = new PS_Image();
            image.ImageData = (byte[])imageData;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        object imageData;
        public object GetImage()
        {

            return imageData;
        }
        private void setImage()
        {
            pictureEdit1.EditValue = null;
            imageData = null;
            
                image = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_Image>(rowData.c3);
            
            if (image != null)
                pictureEdit1.EditValue = image.ImageData;
            imageData = null;
        }
        PS_Image image = null;
        public PS_Image GetPS_Image()
        {
            if (image != null && imageData != null)
                image.ImageData = (byte[])imageData;
            return image;
        }

        private void splitContainerControl1_Panel2_Resize(object sender, EventArgs e)
        {
            //this.splitContainerControl1.Panel2.MinSize = 42;
            //this.splitContainerControl1.Panel1.MinSize = this.splitContainerControl1.Size.Height - this.splitContainerControl1.Panel2.Height;
        }
    }
}