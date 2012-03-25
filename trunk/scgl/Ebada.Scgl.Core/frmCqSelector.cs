using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
namespace Ebada.Scgl.Core
{
    public partial class frmCqSelector : DevExpress.XtraEditors.XtraForm
    {
        public frmCqSelector()
        {
            InitializeComponent();
        }
        private DataTable dt1 = new DataTable();
        public string dynr = "";
        public DataTable DT1
        {
            get { return dt1; }
        }

        void init()
        {
            dt1.Columns.Add("ID", typeof(int));
            dt1.Columns.Add("ParentID", typeof(int));
            dt1.Columns.Add("Title", typeof(string));
            //一、上级变电所与局属线路（局属变电所同此）
            DataRow dr = dt1.NewRow();
            dr["ID"] = 1;
            dr["Title"] = "一、上级变电所与局属线路（局属变电所同此）";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["ID"] = 11;
            dr["ParentID"] = 1;
            dr["Title"] = "1.架空出线";
            dt1.Rows.Add(dr);
            
            dr = dt1.NewRow();
            dr["ID"] = 12;
            dr["ParentID"] = 1;
            dr["Title"] = "2.电缆出线";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 111;
            dr["ParentID"] =11;
            dr["Title"] = "划分原则：以变电所出口构架上的耐张线夹或蝶式绝缘子向线路方向延伸一米";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 121;
            dr["ParentID"] = 12;
            dr["Title"] = "划分原则：以变电所穿墙套管与电缆连接点";
            dt1.Rows.Add(dr);

            //二、上级架空线路对局架空线路
            dr = dt1.NewRow();
            dr["ID"] = 2;
            dr["Title"] = "二、上级架空线路对局架空线路";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 21;
            dr["ParentID"] = 2;
            dr["Title"] = "1.未装设隔离";
            dt1.Rows.Add(dr);
            
            dr = dt1.NewRow();
            dr["ID"] = 22;
            dr["ParentID"] = 2;
            dr["Title"] = "2.装设隔离开关";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 211;
            dr["ParentID"] = 21;
            dr["Title"] = "划分原则：T接点局属线路侧耐张线夹或蝶式绝缘子向上级线路方向延伸1米";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 221;
            dr["ParentID"] = 22;
            dr["Title"] = "划分原则：以隔离开关动触头";
            dt1.Rows.Add(dr);
            //三.局属线路与用户
            dr = dt1.NewRow();
            dr["ID"] = 3;
            dr["Title"] = "三.局属线路与用户（用户与用户相同）";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dt1.NewRow();
            dr["ID"] = 31;
            dr["ParentID"] = 3;
            dr["Title"] = "1.在线路上T接";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 32;
            dr["ParentID"] = 3;
            dr["Title"] = "2.在线路下做变台";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 33;
            dr["ParentID"] = 3;
            dr["Title"] = "3.低压在变台接线";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 311;
            dr["ParentID"] = 31;
            dr["Title"] = "（1）高压架空对架空";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 312;
            dr["ParentID"] = 31;
            dr["Title"] = "（2）高压架空对电缆";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 313;
            dr["ParentID"] = 31;
            dr["Title"] = "（3）低压架空对架空";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["ID"] = 314;
            dr["ParentID"] = 31;
            dr["Title"] = "（4）低压架空对电缆";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["ID"] = 321;
            dr["ParentID"] = 32;
            dr["Title"] = "(1) H 型变台：以高压引线担上的高压立瓶";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["ID"] = 322;
            dr["ParentID"] = 32;
            dr["Title"] = "（2）单杆变台：以线路与用户引线连接点向负荷侧延伸1米";
            dt1.Rows.Add(dr);

            
            dr = dt1.NewRow();
            dr["ID"] = 331;
            dr["ParentID"] = 33;
            dr["Title"] = "（1）在变压器二次侧接线柱接线";
            dt1.Rows.Add(dr);
           
            dr = dt1.NewRow();
            dr["ID"] = 332;
            dr["ParentID"] = 33;
            dr["Title"] = "（2）在低压开关负荷侧接线";
            dt1.Rows.Add(dr);
            dr = dt1.NewRow();
            dr["ID"] = 333;
            dr["ParentID"] = 33;
            dr["Title"] = "（3）在计量箱互感器负荷侧接线";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3111;
            dr["ParentID"] = 311;
            dr["Title"] = "划分原则：T接点用户侧耐张线夹或蝶式绝缘子向线路方向延伸1米";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3121;
            dr["ParentID"] = 312;
            dr["Title"] = "A.有熔断器的：以熔断器静触头";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3122;
            dr["ParentID"] = 312;
            dr["Title"] = " B.无熔断器的：以电缆头接线端子与引线接线端子连接";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3311;
            dr["ParentID"] = 331;
            dr["Title"] = "划分原则：以用户侧耐张线夹或蝶式绝缘子向线路方向延伸1米";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3321;
            dr["ParentID"] = 332;
            dr["Title"] = "划分原则：以低压开关负荷与引线接点向负荷侧延伸1米处";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["ID"] = 3331;
            dr["ParentID"] = 333;
            dr["Title"] = "划分原则：以互感器负荷侧与引线接点向负荷侧延伸1米";
            dt1.Rows.Add(dr);

            treeList1.DataSource = dt1;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!treeList1.FocusedNode.HasChildren)
            {
                dynr = treeList1.FocusedNode["Title"].ToString().ToString();
                dynr = dynr.Substring(dynr.LastIndexOf("：") + 1);
            }
            else
            {
                MessageBox.Show("请选择它的子类！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmCqSelector_Load(object sender, EventArgs e)
        {
            init();
        }
    }
}