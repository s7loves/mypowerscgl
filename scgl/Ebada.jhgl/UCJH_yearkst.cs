/**********************************************
系统:计划管理
模块:
作者:Rabbit
创建时间:2012-9-12
最后一次修改:2012-9-15
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Components;
using Ebada.Client;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.jhgl {
    /// <summary>
    /// 材料名称维护
    /// </summary>
    public partial class UCJH_yearkst : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<JH_yearkst> treeViewOperator;

        public TreeViewOperation<JH_yearkst> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        public event SendDataEventHandler<JH_yearkst> FocusedNodeChanged;
        public event SendDataEventHandler<JH_yearkst> AfterAdd;
        public event SendDataEventHandler<JH_yearkst> AfterEdit;
        public event SendDataEventHandler<JH_yearkst> AfterDelete;
        public UCJH_yearkst() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<JH_yearkst>(treeList1,barManager1,true);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit +=treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete +=treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            btOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btOK_ItemClick);
            treeViewOperator.BeforeDelete += new ObjectOperationEventHandler<JH_yearkst>(treeViewOperator_BeforeDelete);
        }

        void treeViewOperator_BeforeDelete(object render, ObjectOperationEventArgs<JH_yearkst> e) {
            if (e.Value.ID.Length < 10) {
                e.Cancel = true;
                MsgBox.ShowAskMessageBox("本记录是系统生成，不允许删除!");
            }
        }

        void btOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            btOKclick();
        }

        void treeList1_DoubleClick(object sender, EventArgs e) {
            btOKclick();
        }
        void btOKclick() {
            if (!ShowbtOK) return;
            if (treeList1.FocusedNode != null) {
                if (treeList1.FocusedNode.HasChildren) return;
                var obj = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as JH_yearkst;
                if (obj != null) this.ParentForm.DialogResult = DialogResult.OK;
            }
        }
        void treeViewOperator_AfterDelete(JH_yearkst newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(JH_yearkst newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(JH_yearkst newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
            treeList1.SetFocusedNode(treeList1.FindNodeByKeyID(newobj.ID));
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1,treeList1.GetDataRecordByNode(e.Node) as JH_yearkst);
        }

        void treeViewOperator_CreatingObject(JH_yearkst newobj) {
            string pid = getparentValue();
            TreeListNode pnode = null;
            newobj.结束日期 = DateTime.Today;
            newobj.开始日期 = DateTime.Today;
            newobj.年 = DateTime.Today.Year.ToString();
            newobj.标题 = "计划";
            
            if (treeList1.Selection[0] != null) {
                pnode = treeList1.Selection[0].ParentNode;

            }
            if (newobj.ParentID == pid) {//同级
                if (pnode != null)
                    Ebada.Core.ConvertHelper.CopyTo(pnode, newobj);
                //newobj.材料代码=getcode(pnode, pnode != null ? pnode.Nodes : treeList1.Nodes);
                
            } else {
                //newobj.材料代码 = getcode(treeList1.Selection[0], treeList1.Selection[0].Nodes);
            }
            //newobj.材料名称 = JH_yearkst.f_材料名称;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            //treeList1.Columns["序号"].SortOrder = SortOrder.Ascending;
            treeList1.Columns["年"].Caption = "年月周";
            treeList1.Columns["年"].VisibleIndex = 0;
            treeList1.Columns["标题"].VisibleIndex = 1;
            //treeList1.Columns["年"].OptionsColumn.AllowEdit = false;
            treeList1.Columns["c1"].Visible = false;
            treeList1.Columns["c2"].Visible = false;
            treeList1.Columns["c3"].Visible = false;
            treeList1.Columns["单位代码"].Visible = false;
            treeList1.Columns["单位名称"].Visible = false;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btFind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            InitData();
            buildyear(DateTime.Today.AddDays(30).Year);
            treeViewOperator.RefreshData("");
        }
        private void buildyear(int year) {

            //Client.ClientHelper.PlatformSqlMap.DeleteByWhere<JH_yearkst>(" where id like '" + year + "%'");
            JH_yearkst jh= Client.ClientHelper.PlatformSqlMap.GetOneByKey<JH_yearkst>(year.ToString());
            if (jh != null) return;
            string syear=year.ToString();
            JH_yearkst jh_year = new JH_yearkst() { 年 = syear, ID = syear, ParentID = "0", 标题 = syear + "年计划", 开始日期 = new DateTime(year, 1, 1), 结束日期 = new DateTime(year, 12, 31) };
            Client.ClientHelper.PlatformSqlMap.Create<JH_yearkst>(jh_year);
            JH_yearkst[] jh_months = new JH_yearkst[12];
            string smonth="";
            for (int i = 1; i <= 12; i++) {
                smonth=syear+i.ToString("00");
                //DateTime.Today.
                DateTime dt2 = new DateTime(i < 12 ? year : year + 1, i < 12 ? i+1 : 1, 1).AddDays(-1);
                jh_months[i - 1] = new JH_yearkst() { 年 = smonth, ID = smonth, ParentID = syear, 标题 = syear+"年"+i.ToString("00") + "月计划", 开始日期 = new DateTime(year,i, 1), 结束日期 = dt2 };
            }
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(jh_months, null, null);
            List<JH_yearkst> weeklist = new List<JH_yearkst>();
            string lastmonth = syear+"01";
            int index = 0;
            string[] weeks = new string[5] { "第一周", "第二周", "第三周", "第四周", "第五周" };
            for (int i = 1; i < 55; i++) {
                try {
                    DateTime date1=DateTime.Today;
                    DateTime date2=DateTime.Today;
                    string month= ConvertDate.GetWeekOfMonth(year, i, out date1, out date2);
                    string months = syear + "年" + month.Substring(4, 2) + "月";
                    if (lastmonth == month) {
                        index++;
                    } else {
                        index = 1;
                        lastmonth = month;
                    }
                    weeklist.Add(new JH_yearkst() { 年 = month + index, ID = month + index, ParentID = month, 标题 = months + weeks[index - 1] + "计划", 开始日期 = date1, 结束日期 = date2 });

                } catch { }
            }
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(weeklist.ToArray(), null, null);

        }
        //当天与该周星期一相差的天数
        private int getModdayNum(System.DayOfWeek dw) {
            int weeknow = Convert.ToInt32(dw);
            int moddayNum = (-1) * weeknow + 1;
            return moddayNum;
        }

        //当天与该周星期日相差的天数
        private int getSundayNum(System.DayOfWeek dw) {
            int weeknow = Convert.ToInt32(dw);
            int sundayNum = 7 - weeknow;
            return sundayNum;
        }

        //该周星期一的日期
        private string getWeekMonday(System.DayOfWeek dw, string timeFormateStr) {
            int weeknow = Convert.ToInt32(dw);
            int moddayNum = (-1) * weeknow + 1;
            string weekMonday = System.DateTime.Now.AddDays(moddayNum).Date.ToString(timeFormateStr);
            return weekMonday;
        }

        //该周星期日的日期
        private string getWeekSunday(System.DayOfWeek dw, string timeFormateStr) {
            int weeknow = Convert.ToInt32(dw);
            int sundayNum = 7 - weeknow;
            string weekSunday = System.DateTime.Now.AddDays(sundayNum).Date.ToString(timeFormateStr);
            return weekSunday;
        }

        //本周是本年第几周
        private int weekNum(System.DayOfWeek dw) {
            int weeknow = Convert.ToInt32(dw);//今天星期几
            int daydiff = (-1) * (weeknow + 1);//今日与上周末的天数差
            int days = System.DateTime.Now.AddDays(daydiff).DayOfYear;//上周末是本年第几天
            int weeks = days / 7;
            if (days % 7 != 0) {
                weeks++;
            }
            return (weeks + 2);
        }

        //调用方法
        
        string getparentValue() {
            string ret = "0";
            if (treeList1.Selection.Count > 0) {
                ret = treeList1.Selection[0][treeList1.ParentFieldName].ToString();
            }
            return ret;
        }
        
        string getcode(TreeListNode pnode, TreeListNodes nodes) {
            string code = "";
            int levenum = 3;
            //if (pnode != null && pnode.Level == 0) levenum = 4;
            string linecode = "";// pnode["LineCode"].ToString();
            if (pnode != null) {
                linecode = pnode["材料代码"].ToString();
                string sql = string.Format("Select max(材料代码) as LineCode from JH_yearkst where len(材料代码)={2} and Left(材料代码,{0})='{1}'", linecode.Length, linecode, linecode.Length + levenum);
                Hashtable ht = Client.ClientHelper.TransportSqlMap.GetObject("Select", sql) as Hashtable;
                if (ht != null && ht["LineCode"] != null) {
                    string childcode = ht["LineCode"].ToString();
                    if (!string.IsNullOrEmpty(childcode)) {
                        int maxcode = int.Parse(childcode.Substring(linecode.Length, levenum));
                        code = linecode + (maxcode + 1).ToString("000");
                    }
                }
            }
            if (code == "") {
                if (nodes.Count > 0) {
                    int maxcode = 0;
                    foreach (TreeListNode node in nodes) {
                        linecode = node["材料代码"].ToString();
                        maxcode = Math.Max(maxcode, int.Parse(linecode.Substring(linecode.Length - levenum, levenum)));
                    }
                    code = linecode.Substring(0, linecode.Length - levenum) + (maxcode + 1).ToString("000");
                } else {
                    if (pnode != null) {

                        code = pnode["材料代码"].ToString() + "001";
                    } else {
                        code = "001";
                    }
                }
            }

            return code;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData(" where 1>2");    
        }

        public bool ShowbtOK {
            get {
                return btOK.Visibility== DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set {
                btOK.Visibility = value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                if (value) {
                    bar3.Visible = true;
                    barStaticItem1.Caption = "";
                }

            }
        }
    }
}
