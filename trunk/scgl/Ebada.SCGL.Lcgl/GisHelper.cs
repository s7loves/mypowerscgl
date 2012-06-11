using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ebada.Scgl.Lcgl {
    class GisHelper {
        const string gislib = "Ebada.Scgl.Gis.dll";
        const string gisclass = "Ebada.Scgl.Gis.GMapHelper";
        /// <summary>
        /// 显示单线图
        /// </summary>
        /// <param name="lineCode">线路代码</param>
        internal static void ShowDxt(string lineCode) {
            Ebada.Client.Platform.MainHelper.Execute(gislib, gisclass, "ShowDxt", new object[] { lineCode });
        }
        /// <summary>
        /// 显示地理图
        /// </summary>
        /// <param name="gdsCode">供电所代码，值为all时显示全局</param>
        internal static void ShowDlt(string gdsCode) {
            Ebada.Client.Platform.MainHelper.Execute(gislib, gisclass, "ShowDlt", new object[] { gdsCode });
        }
        /// <summary>
        /// 显示台区图
        /// </summary>
        /// <param name="tqCode">台区代码</param>
        internal static void ShowDyt(string tqCode) {
            Ebada.Client.Platform.MainHelper.Execute(gislib, gisclass, "ShowDyt", new object[] { tqCode });
        }

        internal static System.Drawing.Bitmap GetDytqMap(string tqcode, int p, int p_3) {
            object obj =Ebada.Client.Platform.MainHelper.Execute(gislib, gisclass, "GetDytqMap", new object[] { tqcode, p, p_3 });
            return obj as Bitmap;
        }
    }
}
