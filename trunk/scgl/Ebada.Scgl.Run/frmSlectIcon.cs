using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Resource;

namespace Ebada.Scgl.Run
{
    public partial class frmSlectIcon : DevExpress.XtraEditors.XtraForm
    {
        public frmSlectIcon()
        {
            InitializeComponent(); 
            ImageList imagelist =ImageListRes.GetimageListAll(48, "");
            add_image(imagelist);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          string keyname=txtImageName.Text.Trim();
                ImageList imagelist = ImageListRes.GetimageListAll(40,keyname);
                add_image(imagelist);
        }
        protected void add_image(ImageList templist)
        {
            tabControl1.Controls.Clear();
           int m=0;
            if (templist.Images.Count%24==0)
	        {
                m=templist.Images.Count/24;

	        }
            else
	        {
                m=templist.Images.Count/24;
                m=m+1;
	        }
           
            for (int i = 0; i < m; i++)
            {
                System.Windows.Forms.TabPage temptabPage = new TabPage();
                temptabPage.Text = "第" + (i + 1 )+ "页";
                
                
                ListView templistview=new ListView ();
                templistview.DoubleClick+=new EventHandler(templistview_DoubleClick);
                temptabPage.Controls.Add(templistview);
                templistview.Dock = System.Windows.Forms.DockStyle.Fill;
                templistview.LargeImageList = templist;
                for (int j = 0; j < 24; j++)
                {
                    if (templist.Images.Count <= i * 24 + j)
                    {
                        break;
                    }
                    ListViewItem item = new ListViewItem(templist.Images.Keys[i * 24 + j].ToString());
                    item.ImageKey = templist.Images.Keys[i * 24 + j].ToString();
                    templistview.Items.Add(item);
                }
                tabControl1.Controls.Add(temptabPage);
               
            }
           
        }

        void templistview_DoubleClick(object sender, EventArgs e)
        {
                ListViewItem item = ((ListView)sender).SelectedItems[0];
                selectedImageKey = item.Text;
                this.DialogResult = DialogResult.OK;
        }

        string selectedImageKey = string.Empty;

        public string SelectedImageKey {
            get { return selectedImageKey; }
            set { selectedImageKey = value; }
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {

        }

      
    }
}
