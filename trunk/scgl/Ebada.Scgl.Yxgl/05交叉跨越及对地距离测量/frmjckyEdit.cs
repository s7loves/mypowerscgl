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
    public partial class frmjckyEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_05jcky> m_CityDic = new SortableSearchableBindingList<PJ_05jcky>();
        private string parentID = "";

        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }


        public frmjckyEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineID");
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
        private PJ_05jcky rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_05jcky;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    this.InitComboBoxData();
                    ConvertHelper.CopyTo<PJ_05jcky>(value as PJ_05jcky, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
         
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "规定距离不小于(m)",spinEdit1);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "被跨越物名称", comboBoxEdit5);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "所属单位", comboBoxEdit6);
            ComboBoxHelper.FillCBoxByDyk("05交叉跨越及对地距离测量记录", "级别", comboBoxEdit7);

            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + parentID + "' and linevol>=10.0 and parentid=''");
           foreach (PS_xl pl in xlList)
           {
               comboBoxEdit1.Properties.Items.Add(pl.LineName);
           }
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
            if (comboBoxEdit1.EditValue == null) return;
            PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit1.Text + "'");
            if (xl == null) return;
            comboBoxEdit2.Properties.Items.Clear();
            IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where ParentID='"+xl.LineCode+"'");
            if (list.Count==0)
            {
                list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where ParentID='" + xl.LineID + "'");
            }
            foreach (PS_xl pl in list)
            {
                comboBoxEdit2.Properties.Items.Add(pl.LineName);
            }
            
            //string linecode = comboBoxEdit1.EditValue.ToString();
            //int num=(linecode.Length - 3) / 3;
            //int len = 3;
            //string code;
            //List<string> codelist=new List<string>();
            //for (int i = 0; i < num; i++) {
            //    if (i == 1)
            //        len += 4;
            //    else
            //        len += 3;
            //    codelist.Add("'" + linecode.Substring(0, len) + "'");

            //}
            //code = string.Join(",", codelist.ToArray());
            //if (code == "") return;
            //IList xllist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select linename from ps_xl where linecode in ({0})",code));
            //code = "";
            //foreach (string str in xllist) {
            //    code += str;
            //}
            //this.comboBoxEdit3.Text = rowData.kywz = code;
        }       
        

        private void comboBoxEdit2_EditValueChanged_2(object sender, EventArgs e)
        {
            if (comboBoxEdit2.EditValue == null) return;
            comboBoxEdit3.Properties.Items.Clear();
            PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where linename='" + comboBoxEdit2.Text + "'");
            if (xl!=null)
            {
                IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + xl.LineCode + "'");
                for (int i = 0; i < list.Count; i++)
                {
                    //comboBoxEdit2.Properties.Items.Add(list[i].LineID);
                    comboBoxEdit4.Properties.Items.Add(list[i].gtCode);
                }
            }
            IList<string> list1 = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select linename from ps_xl where ParentID='" + xl.LineCode + "'");
            if (list1.Count==0)
            {
                list1 = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select linename from ps_xl where ParentID='" + xl.LineID + "'");
            }
            List<string> col=list1 as List<string>;
            comboBoxEdit3.Properties.Items.AddRange(col.ToArray());
           
        }
    }
}