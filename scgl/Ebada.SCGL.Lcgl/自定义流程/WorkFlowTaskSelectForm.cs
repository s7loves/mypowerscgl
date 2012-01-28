using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Scgl.WFlow;
using Ebada.Client;

namespace Ebada.Scgl.Lcgl
{
    public partial class WorkFlowTaskSelectForm : FormBase
    {
        public WorkFlowTaskSelectForm()
        {
            InitializeComponent();
        }

        private bool isWorkflowCall = false;
        private DataTable WorkFlowData = null;//实例流程信息
        private DataTable retWorkFlowData = null;//实例流程信息


        public DataTable RecordWorkFlowData
        {
            get
            {

                return WorkFlowData;
            }
            set
            {


                WorkFlowData = value;


            }
        }

        public DataTable RetWorkFlowData
        {
            get { return retWorkFlowData; }
        }


        private void WorkFlowTaskSelectForm_Load(object sender, EventArgs e)
        {
            string taskid="";
            string workFlowId="";
            Hashtable checkkeys = new Hashtable();
            for (int i = 0; i < WorkFlowData.Rows.Count; i++)
            {

                
                checkkeys.Add(WorkFlowData.Rows[i]["WorkTaskId"], WorkFlowData.Rows[i]["TaskCaption"]);
            }
            ArrayList akeys = new ArrayList(checkkeys.Keys);
            comboBoxEdit1.Properties.Items.Clear();
            foreach (string strtask in akeys)
            {
                ListItem lt = new ListItem();
                lt.DisplayMember = checkkeys[strtask].ToString();
                lt.ValueMember = strtask;
                comboBoxEdit1.Properties.Items.Add(lt);
            }
           
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            retWorkFlowData = WorkFlowData.Clone();
            retWorkFlowData.Rows.Clear();
            if (comboBoxEdit1.SelectedIndex > -1)
            {
                DataRow dr = retWorkFlowData.NewRow();
                foreach (DataRow drtemp in WorkFlowData.Rows)
                {
                    if (drtemp["WorkTaskId"].ToString() != ((ListItem)comboBoxEdit1.SelectedItem).ValueMember)
                        continue;
                    foreach (DataColumn dc in WorkFlowData.Columns)
                    {
                        dr[dc.ColumnName] = drtemp[dc.ColumnName];
                    }
                }
                retWorkFlowData.Rows.Add(dr);
                this.DialogResult = DialogResult.OK;
            }
            else
            {

                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
