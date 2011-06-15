using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Ebada.Scgl.Core {
    public static class UserRightHelper {
        private static ArrayList m_btNamesList;

        public static ArrayList BtNamesList {
            get { return UserRightHelper.m_btNamesList; }
            set { UserRightHelper.m_btNamesList = value; }
        }
        private static List<string> m_UserFunction;

        public static List<string> UserFunctions {
            get { return UserRightHelper.m_UserFunction; }
            set { UserRightHelper.m_UserFunction = value; }
        }

        static UserRightHelper(){
            string[] btNames = new string[] { "btAdd", "btEdit", "btDelete", "btFind", "btExport", "btRefresh" };
            m_btNamesList.AddRange(btNames);
        }
        /// <summary>
        /// 设置工具栏权限
        /// </summary>
        /// <param name="control">注册模块的用户对象</param>
        /// <param name="barmanager">工具栏的管理对象</param>
        public static void SetToolbar(UserControl control,BarManager barmanager) {
            if ((control.Site == null) && (barmanager != null)) {
                List<string> userFunction = UserFunctions;
                if ((control != null) && (userFunction != null)) {
                    IList btNames = BtNamesList;
                    string fullName = control.GetType().FullName;
                    foreach (BarItem item in barmanager.Items) {
                        if (userFunction.Contains(fullName + "_" + item.Name)) {
                            item.Enabled = true;
                        } else if (btNames.Contains(item.Name)) {
                            item.Enabled = false;
                        }
                    }
                }
            }
        }
        public static void SetToolbar(string moduTypes, BarManager barmanager) {
            if ( (barmanager != null)) {
                List<string> userFunction = UserFunctions;
                if ((userFunction != null)) {
                    IList btNames = BtNamesList;
                    string fullName = moduTypes;
                    foreach (BarItem item in barmanager.Items) {
                        if (userFunction.Contains(fullName + "_" + item.Name)) {
                            item.Enabled = true;
                        } else if (btNames.Contains(item.Name)) {
                            item.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}
