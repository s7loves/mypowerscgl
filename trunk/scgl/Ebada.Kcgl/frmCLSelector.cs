using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    public partial class frmCLSelector : XtraForm {
        public  UC材料名称 uc材料表;
        public kc_材料名称表 Selected材料;//当前被选中材料
        public frmCLSelector() {
            InitializeComponent();
            createCLGrid();
            this.Text = "选择材料";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void createCLGrid() {
            //初始材料列表
            uc材料表 = new UC材料名称();
            uc材料表.Dock = DockStyle.Fill;
            uc材料表.Parent = this;
            uc材料表.FocusedNodeChanged += new Ebada.Client.SendDataEventHandler<Ebada.Kcgl.Model.kc_材料名称表>(uc材料表_FocusedNodeChanged);
            uc材料表.ShowbtOK = true;
        }

        void uc材料表_FocusedNodeChanged(object sender, Ebada.Kcgl.Model.kc_材料名称表 obj) {
            Selected材料 = obj;
        }     
    }
}
