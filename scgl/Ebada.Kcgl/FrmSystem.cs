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
using Ebada.Core;
namespace Ebada.Kcgl {
    //public partial class FrmSystem : DevExpress.XtraEditors.XtraForm
    public partial class FrmSystem : Form {
        private string secondmenu = "";
        bool allowClose=false;
        Image topBackbmp;
        int topbarWidth;
        public FrmSystem() {

            InitializeComponent();
            //FormView.PaintAll(this);
            //FormView.PaintPicAll(picback);
            //FormView.PaintUP(pictureEdit1);

            this.Text = "绥化市郊农电局生产库存管理系统";
            topBackbmp =pictureEdit1.Image= ImageListRes.GetTop3();
            topbarWidth = pictureEdit1.Width;
            pictureEdit1.SizeChanged += new EventHandler(pictureEdit1_SizeChanged);
            labdate.Parent = pictureEdit1;
            labTime.Parent = pictureEdit1;
            labdate2.Parent = pictureEdit1;
            labSet.Parent = pictureEdit1;
            labExit.Parent = pictureEdit1;
            labdate2.Text = GetCNDate();
            labshow.Parent = panelControl1;

            //labshow.Parent = pictureEdit2;
            labdate.Text = DateTime.Now.ToString("m") + "" + DateTime.Now.ToString("dddd");
            
        }

        void pictureEdit1_SizeChanged(object sender, EventArgs e) {

            if (pictureEdit1.Width > topbarWidth) {
                Bitmap map = new Bitmap(pictureEdit1.Width, pictureEdit1.Height);
                Graphics g = Graphics.FromImage(map);
                Rectangle rect =new Rectangle(0,0,660,topBackbmp.Height);
                Rectangle rect2 = new Rectangle(660, 0,map.Width- (topbarWidth -680)-660, topBackbmp.Height);
                Rectangle rect3 = new Rectangle(map.Width- (topbarWidth -680), 0, topbarWidth - 680, topBackbmp.Height);
                g.DrawImage(topBackbmp,rect, 0, 0, 660, topBackbmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(topBackbmp, rect2, 660, 0, 20, topBackbmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(topBackbmp, rect3, 680, 0, rect3.Width, topBackbmp.Height, GraphicsUnit.Pixel);
                g.Dispose();
                pictureEdit1.Image = map;
            } else {
                pictureEdit1.Image = topBackbmp;
            }

        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Application.DoEvents();
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            this.BeginInvoke((MethodInvoker)delegate() { ClientHelper.TransportSqlMap.GetList<Model.kc_账套>(null); });
            frmLogin dlg = new frmLogin();
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (MainHelper.User.LoginID == "rabbit") {
                } else {
                    InitFunction(MainHelper.User.UserID);
                }
            } else {
                this.Close();
            }
        }
        void InitFunction(string userID) {
            try {
                ClientHelper.UserFuns = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select Modu_ID+'_'+funcode from vuserfun where userid='" + userID + "'");
            } catch { }
        }
        void test() {
            ClientHelper.TransportSqlMap.GetList<Model.kc_账套>(null);
        }
        private void FrmSystem_Load(object sender, EventArgs e) {
            CreateMenu();

        }
        DataTable progtable;
        private void CreateMenu() {
            nbctSystem.Groups.Clear();
            nbctSystem.Items.Clear();

            nbctSystem.LargeImages = ImageListRes.GetimageListAll(40, "");
            nbctSystem.SmallImages = ImageListRes.GetimageListAll(28, "");

            string sqlwhere = "where  Description='kcgl'  order by Sequence";
            IList<mModule> mlist = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(sqlwhere);

            DataTable table = progtable = Ebada.Core.ConvertHelper.ToDataTable((IList)mlist);

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
                    nbi.Hint = row["Sequence"].ToString();
                    nbctSystem.Items.Add(nbi);
                    nbg.ItemLinks.Add(nbi);
                }
                nbctSystem.Groups.Add(nbg);
                nbctSystem.Refresh();

            }
            if (nbctSystem.Groups.Count > 0 && nbctSystem.Groups[0].ItemLinks.Count > 0) {
                nbctSystem.Groups[0].ItemLinks[0].PerformClick();
                nbctSystem.Groups[0].SelectedLinkIndex = 0;
            }
        }


        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e) {
            listView1.Items.Clear();
            secondmenu = "";
            listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");
            mModule mdule = e.Group.Tag as mModule;
            //string slqwhrer2 = "where Description = 'system' and ParentID='" + mdule.Modu_ID + "'  order by Sequence";
            //IList<mModule> mlist2 = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(slqwhrer2);
            DataRow[] rows = progtable.Select("Description = 'kcgl' and ParentID='" + mdule.Modu_ID + "'", "Sequence");
            foreach (var item in rows) {
                mModule obj = ConvertHelper.RowToObject<mModule>(item);
                ListViewItem listItem = new ListViewItem();
                listItem.Text = obj.ModuName;
                listItem.Tag = obj;
                listItem.ImageKey = obj.IconName;
                listView1.Items.Add(listItem);
            }
            //显示上部位置名称
            labshow.Text = ">>" + mdule.ModuName;
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
        }
        //激活程序
        private void listView1_ItemActivate(object sender, EventArgs e) {
            mModule mdule = listView1.FocusedItem.Tag as mModule;
            //显示上部位置名称
            if (secondmenu == "") {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
            } else {
                labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + secondmenu + "->" + mdule.ModuName;
            }

            //显示下部说明
            labbuttom.Text = mdule.IsCores;
            if (mdule.ModuName.Contains("生产管理系统")) {
                //frmMain2 frm = new frmMain2();
                //frm.ShowDialog();
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
                object result = MainHelper.Execute(mdule.AssemblyFileName, mdule.ModuTypes, mdule.MethodName, null, null, ref instance);
                if (instance is Form) {
                    Form form = (Form)instance;
                    form.Tag = dic;
                    form.Show();
                } else {
                    this.Tag = dic;
                    showmodul(instance as UserControl, mdule.ModuName);
                }
            }
        }
        void showmodul(UserControl c, string text) {
            c.Dock = DockStyle.Fill;
            panel1.Controls.Add(c);
            panel1.Show();
            
            //Form dlg = new Form();
            //dlg.Text = text;
            //dlg.Size = new Size(800, 600);
            //dlg.StartPosition = FormStartPosition.CenterScreen;
            //dlg.Controls.Add(c); 
            //dlg.Show();
        }
        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = !allowClose;
            if (!allowClose) {
                panel1.Controls.Clear();
                panel1.Hide();
            }
            base.OnClosing(e);
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
            listView1.Items.Clear();
            listView1.LargeImageList = ImageListRes.GetimageListAll(60, "");
            DataRow[] rows = progtable.Select("Description = 'kcgl' and ParentID='" + mdule.Modu_ID + "'", "Sequence");
            foreach (var item in rows) {
                mModule obj = ConvertHelper.RowToObject<mModule>(item);
                ListViewItem listItem = new ListViewItem();
                listItem.Text = obj.ModuName;
                listItem.Tag = obj;
                listItem.ImageKey = obj.IconName;
                listView1.Items.Add(listItem);
            }
            //显示上部位置名称
            labshow.Text = ">>" + nbctSystem.ActiveGroup.Caption + "->" + mdule.ModuName;
            //显示下部说明
            labbuttom.Text = mdule.IsCores;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            labTime.Text = DateTime.Now.ToString("HH:mm");
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
            //frmModule frm = new frmModule();
            //frm.ShowDialog();
            //CreateMenu();
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

    }
}