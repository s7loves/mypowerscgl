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
using System.Threading;

namespace Ebada.Scgl.Sbgl
{
    public partial class frmsd_xsjhnr : FormBase, IPopupFormEdit
    {
      
        DevExpress.XtraTab.XtraTabPage XtraPage = null;
        public  IList<sd_gt> gtList;
        public sd_xsjh sdxsjh;
        
        public frmsd_xsjhnr()
        {
            InitializeComponent();
            
        }

        #region IPopupFormEdit 成员
        private List<sd_xsjhnr> rowData = null;
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
                    this.rowData = value as List<sd_xsjhnr>;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<List<sd_xsjhnr>>(value as List<sd_xsjhnr>, rowData);
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
           
            InitLkue();
           
        }

        private void InitLkue()
        {
            List<DicType> gtDictypeList = new List<DicType>();
            IList<sd_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + sdxsjh.LineID+ "'");
            foreach (sd_gt gt in gtList)
            {
                gtDictypeList.Add(new DicType(gt.gtCode, gt.gtCode));
            }
            SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
            SetComboBoxData(lkueEndGt, "Value", "Key", "请选择", "终止杆塔", gtDictypeList);
        }

        private void RefershControl()
        {
            int pageCount = xtraTabControl1.TabPages.Count;
            //lable一个字符站12个宽度
            for (int i = pageCount-1; i >0; i--)
            {
                xtraTabControl1.TabPages.RemoveAt(i);
            }
            //this.splitContainerControl1.Panel2.Controls.Clear();
            //lable起始位置

            int pageNumber = 1;

            if (gtList == null)
                return;
            if (gtList.Count < 1)
                return;
            foreach (sd_gt gt in gtList)
            {
                int startlblw = 11;
                int startlblh = 11;
                //textbox起始位置
                int starttextw = 180;
                int starttexth = 8;
                int addh = 33;

                XtraPage = new DevExpress.XtraTab.XtraTabPage();
                XtraPage.Name = "xtrpage" + pageNumber;
                XtraPage.Text = string.Format("特殊区域第{0}页", pageNumber);
                this.xtraTabControl1.TabPages.Add(XtraPage);
                pageNumber++;


                AddLable(startlblw, "gtid", "设备ID", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "gtid", "gtid", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "gtbh", "杆塔编号", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "gtbh", "gtbh", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "flag1", "缺陷状态", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "flag1", "flag1", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "lng", "经度", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "lng", "lng", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "lat", "纬度", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "lat", "lat", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "flag2", "巡视状态", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "flag2", "flag2", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "xssj", "巡视时间", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.DateEdit(), "xssj", "xssj", ref starttexth, 48, XtraPage, pageNumber - 2);

                AddLable(startlblw, "qxnr", "缺陷内容", ref startlblh, XtraPage);
                AddOtherControl(new DevExpress.XtraEditors.TextEdit(), "qxnr", "qxnr", ref starttexth, 48, XtraPage, pageNumber - 2);

            }
        }

        private void AddLable(int startlblw, string lblname, string lbltext, ref int startlblh, Control Parent)
        {
            DevExpress.XtraEditors.LabelControl lbl = new DevExpress.XtraEditors.LabelControl();
            lbl.Name = lblname;
            lbl.Text = lbltext;
            lbl.Location = new Point(startlblw, startlblh);
            Parent.Controls.Add(lbl);
            startlblh += 33;
        }

        private void AddOtherControl(Control child, string childname, string bindName, ref int starttexth, int width,Control Parent,int pageNumber)
        {

            child.Name = childname;
            child.DataBindings.Add("EditValue", rowData[pageNumber], bindName);
            child.Size = new Size(337, 21);
            child.Location = new Point(width + 40, starttexth);
            starttexth += 33;
            Parent.Controls.Add(child);
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

      

        void btnOk_Click(object sender, EventArgs e)
        {
            List<sd_xsjhnr> list = rowData;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lkueStartGt_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkueStartGt.EditValue == null)
                return;
            if (this.lkueEndGt.EditValue == null)
                return;
            InitControl();
            RefershControl();
        }

        private void InitControl()
        {
            int startgt = -1;
            int endgt = -1;

            startgt = Convert.ToInt32(this.lkueStartGt.EditValue);
            endgt = Convert.ToInt32(this.lkueEndGt.EditValue);
            int temp = 0;
            if (startgt > endgt)
            {
                temp = startgt;
                startgt = endgt;
                endgt = temp;
            }

            if (startgt < 0 || endgt < 0)
                return;
            if (gtList != null)
            {
                gtList.Clear();
            }
            string sql = "where Convert(int,gtCode) between " + startgt + " and " + endgt + " and LineCode='" +sdxsjh.LineID +"'";
            gtList = (List<sd_gt>)Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>(sql);
            if (gtList == null)
                return;
            if (gtList.Count == 0)
                return;
            List<sd_xsjhnr> xsjhnrList = new List<sd_xsjhnr>();
            Random rn = new Random();
            foreach (sd_gt gt in gtList)
            {
                sd_xsjhnr xsjhnr = new sd_xsjhnr();
                xsjhnr.ID += rn.Next(1, 1000);
                xsjhnr.ParentID = sdxsjh.ID;
                xsjhnr.gtid = gt.gtID;
                xsjhnr.gtbh = gt.gtCode;
                xsjhnr.lat = gt.gtLat.ToString();
                xsjhnr.lng = gt.gtLon.ToString();
                xsjhnrList.Add(xsjhnr);
                Thread.Sleep(10);
            }
            rowData = xsjhnrList;
        }

        private void lkueEndGt_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkueStartGt.EditValue == null)
                return;
            if (this.lkueEndGt.EditValue == null)
                return;
            InitControl();
            RefershControl();
        }
    }
}