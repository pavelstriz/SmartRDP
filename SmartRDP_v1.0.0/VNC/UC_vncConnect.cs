using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRDP_v1._0._0
{
    public partial class UC_vncConnect : UserControl
    {
        public UC_vncConnect()
        {
            InitializeComponent();
            
        }

        
        public static string _vncIp;
        public static string vncIpStored
        {
            get { return _vncIp; }
            set { _vncIp = value;}
        }
        public static int _vncPort;
        public static int vncPortStored
        {
            get { return _vncPort; }
            set { _vncPort = value; }
        }
        private void vncIp_TextChanged(object sender, EventArgs e)
        {
            _vncIp = vncIp.Text;
        }
        private void vncPort_TextChanged(object sender, EventArgs e)
        {
            _vncPort = Int32.Parse(vncPort.Text);
        }
    }
}
