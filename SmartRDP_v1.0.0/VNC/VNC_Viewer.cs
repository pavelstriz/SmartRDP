using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;
using SmartRDP_v1;
using VncSharp;

namespace SmartRDP_v1._0._0
{
    public partial class VNC_Viewer : Form
    {
        private UC_vncConnect uC_VncConnect;
        public VNC_Viewer(UC_vncConnect _uC_VncConnect)
        {
            InitializeComponent();
            uC_VncConnect = _uC_VncConnect;
        }
        protected void ConnectComplete(object sender, ConnectEventArgs e)
        {
            // Update Form to match geometry of remote desktop
            ClientSize = new Size(e.DesktopWidth, e.DesktopHeight);

            // Change the Form's title to match desktop name
            Text = e.DesktopName;
        }

        protected void ConnectionLost(object sender,EventArgs e)
        {
            // Let the user know of lost connection
            //MessageBox.Show("Lost Connection to Host!");
        }
     
        
        private void Remote_Desktop_Load(object sender, EventArgs e)
        {
            try
            {
                vncDesktop1.VncPort = UC_vncConnect.vncPortStored;
                vncDesktop1.Connect(UC_vncConnect.vncIpStored);
                vncDesktop1.ConnectComplete += new ConnectCompleteHandler(ConnectComplete);
                vncDesktop1.ConnectionLost += new EventHandler(ConnectionLost);
            }
            catch
            {

            }
            //vncDesktop1.Height = 200;

            //vncDesktop1.Connect(SmartRDP.vncServerStored);
            //vncDesktop1.Height = 200;
            //vncDesktop1.FullScreenUpdate();
            //vncDesktop1.FullScreenUpdate();



            /*try
            {
                //MessageBox.Show(SmartRDP.userPasswordStored.ToString());
                rdpClient.Server = SmartRDP.serverStored;
                rdpClient.UserName = SmartRDP.userNameStored;
                
                //axMsTscAxNotSafeForScripting1.AdvancedSettings.BitmapPersistence
                //axMsTscAxNotSafeForScripting1.//.AdvancedSettings.BitmapPersistence
                IMsTscNonScriptable secured = (IMsTscNonScriptable)this.rdpClient.GetOcx();
                secured.ClearTextPassword = SmartRDP.userPasswordStored;

                rdpClient.ColorDepth = 24;
                rdpClient.DesktopWidth = 1024; // int value 
                rdpClient.DesktopHeight = 768; // int value 
                //rdpClient.FullScreen = true | false;

                //rdpClient.FullScreen = true;
                // strecth the screen
                rdpClient.AdvancedSettings3.SmartSizing = true;

                //axMsTscAxNotSafeForScripting1.AdvancedSettings7.EnableCredSspSupport = true;

                rdpClient.Connect();
                MessageBox.Show("Connected");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Close();
                
            }*/
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            if (vncDesktop1.IsConnected)
            {
                MessageBox.Show("Connection is closed.");
                vncDesktop1.Disconnect();
                base.OnClosing(e);
            }
            else
            {
               
            }
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
                this.Close();
        }


        private void specKeys_Click(object sender, EventArgs e)
        {
            vncDesktop1.SendSpecialKeys(SpecialKeys.CtrlAltDel);
            
        }

        private void fullscreen_Click(object sender, EventArgs e)
        {

            
            //vncDesktop1.FullScreenUpdate();
        }


    }
}
