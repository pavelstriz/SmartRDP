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

    public partial class pictureBoxWCount : UserControl
    {
        public pictureBoxWCount()
        {
            InitializeComponent();
     

        }
        public string _colCount;
        public string colCountStored
        {
            get { return _colCount; }
            set { _colCount = value; selectedColNumber.Text = value; }
        }
        private void pictureBoxWCount_Load(object sender, EventArgs e)
        {
      


        }

    }
}
