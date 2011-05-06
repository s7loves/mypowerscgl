/**********************************************
系统:企业ERP
模块:系统模块
作者:Rabbit
创建时间:2011-2-24
最后一次修改:2011-2-27
***********************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using System.Threading;
using Ebada.Client.Platform;
using Ebada.Platform.Model;
using System.Reflection;
using DevExpress.XtraNavBar;
using System.Collections.Generic;
using Ebada.Core;
using Ebada.UI.Base;
using Ebada.Modules.Demo;
using Ebada.Client;

namespace Ebada.SCGL {
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm {
        public frmMain() {
            InitializeComponent();
            InitSkinGallery();
            InitEditors();
            ribbonControl1.RibbonStyle = RibbonControlStyle.Office2007;
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
        private void frmMain_Load(object sender, System.EventArgs e) {
            ribbonControl1.ForceInitialize();
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins) {
                BarCheckItem item = ribbonControl1.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                iPaintStyle.ItemLinks.Add(item);
            }
            
            this.btnLogin.ItemClick += new ItemClickEventHandler(btnLogin_ItemClick);
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            MainHelper.MainForm = this;
            xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            Application.DoEvents(); beginProgress();
            BeginInvoke(new MethodInvoker(initNavBar)); 
        }
        void InitEditors() {
            //ribbonControl1.Minimized = true;
            riicStyle.Items.Add(new ImageComboBoxItem("Office 2007", RibbonControlStyle.Office2007, -1));
            riicStyle.Items.Add(new ImageComboBoxItem("Office 2010", RibbonControlStyle.Office2010, -1));
            //biStyle.EditValue = ribbonControl1.RibbonStyle;
        }
        void idNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.showControl(new sample1.MudleTreeManager());
        }
        private void iExit_ItemClick(object sender, ItemClickEventArgs e) {
            if(MsgBox.ShowAskMessageBox("是否确认退出系统平台？")== DialogResult.OK)
            this.Close();
        }

        #region 皮肤
        void OnPaintStyleClick(object sender, ItemClickEventArgs e) {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
        }

        private void iPaintStyle_Popup(object sender, System.EventArgs e) {
            foreach (BarItemLink link in iPaintStyle.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Caption == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;
        }
        private void biStyle_EditValueChanged(object sender, EventArgs e) {
            //ribbonControl1.RibbonStyle = (RibbonControlStyle)biStyle.EditValue;
        }

        void InitSkinGallery() {
            SimpleButton imageButton = new SimpleButton();
            foreach (SkinContainer cnt in SkinManager.Default.Skins) {
                imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName);
                GalleryItem gItem = new GalleryItem();
                int groupIndex = 0;
                if (cnt.SkinName.Contains("Office")) groupIndex = 1;
                //if(DevExpress.DXperience.Demos.LookAndFeelMenu.IsBonusSkin(cnt.SkinName)) groupIndex = 2;
                rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                gItem.Caption = cnt.SkinName;

                gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                gItem.Caption = cnt.SkinName;
                gItem.Hint = cnt.SkinName;
            }
            rgbiSkins.Gallery.Groups[1].Visible = false;
            rgbiSkins.Gallery.Groups[2].Visible = false;
        }
        Bitmap GetSkinImage(SimpleButton button, int width, int height, int indent) {
            Bitmap image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image)) {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));
                info.Bounds = new Rectangle(0, 0, width, height);
                button.LookAndFeel.Painter.GroupPanel.DrawObject(info);
                button.LookAndFeel.Painter.Border.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, width - indent * 2, height - indent * 2);
                button.LookAndFeel.Painter.Button.DrawObject(info);
            }
            return image;
        }
        private void rgbiSkins_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e) {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
        }

        private void rgbiSkins_Gallery_InitDropDownGallery(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e) {
            e.PopupGallery.CreateFrom(rgbiSkins.Gallery);
            e.PopupGallery.AllowFilter = false;
            e.PopupGallery.ShowItemText = true;
            e.PopupGallery.ShowGroupCaption = true;
            e.PopupGallery.AllowHoverImages = false;
            foreach (GalleryItemGroup galleryGroup in e.PopupGallery.Groups)
                foreach (GalleryItem item in galleryGroup.Items)
                    item.Image = item.HoverImage;
            e.PopupGallery.ColumnCount = 2;
            e.PopupGallery.ImageSize = new Size(70, 36);
        }
        #endregion

        #region 模块调度
        private Dictionary<string, Form> openFormList = new Dictionary<string, Form>();//打开模块列表

        /// <summary>
        /// 打开模块方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doModule(object sender, EventArgs e) {
            Application.DoEvents();           

            DataRow row = sender as DataRow;
            mModule obj = ConvertHelper.RowToObject<mModule>(row);
            OpenModule(obj);
        }
        public void OpenModule(mModule obj)
        {
            //检查模块是否已经打开
            if (openFormList.ContainsKey(obj.Modu_ID))
            {
                openFormList[obj.Modu_ID].Activate();
                BeginInvoke(new MethodInvoker(endProgress));
                return;
            }
            object instance = null;//模块接口
            this.Cursor = Cursors.WaitCursor;
            try
            {
                object result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, this, ref instance);
                if (result is UserControl)
                {
                    instance = showControl(result as UserControl);
                }
                if (instance is FormBase)
                {
                    FormBase fb = instance as FormBase;
                    openFormList.Add(obj.Modu_ID, instance as FormBase);
                    ((FormBase)instance).Text = obj.ModuName;
                    ((FormBase)instance).FormClosed += frmMain_ChildFormClosed;
                    ((FormBase)instance).Tag = obj.Modu_ID;

                }
                this.Cursor = Cursors.Default;

            }
            catch (Exception err)
            {
                this.Cursor = Cursors.Default;
                BeginInvoke(new MethodInvoker(endProgress));
                MainHelper.ShowException(err);
            }
            BeginInvoke(new MethodInvoker(endProgress));
        }
        /// <summary>
        /// 模块关闭时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmMain_ChildFormClosed(object sender, FormClosedEventArgs e) {

            openFormList.Remove((sender as Form).Tag.ToString());
        }
        /// <summary>
        /// 显示用户控件方法
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private FormBase showControl(UserControl uc)
        {
            FormBase dlg = new FormBase();
            dlg.MdiParent = this;
            dlg.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dlg.Show();
            return dlg;
        }
        #endregion

        #region 用户模块初始
        /// <summary>
        /// 初始系统模块
        /// </summary>
        private void initNavBar() {
            navBarControl1.Groups.Clear();

            IList list = getUserModules();
            if (list.Count == 0) return;
            DataTable dt = ConvertHelper.ToDataTable(list);
            DataRow[] rows = dt.Select("parentid='0'", "Sequence");
            foreach (DataRow row in rows) {
                NavBarGroup sub1 = new NavBarGroup();
                sub1.Caption = row["ModuName"].ToString();
                sub1.SmallImageIndex = 24;
                sub1.LargeImageIndex = 24;
                //sub1.SmallImages = imageCollection2;
                navBarControl1.Groups.Add(sub1);
                DataRow[] progs = dt.Select("parentid='" + row["Modu_ID"] + "'", "Sequence");
                foreach (DataRow row2 in progs) {
                    NavBarItem bt1 = new NavBarItem();
                    bt1.Caption = row2["ModuName"].ToString();
                    bt1.LargeImageIndex = 27;
                    bt1.SmallImageIndex = 27;
                    bt1.LinkClicked += new NavBarLinkEventHandler(bt1_LinkClicked);
                    bt1.Tag = row2;
                    sub1.ItemLinks.Add(bt1);
                }
                if (sub1.Caption == "系统管理") sub1.Expanded = true;
                //if (sub1.Caption.IndexOf("业务")>-1) sub1.Expanded = true;
            }
            BeginInvoke(new MethodInvoker(endProgress));
        }
        void bt1_LinkClicked(object sender, NavBarLinkEventArgs e) {
            BeginInvoke(new MethodInvoker(beginProgress));
            BeginInvoke(new EventHandler(doModule), e.Link.Item.Tag, null);
        }
        void beginProgress() {
            btProgress.EditValue = 10;
            btProgress.Visibility = BarItemVisibility.Always;
            progress = 0;
        }
        void endProgress() {
            btProgress.EditValue = 100;

            //btProgress.Visibility = BarItemVisibility.Never;
        }
        /// <summary>
        /// 获取用户功能模块
        /// </summary>
        IList getUserModules() {
            //根据登录用户权限编写查询条件
            string sqlwhere = null;
            string str = MainHelper.PlatformSqlMap.GetConnectionString();
            return (IList)MainHelper.PlatformSqlMap.GetList<mModule>(sqlwhere);
        }
        public void InitNavBar(string userID)
        {
            navBarControl1.Groups.Clear();

            IList list = (IList)MainHelper.PlatformSqlMap.GetList<mModule>("SelectmModuleListByUserid", userID);
            DataTable dt = ConvertHelper.ToDataTable(list);
            DataRow[] rows = dt.Select("parentid='0'", "Sequence");
            foreach (DataRow row in rows)
            {
                NavBarGroup sub1 = new NavBarGroup();
                sub1.Caption = row["ModuName"].ToString();
                sub1.SmallImageIndex = 24;
                sub1.LargeImageIndex = 24;
                //sub1.SmallImages = imageCollection2;
                navBarControl1.Groups.Add(sub1);
                DataRow[] progs = dt.Select("parentid='" + row["Modu_ID"] + "'", "Sequence");
                foreach (DataRow row2 in progs)
                {
                    NavBarItem bt1 = new NavBarItem();
                    bt1.Caption = row2["ModuName"].ToString();
                    bt1.LargeImageIndex = 27;
                    bt1.SmallImageIndex = 27;
                    bt1.LinkClicked += new NavBarLinkEventHandler(bt1_LinkClicked);
                    bt1.Tag = row2;
                    sub1.ItemLinks.Add(bt1);
                }
                if (sub1.Caption == "系统管理") sub1.Expanded = true;
                //if (sub1.Caption.IndexOf("业务")>-1) sub1.Expanded = true;
            }
            //BeginInvoke(new MethodInvoker(endProgress));
        }
        /// <summary>
        /// 获取用户功能模块
        /// </summary>
        IList getUserModules(string userID)
        {
            //根据登录用户权限编写查询条件
            //string sqlwhere = string.Format("", userID);
            string str = MainHelper.PlatformSqlMap.GetConnectionString();
            return (IList)MainHelper.PlatformSqlMap.GetList<mModule>("SelectmModuleListByUserid", userID);
        }
        /// <summary>
        /// 刷新模块功能模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            //异步刷新数据
            BeginInvoke(new MethodInvoker(initNavBar));
        }
        #endregion 

        int progress = 0;
        int step = 20;
        void dotimer() {
            //btProgress.EditValue = (progress += step);
            //btProgress.Refresh(); Application.DoEvents();
        }
        void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            BeginInvoke(new MethodInvoker(dotimer));
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                this.InitNavBar(login.UserID);
                this.InitFunction(login.UserID);
                
                
            }
        }
        

        void InitFunction(string userID)
        {
            IList<VUserFunction> list = MainHelper.PlatformSqlMap.GetList<VUserFunction>(string.Format(" Where Empolyee_ID = '{0}'", userID));
            List<string> m_StrList = new List<string>();

            foreach(VUserFunction info in list)
            {
                m_StrList.Add(info.ModuTypes + "_" + info.FunctionName);
            }
            FormBase.UserFunction = m_StrList;
        }
    }
}
