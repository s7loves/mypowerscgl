using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
namespace Ebada.SCGL.ExpressCalculate
{
    #region  ��ջ��
    /// <summary>
    /// ��ջ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class myllstack<T>
    {
        private Node<T> head;
        class Node<T>
        {
            public T data;
            public Node<T> next;
        }
        public myllstack()
        {
            head = new Node<T>();
            head.next = null;
        }

        #region ѹ���ջ
        public void Push(T data)
        {

            Node<T> tem;

            tem = head.next;
            head.next = new Node<T>();
            head.next.next = tem;  
            head.next.data = data;

        }

        #endregion
        #region ��ջ
        public bool Pop(ref T data)
        {

            if (head.next != null)
            {
                data = head.next.data;
                Node<T> tem = head.next.next;
                head.next = tem;
                return true;

            }
            else
                return false;
        }
        #endregion
        #region ��ȡջ����ֵ
        public bool Get(ref T data)
        {

            if (head.next != null)
            {
                data = head.next.data;
                return true;

            }
            else
                return false;
        }
        #endregion

    }
    #endregion
    #region �ʷ������
    class WordAnalyse
    {
        const int MaxWordNum = 500;
        const int MaxWordLength = 500;
        protected char[,] Words = new char[MaxWordNum, MaxWordLength];
        protected int[] WordsAttribute = new int[MaxWordNum];
        protected int CurrentWordNum;
        protected string pCurrentLocation;
        protected string pLastLocation;
        protected bool bResult;
        protected bool WordType;
        protected char[] Expression = new char[MaxWordLength];

        public WordAnalyse(string chExpression)
        {

            int i, j;
            for (i = 0; i < MaxWordNum; i++)
            {
                for (j = 0; j < MaxWordLength; j++)
                    Words[i, j] = '\0';
                WordsAttribute[i] = 0;

            }
            CurrentWordNum = 0;
            pCurrentLocation = "";
            for (i = 0; i < 100; i++)
            {
                if (i == 0)
                    Expression[0] = '(';
                else
                    Expression[i] = '\0';
            }
            char[] chExpressiontemp = chExpression.ToCharArray();
            for (i = 0; i < chExpression.Length; i++)
            {
                Expression[i + 1] = chExpressiontemp[i];
            }


            for (i = 0; i < Expression.Length; i++)
            {
                if (i != 0)
                    pCurrentLocation += Expression[i];
                pLastLocation += Expression[i];
            }


            bResult = WordsAnalyse();
            WordType = IsAllDouble();


        }
        protected bool IsAllDouble()
        {
            for (int i = 0; i < CurrentWordNum; i++)
            {
                if (WordsAttribute[i] == 1 || Words[i, 0].CompareTo('/') == 0)
                    return true;
            }
            return false;
        }
        protected bool WordsAnalyse()
        {
            int i = 0;
            while (pCurrentLocation[i] != '\0')
                if (!GenerateWord(ref i))
                    return false;
            return true;

        }
        protected bool GenerateWord(ref int p)
        {

            if (pCurrentLocation[p] == ' ')
                do
                {
                    p++;
                }
                while (pCurrentLocation[p] == ' ');

            switch (pCurrentLocation[p])
            {
                case '+':
                case '*':
                case '/':
                case '(':
                case ')':
                case '#':
                case '^':
                    Words[CurrentWordNum, 0] = pCurrentLocation[p];
                    WordsAttribute[CurrentWordNum] = 2;
                    CurrentWordNum++;
                    pLastLocation = pCurrentLocation.Substring(p);
                    p++;

                    return true;
                case '-':
                    int j = 0;
                    if (pLastLocation[j] != '(')    // - ��Ϊ˫Ŀ������
                    {
                        Words[CurrentWordNum, 0] = pCurrentLocation[p];
                        WordsAttribute[CurrentWordNum] = 2;

                    }
                    else                             //��Ϊ��Ŀ������
                    {
                        Words[CurrentWordNum, 0] = '0';
                        WordsAttribute[CurrentWordNum] = 0;
                        CurrentWordNum++;

                        Words[CurrentWordNum, 0] = '-';
                        WordsAttribute[CurrentWordNum] = 2;

                    }

                    CurrentWordNum++;
                    pLastLocation = pCurrentLocation.Substring(p);
                    p++;

                    return true;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    int i;
                    i = 0;
                    do
                    {
                        Words[CurrentWordNum, i++] = pCurrentLocation[p];
                        pLastLocation = pCurrentLocation.Substring(p);
                        p++;
                    } while (IsNumber(pCurrentLocation[p]));

                    if (pCurrentLocation[p] == '.')
                    {

                        Words[CurrentWordNum, i++] = pCurrentLocation[p];
                        p++;
                        if (!IsNumber(pCurrentLocation[p]))
                            return false;
                        while (IsNumber(pCurrentLocation[p]))
                        {
                            Words[CurrentWordNum, i++] = pCurrentLocation[p];
                            pLastLocation = pCurrentLocation.Substring(p);
                            p++;
                        }
                        WordsAttribute[CurrentWordNum] = 1;
                        CurrentWordNum++;
                        return true;
                    }
                    else
                        if (pCurrentLocation[p] == '^')
                        {

                            CurrentWordNum++;
                            Words[CurrentWordNum, 0] = pCurrentLocation[p];
                            WordsAttribute[CurrentWordNum] = 2;
                            p++;
                            CurrentWordNum++;


                            return true;
                        }
                        else
                        {

                            CurrentWordNum++;
                            return true;
                        }

                default:
                    #region ���ʷ���������
                    int mintex = p;
                    char ctemp;
                    while (true)
                    {
                        if (pCurrentLocation[mintex].CompareTo('#') == 0)
                            break;
                        if (pCurrentLocation[mintex].CompareTo('+') == 0 ||
                            pCurrentLocation[mintex].CompareTo('-') == 0 ||
                            pCurrentLocation[mintex].CompareTo('*') == 0 ||
                            pCurrentLocation[mintex].CompareTo('^') == 0 ||
                            pCurrentLocation[mintex].CompareTo('/') == 0
                            )
                        {

                            break;
                        }
                        mintex++;
                    }

                    if (pCurrentLocation[p] != '[')
                    {
                        if (pCurrentLocation[mintex - 1].CompareTo(']') == 0)
                            MessageBox.Show("�� " + pCurrentLocation.Substring(p).Replace(pCurrentLocation.Substring(mintex), "") + " ȱ��'['");
                        else
                            MessageBox.Show("δ�����ַ� " + pCurrentLocation.Substring(p).Replace(pCurrentLocation.Substring(mintex), "") + "��������Ӧ��������[]");
                    }
                    else
                    {
                        if (pCurrentLocation[mintex - 1].CompareTo(']') == 0)
                            MessageBox.Show("û���� " + pCurrentLocation.Substring(p).Replace(pCurrentLocation.Substring(mintex), ""));
                        else
                            MessageBox.Show("�� " + pCurrentLocation.Substring(p).Replace(pCurrentLocation.Substring(mintex), "") + " ȱ��']'");
                    }
                    #endregion

                    return false;

            }


        }
        protected bool IsNumber(char ch)
        {
            if (ch >= '0' && ch <= '9')
                return true;
            return false;
        }
        public bool GetResult()
        {
            return bResult;
        }
        public char GetWord(int index)
        {
            if (index >= CurrentWordNum)
                return '\0';
            else
                return Words[index, 0];
        }
        public int GetWordAttribute(int index)
        {
            if (index >= CurrentWordNum)
                return -100;
            return WordsAttribute[index];
        }
        public int GetWordNum()
        {
            return CurrentWordNum;
        }
        bool TypeIsDouble()
        {
            return WordType;
        }

    }
    #endregion
    #region �﷨�����
    class SyntaxAnalyse
    {
        bool bResult;
        int WordIndex;
        int RoundBracketsR;
        int RoundBracketsL;
        int RoundBracketsi;
        //        Stack<int> ValutStack=new Stack<int> ();
        myllstack<int> ValutStack = new myllstack<int>();
        public SyntaxAnalyse()
        {
            bResult = true;
            WordIndex = 0;
        }

        public bool Analyse(WordAnalyse pWords)
        {
            if (pWords.GetResult() == false)
                return false;
            E(pWords);
            if (WordIndex < pWords.GetWordNum() - 1)
            {
                if (pWords.GetWord(WordIndex).CompareTo(')') == 0)
                    MessageBox.Show("��" + (RoundBracketsL + 1) + "��������ȱ��������", "ȱ��������");

                bResult = true;
                WordIndex = 0;
                return false;
            }
            bool tem = bResult;
            bResult = true;
            WordIndex = 0;
            return tem;

        }

        protected void E(WordAnalyse pWords)
        {

            if (pWords.GetWord(WordIndex).CompareTo('(') == 0)
            {
                WordIndex++;
                RoundBracketsi = RoundBracketsR + 1;
                RoundBracketsR++;
                //                ValutStack.Push(RoundBracketsi);
                //if (ValutStack.Get(ref itemp))
                //MessageBox.Show(itemp+"");
                ValutStack.Push(RoundBracketsi);
                //if (ValutStack.Get(ref itemp))
                //MessageBox.Show(itemp+"","2");
                E(pWords);
                //               RoundBracketsi=ValutStack.Pop();
                ValutStack.Pop(ref RoundBracketsi);
                //if( ValutStack.Get( ref itemp))
                // MessageBox.Show(itemp+"","3");
                //else
                // MessageBox.Show(0 + "", "33");
                if (pWords.GetWord(WordIndex).CompareTo(')') == 0)
                {
                    WordIndex++;
                    RoundBracketsL++;
                    E_(pWords);
                }
                else
                {
                    MessageBox.Show("��" + RoundBracketsi + "��������ȱ��������", "������");
                    bResult = false;
                    return;
                }

            }
            else
                if (pWords.GetWordAttribute(WordIndex) != 2)
                {
                    WordIndex++;
                    E_(pWords);
                }
                else
                {
                    bResult = false;
                    return;
                }
        }


        protected void E_(WordAnalyse pWords)
        {
            //char tem[100] = "\0";
            //	strcpy(tem,Words.GetWord(WordIndex));
            //	char Operator = tem[0];
            if (pWords.GetWord(WordIndex).CompareTo('+') == 0 ||
                pWords.GetWord(WordIndex).CompareTo('-') == 0 ||
                pWords.GetWord(WordIndex).CompareTo('*') == 0 ||
                pWords.GetWord(WordIndex).CompareTo('^') == 0 ||
                pWords.GetWord(WordIndex).CompareTo('/') == 0
                )
            {
                WordIndex++;
                E(pWords);
                E_(pWords);
            }
            else
                return;

        }

    }
    class CalExpression
    {
        //     public CalExpression(string Expression);

        //	protected PriorityTable  MyTable;
        protected WordAnalyse MyWords;
        protected SyntaxAnalyse MySyntax = new SyntaxAnalyse();

        protected bool bResult;
        protected int nResult;
        protected double dResult;
        protected int ValueType;
        public CalExpression(string Expression)
        {
            MyWords = new WordAnalyse(Expression);
            bResult = false;
            nResult = 0;
            dResult = 0;
            ValueType = -1;
        }
        public int Calculate()
        {
            bResult = false;
            nResult = 0;
            dResult = 0;
            ValueType = -1;

            if (!MySyntax.Analyse(MyWords))
                return ValueType = -1;
            else
                return ValueType = 0;

            return 0;
        }
        public int GetValueType()
        {
            return ValueType;
        }

    }
    #endregion
    #region ������
    public class ExpressionCalculator
    {
        [DllImport("ExpressionCalculator.dll", EntryPoint = "sum", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern double sum(char[] tem); //DllImport�����MSDN
        public ExpressionCalculator()
        {

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\ExpressionCalculator.dll"))
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                string ResourceName = "TONLI.Client.ExpressCalculate.ExpressionCalculator.dll";

                Stream pStream=null;
                if (asm != null)
                    pStream = asm.GetManifestResourceStream(ResourceName);
                if (pStream!=null)
                {
                Byte[] buff = new byte[pStream.Length];
                pStream.Read(buff, 0, (int)pStream.Length);

                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "\\ExpressionCalculator.dll", buff);
                }
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\ExpressionCalculator.dll"))
                    MessageBox.Show("����" + AppDomain.CurrentDomain.BaseDirectory + "\\ExpressionCalculator.dllʧ��");

            }

        }
        #region ������ʽExpression ��GridView��string���� ����Column���������
        /// <summary>
        ///  ������ʽExpression ��GridView��string���� ����Expression���Column��������� 
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="gridview"></param>
        /// <param name="RowsIntex">����������</param>
        /// <returns></returns>
        public void GetExpressionColumnIntex(string Expression, GridView gridview, ref string[] RowsIntex)
        {
            int i = 0;
         
            for (i = 0; i < RowsIntex.Length; i++)
                RowsIntex[i] = "";
            i = 0;
            foreach (DevExpress.XtraGrid.Columns.GridColumn sc in gridview.Columns)
            {
                if (Expression.IndexOf("["+CharConverter(sc.Caption)+"]") > -1)
                {
                   
                    RowsIntex[i] = sc.FieldName;

                    i++;
                }
            }
           
        }
        #endregion
        /// <summary>
        /// ����GridView����������ColumnName���½�(FALSE)�����޸�(TRUE)��������TRUE��֮FALSE
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="ColumnName"></param>
        /// <param name="ISUpdate"></param>
        /// <returns></returns>
        public bool GetColumnExit(GridView gridview, string ColumnName,string filedname)
        {
            int i = 0;
            ColumnName = CharConverter(ColumnName);
            if (ColumnName.Contains("[") && ColumnName.Contains("]"))
            {
                return false;
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn sc in gridview.Columns)
            {

                if (sc.Caption == ColumnName)
                {
                    if (sc.FieldName == filedname)
                    {
                        return true;
                    }
                    else return false;

                }
            }
            return true;
        }
     
       
      

        #region ������ֵ���ʽ�ͱ���С��λ�����ر��ʽ��ֵ��SaveDecimalpoint=-1�򷵻�Ĭ��С��λ��
        /// <summary>
        ///  ������ֵ���ʽ�ͱ���С��λ�����ر��ʽ��ֵ��SaveDecimalpoint=-1�򷵻�Ĭ��С��λ��
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="SaveDecimalpoint"></param>
        /// <returns></returns>
        public double Calculator(string Expression, int SaveDecimalpoint)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpressionCalculator.dll"))
                return 0;
            string ExpressionTemp = Expression + "#";
            char[] sumtemp = new char[400];
            double retunsum = 0;
            sumtemp = ExpressionTemp.ToCharArray();
            retunsum = sum(sumtemp);
            if (SaveDecimalpoint == -1)
                return retunsum;
            if (retunsum.ToString().Contains("E+"))
            {
                //                    retunsum = retunsum.ToString("e" + SaveDecimalpoint) ;
                retunsum = double.Parse(retunsum.ToString("e" + SaveDecimalpoint), NumberStyles.Float);
            }
            else
            {
                //       retunsum = Double.Parse(retunsum.ToString(SaveDecimalpoint.ToString()), NumberStyles.Float);
                retunsum = Math.Round(retunsum, SaveDecimalpoint);
            }

            return retunsum;

        }
        #endregion
        /// <summary>
        /// ������ֵ���ʽ��GridView��DataTable���й�ʽColumn��filedname������С��λ��,����ɹ�����TRUE��֮FALSE
        /// </summary>
        /// <param name="strExpression"></param>
        /// <param name="gridView1"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool RowCalculator(string strExpression, GridView gridView1, ref DataTable a, string filedname, int SaveDecimalpoint)
        {
            string strExpressiontemp = "";
            for (int i = 0; i < a.Rows.Count; i++)
            {
                double sumstemp = 0;
                strExpressiontemp = strExpression;
                string wrongcaption = "";
                string[] ColumsIntex=new string [50];
                 GetExpressionColumnIntex(strExpressiontemp, gridView1,ref ColumsIntex);
                try
                {
                    foreach (string str in ColumsIntex)
                    {
                        if (str == "") break;
                        string strtemp = RowsValuetoString(a.Rows[i][str]);
                        if (strtemp == "")
                            strtemp = "0";

                        wrongcaption = gridView1.Columns[str].Caption;
                        strExpressiontemp = strExpressiontemp.Replace("[" + CharConverter(gridView1.Columns[str].Caption) + "]", strtemp);

                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("��" + wrongcaption  +"�г��ַ�����", "���ַ�����");
                    return false;
                }
               

                if (ISIllegal(strExpressiontemp))
                {
                    sumstemp = Calculator(strExpressiontemp, SaveDecimalpoint);
                    
                        a.Rows[i][filedname] = sumstemp;
                }
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// ������ֵ���ʽ��GridView��DataRow���й�ʽColumn��filedname������С��λ��,����ɹ�����TRUE��֮FALSE
        /// </summary>
        /// <param name="strExpression"></param>
        /// <param name="gridView1"></param>
        /// <param name="a"></param>
        /// <param name="filedname"></param>
        /// <param name="SaveDecimalpoint"></param>
        /// <returns></returns>
        public bool RowCalculator(string strExpression, GridView gridView1, ref DataRow a, string filedname, int SaveDecimalpoint)
        {
            string strExpressiontemp = "";
            string wrongcaption="";
                double sumstemp = 0;
                strExpressiontemp = strExpression;
                string[] ColumsIntex = new string[50];
                GetExpressionColumnIntex(strExpressiontemp, gridView1, ref ColumsIntex);
               try
                {
                     foreach (string str in ColumsIntex)
                    {
                        if (str == "") break;
                        string strtemp = RowsValuetoString(a[str]);
                        if (strtemp == "")
                            strtemp = "0";

                        wrongcaption = gridView1.Columns[str].Caption;
                        strExpressiontemp = strExpressiontemp.Replace("[" + CharConverter(gridView1.Columns[str].Caption) + "]", strtemp);

                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("��" + wrongcaption + "�г��ַ�����", "���ַ�����");
                    return false;
                }
                if (ISIllegal(strExpressiontemp))
                {
                    sumstemp = Calculator(strExpressiontemp, SaveDecimalpoint);
                    
                        a[filedname] = sumstemp;
                }
                else
                    return false;
            
            return true;
        }
   /// <summary>
    ///  ������ֵ���ʽ��GridView��IList<T>���й�ʽColumn��filedname������С��λ��,����ɹ�����TRUE��֮FALSE
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="strExpression"></param>
   /// <param name="gridView1"></param>
   /// <param name="a"></param>
   /// <param name="filedname"></param>
   /// <param name="SaveDecimalpoint"></param>
   /// <returns></returns>
        public bool RowCalculator<T>(string strExpression, GridView gridView1, ref IList<T> a, string filedname, int SaveDecimalpoint)
        {
            if (strExpression == "" || gridView1 == null || a == null || filedname == "")
                return false;
            string strExpressiontemp = "";
            string wrongcaption = "";
            try
            {
                for (int i = 0; i < a.Count; i++)
                {
                    double sumstemp = 0;
                    strExpressiontemp = strExpression;
                    string[] ColumsIntex = new string[50];
                    GetExpressionColumnIntex(strExpressiontemp, gridView1, ref ColumsIntex);

                    foreach (string str in ColumsIntex)
                    {
                        if (str == "") break;
                        wrongcaption = gridView1.Columns[str].Caption;
                        string strtemp = RowsValuetoString(a[i].GetType().GetProperty(gridView1.Columns[str].FieldName).GetValue(a[i], null));
                        if (strtemp == "")
                            strtemp = "0";


                        strExpressiontemp = strExpressiontemp.Replace("[" + CharConverter(gridView1.Columns[str].Caption) + "]", strtemp);

                    }

                    if (ISIllegal(strExpressiontemp))
                    {
                        sumstemp = Calculator(strExpressiontemp, SaveDecimalpoint);


                        if (a[i].GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.String"))

                            a[i].GetType().GetProperty(filedname).SetValue(a[i], sumstemp.ToString(), null);

                        else if (a[i].GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.Double"))
                            a[i].GetType().GetProperty(filedname).SetValue(a[i], sumstemp, null);

                        else if (a[i].GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.Int32"))
                            a[i].GetType().GetProperty(filedname).SetValue(a[i], Convert.ToInt16(sumstemp), null);
                        else
                            return false;



                    }
                    else
                        return false;
                }
                
            }
            catch (System.Exception e)
            {
                MessageBox.Show("��" + wrongcaption + "�г��ַ�����", "���ַ�����");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ������ֵ���ʽ��GridView��IList<T>��һ��T���й�ʽColumn��filedname������С��λ��,����ɹ�����TRUE��֮FALSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strExpression"></param>
        /// <param name="gridView1"></param>
        /// <param name="a"></param>
        /// <param name="filedname"></param>
        /// <param name="SaveDecimalpoint"></param>
        /// <returns></returns>
        public bool RowCalculator<T>(string strExpression, GridView gridView1, ref T a, string filedname, int SaveDecimalpoint)
        {
            if (strExpression == "" || gridView1 == null || a == null || filedname == "")
                return false;
            string strExpressiontemp = "";
            string wrongcaption = "";
                double sumstemp = 0;
                strExpressiontemp = strExpression;
                string[] ColumsIntex = new string[50];
                GetExpressionColumnIntex(strExpressiontemp, gridView1, ref ColumsIntex);
            try
            {
                foreach (string str in ColumsIntex)
                {
                    if (str == "") break;
                    wrongcaption = gridView1.Columns[str].Caption;
                    string strtemp = RowsValuetoString(a.GetType().GetProperty(gridView1.Columns[str].FieldName).GetValue(a, null));
                    if (strtemp == "")
                        strtemp = "0";


                    strExpressiontemp = strExpressiontemp.Replace("[" + CharConverter(gridView1.Columns[str].Caption) + "]", strtemp);

                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("��" + wrongcaption + "�г��ַ�����", "���ַ�����");
                return false;
            }
               

                if (ISIllegal(strExpressiontemp))
                {
                    sumstemp = Calculator(strExpressiontemp, SaveDecimalpoint);
                    
                    
                        if (a.GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.String"))
                        
                                a.GetType().GetProperty(filedname).SetValue(a, sumstemp.ToString(), null);

                        
                        else 
                            if (a.GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.Double"))
                                a.GetType().GetProperty(filedname).SetValue(a, sumstemp, null);
                             
                         else 
                            if (a.GetType().GetProperty(filedname).PropertyType.ToString().Contains("System.Int32"))
                                a.GetType().GetProperty(filedname).SetValue(a, Convert.ToInt16(sumstemp), null);
                            else
                                return false;
                        


                    
                }
                else
                    return false;
            
            return true;
        }
        #region �����ֵ���ʽ�Ƿ���ȷ
        /// <summary>
        /// �����ֵ���ʽ�Ƿ���ȷ
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public bool ISIllegal(string Expression)
        {
            if (Expression.ToCharArray().Length >= 400)
            {
                MessageBox.Show("���ʽ̫��");
                return false;
            }
            string ExpressionTemp = Expression + "#";
            WordAnalyse MyWords = new WordAnalyse(ExpressionTemp);
            MyWords.GetResult();
            SyntaxAnalyse MySyntax = new SyntaxAnalyse();
            if (!MySyntax.Analyse(MyWords))
            {
                MessageBox.Show("�﷨����");
                return false;
            }
            return true;
        }
        #endregion

        #region ��RowsValueתΪ�ַ���
        /// <summary>
        /// ��RowsValueתΪ�ַ���
        /// </summary>
        /// <param name="RowsValue"></param>
        /// <returns></returns>
        public string RowsValuetoString(object RowsValue)
        {
            string strtemp = "";
            if (RowsValue == null || RowsValue == DBNull.Value)
                return strtemp;
            if(RowsValue.ToString() == "")
                return strtemp;
            double result=0;
            
                result = Double.Parse(RowsValue.ToString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent | NumberStyles.Float);
            
            if (Double.IsInfinity(result))
            {
                if (result.ToString().Contains("��"))
                {
                    strtemp = "(1/0)";
                }
                else
                    strtemp = "(-1/0)";
            }
            else
            {
                if (result >= 0)
                {
                    if (result.ToString().Contains("E+"))
                    {
                        strtemp = "(" + result.ToString().Replace("E+", "*10^") + ")";
                    }
                    else
                        strtemp = result.ToString();
                }

                else
                    strtemp = "(" + result.ToString() + ")";
            }
            return strtemp;

        }
        #endregion

        #region ��ȫ���ַ�תΪ��ǣ��������ַ���
        /// <summary>
        /// /��ȫ���ַ�תΪ��ǣ��������ַ���
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string CharConverter(string source)
        {
            if (source == "")
                return source;
            source = source.Replace("��", "[");
            source = source.Replace("��", "[");
            source = source.Replace("��", "]");
            source = source.Replace("��", "]");
            source = source.Replace("��", "+");
            source = source.Replace("��", "-");
            source = source.Replace("��", "*");
            source = source.Replace("��", "*");
            source = source.Replace("��", "/");
            source = source.Replace("��", "/");
            source = source.Replace("����", "^");
            source = source.Replace("��", "^");
            System.Text.StringBuilder result = new System.Text.StringBuilder(source.Length, source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] >= 65281 && source[i] <= 65373)
                {
                    result.Append((char)(source[i] - 65248));
                }
                else if (source[i] == 12288)
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(source[i]);
                }
            }
            return result.ToString();
        }
        #endregion

        #region �ô�1��ʼ����1��������������ʽ��ROW��ֵ������ַ������ʽ�Ƿ���ȷ
        /// <summary>
        /// �ô�1��ʼ����1��������������ʽ��ROW��ֵ������ַ������ʽ�Ƿ���ȷ
        /// </summary>
        /// <param name="strExpressiontemp">���ʽ</param>
        /// <param name="gridView1"></param>
        /// <param name="ColumsIntex">���г����ڱ��ʽ���Column���������</param>
        /// <param name="ISDialog">�Ƿ񵯶Ի�����ʾ���Ա��ʽ</param>
        /// <param name="SaveDecimalpoint">����С��λ��</param>
        /// <returns></returns>

        public bool ExpressiontempISIllegal(string strExpressiontemp, GridView gridView1,  bool ISDialog, int SaveDecimalpoint)
        {
            string[] ColumsIntex = new string[50];
            string strRemark = "";
            if (strExpressiontemp == "" || gridView1 == null)
                return true;
            if (ISDialog) strRemark += "���ʽΪ��" + strExpressiontemp + "\n";
            double sumstemp = 1;
            GetExpressionColumnIntex(strExpressiontemp, gridView1, ref ColumsIntex);
            foreach (string str in ColumsIntex)
            {
                if (str == "") break;
                strExpressiontemp = strExpressiontemp.Replace("[" + CharConverter(gridView1.Columns[str].Caption) + "]", sumstemp.ToString());
                if (ISDialog) strRemark += "[" + gridView1.Columns[str].Caption + "]" + "��ֵ" + sumstemp + "��ʾ\n";
                sumstemp++;
            }

            if (ISDialog) strRemark += "�����ʽΪ��" + strExpressiontemp + "\n";
            if (ISIllegal(strExpressiontemp))
            {
                if (ISDialog)
                {

                    sumstemp = Calculator(strExpressiontemp, SaveDecimalpoint);

                    strRemark += "���Ϊ:" + sumstemp.ToString() + "\n";

                    strRemark += "�������С�����" + SaveDecimalpoint + "λ";
                    MessageBox.Show(strRemark, "���");
                }
                return true;
            }
            else
                return false;
        }
        #endregion


    }

    #endregion
}
