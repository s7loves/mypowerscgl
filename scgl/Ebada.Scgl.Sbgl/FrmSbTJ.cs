using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Client;
using DevExpress.XtraEditors.Repository;

namespace Ebada.Scgl.Sbgl
{
    public partial class FrmSbTJ : DevExpress.XtraEditors.XtraForm
    {
        public FrmSbTJ()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
        }
        private string allcode = "00000";
        private void InitData()
        {
            IList<mOrg> orglist = ClientHelper.PlatformSqlMap.GetList<mOrg>(" where OrgType=2");
       
            IList<mOrg> newlist = new List<mOrg>();
            newlist.Add(new mOrg() { OrgCode = allcode, OrgName = "全局" });
            foreach (mOrg org in orglist)
            {
                newlist.Add(org);
            }
            SetComboBoxData(repositoryItemLookUpEdit1, "OrgName", "OrgCode", "请选择变电所", "变电所名称", newlist);
           
        }

       
        public void SetComboBoxData(RepositoryItemLookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<mOrg> post)
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

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue != null)
            {
                string code = barEditItem1.EditValue.ToString();
                string sql = string.Empty;
                //不是全局
                if (code != allcode)
                {
                    sql = " select  a1 as 设备名称, a3 as 类型  ,count(sbname) as 设备数量 from BD_SBTZ  where OrgCode='" + code + "'group by a1,a3 ";
                }
                else
                {
                    sql = " select  a1 as 设备名称, a3 as 类型  ,count(sbname) as 设备数量 from BD_SBTZ  group by a1,a3 ";
                }


                DataTable dt = ClientHelper.PlatformSqlMap.GetDataTable("GetBD_SBTZRowTable", sql);
                gridControl1.DataSource = dt;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //try
            //{
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = "";
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {

                    //gridControl.ExportToExcelOld(fname);
                    gridView1.ExportToXls(fname, true);
                    if (MessageBox.Show("导出成功，是否打开该文档？","提示",MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    System.Diagnostics.Process.Start(fname);
                }
                catch
                {
                    MessageBox.Show("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                    return;
                }
            }


            //return true;
            //}
            //catch { }
        }
    }
}