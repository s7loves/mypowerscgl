using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// 新加功能流程导出
	/// leg 设计编码 
	/// </summary>
	public class fmWorkflowExport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gbxOne;
		private System.Windows.Forms.Button btnFilePath;
		private System.Windows.Forms.GroupBox gbxReult;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnClose;
		public string exportGuid;//导出流程的guid 主建
		public string exportName;//导出的流程名
		private string exportFileName;
		private System.Windows.Forms.RadioButton rbtnAll;
		private System.Windows.Forms.RadioButton rbtnWorkFlow;
		private System.Windows.Forms.TextBox tbxFilePath;
		private System.Windows.Forms.Label lbStep;//导出的路径文件名 
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmWorkflowExport(string iExportGuid,string iexportName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			exportGuid=iExportGuid;
			exportName=iexportName;

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
		/// <summary>
		/// 进度条
		/// </summary>
		/// <param name="iMessage"></param>
		private void progressShow(string iMessage)
		{
			progressBar1.PerformStep();
			lbStep.Text="正在导出："+iMessage;

		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnWorkFlow = new System.Windows.Forms.RadioButton();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.gbxReult = new System.Windows.Forms.GroupBox();
            this.lbStep = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gbxOne.SuspendLayout();
            this.gbxReult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Location = new System.Drawing.Point(16, 32);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.Size = new System.Drawing.Size(344, 21);
            this.tbxFilePath.TabIndex = 0;
            // 
            // gbxOne
            // 
            this.gbxOne.Controls.Add(this.rbtnAll);
            this.gbxOne.Controls.Add(this.rbtnWorkFlow);
            this.gbxOne.Controls.Add(this.btnFilePath);
            this.gbxOne.Controls.Add(this.tbxFilePath);
            this.gbxOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxOne.Location = new System.Drawing.Point(0, 0);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Size = new System.Drawing.Size(480, 100);
            this.gbxOne.TabIndex = 1;
            this.gbxOne.TabStop = false;
            this.gbxOne.Text = "第一步：导出到文件";
            // 
            // rbtnAll
            // 
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(48, 64);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(192, 24);
            this.rbtnAll.TabIndex = 3;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "导出全部(&B包含表单)";
            // 
            // rbtnWorkFlow
            // 
            this.rbtnWorkFlow.Location = new System.Drawing.Point(256, 64);
            this.rbtnWorkFlow.Name = "rbtnWorkFlow";
            this.rbtnWorkFlow.Size = new System.Drawing.Size(184, 24);
            this.rbtnWorkFlow.TabIndex = 2;
            this.rbtnWorkFlow.Text = "只导出原形(&A不含表单)";
            // 
            // btnFilePath
            // 
            this.btnFilePath.Location = new System.Drawing.Point(384, 32);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(64, 23);
            this.btnFilePath.TabIndex = 1;
            this.btnFilePath.Text = "浏览(&B)";
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // gbxReult
            // 
            this.gbxReult.Controls.Add(this.lbStep);
            this.gbxReult.Controls.Add(this.btnClose);
            this.gbxReult.Controls.Add(this.btnExport);
            this.gbxReult.Controls.Add(this.progressBar1);
            this.gbxReult.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxReult.Location = new System.Drawing.Point(0, 100);
            this.gbxReult.Name = "gbxReult";
            this.gbxReult.Size = new System.Drawing.Size(480, 100);
            this.gbxReult.TabIndex = 2;
            this.gbxReult.TabStop = false;
            this.gbxReult.Text = "第二步：执行导出";
            // 
            // lbStep
            // 
            this.lbStep.Location = new System.Drawing.Point(8, 56);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(440, 16);
            this.lbStep.TabIndex = 3;
            this.lbStep.Text = "导出进度";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(352, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(264, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(474, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // fmWorkflowExport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(480, 205);
            this.Controls.Add(this.gbxReult);
            this.Controls.Add(this.gbxOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmWorkflowExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流程导出";
            this.gbxOne.ResumeLayout(false);
            this.gbxOne.PerformLayout();
            this.gbxReult.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// 导出原形(不包含表单)
		/// </summary>
		/// <param name="iDs"></param>
		/// <param name="flowId"></param>
		/// <returns></returns>
		public void exportWorkFlow(DataSet iDs,string flowId)
		{

			try
			{
				//1、WorkFlow
				progressShow("WorkFlow");
                DataTable WorkFlow= WorkFlowTemplate.GetWorkflowTable(flowId);
                WorkFlow.TableName = "WorkFlow";
				iDs.Tables.Add(WorkFlow.Copy());
				
		

				//2、WorkTask表
				progressShow("WorkTask");
                DataTable WorkTask = WorkFlowTask.GetWorkTasks(flowId);
                WorkTask.TableName = "WorkTask";
                iDs.Tables.Add(WorkTask.Copy());
				

				//3、WorkLink
				progressShow("WorkLink");
                DataTable WorkLink = WorkFlowLink.GetWorkLinks(flowId);
                WorkLink.TableName = "WorkLink";
                iDs.Tables.Add(WorkLink.Copy());

                //4、TaskVar
                progressShow("TaskVar");
                DataTable var = TaskVar.GetWorkflowAllVar(flowId);
                var.TableName = "TaskVar";
                iDs.Tables.Add(var.Copy());

                //5、Operator
                progressShow("Operator");
                DataTable wfOperator = Operator.GetWorkFlowAllOperator(flowId);
                wfOperator.TableName = "Operator";
                iDs.Tables.Add(wfOperator.Copy());


                //6、subWorkFlow
                progressShow("subWorkFlow");
                DataTable subWorkFlow = SubWorkFlow.GetWorkflowAllSub(flowId);
                subWorkFlow.TableName = "subWorkFlow";
                iDs.Tables.Add(subWorkFlow.Copy());

                //7、WorkTaskCommands
                progressShow("WorkTaskCommands");
                DataTable workTaskCommands = WorkTaskCommands.GetWorkFlowAllCommands(flowId);
                workTaskCommands.TableName = "WorkTaskCommands";
                iDs.Tables.Add(workTaskCommands.Copy());
                //8、worktaskControls
                progressShow("worktaskControls");
                DataTable dtworktaskControls = WorkFlowTemplate.GetWorkFlowAllControlsTable(flowId);
                dtworktaskControls.TableName = "worktaskControls";
                iDs.Tables.Add(dtworktaskControls.Copy());
                //9、WorkFlowEvent
                progressShow("WorkFlowEvent");
                DataTable dtWorkFlowEvent = WorkFlowEvent.GetWorkFlowAllEventTable(flowId);
                dtWorkFlowEvent.TableName = "WorkFlowEvent";
                iDs.Tables.Add(dtWorkFlowEvent.Copy());
                //10、WorkOutTime
                progressShow("WorkOutTime");
                 DataTable dtWorkOutTime = WorkOutTime.GetWorkFlowAllOutTimeTable(flowId);
                 dtWorkOutTime.TableName = "WorkOutTime";
                 iDs.Tables.Add(dtWorkOutTime.Copy());
				
			}
			catch
			{
				throw;
			}


		}
		/// <summary>
		/// 导出表单
		/// </summary>
		/// <param name="iDs"></param>
		/// <param name="flowId"></param>
		/// <returns></returns>
		private void exportPage(DataSet iDs,string flowId)
		{
			try
			{
				
                //1\UserControlsLink
                progressShow("UserControlsLink");
                DataTable Controllink = MainUserControl.GetWorkFlowAllControlsLink(flowId);
                Controllink.TableName = "UserControlsLink";
                iDs.Tables.Add(Controllink.Copy());
				;
                //2、MainUserControl
                progressShow("MainUserControl");
                DataTable Control = MainUserControl.GetWorkFlowAllMainControls(flowId);
                Control.TableName = "MainUserControl";
                iDs.Tables.Add(Control.Copy());


                //3、UserControls
                progressShow("UserControls");
                DataTable dtuserControls = MainUserControl.GetWorkFlowAllControls(flowId);
                dtuserControls.TableName = "UserControls";
                iDs.Tables.Add(dtuserControls.Copy());
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		private void btnFilePath_Click(object sender, System.EventArgs e)
		{

			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Xml 文件|*.xml";
		    save.Title="["+exportName+"]流程导出";
            save.FileName = exportName;
			save.AddExtension=true;
		     DialogResult rsult=save.ShowDialog();
             if (rsult == DialogResult.OK)
			{
				exportFileName=save.FileName;
				tbxFilePath.Text=save.FileName;
				
			}
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			// Create FileStream   
			if (this.tbxFilePath.Text=="")
			{
				MessageBox.Show("请先选择导出的文件名！","系统提示");
				return;

			}
            this.progressBar1.Maximum = 0;
			System.IO.FileStream fsWriteXml = new System.IO.FileStream(exportFileName, System.IO.FileMode.Create);
			try
			{
				
				// Create an XmlTextWriter to write the file.
				System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(fsWriteXml, System.Text.Encoding.Unicode);
				DataSet ds =new DataSet();
				if (rbtnAll.Checked)
				{
					this.progressBar1.Maximum=13;
					exportWorkFlow(ds,exportGuid);//导出原形
					exportPage(ds,exportGuid);//导出表单


				}
				else
					if (rbtnWorkFlow.Checked)
			
				{
					this.progressBar1.Maximum=10;
					exportWorkFlow(ds,exportGuid);

				}
				ds.WriteXml(xmlWriter);
				fsWriteXml.Close();	
		        lbStep.Text="导出成功！";
			}
			catch (Exception ex)
			{
				fsWriteXml.Close();	
				MessageBox.Show("导出错误，错误代码："+ex.Message.ToString(),"系统提示");
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
