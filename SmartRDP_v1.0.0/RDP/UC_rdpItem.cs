using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDP;
using System.IO;
using SmartRDP_v1;
using System.Diagnostics;
using System.Data.SqlClient;

namespace SmartRDP_v1._0._0
{
    public partial class rdpItem : UserControl
    {
        public rdpItem()
        {
            InitializeComponent();
            
        }
        
        public PictureBox _picture;
        public PictureBox pictureStored
        {
            get { return _picture; }
            set { _picture = value; pictureBox1 = value; }
        }
        public string _hostName;
        public string hostNameStored
        {
            get { return _hostName; }
            set { _hostName = value; RI_hostName.Text = value; }
        }
        public string _ipAddress;
        public string ipAddressStored
        {
            get { return _ipAddress; }
            set { _ipAddress = value; RI_ipAddress.Text = value; }
        }
        public string _userName;
        public string userNameStored
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string _userPassword;
        public string userPasswordStored
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        private void rdpItem_Load(object sender, EventArgs e)
        {
            File.Delete(RdpConstant.FilePath);
            foreach (Control c in this.Controls)
            {
                c.DoubleClick += new EventHandler(yourEvent_handler_click);
                
           
            }foreach (Control a in tableLayoutPanel1.Controls)
            {
                a.DoubleClick += new EventHandler(yourEvent_handler_click);
   
            }

        }
        private static void _mstsc(String cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
        }
        public void yourEvent_handler_click(object sender, EventArgs e)
        {
            var pwstr = BitConverter.ToString(DataProtection.ProtectData(Encoding.Unicode.GetBytes(userPasswordStored), "")).Replace("-", "");
            var rdpInfo = String.Format(File.ReadAllText(RdpConstant.templatePath), _ipAddress, userNameStored, pwstr);
            File.WriteAllText(RdpConstant.FilePath, rdpInfo);

            _mstsc("mstsc " + RdpConstant.FilePath);
        }
        public bool mEnter = false;
        private void rdpItem_MouseEnter(object sender, EventArgs e)
        {
            mEnter = true;
            if (holdItem != true)
            {
                this.BackColor = Color.LightGray;
            }
        }
        private void rdpItem_MouseLeave(object sender, EventArgs e)
        {
            if (holdItem != true)
            {
                this.BackColor = Color.FromArgb(242, 242, 242);
            }
        }
        private bool holdItem = false;

    }
}
