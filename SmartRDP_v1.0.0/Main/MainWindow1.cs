using RDP;
using SmartRDP_v1._0._0.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SmartRDP_v1._0._0
{
    
    public partial class MainWindow1 : Form
    {
        //private readonly UC_vncConnect uC_VncConnect;
        public MainWindow1()
        {
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            InitializeComponent();


            pictureBox1.MouseEnter += new EventHandler(buttonLayout1_MouseEnter);
            pictureBox1.MouseLeave += new EventHandler(buttonLayout1_MouseLeave);
            
            pictureBox2.MouseEnter += new EventHandler(buttonLayout2_MouseEnter);
            pictureBox2.MouseLeave += new EventHandler(buttonLayout2_MouseLeave);

        }
        public System.Data.DataTable dt1 = new System.Data.DataTable();
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteGroups = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");


        

        ToolStripMenuItem groupsItem, showItem, hideItem, exitItem;//, subgroupsItem, subgroupsItem2; //Tray Icon
        ToolStripMenuItem[] groupsSubMenu, usersSubMenu;

        
        ToolStripMenuItem connectItem, openItem, deleteItem;
        

        String[] userSubMenuCreds;

        #region STATIC_VARIABLES
        public static string _alias;
        public static string aliasStored
        {
            get { return _alias; }
            set { _alias = value; }
        }
        public static string _ip;
        public static string ipStored
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public static string _userName;
        public static string userNameStored
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public static string _userPassword;
        public static string userPasswordStored
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }
        public static string _groupName;
        public static string groupNameStored
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
        public static string _connectionType;
        public static string connectionTypeStored
        {
            get { return _connectionType; }
            set { _connectionType = value; }
        }
        #endregion
        
        private volatile bool isPaused;
        public void PauseTcpTask()
        {
            isPaused = true;
        }

        public void ResumeTcpTask()
        {
            isPaused = false;
        }


        public Button NewConBTN; 
        public Button BookmarksBTN; //Acess new con form from bookmarks

        public void runInShowMode(bool state)
        {
            if (state == true)
            {
                //ResumeTcpTask();
                if (!backgroundWorker1.IsBusy)
                {
                    
                    backgroundWorker1.RunWorkerAsync();
                }

                RdpConstant.GridSettings(dgv_latest);

                LoadLatestConnections();

                statusColumn();

                dgv_latest.ReadOnly = true;

                if (dgv_latest.Rows.Count > 0)
                    dgv_latest.CurrentRow.Cells[0].Selected = true;
                dgv_latest.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;//Color.Silver;

                dgv_latest.GridColor = Color.LightGray;
                dgv_latest.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                dgv_latest.Columns[0].Width = 10;
                dgv_latest.Columns[1].Width = 10;
                dgv_latest.Columns[2].Width = 10;
                dgv_latest.Columns[3].Width = 10;
                dgv_latest.Columns[4].Width = 10;
                dgv_latest.Columns[5].Width = 10;
                dgv_latest.Columns[6].Width = 60;
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                {
                    return;
                    //PauseTcpTask();
                    //backgroundWorker1.CancelAsync();
                }
            }
        }
        private void MainWindow1_Load(object sender, EventArgs e)
        {
            dateToday = DateTime.Today.ToString("dd.MM. yyyy");

            //MessageBox.Show(dateToday);
            NewConBTN = new Button(); //Creates instance for button
            NewConBTN.Click += new EventHandler(buttonLayout1_Click); //Add event to create new form 

            LoadTrayMenu();

            panel4.BackColor = Color.Gainsboro;
            panel5.BackColor = Color.Gainsboro;
            panel6.BackColor = Color.Gainsboro;
            panel7.BackColor = Color.Gainsboro;


            //pingMachinesLoop(); //ping machines every 10 seconds


            runInShowMode(false);








        }
        PictureBox[] statusImage;
        string userAlias1;


        public void LoadTrayMenu()
        {
            #region TrayMenu
            trayIcon1.ContextMenuStrip.Items.Clear();

            groupsItem = new ToolStripMenuItem();
            groupsItem.Text = "Groups";
            trayIcon1.ContextMenuStrip.Items.Add(groupsItem);



            showItem = new ToolStripMenuItem();
            showItem.Text = "Show";
            showItem.Click += showTrayMenuItem_Click;
            trayIcon1.ContextMenuStrip.Items.Add(showItem);


            hideItem = new ToolStripMenuItem();
            hideItem.Text = "Hide";
            hideItem.Click += hideTrayMenuItem_Click;
            trayIcon1.ContextMenuStrip.Items.Add(hideItem);

            exitItem = new ToolStripMenuItem();
            exitItem.Text = "Exit";
            exitItem.Click += ExitTrayMenuItem_Click;
            trayIcon1.ContextMenuStrip.Items.Add(exitItem);

            groupsSubMenu = new ToolStripMenuItem[RdpConstant.maxGroups];

            usersSubMenu = new ToolStripMenuItem[RdpConstant.maxUsers];

            userSubMenuCreds = new string[3];

            string groupName;
            i = 0;

            remoteUsers.Open();
            String query = "SELECT groupName, groupColor FROM " + RdpConstant.tableGroups + " ORDER BY groupName ASC";
            SqlCommand cmd = new SqlCommand(query, remoteUsers);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                groupsSubMenu[i] = new ToolStripMenuItem();
                groupsSubMenu[i].Name = "groupSubMenuItem" + i.ToString();
                //groupsMenu[i].Tag = "specialDataHere";
                groupsSubMenu[i].Text = dr["groupName"].ToString();

                if (!String.IsNullOrEmpty(dr["groupColor"].ToString()))
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dr["groupColor"]);
                    MemoryStream mem = new MemoryStream(data);
                    groupsSubMenu[i].Image = Image.FromStream(mem);
                }
                //groupsMenu[i].Click += new EventHandler(MenuItemClickHandler);
                if (groupsSubMenu[i].Text == "<All>" || groupsSubMenu[i].Text == "<None>")
                {
                    continue; //?
                }
                else
                {
                    groupsItem.DropDownItems.Add(groupsSubMenu[i]);
                }
                i++;
            }
            remoteUsers.Close();

            int j = 0;
            for (int k = 0; k < i; k++)
            {
                remoteUsers.Open();
                string query1 = "SELECT hostAlias, ipAddress, userName, userPassword FROM " + RdpConstant.tableBookmarks + " WHERE userGroup='" + groupsSubMenu[k].Text + "' ORDER BY hostAlias ASC";
                SqlCommand cmd2 = new SqlCommand(query1, remoteUsers);
                SqlDataReader dr2 = cmd2.ExecuteReader();


                while (dr2.Read())
                {
                    _ip = dr2["ipAddress"].ToString();
                    _userName = dr2["userName"].ToString();
                    _userPassword = dr2["userPassword"].ToString();

                    usersSubMenu[j] = new ToolStripMenuItem();
                    usersSubMenu[j].Image = Resources.rdpIcon2;
                    //usersSubMenu[j].Image.Width(5);
                    usersSubMenu[j].Name = "userSubMenuItem" + j.ToString();
                    //groupsMenu[j].Tag = "specialDataHere";
                    usersSubMenu[j].Text = dr2["hostAlias"].ToString();

                    usersSubMenu[j].Click += new EventHandler(TrayConnect_Click);

                    groupsSubMenu[k].DropDownItems.Add(usersSubMenu[j]);



                    j++;
                }
                remoteUsers.Close();
            }
            #endregion
        }
        public void TrayConnect_Click(object sender, EventArgs e)
        {

            userAlias1 = ((ToolStripMenuItem)sender).Text;

            //SmartRDP._connectBTNClicked = false;
            remoteUsers.Open();
            string query2 = "SELECT ipAddress, userName, userPassword FROM " + RdpConstant.tableBookmarks + " WHERE hostAlias='" + userAlias1 + "'";
            SqlCommand cmd3 = new SqlCommand(query2, remoteUsers);
            SqlDataReader dr3 = cmd3.ExecuteReader();


            while (dr3.Read())
            {
                RdpConstant._server = dr3["ipAddress"].ToString();
                RdpConstant._userName = dr3["userName"].ToString();
                RdpConstant._userPassword = dr3["userPassword"].ToString();


            }
            remoteUsers.Close();

            var pwstr = BitConverter.ToString(DataProtection.ProtectData(Encoding.Unicode.GetBytes(RdpConstant._userPassword), "")).Replace("-", "");
            var rdpInfo = String.Format(File.ReadAllText(RdpConstant.templatePath), RdpConstant._server, RdpConstant._userName, pwstr);
            File.WriteAllText(RdpConstant.FilePath, rdpInfo);
            //File.Move(RdpConstant.FilePath, RdpConstant.rdpSavesFolder + rdpName.Text + @".rdp");
            RdpConstant._mstsc("mstsc " + RdpConstant.FilePath);

            //rd.InsertInto(RdpConstant.tableRecently);

            //rd.LoadRecentlyData();

        }
        private void LoadLastSavedCred()
        {
            remoteUsers.Open();
            string query2 = "SELECT hostAlias, ipAddress, userName, userPassword, userGroup FROM " + RdpConstant.tableSaveCredentials + "";

            SqlCommand command = new SqlCommand(query2, remoteUsers);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    
                        RdpConstant._alias = reader["hostAlias"].ToString();
                        RdpConstant._server = reader["ipAddress"].ToString();
                        RdpConstant._userName = reader["userName"].ToString();
                        RdpConstant._userPassword = reader["userPassword"].ToString();
                        RdpConstant._groupName = reader["userGroup"].ToString();
                    
                       
                    
                    //MessageBox.Show(UC_rdpConnect.saveCredStored.ToString());
                }
                else
                {
                    //LoadGroupsToCombobox("<None>");

                   /* RdpConstant._alias = "";
                    RdpConstant._server = "";
                    RdpConstant._userName = "";
                    RdpConstant._userPassword = "";
                    RdpConstant._groupName = "";*/

                }
            }
            remoteUsers.Close();


        }

        DataGridViewImageColumn col;
        DataGridViewCell cell;
        public void statusColumn()
        {
            statusImage = new PictureBox[dgv_latest.Rows.Count];
            clientsLastConnect = new string[dgv_latest.Rows.Count];

            //statusImageControl = new Label[dgv_latest.Rows.Count];

            //ttStatus  = new ToolTip[dgv_latest.Rows.Count];

            col = new DataGridViewImageColumn();
            col.ImageLayout = DataGridViewImageCellLayout.Normal;
            col.Name = "status";
            col.HeaderText = "Status";
            col.Image = RdpConstant.statusTrying;
            dgv_latest.Columns.Insert(6, col);
            col.Width = 25;

            foreach (DataGridViewRow row in dgv_latest.Rows)
            {
                cell = this.dgv_latest.Rows[row.Index].Cells[6];
                cell.ToolTipText = "Trying connection..";
            }
        }
      
        int i;
        string[] clientsLastConnect;
        string dateToday;
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //int i = 0; //Cancel test
            //if(isPaused == true)
            //{
                foreach (DataGridViewRow row in dgv_latest.Rows)
                {


                    PictureBox picture = new PictureBox();
                    statusImage[row.Index] = picture;
                    statusImage[row.Index].Name = "status" + row.Index;
                    statusImage[row.Index].BackgroundImageLayout = ImageLayout.Zoom;

                    string hostname = dgv_latest.Rows[row.Index].Cells[1].Value.ToString();
                    int port = 3389;

                    System.Net.IPAddress ipAddress = null;

                    bool isValidIp = System.Net.IPAddress.TryParse(hostname, out ipAddress);

                    cell = this.dgv_latest.Rows[row.Index].Cells[6];

                    if (isValidIp)
                    {
                        ipAddress = (IPAddress)Dns.GetHostAddresses(hostname)[0];
                    }
                    else
                    {
                        cell.ToolTipText = "Unknown IP Address entry." + clientsLastConnect[row.Index];
                    }

                    TcpClient client = null;
                    try
                    {


                        client = new TcpClient();
                        var task = client.ConnectAsync(hostname, port);
                        if (task.Wait(RdpConstant.connectTestAfter))
                        {
                            if (client.Connected)
                            {
                                statusImage[row.Index].Image = RdpConstant.statusOnline;
                                cell.ToolTipText = "Online\nPort 3389 is open.";

                                clientsLastConnect[row.Index] = DateTime.Now.ToString(RdpConstant.dateFormat + (" ") + RdpConstant.timeFormat);
                                if (dateToday == DateTime.Now.ToString("dd.MM. yyyy"))
                                {
                                    clientsLastConnect[row.Index] = "Today at " + DateTime.Now.ToString(RdpConstant.timeFormat);
                                    //i++;
                                    //Console.WriteLine("canceled" + i.ToString());
                                }
                            }
                            else
                            {
                                statusImage[row.Index].Image = RdpConstant.statusOffline;

                                //clientConnected[row.Index] = false;
                            }
                        }
                        else
                        {

                            statusImage[row.Index].Image = RdpConstant.statusOffline;
                            cell.ToolTipText = "Offline\n Last activity: " + clientsLastConnect[row.Index];


                        }
                        dgv_latest.Rows[row.Index].Cells[6].Value = statusImage[row.Index].Image;
                        statusImage[row.Index].Visible = true;




                    }
                    catch (Exception ex)
                    {
                        // connection failed
                    }
                    finally
                    {
                        client.Close();
                    }

                    /*Ping p = new Ping();
                    PingReply r;
                    try
                    {
                        foreach (DataGridViewRow row in dgv_latest.Rows)
                        {
                            r = p.Send(dgv_latest.Rows[row.Index].Cells[1].Value.ToString()); //25 sekund delay
                            PictureBox picture = new PictureBox();
                            statusImage[row.Index] = picture;
                            //statusImage[row.Index].Name = "status" + row.Index;
                            //statusImage[row.Index].BackgroundImageLayout = ImageLayout.Zoom;
                            statusImage[row.Index].Image = RdpConstant.statusTrying;
                            //MessageBox.Show(r.Status.ToString());

                            if (r.Status == IPStatus.Success)
                            {

                                statusImage[row.Index].Image = RdpConstant.statusOnline;

                            }
                            else //if(r.Status == IPStatus.DestinationHostUnreachable || r.Status == IPStatus.TimedOut)
                            {

                                statusImage[row.Index].Image = RdpConstant.statusOffline;

                            }
                            dgv_latest.Rows[row.Index].Cells[6].Value = statusImage[row.Index].Image;
                        }
                    }
                    catch
                    {

                    }
                    */
                    /*}
                    else
                    {
                        return;
                    }*/
                }



            }



            /*bool ttt = false;
            public async Task pingMachinesLoop()
            {

                ttt = true;
                while (ttt)
                {

                    var delayTask = Task.Delay(RdpConstant.pingMachinesAfterSeconds * 1000);

                        //backgroundWorker1.RunWorkerAsync();

                    await delayTask; // wait until at least 10s elapsed since delayTask created

                }
            }*/

            public void UpdateEventHandler1(object sender, SmartRDP.UpdateEventArgs args)
        {
            if (SmartRDP.connectBTNClickedStored == true)
            {

                backgroundWorker1.CancelAsync();


                //if (backgroundWorker1.IsBusy == true)

                dgv_latest.Columns.Clear();
                LoadLatestConnections();
                statusColumn();
                dgv_latest.Columns[0].Width = 10;
                dgv_latest.Columns[1].Width = 10;
                dgv_latest.Columns[2].Width = 10;
                dgv_latest.Columns[3].Width = 10;
                dgv_latest.Columns[4].Width = 10;
                dgv_latest.Columns[5].Width = 10;
                dgv_latest.Columns[6].Width = 60;
                backgroundWorker1.RunWorkerAsync();
                dgv_latest.Refresh();
                //i = 0;
                //ttt = true;
                //}
                SmartRDP._connectBTNClicked = false;
            }
            else
            {
                return;
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         
            backgroundWorker1.RunWorkerAsync();
            //MessageBox.Show("test");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show("test");
        }
        public void LoadLatestConnections()
        {
            dgv_latest.Columns.Clear();
            //Thread.Sleep(1000);
            //dgv_latest.Rows.Clear();
            
            remoteUsers.Open();
            string query1 = "SELECT hostAlias as 'Alias', ipAddress as 'Ip', userName as 'User', userGroup as 'Group', connectionType as 'Type', lastTimeConnected as 'Last try' FROM " + RdpConstant.tableRecently + " ORDER BY lastTimeConnected DESC";


              SqlDataAdapter SDA1 = new SqlDataAdapter(query1, remoteUsers);
            dt1 = new System.Data.DataTable();
            SDA1.Fill(dt1);

            dgv_latest.DataSource = dt1;

           
            remoteUsers.Close();

            


        }
        private void dgv_latest_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgv_latest.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

        }

        SmartRDP newConn;
        public static int flag = 0;
        private void buttonLayout1_Click(object sender, EventArgs e)
        {
            
            try
            {

                //iterate through
                if (flag == 0)
                {
                    //bFormNameOpen = true;
                    newConn = new SmartRDP(this);
                    newConn.UpdateEventHandler += UpdateEventHandler1;
                    newConn.StartPosition = FormStartPosition.CenterScreen;
                    newConn.Show();
                    flag++;
                }
                else if(flag >= 1)
                {
                    
                    newConn.Activate();
                    //newConn.UpdateEventHandler += UpdateEventHandler1;
                    //flag = 0;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        private void buttonLayout2_Click(object sender, EventArgs e)
        {
            Groups groups = new Groups(this);
            //groups.UpdateEventHandler += UpdateEventHandler1;
            groups.Show(this);
            
        }
        private void buttonLayout3_Click(object sender, EventArgs e) //BOOKMARKS
        {
            //button1_Click(this.button1, e);
            rdpBookmarks bookmarks = new rdpBookmarks(this);
            bookmarks.Show(this);
        }
        private void buttonLayout1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image image = Resources.conIcon3_focus;
            pictureBox1.BackgroundImage = image;
        }
        private void buttonLayout2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image image = Resources.groupsIcon3_focus;
            pictureBox2.BackgroundImage = image;
            
        }
        private void buttonLayout3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image image = Resources.bookmarkIcon3_3_focus;
            pictureBox3.BackgroundImage = image;
        }
        private void buttonLayout4_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image image = Resources.optionsIcon1_focus;
            pictureBox4.BackgroundImage = image;
        }


        private void buttonLayout1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            Image image = Resources.conIcon3;
            pictureBox1.BackgroundImage = image;
        }
        private void buttonLayout2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            Image image = Resources.groupsIcon3;
            pictureBox2.BackgroundImage = image;
        }
        private void buttonLayout3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            Image image = Resources.bookmarkIcon3_3;
            pictureBox3.BackgroundImage = image;
        }
        private void buttonLayout4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            Image image = Resources.optionsIcon1;
            pictureBox4.BackgroundImage = image;
        }

        private void trayIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTray(true);
        }

        private void MainWindow1_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon1.Visible = true;

            }
        }
        public void RDP_process()
        {
          /*  _server = computerIp.Text;
            _alias = rdpName.Text;
            _userName = userName.Text;

            */
            var pwstr = BitConverter.ToString(DataProtection.ProtectData(Encoding.Unicode.GetBytes(RdpConstant._userPassword), "")).Replace("-", "");
            var rdpInfo = String.Format(File.ReadAllText(RdpConstant.templatePath), RdpConstant._server, RdpConstant._userName, pwstr);
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
        

        public int index;
        string dateTime;
        private void dgv_latest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //SmartRDP rdpp = new SmartRDP(this);
                //rdpp.Show();

                dateTime = DateTime.Now.ToString(RdpConstant.dateFormat + " " + RdpConstant.timeFormat);

                RdpConstant._alias = dgv_latest.Rows[e.RowIndex].Cells[0].Value.ToString();
                RdpConstant._server = dgv_latest.Rows[e.RowIndex].Cells[1].Value.ToString();
                RdpConstant._userName = dgv_latest.Rows[e.RowIndex].Cells[2].Value.ToString();
                RdpConstant._groupName = dgv_latest.Rows[e.RowIndex].Cells[3].Value.ToString();
                RdpConstant._conType = dgv_latest.Rows[e.RowIndex].Cells[4].Value.ToString();

                remoteUsers.Open();
                string queryy = "UPDATE " + RdpConstant.tableRecently + " SET hostAlias=@hostAlias , userPassword=@userPassword, userGroup=@userGroup, connectionType=@conType, lastTimeConnected=@dateTime  WHERE ipAddress=@computerIp AND userName=@userName";
                SqlCommand cmd = new SqlCommand(queryy, remoteUsers);

                cmd.Parameters.AddWithValue("@computerIp", RdpConstant.ipStored);//computerIp.Text);
                cmd.Parameters.AddWithValue("@hostAlias", RdpConstant.aliasStored);//userName.Text);
                cmd.Parameters.AddWithValue("@userName", RdpConstant.userNameStored);//userName.Text);
                cmd.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword); //_userPassword);
                cmd.Parameters.AddWithValue("@userGroup", RdpConstant.groupNameStored);
                cmd.Parameters.AddWithValue("@conType", RdpConstant.conTypeStored);
                cmd.Parameters.AddWithValue("@dateTime", dateTime);
                cmd.ExecuteNonQuery();
                remoteUsers.Close();

                RDP_process();



            }
        }
        private void LoadFromDGV()
        {

            index = dgv_latest.Rows[dgv_latest.CurrentCell.RowIndex].Index;
            //MessageBox.Show(index.ToString());
            RdpConstant._alias = dgv_latest.Rows[index].Cells[0].Value.ToString();
            RdpConstant._server = dgv_latest.Rows[index].Cells[1].Value.ToString();
            RdpConstant._userName = dgv_latest.Rows[index].Cells[2].Value.ToString();
            //_password = dgv_bookmark.Rows[index].Cells[3].Value.ToString();
            RdpConstant._groupName = dgv_latest.Rows[index].Cells[3].Value.ToString();
            RdpConstant._conType = dgv_latest.Rows[index].Cells[4].Value.ToString();
            



            remoteUsers.Open();
            string query3 = "SELECT userPassword FROM " + RdpConstant.tableRecently + "" +
                " WHERE hostAlias='" + RdpConstant._alias + "' AND ipAddress='" + RdpConstant._server + "'AND userGroup='" + RdpConstant._groupName + "'AND userName='" + RdpConstant._userName + "'AND connectionType='" + RdpConstant._conType + "'";

            SqlCommand command3 = new SqlCommand(query3, remoteUsers);
            SqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                RdpConstant._userPassword = reader3["userPassword"].ToString();
            }
            remoteUsers.Close();


            if (_groupName != "<None>")
            {
                remoteGroups.Open();
                String query1 = "SELECT groupColor FROM " + RdpConstant.tableGroups + " WHERE groupName = '" + RdpConstant._groupName + "'";

                SqlCommand cmd2 = new SqlCommand(query1, remoteGroups);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dr2["groupColor"]);
                    MemoryStream mem = new MemoryStream(data);
                    RdpConstant._groupFlag = Image.FromStream(mem);

                }
                remoteGroups.Close();
            }
            else
            {
                RdpConstant._groupFlag = null;
            }


        }
        
        private void connectItemEvent(object sender, EventArgs e)
        {
            RDP_process();
        }
        private void openItemEvent(object sender, EventArgs e)
        {
            LoadFromDGV();

            RdpConstant.isOpenRDPStatementTrue = true;

            newConn = new SmartRDP(this);
            newConn.UpdateEventHandler += UpdateEventHandler1;
            newConn.Show(this);
        }
        int deleteId;
        private void deleteItemEvent(object sender, EventArgs e)
        {
            remoteUsers.Open();
            String query = "SELECT id FROM " + RdpConstant.tableRecently + " ORDER BY id DESC";
            SqlDataAdapter SDA1 = new SqlDataAdapter(query, remoteUsers);
            dt1 = new System.Data.DataTable(); //Tabulka pro vypsání Id z SQL
            SDA1.Fill(dt1);
            remoteUsers.Close();

            deleteId = Int32.Parse(dt1.Rows[dgv_latest.CurrentCell.RowIndex].ItemArray[0].ToString());
            MessageBox.Show(deleteId.ToString());
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the recent connections record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    remoteUsers.Open();
                    String query2 = "DELETE FROM " + RdpConstant.tableRecently + " WHERE id = " + deleteId + "";
                    SqlCommand command = new SqlCommand(query2, remoteUsers);
                    command.ExecuteNonQuery();
                    remoteUsers.Close();

                    deleteId = dgv_latest.CurrentCell.RowIndex;
                    dgv_latest.Rows.RemoveAt(deleteId);
                }
                catch
                {

                }
            }
            else
            {

            }
            /*LoadLatestConnections();
            statusColumn();
            dgv_latest.Columns[0].Width = 10;
            dgv_latest.Columns[1].Width = 10;
            dgv_latest.Columns[2].Width = 10;
            dgv_latest.Columns[3].Width = 10;
            dgv_latest.Columns[4].Width = 10;
            dgv_latest.Columns[5].Width = 10;
            dgv_latest.Columns[6].Width = 60;*/
        }
        private void dgv_latest_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgvRowIndex > -1)
            {
                var hti = dgv_latest.HitTest(e.X, e.Y);
                dgv_latest.ClearSelection();
                dgv_latest.Rows[hti.RowIndex].Selected = true;
            }
            LoadFromDGV();

        }

        private void dgv_latest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {




                LoadFromDGV();
                rClickMenu = new ContextMenuStrip();
                var connectItem = rClickMenu.Items.Add("Connect");
                var openItem = rClickMenu.Items.Add("Open");
                var deleteItem = rClickMenu.Items.Add("Delete");

                connectItem.Click += connectItemEvent;
                openItem.Click += openItemEvent;
                deleteItem.Click += deleteItemEvent;

                rClickMenu.Show(dgv_latest, e.Location.X, e.Location.Y); //X - 125
            }
        }
        private static int dgvRowIndex = 0;
        private void dgv_latest_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvRowIndex = e.RowIndex;
            if (e.RowIndex > -1)
            {
                
                //dgv_latest.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
            }
        }

        private void dgv_latest_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //LoadFromDGV();
        }

        private void dgv_latest_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        

        ContextMenuStrip rClickMenu;

        private void showTrayMenuItem_Click(object sender, EventArgs e)
        {
            ShowTray(true);
        }
        private void hideTrayMenuItem_Click(object sender, EventArgs e)
        {
            ShowTray(false);
        }
        private void ExitTrayMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        runInShowMode(false);
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void ShowTray(bool showState)
        {
            if (showState == true)
            {

                this.ShowInTaskbar = true;
                this.Opacity = 100;
                runInShowMode(true);
                this.Show();
                //trayIcon1.Visible = true;
                WindowState = FormWindowState.Normal;

            }
            else if (showState == false)
            {
                this.Hide();
                trayIcon1.Visible = true;
                //runInShowMode(false);
                //CANCELATION TOKEN

            }

        }
    }
}
