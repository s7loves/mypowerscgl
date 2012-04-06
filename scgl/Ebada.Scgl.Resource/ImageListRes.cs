using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;
using System.Drawing.Imaging;
namespace Ebada.Scgl.Resource
{
  public  class ImageListRes
    {
        public static ImageList GetimageList(int size, DataTable imageNames)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new System.Drawing.Size(size, size);
            imageList.ColorDepth = ColorDepth.Depth32Bit;


            foreach (DataRow row in imageNames.Rows)
            {
                try
                {
                    object obj = Ebada.Scgl.Resource.Properties.Resources.ResourceManager.GetObject(row["ProgIco"] as string);
                    if (obj is Icon)
                    {
                        imageList.Images.Add(row["ProgIco"] as string, (Icon)obj);
                    }
                    else if (obj is Bitmap)
                    {
                        imageList.Images.Add(row["ProgIco"] as string, (Bitmap)obj);
                    }
                    else
                    {

                    }

                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.GetType().ToString() + " - " + exc.Message);
                }
            }

            return imageList;
        }

        public static ImageList GetimageList(int width, int height, DataTable imageNames)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new System.Drawing.Size(width, height);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            //imageList.Images.Add("selected", (Bitmap)Itop.Client.Resources.Properties.Resources.ResourceManager.GetObject("selected"));
            foreach (DataRow row in imageNames.Rows)
            {
                try
                {
                    object obj = Ebada.Scgl.Resource.Properties.Resources.ResourceManager.GetObject(row["ProgIco"] as string);
                    if (obj is Icon)
                    {
                        imageList.Images.Add(row["ProgIco"] as string, (Icon)obj);
                    }
                    else if (obj is Bitmap)
                    {
                        imageList.Images.Add(row["ProgIco"] as string, (Bitmap)obj);
                    }
                    else
                    {

                    }

                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.GetType().ToString() + " - " + exc.Message);
                }
            }

            return imageList;
        }



        static ImageList imagelistall = new ImageList();
        public static Stream GetFileStream(string filename)
        {
            Assembly assembly1 = Assembly.GetAssembly(typeof(Ebada.Scgl.Resource.ImageListRes));
            if (assembly1 != null)
            {

                return assembly1.GetManifestResourceStream(filename);
            }
            return null;
        }

        public static void GetImageFile(Image metaFile, string filename, int wid, int hei)
        {
            Bitmap bmp = new Bitmap(wid, hei);
            Graphics g = Graphics.FromImage(metaFile);
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
            bmp.Save(filename, ImageFormat.Png);
            g.Dispose();
            metaFile.Dispose();
            bmp.Dispose();
        }


        public static ImageList GetimageListAll(int size)
        {

            ImageList imageList = imagelistall;
            if (imagelistall.Images.Count == 0)
            {
                imageList.ImageSize = new System.Drawing.Size(size, size);
                imageList.ColorDepth = ColorDepth.Depth32Bit;
                Stream stream = GetFileStream("Ebada.Scgl.Resource.Properties.Resources.resources");

                ResourceReader read = new ResourceReader(stream);
                IDictionaryEnumerator ie = read.GetEnumerator();
                while (ie.MoveNext())
                {
                    object obj = ie.Value;
                    try
                    {
                        if (obj is Icon)
                        {
                            imageList.Images.Add(ie.Key as string, (Icon)obj);
                        }
                        else
                        {
                            Bitmap tempbit = (Bitmap)obj;
                            tempbit.Tag = ie.Key as string;
                            imageList.Images.Add(ie.Key as string, tempbit);
                        }
                    }
                    catch { }
                }
            }
            return imageList;
        }
        private static bool Is_In(string[] str, string strvalue)
        {
            bool have = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (strvalue == str[i].ToString())
                {
                    have = true;
                    break;
                }
            }
            return have;
        }
        public static ImageList GetimageListAll(int size, string str)
        {
            //系统用图片不显示在图标列表中
            string[] sysico = { "a0"};
            //ImageList imageList = imagelistall;
            ImageList imageList = new ImageList();

            //if (imagelistall.Images.Count == 0||str!="")
            //{
            imageList.Images.Clear();
            imageList.ImageSize = new System.Drawing.Size(size, size);
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            Stream stream = GetFileStream("Ebada.Scgl.Resource.Properties.Resources.resources");

            ResourceReader read = new ResourceReader(stream);
            IDictionaryEnumerator ie = read.GetEnumerator();
            while (ie.MoveNext())
            {
                object obj = ie.Value;
                try
                {
                    if (obj is Icon)
                    {
                        //imageList.Images.Add(ie.Key as string, (Icon)obj);
                    }
                    else
                    {
                        if (!Is_In(sysico, ie.Key.ToString()))
                        {
                            if (ie.Key.ToString().Contains(str) || str == "")
                            {
                                Bitmap tempbit = (Bitmap)obj;
                                imageList.Images.Add(ie.Key as string, tempbit);
                            }

                        }

                    }
                }
                catch { }
            }
            //}
            return imageList;
        }
       


      
        public static Bitmap GetTop()
        {
            return Ebada.Scgl.Resource.Properties.Resources.生产管理系统top;
        }
       
    }
}
