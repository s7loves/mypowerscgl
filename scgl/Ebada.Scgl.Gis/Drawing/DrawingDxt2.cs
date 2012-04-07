using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis.Drawing {
    /// <summary>
    /// 规则单线图绘制类
    /// </summary>
    public class DrawingDxt2 {
        public Image GetImage(string linecode) {
            xl xl = new xl();
            Bitmap img = new Bitmap(1300, 600);
            xl.xlValue=Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='"+ linecode + "'");
            if (xl.xlValue == null) return null;

            buildChild(xl);
            draw(Graphics.FromImage(img), xl);
            return null;
        }
        void buildChild(xl line) {
            IList<PS_gt> gtlist= Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + line.xlValue.LineCode + "'");
            line.addGt(gtlist);
           IList<PS_xl> xlList= Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" a, ps_gt b where a.parentgt=b.gtcode and b.linecode='" + line.xlValue.LineCode + "'");
           line.addXl(xlList);
           foreach (xl xl in line.lines) {
               buildChild(xl);
           }
        }
        void draw(Graphics g, xl xl) {
            g.Clear(Color.White);


        }
        void drawgt(Graphics g, xl xl) {
            foreach (gtNode node in xl.nodes) {

            }
        }
        class gtNode {
            public List<xl> lines;
            public PS_gt gtValue;
            public xl ownerLine;

            public List<PS_kg> kgList;
            public List<PS_tqbyq> byqList;


            public gtNode() {
                lines = new List<xl>();
                kgList = new List<PS_kg>();
                byqList = new List<PS_tqbyq>();
            }

            internal void addLine(xl xl) {
                lines.Add(xl);
            }
        }
        class xl {
            public List<gtNode> nodes;
            public List<xl> lines;
            public PS_xl xlValue;
            public gtNode parentNode;
            public xl() {
                nodes = new List<gtNode>();
                lines = new List<xl>();

        }
            public void addGt(ICollection<PS_gt> list) {
                foreach (PS_gt gt in list) {
                    nodes.Add(new gtNode() { gtValue = gt, ownerLine= this });
                }
            }

            internal void addXl(IList<PS_xl> xlList) {
                foreach (PS_xl line in xlList) {
                    xl xl = new xl() { xlValue = line };
                    lines.Add(xl);
                    gtNode node = getNodeByCode(line.ParentGT);
                    
                    if (node != null) {
                        xl.parentNode = node;
                        node.addLine(xl);
                    }
                }
            }

            private gtNode getNodeByCode(string p) {
                foreach (gtNode node in nodes) {
                    if (node.gtValue.gtCode == p) return node;
                }

                return null;
            }
        }
    }
}
