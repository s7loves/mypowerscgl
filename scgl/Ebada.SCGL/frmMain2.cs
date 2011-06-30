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
        }
        #region Skins
        string skinMask = "Office 2010";
        BarSubItem iPaintStyle;
        void InitSkins()
        {
            barManager1.ForceInitialize();
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
            iPaintStyle.Caption ="皮肤："+ e.Item.Caption;
            iPaintStyle.Hint = iPaintStyle.Caption;
            iPaintStyle.ImageIndex = -1;
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
                MsgBox.ShowException(err);
            }
        }
        /// <summary>
        /// 模块关闭时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmMain_ChildFormClosed(object sender, FormClosedEventArgs e)
        {

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
        #region 加载菜单
        internal void InitMenu(string userid)
        {
            bar2.ItemLinks.Clear();
            
            IList list = (IList)MainHelper.PlatformSqlMap.GetList<mModule>("where ModuTypes != 'hide'");
            DataTable dt = Ebada.Core.ConvertHelper.ToDataTable(list);
            DataRow[] rows = dt.Select("parentid='0'", "Sequence");
            createMenu(bar2, rows, dt);
            //BarSubItem iPaintStyle = new BarSubItem(barManager1, "皮肤");
            //iPaintStyle.Name = "iPaintStyle";
            bar2.AddItem(iPaintStyle);

            //InitSkins();
        }
        void createMenu(BarLinksHolder bc, DataRow[] rows, DataTable dt)
        {
            foreach (DataRow row in rows)
            {
                DataRow[] progs = dt.Select("parentid='" + row["Modu_ID"] + "' and visiableflag=1", "Sequence");
                if (progs.Length > 0)
                {
                    BarSubItem sub1 = new BarSubItem(barManager1,row["ModuName"].ToString());
                    createMenu(sub1, progs, dt);
                    bc.AddItem(sub1);
                }
                else
                {
                    BarButtonItem bt = new BarButtonItem(barManager1,row["ModuName"].ToString());
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
            this.showControl(new sample1.MudleTreeManager()).Text="模块登记";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MainHelper.MainForm = this;
            InitSkins();
            btLogin_ItemClick(null, null);
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucModulBar1.RefreshData("where ModuTypes != 'hide'"); InitMenu("");
        }

        private void btLogin_ItemClick(object sender, ItemClickEventArgs e) {
            frmLogin dlg = new frmLogin();
            if (dlg.ShowDialog() == DialogResult.OK) {
                barStaticItem2.Caption = string.Format("部门：{0}操作员：{1}" ,MainHelper.User.OrgName, MainHelper.User.UserName);
                InitMenu(MainHelper.User.UserID);
                ucModulBar1.RefreshData("where ModuTypes != 'hide'");
                ucModulBar1.SetImage();
                if (MainHelper.User.LoginID == "rabbit") {
                    barButtonItem1.Visibility = BarItemVisibility.Always;
                    barButtonItem2.Visibility = BarItemVisibility.Always;
                }
                
            } else {
#if DEBUG
                ucModulBar1.RefreshData("where ModuTypes != 'hide'");
                ucModulBar1.SetImage();
#endif
            }
            barButtonItem3.Enabled = (dlg.DialogResult == DialogResult.OK);
            
        }

        private void btClose_ItemClick(object sender, ItemClickEventArgs e) {
            if (Client.MsgBox.ShowAskMessageBox("是否退出系统？") == DialogResult.OK) {
                this.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) {
            //锁屏
            
            Client.Platform.FormPasswordValidation dlg = new FormPasswordValidation();
            dlg.Owner = this;
            dlg.ShowInTaskbar = false;
            while (true) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    break;
                } else {
                    if (Client.MsgBox.ShowAskMessageBox("是否退出系统？") == DialogResult.OK) {
                        this.Close();
                        break;
                    }
                }
            }
        }

    }
}
