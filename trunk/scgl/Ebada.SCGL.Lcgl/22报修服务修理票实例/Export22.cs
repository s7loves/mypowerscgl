using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export22  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_22 obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\22报修服务修理票实例.xls";

            ex.Open(fname);
            //此处写填充内容代码
            //供电所
            ex.SetCellValue(obj.OrgName, 3, 1);
            ex.SetCellValue(obj.OrgName,13,1);
            //创建时间
            ex.SetCellValue(obj.bxsj.Year.ToString(), 3, 9);
            ex.SetCellValue(obj.bxsj.Month.ToString(), 3, 12);
            ex.SetCellValue(obj.bxsj.Day.ToString(), 3, 14);
            ex.SetCellValue(obj.bxsj.Year.ToString(), 13, 9);
            ex.SetCellValue(obj.bxsj.Month.ToString(), 13, 12);
            ex.SetCellValue(obj.bxsj.Day.ToString(), 13, 14);
            //编号
            ex.SetCellValue(obj.ph.Substring(0, 2), 3, 20);
            ex.SetCellValue(obj.ph.Substring(2, 4), 3, 21);
            ex.SetCellValue(obj.ph.Substring(6, 3), 3, 24);
            ex.SetCellValue(obj.ph.Substring(0, 2), 13, 20);
            ex.SetCellValue(obj.ph.Substring(2, 4), 13, 21);
            ex.SetCellValue(obj.ph.Substring(6, 3), 13, 24);
            //保修时间，保修地点
            ex.SetCellValue(obj.bxsj.Hour.ToString(), 5, 3);
            ex.SetCellValue(obj.bxsj.Minute.ToString(), 5, 5);
            ex.SetCellValue(obj.bxdd, 5, 14);
            ex.SetCellValue(obj.bxsj.Hour.ToString(), 15, 3);
            ex.SetCellValue(obj.bxsj.Minute.ToString(), 15, 5);
            ex.SetCellValue(obj.bxdd, 15, 21);
            //修理负责人 修理人员
        //    ex.SetCellValue(obj.xlfzr, 6, 3);
        //    ex.SetCellValue(obj.xlry, 6, 14);
        //    ex.SetCellValue(obj.xlfzr, 20,6);
       //     ex.SetCellValue(obj.xlry, 20, 17);
            //值班受理人和报修人报告方式联系方式
        //    ex.SetCellValue(obj.zbslr, 7, 3);
            ex.SetCellValue(obj.bgfs, 7, 17);
            ex.SetCellValue(obj.bxrxm, 8, 17);
            ex.SetCellValue(obj.lxdh, 9, 17);

            ex.SetCellValue(obj.zbslr, 15, 14);
            ex.SetCellValue(obj.bgfs, 21, 17);
            ex.SetCellValue(obj.bxrxm, 22, 17);
            ex.SetCellValue(obj.lxdh, 23, 17);
            //报告故障情况
            ex.SetCellValue(obj.bggzqc, 10, 3);
            ex.SetCellValue(obj.bggzqc, 16, 3);
            //到现场时间
            //ex.SetCellValue(obj.dsj.Month.ToString(), 17, 3);
            //ex.SetCellValue(obj.dsj.Day.ToString(), 17, 5);
            //ex.SetCellValue(obj.dsj.Hour.ToString(), 17, 9);
            //ex.SetCellValue(obj.dsj.Minute.ToString(), 17, 11);

            //ex.SetCellValue(obj.wsj.Month.ToString(), 17, 17);
            //ex.SetCellValue(obj.wsj.Day.ToString(), 17, 19);
            //ex.SetCellValue(obj.wsj.Hour.ToString(), 17, 21);
            //ex.SetCellValue(obj.wsj.Minute.ToString(), 17, 23);
            //实际故障情况 所有材料
            ex.SetCellValue(obj.sjgzqc, 18, 3);
            ex.SetCellValue(obj.sycl, 19, 3);
            ////停电操作时间和送电操作时间
            //ex.SetCellValue(obj.tdsj.Month.ToString(), 24, 3);
            //ex.SetCellValue(obj.tdsj.Day.ToString(), 24, 5);
            //ex.SetCellValue(obj.tdsj.Hour.ToString(), 24,9);
            //ex.SetCellValue(obj.tdsj.Minute.ToString(), 24, 11);

            //ex.SetCellValue(obj.sdsj.Month.ToString(), 24, 17);
            //ex.SetCellValue(obj.sdsj.Day.ToString(), 24, 19);
            //ex.SetCellValue(obj.sdsj.Hour.ToString(), 24, 21);
            //ex.SetCellValue(obj.sdsj.Minute.ToString(), 24, 23);

            //停电操作在变压器高压套管端子处挂地   #线一组
            if (obj.tdczjxname1 != "")
            {
                ex.SetCellValue("停电操作在变压器高压套管端子处挂地 " + obj.tdczjxname1 + " #线一组", 33, 2);
            
            }
            //停电操作在低压侧挂  #地线一组
            if (obj.tdczjxname2 != "")
            {
                ex.SetCellValue("在低压侧挂 " + obj.tdczjxname2 + " #地线一组", 35, 2);

            }
            //停电操作在工作地点挂  #小地线
            if (obj.tdczjxname3 != "")
            {
                ex.SetCellValue("在工作地点挂 " + obj.tdczjxname3 + " #小地线", 36, 2);

            }

            //送电操作拆出低压侧  #地线一组
            if (obj.sdczjxname1 != "")
            {
                ex.SetCellValue("拆出低压侧  " + obj.sdczjxname1 + " #地线一组", 31, 15);

            }

            //送电操作拆除变压器高压套管端子处  #地线一组
            if (obj.sdczjxname2 != "")
            {
                ex.SetCellValue("拆除变压器高压套管端子处  " + obj.sdczjxname2 + " #地线一组", 32,15);

            }
            if (obj.sjgzqc == obj.bggzqc)
            {
                //停电线路名称及杆号
                ex.SetCellValue(obj.tdxl, 25, 5);
                ex.SetCellValue(obj.tdxlgt, 25, 9);
                //保留带点设备
                ex.SetCellValue("临近保留带电线路或带电设备：" + obj.ddsb, 37, 1);
                //危险及安全措施
                ex.SetCellValue("危险点及安全措施：" + obj.wxd, 38, 1);
            }
            else
            {
                //停电线路名称及杆号
                ex.SetCellValue("", 25, 5);
                ex.SetCellValue("", 25, 9);
                //保留带点设备
                ex.SetCellValue("临近保留带电线路或带电设备：", 37, 1);
                //危险及安全措施
                ex.SetCellValue("危险点及安全措施：" , 38, 1);
            
            }
                ////故障处理经过与结果
                //ex.SetCellValue("故障处理经过和结果：" + obj.cljg, 39, 1);
            
           ex.ShowExcel();
        }
      
    }
}
