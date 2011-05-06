using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace Ebada.Modules.Demo
{
    public partial class frmModelCheck : Form
    {
        CheckObj obj = new CheckObj();
        public frmModelCheck()
        {
            InitializeComponent();
            dataBind();
        }
        void dataBind()
        {
            
            this.textEdit1.DataBindings.Add("EditValue", obj, "StrText1");
            this.dateEdit1.DataBindings.Add("EditValue", obj, "Date1");
            this.spinEdit1.DataBindings.Add("EditValue", obj, "Num1");

            RegistryValidateEvent(textEdit1);
            RegistryValidateEvent(dateEdit1);
            RegistryValidateEvent(spinEdit1);

        }
        
        protected void RegistryValidateEvent(TextEdit control)
        {
            //放到FormBase中
            control.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            control.Validating += textEdit_Validating;
        }
      
        private void textEdit_Validating(object sender, CancelEventArgs e)
        {
            //放到FormBase中
            TextEdit edit = sender as TextEdit;
            if (edit == null) return;
            try
            {
                Binding binding = edit.DataBindings["EditValue"];
                if (binding == null) return;
                string p = binding.BindingMemberInfo.BindingMember;
                Type type = binding.DataSource.GetType();
                PropertyInfo pf = type.GetProperty(p);
                Object value = edit.EditValue;
                if(edit is DateEdit){
                    value = (edit as DateEdit).DateTime;
                }
                else if (pf.PropertyType == typeof(Int32))
                {
                    value = Convert.ToInt32(value);
                }
                else
                {
                    //如果value值和属性值的类型不 一样需要在这转换
                }
                pf.SetValue(binding.DataSource, value, null);
            }
            catch (Exception err)
            {
                e.Cancel = true;
                
                edit.ErrorText = err.InnerException.Message;
            }
        }
    }
}
