using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.Scgl.Gis {
    public class GMapHelper {
        /// <summary>
        /// 显示单线图
        /// </summary>
        /// <param name="lineCode">线路代码</param>
        public void ShowDxt(string lineCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDxt(lineCode);
        }
        /// <summary>
        /// 显示地理图
        /// </summary>
        /// <param name="gdsCode">供电所代码，为all时显示全局</param>
        public void ShowDlt(string gdsCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDlt(gdsCode);
        }
        /// <summary>
        /// 显示台区图
        /// </summary>
        /// <param name="tqCode">台区代码</param>
        public void ShowDyt(string tqCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDyt(tqCode);

        }
    }
}
