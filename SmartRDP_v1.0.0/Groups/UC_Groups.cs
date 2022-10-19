using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RDP;

namespace SmartRDP_v1._0._0
{
    public partial class UC_Groups : UserControl
    {
        private MainWindow1 main;
        public UC_Groups(MainWindow1 mainWindow1)
        {
            InitializeComponent();
            main = mainWindow1;
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            //this.Dock = DockStyle.Fill;
            
        }
        public DataTable dt1 = new DataTable();
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteGroups = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteGroups2 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        String query;
        SqlDataAdapter SDA1;


        private void UC_Groups_Load(object sender, EventArgs e)
        {
            LoadUserCount();
            LoadAllGroups();
            dgvGroups.Columns[4].DefaultCellStyle.Padding = new Padding(0, 0, 60, 0);
            //
            //selectedGroupShortcut = dgvGroups.Rows[0].Cells[1].Value.ToString();
            selectedGroupName = dgvGroups.Rows[0].Cells[1].Value.ToString();
            selectedGroupType = dgvGroups.Rows[0].Cells[3].Value.ToString();
            try
            {
                selectedGroupColor = (byte[])dgvGroups.Rows[0].Cells[4].Value;
                
            }
            catch
            {

            }
            
            dgvGroups.Rows[0].Selected = true;
            dgvGroups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvGroups.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.0F, FontStyle.Bold);
            dgvGroups.EnableHeadersVisualStyles = false;
            dgvGroups.ColumnHeadersHeight = 25;
            dgvGroups.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 151, 218); //52,151,218
            dgvGroups.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 151, 218); //52,151,218
            dgvGroups.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //52,151,218
            dgvGroups.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 215, 215);
            dgvGroups.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvGroups.DefaultCellStyle.Font = new Font("Tahoma", 9.0F, FontStyle.Regular);


        }
        private void LoadUserCount()
        {
            //POČET UŽIVATELŮ V JEDNOTLIVÝCH SKUPINÁCH
            string groupName;
            string userCount;
            remoteUsers.Open();
            String query = "SELECT groupName FROM " + RdpConstant.tableGroups + "";
            SqlCommand cmd = new SqlCommand(query, remoteUsers);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                groupName = dr["groupName"].ToString();

                remoteGroups.Open();
                if (groupName == "<All>")
                {
                     userCount = "SELECT COUNT(*) FROM " + RdpConstant.tableBookmarks + "";
                }
                else
                {
                     userCount = "SELECT COUNT(*) FROM " + RdpConstant.tableBookmarks + " WHERE userGroup = @userGroup";
                }
                SqlCommand command = new SqlCommand(userCount, remoteGroups);
                command.Parameters.AddWithValue("@userGroup", groupName);
                Int32 count = (Int32)command.ExecuteScalar();

                //MessageBox.Show(count.ToString());
                remoteGroups.Close();

                remoteGroups2.Open();

                string query3 = "UPDATE " + RdpConstant.tableGroups + " SET groupUserCount=@groupUserCount  WHERE groupName = '" + groupName + "'";
                SqlCommand cmd3 = new SqlCommand(query3, remoteGroups2);
                cmd3.Parameters.AddWithValue("@groupUserCount", count);
                cmd3.ExecuteNonQuery();
                remoteGroups2.Close();

            }
            remoteUsers.Close();
        }
        private void LoadAllGroups()
        {

            

            remoteGroups.Open();

            String query1 = "SELECT id, groupName as 'Group',groupShortcut as 'Shortcut', groupType as 'Type', groupColor as 'Flag', groupUserCount as 'Users' FROM " + RdpConstant.tableGroups + "";

            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, remoteGroups);
            DataTable dt1 = new DataTable();

            SDA1.Fill(dt1);
            dgvGroups.DataSource = dt1;
            remoteGroups.Close();
            remoteGroups.Open();
            String query2 = "SELECT * FROM " + RdpConstant.tableGroupUsers + "";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query2, remoteGroups);
            DataTable dt2 = new DataTable();
            SDA1.Fill(dt2);
            dgvGroups.DataSource = dt2;
            remoteGroups.Close();
            dgvGroups.Columns[0].Visible = false;
            //dgvGroups.Columns[1].Visible = false;

//ZAKÁŽE ZOBRAZOVÁNÍ ČERVENÝCH X V DATAGRIDVIEW POKUD BUDE HODNOTA BUŇKY NULL
            ((DataGridViewImageColumn)this.dgvGroups.Columns["Flag"]).DefaultCellStyle.NullValue = null;


        }
        private void addGroupBTN1_Click(object sender, EventArgs e)
        {
            selectedId = "";
            _gShortcut = "";
            _gName = "";
            _gType = "";
            _gImage = null;
            addGroup group = new addGroup();
            //group.UpdateEventHandler += UpdateEventHandler1;
            group.ShowDialog(this);
            LoadUserCount();
            LoadAllGroups();
            
            main.LoadTrayMenu();
        }
        public static string _gId;
        public static string gIdStored
        {
            get { return _gId; }
            set { _gId = value; }
        }public static string _gShortcut;
        public static string gShortcutStored
        {
            get { return _gShortcut; }
            set { _gShortcut = value; }
        }public static string _gName;
        public static string gNameStored
        {
            get { return _gName; }
            set { _gName = value; }
        }
        public static string _gType;
        public static string gTypeStored
        {
            get { return _gType; }
            set { _gType = value; }
        }
        public static byte[] _gImage;
        public static byte[] gImageStored
        {
            get { return _gImage; }
            set { _gImage = value; }
        }
        private void dgvGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _gId = selectedId;
            _gShortcut = selectedGroupShortcut;
            _gName = selectedGroupName;
            _gType = selectedGroupType;
            _gImage = selectedGroupColor;

            if (selectedGroupName != "<All>" && selectedGroupName != "<None>")
            {
                addGroup group = new addGroup();
                group.UpdateEventHandler += UpdateEventHandler1;
                group.ShowDialog(this);
                LoadUserCount();
                LoadAllGroups();
                main.LoadTrayMenu();
            }
            else
            {

            }
        }
        public void UpdateEventHandler1(object sender, addGroup.UpdateEventArgs args)
        {
      
            dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[1].Value = addGroup.groupNameStored;
            dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[2].Value = addGroup.groupTypeStored;
            dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[3].Value = addGroup.groupShortCutStored;
          
        }
        public static string selectedId;
        public static string selectedGroupShortcut;
        public static string selectedGroupName;
        public static string selectedGroupType;
        public static byte[] selectedGroupColor;
        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            selectedId = dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[0].Value.ToString();
            selectedGroupName = dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[1].Value.ToString();
            selectedGroupShortcut = dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[2].Value.ToString();
            selectedGroupType = dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[3].Value.ToString();
            try
            {
                selectedGroupColor = (byte[])dgvGroups.Rows[dgvGroups.CurrentCell.RowIndex].Cells[4].Value;
            }
            catch
            {

            }
        


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedGroupName != "<All>" && selectedGroupName != "<None>")
            {
                DialogResult dialogResult = MessageBox.Show("Delete this group?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //Smaže označenou skupinu
                    remoteGroups.Open();
                    String query2 = "DELETE FROM " + RdpConstant.tableGroups + " WHERE groupName = '" + selectedGroupName + "'";
                    SqlCommand command = new SqlCommand(query2, remoteGroups);
                    command.ExecuteNonQuery();
                    remoteGroups.Close();


                    //Projde všechny záznamy ve sloupci userGroup s filtrem selectedGroupName a pokud hodnota existuje vypíše ji
                    remoteUsers.Open();
                    String query = "SELECT userGroup FROM " + RdpConstant.tableBookmarks + " WHERE userGroup = '" + selectedGroupName + "'";
                    SqlCommand cmd = new SqlCommand(query, remoteUsers);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        //Updatuje všem uživatelům smazanou skupinu na "defaultGroup"
                        remoteGroups.Open();
                        string queryy = "UPDATE " + RdpConstant.tableBookmarks + " SET userGroup=@newGroup WHERE userGroup=@defaultGroup";
                        SqlCommand cmd2 = new SqlCommand(queryy, remoteGroups);
                        cmd2.Parameters.AddWithValue("@newGroup", RdpConstant.defaultGroup);
                        cmd2.Parameters.AddWithValue("@defaultGroup", selectedGroupName);
                        cmd2.ExecuteNonQuery();
                        remoteGroups.Close();
                        //MessageBox.Show(defaultGroup);
                    }
                    remoteUsers.Close();
                }
                else
                {

                }
                LoadUserCount();
                LoadAllGroups();
                main.LoadTrayMenu();
            }
            else { }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            _gId = selectedId;
            _gShortcut = selectedGroupShortcut;
            _gName = selectedGroupName;
            _gType = selectedGroupType;
            _gImage = selectedGroupColor;

            if (selectedGroupName != "<All>" && selectedGroupName != "<None>")
            {
                addGroup group = new addGroup();
                group.UpdateEventHandler += UpdateEventHandler1;
                group.ShowDialog(this);
                LoadUserCount();
                LoadAllGroups();
                main.LoadTrayMenu();
            }
            else
            {

            }
        }
    }
}
