using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using RDP;
using System.IO;
using SmartRDP_v1._0._0.Properties;


namespace SmartRDP_v1._0._0
{
    public partial class SmartRDP : Form
    {

        private readonly MainWindow1 mWindow1;
        public SmartRDP(MainWindow1 mWindow)
        {
            InitializeComponent();

            mWindow1 = mWindow;
        }

        public DataTable dt1 = new DataTable();
        rdpItem item;
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteGroups = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public int u;

        string dateTime;
        private void SmartRDP_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            ShowRDP();

            button1.UseMnemonic = false;
            //button1.Text = "Save & Connect";

            LoadRecentlyData();
            LoadGroupsToCombobox();

           
    
        }
        public void GetPassword()
        {
            remoteUsers.Open();
            string query3 = "SELECT userPassword FROM " + RdpConstant.tableBookmarks + "" +
                " WHERE hostAlias='" + rdpBookmarks.aliasStored + "' AND ipAddress='" + rdpBookmarks.ipStored + "'AND userName='" + rdpBookmarks.userStored + "'AND userGroup='" + rdpBookmarks.groupNameStored + "'AND connectionType='" + rdpBookmarks.connectionTypeStored + "'";


            SqlCommand command3 = new SqlCommand(query3, remoteUsers);
            SqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {

                _userPassword = reader3["userPassword"].ToString();

            }
            remoteUsers.Close();
        }
        public string connectionType1;

        private void LoadGroupsToCombobox()
        {
            

            remoteGroups.Open();

            String query = "SELECT groupName FROM " + RdpConstant.tableGroups + " WHERE groupType = '" + connectionType1 + "'";

            SqlCommand cmd = new SqlCommand(query, remoteGroups);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
            }
            remoteGroups.Close();
        }
        public void LoadRecentlyData()
        {
           
            remoteUsers.Open(); 
             String query = "SELECT id, hostAlias, ipAddress, userName, userPassword FROM "+ RdpConstant.tableRecently +" ORDER BY id DESC";

            SqlCommand cmd = new SqlCommand(query, remoteUsers);
            SqlDataReader dr = cmd.ExecuteReader();
            
             while (dr.Read())
             {

                        item = new rdpItem();

                        item.hostNameStored = dr["hostAlias"].ToString();
                        item.ipAddressStored = dr["ipAddress"].ToString();
                        item.userNameStored = dr["userName"].ToString();
                        item.userPasswordStored = dr["userPassword"].ToString();
               
                

            }
            remoteUsers.Close();
                
            
        }
        
        
        public static string _server;
        public static string serverStored
        {
            get { return _server; }
            set { _server = value; }
        }public static string _alias;
        public static string aliasStored
        {
            get { return _alias; }
            set { _alias = value; }
        }public static string _userName;
        public static string userNameStored
        {
            get { return _userName; }
            set { _userName = value; }
        }public static string _userPassword;
        public static string userPasswordStored
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public static string _vncPort;
        public static string vncPortStored
        {
            get { return _vncPort; }
            set { _vncPort = value; }
        }//TCP
        public static string _serverTcp;
        private int _portTcp;

        public static string tcpServerStored
        {
            get { return _serverTcp; }
            set { _serverTcp = value; }
        }
        public static int _tcpPort;
        public static int tcpPortStored
        {
            get { return _tcpPort; }
            set { _tcpPort = value; }
        }
        //SSH
        string userAlias1;


        public void RDP_process()
        {
            /* _server = computerIp.Text; 
             _alias = rdpName.Text; 
             _userName = userName.Text;*/

            _server = UC_rdpConnect._server;
            _alias = UC_rdpConnect._alias;
            _userName = UC_rdpConnect._userName;
            _userPassword = RdpConstant._userPassword;


            var pwstr = BitConverter.ToString(DataProtection.ProtectData(Encoding.Unicode.GetBytes(_userPassword), "")).Replace("-", "");
            
            var rdpInfo = String.Format(File.ReadAllText(RdpConstant.templatePath), _server, _userName, pwstr);
            File.WriteAllText(RdpConstant.FilePath, rdpInfo);
            //File.Move(RdpConstant.FilePath, RdpConstant.rdpSavesFolder + rdpName.Text + @".rdp");
            _mstsc("mstsc " + RdpConstant.FilePath);



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
        public int clickCount = 0;
        public void connectIP()
        {

            try
            {
                InsertInto(RdpConstant.tableRecently);

                LoadRecentlyData();

                RDP_process();

                SaveCredentials();

                if(UC_rdpConnect.saveCredStored == true)
                {
                    remoteUsers.Open();

                    String query = "DELETE FROM " + RdpConstant.tableSaveCredentials + "";

                    SqlDataAdapter SDA = new SqlDataAdapter(query, remoteUsers);
                    SDA.SelectCommand.ExecuteNonQuery();

                    remoteUsers.Close();

                    InsertInto(RdpConstant.tableSaveCredentials);
                    //MessageBox.Show("truuu");
                }
                else if(UC_rdpConnect.saveCredStored == false)
                {
                    //MessageBox.Show("false");
                    return;
                }

            }
            catch
            {

            }
        }
        protected void insert()
        {
            try
            {
                    UpdateEventArgs args = new UpdateEventArgs();
                    UpdateEventHandler.Invoke(this, args);
               
            }
            catch// (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        public int textChangedCount;
        private void userPassword_TextChanged(object sender, EventArgs e)
        {

            textChangedCount++;
           
            
            //_userPassword = userPassword.Text;
            if (textChangedCount > 1) 
            {
              
                textChangedCount--;

             
                
                
            }
 
        }
        
        public void InsertInto(string table)
        {
           


                int UserIdExist;
                UserIdExist = 0;

                //dateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss ");
                dateTime = DateTime.Now.ToString(RdpConstant.dateFormat + " " + RdpConstant.timeFormat);
                SqlCommand checkUserAlias = new SqlCommand("SELECT COUNT(*) FROM " + table + " WHERE ( ipAddress = @computerIp AND userName = @userName )", remoteUsers);
                remoteUsers.Open();
                checkUserAlias.Parameters.AddWithValue("@computerIp", UC_rdpConnect.ipStored);//computerIp.Text);
                checkUserAlias.Parameters.AddWithValue("@userName", UC_rdpConnect.userNameStored);//rdpName.Text);
                
                UserIdExist = (int)checkUserAlias.ExecuteScalar();
                remoteUsers.Close();

            
            if (UserIdExist > 0)
                {
                    remoteUsers.Open();
                    string queryy = "UPDATE " + table + " SET hostAlias=@hostAlias , userPassword=@userPassword, userGroup=@userGroup, connectionType=@conType, lastTimeConnected=@dateTime  WHERE ipAddress=@computerIp AND userName=@userName";
                    SqlCommand cmd = new SqlCommand(queryy, remoteUsers);

                    cmd.Parameters.AddWithValue("@computerIp", UC_rdpConnect.ipStored);//computerIp.Text);
                    cmd.Parameters.AddWithValue("@hostAlias", UC_rdpConnect.aliasStored);//userName.Text);
                    cmd.Parameters.AddWithValue("@userName", UC_rdpConnect.userNameStored);//userName.Text);
                    cmd.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword); //_userPassword);
                    cmd.Parameters.AddWithValue("@userGroup", UC_rdpConnect.groupNameStored);
                    cmd.Parameters.AddWithValue("@conType", "RDP");
                    cmd.Parameters.AddWithValue("@dateTime", dateTime);
                    cmd.ExecuteNonQuery();
                    remoteUsers.Close();
                    //UPDATE
                    //MessageBox.Show("Host name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (UserIdExist == 0)
                {

                    remoteUsers.Open();
                    string query1 = "INSERT INTO " + table + " (hostAlias, ipAddress, userName , userPassword, userGroup, connectionType, lastTimeConnected) VALUES ( @hostAlias, @computerIp, @userName, @userPassword, @userGroup, @connectionType, @dateTime)";

                    SqlCommand cmd1 = new SqlCommand(query1, remoteUsers);
                    //cmd1.Parameters.AddWithValue("@id", rdpName.Text);


                    cmd1.Parameters.AddWithValue("@hostAlias", UC_rdpConnect.aliasStored);//rdpName.Text);
                    cmd1.Parameters.AddWithValue("@computerIp", UC_rdpConnect.ipStored);//computerIp.Text);
                    cmd1.Parameters.AddWithValue("@userName", UC_rdpConnect.userNameStored);//userName.Text);
                    cmd1.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword); //_userPassword);
                    cmd1.Parameters.AddWithValue("@userGroup", UC_rdpConnect.groupNameStored);
                    cmd1.Parameters.AddWithValue("@connectionType", "RDP");
                    cmd1.Parameters.AddWithValue("@dateTime", dateTime);
                    cmd1.ExecuteNonQuery();

                  
                    remoteUsers.Close();

                   


                }

        }
        private void SaveCredentials()
        {
            
        }
        private void vncPort_Enter(object sender, EventArgs e)
        {
          //vncPort.ForeColor = Color.Black;
        }
        public static int _usersInGroupCount;
        public static int usersInGroupCountStored
        {
            get { return _usersInGroupCount; }
            set { _usersInGroupCount = value; }
        }
        rdpBookmarks rbk;

        private bool? isDialogTrue = null;

        private void SaveMachine()
        {
            try
            {
                SqlCommand checkUserAlias2 = new SqlCommand("SELECT COUNT(*) FROM " + RdpConstant.tableBookmarks + " WHERE (ipAddress = @computerIp) AND (userName = @userName) ", remoteUsers);
                remoteUsers.Open();
                checkUserAlias2.Parameters.AddWithValue("@computerIp", UC_rdpConnect.ipStored);
                checkUserAlias2.Parameters.AddWithValue("@userName", UC_rdpConnect.userNameStored);
                int UserIdExist2 = (int)checkUserAlias2.ExecuteScalar();
                remoteUsers.Close();

                //UPRAVIT ZÁZNAM
                if (UserIdExist2 > 0) //POKUD EXISTUJE ZÁZNAM
                {
                    DialogResult dialogResult = MessageBox.Show("Update existing connection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isDialogTrue = true;

                        remoteUsers.Open();
                        string queryy = "UPDATE " + RdpConstant.tableBookmarks + " SET hostAlias=@hostAlias, userPassword=@userPassword, userGroup=@userGroup, connectionType=@conType  WHERE ipAddress =  '" + UC_rdpConnect.ipStored + "' AND userName = '" + UC_rdpConnect.userNameStored + "' ";
                        SqlCommand cmd = new SqlCommand(queryy, remoteUsers);
                        cmd.Parameters.AddWithValue("@hostAlias", UC_rdpConnect.aliasStored);
                        cmd.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword);
                        cmd.Parameters.AddWithValue("@userGroup", UC_rdpConnect.groupNameStored);
                        cmd.Parameters.AddWithValue("@conType", "RDP");
                        cmd.ExecuteNonQuery();
                        remoteUsers.Close();


                        //DIALOG Save already exists, do u want to update?
                        //MessageBox.Show("Host name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;


                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        isDialogTrue = false;
                        return;
                    }
                }
                else if (UserIdExist2 == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Add connection to bookmarks?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isDialogTrue = true;

                        remoteUsers.Open();
                        string query1 = "INSERT INTO " + RdpConstant.tableBookmarks + " (hostAlias, ipAddress, userName , userPassword,userGroup, connectionType) VALUES ( @hostAlias, @computerIp, @userName, @userPassword, @userGroup, @connectionType)";

                        SqlCommand cmd1 = new SqlCommand(query1, remoteUsers);
                        cmd1.Parameters.AddWithValue("@hostAlias", UC_rdpConnect.aliasStored);
                        cmd1.Parameters.AddWithValue("@computerIp", UC_rdpConnect.ipStored);
                        cmd1.Parameters.AddWithValue("@userName", UC_rdpConnect.userNameStored);
                        cmd1.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword);
                        cmd1.Parameters.AddWithValue("@userGroup", UC_rdpConnect.groupNameStored);
                        cmd1.Parameters.AddWithValue("@connectionType", "RDP");


                        cmd1.ExecuteNonQuery();

                        remoteUsers.Close();







                        var pwstr = BitConverter.ToString(DataProtection.ProtectData(Encoding.Unicode.GetBytes(_userPassword), "")).Replace("-", "");
                        var rdpInfo = String.Format(File.ReadAllText(RdpConstant.templatePath), _server, _userName, pwstr);
                        File.WriteAllText(RdpConstant.FilePath, rdpInfo);
                        //ULOŽÍ JEDNOTLIVÉ RDP PŘIPOJENÍ DO SLOŽKY
                        //File.Move(RdpConstant.FilePath, RdpConstant.rdpSavesFolder + rdpName.Text + @".rdp");

                        //ULOŽÍ POUZE 1 RDP PŘIPOJENÍ
                        File.Move(RdpConstant.FilePath, RdpConstant.rdpSavesFolder);

                        //PŘEJMENOVAT RDP KLIENTA

                        //UPDATUJE POČET UŽIVATELŮ SE SKUPINOU X




                    }
                    else
                    {
                        isDialogTrue = false;
                        return;
                    }
                }

                if (rbk != null)
                {
                    rbk = new rdpBookmarks(null);
                    rbk.LoadToBookmarks();
                }
            }
            catch (Exception ex)
            {
            }
            insert();
        }
        bool bookmarksOpened = false;

        public static bool _connectBTNClicked = false;
        public static bool connectBTNClickedStored
        {
            get { return _connectBTNClicked; }
            set { _connectBTNClicked = value; }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (rdpPanel.Visible)
            {
                _connectBTNClicked = true;

                bookmarksOpened = false;
                connectIP();

                insert();
            }else if(vncPanel.Visible)
            {
                VNC_Viewer vNC_Viewer = new VNC_Viewer(null);
                vNC_Viewer.Show();
            }
            /*if (mWindow1 != null)
            {
                mWindow1.test();
            }*/

        }
        private void saveNQuitBTN_Click(object sender, EventArgs e)
        {
            _connectBTNClicked = false;
            SaveMachine();

            if (isDialogTrue == true)
            {


                Form fc = Application.OpenForms["rdpBookmarks"];
                if (fc != null)
                {
                    fc.Close();
                    rdpBookmarks rdBooks = new rdpBookmarks(null);
                    rdBooks.Owner = mWindow1;
                    rdBooks.Show();
                }
                this.Close();
            }
            else { return; }
            isDialogTrue = null;



        }
        private void saveBTN_Click(object sender, EventArgs e)
        {
            _connectBTNClicked = false;
            SaveMachine();
            if (isDialogTrue == true)
            {
                //rBookmarks1.LoadToBookmarks();

                Form fc = Application.OpenForms["rdpBookmarks"];
                if (fc != null)
                {
                    fc.Close();
                    rdpBookmarks rdBooks = new rdpBookmarks(null);
                    rdBooks.Owner = mWindow1;
                    rdBooks.Show();
                    //rdBooks.SendToBack();
                    this.BringToFront();
                }
            }
            else { return; }
            isDialogTrue = null;

        }


        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);

        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }

        }


        

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string comboSelectedGroup;

        private void SmartRDP_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow1.flag = 0;
        }

        private void SmartRDP_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                MainWindow1.flag = 0;
            }
        }

        UC_rdpConnect rdpPanel = new UC_rdpConnect();
        private void ShowRDP()
        {

            //panel6.Controls.Clear();
            vncPanel.Hide();
            rdpPanel.Dock = DockStyle.Fill;
            rdpPanel.Show();
            activeHeaderText.Text = "Remote Desktop Protocol";
            panel6.Controls.Add(rdpPanel);


        }

        UC_vncConnect vncPanel = new UC_vncConnect();
        private void ShowVNC()
        {

            //panel6.Controls.Clear();
            rdpPanel.Hide();
            vncPanel.Dock = DockStyle.Fill;
            vncPanel.Show();
            activeHeaderText.Text = "Virtual Network Computing";
            panel6.Controls.Add(vncPanel);
        }

        private void rdpBTN_Click(object sender, EventArgs e)
        {
            ShowRDP();
        }

        private void vncBTN_Click(object sender, EventArgs e)
        {
            ShowVNC();
        }
        private void SmartRDP_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
               
                
            }
        }


    }
}
