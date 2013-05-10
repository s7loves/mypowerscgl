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
using System.Collections;
using DevExpress.XtraEditors.Repository;
using Ebada.Core;


namespace Ebada.jhgl
{
    public partial class UCJH_weekmanthz : DevExpress.XtraEditors.XtraUserControl
    {


        string BaseSql = "SELECT mUser.PostName AS 职务, JH_weekmant.考核结果,  JH_weekmant.姓名, mUser_1.UserName AS 考核人,"
                      + " mOrg.OrgName AS 单位名称,"
                      + " convert(varchar(50),dateadd(day,-1,dateadd(month,1,cast(left(JH_weekmant.年月周,6)+'01' as datetime))),23) as 考核时间"
                      + " FROM JH_weekmant INNER JOIN"
                      + " mUser ON JH_weekmant.单位代码 = mUser.OrgCode AND JH_weekmant.姓名 = mUser.UserName INNER JOIN"
                      + " mUser AS mUser_1 ON mUser.OrgCode = mUser_1.OrgCode INNER JOIN"
                      + " mOrg ON JH_weekmant.单位代码 = mOrg.OrgCode"
                      + " WHERE (mUser.UserCode <> mUser.OrgCode + '001') AND (mUser_1.UserCode = mUser_1.OrgCode + '001')";

        string sqlorder = " order by mOrg.OrgName";

        string orgBaseSql = "SELECT mOrg.OrgCode"
                          + " FROM mOrg INNER JOIN rRoleOrg ON mOrg.OrgID = rRoleOrg.OrgID INNER JOIN"
                          + " rUserRole ON rRoleOrg.RoleID = rUserRole.RoleID INNER JOIN mUser ON rUserRole.UserID = mUser.UserID";

        public UCJH_weekmanthz()
        {
            InitializeComponent();
        }
        private bool isYear;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();//初始数据
            InitGridData();
        }

        private void InitGridData()
        {
            IList<JH_weekmant> weekmantList = new List<JH_weekmant>();
            this.gridControl1.DataSource = weekmantList;
            InitGridViewColumn();
        }


        


        private void RefreshGrid(string where)
        {
            this.gridControl1.DataSource = null;
           IList datalist = Client.ClientHelper.PlatformSqlMap.GetList("Select", where);
           DataTable dt = DataConvert.HashTablesToDataTable(datalist);
           if (dt == null)
               return;
           List<JH_weekmant> exportList = new List<JH_weekmant>();
           List<string> weeknameList = new List<string>();
           foreach (DataRow  rw in dt.Rows)
           {
               if (!weeknameList.Contains(rw["姓名"].ToString()))
               {
                   weeknameList.Add(rw["姓名"].ToString());
               }
           }
           foreach (string name in weeknameList)
           {
               JH_weekmant newWeekMant = new JH_weekmant();
               int score = 0;
               string detail = "";
               foreach (DataRow  rw in dt.Rows)
               {
                   if (rw["姓名"].ToString() == name)
                   {
                       detail = detail + rw["考核结果"] + "|";
                       score = score + GetScore(rw["考核结果"].ToString());
                       if (string.IsNullOrEmpty(newWeekMant.单位名称))
                           newWeekMant.单位名称 = rw["单位名称"].ToString();
                       if (string.IsNullOrEmpty(newWeekMant.职务))
                           newWeekMant.职务 = rw["职务"].ToString();
                       if (string.IsNullOrEmpty(newWeekMant.考核人))
                           newWeekMant.考核人 = rw["考核人"].ToString();
                       if (string.IsNullOrEmpty(newWeekMant.考核时间))
                           newWeekMant.考核时间 = Convert.ToDateTime(rw["考核时间"]).ToShortDateString();
                   }
               }
               
               newWeekMant.考核结果 = detail;
               newWeekMant.c3 = score.ToString();
               newWeekMant.姓名 = name;
               exportList.Add(newWeekMant);
           }


           gridControl1.DataSource = exportList;
        }
        

        

        /// <summary>
        /// 展示月
        /// </summary>
        /// <returns></returns>
        public Control showM()
        {
            isYear = false;
            return this;
        }

        /// <summary>
        /// 展示年
        /// </summary>
        /// <returns></returns>
        public Control showY()
        {
            isYear = true;
            this.barEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barStaticItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }

        /// <summary>
        /// 初始化Gridview列
        /// </summary>
        private void InitGridViewColumn()
        {
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["单位代码"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["年月周"].Visible = false;
            gridView1.Columns["开始日期"].Visible = false;
            gridView1.Columns["结束日期"].Visible = false;
            gridView1.Columns["月总分"].Visible = false;
            gridView1.Columns["年总分"].Visible = false;
            gridView1.Columns["标题"].Visible = false;
            gridView1.Columns["c3"].Caption = "总分";
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            IList listYear = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select 年 from jh_yearkst where parentid='0'");
            repositoryItemComboBox2.Items.AddRange(listYear);

            List<string> listMonth = new List<string>();
            listMonth.AddRange(new string[] {"1","2","3","4","5","6","7","8","9","10","11","12" });
            this.repositoryItemComboBox3.Items.AddRange(listMonth);

            string where = "where orgcode in(" + orgBaseSql + " where mUser.UserID='" + MainHelper.User.UserID + "') order by OrgCode,OrgType";
            IList<mOrg> listorg = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(where);
            
            foreach (mOrg org in listorg)
            {
                this.repositoryItemCheckedComboBoxEdit1.Items.Add(org.OrgName, CheckState.Unchecked, true);
            }
        }
        /// <summary>
        /// 年改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (isYear||barEditItem2.EditValue!=null)
                RefershData();
            
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefershData()
        {
            if (barEditItem1.EditValue == null)
                return;
            if (barEditItem2.EditValue == null&&!isYear)
                return;

            string where = "";

            if (barEditItem1.EditValue != null)
            {
                where = " and 年月周 like '" + barEditItem1.EditValue.ToString();
                if (barEditItem2.EditValue != null)
                {
                    string month = "";
                    if (Convert.ToInt32(barEditItem2.EditValue) < 10)
                    {
                        month = "0" + barEditItem2.EditValue.ToString();
                    }
                    else
                    {
                        month = barEditItem2.EditValue.ToString();
                    }
                    where = where + month + "%'";
                }
                else
                {
                    where = where + "%'";
                }
            }

            if (barEditItem3.EditValue != null)
            {
                string[] orgName = barEditItem3.EditValue.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (orgName.Length > 0)
                {
                    
                    where = where + " and 单位名称 in(";                 
                    for (int i = 0; i < orgName.Length; i++)
                    {
                        if (i == orgName.Length - 1)
                        {
                            where = where + "'" + orgName[i].Trim() + "')";
                        }
                        else
                        {
                            where = where + "'" + orgName[i].Trim() + "',";
                        }
                    }
                }
            }
            string sql = BaseSql + where + sqlorder;
            RefreshGrid(sql);
        }
        /// <summary>
        /// 月改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            string where = "";
            if (barEditItem1.EditValue == null)
            {
                return;
            }
            else if(barEditItem2.EditValue!=null)
            {
                where = "and 年月周 like '" + barEditItem1.EditValue.ToString();
                string month = "";
                if (Convert.ToInt32(barEditItem2.EditValue) < 10)
                {
                    month = "0" + barEditItem2.EditValue.ToString();
                }
                else
                {
                    month = barEditItem2.EditValue.ToString();
                }
                where = where + month + "%'";
            }
            if (barEditItem3.EditValue != null)
            {
                string[] orgName = barEditItem3.EditValue.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (orgName.Length > 0)
                {
                    where = where + " and 单位名称 in(";
                    for (int i = 0; i < orgName.Length; i++)
                    {
                        if (i == orgName.Length - 1)
                        {
                            where = where + "'" + orgName[i].Trim() + "')";
                        }
                        else
                        {
                            where = where + "'" + orgName[i].Trim() + "',";
                        }
                    }
                }
            }
            string sql = BaseSql + where + sqlorder;
            RefreshGrid(sql);
        }
        /// <summary>
        /// 单位改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barEditItem3_EditValueChanged(object sender, EventArgs e)
        {
            RefershData();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barEditItem1.EditValue == null)
            {
                MessageBox.Show("请选择年!");
                return;
            }
            string title = "";
            List<JH_weekmant> weekmantList = (List<JH_weekmant>)gridControl1.DataSource;

            //"员工工作写实年终总分"
            title = barEditItem1.EditValue.ToString() + "年";
           
            if (!isYear)
            {
                title = title + "员工总分汇总表("+barEditItem2.EditValue+"月)";
                ExportPDCA.ExportExcelMantthMonth(title, weekmantList);
            }
            else
            {
                title = title + "员工总分汇总表(年)";
                ExportPDCA.ExportExcelMantthYear(title, weekmantList); 
            }
            

        }

        private int GetScore(string Type)
        {
            switch (Type)
            {
                case "A":
                    return 4;
                case "B":
                    return 3;
                case "C":
                    return 2;
                case "D":
                    return 1;
                default:
                    return 0;
                    

            }
        }
    }
}
