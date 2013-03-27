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
using DevExpress.XtraTab;

namespace Ebada.Scgl.Sbgl.变电
{
    public partial class frmsd_tsqyEdit : FormBase, IPopupFormEdit
    {
        public bool ispicChange = false;
        private bool isfirst = true;
        public sd_xl sdxl;
        DevExpress.XtraTab.XtraTabPage XtraPage = null;
        public sd_tsqyzl tsqyzl;
        DevExpress.XtraEditors.PictureEdit pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
        IList<sd_gt> gtList;
        public frmsd_tsqyEdit()
        {
            InitializeComponent();
            //xtraTabControl1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom| AnchorStyles.Left| AnchorStyles.Top;
           
        }

        #region IPopupFormEdit 成员
        private sd_tsqy rowData = null;
        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sd_tsqy;

                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sd_tsqy>(value as sd_tsqy, rowData);
                }
                //setImage();
            }
        }

        

        #endregion


        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
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

        private void dataBind()
        {
            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "mc");
        }
        //起始位置11、11 |128、8;size 337:21|
        //垂直增加33  
        private void frmSBTZ_Load(object sender, EventArgs e)
        {
            List<DicType> dicTypeList = new List<DicType>();
            if (sdxl != null)
            {
                gtList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + sdxl.LineCode + "'");
            }
            foreach (sd_gt sdgt in gtList)
            {
                dicTypeList.Add(new DicType(sdgt.gtCode, sdgt.gtCode));
            }
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
            int nrows = 30;
            IList<sd_tsqyzlsx> sbsxList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_tsqyzlsx>("where zldm='" + tsqyzl.zldm + "' and isuse='是' order by convert(int,norder)");
            int[] widthArr = new int[sbsxList.Count / nrows + 1];
            for (int i = 0; i < widthArr.Length; i++)
            {
                widthArr[i] = GetMaxLblWidth(i, sbsxList);
            }

            if (pageNumber == 1)
            {
                XtraPage = new DevExpress.XtraTab.XtraTabPage();
                XtraPage.Name = "xtrpage" + pageNumber;
                XtraPage.Text = string.Format("特殊区域属性");
                this.xtraTabControl1.TabPages.Add(XtraPage);

                DevExpress.XtraEditors.LabelControl lblstart = new DevExpress.XtraEditors.LabelControl();
                lblstart.Name = "lblStart";
                lblstart.Text = "起始杆塔";
                lblstart.Location = new Point(startlblw, startlblh);

                DevExpress.XtraEditors.LookUpEdit lkueStart = new LookUpEdit();
                lkueStart.Name = "lkueStart";
                SetComboBoxData(lkueStart, "Value", "Key", "请选择", "起始杆塔", dicTypeList);

                lkueStart.Location = new Point(widthArr[pageNumber - 1] + 40, starttexth);
                lkueStart.DataBindings.Add("EditValue", rowData, "gtbegin");

                XtraPage.Controls.Add(lblstart);
                XtraPage.Controls.Add(lkueStart);
                startlblh += 33;
                starttexth += 33;
                

                DevExpress.XtraEditors.LabelControl lblend = new DevExpress.XtraEditors.LabelControl();
                lblend.Name = "lblend";
                lblend.Text = "终止杆塔";
                lblend.Location = new Point(startlblw, startlblh);

                DevExpress.XtraEditors.LookUpEdit lkueEnd = new LookUpEdit();
                lkueEnd.Name = "lkueend";
                SetComboBoxData(lkueEnd, "Value", "Key", "请选择", "终止杆塔", dicTypeList);
                lkueEnd.Location = new Point(widthArr[pageNumber - 1] + 40, starttexth);
                lkueEnd.DataBindings.Add("EditValue", rowData, "gtend");

                XtraPage.Controls.Add(lblend);
                XtraPage.Controls.Add(lkueEnd);
                startlblh += 33;
                starttexth += 33;
                
            }

                if (sbsxList.Count > 0)
                {
                    
                    int i = 3;
                    foreach (sd_tsqyzlsx sbsx in sbsxList)
                    {
                        if (i > nrows || XtraPage == null)
                        {
                            pageNumber++;
                            XtraPage = new DevExpress.XtraTab.XtraTabPage();
                            XtraPage.Name = "xtrpage" + pageNumber;
                            XtraPage.Text = string.Format("特殊区域第{0}页", pageNumber);
                            this.xtraTabControl1.TabPages.Add(XtraPage);
                            XtraPage.AutoScroll = true;
                            //XtraPage.SizeChanged += new EventHandler(XtraPage_SizeChanged);
                        }

                        if (i > nrows)
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

                        Control txtEdit = createControl(sbsx);
                        txtEdit.Name = sbsx.sxcol;
                        //txtEdit.DataBindings.Add("EditValue", rowData, sbsx.sxcol);
                        txtEdit.Size = new Size(337, 21);
                        //txtEdit.Location = new Point(starttextw, starttexth);
                        txtEdit.Location = new Point(widthArr[pageNumber - 1] + 40, starttexth);
                        
                        XtraPage.Controls.Add(lbl);
                        XtraPage.Controls.Add(txtEdit);
                        XtraPage.AutoScrollMinSize = new Size(txtEdit.Right + 10, txtEdit.Bottom + 10);
                        startlblh += 33;
                        starttexth += 33;
                        i++;
                    }
                    XtraPage = new DevExpress.XtraTab.XtraTabPage();
                    XtraPage.Name = "xtrPagePicture";
                    XtraPage.Text = "特殊区域照片";
                    this.xtraTabControl1.TabPages.Add(XtraPage);
                    GroupBox grpbox = new GroupBox();
                    grpbox.Location = new Point(0, 0);
                    grpbox.Text = "照片";
                    grpbox.Name = "grppicture";
                    grpbox.Dock = DockStyle.Top;
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

        void XtraPage_SizeChanged(object sender, EventArgs e) {
            XtraTabPage aa=(sender as XtraTabPage);
            aa.AutoScrollMinSize = aa.ClientSize;
        }

        private Control createControl(sd_tsqyzlsx sbsx) {
            Control c = createControl(sbsx.ctype);
            if (sbsx.ctype == "下拉列表") {
                DevExpress.XtraEditors.ComboBoxEdit box = c as DevExpress.XtraEditors.ComboBoxEdit;
                switch (sbsx.inittype) {
                    case "查询":
                        
                        try {
                            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sbsx.initsql);
                            box.Properties.Items.AddRange(list);
                        } catch { }
                        break;
                    default :
                        box.Properties.Items.AddRange(sbsx.initsql.Split('|'));
                        break;
                }
            }
            if (sbsx.ctype == "日期") {
                var cdate = c as DateEditEx;
                cdate.BindingData(rowData, sbsx.sxcol);
                //c.DataBindings.Add("EditValue", rowData, sbsx.sxcol, true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "yyyy-MM-dd");
            } else {
                c.DataBindings.Add("EditValue", rowData, sbsx.sxcol);
            }
            return c;
        }
        Control createControl(string name){
            Control c = null ;
            switch (name) {
                case "日期":
                    var cdate = new DateEditEx();
                    cdate.Properties.EditMask = "yyyy-MM-dd";
                    cdate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                    cdate.Properties.AllowNullInput  = DevExpress.Utils.DefaultBoolean.True;
                    cdate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
                    
                    c = cdate;
                    break;
                case "下拉列表":
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
        private int GetMaxLblWidth(int i, IList<sd_tsqyzlsx> sbsxList)
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
                if (sbsxList[j].sxname.ToString().Trim().Length * 12 > retMax)
                {
                    retMax = sbsxList[j].sxname.ToString().Trim().Length * 12;
                }
            }
                return retMax;
        }

        void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
            if (!isfirst)
            {
                ispicChange = true;
            }
            isfirst = false;
            imageData = pictureEdit1.EditValue;
            if(image!=null)
            image.data =imageData as byte[] ;
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
        //获取图片
        public object GetImage()
        {

            return imageData;
        }
        /// <summary>
        /// 加载时设置图片
        /// </summary>
        private void setImage()
        {
            pictureEdit1.EditValue = null;
            imageData = null;

            image = Client.ClientHelper.PlatformSqlMap.GetOne<sd_tsqyimage>("where ParentID='"+rowData.ID+"'");

            if (image != null) {

                pictureEdit1.EditValue = image.data;
            } else {

            }
            isfirst = false;
            imageData = null;
        }
        sd_tsqyimage image = null;
        public sd_tsqyimage GetPS_Image()
        {
            if (image != null && imageData != null)
                image.data = (byte[])imageData;
            return image;
        }
    }
}