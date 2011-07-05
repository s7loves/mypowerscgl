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
    /// WorkPlace ��ժҪ˵����
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

        private int stID;//�����ڵ����
        private int endtID;//��ֹ�ڵ����
        private int altID;//�����ڵ����
        private int jtID;//�жϽڵ����
        private int etID;//�鿴�ڵ����
        private int autoID;//�Զ��ڵ����
        private int conID;//���ƽڵ����
        private int subID;//�����̽ڵ����
        private Rubberband rubberband = null;//��ƤȦ                                    
        private Dragger dragger = null;    //��ק����
        private bool isZhexian;//ѡ�е����ߵ�ѡ���۵������
        private int breakIndex;
        private bool isInAnchor;
        private bool isDrawingLine;
        private Link link;    //������ʱѡ�е�ֱ��.��Ϊ�ƶ�����϶�ʱ����Ҫ��ԭ����ֱ��
        private Point startPoint, endPoint,breakPoint;
        private Bounds myBounds;
        private BaseComponent startTask, endTask;  

        /**//// <summary>
        /// ����ģ�����нڵ��б�
        /// </summary>
        public ArrayList TaskItems = new ArrayList();
        /**//// <summary>
        /// ����ģ�����������б�
        /// </summary>
        public ArrayList LineItems=new ArrayList();    
        /**//// <summary>
        /// ѡ�еĽڵ��б�
        /// </summary>
        public SelectedItems SelectedItems = new SelectedItems();
        /**//// <summary>
        /// ѡ�е������б�
        /// </summary>
        public SelectedLine SelectedLine=new SelectedLine();
        public ToolStripButton nowButton;
           

        
        /**//// <summary>
        /// ��������ͼ���ģʽ��ֻ�������ģʽ���ܻ�����ڵ����
        /// </summary>
        public bool toolModel;
        /**//// <summary>
        /// �ڵ�ģʽ������ģʽ��1--�����ڵ㣻2-��ֹ�ڵ�;3-�����ڵ�;4-�жϽڵ�;5-�鿴�ڵ�;6-�Զ��ڵ�;7-���ƽڵ�;
        /// 8-�����̽ڵ㣻0������,-1-������;
        /// </summary>
        public int Module;
        /**//// <summary>
        /// ��ͼ������ͬʱ���������ڵ�ʱLockModel=true
        /// </summary>
        public bool LockModel;    
        /**//// <summary>
        /// ����ģ������
        /// </summary>
        public string WorkFlowCaption="";
        /**//// <summary>
        /// ����ģ��Id
        /// </summary>
        public string WorkFlowId="";
        /**//// <summary>
        /// �޸ġ��½����鿴����״̬
        /// </summary>
        public string State;        
        /**//// <summary>
        /// �Ƿ�����༭
        /// </summary>
        public bool CanEdit;
        /**//// <summary>
        /// �Ƿ��޸�
        /// </summary>
        public bool IsModify=false;
        /**//// <summary>
        /// �������˺ţ�����Ȩ���жϡ�
        /// </summary>
        public string UserId = "";
        /**//// <summary>
        /// ������������������ʾ��
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
        #region ��ͼ����
        /**//// <summary>
        /// ������������ʹ�õ���Դ����ͼ����
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
        /// �жϵ�p�Ƿ���ֱ�ߵ�ĳ��ê��,ͬʱ��һЩ׼������
        /// </summary>
        /// <param name="p"></param>
        /// <returns>p��ֱ�ߵ�ĳ��ê��,����true,����false </returns>

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
        /// �������Ƿ���ѡ����ֱ����
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>thePoint��ѡ����ĳһֱ���Ϸ��ظ�ֱ��,���򷵻�null</returns>

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
        /// �������Ƿ���ѡ�е�����ڵ���
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>���������thePoint��ĳһѡ�е�����ڵ��Ϸ��ظ�����ڵ�,����ķ���null</returns>
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
        /// �������Ƿ�������ڵ���
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>������������ڵ���,���ظ�����ڵ�,���򷵻�null</returns>        
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
        //Windows ������������ɵĴ���
            #region Windows ������������ɵĴ���
        /**//// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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
            this.menuSave.Text = "����";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.Index = 1;
            this.menuPrint.Text = "��ӡ";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintView
            // 
            this.menuPrintView.Index = 2;
            this.menuPrintView.Text = "��ӡԤ��";
            this.menuPrintView.Click += new System.EventHandler(this.menuPrintView_Click);
            // 
            // WorkPlaceCloseFlow
            // 
            this.WorkPlaceCloseFlow.Index = 3;
            this.WorkPlaceCloseFlow.Text = "�ر�";
            this.WorkPlaceCloseFlow.Click += new System.EventHandler(this.WorkPlaceCloseFlow_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Index = -1;
            this.menuDelete.Text = "ɾ��";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuProperty
            // 
            this.menuProperty.Index = -1;
            this.menuProperty.Text = "����";
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
            this.menuItem1.Text = "ɾ��";
            this.menuItem1.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuTaskLine
            // 
            this.menuTaskLine.Index = 1;
            this.menuTaskLine.Text = "����";
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
                MsgBox.ShowAskMessageBox("ֻ��״̬�������޸�!");
                
                this.dragger=null;    
            }
            
            return CanEdit;

        }

       // OnPaint �ػ��¼�
            #region OnPaint �ػ��¼�
        /**//// <summary>
        /// �ػ������/ 
        /// </summary>
        /// <param name="start">�ػ��������ʼ��</param>
        /// <param name="end">�ػ��������ֹ��</param>
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

            System.Drawing.Font font = new System.Drawing.Font("����_GB2312", 14, FontStyle.Regular);
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
            //���ߵĻ�ͼ��l���Ѿ�����.����Ҫ�ټ�.��Ϊֱ���Ѿ�������.��ͬ�ڻ�ֱ�ߵ���:��ֱ����������ͷ�ʱ�����ɵ�ֱ�߶���/                    
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
        //MouseDown ��갴���¼�
        #endregion
        
            #region MouseDown ��갴���¼�
        private void WorkPlace_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //��������Ҽ�
            if (MouseButtons== MouseButtons.Right)
            {
                if ( SelectedLine.Count != 0 &&SelectedItems.Count == 0 )//ѡ��ֱ�ߣ�û��ѡ������ڵ�
                {
                    this.ContextMenu = this.contextMenu;                
                }
                else if ( SelectedItems.Count > 0 )//ѡ������ڵ�
                {
                    this.ContextMenu = this.contextMenu;                                    
                }
                else//ֱ�ߺ�����ڵ㶼û��ѡ��
                    this.ContextMenu = this.cmPanel;                    
                return;
            }
            //����������
            if(toolModel==true)//����ģʽ��
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                
                //�����ڵ�
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
                                    

                    case 0://����                
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
                    case -1://������
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
                if (nowButton != null&&LockModel==false) nowButton.Checked = false;    //�������޸�toolbar��ťΪ��ѡ��״̬
               
            }
            else//�ǹ���ģʽ��
            {
                Point p=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                BaseComponent baseComponent = IsInAItem(p);
                link=IsInALine(p);
                if(baseComponent!= null)//�������ĳһ������ڵ�
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
                    if(link!=null)//�����ĳ������
                    {
                        SelectedLine.Clear();
                        SelectedLine.Add(link);
                        SelectedItems.Clear();
                        //���е���ê�㻰,�϶�ê�����ɾ��,��������Ϊ���϶�.���ú������ҳ�startPoint,endPoint��breakIndex��
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
       // MouseMove ����ƶ��¼�
            #region MouseMove ����ƶ��¼�
        /**//// <summary>
        /// �����ƶ�ʱִ�иú����������ж��Ƿ����ڻ���,����Ǿͽ��л��ߴ���;
        /// Ȼ���ж��Ƿ��ڽ��нڵ����ק������
        /// ����ǣ��͵���dragger��MoveT�����������򣬾��ж��Ƿ��ڻ�����ƤȦ������ǣ��͵���rubberband��ResizeTo����������ƤȦ�Ĵ�С��
        /// ͬʱ��������������BaseComponent��ķ���Contains�жϵ�ǰ���Ƿ���ĳ������ڵ�ı߿��ڡ�
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (this.Module==0 && isDrawingLine == true )//�ж��Ƿ���
            {
                Region region=reDrawRegion(startPoint,endPoint);
                this.Invalidate(region);
                endPoint.X = e.X;
                endPoint.Y = e.Y;
                
            }

            if(this .SelectedLine.Count>0&&e.Button==MouseButtons.Left)//��ק���ߣ���ê�㡣
            {
                if (!isReadOnly()) return;//�ж��Ƿ�ֻ��״̬
                Link line=(Link)SelectedLine[0];
                if(line.startTask!=line.endTask)
                {   
                    //ɾ��ê��ʱ,breakIndex�Ѿ�������-1.
                    //ֻ���϶�ʱ��֪�������ê���������������breakIndex.
                    if(this.breakIndex==-1)//��ê��
                    {
                        this.breakIndex=link.BreakIndex(breakPoint);
                        startPoint.X=Convert.ToInt16(link.breakPointX[breakIndex-1]);
                        startPoint.Y=Convert.ToInt16(link.breakPointY[breakIndex-1]);

                        endPoint.X=Convert.ToInt16(link.breakPointX[breakIndex]);
                        endPoint.Y=Convert.ToInt16(link.breakPointY[breakIndex]);

                        link.breakPointX.Insert(breakIndex,breakPoint.X);
                        link.breakPointY.Insert(breakIndex,breakPoint.Y);
                    }
                    
                    if(breakIndex>=0&&breakIndex<link.breakPointX.Count)//�Ѵ���ê��
                    {
                        Region region=reDrawRegion(startPoint,breakPoint);
                        this.Invalidate(region);
                        region=reDrawRegion(breakPoint,endPoint);
                        this.Invalidate(region);            
                        link.breakPointX[breakIndex]=breakPoint.X;//Ϊ�˻�����ʱ�϶�����Ҫ��ԭ����    
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
                if (!isReadOnly()) return;//�ж��Ƿ�ֻ��״̬
                this.Cursor=Cursors.Hand;
                dragger.DragT(p);
                IsModify=true;
            }
            else
                this.Cursor = Cursors.Default;
            if (rubberband != null)//�ض�λ��ƤȦ��λ��
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
       // MouseUp���̧���¼�
            #region MouseUp���̧���¼�
        /**//// <summary>
        /// ����̧��ʱִ�иú���.
        /// �������߿����϶�����,�������̧��ʱ��ʾ���Ի�һ������.
        /// �������ߵ��۵���Ըı�λ�ã��������̧��ʱҲ�������۵�λ���޸ĺ��ˡ�
        /// �л����ߵĹ���ģʽ�� Ȼ���ж���ƤȦ�Ƿ�Ȧѡ��ĳЩ�ڵ㣬����ǣ��Ͱ�������ӵ�SelectedItems�С�
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(toolModel==true)//����ģʽ��
            {
                if(this.Module==0&&isDrawingLine==true)//����,��ֹ��
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
                                //���Undo�����õ�
                                
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
                toolModel=LockModel;//�Ƿ����������������ڵ�
                
            }        
            Point p=new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            //����                        
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
            //��ק
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
            //��ƤȦѡ������ʱ������ͷ�
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
                MsgBox.ShowWarningMessageBox ("��ӡ����,�������:"+ex.Message);
                
            }
        
        }
       // ��ӡ
            #region ��ӡ
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for(int i=0;i<this.TaskItems.Count;i++)
            {
                BaseComponent  bc=(BaseComponent)TaskItems[i];
                Bitmap bitmap=null;
                switch(bc.TaskType)
                {
                    case 1:
                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico")));
                        break;
                    case 2:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.��ֹ�ڵ�.ico")));
                        break;
                    case 3:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico")));
                        break;
                    case 4:


                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.���ƽڵ�.ico")));
                        break;
                    case 5:

                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�鿴�ڵ�.ico")));
                        break;
                    case 6:
                        
                        bitmap=new  Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����̽ڵ�.ico")));
                        break;
                    default:
                        bitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�鿴�ڵ�.ico")));
                        break;     
                }                        
                Point point=new Point (bc.X,bc.Y);                
                e.Graphics.DrawImage(bitmap,point.X,point.Y,32,32);
                //��������    
                System.Drawing.Font f=new System.Drawing.Font("����", 18, FontStyle.Bold);
                string displayName = WorkFlowCaption;
                StringFormat alignVertically = new StringFormat();
                SizeF sizef = e.Graphics.MeasureString(displayName,f);
                int Stringx = (this.Width - ((int)sizef.Width))/2;
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.DrawString(displayName, f, Brushes.Black, Stringx, 25, alignVertically);                        
                //д��ͼƬ������
                System.Drawing.Font font=new System.Drawing.Font("Arial",8);
                Rectangle bounds=bc.bounds;                
                SizeF sizeF = e.Graphics.MeasureString(bc.TaskName,font);
                int Namex=bounds.Left-((int)sizeF.Width)/2+bounds.Width/2;                            
                e.Graphics.DrawString(bc.TaskName, font, Brushes.Black, Namex,bounds.Top+40, alignVertically);                  
            }
            //����
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
                //�����һ������ͷ��
                Point tt=new Point (Convert.ToInt16(line.breakPointX[line.breakPointX.Count-2]),Convert.ToInt16(line.breakPointY[line.breakPointX.Count-2]));
                Point tt2=new Point (Convert.ToInt16(line.breakPointX[line.breakPointX.Count-1]),Convert.ToInt16(line.breakPointY[line.breakPointX.Count-1]));
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3,3);
                pen.CustomEndCap=Arrow;

                if (line.haveback)
                    pen.CustomStartCap = Arrow;
                e.Graphics.DrawLine(pen,tt,tt2);

               
                //��ע��    
                if (line.Des == "" && !line.endTask.haveback)       
                    continue;
                Font font=new Font("Arial",8);
                StringFormat alignVertically=new StringFormat();
                alignVertically.LineAlignment=StringAlignment.Center;//ָ���ı��ڲ��־����о��ж���
                SizeF sizeF=e.Graphics.MeasureString(line.Des,font);        
                int x=((int)line.breakPointX[0]+(int)line.breakPointX[1]-(int)sizeF.Width)/2;
                int y=((int)line.breakPointY[0]+(int)line.breakPointY[1])/2;
                if (line.endTask.haveback)
                {
                    //if (Des.IndexOf("/�˻�") < 0)
                    e.Graphics.DrawString(line.Des + "/�˻�", font, Brushes.Blue, x, y, alignVertically);

                }
                else
                {
                    e.Graphics.DrawString(line.Des + "/�˻�", font, Brushes.Blue, x, y, alignVertically);
                }
                   
            }

        }
        #endregion
        
        /**//// <summary>
        /// ɾ��ѡ�еĽڵ��������
        /// </summary>
        private void deleteSelect()
        {
            if (PowerData.IsPower(UserId, "070101") == false)
            {

                MsgBox .ShowTipMessageBox ("�û� " + UserId + " û�� 070101 �Ĳ���Ȩ��!");
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
            if (!isReadOnly()) return;//�ж��Ƿ�ֻ��״̬
            DialogResult result = MessageBox.Show("ȷ��Ҫɾ����ѡ������ڵ���?","��ʾ!",MessageBoxButtons.OKCancel);
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
            if (!isReadOnly()) return;//�ж��Ƿ�ֻ��״̬
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
        /// �����Դ
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
        /// ����ر�����ģ��
        /// </summary>    
        public  void  closeFlow()
        {    
            
            if(!this.IsModify)//����û�иı�,���ñ���ֱ�ӹر�����
            {
                this.clearAndMenu();
            }
            else
            {
                
                DialogResult result = MsgBox.ShowAskMessageBox ("�Ƿ񱣴��[" + WorkFlowCaption + "]���޸�?");
                if (result==DialogResult.OK )
                {/**/////�������̲��ر�����            
                    SaveWorkFlow();
                    this.clearAndMenu();                    
                }
                else if (result==DialogResult.Cancel )
                {//������,�ر�����
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
            //�ڵ�����
            if (SelectedItems.Count==1)
            {

                BaseComponent tmpBaseComponent=(BaseComponent)SelectedItems[0];
                if (tmpBaseComponent.TaskType == 2) //�����ڵ�
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
            else//��������
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
                MsgBox.ShowTipMessageBox ("����ɹ�!");
            }
            catch(Exception ex)
            {
                MsgBox .ShowWarningMessageBox ("����ʧ�ܣ��������:"+ex.Message.ToString());
            }
        }
        private void WorkPlace_Load(object sender, EventArgs e)
        {

        }


        
       

    }
}