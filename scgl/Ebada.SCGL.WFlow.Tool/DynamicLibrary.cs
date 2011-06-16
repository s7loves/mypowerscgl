using System;
using System.Reflection;
using System.IO;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// 动态调用dll的类
	/// </summary>
	public class DynamicLibrary
	{
		private string _DllFileName;
        /// <summary>
        /// 动态调用的dll文件
        /// </summary>
		public string DllFileName
		{
			set{this._DllFileName=value;}
			get{return this._DllFileName;}
		}
		
		private System.Windows.Forms.Form _MainForm;
        /// <summary>
        /// 动态调用该类的主窗体
        /// </summary>
		public  System.Windows.Forms.Form MainForm
		{
			set{this._MainForm=value;}
			get{return this._MainForm;}
		}
		
		private string _DllClassName;
        /// <summary>
        /// 动态调用的类名(包含命名空间)
        /// </summary>
		public string DllClassName
		{
			set{this._DllClassName=value;}
			get{return this._DllClassName;}
		}

		
		private string _DllMethodName;
        /// <summary>
        /// 动态调用类中的方法名(只提供方法名即可)
        /// </summary>
		public string DllMethodName
		{
			set{this._DllMethodName=value;}
			get{return this._DllMethodName;}
		}

		
		private object[] _ObjArray;
        /// <summary>
        /// 动态调用的类构造函数需要的参数数组
        /// </summary>
		public object[] ObjArray
		{
			set{this._ObjArray=value;}
			get{return this._ObjArray;}
		}

		/// <summary>
		/// 动态调用方法需要的参数数组
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
			// TODO: 在此处添加构造函数逻辑

			//
			

		}
		/// <summary>
		/// MDI方式动态调用dll中的窗体,只使用于winform.
		/// </summary>

		public  System.Windows.Forms.Form CallMDIWindows()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallMDIWindows调用失败，DllName 不允许为空！");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallMDIWindows调用失败，DllClassName 不允许为空！");
			if (_MainForm==null)throw new Exception("CallMDIWindows调用失败，MainForm没有指定！");
			if (!File.Exists(_DllFileName)) throw new Exception("CallMDIWindows调用失败，["+_DllFileName+"]不存在。");
			try
			{
				System.Windows.Forms.Form fromCtrl = null;
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);//
				if (_ObjArray==null)//窗体的构造函数不需要参数
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp);
                else//窗体的构造函数需要参数
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp,_ObjArray);
				fromCtrl.MdiParent=_MainForm;
				fromCtrl.Show();
				return fromCtrl;//返回调用的窗体
			}
			catch(Exception ex)
			{
				throw ex;

			}

		}

		/// <summary>
		/// SDI方式动态调用dll中的窗体,只使用于winform.
		/// </summary>
		public System.Windows.Forms.Form  CallSDIWindows()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallSDIWindows调用失败，DllName 不允许为空！");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallSDIWindows调用失败，_DllClassName 不允许为空！");
			if (!File.Exists(_DllFileName)) throw new Exception("CallSDIWindows调用失败，["+_DllFileName+"]不存在。");
			try
			{
				System.Windows.Forms.Form fromCtrl = null;
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);
                if (_ObjArray == null)////窗体的构造函数不需要参数
					fromCtrl = ( System.Windows.Forms.Form)Activator.CreateInstance(tp);
                else//窗体的构造函数需要参数
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
		/// 动态调用dll类中的方法
		/// </summary>
		/// <returns></returns>
		public object CallMethod()
		{
			if (_DllFileName.Trim().Length==0||_DllFileName==null) throw new Exception("CallMethod调用失败，DllName 不允许为空！");
			if (_DllClassName.Trim().Length==0||_DllClassName==null) throw new Exception("CallMethod调用失败，_DllClassName 不允许为空！");
			if (_DllMethodName.Trim().Length==0||_DllMethodName==null) throw new Exception("CallMethod调用失败，DllMethodName 不允许为空！");
			if (!File.Exists(_DllFileName)) throw new Exception("CallMethod调用失败，["+_DllFileName+"]不存在。");
            object obj=null;
			try
			{
				Assembly assembly = Assembly.LoadFile(_DllFileName);
				Type tp=assembly.GetType(_DllClassName);
				MethodInfo mi=tp.GetMethod(_DllMethodName);
				if (_ObjArray==null)//方法不需要参数
					obj = (object)Activator.CreateInstance(tp);
				else //方法需要参数
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
