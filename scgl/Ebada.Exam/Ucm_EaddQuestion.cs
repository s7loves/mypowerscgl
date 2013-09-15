using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Exam
{
    public partial class Ucm_EaddQuestion : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void ChangeObj(Dictionary<string, E_QuestionBank> dic);
        public event ChangeObj ChangeDic;

        public Ucm_EaddQuestion()
        {
            InitializeComponent();
            ucE_QuestionBankForAdd1.DeleteObj += new UCE_QuestionBankForAdd.RemoveObj(ucE_QuestionBankForAdd1_DeleteObj);
            ucE_QuestionBankForAdd2.DeleteObj += new UCE_QuestionBankForAdd.RemoveObj(ucE_QuestionBankForAdd2_DeleteObj);
        }
        void ucE_QuestionBankForAdd1_DeleteObj(Dictionary<string, Ebada.Scgl.Model.E_QuestionBank> dic)
        {
            eqdic = dic;
            ucE_QuestionBankForAdd2.eqdic = dic;
            ucE_QuestionBankForAdd2.DataRefresh();
            if (ChangeDic!=null)
            {
                ChangeDic(eqdic);
            }
        }
        void ucE_QuestionBankForAdd2_DeleteObj(Dictionary<string, Ebada.Scgl.Model.E_QuestionBank> dic)
        {
            eqdic = dic;
            ucE_QuestionBankForAdd1.eqdic = dic;
            ucE_QuestionBankForAdd1.DataRefresh();
            if (ChangeDic != null)
            {
                ChangeDic(eqdic);
            }
        }
        public int DesNum;
        public string PID;
        public string Type;
        public Dictionary<string, E_QuestionBank> eqdic;
        protected override void OnLoad(EventArgs e)
        {
                base.OnLoad(e);
                InitData();
        }

        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            Frefresh();
        }
        private void Frefresh()
        {
            ucE_QuestionBankForAdd1.DesNum = DesNum;
            ucE_QuestionBankForAdd1.intfalg = 0;
            ucE_QuestionBankForAdd1.pid = PID;
            ucE_QuestionBankForAdd1.type = Type;
            ucE_QuestionBankForAdd1.eqdic = eqdic;
            ucE_QuestionBankForAdd1.DataRefresh();

            ucE_QuestionBankForAdd2.intfalg = 1;
            ucE_QuestionBankForAdd2.pid = PID;
            ucE_QuestionBankForAdd2.type = Type;
            ucE_QuestionBankForAdd2.eqdic = eqdic;

            ucE_QuestionBankForAdd2.DataRefresh();

        }
    }
}
