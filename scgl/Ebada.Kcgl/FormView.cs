﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ebada.Kcgl
{
    class FormView
    {
        public static void PaintAll(object sender)
        {
            Form form = ((Form)sender);
            List<Point> list = new List<Point>();
            int width = form.Width;
            int height = form.Height;

            //左上
            list.Add(new Point(0, 5));
            list.Add(new Point(1, 5));
            list.Add(new Point(1, 3));
            list.Add(new Point(2, 3));
            list.Add(new Point(2, 2));
            list.Add(new Point(3, 2));
            list.Add(new Point(3, 1));
            list.Add(new Point(5, 1));
            list.Add(new Point(5, 0));
            //右上
            list.Add(new Point(width - 5, 0));
            list.Add(new Point(width - 5, 1));
            list.Add(new Point(width - 3, 1));
            list.Add(new Point(width - 3, 2));
            list.Add(new Point(width - 2, 2));
            list.Add(new Point(width - 2, 3));
            list.Add(new Point(width - 1, 3));
            list.Add(new Point(width - 1, 5));
            list.Add(new Point(width - 0, 5));
            //右下
            list.Add(new Point(width - 0, height - 5));
            list.Add(new Point(width - 1, height - 5));
            list.Add(new Point(width - 1, height - 3));
            list.Add(new Point(width - 2, height - 3));
            list.Add(new Point(width - 2, height - 2));
            list.Add(new Point(width - 3, height - 2));
            list.Add(new Point(width - 3, height - 1));
            list.Add(new Point(width - 5, height - 1));
            list.Add(new Point(width - 5, height - 0));
            //左下
            list.Add(new Point(5, height - 0));
            list.Add(new Point(5, height - 1));
            list.Add(new Point(3, height - 1));
            list.Add(new Point(3, height - 2));
            list.Add(new Point(2, height - 2));
            list.Add(new Point(2, height - 3));
            list.Add(new Point(1, height - 3));
            list.Add(new Point(1, height - 5));
            list.Add(new Point(0, height - 5));

            Point[] points = list.ToArray();

            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);

            //将窗体的显示区域设为GraphicsPath的实例 
            form.Region = new System.Drawing.Region(shape);
        }

        public static void PaintPicAll(object sender)
        {
            DevExpress.XtraEditors.PictureEdit form = ((DevExpress.XtraEditors.PictureEdit)sender);
            List<Point> list = new List<Point>();
            int width = form.Width;
            int height = form.Height;

            //左上
            list.Add(new Point(0, 5));
            list.Add(new Point(1, 5));
            list.Add(new Point(1, 3));
            list.Add(new Point(2, 3));
            list.Add(new Point(2, 2));
            list.Add(new Point(3, 2));
            list.Add(new Point(3, 1));
            list.Add(new Point(5, 1));
            list.Add(new Point(5, 0));
            //右上
            list.Add(new Point(width - 5, 0));
            list.Add(new Point(width - 5, 1));
            list.Add(new Point(width - 3, 1));
            list.Add(new Point(width - 3, 2));
            list.Add(new Point(width - 2, 2));
            list.Add(new Point(width - 2, 3));
            list.Add(new Point(width - 1, 3));
            list.Add(new Point(width - 1, 5));
            list.Add(new Point(width - 0, 5));
            //右下
            list.Add(new Point(width - 0, height - 5));
            list.Add(new Point(width - 1, height - 5));
            list.Add(new Point(width - 1, height - 3));
            list.Add(new Point(width - 2, height - 3));
            list.Add(new Point(width - 2, height - 2));
            list.Add(new Point(width - 3, height - 2));
            list.Add(new Point(width - 3, height - 1));
            list.Add(new Point(width - 5, height - 1));
            list.Add(new Point(width - 5, height - 0));
            //左下
            list.Add(new Point(5, height - 0));
            list.Add(new Point(5, height - 1));
            list.Add(new Point(3, height - 1));
            list.Add(new Point(3, height - 2));
            list.Add(new Point(2, height - 2));
            list.Add(new Point(2, height - 3));
            list.Add(new Point(1, height - 3));
            list.Add(new Point(1, height - 5));
            list.Add(new Point(0, height - 5));

            Point[] points = list.ToArray();

            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);

            //将窗体的显示区域设为GraphicsPath的实例 
            form.Region = new System.Drawing.Region(shape);
        }

        public static void PaintUP(object sender)
        {
            DevExpress.XtraEditors.PictureEdit pic = ((DevExpress.XtraEditors.PictureEdit)sender);
            List<Point> list = new List<Point>();
            int width = pic.Width;
            int height = pic.Height;

            //左上
            list.Add(new Point(0, 5));
            list.Add(new Point(1, 5));
            list.Add(new Point(1, 3));
            list.Add(new Point(2, 3));
            list.Add(new Point(2, 2));
            list.Add(new Point(3, 2));
            list.Add(new Point(3, 1));
            list.Add(new Point(5, 1));
            list.Add(new Point(5, 0));
            //右上
            list.Add(new Point(width - 5, 0));
            list.Add(new Point(width - 5, 1));
            list.Add(new Point(width - 3, 1));
            list.Add(new Point(width - 3, 2));
            list.Add(new Point(width - 2, 2));
            list.Add(new Point(width - 2, 3));
            list.Add(new Point(width - 1, 3));
            list.Add(new Point(width - 1, 5));
            list.Add(new Point(width - 0, 5));
            ////右下

            //右下
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            list.Add(new Point(width - 0, height - 0));
            //左下
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));
            list.Add(new Point(0, height - 0));


            Point[] points = list.ToArray();

            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);

            //将窗体的显示区域设为GraphicsPath的实例 
            pic.Region = new System.Drawing.Region(shape);
        }
        public static void PaintDOWN(object sender)
        {
            PictureBox pic = ((PictureBox)sender);
            List<Point> list = new List<Point>();
            int width = pic.Width;
            int height = pic.Height;

            //左上
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            //右上
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            list.Add(new Point(width - 0, 0));
            //右下
            list.Add(new Point(width - 0, height - 5));
            list.Add(new Point(width - 1, height - 5));
            list.Add(new Point(width - 1, height - 3));
            list.Add(new Point(width - 2, height - 3));
            list.Add(new Point(width - 2, height - 2));
            list.Add(new Point(width - 3, height - 2));
            list.Add(new Point(width - 3, height - 1));
            list.Add(new Point(width - 5, height - 1));
            list.Add(new Point(width - 5, height - 0));
            //左下
            list.Add(new Point(5, height - 0));
            list.Add(new Point(5, height - 1));
            list.Add(new Point(3, height - 1));
            list.Add(new Point(3, height - 2));
            list.Add(new Point(2, height - 2));
            list.Add(new Point(2, height - 3));
            list.Add(new Point(1, height - 3));
            list.Add(new Point(1, height - 5));
            list.Add(new Point(0, height - 5));

            Point[] points = list.ToArray();

            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);

            //将窗体的显示区域设为GraphicsPath的实例 
            pic.Region = new System.Drawing.Region(shape);
        }
    }
}
