using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.Client;
using Ebada.Core;
using System.Collections;

namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TreeNote的扩展类，通过扩展属性记录节点的多个信息。
	/// </summary>
	public  class FrmworkTreeNode:System.Windows.Forms.TreeNode
	{	
		public FrmworkTreeNode()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            blankWindows = true;
            
        }
        private string[] fieldList ={"selfcode","fathercode","Caption","NodeType","isVisable",
										"DllFilename","DllClassName","DllMethodName","FormName",
                                        "BlankWindows","MouseIsClick","ImageIndex","SDIWindows"};
        private string tableName = "FrmworkTree";
        private string keyField = "selfcode";
        private string sqlString = "";
        #region 属性
        private string nodeType;
        private string nodeId;
        private string fatherId;
        private string fatherCaption;
        private bool   canEdit;
        private bool   refresh;
        private string isSignOut;
        private string signOutOperator;
        private string nodeMemo;
        private string dllFileName;
        private string dllClassName;
        private string dllMethodName;
        private string formName;
        private bool mouseIsClick;
        private bool blankWindows;
        private bool canVisable;
        private bool windowsSDI;

        
        /// <summary>
        /// 获取或设置树节点的类型
        /// </summary>
		public string NodeType
		{
            get { return this.nodeType; }
            set { this.nodeType = value; }
		}
        /// <summary>
        /// 获取或设置节点的_NodeId,一般是表的主键
        /// </summary>
		public string NodeId
		{
            set { this.nodeId = value; }
            get { return this.nodeId; }
			
		}
        /// <summary>
        /// 父节点id
        /// </summary>
        public string FatherId
        {
            set { this.fatherId=value;}
            get { return this.fatherId;}
        }        
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string FatherCaption
        {
            set { this.fatherCaption = value; }
            get { return this.fatherCaption; }
        }
					
        /// <summary>
        /// 是否可以编辑.若是true,可编辑,否则只能查看
        /// </summary>
		public bool CanEdit
		{
            set { this.canEdit = value; }
            get { return this.canEdit; }
		}
		
        /// <summary>
        /// 是否被其他用户迁出
        /// </summary>
		public string IsSignOut
		{
            set { this.isSignOut = value; }
            get { return this.isSignOut; }
			
		}
		
        /// <summary>
        /// 迁出者
        /// </summary>
		public string SignOutOperator
		{
            set { this.signOutOperator = value; }
            get { return this.signOutOperator; }
			
		}
		
        /// <summary>
        /// 是否刷新该节点
        /// </summary>
		public bool Refresh
		{
            set { this.refresh = value; }
            get { return this.refresh; }
			
		}
	
        /// <summary>
        /// 节点属性说明
        /// </summary>
		public string NodeMemo
		{
            set { this.nodeMemo = value; }
            get { return this.nodeMemo; }
			
		}

        /// <summary>
        /// 与之关联的dll的文件名字
        /// </summary>
		public string DllFileName
		{
            set { this.dllFileName = value; }
            get { return this.dllFileName; }
			
		}

        /// <summary>
        /// 调用类的名字
        /// </summary>
		public string DllClassName
		{
            set { this.dllClassName = value; }
            get { return this.dllClassName; }
			
		}

        /// <summary>
        /// 调用方法的名字
        /// </summary>
		public string DllMethodName
		{
            set { this.dllMethodName = value; }
            get { return this.dllMethodName; }
			
		}
        /// <summary>
        /// 是否在新窗口中打开
        /// </summary>
        public bool BlankWindows
        {
            set { this.blankWindows = value; }
            get { return this.blankWindows; }
 
        }
        
        
        /// <summary>
        /// 动态调用的窗体名
        /// </summary>
        public string FormName
        {
            set { this.formName = value; }
            get { return this.formName; }
 
        }
       
        /// <summary>
        /// 是否单击鼠标执行,true 为单击，false为双击
        /// </summary>
        public bool MouseIsClick
        {
            set { this.mouseIsClick = value; }
            get { return this.mouseIsClick; }

        }
        
        /// <summary>
        /// 是否显示该节点
        /// </summary>
        public bool CanVisable
        {
            set { this.canVisable = value; }
            get { return this.canVisable; }

        }
        /// <summary>
        /// 模态模式调用窗口
        /// </summary>
        public bool WindowsSDI
        {
            set { this.windowsSDI = value; }
            get { return this.windowsSDI; }

        }
		#endregion
        
        #region 方法
        
        /// <summary>
        /// 根据id获得节点名称
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static string GetCaptionById(string nodeId)
        {
            if (nodeId == "") throw new Exception("调用GetNodeInfoById失败，nodeId未指定！");
            //string tmpStr = "select caption from FrmworkTree where selfcode=@selfcode";
            try
            {
                 
                return MainHelper.PlatformSqlMap.GetOneByKey<WFModul>(nodeId).SelfCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        /// <summary>
        /// 根据父节点id获得子节点列表
        /// </summary>
        /// <param name="fatherId">父节点Id</param>
        /// <returns>子节点的table</returns>
        public static DataTable GetChildNodes(string fatherId)
        {
            try
            {

               
                string tmpStr = " WHERE isVisable=1 and FatherCode='" + fatherId + "'";
                WFModul ss = new WFModul();
                ss.FullPosition  =tmpStr;
                IList list = (IList)MainHelper.PlatformSqlMap.GetList<WFModul>("SelectWFModulList", ss.FullPosition);
                return ConvertHelper.ToDataTable(list);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// 获得framework树节点信息
        /// </summary>
        /// <param name="nodeId"></param>
        public void GetNodeInfoById(string nodeId)
        {
            if (nodeId == "") throw new Exception("调用GetNodeInfoById失败，nodeId未指定！");

            string tmpStr = " where selfcode='" + nodeId + "'";
            
            try
            {
                DataTable table = ConvertHelper.ToDataTable(MainHelper.PlatformSqlMap.GetList("SelectWFModulByWhere", tmpStr));
                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    this.NodeId = nodeId;
                    this.Text = row["Caption"].ToString();
                    this.fatherId = row["fathercode"].ToString();
                    this.FatherCaption = GetCaptionById(this.fatherId);
                    
                    this.DllClassName = row["DllClassName"].ToString();
                    this.DllFileName = row["DllFileName"].ToString();
                    
                    this.DllMethodName = row["DllMethodName"].ToString();
                    this.FormName = row["FormName"].ToString();
                    this.MouseIsClick = Convert.ToBoolean(row["MouseIsClick"]);
                    this.BlankWindows = Convert.ToBoolean(row["BlankWindows"]);
                    this.CanVisable = Convert.ToBoolean(row["isVisable"]);
                    this.NodeType = row["NodeType"].ToString();
                    this.ImageIndex =Convert.ToInt16( row["ImageIndex"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
       
        
        /// <summary>
        /// 增加一个节点
        /// </summary>
        public void AddNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("AddNodeInfo方法错误，NodeId 不能为空！");
            if (this.Text.Trim().Length == 0 || this.Text == null)
                throw new Exception("AddNodeInfo方法错误，Text 不能为空！");
            try
            {
                WFModul wf = new WFModul();
                wf.SelfCode = this.NodeId;
                wf.FatherCode = this.FatherId;
                wf.SelfCode = this.Text;
                wf.IsVisable  = this.CanVisable;
                wf.DllFileName = this.DllFileName;
                wf.DllClassName = this.DllClassName;
                wf.DllMethodName = this.DllMethodName;
                wf.FormName= this.FormName;
                wf.BlankWindows = this.BlankWindows;
                wf.MouseIsClick= this.MouseIsClick;
                wf.ImageIndex = this.ImageIndex;
                wf.SDIWindows  = this.WindowsSDI;
                MainHelper.PlatformSqlMap.Create<WFModul>(wf); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

 
        }
        /// <summary>
        /// 修改一个节点
        /// </summary>
        public void ModifyNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("ModifyNodeInfo方法错误，Nodeid 不能为空！");
            try
            {
                WFModul wf = MainHelper.PlatformSqlMap.GetOneByKey<WFModul>(NodeId);
                wf.SelfCode = this.NodeId;
                wf.FatherCode = this.FatherId;
                wf.SelfCode = this.Text;
                wf.IsVisable = this.CanVisable;
                wf.DllFileName = this.DllFileName;
                wf.DllClassName = this.DllClassName;
                wf.DllMethodName = this.DllMethodName;
                wf.FormName = this.FormName;
                wf.BlankWindows = this.BlankWindows;
                wf.MouseIsClick = this.MouseIsClick;
                wf.ImageIndex = this.ImageIndex;
                wf.SDIWindows = this.WindowsSDI;
                MainHelper.PlatformSqlMap.Update<WFModul>(wf); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        /// <summary>
        /// 删除一个节点
        /// </summary>
        public void DeleteNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("DeleteNodeInfo方法错误，NodeId 不能为空！");
            try
            {

                string tmpSql = "delete from " + this.tableName + " where selfcode='" + NodeId + "";
                MainHelper.PlatformSqlMap.DeleteByWhere<WFModul>(tmpSql);
          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		#endregion

	}
}
