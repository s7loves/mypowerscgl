/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
***********************************************/
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
using System.Threading;
using Ebada.UI.Base;
using System.Globalization;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCWarnRecordPage : DevExpress.XtraEditors.XtraUserControl
    {
       
        private string parentID = null;
        public  mOrg Org;
        public string type;
        public UCWarnRecordPage()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            repositoryItemHyperLinkEdit1.Click += new EventHandler(repositoryItemHyperLinkEdit1_Click);
            bar3.Visible = false;
        }

        void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                WarnRecord record = gridView1.GetFocusedRow() as WarnRecord;

                string mudulid = record.LinkID;
                if (mudulid!=string.Empty)
                {

                    mModule md = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(mudulid);
                    if (md != null)
                    {
                        OpenModule(md);
                    }

                }

            }
            catch (Exception)
            {
            }
            

        }
        public void OpenModule(mModule obj)
        {
           
            object instance = null;//模块接口
          
            this.Cursor = Cursors.WaitCursor;
            try
            {
                object result = null;
                if (obj.MethodParam == null || string.IsNullOrEmpty(obj.MethodName))
                    result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, null, ref instance);
                else
                {
                    result = Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.MethodParam.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries), null, ref instance);
                }
                if (result is UserControl)
                {
                    instance = showControl(result as UserControl, obj.Modu_ID);
                }
                if (instance is Form)
                {
                    Form fb = instance as Form;
                    fb.Text = obj.ModuName;
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("Modu_ID", obj.Modu_ID);
                    fb.Tag = dic;
                }
                this.Cursor = Cursors.Default;

            }
            catch (Exception err)
            {
                this.Cursor = Cursors.Default;
                MsgBox.ShowException(err);
            }
          
        }
        public static object Execute(string assemblyName, string className, string methodName, object[] paramValues, Form mdi, ref object classInstance)
        {

            if (assemblyName == null)
                assemblyName = string.Empty;
            if (className == null || className == string.Empty)
                return null;
            if (string.IsNullOrEmpty(methodName))
                methodName = "Show";
            if (paramValues == null)
                paramValues = new object[0];
            object result = null;

            Type type = Assembly.GetExecutingAssembly().GetType(className);
            if (null == type)
            {
                Assembly asm = (assemblyName == string.Empty) ? Assembly.GetExecutingAssembly() : Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                type = asm.GetType(className, true);
            }
            //
            Type[] ptypes = new Type[paramValues.Length];
            for (int i = 0; i < paramValues.Length; i++)
                ptypes[i] = paramValues[i].GetType();

            MethodInfo method = type.GetMethod(methodName, ptypes);
            if (method != null)
            {
                ParameterInfo[] paramInfos = method.GetParameters();
                if (paramInfos.Length == paramValues.Length)
                {
                    // 参数个数相同才会执行
                    object[] methodParams = new object[paramValues.Length];

                    for (int i = 0; i < paramValues.Length; i++)
                        methodParams[i] = Convert.ChangeType(paramValues[i], paramInfos[i].ParameterType, CultureInfo.InvariantCulture);
                    if (classInstance == null)
                    {
                        classInstance = (method.IsStatic) ? null : Activator.CreateInstance(type);
                    }
                    if (classInstance is Form && mdi is Form)
                    {
                        ((Form)classInstance).MdiParent = mdi;
                    }
                    else if (classInstance is UserControl)
                    {
                        //return classInstance;
                    }
                    result = method.Invoke(classInstance, methodParams);
                }
            }

            return result;
        }
        /// <summary>
        /// 显示用户控件方法
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private FormBase showControl(UserControl uc, string moduID)
        {
            FormBase dlg = new FormBase();
            if (!string.IsNullOrEmpty(moduID))
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("Modu_ID", moduID);
                dlg.Tag = dic;
            }
            dlg.MdiParent = this.ParentForm.ParentForm;
            dlg.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dlg.Show();
            return dlg;
        }
        public void Refresh()
        {
            InitData();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitColumns();//初始列
            InitData();//初始数据
        }

     
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridView1.GetFocusedRow() as WarnRecord
                
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            //找到所有启用的提醒设置
            List<WarnRecord> list = new List<WarnRecord>();

            string sqlwarn = "where IsUse=1" ;
            if (type!=string.Empty)
            {
                sqlwarn += " and  Type='" + type + "'";
            }
            IList<WarnSet> wslist = MainHelper.PlatformSqlMap.GetList<WarnSet>(sqlwarn);

            DateTime dtnow = DateTime.Now;
            int index = 0;
            foreach (WarnSet  ws in wslist)
            {
                //如果此提醒设置对该单位不起作用，则不用计算

                if (Org!=null&&!ws.BYScol1.Contains(Org.OrgCode))
                {
                    break;
                }
                index++;
                string tablename=ws.TableName;
                string field=ws.FieldName;
                string orgfield=ws.OrgField;
                string sql = string.Empty;
                sql="  select top(1) "+field+" from "+tablename ;
                if (orgfield != string.Empty && Org!=null)
                {
                    sql+="  where "+orgfield+" ='"+Org.OrgCode+"'";
                }
                sql += " order by cast(" + field + "  as datetime)  desc";

                DateTime lastneeddate = new DateTime();
                int needtimes = 0;



                try
                {
                  //查找符合条件的日期最后值
                    
                  object dt=  MainHelper.PlatformSqlMap.GetObject("GetWarnResultBySqlWhere", sql);
                  DateTime resdt = DateTime.Parse(dt.ToString());
                  //每月类型
                  if (ws.WarnType==frmWarnSetEdit.WarinType1)
                  {
                      if (IsNeedWarnMonth(ws.BeforeDays,ws.OrderDays,ws.AfterDays,resdt,out lastneeddate,out needtimes))
                      {

                          WarnRecord record = new WarnRecord()
                          {
                              
                              Type = ws.Type,
                              WarnType = ws.WarnType,
                              Times = needtimes,
                              WritTime = lastneeddate,
                              LinkID = ws.LinkID,
                              TableName = ws.TableName,
                              Remark="每月["+ws.OrderDays+" ]号填写",
                              Des=ws.Remark
                          };
                          record.ID += index;
                          list.Add(record);

                      }
                  }
                  else
                  {
                      if (IsNeedWarnDays(ws.BeforeDays, ws.SpaceDays, ws.AfterDays, resdt, out lastneeddate, out needtimes))
                      {

                          WarnRecord record = new WarnRecord()
                          {

                              Type = ws.Type,
                              WarnType = ws.WarnType,
                              Times = needtimes,
                              WritTime = lastneeddate,
                              LinkID = ws.LinkID,
                              TableName = ws.TableName,
                               Des=ws.Remark,
                              Remark = "每隔[" + ws.SpaceDays + " ]日填写"
                          };
                          record.ID += index;
                          list.Add(record);

                      }
                  }

                }
                catch (Exception)
                {
                    break;
                }
               
            }
            if (type=="实验")
            {
                list = InsertSYdata(list);
            }
            gridControl1.DataSource = list;

        }
        private List<WarnRecord> InsertSYdata(List<WarnRecord> list)
        {
            int index = 0;
            string sql=string.Empty;
            if (Org!=null)
	        {
                sql=" where OrgID='"+Org.OrgCode+"'";
	        }
            IList<PS_aqgj> aqgjlist = ClientHelper.PlatformSqlMap.GetList<PS_aqgj>(sql);

            foreach (PS_aqgj aqgj in aqgjlist)
            {
                index++;
                string sqlsy = " where sbID='" + aqgj.sbID + "' order by xcsyrq desc";
                IList<PJ_14aqgjsy> aqgjsylist = ClientHelper.PlatformSqlMap.GetList<PJ_14aqgjsy>(sqlsy);
                if (aqgjsylist.Count>0&&aqgjsylist[0].xcsyrq>DateTime.Now)
                {
                    WarnRecord record=new WarnRecord ()
                    {
                        Type = "实验",
                        WarnType = "安全工具",
                        Times = 1,
                        WritTime = aqgjsylist[0].xcsyrq,
                        LinkID = "",
                        TableName = "PJ_14aqgjsy",
                        Des = " 编号：" + aqgj.sbCode + " 名称：" + aqgj.sbName,
                        Remark = "下次实验在" + aqgjsylist[0].xcsyrq.ToShortDateString()
                    };
                    record.ID += index;
                    list.Add(record);

                }
            }
            return list;
             
        }
        //月份
        private bool IsNeedWarnMonth(int beforedays,int orderdays ,int afterdatys,DateTime haswritdt,out DateTime dt,out int needtimes)
        {
            // 返回是否需要填写
            bool result = false;
            //需要填写日期
            DateTime resultdt = new DateTime();
            //需要填写次数
            int times = 0;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            
            //1.如果在当前月份已填写则
            if (haswritdt.Month == month && haswritdt.Year == year)
            {             
                // 下个月需要填写日期
                DateTime nextmonth = new DateTime(year, (month + 1), orderdays);
                // 下个月填写日距离现在天数
                int days = new TimeSpan(nextmonth.Ticks - DateTime.Now.Ticks).Days;

                //1.1下个月需填写的已在提前提醒范围内
                if (days <= beforedays)
                {
                   times = 1;
                   resultdt = nextmonth;
                   result = true;
                }
            }
            else 
            {
                //根据上次填写时间计算需要填写次数
               int  monthtimes = (DateTime.Now.Year - haswritdt.Year) * 12 + (month - haswritdt.Month);
                //只有当前月未填写
               if (monthtimes == 1)
                {
                    //当前日期在本月提醒范围内
                    if ((orderdays-beforedays)<=day&&day<=(orderdays+afterdatys))
                    {
                        times = 1;
                        resultdt = new DateTime(year, month, orderdays);
                        result = true;
                    }

                    // 下个月需要填写日期
                    DateTime nextmonth = new DateTime(year, (month + 1), orderdays);
                    // 下个月填写日距离现在天数
                    int days = new TimeSpan(nextmonth.Ticks - DateTime.Now.Ticks).Days;

                    //下个月需填写的已在提前提醒范围内
                    if (days <= beforedays)
                    {
                        times =times+ 1;
                        resultdt = nextmonth;
                        result = true;
                    }

                }//有多月未填写 此时只提醒本月要填写的日期，不去关注下个月日期
                else
                {
                    times = monthtimes;
                    resultdt = new DateTime(year, month, orderdays);
                    result = true;
                }

            }



            needtimes = times;
            dt = resultdt;
            return result;

        }

        //间隔日
        private bool IsNeedWarnDays(int beforedays, int spacedays, int afterdatys,DateTime haswritdt,out DateTime dt,out int needtimes)
        {
            spacedays = spacedays + 1;
            // 返回是否需要填写
            bool result = false;
            //需要填写日期
            DateTime resultdt = new DateTime();
            //需要填写次数
            int times = 0;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            //
            int days = new TimeSpan(DateTime.Now.Ticks - haswritdt.Ticks).Days;

            //看需要填写几次
            times = days / spacedays;
            // 可能有一次未填写
            if (times==0)
            {
                //下次要填写日期
                DateTime nextday = haswritdt.AddDays(spacedays);
                int cha=new TimeSpan(nextday.Ticks-DateTime.Now.Ticks).Days;
                //下次要填写日期已在提醒范围内
                if (cha<=beforedays)
                {
                    times = 1;
                    resultdt = nextday;
                    result = true;
                }
            }//  至少有一次未填写
            else if(times==1)
            {
                // 本次要填写日期
                DateTime currtenday = haswritdt.AddDays(spacedays);
                int cha = new TimeSpan(DateTime.Now.Ticks - currtenday.Ticks).Days;
                //本次要填写日期还在延时提醒范围内
                if (cha <= afterdatys)
                {
                    times = 1;
                    resultdt = currtenday;
                    result = true;
                }
                //下次要填写日期
                DateTime nextday = currtenday.AddDays(spacedays);
                int nextcha = new TimeSpan(nextday.Ticks - DateTime.Now.Ticks).Days;
                //下次提醒已在提前提醒范围内
                if (nextcha <= beforedays)
                {
                    if (result)
	                {
                        times = times + 1;
	                }
                    resultdt = nextday;
                    result = true;
                }

            }// 至少有两次未填写
            else
            {
                int cha=days % spacedays;
                //最近一次需要填写日期
                resultdt = DateTime.Now.AddDays(-cha);
                result = true;
            }
            dt = resultdt;
            needtimes = times;
            return result;

        }

        private static  bool IsNeedWarnMonth1(int beforedays, int orderdays, int afterdatys, DateTime haswritdt, out DateTime dt, out int needtimes)
        {
            // 返回是否需要填写
            bool result = false;
            //需要填写日期
            DateTime resultdt = new DateTime();
            //需要填写次数
            int times = 0;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            //1.如果在当前月份已填写则
            if (haswritdt.Month == month && haswritdt.Year == year)
            {
                // 下个月需要填写日期
                DateTime nextmonth = new DateTime(year, (month + 1), orderdays);
                // 下个月填写日距离现在天数
                int days = new TimeSpan(nextmonth.Ticks - DateTime.Now.Ticks).Days;

                //1.1下个月需填写的已在提前提醒范围内
                if (days <= beforedays)
                {
                    times = 1;
                    resultdt = nextmonth;
                    result = true;
                }
            }
            else
            {
                //根据上次填写时间计算需要填写次数
                int monthtimes = (DateTime.Now.Year - haswritdt.Year) * 12 + (month - haswritdt.Month);
                //只有当前月未填写
                if (monthtimes == 1)
                {
                    //当前日期在本月提醒范围内
                    if ((orderdays - beforedays) <= day && day <= (orderdays + afterdatys))
                    {
                        times = 1;
                        resultdt = new DateTime(year, month, orderdays);
                        result = true;
                    }

                    // 下个月需要填写日期
                    DateTime nextmonth = new DateTime(year, (month + 1), orderdays);
                    // 下个月填写日距离现在天数
                    int days = new TimeSpan(nextmonth.Ticks - DateTime.Now.Ticks).Days;

                    //下个月需填写的已在提前提醒范围内
                    if (days <= beforedays)
                    {
                        times = times + 1;
                        resultdt = nextmonth;
                        result = true;
                    }

                }//有多月未填写 此时只提醒本月要填写的日期，不去关注下个月日期
                else
                {
                    times = monthtimes;
                    resultdt = new DateTime(year, month, orderdays);
                    result = true;
                }

            }



            needtimes = times;
            dt = resultdt;
            return result;

        }
        private static  bool IsNeedWarnDays1(int beforedays, int spacedays, int afterdatys, DateTime haswritdt, out DateTime dt, out int needtimes)
        {
            spacedays = spacedays + 1;
            // 返回是否需要填写
            bool result = false;
            //需要填写日期
            DateTime resultdt = new DateTime();
            //需要填写次数
            int times = 0;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            //
            int days = new TimeSpan(DateTime.Now.Ticks - haswritdt.Ticks).Days;

            //看需要填写几次
            times = days / spacedays;
            // 可能有一次未填写
            if (times == 0)
            {
                //下次要填写日期
                DateTime nextday = haswritdt.AddDays(spacedays);
                int cha = new TimeSpan(nextday.Ticks - DateTime.Now.Ticks).Days;
                //下次要填写日期已在提醒范围内
                if (cha <= beforedays)
                {
                    times = 1;
                    resultdt = nextday;
                    result = true;
                }
            }//  至少有一次未填写
            else if (times == 1)
            {
                // 本次要填写日期
                DateTime currtenday = haswritdt.AddDays(spacedays);
                int cha = new TimeSpan(DateTime.Now.Ticks - currtenday.Ticks).Days;
                //本次要填写日期还在延时提醒范围内
                if (cha <= afterdatys)
                {
                    times = 1;
                    resultdt = currtenday;
                    result = true;
                }
                //下次要填写日期
                DateTime nextday = currtenday.AddDays(spacedays);
                int nextcha = new TimeSpan(nextday.Ticks - DateTime.Now.Ticks).Days;
                //下次提醒已在提前提醒范围内
                if (nextcha <= beforedays)
                {
                    if (result)
                    {
                        times = times + 1;
                    }
                    resultdt = nextday;
                    result = true;
                }

            }// 至少有两次未填写
            else
            {
                int cha = days % spacedays;
                //最近一次需要填写日期
                resultdt = DateTime.Now.AddDays(-cha);
                result = true;
            }
            dt = resultdt;
            needtimes = times;
            return result;

        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            hideColumn("TableName");
        }

        private void repositoryItemHyperLinkEdit1_Click_1(object sender, EventArgs e)
        {
            string aa = string.Empty;
        }

        public static bool IsNeedTX( mOrg userorg)
        {
            //找到所有启用的提醒设置
            bool result=false;
            List<WarnRecord> list = new List<WarnRecord>();

            string sqlwarn = "where IsUse=1";
            
            IList<WarnSet> wslist = MainHelper.PlatformSqlMap.GetList<WarnSet>(sqlwarn);

            DateTime dtnow = DateTime.Now;
            int index = 0;
            foreach (WarnSet ws in wslist)
            {
                //如果此提醒设置对该单位不起作用，则不用计算

                if (userorg != null && !ws.BYScol1.Contains(userorg.OrgCode))
                {
                    break;
                }
                index++;
                string tablename = ws.TableName;
                string field = ws.FieldName;
                string orgfield = ws.OrgField;
                string sql = string.Empty;
                sql = "  select top(1) " + field + " from " + tablename;
                if (orgfield != string.Empty && userorg != null)
                {
                    sql += "  where " + orgfield + " ='" + userorg.OrgCode + "'";
                }
                sql += " order by cast(" + field + "  as datetime)  desc";

                DateTime lastneeddate = new DateTime();
                int needtimes = 0;



                try
                {
                    //查找符合条件的日期最后值

                    object dt = MainHelper.PlatformSqlMap.GetObject("GetWarnResultBySqlWhere", sql);
                    DateTime resdt = DateTime.Parse(dt.ToString());
                    //每月类型
                    if (ws.WarnType == frmWarnSetEdit.WarinType1)
                    {
                        if (IsNeedWarnMonth1(ws.BeforeDays, ws.OrderDays, ws.AfterDays, resdt, out lastneeddate, out needtimes))
                        {

                            result = true;
                            return result;
                        }
                    }
                    else
                    {
                        if (IsNeedWarnDays1(ws.BeforeDays, ws.SpaceDays, ws.AfterDays, resdt, out lastneeddate, out needtimes))
                        {
                            result = true;
                            return result;
                           

                        }
                    }

                }
                catch (Exception)
                {
                    break;
                }

            }
            
            if (!result)
            {
                result = HasSYdata(userorg);
            }

            return result;
        }
        private static   bool  HasSYdata( mOrg userorg)
        {
            bool result = false;
            int index = 0;
            string sql = string.Empty;
            if (userorg != null)
            {
                sql = " where OrgID='" + userorg.OrgCode + "'";
            }
            IList<PS_aqgj> aqgjlist = ClientHelper.PlatformSqlMap.GetList<PS_aqgj>(sql);

            foreach (PS_aqgj aqgj in aqgjlist)
            {
                index++;
                string sqlsy = " where sbID='" + aqgj.sbID + "' order by xcsyrq desc";
                IList<PJ_14aqgjsy> aqgjsylist = ClientHelper.PlatformSqlMap.GetList<PJ_14aqgjsy>(sqlsy);
                if (aqgjsylist.Count > 0 && aqgjsylist[0].xcsyrq > DateTime.Now)
                {
                    result = true;
                    break;

                }
            }
            return result;

        }
       
    }
}
