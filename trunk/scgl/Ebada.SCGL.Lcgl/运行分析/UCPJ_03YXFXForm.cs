using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.Lcgl
{
    public partial class UCPJ_03YXFXForm : Form
    {
        public UCPJ_03YXFXForm()
        {
            InitializeComponent();
        }
        public void UCPJ_03YXFXForm_DQFX()
        {
            //InitializeComponent();
            ucpJ_03yxfx1.RecordIkind = "流程定期分析";
            //ucpJ_03yxfx1.InitColumns();
            //ucpJ_03yxfx1.InitData();
            this.Show();
            

        }
        public void UCPJ_03YXFXForm_ZTFX()
        {
            //InitializeComponent();
            ucpJ_03yxfx1.RecordIkind = "流程专题分析";
            //ucpJ_03yxfx1.InitColumns();
            //ucpJ_03yxfx1.InitData();
            this.Show() ;
           
        }

        private void UCPJ_03YXFXForm_Load(object sender, EventArgs e)
        {
            this.Text = "运行分析-" + ucpJ_03yxfx1.RecordIkind;
        }
    }
}
