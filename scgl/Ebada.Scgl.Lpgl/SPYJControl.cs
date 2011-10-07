using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lpgl
{
    public partial class SPYJControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SPYJControl()
        {
            InitializeComponent();
        }
        private string recordID;//所属记录的ID
        private string taskID;//所属节点的ID
        public string RecordID
        {
            get { return recordID; }
            set
            {
                recordID = value;

            }
        }
        public string TaskID
        {
            get { return taskID; }
            set
            {
                taskID = value;

            }
        }
        private void inidata()
        {
            preMemoEdit.Text = "";
            IList<PJ_lcspyj>spyjlist = MainHelper.PlatformSqlMap.GetList<PJ_lcspyj>("SelectPJ_lcspyjList", "where RecordID='" + recordID + "' order by creattime");
            for (int i = 0; i < spyjlist.Count; i++)
            {
               preMemoEdit.Text+= spyjlist[i].Charman + ":" + "\r\n" + spyjlist[i].Spyj + "\r\n";

            }
        }
        private void SPYJControl_Load(object sender, EventArgs e)
        {
            inidata();
            this.preMemoEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.preMemoEdit_EditValueChanging);
        }

        private void preMemoEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;

        }
    }
}
