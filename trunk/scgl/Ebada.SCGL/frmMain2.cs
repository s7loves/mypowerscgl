﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Ebada.Client.Platform;
using Ebada.UI.Base;
using Ebada.Platform.Model;

namespace Ebada.SCGL
{
    public partial class frmMain2 : DevExpress.XtraEditors.XtraForm
    {
        public frmMain2()
        {
            InitializeComponent();
            InitSkins();
            ucModulBar1.RefreshData("");
            ucModulBar1.PlatForm = this;
        }
        #region Skins
        string skinMask = "Office 2010";
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
                MainHelper.ShowException(err);
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.showControl(new sample1.MudleTreeManager());
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucModulBar1.RefreshData("");
        }

    }
}
