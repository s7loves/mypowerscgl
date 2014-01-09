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
using Ebada.Core;
using Ebada.SCGL.Properties;
using Ebada.UI.Base;
namespace Ebada.SCGL {
    //public partial class FrmSystem : DevExpress.XtraEditors.XtraForm
    public partial class FrmSystem : Form {
        private string secondmenu = "";
        bool allowClose = false;
        Image topBackbmp;
        int topbarWidth;
        private Panel panel1;
        public FrmSystem() {

            InitializeComponent();
            createPanel();
            panelControl1.Anchor |= AnchorStyles.Right;
            //FormView.PaintAll(this);
            //FormView.PaintPicAll(picback);


            this.Text = string.Format("-{0}信息管理平台", MainHelper.UserCompany); //
            topBackbmp = pictureEdit1.Image = ImageListRes.GetTop2();
            topbarWidth = pictureEdit1.Width;
            pictureEdit1.SizeChanged += new EventHandler(pictureEdit1_SizeChanged);
            labdate.Parent = pictureEdit1;
            labTime.Parent = pictureEdit1;
            lagtx.Parent = pictureEdit1;
            labdate2.Parent = pictureEdit1;
            labSet.Parent = pictureEdit1;
            labExit.Parent = pictureEdit1;
            labdate2.Text = GetCNDate();
            //labshow.Parent = panelControl1;
            labSet.Hide();
            //labshow.Parent = pictureEdit2;
            labdate.Text = DateTime.Now.ToString("m") + "" + DateTime.Now.ToString("dddd");
            timer1.Start();
            listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");

            this.MinimumSize = this.Size;
            this.Size = Settings.Default.frmSystemSize;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            
        }
        void pictureEdit1_SizeChanged(object sender, EventArgs e) {

            if (pictureEdit1.Width > topbarWidth) {
                Bitmap map = new Bitmap(pictureEdit1.Width, pictureEdit1.Height);
                Graphics g = Graphics.FromImage(map);
                Rectangle rect = new Rectangle(0, 0, 660, topBackbmp.Height);
                Rectangle rect2 = new Rectangle(660, 0, map.Width - (topbarWidth - 680) - 660, topBackbmp.Height);
                Rectangle rect3 = new Rectangle(map.Width - (topbarWidth - 680), 0, topbarWidth - 680, topBackbmp.Height);
                g.DrawImage(topBackbmp, rect, 0, 0, 660, topBackbmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(topBackbmp, rect2, 660, 0, 20, topBackbmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(topBackbmp, rect3, 680, 0, rect3.Width, topBackbmp.Height, GraphicsUnit.Pixel);
                g.Dispose();
                pictureEdit1.Image = map;
            } else {
                pictureEdit1.Image = topBackbmp;
            }
            FormView.PaintUP(pictureEdit1);
        }
        void createPanel() {
            panel1 = new Panel();
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(205, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 343);
            this.panel1.TabIndex = 28;
            this.panel1.Visible = false;
            this.Controls.Add(panel1);
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Application.DoEvents();
            //timer1.Start();

            
            //this.BeginInvoke((MethodInvoker)delegate() { ClientHelper.TransportSqlMap.GetList<Model.kc_账套>(null); });
            frmLogin dlg = new frmLogin();
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (MainHelper.User.LoginID == "rabbit") {
                    labSet.Show();
                } else {
                    CreateMenu();
                    InitFunction(MainHelper.User.UserID);
                }
                //this.WindowState = FormWindowState.Maximized;
            } else {
                allowClose = true;
                this.Close();
            }
            try
            {
                if (Ebada.Scgl.Yxgl.UCWarnRecordPage.IsNeedTX(MainHelper.UserOrg))
                {
                    lagtx.Visible = true;
                }
                else
                {
                    lagtx.Visible = true;
                }
            }
            catch 
            {
                
            }
            
        }
        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = !allowClose;
            if (!allowClose) {
                panel1.Controls.Clear();
                panel1.Hide();
            }
            base.OnClosing(e);
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            if (this.WindowState == FormWindowState.Normal) {
                Settings.Default.frmSystemSize = this.Size;
                Settings.Default.Save();
            }
        }
        void InitFunction(string userID) {
            try {
                ClientHelper.UserFuns = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select Modu_ID+'_'+funcode from vuserfun where userid='" + userID + "'");
            } catch { }
        }
        private void FrmSystem_Load(object sender, EventArgs e) {
            
            nbctSystem.LargeImages = ImageListRes.GetimageListAll(40, "");
            nbctSystem.SmallImages = ImageListRes.GetimageListAll(28, "");
            CreateMenu();

        }
        DataTable moduleTable;
        private void CreateMenu() {
            nbctSystem.Groups.Clear();
            nbctSystem.Items.Clear();
            listView1.Items.Clear();
            string sqlwhere = "where   Description='system'  order by Sequence";

            if (!string.IsNullOrEmpty(MainHelper.LoginName)) {

                sqlwhere = "where (visiableflag='true' or parentid='0') and Description='" + "system" + "'" + "and Modu_ID in (select distinct modu_id from vusermodule where userid='" + MainHelper.User.UserID + "')" + "  order by Sequence ";

            }
            IList<mModule> mlist = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(sqlwhere);
            if (mlist == null || mlist.Count == 0) return;
            moduleTable = Ebada.Core.ConvertHelper.ToDataTable((IList)mlist);
            DataTable table = moduleTable;

            DataRow[] Rows = table.Select(string.Format("ParentID='{0}'", "0"));

            foreach (DataRow row in Rows) {
                DevExpress.XtraNavBar.NavBarGroup nbg = new DevExpress.XtraNavBar.NavBarGroup();
                nbg.Name = row["ModuName"].ToString();
                nbg.Tag = Ebada.Core.ConvertHelper.RowToObject<mModule>(row);
                nbg.Caption = row["ModuName"].ToString();
                nbg.LargeImage = ((ImageList)nbctSystem.LargeImages).Images[row["IconName"].ToString()];

                DataRow[] Rows2 = table.Select(string.Format(" ParentID='{0}'", row["Modu_ID"].ToString()));
                foreach (DataRow row2 in Rows2) {
                    DevExpress.XtraNavBar.NavBarItem nbi = new DevExpress.XtraNavBar.NavBarItem();
                    nbi.Name = row2["ModuName"].ToString();
                    nbi.Tag = Ebada.Core.ConvertHelper.RowToObject<mModule>(row2);
                    nbi.Caption = row2["ModuName"].ToString();
                    nbi.SmallImage = ((ImageList)nbctSystem.SmallImages).Images[row2["IconName"].ToString()];
                    //nbi.Hint = row["Sequence"].ToString();
                    nbctSystem.Items.Add(nbi);
                    nbg.ItemLinks.Add(nbi);
                }
                nbctSystem.Groups.Add(nbg);
                nbctSystem.Refresh();

            }


        }
      
        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e) {
            secondmenu = "";
            mModule mdule = e.Group.Tag as mModule;
            createListView(mdule);

            //显示上部位置名称
            labshow.Text = ">>" + mdule.ModuName;
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
        }
        void createListView(mModule m) {
            if (m == null) return;
            listView1.Items.Clear();

            //listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");
            mModule mdule = m;
            string slqwhrer2 = "ParentID='" + mdule.Modu_ID + "'";//order by Sequence
            DataRow[] rows = moduleTable.Select(slqwhrer2, "Sequence");
            //IList<mModule> mlist2 = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(slqwhrer2);
            for (int j = 0; j < rows.Length; j++) {
                mModule obj = ConvertHelper.RowToObject<mModule>(rows[j]);
                ListViewItem listItem = new ListViewItem();
                listItem.Text = obj.ModuName.ToString();
                listItem.Tag = obj;
                listItem.ImageKey = obj.IconName.ToString();

                //listItem.BackColor = System.Drawing.Color.Blue;
                listView1.Items.Add(listItem);
            }
        }
        //激活程序
        private void listView1_ItemActivate(object sender, EventArgs e) {
            mModule mdule = listView1.FocusedItem.Tag as mModule;
            if(showForms.ContainsKey(mdule.Modu_ID)){
                Form form=showForms[mdule.Modu_ID];
                form.WindowState = FormWindowState.Maximized;
                
                return;
            }
            //显示上部位置名称
            if (secondmenu == "") {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
            } else {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + secondmenu + "->" + mdule.ModuName;
            }

            //显示下部说明
            labbuttom.Text = mdule.IsCores;
            if (mdule.ModuName.Contains("生产管理系统")) {
                frmMain2 frm = new frmMain2();
                frm.ShowDialog();
                return;
            }
            if (mdule == null || string.IsNullOrEmpty(mdule.ModuTypes))
                return;

            string exe = mdule.ModuTypes;
            if (mdule.ModuTypes.ToLower().Contains(".exe")) {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + exe);
            } else if (mdule.ModuTypes.ToLower().Contains("http")) {
                System.Diagnostics.Process.Start(exe);
            } else {
                object instance = null;
                object[] para = new object[1];
                para.SetValue(mdule, 0);
                para = new object[0];
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("Modu_ID", mdule.Modu_ID);
                object[] p = null;
                object result = null;
                if (!string.IsNullOrEmpty(mdule.MethodParam)) {
                    p = new object[] { mdule.MethodParam };
                    result = MainHelper.Execute(mdule.AssemblyFileName, mdule.ModuTypes, mdule.MethodName, p);
                } else {
                    result = MainHelper.Execute(mdule.AssemblyFileName, mdule.ModuTypes, mdule.MethodName, null, null, ref instance);
                }
                if (instance is Form) {
                    Form form = (Form)instance;
                    form.Tag = dic;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.WindowState = FormWindowState.Maximized;
                    form.Owner = this;
                    form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    showForms.Add(mdule.Modu_ID,form);
                    form.Show();
                } else if(instance is Control) {
                    this.Tag = dic;
                    showmodul(instance as UserControl, mdule.ModuName);
                } else if (result is Control) {
                    this.Tag = dic;
                    showmodul(result as UserControl, mdule.ModuName);
                }
            }
        }

        void form_FormClosed(object sender, FormClosedEventArgs e) {
            Form form = sender as Form;
            foreach(var item in showForms){
                if (item.Value == form) {
                    showForms.Remove(item.Key); break;
                }
            }
        }
        Dictionary<string, Form> showForms = new Dictionary<string, Form>();
        void showmodul(UserControl c, string text) {
            c.Dock = DockStyle.Fill;
            panel1.Controls.Add(c);
            panel1.Show();
            panel1.BringToFront();
        }
        private void nbctSystem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {

            CreateListView(e.Link.Item);
            if (panel1.Visible) {
                panel1.Controls.Clear();
                panel1.Hide();
            }
        }

        private void CreateListView(DevExpress.XtraNavBar.NavBarItem nbi) {
            mModule mdule = nbi.Tag as mModule;
            secondmenu = mdule.ModuName;
            if (mdule == null)
                return;
            createListView(mdule);
            //显示上部位置名称
            labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
        }

        int tempindex = 0;
        private void timer1_Tick(object sender, EventArgs e) {
            labTime.Text = DateTime.Now.ToString("HH:mm");
            if (lagtx.Visible)
            {
                tempindex++;
                if (tempindex==15)
                {
                    tempindex = 0;
                    lagtx.Text = "";
                    lagtx.ImageIndex = -1;
                }
                else
                {
                    lagtx.ImageIndex = 1;
                    lagtx.Text = "提醒";
                }
            }
        }
        //显示农历日期
        string GetCNDate() {
            DateTime m_Date; //今天的日期
            int cny; //农历的年月日
            int cnm; //农历的年月日
            int cnd; //农历的年月日
            int icnm; //农历闰月

            m_Date = DateTime.Today;
            ChineseLunisolarCalendar cnCalendar = new ChineseLunisolarCalendar();
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
            if (icnm > 0) {
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

        private void labSet_Click(object sender, EventArgs e) {
            frmModule frm = new frmModule();
            frm.ShowDialog();
            CreateMenu();
        }

        private void labExit_Click(object sender, EventArgs e) {
            allowClose = true;
            this.Close();
        }

        private void labSet_MouseEnter(object sender, EventArgs e) {
            labSet.BackColor = Color.YellowGreen;
        }

        private void labSet_MouseLeave(object sender, EventArgs e) {
            labSet.BackColor = Color.Transparent;
        }

        private void labExit_MouseEnter(object sender, EventArgs e) {
            labExit.BackColor = Color.Red;
        }

        private void labExit_MouseLeave(object sender, EventArgs e) {
            labExit.BackColor = Color.Transparent;
        }

        #region 美化窗体
        private bool m_isMouseDown = false;
        private Point m_mousePos = new Point();
        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e) {
            base.OnMouseDown(e);
            m_mousePos = Cursor.Position;
            m_isMouseDown = true;
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e) {
            this.Cursor = Cursors.Hand;
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e) {
            this.Cursor = Cursors.Default;
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e) {
            base.OnMouseMove(e);
            if (m_isMouseDown) {
                Point tempPos = Cursor.Position;
                this.Location = new Point(Location.X + (tempPos.X - m_mousePos.X), Location.Y + (tempPos.Y - m_mousePos.Y));
                m_mousePos = Cursor.Position;
            }
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e) {
            base.OnMouseUp(e);
            m_isMouseDown = false;
        }


        #endregion

        private void lagtx_Click(object sender, EventArgs e)
        {
            Ebada.Scgl.Yxgl.FrmWarnRecord frm = new Ebada.Scgl.Yxgl.FrmWarnRecord();
            frm.ShowDialog();
        }

       

    }
}