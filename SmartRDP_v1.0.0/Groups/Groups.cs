using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRDP_v1._0._0
{
    public partial class Groups : Form
    {
        private MainWindow1 main;
        public Groups(MainWindow1 mainWindow1)
        {
            InitializeComponent();
            main = mainWindow1;
        }
        
        private void Groups_Load(object sender, EventArgs e)
        {
            UC_Groups ucGroups = new UC_Groups(main);
            ucGroups.Dock = DockStyle.Fill;
            this.Controls.Add(ucGroups);
            ucGroups.Show();
        }
    }
}
