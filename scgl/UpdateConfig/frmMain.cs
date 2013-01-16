using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace UpdateConfig
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetSetIp(false);
        }

        private void GetSetIp(bool save)
        {
            #region
            try
            {
                string Autoupdater_config = Application.StartupPath + "\\Autoupdater.config";
                string ClientConfig_xml = Application.StartupPath + "\\Config\\ClientConfig.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(Autoupdater_config);
                XmlNodeList nodeServerUrllist = doc.GetElementsByTagName("ServerUrl");
                XmlNodeList nodeUpfileUrllist = doc.GetElementsByTagName("UpfileUrl");

                XmlDocument doc1 = new XmlDocument();
                doc1.Load(ClientConfig_xml);

                if (save)
                {
                    foreach (XmlElement item in doc1.GetElementsByTagName("facility"))
                    {
                        item.Attributes["remoteKernelUri"].Value = "tcp://" + txtServerUrlIP.EditValue + ":5100/kernel.rem";
                        item.Attributes["baseUri"].Value = "tcp://" + txtServerUrlIP.EditValue + ":5100";
                    }

                    nodeServerUrllist[0].InnerXml = "http://" + txtServerUrlIP.EditValue + "/ScglUpdateService/AutoupdateService.xml";
                    nodeUpfileUrllist[0].InnerXml = "http://" + txtServerUrlIP.EditValue + "/ScglUpFileService/UpFileHandler.ashx";

                    doc.Save(Autoupdater_config);
                    doc1.Save(ClientConfig_xml);
                }
                else
                {
                    txtServerUrlIP.EditValue = nodeUpfileUrllist[0].InnerXml.Replace("http://", "").Replace("/ScglUpFileService/UpFileHandler.ashx", "");
                }

            }
            catch
            {
                MessageBox.Show("读写文件失败！");
                Application.Exit();
            }
            #endregion
        }

        #region 取消修改   并    退出程序
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnSave_Click(sender, e);
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServerUrlIP.Text.Trim() != "")
            {
                Regex reg = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                if (!reg.IsMatch(txtServerUrlIP.Text))
                {
                    MessageBox.Show(lblServerUrlIP.Text + "不正确，请重新输入！");
                    txtServerUrlIP.Focus();
                    txtServerUrlIP.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入" + lblServerUrlIP.Text);
                txtServerUrlIP.Focus();
                return;
            }

            if (MessageBox.Show("确定保存修改？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                GetSetIp(true);
                MessageBox.Show("保存成功！");
                Application.Exit();
            }
        }
    }
}