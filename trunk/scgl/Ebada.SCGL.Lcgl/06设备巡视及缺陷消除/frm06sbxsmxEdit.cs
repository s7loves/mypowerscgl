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
namespace Ebada.Scgl.Lcgl
{
    public partial class frm06sbxsmxEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_06sbxsmx> m_CityDic = new SortableSearchableBindingList<PJ_06sbxsmx>();
        public PJ_06sbxs ParentObj = new PJ_06sbxs();
        public frm06sbxsmxEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {


            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "LineID");

            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xlqd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "xssj");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xsr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxlb");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "qxnr", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "xcrq");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

            
            this.combTq.DataBindings.Add("EditValue", rowData, "tqid");
            this.combByq.DataBindings.Add("EditValue", rowData, "byqid");
            this.combKg.DataBindings.Add("EditValue", rowData, "kgid");

        }
        #region IPopupFormEdit Members
        private PJ_06sbxsmx rowData = null;

        public object RowData
        {
            get
            {
                getxsr();
                getxcr();
                rowData.xlid = comboBoxEdit1.EditValue.ToString();
                rowData.xlname =comboBoxEdit1.Text;
                rowData.tqname = combTq.Text;
                rowData.byqname = combByq.Text;
                rowData.kgname = combKg.Text;
                return rowData;
            }
            set
            {
                if (value == null) return;

                if (rowData == null)
                {
                    this.rowData = value as PJ_06sbxsmx;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_06sbxsmx>(value as PJ_06sbxsmx, rowData);
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

            //ICollection linelist = ComboBoxHelper.GetGdsxl(rowData.OrgCode);//获取供电线路名称
            ////线路名称
            //comboBoxEdit1.Properties.Items.AddRange(linelist);
            IList<PS_xl> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where OrgCode='" + rowData.OrgCode + "'and linevol>=10.0 ");
            SetComboBoxData(lookUpEdit1, "LineName", "LineID", "选择线路", "", xllit);
            comboBoxEdit1.Properties.Items.Clear();
            for (int i = 0; i < xllit.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = xllit[i].LineName;
                ot.ValueMember = xllit[i].LineCode;
                comboBoxEdit1.Properties.Items.Add(ot);
            }
            if (rowData.LineName == "")
            {
                if (comboBoxEdit1.Properties.Items.Count > 0)
                {
                    comboBoxEdit1.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxEdit1.Text = rowData.LineName;
            }
            PJ_sbxsqd ps = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_sbxsqd>("where XsqdName='" + ParentObj.xlqd+ "'and LineCode='" + ParentObj.LineID + "' ");
            if (ps != null)
            {
                comboBoxEdit3.EditValue = ps.XSR1;
                comboBoxEdit6.EditValue = ps.XSR2;
            }
          
                //巡视区段
                // ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视区段", comboBoxEdit2.Properties);


                //ICollection qxlist = ComboBoxHelper.GetQxlb();//获取缺陷类别
                //缺陷类别GetQxlb
                ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);

            //ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "巡视人", comboBoxEdit3.Properties);

            //comboBoxEdit4.Properties.Items.AddRange(qxlist);
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_xl> post)
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

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lookUpEdit1.Text))
            {
                rowData.LineID = lookUpEdit1.EditValue.ToString();
                rowData.LineName = lookUpEdit1.Text;
                comboBoxEdit2.Properties.Items.Clear();
                comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit6.Properties.Items.Clear();

                PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linecode='" + rowData.LineID + "'");
                if (xl != null)
                {
                    IList<PJ_sbxsqd> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PJ_sbxsqd>(" where LineCode='" + xl.LineID + "'");
                    foreach (PJ_sbxsqd xsqd in xllit)
                    {
                        comboBoxEdit2.Properties.Items.Add(xsqd.XsqdName);
                        comboBoxEdit3.Properties.Items.Add(xsqd.XSR1);
                        comboBoxEdit6.Properties.Items.Add(xsqd.XSR2);
                    }
                }
               
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("06设备巡视及缺陷消除记录", "缺陷内容", memoEdit1);

        }



        private void comboBoxEdit3_Properties_SelectedValueChanged(object sender, EventArgs e)
        {
            //string xsry = comboBoxEdit3.Properties.GetDisplayText(null);
            ////comboBoxEdit3.EditValue = "";
            //comboBoxEdit6.EditValue = "";
            //string[] mans = xsry.Split(new char[1] { ';' }, 10, StringSplitOptions.RemoveEmptyEntries);
            //if (mans.Length >= 1)
            //{
            //    comboBoxEdit3.EditValue = mans[0];
            //}
            //if (mans.Length >= 2)
            //{
            //    comboBoxEdit6.EditValue = mans[1];
            //}

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
           
           PJ_sbxsqd ps = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_sbxsqd>("where XsqdName='"+ comboBoxEdit2.EditValue+"'and LineCode='"+rowData.LineID+"' ");
            if (ps!=null)
            {
                comboBoxEdit3.EditValue = ps.XSR1;
                comboBoxEdit6.EditValue = ps.XSR2;
            }
        }

        private void comboBoxEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            //ICollection list = new ArrayList();
            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR1 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            //comboBoxEdit3.Properties.Items.Clear();
            //comboBoxEdit3.Properties.Items.AddRange(list);

            //list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select XSR2 from PJ_sbxsqd where XsqdName='{0}' ", comboBoxEdit2.EditValue));
            //comboBoxEdit6.Properties.Items.Clear();
            //comboBoxEdit6.Properties.Items.AddRange(list); 
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
            dx = "06设备巡视及缺陷消除记录";
            sx = "缺陷类别";
            nr = "紧急缺陷";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx,nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dayspan1 = Convert.ToInt32(list[0]);
            }

            sx = "缺陷类别";
            nr = "重大缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx, nr));
            if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
            {
                dayspan2 = Convert.ToInt32(list[0]);
            }
            sx = "缺陷类别";
            nr = "一般缺陷";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}'", dx, sx, nr));
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ReSetSelectValue();
        }
        private void ReSetSelectValue()
        {
            string xlcode = string.Empty;
            if (comboBoxEdit1.EditValue != null)
            {
                xlcode = comboBoxEdit1.EditValue.ToString();
            }
            if (xlcode.Length == 6)
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode='{0}' ", xlcode));
                combTq.Properties.Items.Clear();
                for (int i = 0; i < xlList.Count; i++)
                {
                    ListItem ot = new ListItem();
                    ot.DisplayMember = xlList[i].tqName;
                    ot.ValueMember = xlList[i].tqCode;
                    combTq.Properties.Items.Add(ot);
                }
            }
            else
            {
                IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where   xlcode2='{0}' ", xlcode));
                combTq.Properties.Items.Clear();
                for (int i = 0; i < xlList.Count; i++)
                {
                    ListItem ot = new ListItem();
                    ot.DisplayMember = xlList[i].tqName;
                    ot.ValueMember = xlList[i].tqCode;
                    combTq.Properties.Items.Add(ot);
                }
            }

            IList<PS_tqbyq> byqlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tqbyq>(string.Format("where   left(byqcode,3)='{0}' ", rowData.gdstemp));
            combByq.Properties.Items.Clear();
            for (int i = 0; i < byqlist.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = byqlist[i].byqName;
                ot.ValueMember = byqlist[i].byqCode;
                combByq.Properties.Items.Add(ot);
            }



            IList<PS_kg> kglist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_kg>(string.Format("where gtID in ( SELECT gtID FROM ps_gt WHERE lineCode='{0}' ", xlcode));
            combKg.Properties.Items.Clear();
            for (int i = 0; i < kglist.Count; i++)
            {
                ListItem ot = new ListItem();
                ot.DisplayMember = kglist[i].kgName;
                ot.ValueMember = kglist[i].kgCode;
                combKg.Properties.Items.Add(ot);
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            rowData.LineID = ParentObj.LineID;
            rowData.LineName = ParentObj.LineName;
            //PS_xl xl = null;
            //xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='"+comboBoxEdit1.Text+"'");
            //if (xl != null)
            //{
            //    rowData.LineID = xl.LineID;
            //    rowData.LineName = xl.LineName;
            //}
            //else
            //{
            //    rowData.LineName = comboBoxEdit1.Text;
            //}
           // rowData.CreateDate = rowData.xssj;
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(comboBoxEdit1.Text))
            //{
            //    PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit1.EditValue.ToString() + "'");
              
            //    rowData.LineName = comboBoxEdit1.EditValue.ToString(); ;
            //    comboBoxEdit2.Properties.Items.Clear();
            //    comboBoxEdit3.Properties.Items.Clear();
            //    comboBoxEdit6.Properties.Items.Clear();
            //    if (xl != null)
            //    {
            //        rowData.LineID = xl.LineID;
            //        IList<PJ_sbxsqd> xllit = Client.ClientHelper.PlatformSqlMap.GetList<PJ_sbxsqd>(" where LineCode='" + xl.LineID + "'");
            //        foreach (PJ_sbxsqd xsqd in xllit)
            //        {
            //            comboBoxEdit2.Properties.Items.Add(xsqd.XsqdName);
            //            comboBoxEdit3.Properties.Items.Add(xsqd.XSR1);
            //            comboBoxEdit6.Properties.Items.Add(xsqd.XSR2);
            //        }
            //    }

            //}
        }








    }
}