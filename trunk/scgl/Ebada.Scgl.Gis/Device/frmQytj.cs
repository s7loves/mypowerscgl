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
        private string strLineCode = null;
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
            InitData();
        }
        protected virtual void InitColumns()
        {

        }
        protected virtual void InitData()
        {
            IList<PS_tj> tjList = new List<PS_tj>();
            IList<PS_xl> xlList = new List<PS_xl>();

            strGtID = null;
            int maxLength = 8;
            StringBuilder sb = new StringBuilder();
            sb.Append("设备名称\t设备类型\t设备数量\r\n");
            foreach (PS_gt gt in gtList)
            {
                if (string.IsNullOrEmpty(strGtID))
                {
                    strGtID += "(" + "'" + gt.gtID + "'";
                }
                else
                {
                    strGtID += "," + "'" + gt.gtID + "'";
                }                             
                IList<PS_xl> xlListTemp = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("SelectPS_xlList"," where linecode = '" + gt.LineCode +"'");
                foreach (PS_xl xl in xlListTemp)
                {
                    xlList.Add(xl);
                    if (string.IsNullOrEmpty(strLineCode))
                    {
                        strLineCode += "(" + "'" + xl.LineCode + "'";
                    }
                    else
                    {
                        strLineCode += "," + "'" + xl.LineCode + "'";
                    }  
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
            if (string.IsNullOrEmpty(strLineCode))
            {
                strLineCode = "()";
            }
            else
            {
                strLineCode += ")";
            }
            
            IList gtSBList = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtsbRowCountByWhere", ",PS_gt where PS_gtsb.gtID = PS_gt.gtID and PS_gt.gtID in " + strGtID + " group by sbModle,sbName");
            foreach (object[] ob in gtSBList)
            {
                if (ob[1].ToString().Length > maxLength)
                {
                    maxLength = ob[1].ToString().Length;
                }
                if (ob[2].ToString().Length > maxLength)
                {
                    maxLength = ob[2].ToString().Length;
                }
                sb.Append(ob[2].ToString() + "\t" + ob[1].ToString() + "\t" + ob[0].ToString() + "\r\n");
                PS_tj tj = new PS_tj();              
                tj.SBNumber = Convert.ToInt32(ob[0]);
                tj.SbType = ob[1].ToString();
                tj.SbName = ob[2].ToString();
                tjList.Add(tj);
            }
//             IList byqCount = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqbyqRowCountByWhere", ",PS_tq where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.tqID in " + strLineCode + " group by byqModle,byqName");
//             foreach (object[] ob in byqCount)
//             {
//                 if (ob[1].ToString().Length > maxLength)
//                 {
//                     maxLength = ob[1].ToString().Length;
//                 }
//                 if (ob[2].ToString().Length > maxLength)
//                 {
//                     maxLength = ob[2].ToString().Length;
//                 }
//                 sb.Append(ob[2].ToString() + "\t" + ob[1].ToString() + "\t" + ob[0].ToString() + "\r\n");
//                 PS_tj tj = new PS_tj();
//                 tj.SBNumber = Convert.ToInt32(ob[0]);
//                 tj.SbType = ob[1].ToString();
//                 tj.SbName = ob[2].ToString();
//                 tjList.Add(tj);
//             }
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
                sb.Append(ob[2].ToString() + "\t" + ob[1].ToString() + "\t" + ob[0].ToString() + "\r\n");
                PS_tj tj = new PS_tj();
                tj.SBNumber = Convert.ToInt32(ob[0]);
                tj.SbType = ob[1].ToString();
                tj.SbName = ob[2].ToString();
                tjList.Add(tj);
            }
            IList tqCount = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqRowCount", " where xlCode in " + strLineCode);
            if (tqCount.Count > 0)
            {
                sb.Append("台区" + "\t" + "台区数量" + "\t" + tqCount[0].ToString());
                PS_tj tj = new PS_tj();
                tj.SBNumber = Convert.ToInt32(tqCount[0].ToString());
                tj.SbType = "台区数量";
                tj.SbName = "台区";
                tjList.Add(tj);
            }

            IList byqCount = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_tqbyqRowCount",",PS_tq where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.tqID in " + strLineCode);
            if (byqCount.Count > 0)
            {
                sb.Append("变压器" + "\t" + "变压器数量" + "\t" + byqCount[0].ToString());
                PS_tj tj = new PS_tj();
                tj.SBNumber = Convert.ToInt32(byqCount[0].ToString());
                tj.SbType = "变压器数量";
                tj.SbName = "变压器";
                tjList.Add(tj);
            }
            IList gtCountSum = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_gtRowCount", " where gtID in " + strGtID);
            if (gtCountSum.Count > 0)
            {
                sb.Append("杆塔" + "\t" + "杆塔数量" + "\t" + gtCountSum[0].ToString());
                PS_tj tj = new PS_tj();
                tj.SBNumber = Convert.ToInt32(gtCountSum[0].ToString());
                tj.SbType = "杆塔数量";
                tj.SbName = "杆塔";
                tjList.Add(tj);
            }
            IList xlLength = Client.ClientHelper.PlatformSqlMap.GetList("GetPS_xlLengthByWhere", " where gtID in " + strGtID);
            if (xlLength.Count > 0)
            {
                sb.Append("线路" + "\t" + "线路长度" + "\t" + xlLength[0].ToString() + "米");
                PS_tj tj = new PS_tj();
                tj.SBNumber = (int)Convert.ToDouble(xlLength[0].ToString());
                tj.SbType = "线路长度";
                tj.SbName = "线路";
                tjList.Add(tj);
            }
            
            gridControl1.DataSource = tjList;
            //             foreach (GridColumn c in gridView1.Columns)
            //             {
            //                 c.Visible = false;
            // 
            //             }
            try
            {
                gridView1.Columns["SmOrg"].Visible = false;
                //gridView1.Columns["SbType"].Visible = true;
                //gridView1.Columns["SBNumber"].Visible = true;
                gridView1.Columns["SbOwner"].Visible = false;
                gridView1.Columns["SbOwner"].Caption = "线路";
                gridView1.Columns["SbName"].VisibleIndex = 0;
                gridView1.Columns["SbType"].VisibleIndex = 1;
                gridView1.Columns["SBNumber"].VisibleIndex = 2;
            }
            catch { }
            //             foreach (object[] ob in tqSBList)
            //             {
            //                 PS_tj tj = new PS_tj();
            //                 string strOwner = repositoryItemCheckedComboBoxEdit3.GetDisplayText(str).Trim();
            //                 tj.SmOrg = btGdsList.Edit.GetDisplayText(btGdsList.EditValue);
            //                 tj.SbOwner = strOwner;
            //                 tj.SBNumber = Convert.ToInt32(ob[0]);
            //                 tj.SbType = ob[1].ToString();
            //                 tj.SbName = ob[2].ToString();
            //                 tjList.Add(tj);
            //             }
        }
    }
}