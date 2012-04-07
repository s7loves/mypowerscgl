using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Ebada.Scgl.Resource;
using System.Globalization;
using System.Reflection;
using Ebada.Scgl.Run;
namespace Ebada.SCGL
{
    //public partial class FrmSystem : DevExpress.XtraEditors.XtraForm
        public partial class FrmSystem : Form
    {
        private string secondmenu = "";
        public FrmSystem()
        {
            
            InitializeComponent();
            this.Text = "绥化市郊农电信息管理平台";
            pictureEdit1.Image = ImageListRes.GetTop2();
           
            labdate.Parent = pictureEdit1;
            labTime.Parent = pictureEdit1;
            labdate2.Parent = pictureEdit1;
            labSet.Parent = pictureEdit1;
            labExit.Parent = pictureEdit1;
            labdate2.Text = GetCNDate();
            //labshow.Parent = pictureEdit2;
            labdate.Text = DateTime.Now.ToString("m") + ""+DateTime.Now.ToString("dddd");
            timer1.Start();

        }

        private void FrmSystem_Load(object sender, EventArgs e)
        {
            CreateMenu();

        }
        private void CreateMenu()
        {
            nbctSystem.Groups.Clear();
            nbctSystem.Items.Clear();

            nbctSystem.LargeImages = ImageListRes.GetimageListAll(40, "");
            nbctSystem.SmallImages = ImageListRes.GetimageListAll(28, "");


            string sqlwhere = "where ParentID='0' and  Description='system'  order by Sequence";
            IList<mModule> mlist = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(sqlwhere);
            for (int i = 0; i < mlist.Count; i++)
            {
                DevExpress.XtraNavBar.NavBarGroup nbg = new DevExpress.XtraNavBar.NavBarGroup();
                nbg.Name = mlist[i].ModuName;
                nbg.Tag = mlist[i];
                nbg.Caption = mlist[i].ModuName;
                nbg.LargeImage = ((ImageList)nbctSystem.LargeImages).Images[mlist[i].IconName];

                string slqwhrer2 = "where Description = 'system' and ParentID='" + mlist[i].Modu_ID + "'  order by Sequence";
                IList<mModule> mlist2 = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(slqwhrer2);
                for (int j = 0; j < mlist2.Count; j++)
                {
                    DevExpress.XtraNavBar.NavBarItem nbi = new DevExpress.XtraNavBar.NavBarItem();
                    nbi.Name = mlist2[j].ModuName;
                    nbi.Tag = mlist2[j];
                    nbi.Caption = mlist2[j].ModuName;
                    nbi.SmallImage = ((ImageList)nbctSystem.SmallImages).Images[mlist2[j].IconName];
                    nbi.Hint = mlist2[j].Sequence.ToString();
                    nbctSystem.Items.Add(nbi);
                    nbg.ItemLinks.Add(nbi);
                }
                nbctSystem.Groups.Add(nbg);
                nbctSystem.Refresh();
            }
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            listView1.Items.Clear();
            secondmenu = "";
            listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");
            mModule mdule = e.Group.Tag as mModule;
            string slqwhrer2 = "where Description = 'system' and ParentID='" + mdule.Modu_ID + "'  order by Sequence";
            IList<mModule> mlist2 = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(slqwhrer2);
            for (int j = 0; j < mlist2.Count; j++)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = mlist2[j].ModuName.ToString();
                listItem.Tag = mlist2[j];
                listItem.ImageKey = mlist2[j].IconName.ToString();
                
                //listItem.BackColor = System.Drawing.Color.Blue;
                listView1.Items.Add(listItem);
            }
            //显示上部位置名称
            labshow.Text = ">>" + mdule.ModuName;
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
        }
        //激活程序
         private void listView1_ItemActivate(object sender, EventArgs e)
        {
            mModule mdule = listView1.FocusedItem.Tag as mModule;
            //显示上部位置名称
            if (secondmenu=="")
            {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
            }
            else
            {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption +"->"+ secondmenu+"->" + mdule.ModuName;
            }
            
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
            if (mdule.ModuName.Contains("生产管理系统"))
            {
                frmMain2 frm = new frmMain2();
                frm.ShowDialog();
                return;
            }
            if (mdule == null || string.IsNullOrEmpty(mdule.ModuTypes))
                return;

            string exe = mdule.ModuTypes;
            if (mdule.ModuTypes.ToLower().Contains(".exe")  )
            {             
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + exe);
            }
            else if(mdule.ModuTypes.ToLower().Contains("http"))
	        {
                System.Diagnostics.Process.Start(exe);
	        }
            else
            {
                object instance=null;
                object[] para = new object[1];
                para.SetValue(mdule, 0);
                para = new object[0];
                
                object result = MainHelper.Execute(mdule.AssemblyFileName, mdule.ModuTypes, mdule.MethodName, null,null,ref instance);
                Form form = (Form)instance;
                form.Show();
            }

           
        }
         private void nbctSystem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {

           CreateListView(e.Link.Item);
            
        }

         private void CreateListView(DevExpress.XtraNavBar.NavBarItem nbi)
         {
             mModule mdule = nbi.Tag as mModule;
             secondmenu = mdule.ModuName;
             if (mdule == null)
                 return;
             listView1.Items.Clear();
             listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");
             string slqwhrer2 = "where Description = 'system' and ParentID='" + mdule.Modu_ID + "'  order by Sequence";
             IList<mModule> mlist2 = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(slqwhrer2);
             for (int j = 0; j < mlist2.Count; j++)
             {
                 ListViewItem listItem = new ListViewItem();
                 listItem.Text = mlist2[j].ModuName.ToString();
                 listItem.Tag = mlist2[j];
                 listItem.ImageKey = mlist2[j].IconName.ToString();

                 //listItem.BackColor = System.Drawing.Color.Blue;
                 listView1.Items.Add(listItem);
             }
             //显示上部位置名称
             labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
             //显示下部说明
             labbuttom.Text = mdule.IsCores;
         }
         
        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString("HH:mm");
        }
        //显示农历日期
        string GetCNDate()
        {
             DateTime m_Date; //今天的日期
             int cny; //农历的年月日
             int cnm; //农历的年月日
             int cnd; //农历的年月日
             int icnm; //农历闰月

             m_Date = DateTime.Today;
            ChineseLunisolarCalendar cnCalendar =new ChineseLunisolarCalendar();
            cny = cnCalendar.GetSexagenaryYear(m_Date);
            cnm = cnCalendar.GetMonth(m_Date);
            cnd = cnCalendar.GetDayOfMonth(m_Date);
            icnm = cnCalendar.GetLeapMonth(cnCalendar.GetYear(m_Date));


            string txcns = "农历";
            const string szText1 = "癸甲乙丙丁戊己庚辛壬";
            const string szText2 = "亥子丑寅卯辰巳午未申酉戌";
            const string szText3 = "猪鼠牛虎免龙蛇马羊猴鸡狗";
            int tn = cny % 10; //天干
            int dn = cny % 12;  //地支
            //txcns += szText1.Substring(tn, 1);
            //txcns += szText2.Substring(dn, 1);
            //txcns += "(" + szText3.Substring(dn, 1) + ")年";

            //格式化月份显示
            string[] cnMonth ={ "", "正月", "二月", "三月", "四月", "五月", "六月"
                , "七月", "八月", "九月", "十月", "十一月", "十二月", "十二月" };
            if (icnm > 0)
            {
                for (int i = icnm + 1; i < 13; i++)
                    cnMonth[icnm] = cnMonth[icnm - 1];
                cnMonth[icnm] = "闰" + cnMonth[icnm];
            }
            txcns += cnMonth[cnm];
            string[] cnDay ={ "", "初一", "初二", "初三", "初四", "初五", "初六", "初七"
                , "初八", "初九", "初十", "十一", "十二", "十三"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   , "十四", "十五", "十六"
                , "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五"
                , "廿六", "廿七", "廿八", "廿九", "三十" };
            txcns += cnDay[cnd];
            return txcns;
        }

        private void labSet_Click(object sender, EventArgs e)
        {
            frmModule frm = new frmModule();
            frm.ShowDialog();
            CreateMenu();
        }

        private void labExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        

       
    }
}