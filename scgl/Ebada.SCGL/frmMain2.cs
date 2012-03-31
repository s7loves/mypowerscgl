using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Ebada.Client.Platform;
using Ebada.UI.Base;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client;
using Ebada.SCGL.WFlow.Engine;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace Ebada.SCGL
{
    public partial class frmMain2 : DevExpress.XtraEditors.XtraForm
    {
        public frmMain2()
        {
            InitializeComponent();

            //ucModulBar1.RefreshData("");
            ucModulBar1.PlatForm = this;
            iPaintStyle = new BarSubItem(barManager1, "皮肤");
            //InitMenu("");
            InitSkins();

            helpitem = new BarButtonItem(barManager1, "帮助");
            InitHelp();

            Text += "-绥化农电局生产管理系统";
        }
        #region Skins
        string skinMask = "Office 2010";
        BarSubItem iPaintStyle;
        void InitSkins()
        {
            barManager1.ForceInitialize();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Xmas 2008 Blue");
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Xmas 2008 Blue");
            if (barManager1.GetController().PaintStyleName == "Skin")
            {
                iPaintStyle.Caption = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
                iPaintStyle.Hint = iPaintStyle.Caption;
            }
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarButtonItem item = new BarButtonItem(barManager1, cnt.SkinName);
                item.Name = "bi" + cnt.SkinName;
                item.Id = barManager1.GetNewItemId();
                iPaintStyle.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(OnSkinClick);
            }
        }
        void OnSkinClick(object sender, ItemClickEventArgs e)
        {
            string skinName = e.Item.Caption.Replace(skinMask, "");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
            barManager1.GetController().PaintStyleName = "Skin";
            //solutionExplorer1.barManager1.GetController().PaintStyleName = "Skin";
            iPaintStyle.Caption = "皮肤：" + e.Item.Caption;
            iPaintStyle.Hint = iPaintStyle.Caption;
            iPaintStyle.ImageIndex = -1;
        }
        #endregion
        #region 帮助


        BarButtonItem helpitem;
        void InitHelp()
        {
            barManager1.ForceInitialize();
            helpitem.Name = "help";
            helpitem.ItemClick += new ItemClickEventHandler(OnHelpClick);

        }
        void OnHelpClick(object sender, ItemClickEventArgs e)
        {
            string fname = Application.StartupPath + "\\00记录模板\\生产软件数据采集说明书.doc";
            try
            {
                System.Diagnostics.Process.Start(fname);
            }
            catch
            {


            }
        }
        #endregion
        #region 模块调度
        private Dictionary<string, Form> openFormList = new Dictionary<string, Form>();//打开模块列表

        /// <summary>
        /// 打开模块方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doModule(object sender, EventArgs e)
        {
            Application.DoEvents();

            DataRow row = sender as DataRow;
            mModule obj = Ebada.Core.ConvertHelper.RowToObject<mModule>(row);
            OpenModule(obj);
        }
        public void OpenModule(mModule obj)
        {
            //检查模块是否已经打开
            if (openFormList.ContainsKey(obj.Modu_ID))
            {
                openFormList[obj.Modu_ID].Activate();
                return;
            }
            object instance = null;//模块接口
            barEditItem1.Visibility = BarItemVisibility.Always;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                object result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, this, ref instance);
                if (result is UserControl)
                {
                    instance = showControl(result as UserControl, obj.Modu_ID);
                }
                if (instance is Form)
                {
                    Form fb = instance as Form;
                    openFormList.Add(obj.Modu_ID, fb);
                    fb.Text = obj.ModuName;
                    fb.FormClosed += frmMain_ChildFormClosed;
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
            finally
            {
                barEditItem1.Visibility = BarItemVisibility.Never;
            }
        }
        /// <summary>
        /// 模块关闭时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmMain_ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            Dictionary<string, object> dic = (sender as Form).Tag as Dictionary<string, object>;
            if (dic != null)
                openFormList.Remove(dic["Modu_ID"].ToString());
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
            dlg.MdiParent = this;
            dlg.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dlg.Show();
            return dlg;
        }
        #endregion
        #region 加载菜单
        string sqlwhere = " where 1=0";
        internal void InitMenu(string userid)
        {
            bar2.ItemLinks.Clear();
            sqlwhere = "  a " +
                "where a.modu_id in (select b.modu_id from rRoleModul b " +
                "inner join rUserRole c on b.roleid=c.roleid " +
                "where a.visiableflag=1" + " and c.userid='" + userid + "')";
            IList list = (IList)MainHelper.PlatformSqlMap.GetList<mModule>(sqlwhere);
            if (list.Count > 0)
            {
                DataTable dt = Ebada.Core.ConvertHelper.ToDataTable(list);
                DataRow[] rows = dt.Select("parentid='0'", "Sequence");
                createMenu(bar2, rows, dt);
            }
            bar2.AddItem(iPaintStyle);
            bar2.AddItem(helpitem);

            //加载用户操作权限列表
            //ClientHelper.UserFuns = ClientHelper.PlatformSqlMap.GetList("SelectUserFuns", userid);

        }
        void createMenu(BarLinksHolder bc, DataRow[] rows, DataTable dt)
        {
            foreach (DataRow row in rows)
            {
                DataRow[] progs = dt.Select("parentid='" + row["Modu_ID"] + "' and visiableflag=1", "Sequence");
                if (progs.Length > 0)
                {
                    BarSubItem sub1 = new BarSubItem(barManager1, row["ModuName"].ToString());
                    createMenu(sub1, progs, dt);
                    bc.AddItem(sub1);
                }
                else
                {
                    BarButtonItem bt = new BarButtonItem(barManager1, row["ModuName"].ToString());
                    bt.ItemClick += new ItemClickEventHandler(bt_ItemClick);
                    bt.Tag = Ebada.Core.ConvertHelper.RowToObject<mModule>(row);
                    bc.AddItem(bt);
                }
            }
        }

        void bt_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenModule(e.Item.Tag as mModule);
        }

        #endregion
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.showControl(new sample1.MudleTreeManager(), null).Text = "模块登记";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MainHelper.MainForm = this;
            InitSkins();
            MethodInvoker m = delegate()
            {
                mModule module = new mModule();
                module.ModuTypes = "Ebada.Scgl.Gis.frmMapM";
                module.ModuName = "地理信息";
                module.AssemblyFileName = "Ebada.Scgl.Gis.dll";
                OpenModule(module);
            };


            btLogin.PerformClick();
            Application.DoEvents();
            try
            {
                BeginInvoke(m);
            }
            catch
            {
            }
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucModulBar1.RefreshData("where ModuTypes != 'hide' order by Sequence"); InitMenu("");
        }

        private void btLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin dlg = new frmLogin();
            if (dlg.ShowDialog() == DialogResult.OK)
            {



                barStaticItem2.Caption = string.Format("部门：{0}  操作员：{1}", MainHelper.User.OrgName, MainHelper.User.UserName);
                InitMenu(MainHelper.User.UserID);
                ucModulBar1.RefreshData(sqlwhere);
                ucModulBar1.SetImage();
                if (MainHelper.User.LoginID == "rabbit")
                {
                    barButtonItem1.Visibility = BarItemVisibility.Always;
                    barButtonItem2.Visibility = BarItemVisibility.Always;
                }

                showMessage(3, "欢迎 " + MainHelper.User.UserName + " 登陆，您今天有" + WorkFlowInstance.WorkflowToDoWorkTasks(MainHelper.User.UserID, 999).Rows.Count.ToString() + "个任务待处理");
                timer1.Enabled = false;
                timer1.Interval = 8000;
                timer1.Enabled = true;
                try
                {
                    Program.killmsg();
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerAsync(MainHelper.User.LoginID);

                }
                catch { }
            }
            else
            {
                if (MainHelper.User.LoginID == "rabbit")
                {
                    barButtonItem1.Visibility = BarItemVisibility.Always;
                    barButtonItem2.Visibility = BarItemVisibility.Always;

                    ucModulBar1.RefreshData("where ModuTypes != 'hide' order by Sequence");
                    ucModulBar1.SetImage();
                }
                else
                {
                    this.Close();
                    return;
                }
#if DEBUG

#endif
            }
            barButtonItem3.Enabled = (dlg.DialogResult == DialogResult.OK);

        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\msg\\Ebada.MsgClient.exe"))
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\msg\\Ebada.MsgClient.exe", e.Argument.ToString());
        }

        private void btClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Client.MsgBox.ShowAskMessageBox("是否退出系统？") == DialogResult.OK)
            {

                timer1.Enabled = false;
                this.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //锁屏

            Client.Platform.FormPasswordValidation dlg = new FormPasswordValidation();
            dlg.Owner = this;
            dlg.ShowInTaskbar = false;
            while (true)
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    break;
                }
                else
                {
                    if (Client.MsgBox.ShowAskMessageBox("是否退出系统？") == DialogResult.OK)
                    {
                        this.Close();
                        break;
                    }
                }
            }
        }
        private void showMessage(int type, string nr)
        {
            showMessage(type, nr, 5000);
        }
        private void showMessage(int type, string nr, int nTimeToStay)
        {
            TaskbarNotifier taskbarNotifier1 = new TaskbarNotifier();
            switch (type)
            {
                case 1:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.skin1.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(127, 8));
                    taskbarNotifier1.TitleRectangle = new Rectangle(40, 9, 70, 25);
                    taskbarNotifier1.ContentRectangle = new Rectangle(8, 41, 133, 68);
                    break;
                case 2:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.skin2.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(300, 74));
                    taskbarNotifier1.TitleRectangle = new Rectangle(123, 80, 176, 16);
                    taskbarNotifier1.ContentRectangle = new Rectangle(116, 97, 197, 22);
                    break;
                default:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.skin3.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(UsualForm).Assembly.GetManifestResourceStream("Ebada.SCGL.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(280, 57));
                    taskbarNotifier1.TitleRectangle = new Rectangle(150, 57, 125, 28);
                    taskbarNotifier1.ContentRectangle = new Rectangle(75, 92, 215, 55);
                    break;
            }
            taskbarNotifier1.CloseClickable = true;
            taskbarNotifier1.TitleClickable = false;
            taskbarNotifier1.ContentClickable = true;
            taskbarNotifier1.EnableSelectionRectangle = true;
            taskbarNotifier1.KeepVisibleOnMousOver = true;	// Added Rev 002
            taskbarNotifier1.ReShowOnMouseOver = false;			// Added Rev 002
            //taskbarNotifier1.TitleClick += new EventHandler(TitleClick);
            taskbarNotifier1.ContentClick += new EventHandler(ContentClick);
            //taskbarNotifier1.CloseClick += new EventHandler(CloseClick);
            taskbarNotifier1.Show("农电生产系统", nr, 10, nTimeToStay, 50);

        }
        void ContentClick(object obj, EventArgs e)
        {
            Desktop dt = new Desktop();
            dt.PlatForm = this;
            this.showControl(dt, null).Text = "我的桌面";
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Desktop dt = new Desktop();
            dt.PlatForm = this;
            this.showControl(dt, null).Text = "我的桌面";
        }
        public IList InitSQLData(string sqlSentence)
        {



            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            Regex r1;
            if (sqlSentence != "")
            {
                sqlSentence = sqlSentence.ToLower();
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.ToLower().Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }




            }

            try
            {
                sqlSentence = sqlSentence.Replace("\r\n", " ");
                li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                if (sqlSentence.IndexOf("where 9=9") > -1)
                {
                    string strtemp = li[0].ToString();
                    li.Clear();
                    r1 = new Regex(@"[0-9]+\+[0-9]+");
                    if (r1.Match(strtemp).Value != "")
                    {
                        int istart = 1;
                        int ilen = 10;
                        r1 = new Regex(@"[0-9]+(?=\+)");
                        if (r1.Match(strtemp).Value != "")
                        {
                            istart = Convert.ToInt32(r1.Match(strtemp).Value);
                        }
                        r1 = new Regex(@"(?<=\+)[0-9]+");
                        if (r1.Match(strtemp).Value != "")
                        {
                            ilen = Convert.ToInt32(r1.Match(strtemp).Value); ;
                        }
                        for (int i = istart; i <= ilen; i++)
                        {
                            li.Add(string.Format("{0}", i));
                        }
                    }
                    else
                    {
                        string[] strli = ToDBC(strtemp).Split(',');
                        foreach (string ss in strli)
                        {
                            li.Add(ss);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                li.Add("出错:" + ex.Message);
            }
            return li;
        }
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            IList<PJ_znts> strlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_znts>(
                "where type='显示信息' "
           );
            foreach (PJ_znts zn in strlist)
            {
                IList li = InitSQLData(zn.tjsql);
                if (li.Count > 0)
                {
                    li = InitSQLData(zn.sql);
                    string ss = "select  top 1 '" + zn.xsgs.Replace("{gs}", li.Count.ToString()) + "'from mOrg where 1=1";
                    li = InitSQLData(ss);
                    showMessage(3, li[0].ToString(), 60000);
                }

            }
            PJ_znts zn2 = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_znts>(
                "where type='显示间隔' ");

            if (zn2 == null || zn2.xsgs == "")
            {
                timer1.Interval = 1000 * 60 * 30;
            }
            else if (timer1.Interval.ToString() != (1000 * 60 * Convert.ToInt32(zn2.xsgs)).ToString())
            {
                timer1.Interval = 1000 * 60 * Convert.ToInt32(zn2.xsgs);
            }
        }
    }
}
