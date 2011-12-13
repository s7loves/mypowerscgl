using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Core;
using Ebada.Client;
using System.Text.RegularExpressions;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmGridcontrolColumnSet : FormBase
    {
        public frmGridcontrolColumnSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";

        public string StrSQL
        {
            get
            {
                return strSQL;
            }
            set
            {
                if (value == null) return;

                strSQL = value;
            }
        }
        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                
                    this.rowData = value as LP_Temple;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            strSQL = "";
            foreach (DataRow dr in griddt.Rows)
            {

                strSQL += "[" + i + ":" + dr["sql"] + "]|";
                i++;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            int i = 0;
            
            LP_Temple tp = ClientHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(rowData.ParentID);
            string[] comItem = SelectorHelper.ToDBC(rowData.ColumnName).Split('|');
            griddt = new DataTable();
            griddt.Columns.Add("name",typeof(string));
            griddt.Columns.Add("sql",typeof(string));
            griddt.Rows.Clear();
            comboBox1.Items.Clear();
            i = 0;
            foreach (string strname in comItem)
            {
                DataRow dr = griddt.NewRow();
                if (strname == "") continue;
                dr["name"] = strname;
                Regex r1 = new Regex(@"(?<=\["+i+":).*?(?=\\])");
                if (r1.Match(rowData.ComBoxItem).Value!="")
                {
                    dr["sql"] = r1.Match(rowData.ComBoxItem).Value;
                }
                griddt.Rows.Add(dr);
                i++;
            }
            WinFormFun.LoadComboBox(columnBox, griddt, "sql", "name");
            gridControl1.DataSource = griddt;
            gridView1.Columns["name"].Caption = "列名";
            gridView1.Columns["name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].Caption = "绑定控件";
            gridView1.Columns["sql"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.OptionsBehavior.Editable = false;
            ListItem lt = new ListItem("RepositoryItemComboBox", "下拉控件");
            comboBox1.Items.Add(lt);
            lt = new ListItem("RepositoryItemDateEdit", "时间控件");
            comboBox1.Items.Add(lt);
            lt = new ListItem("RepositoryItemCalcEdit", "计算器");
            comboBox1.Items.Add(lt);

            lt = new ListItem("yyyy年MM月dd日", "yyyy年MM月dd日");
            comboBox2.Items.Add(lt);

            lt = new ListItem("yyyy-MM-dd", "yyyy-MM-dd");
            comboBox2.Items.Add(lt);
            lt = new ListItem("MM-dd日", "MM-dd日");
            comboBox2.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm");
            comboBox2.Items.Add(lt);
            lt = new ListItem("yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss");
            comboBox2.Items.Add(lt);
            lt = new ListItem("MM-dd日 HH:mm", "MM-dd日 HH:mm");
            comboBox2.Items.Add(lt);
            lt = new ListItem("dd日 HH:mm", "dd日 HH:mm");
            comboBox2.Items.Add(lt);
            lt = new ListItem("HH:mm:ss", "HH:mm:ss");
            comboBox2.Items.Add(lt);
            lt = new ListItem("HH:mm", "HH:mm");
            comboBox2.Items.Add(lt);
            lt = new ListItem("yyyy", "yyyy");
            comboBox2.Items.Add(lt);


        }
        void setComoboxFocusIndex(ComboBox cbx,string text)
        {
            int focusindex =-1, i = 0;
            foreach (ListItem it in cbx.Items)
            {

                ListItem l = it as ListItem;
                if (l.ID == text)
                {
                    focusindex = i;
                    break;
                }
                i++;
            }
            cbx.SelectedIndex = focusindex;
        }
     

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }

 

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MsgBox.ShowTipMessageBox("为选择类型");
                return;
            }
            string strSQLtemp = ((ListItem)comboBox1.SelectedItem).ID;
            if (comboBox2.Visible)
            {
                //strSQLtemp += ":" + ((ListItem)comboBox2.SelectedItem).ID;
                strSQLtemp += ":" + comboBox2.Text;
            }
            int i = 0;
            foreach (DataRow dr in griddt.Rows)
            {
                if (dr["name"].ToString() == columnBox.Text)
                {
                    dr["sql"] = strSQLtemp;
                    break;
                }
                i++;
            }

            ((ListItem)columnBox.SelectedItem).ID = strSQLtemp;
        }

        private void columnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQLtemp = ((ListItem)columnBox.SelectedItem).ID;
            if (columnBox.SelectedIndex < 1) return;
            int i=-1;
            if (strSQLtemp != "")
            {
                i = -1;
                simpleButton3.Text = "修改";
                foreach (ListItem it in comboBox1.Items)
                {
                    i++;
                    if (strSQLtemp.IndexOf(it.ID) > -1)
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
                if (strSQLtemp.IndexOf("RepositoryItemDateEdit") == -1)
                {
                    comboBox2.Visible = false;
                }
                else
                {
                    i = -1;
                    comboBox2.Visible = true;
                    Regex r1 = new Regex(@"(?<=:).*");
                    if (r1.Match(strSQLtemp).Value != "")
                        comboBox2.Text = r1.Match(strSQLtemp).Value;
                    //foreach (ListItem ittemp in comboBox2.Items)
                    //{
                    //    i++;
                    //    if (strSQLtemp.IndexOf(ittemp.ID) > -1)
                    //    {
                    //        comboBox2.SelectedIndex = i;
                    //        break;
                    //    }
                    //}
                }
            }
            else
            {

                simpleButton3.Text = "添加";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQLtemp = ((ListItem)comboBox1.SelectedItem).ID;
            if (strSQLtemp.IndexOf("RepositoryItemDateEdit") == -1)
            {
                comboBox2.Visible = false;
            }
            else
            {

                comboBox2.Visible = true;
            }
        }

       

       

    }
}
