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

        public static void FillCBoxByGt(ComboBoxEdit c) {
            c.Properties.Items.Clear();
            c.Properties.Items.AddRange(ComboBoxHelper.GetsbxhList("18"));
        }
    }
}
