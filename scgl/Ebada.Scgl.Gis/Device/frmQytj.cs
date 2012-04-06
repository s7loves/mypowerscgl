using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.Scgl.Gis.Device {
    /// <summary>
    /// 区域统计;统计内容：线路长度、杆塔数量、杆塔设备、杆塔材料、交叉跨越
    /// </summary>
    public partial class frmQytj : DevExpress.XtraEditors.XtraForm {
        List<PS_gt> gtList;
        private string strGtID = null;
        public frmQytj(List<PS_gt> gtlist) {
            InitializeComponent();
            simpleButton1.Click += new EventHandler(simpleButton1_Click);
            gtList = gtlist;
        }

        void simpleButton1_Click(object sender, EventArgs e) {
            this.Close();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            strGtID = null;
            int maxLength = 8;
            StringBuilder sb = new StringBuilder();
            sb.Append("设备名称\t设备类型\t设备数量\r\n");
            foreach (PS_gt gt in gtList) {
                if (string.IsNullOrEmpty(strGtID))
                {
                    strGtID += "(" + "'" + gt.gtID + "'";
                }
                else
                {
                    strGtID += "," + "'" + gt.gtID + "'";
                }
                //sb.AppendLine(gt.gtCode);
            }
            if (string.IsNullOrEmpty(strGtID))
            {
                strGtID = "()";
            }
            else
            {
                strGtID += ")";
            }
            IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt where PS_gtsb.gtID = PS_gt.gtID and PS_gt.gtID in " + strGtID + " group by sbModle,sbName");
            foreach (object[] ob in gtSBList)
            {
                if (ob[1].ToString().Length>maxLength)
                {
                    maxLength = ob[1].ToString().Length;
                }
                if (ob[2].ToString().Length > maxLength)
                {
                    maxLength = ob[2].ToString().Length;
                }
                sb.Append(ob[2].ToString() + "\t" + ob[1].ToString() + "\t" + ob[0].ToString()+"\r\n");
            }
            IList gtCount = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtRowCountByWhere", " where gtID in " + strGtID + " group by  gtType, gtModle");
            foreach (object[] ob in gtCount)
            {
                if (ob[1].ToString().Length > maxLength)
                {
                    maxLength = ob[1].ToString().Length;
                }
                if (ob[2].ToString().Length > maxLength)
                {
                    maxLength = ob[2].ToString().Length;
                }
                sb.Append(ob[2].ToString() + "\t" + ob[1].ToString() + "\t" + ob[0].ToString()+"\r\n");
            }
            IList xlLength = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_xlLengthByWhere", " where gtID in " + strGtID);
            if (xlLength.Count>0)
            {
                sb.Append("线路" + "\t" + "线路长度" +"\t"+ xlLength[0].ToString()+"米");
            }
            memoEdit1.Properties.AcceptsTab = true;        
            memoEdit1.Text = sb.ToString();
        }
    }
}