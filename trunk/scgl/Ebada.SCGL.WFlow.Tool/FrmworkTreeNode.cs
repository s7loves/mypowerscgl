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
	/// TreeNote����չ�࣬ͨ����չ���Լ�¼�ڵ�Ķ����Ϣ��
	/// </summary>
	public  class FrmworkTreeNode:System.Windows.Forms.TreeNode
	{	
		public FrmworkTreeNode()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
            blankWindows = true;
            
        }
        private string[] fieldList ={"selfcode","fathercode","Caption","NodeType","isVisable",
										"DllFilename","DllClassName","DllMethodName","FormName",
                                        "BlankWindows","MouseIsClick","ImageIndex","SDIWindows"};
        private string tableName = "FrmworkTree";
        private string keyField = "selfcode";
        private string sqlString = "";
        #region ����
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
        /// ��ȡ���������ڵ������
        /// </summary>
		public string NodeType
		{
            get { return this.nodeType; }
            set { this.nodeType = value; }
		}
        /// <summary>
        /// ��ȡ�����ýڵ��_NodeId,һ���Ǳ������
        /// </summary>
		public string NodeId
		{
            set { this.nodeId = value; }
            get { return this.nodeId; }
			
		}
        /// <summary>
        /// ���ڵ�id
        /// </summary>
        public string FatherId
        {
            set { this.fatherId=value;}
            get { return this.fatherId;}
        }        
        /// <summary>
        /// ���ڵ�����
        /// </summary>
        public string FatherCaption
        {
            set { this.fatherCaption = value; }
            get { return this.fatherCaption; }
        }
					
        /// <summary>
        /// �Ƿ���Ա༭.����true,�ɱ༭,����ֻ�ܲ鿴
        /// </summary>
		public bool CanEdit
		{
            set { this.canEdit = value; }
            get { return this.canEdit; }
		}
		
        /// <summary>
        /// �Ƿ������û�Ǩ��
        /// </summary>
		public string IsSignOut
		{
            set { this.isSignOut = value; }
            get { return this.isSignOut; }
			
		}
		
        /// <summary>
        /// Ǩ����
        /// </summary>
		public string SignOutOperator
		{
            set { this.signOutOperator = value; }
            get { return this.signOutOperator; }
			
		}
		
        /// <summary>
        /// �Ƿ�ˢ�¸ýڵ�
        /// </summary>
		public bool Refresh
		{
            set { this.refresh = value; }
            get { return this.refresh; }
			
		}
	
        /// <summary>
        /// �ڵ�����˵��
        /// </summary>
		public string NodeMemo
		{
            set { this.nodeMemo = value; }
            get { return this.nodeMemo; }
			
		}

        /// <summary>
        /// ��֮������dll���ļ�����
        /// </summary>
		public string DllFileName
		{
            set { this.dllFileName = value; }
            get { return this.dllFileName; }
			
		}

        /// <summary>
        /// �����������
        /// </summary>
		public string DllClassName
		{
            set { this.dllClassName = value; }
            get { return this.dllClassName; }
			
		}

        /// <summary>
        /// ���÷���������
        /// </summary>
		public string DllMethodName
		{
            set { this.dllMethodName = value; }
            get { return this.dllMethodName; }
			
		}
        /// <summary>
        /// �Ƿ����´����д�
        /// </summary>
        public bool BlankWindows
        {
            set { this.blankWindows = value; }
            get { return this.blankWindows; }
 
        }
        
        
        /// <summary>
        /// ��̬���õĴ�����
        /// </summary>
        public string FormName
        {
            set { this.formName = value; }
            get { return this.formName; }
 
        }
       
        /// <summary>
        /// �Ƿ񵥻����ִ��,true Ϊ������falseΪ˫��
        /// </summary>
        public bool MouseIsClick
        {
            set { this.mouseIsClick = value; }
            get { return this.mouseIsClick; }

        }
        
        /// <summary>
        /// �Ƿ���ʾ�ýڵ�
        /// </summary>
        public bool CanVisable
        {
            set { this.canVisable = value; }
            get { return this.canVisable; }

        }
        /// <summary>
        /// ģ̬ģʽ���ô���
        /// </summary>
        public bool WindowsSDI
        {
            set { this.windowsSDI = value; }
            get { return this.windowsSDI; }

        }
		#endregion
        
        #region ����
        
        /// <summary>
        /// ����id��ýڵ�����
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static string GetCaptionById(string nodeId)
        {
            if (nodeId == "") throw new Exception("����GetNodeInfoByIdʧ�ܣ�nodeIdδָ����");
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
        /// ���ݸ��ڵ�id����ӽڵ��б�
        /// </summary>
        /// <param name="fatherId">���ڵ�Id</param>
        /// <returns>�ӽڵ��table</returns>
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
        /// ���framework���ڵ���Ϣ
        /// </summary>
        /// <param name="nodeId"></param>
        public void GetNodeInfoById(string nodeId)
        {
            if (nodeId == "") throw new Exception("����GetNodeInfoByIdʧ�ܣ�nodeIdδָ����");

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
        /// ����һ���ڵ�
        /// </summary>
        public void AddNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("AddNodeInfo��������NodeId ����Ϊ�գ�");
            if (this.Text.Trim().Length == 0 || this.Text == null)
                throw new Exception("AddNodeInfo��������Text ����Ϊ�գ�");
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
        /// �޸�һ���ڵ�
        /// </summary>
        public void ModifyNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("ModifyNodeInfo��������Nodeid ����Ϊ�գ�");
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
        /// ɾ��һ���ڵ�
        /// </summary>
        public void DeleteNodeInfo()
        {
            if (NodeId.Trim().Length == 0 || NodeId == null)
                throw new Exception("DeleteNodeInfo��������NodeId ����Ϊ�գ�");
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
