using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Drawing.Drawing2D;

using System;
using Ebada.Client;





namespace Ebada.SCGL.WFlow.Tool
{
    /**//// <summary>
    /// WorkPlace 的摘要说明。
    /// </summary>
    public class WorkPlace : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenu cmPanel;
        private System.Windows.Forms.MenuItem WorkPlaceCloseFlow;
        private System.Windows.Forms.MenuItem menuProperty;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.MenuItem menuDelete;
        private MenuItem menuSave;
        private System.Windows.Forms.MenuItem menuPrint;
        private System.Windows.Forms.MenuItem menuPrintView;
        private System.Windows.Forms.PrintPreviewDialog view;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuTaskLine;

        private int stID;//启动节点计数
        private int endtID;//终止节点计数
        private int altID;//交互节点计数
        private int jtID;//判断节点计数
        private int etID;//查看节点计数
        private int autoID;//自动节点计数
        private int conID;//控制节点计数
        private int subID;//子流程节点计数
        private Rubberband rubberband = null;//橡皮圈                                    
        private Dragger dragger = null;    //拖拽处理
        private bool isZhexian;//选中的连线的选中折点的索引
        private int breakIndex;
        private bool isInAnchor;
        private bool isDrawingLine;
        private Link link;    //画折线时选中的直线.因为移动鼠标拖动时不需要画原来的直线
        private Point startPoint, endPoint,breakPoint;
        private Bounds myBounds;
        private BaseComponent startTask, endTask;  

        /**//// <summary>
        /// 流程模板所有节点列表
        /// </summary>
        public ArrayList TaskItems = new ArrayList();
        /**//// <summary>
        /// 流程模板所有连线列表
        /// </summary>
        public ArrayList LineItems=new ArrayList();    
        /**//// <summary>
        /// 选中的节点列表
        /// </summary>
        public SelectedItems SelectedItems = new SelectedItems();
        /**//// <summary>
        /// 选中的连线列表
        /// </summary>
        public SelectedLine SelectedLine=new SelectedLine();
        public ToolStripButton nowButton;
           

        
        /**//// <summary>
        /// 进入流程图设计模式，只有在设计模式才能画任务节点或线
        /// </summary>
        public bool toolModel;
        /**//// <summary>
        /// 节点模式，画线模式：1--启动节点；2-终止节点;3-交互节点;4-判断节点;5-查看节点;6-自动节点;7-控制节点;
        /// 8-子流程节点；0－连线,-1-自连线;
        /// </summary>
        public int Module;
        /**//// <summary>
        /// 画图锁定，同时画多个任务节点时LockModel=true
        /// </summary>
        public bool LockModel;    
        /**//// <summary>
        /// 流程模板名称
        /// </summary>
        public string WorkFlowCaption="";
        /**//// <summary>
        /// 流程模板Id
        /// </summary>
        public string WorkFlowId="";
        /**//// <summary>
        /// 修改、新建、查看三种状态
        /// </summary>
        public string State;        
        /**//// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool CanEdit;
        /**//// <summary>
        /// 是否修改
        /// </summary>
        public bool IsModify=false;
        /**//// <summary>
        /// 操作人账号，用作权限判断。
        /// </summary>
        public string UserId = "";
        /**//// <summary>
        /// 操作人姓名，用作显示。
        /// </summary>
        public string UserName="";
        public WorkPlace(string workFlowId,string userId,string userName)
        {
            InitializeComponent();
            UserId=userId;
            UserName=userName;
            stID=0;            
            endtID=0;
            altID=0;
            jtID=0;
            etID=0;
            autoID=0;
            conID=0;
            subID=0;            
            toolModel=false;        
            isDrawingLine = false;
            isZhexian=false;
            IsModify=false;
            breakIndex=-1;    
            WorkFlowId=workFlowId;
            if (WorkFlowId!=null&&WorkFlowId.Trim().Length>0)
            {
                WorkFlowData tmpWorkflow=new WorkFlowData();
                tmpWorkflow.WorkFlowId=WorkFlowId;
                tmpWorkflow.ReadWorkFlow();
                TaskItems=tmpWorkflow.TaskItems;
                LineItems=tmpWorkflow.LineItems;
            }
        }
        #region 画图处理
        /**//// <summary>
        /// 清理所有正在使用的资源。画图处理
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
        /**//// <summary>
        /// 判断点p是否在直线的某个锚点,同时作一些准备工作
        /// </summary>
        /// <param name="p"></param>
        /// <returns>p是直线的某个锚点,返回true,否则false </returns>

        protected bool IsInAnchor(Point p)
        {
            bool result=false;
            for(int i=1;i<link.breakPointX.Count-1;i++)
            {
                Region region=new Region(new Rectangle(Convert.ToInt16(link.breakPointX[i])-3,Convert.ToInt16(link.breakPointY[i])-3,6,6));
                if(region.IsVisible(p))
                {                                
                    this.breakIndex=i;                    
                    startPoint.X=Convert.ToInt16(link.breakPointX[i-1]);
                    startPoint.Y=Convert.ToInt16(link.breakPointY[i-1]);
                    endPoint.X=Convert.ToInt16(link.breakPointX[i+1]);
                    endPoint.Y=Convert.ToInt16(link.breakPointY[i+1]);    
                    result=true;
                    link.selectedAnchor=i;
                    break;
                }
            }
            if(result==false){ this.breakIndex=-1;link.selectedAnchor=-1;}
            return result;
        }
        /**//// <summary>
        /// 给定点是否在选定的直线上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>thePoint在选定的某一直线上返回该直线,否则返回null</returns>

        protected Link IsInALine(Point thePoint)
        {
            int i;
            for(i=LineItems.Count-1;i>=0;i--)
            {
                Link linkLine=LineItems[i] as Link;
                if(linkLine.Contains(thePoint))
                    return linkLine;
            }
            return null;
        }
        /**//// <summary>
        /// 给定点是否在选中的任务节点上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>如果给定点thePoint在某一选中的任务节点上返回该任务节点,否则的返回null</returns>
        protected BaseComponent SelectedComponentContaining(Point thePoint)
        {
            // iterate backwards over the TaskItems collection
            // if a selected item is found, return it
            for (int i = TaskItems.Count - 1; i >= 0; i--)
            {
                BaseComponent c = TaskItems [i] as BaseComponent;
                if (SelectedItems.Contains(c) )
                    if (c.Contains(thePoint) )
                        return c;
            }
            return null;
        }

        protected void AddItem(BaseComponent theItem,int taskType)
        {
            theItem.WorkFlowId = this.WorkFlowId;            
             theItem.TaskType=taskType;
            TaskItems.Add(theItem);
            IsModify=true;
            this.Invalidate();
        }

        protected bool IsInASelectedItem(Point thePoint)
        {
            return SelectedComponentContaining(thePoint) != null ? true : false;
        }

        /**//// <summary>
        /// 给定点是否在任务节点上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>给定点在任务节点上,返回该任务节点,否则返回null</returns>        
        protected BaseComponent IsInAItem(Point thePoint)
        {
            int i;
            for(i=TaskItems.Count-1;i>=0;i--)
            {
                BaseComponent baseComponent=TaskItems[i] as BaseComponent;
                if(baseComponent.Contains(thePoint))
                    return baseComponent;
            }
            return null;
        }

        protected void MouseDownInAComponent(Point thePoint)
        {
            SelectedLine.Clear();
            BaseComponent c = SelectedComponentContaining(thePoint);
            if (c == null) 
                return;
            myBounds = new Bounds();
            myBounds.AddList(SelectedItems);
            dragger = new Dragger(this, SelectedItems, thePoint, myBounds);
        }

        #endregion
        //Windows 窗体设计器生成的代码
            #region Windows 窗体设计器生成的代码
        /**//// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlace));
            this.cmPanel = new System.Windows.Forms.ContextMenu();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuPrint = new System.Windows.Forms.MenuItem();
            this.menuPrintView = new System.Windows.Forms.MenuItem();
            this.WorkPlaceCloseFlow = new System.Windows.Forms.MenuItem();
            this.menuDelete = new System.Windows.Forms.MenuItem();
            this.menuProperty = new System.Windows.Forms.MenuItem();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.view = new System.Windows.Forms.PrintPreviewDialog();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuTaskLine = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // cmPanel
            // 
            this.cmPanel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSave,
            this.menuPrint,
            this.menuPrintView,
            this.WorkPlaceCloseFlow});
            // 
            // menuSave
            // 
            this.menuSave.Index = 0;
            this.menuSave.Text = "保存";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.Index = 1;
            this.menuPrint.Text = "打印";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintView
            // 
            this.menuPrintView.Index = 2;
            this.menuPrintView.Text = "打印预览";
            this.menuPrintView.Click += new System.EventHandler(this.menuPrintView_Click);
            // 
            // WorkPlaceCloseFlow
            // 
            this.WorkPlaceCloseFlow.Index = 3;
            this.WorkPlaceCloseFlow.Text = "关闭";
            this.WorkPlaceCloseFlow.Click += new System.EventHandler(this.WorkPlaceCloseFlow_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Index = -1;
            this.menuDelete.Text = "删除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuProperty
            // 
            this.menuProperty.Index = -1;
            this.menuProperty.Text = "属性";
            this.menuProperty.Click += new System.EventHandler(this.menuProperty_Click);
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // view
            // 
            this.view.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.view.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.view.ClientSize = new System.Drawing.Size(400, 300);
            this.view.Enabled = true;
            this.view.Icon = ((System.Drawing.Icon)(resources.GetObject("view.Icon")));
            this.view.Name = "view";
            this.view.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuTaskLine});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "删除";
            this.menuItem1.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuTaskLine
            // 
            this.menuTaskLine.Index = 1;
            this.menuTaskLine.Text = "属性";
            this.menuTaskLine.Click += new System.EventHandler(this.WorkPlace_DoubleClick);
            // 
            // WorkPlace
            // 
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(1000, 1000);
            this.AutoScrollMinSize = new System.Drawing.Size(15, 15);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Name = "WorkPlace";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(5600, 5080);
            this.Load += new System.EventHandler(this.WorkPlace_Load);
            this.DoubleClick += new System.EventHandler(this.WorkPlace_DoubleClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkPlace_Paint);
            this.Click += new System.EventHandler(this.menuTaskLine_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkPlace_MouseMove);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkPlace_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkPlace_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkPlace_MouseUp);
            this.ResumeLayout(false);

        }
        #endregion
        private bool isReadOnly()
        {
            if (!this.CanEdit)
            {
                MsgBox.ShowAskMessageBox("只读状态不允许修改!");
                
                this.dragger=null;    
            }
            
            return CanEdit;

        }

       // OnPaint 重画事件
            #region OnPaint 重画事件
        /**//// <summary>
        /// 重绘的区域/ 
        /// </summary>
        /// <param name="start">重绘区域的起始点</param>
        /// <param name="end">重绘区域的终止点</param>
        /// <returns></returns>
        private Region reDrawRegion(Point start,Point end)
        {
            int dx;
            int dy;                
            Point[] point = new Point[]{start, start, end, end, start};
            int width = 3;
            if ( end.Y == start.Y )
            {
                dx = 0;
                dy = width;
            }
            else
            {
                dx = width;
                float k = ( start.X - end.X ) / ( end.Y - start.Y );
                dy = (int)(dx * k);
            }
            point[0].Offset(-dx,-dy);
            point[1].Offset(dx,dy);
            point[2].Offset(dx,dy);
            point[3].Offset(-dx,-dy);
            point[4]=point[0];
            GraphicsPath graphicsPath=new GraphicsPath();
            graphicsPath.AddLines(point);
            Region region=new Region(graphicsPath);
            return region;            
        }
        private void WorkPlace_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            System.Drawing.Font font = new System.Drawing.Font("楷体_GB2312", 14, FontStyle.Regular);
            string displayName =WorkFlowCaption;
            StringFormat alignVertically = new StringFormat();
            SizeF sizeF = e.Graphics.MeasureString(displayName,font);
            int Stringx = 400;
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            e.Graphics.DrawString(displayName, font, Brushes.Black,Stringx, 60, alignVertically);  

            if ( Module==0 && isDrawingLine == true)
            {
                Pen pen=new Pen(Color.Green,1);
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3,3);
                pen.CustomEndCap = Arrow;
               
                e.Graphics.DrawLine(pen, startPoint, endPoint);                
            }
            //折线的画图在l中已经画了.不需要再加.因为直线已经生成了.不同于画直线的是:画直线是在鼠标释放时才生成的直线对象/                    
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            foreach (BaseComponent c in TaskItems)
                c.OnPaint(e);
            foreach(Link l in LineItems)    
            {
                l.OnPaint(e);                                
            }
            if(dragger!=null)
                myBounds.OnPaint(e);
            
        }
        //MouseDown 鼠标按下事件
        #endregion
        
            #region MouseDown 鼠标按下事件
        private void WorkPlace_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //点击的是右键
            if (MouseButtons== MouseButtons.Right)
            {
                if ( SelectedLine.Count != 0 &&SelectedItems.Count == 0 )//选中直线，没有选中任务节点
                {
                    this.ContextMenu = this.contextMenu;                
                }
                else if ( SelectedItems.Count > 0 )//选中任务节点
                {
                    this.ContextMenu = this.contextMenu;                                    
                }
                else//直线和任务节点都没有选中
                    this.ContextMenu = this.cmPanel;                    
                return;
            }
            //点击的是左键
            if(toolModel==true)//工具模式下
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                
                //操作节点
                switch(this.Module)
                {
                    case 1:
                        this.stID++;
                        StartTask st=new StartTask(p,stID);
                        AddItem(st,1);                        
                        break;
                    case 2:
                        this.endtID++;
                        EndTask endt=new EndTask(p,endtID);
                        AddItem(endt,2);                        
                        break;
                    case 3:
                        this.altID++;
                        AlternateTask at=new AlternateTask(p,altID);
                        AddItem(at,3);                        
                        break;
                    case 4:
                        this.jtID++;
                        JudgeTask jt=new JudgeTask(p,jtID);
                        AddItem(jt,4);                    
                        break;
                    case 5:
                        this.etID++;
                        ViewTask et=new ViewTask(p,etID);
                        AddItem(et,5);                        
                        break;
                    
                    case 6:
                        this.subID++;
                        SubFlowTask sft=new SubFlowTask(p,subID);
                        AddItem(sft,6);
                        break;
                                    

                    case 0://连线                
                        Point point=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                        foreach(BaseComponent c in TaskItems)
                        {
                            if(c.Contains(point))
                            {
                                startTask=c;
                                this.isDrawingLine = true;
                                startPoint.X = e.X;
                                startPoint.Y = e.Y;    
                                break;
                            }
                            else
                            {
                                startTask=null;    
                                this.isDrawingLine = false;                        
                            }
                        }
                        break;
                    case -1://自连线
                        point=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                        foreach(BaseComponent c in TaskItems)
                        {
                            if(c.Contains(point))
                            {
                                startTask=c;                                                            
                                endTask=c;    
                                Link lnk=new Link(startTask,endTask);
                                lnk.flowGuid=this.WorkFlowId;
                                this.LineItems.Add(lnk);
                                IsModify = true;
                                this.Invalidate();
                                break;
                            }                
                        }                        
                        break;
                    
                }
                if (nowButton != null&&LockModel==false) nowButton.Checked = false;    //添加完后修改toolbar按钮为非选中状态
               
            }
            else//非工具模式下
            {
                Point p=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                BaseComponent baseComponent = IsInAItem(p);
                link=IsInALine(p);
                if(baseComponent!= null)//鼠标点击了某一个任务节点
                {
                    if (IsInASelectedItem(p) )
                    {
                        MouseDownInAComponent(p);
                    }
                    else
                    {
                        SelectedItems.Clear();                    
                        SelectedItems.Add(baseComponent);
                        SelectedLine.Clear();
                        MouseDownInAComponent(p);
                        this.Invalidate();
                    }
                }
                else
                {
                    if(link!=null)//点击了某条连线
                    {
                        SelectedLine.Clear();
                        SelectedLine.Add(link);
                        SelectedItems.Clear();
                        //点中的是锚点话,拖动锚点或者删除,在这里认为是拖动.利用函数来找出startPoint,endPoint和breakIndex等
                        isInAnchor=IsInAnchor(p);                        
                        breakPoint=p;
                        this.Invalidate();
                    }
                    else
                    {
                        SelectedItems.Clear();
                        SelectedLine.Clear();
                        if (e.Button == MouseButtons.Right)
                            return;
                        else
                            rubberband = new Rubberband(this, p);
                    }
                }
                //this.label1.Text=SelectedLine.Count.ToString();
            }
        
        }
        #endregion
       // MouseMove 鼠标移动事件
            #region MouseMove 鼠标移动事件
        /**//// <summary>
        /// 鼠标键移动时执行该函数，首先判断是否是在画线,如果是就进行画线处理;
        /// 然后判断是否在进行节点的拖拽操作，
        /// 如果是，就调用dragger的MoveT函数处理；否则，就判断是否在绘制橡皮圈，如果是，就调用rubberband的ResizeTo函数调整橡皮圈的大小。
        /// 同时，函数还调用了BaseComponent类的方法Contains判断当前点是否在某个任务节点的边框内。
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (this.Module==0 && isDrawingLine == true )//判断是否画线
            {
                Region region=reDrawRegion(startPoint,endPoint);
                this.Invalidate(region);
                endPoint.X = e.X;
                endPoint.Y = e.Y;
                
            }

            if(this .SelectedLine.Count>0&&e.Button==MouseButtons.Left)//拖拽连线，画锚点。
            {
                if (!isReadOnly()) return;//判断是否只读状态
                Link line=(Link)SelectedLine[0];
                if(line.startTask!=line.endTask)
                {   
                    //删除锚点时,breakIndex已经不等于-1.
                    //只有拖动时才知道是添加锚点所以在这里求出breakIndex.
                    if(this.breakIndex==-1)//新锚点
                    {
                        this.breakIndex=link.BreakIndex(breakPoint);
                        startPoint.X=Convert.ToInt16(link.breakPointX[breakIndex-1]);
                        startPoint.Y=Convert.ToInt16(link.breakPointY[breakIndex-1]);

                        endPoint.X=Convert.ToInt16(link.breakPointX[breakIndex]);
                        endPoint.Y=Convert.ToInt16(link.breakPointY[breakIndex]);

                        link.breakPointX.Insert(breakIndex,breakPoint.X);
                        link.breakPointY.Insert(breakIndex,breakPoint.Y);
                    }
                    
                    if(breakIndex>=0&&breakIndex<link.breakPointX.Count)//已存在锚点
                    {
                        Region region=reDrawRegion(startPoint,breakPoint);
                        this.Invalidate(region);
                        region=reDrawRegion(breakPoint,endPoint);
                        this.Invalidate(region);            
                        link.breakPointX[breakIndex]=breakPoint.X;//为了画折线时拖动不需要画原来的    
                        link.breakPointY[breakIndex]=breakPoint.Y;
                        breakPoint.X = e.X;
                        breakPoint.Y = e.Y;    
                        isZhexian=true;                                    
                    }
                    IsModify = true;
                }
                
            }
            Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            if (dragger != null)
            {
                if (!isReadOnly()) return;//判断是否只读状态
                this.Cursor=Cursors.Hand;
                dragger.DragT(p);
                IsModify=true;
            }
            else
                this.Cursor = Cursors.Default;
            if (rubberband != null)//重定位橡皮圈的位置
                rubberband.ResizeTo(p);
            // set the cursor if the mouse is over a selected item
            foreach (BaseComponent c in SelectedItems)
            {
                if (c.Contains(p) )
                {
                    this.Cursor = c.GetCursor(p);
                    return;
                }
            }    
        }
        #endregion
       // MouseUp鼠标抬起事件
            #region MouseUp鼠标抬起事件
        /**//// <summary>
        /// 鼠标键抬起时执行该函数.
        /// 由于连线可以拖动来画,所以鼠标抬起时表示可以画一条连线.
        /// 由于连线的折点可以改变位置，所以鼠标抬起时也可能是折点位置修改好了。
        /// 切换工具的工作模式， 然后判断橡皮圈是否圈选了某些节点，如果是，就把它们添加到SelectedItems中。
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(toolModel==true)//工具模式下
            {
                if(this.Module==0&&isDrawingLine==true)//画线,终止点
                {
                    Point point=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                    foreach(BaseComponent c in TaskItems)
                    {
                        if(c.Contains(point))
                        {
                            endTask=c;                            
                            if(endTask!=startTask)
                            {
                                Link l = new Link(startTask,endTask);
                                l.flowGuid = this.WorkFlowId;
                                LineItems.Add(l);
                                IsModify = true;                                            
                                //添加Undo操作用的
                                
                                //    his.OperationLineItem.Add(l);
                            }
                            this.isDrawingLine = false;                                                
                            break;
                        }
                        else
                        {
                            endTask=null;                            
                            this.isDrawingLine = false;                                                
                        }
                    }
                    this.Invalidate();                                
                }    
                toolModel=LockModel;//是否锁定，画多个任务节点
                
            }        
            Point p=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            //折线                        
            if(this.SelectedLine.Count>0&&this.CanEdit)
            {
                if(this.SelectedLine.Count>0)
                {    
                    //                    oldBreakPoint.Add(link.breakPoint);    
                    if(this.isZhexian)
                    {
                        link.breakPointX[breakIndex]=p.X;
                        link.breakPointY[breakIndex]=p.Y;
                        this.breakIndex=-1;
                        this.isZhexian=false;
                        IsModify = true;
                    }
//                    this.OperationLineItem.Add(link);
                    //                    this.OperationType.Add(UndoType.Zhexian);
                    this.Invalidate();
                                            
                }                
            }
            //拖拽
            if (dragger != null)
            {
                if(this.CanEdit&&!dragger.location.Equals(p))
                {
                    dragger.DragTo(p);                                    
                    dragger.End();
                    IsModify = true;
                }
                dragger = null;                
                return;
            }
            //橡皮圈选择区域时的鼠标释放
            if (rubberband != null)
            {
                Rectangle rect = rubberband.Bounds();
                rubberband.End();
                rubberband = null;            
                foreach (BaseComponent c in TaskItems)
                {
                    if (rect.Contains(c.bounds) )
                        SelectedItems.Add(c);
                }
                this.Invalidate();
            }
                
            
        }
        #endregion    
        
        
        private void menuDelete_Click(object sender, System.EventArgs e)
        {
             deleteSelect();    
        }


        private void menuSave_Click(object sender, System.EventArgs e)
        {
            SaveWorkFlow();
            
        }

        private void menuPrint_Click(object sender, System.EventArgs e)
        {
            PrintDialog print=new PrintDialog();
            print.Document=this.printDoc;
            
            if(print.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    this.printDoc.Print();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }

        private void menuPrintView_Click(object sender, System.EventArgs e)
        {
            try
            {                
                view.Document=this.printDoc;
                view.ShowDialog();        
            }
            catch(Exception ex)
            {
                MsgBox.ShowWarningMessageBox ("打印出错,错误代码:"+ex.Message);
                
            }
        
        }
       // 打印
            #region 打印
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for(int i=0;i<this.TaskItems.Count;i++)
            {
                BaseComponent  bc=(BaseComponent)TaskItems[i];
                Bitmap bitmap=null;
                switch(bc.TaskType)
                {
                    case 1:
                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.启动节点.ico")));
                        break;
                    case 2:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.终止节点.ico")));
                        break;
                    case 3:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.交互节点.ico")));
                        break;
                    case 4:


                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.控制节点.ico")));
                        break;
                    case 5:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.查看节点.ico")));
                        break;
                    case 6:
                        
                        bitmap=new  Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.子流程节点.ico")));
                        break;
                    default:
                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.查看节点.ico")));
                        break;     
                }                        
                Point point=new Point (bc.X,bc.Y);                
                e.Graphics.DrawImage(bitmap,point.X,point.Y,32,32);
                //流程名称    
                System.Drawing.Font f=new System.Drawing.Font("宋体", 18, FontStyle.Bold);
                string displayName = WorkFlowCaption;
                StringFormat alignVertically = new StringFormat();
                SizeF sizef = e.Graphics.MeasureString(displayName,f);
                int Stringx = (this.Width - ((int)sizef.Width))/2;
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.DrawString(displayName, f, Brushes.Black, Stringx, 25, alignVertically);                        
                //写出图片的名字
                System.Drawing.Font font=new System.Drawing.Font("Arial",8);
                Rectangle bounds=bc.bounds;                
                SizeF sizeF = e.Graphics.MeasureString(bc.TaskName,font);
                int Namex=bounds.Left-((int)sizeF.Width)/2+bounds.Width/2;                            
                e.Graphics.DrawString(bc.TaskName, font, Brushes.Black, Namex,bounds.Top+40, alignVertically);                  
            }
            //画线
            for(int i=0;i<LineItems.Count;i++)
            {
                Link line=(Link)LineItems[i];
                Pen pen=new Pen(Color.Green,1);                    
                
                for(int m=0;m<line.breakPointX.Count-2;m++)
                {
                    Point bp=new Point (Convert.ToInt16(line.breakPointX[m]),Convert.ToInt16(line.breakPointY[m]));
                    Point bp2=new Point (Convert.ToInt16(line.breakPointX[m+1]),Convert.ToInt16(line.breakPointY[m+1]));
                    e.Graphics.DrawLine(pen,bp,bp2);                            
                }
                //画最后一条带箭头的
                Point tt=new Point (Convert.ToInt16(line.breakPointX[line.breakPointX.Count-2]),Convert.ToInt16(line.breakPointY[line.breakPointX.Count-2]));
                Point tt2=new Point (Convert.ToInt16(line.breakPointX[line.breakPointX.Count-1]),Convert.ToInt16(line.breakPointY[line.breakPointX.Count-1]));
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3,3);
                pen.CustomEndCap=Arrow;

                if (line.haveback)
                    pen.CustomStartCap = Arrow;
                e.Graphics.DrawLine(pen,tt,tt2);

               
                //画注释    
                if (line.Des == "" && !line.endTask.haveback)       
                    continue;
                Font font=new Font("Arial",8);
                StringFormat alignVertically=new StringFormat();
                alignVertically.LineAlignment=StringAlignment.Center;//指定文本在布局矩形中居中对齐
                SizeF sizeF=e.Graphics.MeasureString(line.Des,font);        
                int x=((int)line.breakPointX[0]+(int)line.breakPointX[1]-(int)sizeF.Width)/2;
                int y=((int)line.breakPointY[0]+(int)line.breakPointY[1])/2;
                if (line.endTask.haveback)
                {
                    //if (Des.IndexOf("/退回") < 0)
                    e.Graphics.DrawString(line.Des + "/退回", font, Brushes.Blue, x, y, alignVertically);

                }
                else
                {
                    e.Graphics.DrawString(line.Des + "/退回", font, Brushes.Blue, x, y, alignVertically);
                }
                   
            }

        }
        #endregion
        
        /**//// <summary>
        /// 删除选中的节点或者连线
        /// </summary>
        private void deleteSelect()
        {
            if (PowerData.IsPower(UserId, "070101") == false)
            {

                MsgBox .ShowTipMessageBox ("用户 " + UserId + " 没有 070101 的操作权限!");
                return;
            }

            if(SelectedItems.Count>0)
            {
                this.FuncDeleteTask();
            }
            if(SelectedLine.Count>0)
            {
                if(link.selectedAnchor>=0&&link.selectedAnchor<link.breakPointX.Count)
                {
                    link.breakPointX.RemoveAt(link.selectedAnchor);
                    link.breakPointY.RemoveAt(link.selectedAnchor);
                    link.selectedAnchor=-1;
                    this.Invalidate();
                }                    
                else
                    this.FuncDeleteLine();
            }
        }

        
        private void FuncDeleteTask()
        {
            if (!isReadOnly()) return;//判断是否只读状态
            DialogResult result = MessageBox.Show("确定要删除所选的任务节点吗?","提示!",MessageBoxButtons.OKCancel);
            if ( result != DialogResult.OK )
                return;
            int lineNum=0,taskNodeNum=0;
            foreach(BaseComponent c in SelectedItems)
            {
                for ( int i = LineItems.Count - 1; i >= 0; i-- )
                {
                    if ( ((Link)LineItems[i]).startTask == c || ((Link)LineItems[i]).endTask == c )
                    {
                        Link l=(Link)LineItems[i];
                        LineItems.Remove(l);
                        WorkFlowLink.DeleteLine(WorkFlowId, l.linkGuid);
                        
                        lineNum++;
                    }
                }
                TaskItems.Remove(c);
                WorkFlowTask.DeleteTask(WorkFlowId, c.TaskId);
                taskNodeNum++;
                IsModify = true;
            }    

            SelectedItems.Clear();
            SelectedLine.Clear();
            this.Invalidate();
        }
        
        private void FuncDeleteLine()
        {    
            if (!isReadOnly()) return;//判断是否只读状态
            Link l=(Link)SelectedLine[0];
            LineItems.Remove(l);
            //WorkFlowData.DeleteLineDB(WorkFlowId,l.linkGuid);
            WorkFlowLink.DeleteLine(WorkFlowId, l.linkGuid);
            SelectedLine.Clear();
            IsModify=true;
            this.Invalidate();
        }
        private void WorkPlace_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if ( e.KeyCode == Keys.Delete )
            {
                deleteSelect();
            }
        }
        
        /**//// <summary>
        /// 清楚资源
        /// </summary>
        private void clearAndMenu()
        {        
            SelectedItems.Clear();
            SelectedLine.Clear();
            TaskItems.Clear();
            LineItems.Clear();        
            this.IsModify=false;
            
            
        }

        private void WorkPlaceCloseFlow_Click(object sender, System.EventArgs e)
        {
            this.closeFlow();
        }
        /**//// <summary>
        /// 点击关闭流程模版
        /// </summary>    
        public  void  closeFlow()
        {    
            
            if(!this.IsModify)//流程没有改变,不用保存直接关闭流程
            {
                this.clearAndMenu();
            }
            else
            {
                
                DialogResult result = MsgBox.ShowAskMessageBox ("是否保存对[" + WorkFlowCaption + "]的修改?");
                if (result==DialogResult.OK )
                {/**/////保存流程并关闭流程            
                    SaveWorkFlow();
                    this.clearAndMenu();                    
                }
                else if (result==DialogResult.Cancel )
                {//不保存,关闭流程
                    this.clearAndMenu();
                    
                }
                
            }

        }

        private void menuProperty_Click(object sender, System.EventArgs e)
        {
        
        }    

    public void PanelPass( System.Windows.Forms.ToolBar toolBar,System.Windows.Forms.ToolBarButton btnLock1)
    {
        //this.toolBar = toolBar;
        //this.btnLock = btnLock1;

    }

        private void menuTaskLine_Click(object sender, System.EventArgs e)
        {  
        
        }

        private void WorkPlace_DoubleClick(object sender, System.EventArgs e)
        {
            //节点属性
            if (SelectedItems.Count==1)
            {

                BaseComponent tmpBaseComponent=(BaseComponent)SelectedItems[0];
                if (tmpBaseComponent.TaskType == 2) //结束节点
                    return;
                Object[] objArray=new object[3];
                objArray[0]=tmpBaseComponent;
                objArray[1]=this.UserId;
                objArray[2]=this.UserName;
                DynamicLibrary myDll=new DynamicLibrary();
                myDll.DllFileName=tmpBaseComponent.DllFileName;;
                myDll.DllClassName=tmpBaseComponent.DllClassName;
                myDll.ObjArray=objArray;
                myDll.CallSDIWindows();
                this.Invalidate();    
            }
            else//连线属性
                if (SelectedLine.Count==1)
            {
                Link tmpLink=(Link)SelectedLine[0];
                Object[] objArray=new object[3];
                objArray[0]=tmpLink;
                objArray[1]=this.UserId;
                objArray[2]=this.UserName;
                //DynamicLibrary myDll = new DynamicLibrary();
                //myDll.DllFileName = tmpLink.DllFileName; ;
                //myDll.DllClassName = tmpLink.DllClassName;
                //myDll.ObjArray = objArray;
                //myDll.CallSDIWindows();
                fmLinkConfig fromCtrl = new fmLinkConfig(tmpLink, UserId, UserName);
                fromCtrl.ShowDialog();
            }
        
        }
        public void SaveWorkFlow()
        {
            try
            {
                WorkFlowData tmpWorkflow = new WorkFlowData();
                tmpWorkflow.SaveWorkFlow(WorkFlowId, TaskItems, LineItems, State);
                IsModify = false;
                MsgBox.ShowTipMessageBox ("保存成功!");
            }
            catch(Exception ex)
            {
                MsgBox .ShowWarningMessageBox ("保存失败，错误代码:"+ex.Message.ToString());
            }
        }
        private void WorkPlace_Load(object sender, EventArgs e)
        {

        }


        
       

    }
}