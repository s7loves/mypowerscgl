using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Core {
    /// <summary>
    /// 配电设备型号助手类
    /// </summary>
    public static class pdsbModelHelper {

        public  const string dxxh = "02";
        public const string byqxh = "08";
        public  const string gtzl = "18";
        public  const string gtxh = "";
        public static void FillCBoxByGt(ComboBoxEdit c) {
            c.Properties.Items.Clear();
            c.Properties.Items.AddRange(ComboBoxHelper.GetsbxhList(gtzl));
        }
        /// <summary>
        /// 填充型号列表
        /// </summary>
        /// <param name="c"></param>
        /// <param name="xhdm"></param>
        public static void FillCBox(ComboBoxEdit c,string xhdm) {
            c.Properties.Items.Clear();
            c.Properties.Items.AddRange(ComboBoxHelper.GetsbxhList(xhdm));
        }
    }
}
