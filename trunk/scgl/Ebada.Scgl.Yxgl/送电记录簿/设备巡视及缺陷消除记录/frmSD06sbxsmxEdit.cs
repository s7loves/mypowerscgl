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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmSD06sbxsmxEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<sdjl_06sbxsmx> m_CityDic = new SortableSearchableBindingList<sdjl_06sbxsmx>();
        public sdjl_06sbxs ParentObj = new sdjl_06sbxs();
        public frmSD06sbxsmxEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {
            //this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xlqd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "xssj");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxlb");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "qxnr", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "xcrq");
        }
        #region IPopupFormEdit Members
        private sdjl_06sbxsmx rowData = null;

        public object RowData
        {
            get
            {
                getxsr();
                getxcr();
                return rowData;
            }
            set
            {
                if (value == null) return;

                if (rowData == null)
                {
                    this.rowData = value as sdjl_06sbxsmx;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjl_06sbxsmx>(value as sdjl_06sbxsmx, rowData);
                    this.InitComboBoxData();
                }
                setxsr();
                setxcr();
            }
        }

        #endregion

        private void InitComboBoxData()
        {
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表

            comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit5.Properties.Items.AddRange(ryList);
            comboBoxEdit6.Properties.Items.AddRange(ryList);
            comboBoxEdit7.Properties.Items.AddRange(ryList);

            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<sd_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>(" where OrgCode='" + rowData.OrgCode + "'and linevol>=10");
           
            //comboBoxEdit1.Properties.Items.Clear();
            for (int i = 0; i < xllit.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = xllit[i].LineName;
                ot.ValueMember = xllit[i].LineCode;
                //comboBoxEdit1.Properties.Items.Add(ot);
            }
            sdjl_sbxsqd ps = Client.ClientHelper.PlatformSqlMap.GetOne<sdjl_sbxsqd>("where XsqdName='" + ParentObj.xlqd+ "'and LineCode='" + ParentObj.LineID + "' ");
            if (ps != null)
            {
                comboBoxEdit3.EditValue = ps.XSR1;
                comboBoxEdit6.EditValue = ps.XSR2;
            }
          
            //缺陷类别GetQxlb
            ComboBoxHelper.FillCBoxByDyk("送电设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<sd_xl> post)
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
        void setxsr()
        {
            string str = rowData.xsr;
            comboBoxEdit3.EditValue = "";
            comboBoxEdit6.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit3.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit6.EditValue = mans[1];
            }
        }
        void getxsr()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit3.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit6.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xsr = str;
        }
        void setxcr()
        {
            string str = rowData.xcr;
            comboBoxEdit5.EditValue = "";
            comboBoxEdit7.EditValue = "";
            string[] mans = str.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            if (mans.Length >= 1)
            {
                comboBoxEdit5.EditValue = mans[0];
            }
            if (mans.Length >= 2)
            {
                comboBoxEdit7.EditValue = mans[1];
            }
        }
        void getxcr()
        {
            string str = "";
            string yy1 = "";
            yy1 = comboBoxEdit5.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy1 + ";";
            string yy2 = "";
            yy2 = comboBoxEdit7.EditValue.ToString();
            if (!string.IsNullOrEmpty(yy1.Trim()))
                str += yy2 + ";";
            rowData.xcr = str;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("送电设备巡视及缺陷消除记录", "缺陷内容", memoEdit1);

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit4_EditValueChanged(sender, e);
        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {

            DateTime dt = Convert.ToDateTime(rowData.xssj);
            string dx = "", sx = "", nr = "";
            int dayspan1 = 1, dayspan2 = 10, dayspan3 = 30;
            dx = "送电设备巡视及缺陷消除记录";
            sx = "缺陷类别";
            nr = "紧急缺陷";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from PJ_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx,nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dayspan1 = Convert.ToInt32(list[0]);
            }

            sx = "缺陷类别";
            nr = "重大缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from PJ_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx, nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dayspan2 = Convert.ToInt32(list[0]);
            }
            sx = "缺陷类别";
            nr = "一般缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from PJ_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx, nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dayspan3 = Convert.ToInt32(list[0]);
            }
            if (comboBoxEdit4.EditValue == null) return;
            switch (comboBoxEdit4.EditValue.ToString())
            {
                case "紧急缺陷":
                    rowData.xcqx = dt.AddDays(dayspan1).ToShortDateString();
                    break;
                case "重大缺陷":
                    rowData.xcqx = dt.AddDays(dayspan2).ToShortDateString();
                    break;
                case "一般缺陷":
                    rowData.xcqx = dt.AddDays(dayspan3).ToShortDateString();
                    break;
                default:
                    rowData.xcqx = "";
                    break;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rowData.LineID = ParentObj.LineID;
            rowData.LineName = ParentObj.LineName;
            
        }
    }
}