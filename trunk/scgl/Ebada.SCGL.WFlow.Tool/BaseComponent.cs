using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace Ebada.SCGL.WFlow.Tool
{

    /**//// <summary>
    /// ������ģ��ͼ�λ��ؼ�
    /// </summary>
    public class BaseComponent
    {
        /**//// <summary>
        /// ����ڵ�����ʹ�õ�����
        /// </summary>
        public Font font;    
        /**//// <summary>
        /// �ڵ�����
        /// </summary>
        public int X,Y;        
        /**//// <summary>
        /// ����ڵ����ƶ��뷽ʽ
        /// </summary>
        public StringFormat alignVertically;    
        /**//// <summary>
        /// ѡ����־
        /// </summary>
        public bool Selected;
        /**//// <summary>
        /// ����ڵ�ͼ��߿�
        /// </summary>
        public Rectangle bounds;
        /**//// <summary>
        /// ����ڵ�����
        /// </summary>
            
        public String TaskName;
        /**//// <summary>
        /// ����ڵ��id
        /// </summary>
        public string TaskId;
        /**//// <summary>
        /// ����ģ���id
        /// </summary>
        public string WorkFlowId;
                            
        /**//// <summary>
        /// �ڵ�ͼ��
        /// </summary>
        public Icon icon;    
        /**//// <summary>
        /// �����ȡ��,�˸�����ġ�
        /// </summary>                
        public GrabHandles grabHandles;        
        /**//// <summary>
        /// ������ק������
        /// </summary>
        public Dragger dragger;                
        /**//// <summary>
        /// //��ǰλ��
        /// </summary>
        public Point LocalPoint;
        /**//// <summary>
        /// �ڵ�����
        /// </summary>
        public int TaskType;
        /**//// <summary>
        /// �жϽڵ�and/or
        /// </summary>
        public string TaskTypeAndOr = "";
        /**//// <summary>
        /// �������,��ؼ����Թ�����dll�ļ���
        /// </summary>
        public string DllFileName="";
        /**//// <summary>
        /// �������,��ؼ����Թ���������(���������ռ�)
        /// </summary>
        public string DllClassName="";
        /**//// <summary>
        /// �����߲���
        /// </summary>
        public string OperRule = "";
        /**//// <summary>
        /// ��ע
        /// </summary>
        public string Description = "";
        /**//// <summary>
        /// �������Ǳ���ʱ��������
        /// </summary>
        public bool IsJumpSelf = false;
        /// <summary>
        /// �˻ر�־
        /// </summary>
        public bool haveback; 

        public BaseComponent()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            DllFileName = Application.StartupPath + @"\Ebada.SCGL.WFlow.Tool.dll";
            font=new Font("Arial",8);
            alignVertically=new StringFormat();
            alignVertically.LineAlignment=StringAlignment.Center;//ָ���ı��ڲ��־����о��ж���
            grabHandles=new GrabHandles(this);
            X = LocalPoint.X;// - panel.AutoScrollPosition.X;
            Y = LocalPoint.Y;// - panel.AutoScrollPosition.Y;
            TaskId = Guid.NewGuid().ToString();

        }
        //    
        /**//// <summary>
        /// �жϸ��������Ƿ�������ı߽������
        /// </summary>
        /// <param name="thePoint">��������</param>
        /// <returns></returns>
        public bool Contains(Point thePoint)
        {
            if(!Selected)
                return bounds.Contains(thePoint);
            else
            {
                Rectangle selectionRect=bounds;
                selectionRect.Inflate(SystemInformation.FrameBorderSize);//ͨ��������ĸ���ֵ���Ӿ��εĳߴ�
                return selectionRect.Contains(thePoint);
            }
        }

        public bool InDragHandle(Point thePoint)
        {
            if(!Selected)
                return false;
            return grabHandles.Contains(thePoint);
        }
        /**//// <summary>
        /// ���ڻ������ָ���ͼ��
        /// </summary>
        /// <param name="thePoint"></param>
        /// <returns></returns>

        public Cursor GetCursor(Point thePoint)
        {
            if(Selected)
            {
                if(InDragHandle(thePoint))
                    return grabHandles.GetCursor(thePoint);
                else
                    return Cursors.SizeAll;
            }
            else
                return Cursors.Default;
        }
        /**//// <summary>
        /// ����ͼƬ���������ƣ�
        /// ���ѡ���������������ѡ����ץȡ���
        /// </summary>
        /// <param name="e"></param>        
        public void      OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(icon, bounds.Left, bounds.Top);
            string     displayName = TaskName;
            SizeF sizeF = e.Graphics.MeasureString(displayName,font);
            int Namex=bounds.Left-((int)sizeF.Width)/2+bounds.Width/2;
            e.Graphics.DrawString(displayName, font, Brushes.Black, Namex,bounds.Top+40, alignVertically);  
            if(!Selected)
                return;                
            Rectangle outerRect=bounds;//paint the selection box
            outerRect.Inflate(SystemInformation.FrameBorderSize);
            ControlPaint.DrawSelectionFrame(e.Graphics,true,outerRect,bounds,SystemColors.ActiveBorder);                
            grabHandles.OnPaint(e);//paint the grab handles
        }
        /**//// <summary>
        /// �жϽڵ��Ƿ����
        /// </summary>
        /// <returns></returns>
        public bool TaskExist()
        {
            
            return WorkFlowTask.ExistTask(TaskId);

        }
        /**//// <summary>
        ///��������ڵ�
        /// </summary>
        public void SaveInsertTask()
        {
            if (TaskId.Trim().Length==0||TaskId==null)
                throw new Exception("SaveInsertTask��������TaskId ����Ϊ�գ�");
            try
            {

                WorkFlowTask workflowTask=new WorkFlowTask();
                workflowTask.TaskId=TaskId;
                workflowTask.TaskName=TaskName;
                workflowTask.TaskType=TaskType;
                workflowTask.X=X;
                workflowTask.Y=Y;
                workflowTask.WorkFlowId=WorkFlowId;
                workflowTask.OperRule = OperRule;
                workflowTask.Description = Description;
                workflowTask.TaskTypeAndOr = TaskTypeAndOr;
                workflowTask.IsJumpSelf = IsJumpSelf;
                workflowTask.InsertTask();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }
        /**//// <summary>
        /// �޸�����ڵ�
        /// </summary>
        public void SaveUpdateTask()
        {
            if (TaskId.Trim().Length==0||TaskId==null)
                throw new Exception("SaveUpdateTask��������TaskId ����Ϊ�գ�");
            try
            {

                WorkFlowTask workflowTask=new WorkFlowTask();
                workflowTask.TaskId=TaskId;
                workflowTask.TaskName=TaskName;
                workflowTask.TaskType=TaskType;
                workflowTask.X=X;
                workflowTask.Y=Y;
                workflowTask.WorkFlowId=WorkFlowId;
                workflowTask.OperRule = OperRule;
                workflowTask.Description = Description;
                workflowTask.TaskTypeAndOr = TaskTypeAndOr;
                workflowTask.IsJumpSelf = IsJumpSelf;
                workflowTask.UpdateTask();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


    }
    /**//// <summary>
    /// 1�����ڵ�
    /// </summary>
    public class StartTask: BaseComponent
    {
        public StartTask(Point localPoint,int orderId)
        
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskStart";
            LocalPoint=localPoint;
            X=LocalPoint.X;
            Y=LocalPoint.Y;
            TaskName="�����ڵ�"+orderId.ToString();
            TaskType=1;

            icon = Icon.FromHandle(new Bitmap( Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico"))).GetHicon());
            
            bounds=new Rectangle(LocalPoint,icon.Size);
        


        }

    }
    /**/
    /// <summary>
    /// 2��ֹ�ڵ�
    /// </summary>
    public class EndTask : BaseComponent
    {
        public EndTask(Point localPoint, int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskStart";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�����ڵ�" + orderId.ToString();
            TaskType = 2;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.��ֹ�ڵ�.ico"))).GetHicon());
            bounds = new Rectangle(localPoint, icon.Size);

        }
    }
    /**//// <summary>
    /// 3�����ڵ�
    /// </summary>
    public class AlternateTask: BaseComponent
    {
        public AlternateTask(Point localPoint,int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskAlter";
            LocalPoint=localPoint;
            X=LocalPoint.X;
            Y=LocalPoint.Y;
            TaskName="�����ڵ�"+orderId.ToString();
            TaskType=3;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico"))).GetHicon());
            bounds=new Rectangle(LocalPoint,icon.Size);
            
        }    
    

        
    }
    /**//// <summary>
    /// 4���ƽڵ�
    /// </summary>
    public class JudgeTask: BaseComponent
    {
        public JudgeTask(Point localPoint,int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskJudge";
            LocalPoint=localPoint;
            X=LocalPoint.X;
            Y=LocalPoint.Y;
            TaskName = "���ƽڵ�" + orderId.ToString();
            TaskType = 4;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.���ƽڵ�.ico"))).GetHicon());
            bounds=new Rectangle(LocalPoint,icon.Size);    
        }
        
    }
    /**//// <summary>
    /// 6�����̽ڵ�
    /// </summary>
    public class SubFlowTask: BaseComponent
    {
        public SubFlowTask(Point localPoint,int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskSub";
            LocalPoint=localPoint;
            X=LocalPoint.X;
            Y=LocalPoint.Y;
            TaskName="�����̽ڵ�"+orderId.ToString();
            TaskType=6;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����̽ڵ�.ico"))).GetHicon());
            bounds=new Rectangle(LocalPoint,icon.Size);
        
        }




    }
    /**/
    /// <summary>
    /// 5�鿴�ڵ�
    /// </summary>
    public class ViewTask : BaseComponent
    {
        public ViewTask(Point localPoint, int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskView";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�鿴�ڵ�" + orderId.ToString();
            TaskType = 5;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�鿴�ڵ�.ico"))).GetHicon());
            bounds = new Rectangle(localPoint, icon.Size);
        }

    }
    /**//// <summary>
    /// 6�Զ��ӵ�
    /// </summary>
    public class AutoTask: BaseComponent
    {
        public AutoTask(Point localPoint,int orderId)
        {
            DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskSub";
            LocalPoint=localPoint;
            X=LocalPoint.X;
            Y=LocalPoint.Y;
            TaskName="�Զ��ڵ�"+orderId.ToString();
            TaskType=6;
            icon = Icon.FromHandle(new Bitmap(Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.������.ico"))).GetHicon());
            bounds=new Rectangle(LocalPoint,icon.Size);
        
        }
    }
    /**/
    /// <summary>
    /// 7���нڵ�
    /// </summary>
    public class ParallelTask : BaseComponent
    {
        public ParallelTask(Point localPoint, int orderId)
        {
            //DllClassName = "Ebada.SCGL.WFlow.Tool.fmTaskParalle";

            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "���нڵ�" + orderId.ToString();
            TaskType = 7;
            icon = new Icon("���нڵ�.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }
    /**////// <summary>
    ///// 7���ƽڵ�
    ///// </summary>
    //public class ControlTask: BaseComponent
    //{
    //    public ControlTask(Point localPoint,int orderId)
    //    {
    //        DllClassName="WfaTool.WorkTaskLine.fmTaskControl";
    //        LocalPoint=localPoint;
    //        X=LocalPoint.X;
    //        Y=LocalPoint.Y;
    //        TaskName="���ƽڵ�"+orderId.ToString();
    //        TaskType=7;
    //        icon = new Icon("���ƽڵ�.ico");
    //        bounds=new Rectangle(LocalPoint,icon.Size);
    //    }        
    //}
}
