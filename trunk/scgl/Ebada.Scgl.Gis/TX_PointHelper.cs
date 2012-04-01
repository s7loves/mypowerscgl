using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Gis {
    public class TX_PointHelper {
        internal static void Update(TX_Point pt) {
            Client.ClientHelper.PlatformSqlMap.Update<TX_Point>(pt);
        }

        internal static void Create(TX_Point pt) {
            try {
                Client.ClientHelper.PlatformSqlMap.Create<TX_Point>(pt);
            } catch (Exception err) {
                //MessageBox.Show(err.Message);
                if (err.Message.IndexOf("FOREIGN") > 0) {
                    TX_Project pro = new TX_Project();
                    pro.ProID = "0";
                    pro.ProjectName = "地理接线图";
                    try {
                        Client.ClientHelper.PlatformSqlMap.Create<TX_Project>(pro);
                    } catch { }

                    TX_Layer lay = new TX_Layer();
                    lay.LayerID = pt.LayerID;
                    lay.ProID = "0";
                    //try {
                        Client.ClientHelper.PlatformSqlMap.Create<TX_Layer>(lay);
                        Client.ClientHelper.PlatformSqlMap.Create<TX_Point>(pt);
                    //} catch { }
                }
            }
        }
        internal static void Create(string pt) {

        }
    }
}
