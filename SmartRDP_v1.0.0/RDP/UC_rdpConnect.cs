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
using System.Data.SqlClient;
using System.IO;

namespace SmartRDP_v1._0._0
{
    public partial class UC_rdpConnect : UserControl
    {
        public UC_rdpConnect()
        {
            InitializeComponent();
        }
        public SqlConnection remoteGroups = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");


        public static string _server;
        public static string ipStored
        {
            get { return _server; }
            set { _server = value; }
        }
        public static string _alias;
        public static string aliasStored
        {
            get { return _alias; }
            set { _alias = value; }
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
        public static bool _saveCred;
        public static bool saveCredStored
        {
            get { return _saveCred; }
            set { _saveCred = value; }
        }
        private void UC_rdpConnect_Load(object sender, EventArgs e)
        {
            

            this.Dock = DockStyle.Fill;

            LoadGroupsToComboBox();

            LoadLastUser(RdpConstant.isOpenRDPStatementTrue);

            if (RdpConstant.isOpenRDPStatementTrue == true)
                userPassword.Text = "********";
            else { userPassword.Text = ""; }

            RdpConstant.isOpenRDPStatementTrue = false;


            rdpName.Text = RdpConstant.aliasStored;
            computerIp.Text = RdpConstant.ipStored;
            userName.Text = RdpConstant.userNameStored;
            //userPassword.Text = RdpConstant.userPasswordStored;

            _saveCred = saveCredCheck1.Checked;

            groupComboB1.SelectedItem = RdpConstant.groupNameStored;
            groupFlag1.Image = RdpConstant.groupFlagStored;

            //MessageBox.Show(RdpConstant.groupNameStored);
        }

        private void LoadLastUser(bool _isOpenRDPStatementTrue)
        {
            if (_isOpenRDPStatementTrue == true)
            {
                return;
            }
            else { 
                

                remoteUsers.Open();
                string query2 = "SELECT hostAlias, ipAddress, userName, userPassword, userGroup FROM " + RdpConstant.tableSaveCredentials + "";


                SqlCommand command = new SqlCommand(query2, remoteUsers);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    if (reader.HasRows)
                    {
                        RdpConstant.isOpenRDPStatementTrue = true;
                        saveCredCheck1.Checked = true;

                        RdpConstant._alias = reader["hostAlias"].ToString();
                        RdpConstant._server = reader["ipAddress"].ToString();
                        RdpConstant._userName = reader["userName"].ToString();
                        RdpConstant._userPassword = reader["userPassword"].ToString();

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




                        //_userPassword = reader["userPassword"].ToString();
                        //userPassword.Text = new String('●', 8);

                        if (groupComboB1.Items.Contains(reader["userGroup"].ToString()))
                        {
                            RdpConstant._groupName = reader["userGroup"].ToString();
                        }
                        else
                        {
                            RdpConstant._groupName = "<None>";
                        }
                    }
                    else
                    {
                        saveCredCheck1.Checked = false;

                        RdpConstant._alias = "";
                        RdpConstant._server = "";
                        RdpConstant._userName = "";
                        RdpConstant._userPassword = "";
                        RdpConstant._groupName = "<None>";

                    }
                }
                remoteUsers.Close();
            }

        }
        private void computerIp_TextChanged(object sender, EventArgs e)
        {
            _server = computerIp.Text;
        }

        private void rdpName_TextChanged(object sender, EventArgs e)
        {
            _alias = rdpName.Text;
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            _userName = userName.Text;
        }
        int textChangedCount;
        private void userPassword_TextChanged(object sender, EventArgs e)
        {
            textChangedCount++;
            this.userPassword.UseSystemPasswordChar = true;

            //_userPassword = userPassword.Text;
            if (textChangedCount > 1)
            {

                textChangedCount--;

                RdpConstant._userPassword = userPassword.Text;


            }
        }
        public void LoadGroupsToComboBox()
        {
            remoteGroups.Open();

            String query = "SELECT groupName FROM " + RdpConstant.tableGroups + " WHERE groupType = '" + "RDP" + "'";

            SqlCommand cmd = new SqlCommand(query, remoteGroups);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                groupComboB1.Items.Add(dr["groupName"]);
            }
            remoteGroups.Close();
        }
        private void groupComboB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _groupName = groupComboB1.SelectedItem.ToString();
            if (_groupName != "<None>")
            {
                remoteGroups.Open();
                String query1 = "SELECT groupColor FROM " + RdpConstant.tableGroups + " WHERE groupName = '" + _groupName + "'";

                SqlCommand cmd2 = new SqlCommand(query1, remoteGroups);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dr2["groupColor"]);
                    MemoryStream mem = new MemoryStream(data);
                    groupFlag1.Image = Image.FromStream(mem);

                }
                remoteGroups.Close();
            }
            else
            {
                groupFlag1.Image = null;
            }
        }

        private void saveCredCheck1_CheckedChanged(object sender, EventArgs e)
        {
            if (saveCredCheck1.Checked == true)
            {
                _saveCred = true;
            }
            else if (saveCredCheck1.Checked == false)
            {
                _saveCred = false;
            }
        }
    }
}
