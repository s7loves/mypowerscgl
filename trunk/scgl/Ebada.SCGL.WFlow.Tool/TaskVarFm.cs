using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;


namespace Ebada.SCGL.WFlow.Tool
{
    
	/// <summary>
	/// TaskVarFm 的摘要说明。
	/// </summary>
	public class fmTaskVar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCanel;
		private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        public ComboBox cbxAccessType;
        private System.Windows.Forms.Label label8;
        public ComboBox cbxVarType;
        public ComboBox cbxVarModule;
        public TextBox tbxIniValue;
        public TextBox tbxVarName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;

        public string TaskVarId = "";
        private Button btnTest;
        public ComboBox cbxTableColumns;
        public ComboBox cbxDataTable;
        public string fmSate = "";
        public string varDataBaseName = "";
        public string varDataTableName = "";
        public string varTableColumnName = "";
		public fmTaskVar(string sate)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            fmSate = sate;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCanel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxDataTable = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxAccessType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxVarType = new System.Windows.Forms.ComboBox();
            this.cbxVarModule = new System.Windows.Forms.ComboBox();
            this.tbxIniValue = new System.Windows.Forms.TextBox();
            this.tbxVarName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCanel
            // 
            this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanel.Location = new System.Drawing.Point(320, 209);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 22);
            this.btnCanel.TabIndex = 20;
            this.btnCanel.Text = "取消";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(239, 209);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 22);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxTableColumns);
            this.groupBox1.Controls.Add(this.cbxDataTable);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxAccessType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxVarType);
            this.groupBox1.Controls.Add(this.cbxVarModule);
            this.groupBox1.Controls.Add(this.tbxIniValue);
            this.groupBox1.Controls.Add(this.tbxVarName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 187);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // cbxTableColumns
            // 
            this.cbxTableColumns.FormattingEnabled = true;
            this.cbxTableColumns.Location = new System.Drawing.Point(84, 131);
            this.cbxTableColumns.Name = "cbxTableColumns";
            this.cbxTableColumns.Size = new System.Drawing.Size(168, 20);
            this.cbxTableColumns.TabIndex = 28;
            // 
            // cbxDataTable
            // 
            this.cbxDataTable.FormattingEnabled = true;
            this.cbxDataTable.Location = new System.Drawing.Point(84, 106);
            this.cbxDataTable.Name = "cbxDataTable";
            this.cbxDataTable.Size = new System.Drawing.Size(168, 20);
            this.cbxDataTable.TabIndex = 27;
            this.cbxDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxDatatable_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(312, 154);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(74, 23);
            this.btnTest.TabIndex = 25;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(186, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "变量名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAccessType
            // 
            this.cbxAccessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccessType.Items.AddRange(new object[] {
            "请选择",
            "流程变量",
            "任务变量"});
            this.cbxAccessType.Location = new System.Drawing.Point(66, 62);
            this.cbxAccessType.Name = "cbxAccessType";
            this.cbxAccessType.Size = new System.Drawing.Size(120, 20);
            this.cbxAccessType.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "访问类型";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxVarType
            // 
            this.cbxVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVarType.Items.AddRange(new object[] {
            "int",
            "float",
            "double",
            "string",
            "datetime",
            "bool"});
            this.cbxVarType.Location = new System.Drawing.Point(266, 15);
            this.cbxVarType.Name = "cbxVarType";
            this.cbxVarType.Size = new System.Drawing.Size(120, 20);
            this.cbxVarType.TabIndex = 10;
            // 
            // cbxVarModule
            // 
            this.cbxVarModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVarModule.Items.AddRange(new object[] {
            "in",
            "out"});
            this.cbxVarModule.Location = new System.Drawing.Point(266, 39);
            this.cbxVarModule.Name = "cbxVarModule";
            this.cbxVarModule.Size = new System.Drawing.Size(120, 20);
            this.cbxVarModule.TabIndex = 9;
            // 
            // tbxIniValue
            // 
            this.tbxIniValue.Location = new System.Drawing.Point(66, 39);
            this.tbxIniValue.Name = "tbxIniValue";
            this.tbxIniValue.Size = new System.Drawing.Size(120, 21);
            this.tbxIniValue.TabIndex = 8;
            // 
            // tbxVarName
            // 
            this.tbxVarName.Location = new System.Drawing.Point(66, 15);
            this.tbxVarName.Name = "tbxVarName";
            this.tbxVarName.Size = new System.Drawing.Size(120, 21);
            this.tbxVarName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "初始值";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(210, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "变量模式";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "表字段";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(210, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "表名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fmTaskVar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(416, 246);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmTaskVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量";
            this.Load += new System.EventHandler(this.fmTaskVar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
       

       
        private void initData()
        {

            if (cbxVarType.SelectedIndex < 0) cbxVarType.SelectedIndex = 0;//默认值
            if (cbxVarModule.SelectedIndex<0) cbxVarModule.SelectedIndex=0;
            //ClientDBAgent agent = new ClientDBAgent();
            //DataTable dt = agent.GetDBDataTable(varDataBaseName);
            //WinFormFun.LoadComboBox(cbxDataTable, dt, "name", "name");
            //varDataBaseName = agent.GetCurrentDatabaseName();
            //DataTable dtrow = agent.GetDTColumnsDataTable(varDataTableName, varDataBaseName);
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableName", "  where type = 'U' and  1=1 order by name");
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxDataTable, dt, "name", "name");
            if (varDataTableName != "")
            {
                li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", varDataTableName);
                DataTable dtrow = null;
                if (li.Count > 0)
                    dtrow = ConvertHelper.ToDataTable(li);
                else
                    dtrow = new DataTable();
                WinFormFun.LoadComboBox(cbxTableColumns, dtrow, "name", "name");
            }
            else
            {
                DataTable dtrow =  new DataTable ();
                WinFormFun.LoadComboBox(cbxTableColumns, dtrow, "name", "name");
            }
            if (fmSate == WorkConst.STATE_MOD)
            {
                cbxDataTable.Text = varDataTableName;
                cbxTableColumns.Text = varTableColumnName;
            }
          
        }
        private void cbxDatatable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDataTable.SelectedIndex == 0) return;
            //ClientDBAgent agent = new ClientDBAgent();
            //DataTable dt = agent.GetDTColumnsDataTable(cbxDataTable.SelectedItem.ToString(), varDataBaseName);
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", cbxDataTable.SelectedItem.ToString() );
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxTableColumns, dt, "name", "name");
            cbxTableColumns.SelectedIndex = 0;
            
        }

       

        private void fmTaskVar_Load(object sender, EventArgs e)
        {
            initData();
        }

       
        private bool checkValue()
        {
            if (cbxDataTable.SelectedIndex == 0) return false;
            if (cbxTableColumns.SelectedIndex == 0) return false;
            return true;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (checkValue() == false)
            {
                MsgBox.ShowTipMessageBox("表名或者字段!!");
                return;
            }
            try
            {
                //string sql = "select   " + cbxTableColumns.SelectedItem.ToString() + " from " + cbxDataTable.SelectedItem.ToString() +
                //    " where 1=2 ";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteQuery(sqlItem);
                string sql = "select   " + cbxTableColumns.SelectedItem.ToString() + " from " + cbxDataTable.SelectedItem.ToString() +
                    " where 1=2 ";
                 MainHelper.PlatformSqlMap.GetList("GetTableName2", sql);
                MsgBox.ShowTipMessageBox("测试连接成功!!");
            }
            catch(Exception ex)
            {
                MsgBox.ShowWarningMessageBox("测试连接失败:" + ex.Message.ToString());
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

       

      

       
	}
}
