using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// </summary>
    public class Export01  {
        //ExcelAccess
        public static void ExportExcel(PJ_01gzrj jl, IList<PJ_gzrjnr> nrList) {

           ExcelAccess ex = new ExcelAccess();
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                string fname = "";
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = saveFileDialog1.FileName;
                    ex.MyFileName = fname;
                    ex.CreateExcel();
                    ex.CreateWorkSheet("工作日志");
                    ex.Save();
                }

                //ex.Open(fname);
                //ex.ActiveSheet("工作日志");

                int row = 1;
                int col = 1;
                float cellWidth = 4;
                string fixstr1 = "附录01";
                string title = "工  作  日  记";
                string strqqqk = "缺\r\n勤\r\n情\r\n况";
                string strxm = "姓名";
                string stryy = "原因";
                string straqjl = "安\r\n全\r\n记\r\n录";
                string strrs = "人身";
                string strsb = "设备";
                string strxh = "序号";
                string strgzdz = "工作地址及项目";
                string strfzr = "工作负责人";
                string strcjry = "参加人员";
                string strjs = "记事：";
                string strpy = "领导检查评语：";
                string strqz = "检查人签字：";
                string end = "黑龙江省农村电气化局-配管-01";


                //写附录01
                ex.SetCellValue(fixstr1, row, col);
                ex.UnitCells(row, col, row, col + 14);
                ex.AlignmentCells(row, col, row, col, ExcelStyle.ExcelHAlign.靠左, ExcelStyle.ExcelVAlign.居中);
                ex.SetFontNameSize(row, col, row, col, "宋体", 16);
                ex.SetFontStyle(row, col, row, col, true, false, ExcelStyle.UnderlineStyle.无下划线);
                //写工  作  日  记
                ex.SetCellValue(title, row + 1, col);
                ex.UnitCells(row + 1, col, row + 1, col + 14);
                ex.AlignmentCells(row + 1, col, row + 1, col, ExcelStyle.ExcelHAlign.居中, ExcelStyle.ExcelVAlign.居中);
                ex.SetFontNameSize(row + 1, col, row + 1, col, "宋体", 24);
                ex.SetFontStyle(row + 1, col, row + 1, col, true,false,ExcelStyle.UnderlineStyle.无下划线);
                //缺勤情况
                ex.SetCellValue(strqqqk, row + 3, col);
                ex.UnitCells(row + 3, col, row + 6, col);
                //姓名、原因
                ex.SetCellValue(strxm, row + 3, col + 1);
                ex.SetCellValue(stryy, row + 4, col + 1);
                ex.SetCellValue(strxm, row + 5, col + 1);
                ex.SetCellValue(stryy, row + 6, col + 1);
                string[] rr = new string[10];
                string[] yy = new string[10];
                string[] rr2 = jl.qqry.Split(";".ToCharArray());
                for (int i = 0; i < rr2.Length-1; i++)
                {
                    rr[i] = rr2[i].Split(":".ToCharArray())[0];
                    yy[i] = rr2[i].Split(":".ToCharArray())[1];
                }
                for (int i = rr2.Length - 1; i < rr.Length; i++)
                {
                    rr[i] = "";
                    yy[i] = "";
                }
                for (int i = 2; i < 12;i++ )
                {
                    ex.SetColumnWidth(row + 3, col + i, cellWidth);
                }
                ex.SetCellValue(rr[0], row + 3, col + 2);
                ex.SetCellValue(rr[1], row + 3, col + 4);
                ex.SetCellValue(rr[2], row + 3, col + 6);
                ex.SetCellValue(rr[3], row + 3, col + 8);
                ex.SetCellValue(rr[4], row + 3, col + 10);
                ex.SetCellValue(rr[5], row + 5, col + 2);
                ex.SetCellValue(rr[6], row + 5, col + 4);
                ex.SetCellValue(rr[7], row + 5, col + 6);
                ex.SetCellValue(rr[8], row + 5, col + 8);
                ex.SetCellValue(rr[9], row + 5, col + 10);
                ex.SetCellValue(yy[0], row + 4, col + 2);
                ex.SetCellValue(yy[1], row + 4, col + 4);
                ex.SetCellValue(yy[2], row + 4, col + 6);
                ex.SetCellValue(yy[3], row + 4, col + 8);
                ex.SetCellValue(yy[4], row + 4, col + 10);
                ex.SetCellValue(yy[5], row + 6, col + 2);
                ex.SetCellValue(yy[6], row + 6, col + 4);
                ex.SetCellValue(yy[7], row + 6, col + 6);
                ex.SetCellValue(yy[8], row + 6, col + 8);
                ex.SetCellValue(yy[9], row + 6, col + 10);
                for(int i=0;i<4;i++){
                    ex.UnitCells(row + 3 + i, col + 2, row + 3 + i, col + 3);
                    ex.UnitCells(row + 3 + i, col + 4, row + 3 + i, col + 5);
                    ex.UnitCells(row + 3 + i, col + 6, row + 3 + i, col + 7);
                    ex.UnitCells(row + 3 + i, col + 8, row + 3 + i, col + 9);
                    ex.UnitCells(row + 3 + i, col + 10, row + 3 + i, col + 11);
                }    
                //安全记录
                ex.SetCellValue(straqjl, row + 3, col + 12);
                ex.UnitCells(row + 3, col+12, row + 6, col+12);
                //人身,设备
                ex.SetCellValue(strrs, row + 3, col + 13);
                ex.UnitCells(row + 3, col + 13, row + 3, col + 14);
                ex.SetCellValue(jl.rsaqts.ToString(), row + 4, col + 13);
                ex.SetCellValue("天", row + 4, col + 14);
                ex.SetCellValue(strsb, row + 5, col + 13);
                ex.UnitCells(row + 5, col + 13, row + 5, col + 14);
                ex.SetCellValue(jl.sbaqts.ToString(), row + 6, col + 13);
                ex.SetCellValue("天", row + 6, col + 14);
                //工作内容
                ex.SetCellValue(strxh, row + 7, col);
                ex.SetCellValue(strgzdz, row + 7, col + 1);
                ex.UnitCells(row + 7, col + 1, row + 7, col + 7);
                ex.SetCellValue(strfzr, row + 7, col + 8);
                ex.UnitCells(row + 7, col + 8, row + 7, col + 10);
                ex.SetCellValue(strcjry, row + 7, col + 11);
                ex.UnitCells(row + 7, col + 11, row + 7, col + 14);

                ex.AlignmentCells(row+3, col, row+7, col+14, ExcelStyle.ExcelHAlign.居中, ExcelStyle.ExcelVAlign.居中);
                IList<PJ_gzrjnr> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_gzrjnr>(" where gzrjID='" + jl.gzrjID + "' order by seq");
                for (int i = 0; i < list.Count;i++ )
                {
                    PJ_gzrjnr obj = list[i];
                    ex.SetCellValue(obj.seq.ToString(), row + 8+i, col);
                    ex.SetCellValue(obj.gznr, row + 8+i, col+1);
                    ex.UnitCells(row + 8 + i, col + 1, row + 8 + i, col + 7);
                    ex.SetCellValue(obj.fzr, row + 8+i, col+8);
                    ex.UnitCells(row + 8 + i, col + 8, row + 8 + i, col + 10);
                    ex.SetCellValue(obj.cjry, row + 8+i, col+11);
                    ex.UnitCells(row + 8 + i, col + 11, row + 8 + i, col + 14);
                }
                //记事
                ex.SetCellValue(strjs+jl.js, row + 8 + list.Count, col);
                ex.UnitCells(row + 8 + list.Count, col, row + 8 + list.Count, col + 14);
                ex.RowAutoFit(row + 8 + list.Count);
                //领导评语
                ex.SetCellValue(strpy + jl.py, row + 9 + list.Count, col);
                ex.UnitCells(row + 9 + list.Count, col, row + 9 + list.Count, col + 14);
                ex.RowAutoFit(row + 9 + list.Count);
                //签字、时间
                ex.SetCellValue(strqz, row + 10 + list.Count, col);
                ex.UnitCells(row + 10 + list.Count, col, row + 10 + list.Count, col + 1);
                ex.SetCellValue(jl.qz, row + 10 + list.Count, col+2);
                ex.UnitCells(row + 10 + list.Count, col+2, row + 10 + list.Count, col + 4);
                ex.SetCellValue(jl.qzrq.Year + "年" + jl.qzrq.Month + "月" + jl.qzrq.Day+"日", row + 10 + list.Count, col + 8);
                ex.UnitCells(row + 10 + list.Count, col + 8, row + 10 + list.Count, col + 12);
                //
                ex.SetCellValue(end, row + 11 + list.Count, col);
                ex.UnitCells(row + 11 + list.Count, col, row + 11 + list.Count, col + 14);
                ex.AlignmentCells(row + 11 + list.Count, col, row + 11 + list.Count, col + 14, ExcelStyle.ExcelHAlign.靠右, ExcelStyle.ExcelVAlign.居中);
                ex.SetFontNameSize(row + 11 + list.Count, col, row + 11 + list.Count, col + 14, "宋体", 14);
                ex.SetFontStyle(row + 11 + list.Count, col, row + 11 + list.Count, col + 14, true, false, ExcelStyle.UnderlineStyle.无下划线);
                if (ex.Save())
                {
                    if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") == DialogResult.Yes)
                    {
                        ex.Open(fname);
                    }
                }
                else
                {
                    MsgBox.ShowWarningMessageBox("导出失败！");
                }
                
        }
            
    }
}
