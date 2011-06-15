using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export20  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_20 obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = "20低压设备完好率及台区网络图";
            Ecommon.WriteDoc(obj.BigData,ref fname);
            ex.Open(fname);
            //此处写填充内容代码

           ex.ShowExcel();
        }
      
    }
}
