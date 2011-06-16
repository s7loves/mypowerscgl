using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmOperator :BaseForm_Single
    {
        public string OperContent="";
        public string Description = "";
        public string OperDisplay = "";
        public int OperType;
        public int Relation=0;//û��ϵ
        public bool InorExclude;
        public string fmState="";
        public string OperId = "";
        public string WorkflowId = "";
        public fmOperator(string state)
        {
            InitializeComponent();
            fmState=state;
           
        }
        private void setOperation()
        {
            ///////������//////////
            if (rbtOpr1.Checked)//
            {
                Description = "����������";
                OperType = 1;
                OperDisplay = "����������";

            }
            else//ĳһ����ʵ��ִ����
                if (rbtOpr2.Checked)
                {
                    Description = "[" + tbxOpr2.Text + "]����ʵ��ִ����";
                    OperDisplay = tbxOpr2.Text;
                    OperType = 2;
                }
                else//ָ����Ա
                    if (rbtOpr3.Checked)
                    {
                        Description = tbxOpr3.Text;
                        OperDisplay = tbxOpr3.Text;
                        OperType = 3;
                    }
                    else//����
                        if (rbtOpr4.Checked)
                        {
                            Description = tbxOpr4.Text;
                            OperDisplay = tbxOpr4.Text;
                            OperType = 4;
                        }
                        else// ��ɫ
                            if (rbtOpr5.Checked)
                            {
                                Description = tbxOpr5.Text;
                                OperDisplay = tbxOpr5.Text;
                                OperType = 5;
                            }
                            else//��λ
                                if (rbtOpr6.Checked)
                                {
                                    Description = tbxOpr6.Text;
                                    OperDisplay = tbxOpr6.Text;
                                    OperType = 6;
                                }
                                else//�ӱ����л�ȡ
                                    if (rbtOpr7.Checked)
                                    {
                                        Description = tbxOpr7.Text;
                                        OperDisplay = tbxOpr7.Text;
                                        OperType = 7;
                                    }
                                    else//ĳһ����ѡ��Ĵ�����
                                        if (rbtOpr8.Checked)
                                        {
                                            Description = tbxOpr8.Text;
                                            OperDisplay = tbxOpr8.Text;
                                            OperType = 8;
                                        }
                                        else//������
                                            if (rbtOpr9.Checked)
                                            {
                                                Description = "������";
                                                OperDisplay = Description;
                                                OperType = 9;
                                            }
            ///////��ϵɸѡ//////////
            if (rbtRlt1.Checked && cbxRelation.Checked)//�������쵼
            {
                Description = "�������쵼 of [" + Description + "]";
                Relation = 1;
            }
            else
                if (rbtRlt2.Checked && cbxRelation.Checked)//���ڲ���
                {
                    Description = "���ڲ��� of [" + Description + "]";
                    Relation = 2;
                }
                else
                    if (rbtRlt3.Checked && cbxRelation.Checked)//�ϼ�����
                    {
                        Description = "�ϼ����� of [" + Description + "]";
                        Relation = 3;
                    }
                    else
                        if (rbtRlt4.Checked && cbxRelation.Checked)//�¼�����
                        {
                            Description = "�¼����� of [" + Description + "]";
                            Relation = 4;
                        }
                        else
                            if (rbtRlt5.Checked && cbxRelation.Checked)//�ϼ��쵼
                            {
                                Description = "�ϼ��쵼 of [" + Description + "]";
                                Relation = 5;
                            }
                            else
                                if (rbtRlt6.Checked && cbxRelation.Checked)//�¼��쵼
                                {
                                    Description = "�¼��쵼 of [" + Description + "]";
                                    Relation = 6;
                                }
                                else Relation = 0;
            /////�����ų�//////////
            if (rbtInclude.Checked)
            {
                InorExclude = true;
            }
            else
                if (rbtExclude.Checked)
                {
                    InorExclude = false;
                }
        }
        private void InitData()
        {
   
            if (InorExclude)
                rbtInclude.Checked = true;
            else rbtExclude.Checked = true;
            switch (OperType)
            {
                case 1:
                    rbtOpr1.Checked = true;
                    break;
                case 2:

                    rbtOpr2.Checked = true;
                   // tbxOpr2.Enabled = true;
                    tbxOpr2.Text = OperDisplay;
                    break;
                case 3:

                    rbtOpr3.Checked = true;
                    //tbxOpr3.Enabled = true;
                    tbxOpr3.Text = OperDisplay;
                    break;
                case 4:


                    rbtOpr4.Checked = true;
                   // tbxOpr4.Enabled = true;
                    tbxOpr4.Text = OperDisplay;
                    break;
                case 5:

                    rbtOpr5.Checked = true;
                   // tbxOpr5.Enabled = true;
                    tbxOpr5.Text = OperDisplay;
                    break;
                case 6:

                    rbtOpr6.Checked = true;
                  //  tbxOpr6.Enabled = true;
                    tbxOpr6.Text = OperDisplay;
                    break;
                case 7:

                    rbtOpr7.Checked = true;
                    //tbxOpr7.Enabled = true;
                    tbxOpr7.Text = OperDisplay;
                    break;
                case 8:
                    rbtOpr8.Checked = true;
                   // tbxOpr8.Enabled = true;
                    tbxOpr8.Text = OperDisplay;
                    break;
                case 9:
                    rbtOpr9.Checked = true;
                    break;
            }
            if (Relation != 0) cbxRelation.Checked = true; else cbxRelation.Checked = false;
            switch (Relation)
            {
                case 1:
                    rbtRlt1.Checked = true;
                    break;
                case 2:
                    rbtRlt2.Checked = true;
                    break;
                case 3:
                    rbtRlt3.Checked = true;
                    break;
                case 4:
                    rbtRlt4.Checked = true;
                    break;
                case 5:
                    rbtRlt5.Checked = true;
                    break;
                case 6:
                    rbtRlt6.Checked = true;
                    break;


            }
            
        }
        private void operEnable()
        {
            //tbxOpr2.Enabled = rbtOpr2.Checked;
            //tbxOpr3.Enabled = rbtOpr3.Checked;
            //tbxOpr4.Enabled = rbtOpr4.Checked;
            //tbxOpr5.Enabled = rbtOpr5.Checked;
            //tbxOpr6.Enabled = rbtOpr6.Checked;
            //tbxOpr7.Enabled = rbtOpr7.Checked;
            //tbxOpr8.Enabled = rbtOpr8.Checked;

            btnSelectOpr.Enabled = rbtOpr2.Checked;
            btnSelectUser.Enabled = rbtOpr3.Checked;
            btnSelectArch.Enabled = rbtOpr4.Checked;
            btnSelectRole.Enabled = rbtOpr5.Checked;
            btnSelectDuty.Enabled = rbtOpr6.Checked;
            btnSelectVar.Enabled = rbtOpr7.Checked;
            btnSelectTask.Enabled = rbtOpr8.Checked;

           
        }

        private void rltEnable(bool enable)
        {
            rbtRlt1.Enabled = enable;
            rbtRlt2.Enabled = enable;
            rbtRlt3.Enabled = enable;
            rbtRlt4.Enabled = enable;
            rbtRlt5.Enabled = enable;
            rbtRlt6.Enabled = enable;
 
        }
        private void operEnable(bool enable)
        {
            rbtOpr1.Enabled = enable;
            rbtOpr2.Enabled = enable;
            rbtOpr3.Enabled = enable;
            rbtOpr4.Enabled = enable;
            rbtOpr5.Enabled = enable;
            rbtOpr6.Enabled = enable;
            rbtOpr7.Enabled = enable;
            rbtOpr8.Enabled = enable;
            rbtOpr9.Enabled = enable;

            operEnable();

            groupBox2.Enabled = enable;

 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            setOperation();
            Close();
           
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            fmSelectUser tmpfmSelectUser = new fmSelectUser();
            tmpfmSelectUser.ShowDialog();
             DialogResult dlr = tmpfmSelectUser.DialogResult;
             if (dlr == DialogResult.OK && tmpfmSelectUser.lvUser.SelectedItems.Count>0)
             {
                 tbxOpr3.Text=tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
                 OperContent = tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
             }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectArch_Click(object sender, EventArgs e)
        {
            fmSelectArch tmpfmSelectArch = new fmSelectArch(WorkConst.ARCHITECTURE_ARCH);
            tmpfmSelectArch.ShowDialog();
            DialogResult dlr = tmpfmSelectArch.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectArch.tvArch.SelectedNode != null)
            {
                tbxOpr4.Text = tmpfmSelectArch.tvArch.SelectedNode.Text;
                OperContent = (tmpfmSelectArch.tvArch.SelectedNode as BaseTreeNode).NodeId;
            }
        }

        private void btnSelectRole_Click(object sender, EventArgs e)
        {
            fmSelectGroup tmpfmSelectGroup = new fmSelectGroup();
            tmpfmSelectGroup.ShowDialog();
            DialogResult dlr = tmpfmSelectGroup.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectGroup.lvGroup.SelectedItems.Count>0)
            {
                tbxOpr5.Text = tmpfmSelectGroup.lvGroup.SelectedItems[0].Text;
                OperContent = tmpfmSelectGroup.lvGroup.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnSelectDuty_Click(object sender, EventArgs e)
        {
            fmSelectArch tmpfmSelectArch = new fmSelectArch(WorkConst.ARCHITECTURE_DUTY);
            tmpfmSelectArch.ShowDialog();
            DialogResult dlr = tmpfmSelectArch.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectArch.tvArch.SelectedNode != null)
            {
                tbxOpr6.Text = tmpfmSelectArch.tvArch.SelectedNode.Text;
                OperContent = (tmpfmSelectArch.tvArch.SelectedNode as BaseTreeNode).NodeId;
            }

        }

        private void fmOperator_Load(object sender, EventArgs e)
        {
            if (fmState == WorkConst.STATE_MOD)
            {
                InitData();

            }
        }

        private void rbtOpr2_CheckedChanged(object sender, EventArgs e)
        {
            //ĳһ����ʵ�ʴ�����2
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
            
        }

        private void rbtOpr1_CheckedChanged(object sender, EventArgs e)
        {
            //����������1
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
         
        }

        private void rbtOpr3_CheckedChanged(object sender, EventArgs e)
        {
            //ָ��������3
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
        }

        private void rbtOpr4_CheckedChanged(object sender, EventArgs e)
        {
            //����4
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
            rbtRlt2.Enabled = false;

        }

        private void rbtOpr5_CheckedChanged(object sender, EventArgs e)
        {
            //��ɫ5
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
   
        }

        private void rbtOpr6_CheckedChanged(object sender, EventArgs e)
        {
            //��λְ��6
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
      
        }

        private void rbtOpr7_CheckedChanged(object sender, EventArgs e)
        {
            //�ӱ����л�ȡ7
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void rbtOpr8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtOpr9_CheckedChanged(object sender, EventArgs e)
        {
            //������9
            operEnable();
            rltEnable(false);
            OperContent = "ALL";
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void cbxRelation_CheckedChanged(object sender, EventArgs e)
        {
            rltEnable(cbxRelation.Checked);
        }

        private void btnSelectOpr_Click(object sender, EventArgs e)
        {
            fmSelectTaskOperUser tmpfmSelectTaskOperUser = new fmSelectTaskOperUser(WorkflowId);
            tmpfmSelectTaskOperUser.ShowDialog();
            DialogResult dlr = tmpfmSelectTaskOperUser.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectTaskOperUser.lvTask.SelectedItems.Count > 0)
            {
                tbxOpr2.Text = tmpfmSelectTaskOperUser.lvTask.SelectedItems[0].Text;
                OperContent = tmpfmSelectTaskOperUser.lvTask.SelectedItems[0].SubItems[1].Text;
            }

        }

        private void btnSelectTask_Click(object sender, EventArgs e)
        {
           
        }
    
        private void rbtExclude_CheckedChanged(object sender, EventArgs e)
        {
            //�ų�������ʱ�������ų������ĳ��userid
            if (rbtExclude.Checked == true)
            {
                operEnable(false);
                this.rbtOpr3.Enabled = true;
                this.rbtOpr3.Checked = true;
                btnSelectUser.Enabled = true;
            }

        }

        private void rbtInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtInclude.Checked == true)
            {
                operEnable(true);
            }
        }
    }
}