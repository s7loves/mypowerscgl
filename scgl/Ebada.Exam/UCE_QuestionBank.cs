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
using System.Data.OleDb;

namespace Ebada.Exam {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCE_QuestionBank : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_QuestionBank> gridViewOperation;
        private string parentID = null;
        private E_QuestionBank parentObj;
        public event SendDataEventHandler<E_QuestionBank> FocusedRowChanged;

        public UCE_QuestionBank()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_QuestionBank>(gridControl1, gridView1, barManager1,new FrmE_QuestionBankEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_QuestionBank>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_QuestionBank>(gridViewOperation_BeforeDelete);
            barEproLuk.EditValueChanged += new EventHandler(barEproLuk_EditValueChanged);
            barTypeCom.EditValueChanged += new EventHandler(barTypeCom_EditValueChanged);
        }

        void barTypeCom_EditValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        void barEproLuk_EditValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }
        void Refresh()
        {
            string sql = " where ";
            if (barEproLuk.EditValue!=null)
            {
                sql += " Professional='" + barEproLuk.EditValue.ToString() + "'";
            }
            if (barTypeCom.EditValue!=null)
            {
                if (sql.Length>7)
                {
                    sql += " and ";
                }
                sql += " Type='" + barTypeCom.EditValue.ToString() + "'";
            }
            if (sql.Length>7)
            {
                sql += " order by Professional,Type";
            }
            RefreshData( sql);
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_QuestionBank> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_QuestionBank> e) {
              
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            barEproLuk.Edit = DicTypeHelper.E_proDic;
            InitData();//初始数据

            barTypeCom.EditValue = "单项选择题";
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }

        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            InitColumns();
            //RefreshData(" ");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            gridView1.Columns["Professional"].ColumnEdit = DicTypeHelper.E_proDic;
            gridView1.Columns["DifficultyLevel"].ColumnEdit = DicTypeHelper.E_QuestionBankDic;

            gridView1.Columns["Title"].Width = 400;
            gridView1.Columns["Option"].Width = 120;
            gridView1.Columns["Answer"].Width = 60;
            gridView1.Columns["Explain"].Width = 100;
            gridView1.Columns["DifficultyLevel"].Width = 60;
            gridView1.Columns["Professional"].Width = 90;
           


            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<E_QuestionBank> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_QuestionBank newobj) {
            if (barTypeCom.EditValue!=null)
            {
                newobj.Type = barTypeCom.EditValue.ToString();
            }
            if (barEproLuk.EditValue!=null)
            {
                newobj.Professional = barEproLuk.EditValue.ToString();
            }
            newobj.DifficultyLevel = 2;
            newobj.InTime = DateTime.Now;
            newobj.InUser = MainHelper.User.UserName;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where PID='" + value + "'");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<E_Professional> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }
        List<E_QuestionBank> eqbList = new List<E_QuestionBank>();
        //导入试题
        private void barbtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            eqbList.Clear();
            prodic.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            string filename = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            if (string.IsNullOrEmpty(filename))
                return;
           
            try
            {
                ReadExcel(filename);
            }
            catch
            {
                MsgBox.ShowWarningMessageBox("导入数据错误!请检查Excel文件格式!");
                return;
            }

            if (eqbList.Count > 0)
            {
                try
                {
                    foreach (E_QuestionBank yc in eqbList)
                    {
                        Client.ClientHelper.PlatformSqlMap.Create<E_QuestionBank>(yc);
                    }
                    MsgBox.ShowSuccessfulMessageBox("导入数据成功!");
                }
                catch (Exception ex)
                {
                    MsgBox.ShowWarningMessageBox("导入数据失败!");
                    //数据回滚
                    foreach (E_QuestionBank yc in eqbList)
                    {
                        Client.ClientHelper.PlatformSqlMap.Delete<E_QuestionBank>(yc);
                    }

                }
                finally
                {
                    eqbList.Clear(); 
                }
            }
            Refresh();
        }
       

        private void  ReadExcel(string sExcelFile)
        {
            DataTable ExcelTable;
            DataSet ds = new DataSet();
            //Excel的连接      
            OleDbConnection objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sExcelFile + ";" + "Extended Properties=Excel 8.0;");
            objConn.Open();
            DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                string tableName = schemaTable.Rows[i][2].ToString().Trim();//获取 Excel 的表名，默认值是sheet1    
                string strSql = "select * from [" + tableName + "]";
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                myData.Fill(ds, tableName);//填充数据      
                objConn.Close();
                ExcelTable = ds.Tables[tableName];
                if (tableName.Contains("判断"))
                {
                    JudgeDeal(ExcelTable);
                }
                else if (tableName.Contains("单项") || tableName.Contains("单选"))
                {
                    SelectDeal(ExcelTable);
                }
                else if (tableName.Contains("多项") || tableName.Contains("多选"))
                {
                    MuSelectDeal(ExcelTable);
                }
               
            }
        }
        //判断题
        private void JudgeDeal(DataTable dt)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                if (i == 1000)
                {
                    i = 0;
                }
                E_QuestionBank eq = new E_QuestionBank();
                if (dr["出题科室"].ToString().Trim()==string.Empty||dr["题目"].ToString().Trim()==string.Empty)
                {
                    continue;
                }
                eq.ID += i.ToString();
                eq.Type = "判断题";
                eq.Title = dr["题目"].ToString();
                eq.Answer = PDAnswerChange(dr["答案"].ToString());
                eq.Professional = ProfTurn(dr["出题科室"].ToString());
                eq.DifficultyLevel = DiLeverTurn(dr["难度等级"].ToString());
                eq.InTime = DateTime.Now;
                eq.InUser = MainHelper.User.UserName + "[导入]";
                eq.Sequence = OrderNumTurn(dr["题号"].ToString());
                if (dr["解释说明"]!=null)
                {
                    eq.Explain = dr["解释说明"].ToString();
                }
                if (eq.Title.Length > 5)
                {
                    eqbList.Add(eq);
                }
            }
        }
        //单项选择
        private void SelectDeal(DataTable dt)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                if (i == 1000)
                {
                    i = 0;
                }
                E_QuestionBank eq = new E_QuestionBank();
                 if (dr["出题科室"].ToString().Trim()==string.Empty||dr["题目"].ToString().Trim()==string.Empty)
                {
                    continue;
                }
                eq.ID += i.ToString();
                eq.Type = "单项选择题";
                eq.Title = dr["题目"].ToString();
                eq.Option = OperationTurn(dr["选项内容"].ToString());
                eq.Answer = SelectAnswwerTurn(dr["答案"].ToString());
                eq.Professional = ProfTurn(dr["出题科室"].ToString());
                eq.DifficultyLevel = DiLeverTurn(dr["难度等级"].ToString());
                eq.InTime = DateTime.Now;
                eq.InUser = MainHelper.User.UserName + "[导入]";
                eq.Sequence = OrderNumTurn(dr["题号"].ToString());
                if (dr["解释说明"] != null)
                {
                    eq.Explain = dr["解释说明"].ToString();
                }
                if (eq.Title.Length>5)
                {
                    eqbList.Add(eq);
                }
               
            }
        }
        //多项选择题
        private void MuSelectDeal(DataTable dt)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                if (i == 1000)
                {
                    i = 0;
                }
                E_QuestionBank eq = new E_QuestionBank();
                 if (dr["出题科室"].ToString().Trim()==string.Empty||dr["题目"].ToString().Trim()==string.Empty)
                {
                    continue;
                }
                eq.ID += i.ToString();
                eq.Type = "多项选择题";
                eq.Title = dr["题目"].ToString();
                eq.Option = OperationTurn(dr["选项内容"].ToString());
                eq.Answer = (dr["答案"].ToString());
                eq.Professional = ProfTurn(dr["出题科室"].ToString());
                eq.DifficultyLevel = DiLeverTurn(dr["难度等级"].ToString());
                eq.InTime = DateTime.Now;
                eq.InUser = MainHelper.User.UserName + "[导入]";
                eq.Sequence = OrderNumTurn(dr["题号"].ToString());
                if (dr["解释说明"] != null)
                {
                    eq.Explain = dr["解释说明"].ToString();
                }
                if (eq.Title.Length > 5)
                {
                    eqbList.Add(eq);
                }
            }
        }
        /// <summary>
        /// 判断答案转换
        /// </summary>
        /// <param name="oldanswer"></param>
        /// <returns></returns>
        private string PDAnswerChange(string oldanswer)
        {
            string result = "False";
            if (oldanswer.Contains("√"))
            {
                result = "True";
            }
            else if (oldanswer.Contains("×"))
            {
                result = "False";
            }
            return result;
        }
        /// <summary>
        /// 根据专业名称，返回专业ID
        /// </summary>
        private Dictionary<string, string> prodic = new Dictionary<string, string>();
        private string ProfTurn(string proname)
        {
            string strresult = string.Empty;
            proname = proname.Trim();
            if (prodic.Count==0)
            {
                IList<E_Professional> prolist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
                foreach (E_Professional item in prolist)
                {
                    if (!prodic.ContainsKey(item.PName))
                    {
                        prodic.Add(item.PName, item.ID);
                    }
                }
            }
            if (prodic.ContainsKey(proname))
            {
                strresult = prodic[proname];
            }
            else
            {
                E_Professional pro = new E_Professional();
                pro.PName = proname;
                prodic.Add(proname, pro.ID);
                Client.ClientHelper.PlatformSqlMap.Create<E_Professional>(pro);
                strresult = pro.ID;
            }
            return strresult;
        }
        /// <summary>
        /// 难道转换,最大值为5，默认值为2
        /// </summary>
        /// <param name="strlevel"></param>
        /// <returns></returns>
        private int DiLeverTurn(string strlevel)
        {
            int num = 2;
            int.TryParse(strlevel, out num);
            if (num>5)
            {
                num = 5;
            }
            if (num<=0)
            {
                num = 1;
            }
            return num;
        }
        /// <summary>
        /// 顺序号转变
        /// </summary>
        /// <param name="strorder"></param>
        /// <returns></returns>
        private int OrderNumTurn(string strorder)
        {
            int num = 0;
            int.TryParse(strorder, out num);
            return num;
        }
        /// <summary>
        /// 处理选项
        /// </summary>
        string spchar="@";
        private string OperationTurn(string stroperation)
        {
            
           stroperation= stroperation.Replace(spchar, "");

           stroperation=stroperation.Replace("A:", "");
           stroperation=stroperation.Replace("A：", "");
           
            if (stroperation.Contains("B:"))
            {
                stroperation=stroperation.Replace("B:", spchar);
            }
            if (stroperation.Contains("B："))
            {
               stroperation= stroperation.Replace("B：", spchar);
            }

            if (stroperation.Contains("C:"))
            {
                stroperation = stroperation.Replace("C:", spchar);
            }
            if (stroperation.Contains("C："))
            {
                stroperation = stroperation.Replace("C：", spchar);
            }

            if (stroperation.Contains("D:"))
            {
                stroperation = stroperation.Replace("D:", spchar);
            }
            if (stroperation.Contains("D："))
            {
                stroperation = stroperation.Replace("D：", spchar);
            }

            if (stroperation.Contains("E:"))
            {
                stroperation = stroperation.Replace("E:", spchar);
            }
            if (stroperation.Contains("E："))
            {
                stroperation = stroperation.Replace("E：", spchar);
            }

            if (stroperation.Contains("F:"))
            {
                stroperation = stroperation.Replace("F:", spchar);
            }
            if (stroperation.Contains("F："))
            {
                stroperation = stroperation.Replace("F：", spchar);
            }
            stroperation =  stroperation.Replace(" ", "");
            stroperation = stroperation.Replace(" ", "");
            stroperation = stroperation.Replace(" ", "");

            return stroperation;
          
        }

        /// <summary>
        /// 处理单项选择答案，如果有多个，则选第一个，如果没有则默认为
        /// A
        /// </summary>
        /// <param name="ansewer"></param>
        /// <returns></returns>
        private string SelectAnswwerTurn(string ansewer)
        {
            ansewer = ansewer.Trim();
            string strresult = "A";
            if (ansewer.Length>1)
            {
                strresult = ansewer.Substring(0, 1);
            }
            else if (ansewer.Length==1)
            {
                strresult = ansewer;
            }

            return strresult;
        }

    }
}
