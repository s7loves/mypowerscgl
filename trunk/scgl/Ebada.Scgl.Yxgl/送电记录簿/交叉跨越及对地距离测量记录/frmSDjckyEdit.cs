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
using Ebada.Scgl.Sbgl;
namespace Ebada.Scgl.Yxgl
{
    public partial class frmSDjckyEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<sdjl_05jcky> m_CityDic = new SortableSearchableBindingList<sdjl_05jcky>();
        private string parentID = "";

        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }


        public frmSDjckyEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
            //this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "LineID");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gtID");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kywz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "kygh");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "kymc");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "ssdw");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "jb");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "gdjl");

        }
        #region IPopupFormEdit Members
        private sdjl_05jcky rowData = null;

        public object RowData {
            get {
                sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linename='" + comboBoxEdit1.EditValue + "'");
                if (xl != null)
                {
                    rowData.LineID = xl.LineCode;
                }
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjl_05jcky;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    this.InitComboBoxData();
                    ConvertHelper.CopyTo<sdjl_05jcky>(value as sdjl_05jcky, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
         
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "规定距离不小于(m)",spinEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "被跨越物名称", comboBoxEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "所属单位", comboBoxEdit6.Properties);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "级别", comboBoxEdit7.Properties);
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.Properties.Items.Add("上方");
            comboBoxEdit3.Properties.Items.Add("下方");
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linecode='" + rowData.LineID + "'");
            if (xl!=null)
            {
                comboBoxEdit1.EditValue = xl.LineName;
            }
           // IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + parentID + "' and linevol>=10.0 and parentid=''");
           //foreach (PS_xl pl in xlList)
           //{
           //    comboBoxEdit1.Properties.Items.Add(pl.LineName);
           //}
            //comboBoxEdit1.Properties.DataSource = xlList;
           //comboBoxEdit2.Properties.DataSource = xlList;


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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //if (comboBoxEdit1.EditValue == null) return;
            //PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit1.Text + "'");
            //if (xl == null) return;
            //comboBoxEdit2.Properties.Items.Clear();
            //IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where ParentID='"+xl.LineCode+"'");
            //if (list.Count==0)
            //{
            //    list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where ParentID='" + xl.LineID + "'");
            //}
            //foreach (PS_xl pl in list)
            //{
            //    comboBoxEdit2.Properties.Items.Add(pl.LineName);
            //}
            
          
        }       
        

        private void comboBoxEdit2_EditValueChanged_2(object sender, EventArgs e)
        {
            //if (comboBoxEdit2.EditValue == null) return;
            //comboBoxEdit3.Properties.Items.Clear();
            //PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit2.Text + "'");
            //if (xl!=null)
            //{
            //    IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + xl.LineCode + "'");
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        //comboBoxEdit2.Properties.Items.Add(list[i].LineID);
            //        comboBoxEdit4.Properties.Items.Add(list[i].gtCode);
            //    }
            //    IList<string> list1 = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select linename from ps_xl where ParentID='" + xl.LineCode + "'");
            //    if (list1.Count == 0)
            //    {
            //        list1 = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select linename from ps_xl where ParentID='" + xl.LineID + "'");
            //    }
            //    List<string> col = list1 as List<string>;
            //    comboBoxEdit3.Properties.Items.AddRange(col.ToArray());
            //}
           
           
        }

        private void comboBoxEdit1_Properties_Click(object sender, EventArgs e)
        {
           
            Ebada.Scgl.Sbgl.UCsd_xlTree ucTop = new Ebada.Scgl.Sbgl.UCsd_xlTree();
            ucTop.ParentID = rowData.OrgCode;
           
            ucTop.hidbar();
            FormBase dlg = showControl(ucTop);
            if (dlg.DialogResult == DialogResult.OK)
            {
                sd_xl obj = ucTop.Getps_xl();
                if (obj!=null)
                {
                    comboBoxEdit1.Text = obj.LineName;
                    IList<sd_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + obj.LineCode + "'");
                    comboBoxEdit2.Properties.Items.Clear();
                    comboBoxEdit4.Properties.Items.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        //comboBoxEdit2.Properties.Items.Add(list[i].LineID);
                        comboBoxEdit2.Properties.Items.Add(list[i].gtCode);
                        comboBoxEdit4.Properties.Items.Add(list[i].gtCode.Substring(list[i].gtCode.Length - 4));

                    }
                }
            }
        }
        private FormBase showControl(UserControl uc)
        {
            FrmelementSelect dlg = new FrmelementSelect();
            Size newsize = new Size(1000, 400);
            dlg.Size = newsize;

            dlg.FormBorderStyle = FormBorderStyle.FixedSingle;

            dlg.ShowInTaskbar = false;
            dlg.MaximizeBox = false;
            dlg.MinimizeBox = false;
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.Text = "线路选择器";
            dlg.control.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dlg.ShowDialog();
            return dlg;
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            if (comboBoxEdit2.EditValue!=null)
            {
                comboBoxEdit4.Text = comboBoxEdit2.Text.Substring(comboBoxEdit2.Text.Length - 4);
            }
       
        }
    }
}