using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Ebada.AutoUpdater.Config
{
    public partial class AutoupdateConfig : Form
    {
        DataTable dt = null;
        public AutoupdateConfig()
        {
            InitializeComponent();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoupdateConfig());
        }

        private void AutoupdateConfig_Load(object sender, EventArgs e)
        {
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("HaveSelected", typeof(bool));
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("FullFileName", typeof(string));
                dt.Columns.Add("Version", typeof(string));
                dt.Columns.Add("Size", typeof(string ));
                dt.Columns.Add("NeedRestart", typeof(bool));
                
            
            }
            gridControl1.DataSource = dt; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetAssemblyVersion(string name)
        {
            byte[] filedata = File.ReadAllBytes(name );
            return Assembly.Load(filedata).GetName().Version.ToString();

        }
        private void AddFileToTable(FileInfo f)
        {
            if (f.Name == "AutoupdateService.xml")
            {
                return ;
            }
            DataRow dr = dt.NewRow();
            dr["HaveSelected"] = true;
            dr["FileName"] = f.Name;
            dr["FullFileName"] = f.FullName;
            dr["Version"] = GetAssemblyVersion(f.FullName);
            dr["Size"] = f.Length;
            dr["NeedRestart"] = false;
            dt.Rows.Add(dr);
        }
        private void FindFileAddTOTable(string dir, string filter)                           
            {     
                        //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件
                 DirectoryInfo   Dir=new   DirectoryInfo(dir);
                 try
                    {
                                foreach(DirectoryInfo d in Dir.GetDirectories())//查找子目录
                                {
                                    FindFileAddTOTable(Dir + d.ToString() + "\\", filter);
                                }
                                foreach (FileInfo f in Dir.GetFiles(filter)) //查找文件
                                {
                                    //if (f.Name == "AutoupdateService.xml")
                                    //{
                                    //    continue ;
                                    //}
                                    AddFileToTable(f);
                                    //if (f.Name.Split('.').Length < 2)
                                    //{
                                    //    f.Name.Replace(f.Name, f.Name + ".rar");
                                    //}
                                    //else
                                    //{
                                    //    if (f.Name.Split('.')[f.Name.Split('.').Length - 1] != ".rar")
                                    //    {
                                    //        f.Name.Replace(f.Name, f.Name + ".rar");
                                    //    }
                                    //}
                                }
                        }

                        catch(Exception e)

                        {
                            Console.WriteLine(e.Message); 

                        }
                    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string filepath = System.Environment.CurrentDirectory+"\\ScglUpdateService";
            
            if(checkBox1.Checked   )
            {
                FindFileAddTOTable(filepath,"*.*");
            }
        }

        private void BuildXML_Click(object sender, EventArgs e)
        {
            string filepath = System.Environment.CurrentDirectory + "\\ScglUpdateService\\AutoupdateService.xml";
            string urlHead = "http://localhost/ScglUpdateService/";
            // 创建一个XmlTextReader类的对象并调用Read方法来读取文件 
            XmlTextWriter textWriter = new XmlTextWriter(filepath, System.Text.Encoding.UTF8);
            textWriter.Formatting = Formatting.Indented;
            
            // 开始写过程，调用WriteStartDocument方法 
            textWriter.WriteStartDocument();
            // 写入注释
            textWriter.WriteComment("自动更新XML文件");
            textWriter.WriteStartElement("updateFiles");
              //dr["HaveSelected"] = true;
              //                      dr["FileName"]=f.Name ;
              //                      dr["Version"] =GetAssemblyVersion(f.FullName );
              //                      dr["Size"]=f.Length ;
              //                      dr["NeedRestart"]=false;
            foreach (DataRow dr in dt.Rows)
            {
                string filename = dr["FileName"].ToString();
                if (dr["HaveSelected"].ToString().ToLower () == "true")
                {
                    textWriter.WriteStartElement("file");

                    textWriter.WriteStartAttribute("path");
                    textWriter.WriteValue(dr["FileName"].ToString());
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("url");
                    filename=filename.Substring (0, filename.LastIndexOf('.')) + ".rar";
                    textWriter.WriteValue(urlHead + filename);
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("lastver");
                    textWriter.WriteValue(dr["Version"].ToString());
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("size");
                    textWriter.WriteValue(dr["Size"].ToString());
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("needRestart");
                    textWriter.WriteValue(dr["NeedRestart"].ToString());
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }



            textWriter.WriteEndElement();
            // 写文档结束，调用WriteEndDocument方法 
            textWriter.WriteEndDocument();

            // 关闭textWriter 
            textWriter.Close();
        }

        private void Addbut_Click(object sender, EventArgs e)
        {

            fileDialog1.InitialDirectory = System.Environment.CurrentDirectory + "\\ScglUpdateService\\";
            fileDialog1.Filter = "EXE files (*.exe)|*.exe|All files (*.*)|*.*";
            fileDialog1.FilterIndex = 2;
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Multiselect = true; 
            if (fileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in fileDialog1.FileNames)
                {
                    FileInfo f = new FileInfo(filename);
                    AddFileToTable(f);
                }
            }
        }
    
    }
}
