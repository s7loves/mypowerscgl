using System;
using System.Reflection;
using System.IO;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// ��̬����dll����
	/// </summary>
	public class DynamicLibrary
	{
		private string _DllFileName;
        /// <summary>
        /// ��̬���õ�dll�ļ�
        /// </summary>
		public string DllFileName
		{
			set{this._DllFileName=value;}
			get{return this._DllFileName;}
		}
		
		private System.Windows.Forms.Form _MainForm;
        /// <summary>
        /// ��̬���ø����������
        /// </summary>
		public  System.Windows.Forms.Form MainForm
		{
			set{this._MainForm=value;}
			get{return this._MainForm;}
		}
		
		private string _DllClassName;
        /// <summary>
        /// ��̬���õ�����(���������ռ�)
        /// </summary>
		public string DllClassName
		{
			set{this._DllClassName=value;}
			get{return this._DllClassName;}
		}

		
		private string _DllMethodName;
        /// <summary>
        /// ��̬�������еķ�����(ֻ�ṩ����������)
        /// </summary>
		public string DllMethodName
		{
			set{this._DllMethodName=value;}
			get{return this._DllMethodName;}
		}

		
		private object[] _ObjArray;
        /// <summary>
        /// ��̬���õ��๹�캯����Ҫ�Ĳ�������
        /// </summary>
		public object[] ObjArray
		{
			set{this._ObjArray=value;}
			get{return this._ObjArray;}
		}

		/// <summary>
		/// ��̬���÷�����Ҫ�Ĳ�������
		/// </summary>
		private object[] _ObjMethodArray;
		public object[] ObjMethodArray
		{
			set{this._ObjMethodArray=value;}
			get{return this._ObjMethodArray;}
		}
		


		public DynamicLibrary()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�

			//
			

		}
		/// <summary>
		/// MDI��ʽ��̬����dll�еĴ���,ֻʹ����winform.
		/// </summary>

		public  System.Windows.Forms.Form CallMDIWindows()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallMDIWindows����ʧ�ܣ�DllName ������Ϊ�գ�");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallMDIWindows����ʧ�ܣ�DllClassName ������Ϊ�գ�");
			if (_MainForm==null)throw new Exception("CallMDIWindows����ʧ�ܣ�MainFormû��ָ����");
			if (!File.Exists(_DllFileName)) throw new Exception("CallMDIWindows����ʧ�ܣ�["+_DllFileName+"]�����ڡ�");
			try
			{
				System.Windows.Forms.Form fromCtrl = null;
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);//
				if (_ObjArray==null)//����Ĺ��캯������Ҫ����
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp);
                else//����Ĺ��캯����Ҫ����
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp,_ObjArray);
				fromCtrl.MdiParent=_MainForm;
				fromCtrl.Show();
				return fromCtrl;//���ص��õĴ���
			}
			catch(Exception ex)
			{
				throw ex;

			}

		}

		/// <summary>
		/// SDI��ʽ��̬����dll�еĴ���,ֻʹ����winform.
		/// </summary>
		public System.Windows.Forms.Form  CallSDIWindows()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallSDIWindows����ʧ�ܣ�DllName ������Ϊ�գ�");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallSDIWindows����ʧ�ܣ�_DllClassName ������Ϊ�գ�");
			if (!File.Exists(_DllFileName)) throw new Exception("CallSDIWindows����ʧ�ܣ�["+_DllFileName+"]�����ڡ�");
			try
			{
				System.Windows.Forms.Form fromCtrl = null;
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);
                if (_ObjArray == null)////����Ĺ��캯������Ҫ����
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp);
                else//����Ĺ��캯����Ҫ����
				fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp,_ObjArray);
				fromCtrl.ShowDialog();
				return fromCtrl;
			}
            catch (Exception ex)
			{
				throw ex;
			}

		}
		/// <summary>
		/// ��̬����dll���еķ���
		/// </summary>
		/// <returns></returns>
		public object CallMethod()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallMethod����ʧ�ܣ�DllName ������Ϊ�գ�");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallMethod����ʧ�ܣ�_DllClassName ������Ϊ�գ�");
			if (_DllMethodName.Trim().Length==0||_DllMethodName==null) throw new Exception("CallMethod����ʧ�ܣ�DllMethodName ������Ϊ�գ�");
			if (!File.Exists(_DllFileName)) throw new Exception("CallMethod����ʧ�ܣ�["+_DllFileName+"]�����ڡ�");
            object obj=null;
			try
			{
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);
				MethodInfo mi=tp.GetMethod(_DllMethodName);
				if (_ObjArray==null)//��������Ҫ����
					obj = (object)Activator.CreateInstance(tp);
				else //������Ҫ����
                    obj = (object)Activator.CreateInstance(tp,_ObjArray);
				return mi.Invoke(obj,_ObjMethodArray);
			}
            catch (Exception ex)
			{
				throw ex;
			}
			 
			
		}
	}
}
