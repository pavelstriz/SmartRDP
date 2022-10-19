using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using RDP;
using System.Security;
using System.IO;
using System.Collections.Generic;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
//using Excel = Microsoft.Office.Interop.Excel; //You have to create reference to this
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using SmartRDP_v1._0._0.Properties;

namespace SmartRDP_v1._0._0
{
    public partial class rdpBookmarks : Form
    {

        public static int _id;
        public static int idStored
        {
            get { return _id; }
            set { _id = value; }
        }
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
        public static string _user;
        public static string userStored
        {
            get { return _user; }
            set { _user = value; }
        }
        public static string _password;
        public static string passwordStored
        {
            get { return _password; }
            set { _password = value; }
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
        public static bool _rdpBookmarksBool = false;
        public static bool rdpBookmarksBoolStored
        {
            get { return _rdpBookmarksBool; }
            set { _rdpBookmarksBool = value; }
        }

        private readonly SmartRDP rDP;
        PictureBox[] deletePicture;
        Image img;

        int[] ColumnsToInclude = null;

        System.Windows.Forms.CheckBox checkb0;
        System.Windows.Forms.CheckBox checkb1;
        System.Windows.Forms.CheckBox checkb2;
        System.Windows.Forms.CheckBox checkb3;
        System.Windows.Forms.CheckBox checkb4;

        private MainWindow1 main;

        public rdpBookmarks( MainWindow1 mainWindow1)
        {
            InitializeComponent();

            main = mainWindow1;

            //this.rDP = SmartRDP;

            this.exportPB1.MouseDown += new MouseEventHandler(this.exportPB1_MouseDown);
            this.importPB1.MouseDown += new MouseEventHandler(this.importPB1_MouseDown);
            dgv_bookmark.CellClick += new DataGridViewCellEventHandler(cellClick);
        }
        public System.Data.DataTable dt1 = new System.Data.DataTable();
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");

        ToolTip toolInfo;
        private bool alowDelete = true;

        private void rdpBookmarks_Load(object sender, EventArgs e)
        {


            img = Resources.delete_record2_3;

            exportColCount.Text = "";
            importColCount.Text = "";


            ColumnsToInclude = new int[5];
            for (var i = 0; i < ColumnsToInclude.Length; i++)
            {
                ColumnsToInclude[i] = -1;
                // work with item here
            }


            columnsSelected = new int[5];
            toolInfo = new ToolTip();
       

            //exportPB1.Image = Properties.Resources.export1_4;
            dgv_bookmark.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, FontStyle.Bold);

            dgv_bookmark.EnableHeadersVisualStyles = false;
            dgv_bookmark.ColumnHeadersHeight = 25;
            dgv_bookmark.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 151, 218); //52,151,218 HEADER
            dgv_bookmark.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 151, 218); //52,151,218 HEADER
            dgv_bookmark.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //52,151,218

            dgv_bookmark.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 215, 215);
            dgv_bookmark.DefaultCellStyle.SelectionForeColor = Color.Black;


            

            LoadToBookmarks();
            

            dgv_bookmark.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_bookmark.ReadOnly = true;

            if(dgv_bookmark.Rows.Count > 0)
            dgv_bookmark.CurrentRow.Cells[0].Selected = true;

            dgv_bookmark.GridColor = Color.White;
            dgv_bookmark.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;


            dgv_bookmark.Columns[0].Width = 30;
            dgv_bookmark.Columns[1].Width = 25;
            dgv_bookmark.Columns[2].Width = 25;
            dgv_bookmark.Columns[3].Width = 30;
            dgv_bookmark.Columns[4].Width = 30;
            dgv_bookmark.Columns[5].Width = 10;
            dgv_bookmark.Columns[6].Width = 25;

            dgv_bookmark.Columns[0].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv_bookmark.Columns[1].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv_bookmark.Columns[2].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv_bookmark.Columns[3].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv_bookmark.Columns[4].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv_bookmark.Columns[5].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);



            foreach (var item in columnsSelected)
            {
                columnsSelected[item] = -1;
                //MessageBox.Show(columnsSelected[item].ToString());
            }
            dgv_bookmark.FirstDisplayedScrollingRowIndex = RdpConstant.bookmarksRowIndexStored;
            dgv_bookmark.Rows[RdpConstant.bookmarksRowIndexStored].Selected = true;
            //MessageBox.Show(RdpConstant.bookmarksRowIndexStored.ToString());
        }


        public int rowIndex;
        public int deleteId;

        public void GetPassword()
        {
            remoteUsers.Open();
            string query3 = "SELECT userPassword FROM " + RdpConstant.tableBookmarks + "" +
                " WHERE hostAlias='" + RdpConstant._alias + "' AND ipAddress='" + RdpConstant._server + "'AND userName='" + RdpConstant._userName + "'AND userGroup='" + RdpConstant._groupName + "'AND connectionType='" + RdpConstant._conType + "'";


            SqlCommand command3 = new SqlCommand(query3, remoteUsers);
            SqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {

                RdpConstant._userPassword = reader3["userPassword"].ToString();

            }
            remoteUsers.Close();
        }
        private void cellClick(object sender, EventArgs e)
        {
           


            //WHERE IP USER GROUPNAME CONNECTION TYPE

            index = dgv_bookmark.CurrentCell.RowIndex;
         
            _alias = dgv_bookmark.Rows[index].Cells[0].Value.ToString();
            _ip = dgv_bookmark.Rows[index].Cells[1].Value.ToString();
            _user = dgv_bookmark.Rows[index].Cells[2].Value.ToString();
            //_password = dgv_bookmark.Rows[index].Cells[3].Value.ToString();
            _groupName = dgv_bookmark.Rows[index].Cells[4].Value.ToString();
            _connectionType = dgv_bookmark.Rows[index].Cells[5].Value.ToString();
            try
            {
                GetPassword();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
       



            remoteUsers.Open();
            String query = "SELECT id FROM " + RdpConstant.tableBookmarks + "";

            SqlDataAdapter SDA1 = new SqlDataAdapter(query, remoteUsers);
            dt1 = new System.Data.DataTable(); //Tabulka pro vypsání Id z SQL
            SDA1.Fill(dt1);
            remoteUsers.Close();

            if (selectCol == false)
            {
                if (dgv_bookmark.CurrentCell.ColumnIndex == 6 && alowDelete == true)
                {
                    rowIndex = dgv_bookmark.CurrentCell.RowIndex;
                    try
                    {
                        deleteId = Int32.Parse(dt1.Rows[rowIndex].ItemArray[0].ToString());
                    }
                    catch { }
                    //MessageBox.Show(deleteId.ToString());
                    DialogResult dialogResult = MessageBox.Show("Delete connection from the bookmarks?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            remoteUsers.Open();
                            String query2 = "DELETE FROM " + RdpConstant.tableBookmarks + " WHERE id = " + deleteId + "";
                            SqlCommand command = new SqlCommand(query2, remoteUsers);
                            command.ExecuteNonQuery();
                            remoteUsers.Close();

                            deleteId = dgv_bookmark.CurrentCell.RowIndex;
                            dgv_bookmark.Rows.RemoveAt(deleteId);
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        
                    }

                }
                else
                {

                }
            }


        }
        public void LoadToBookmarks()
        {
            try
            {
                dgv_bookmark.Columns.Remove("image");
            }
            catch
            {

            }
            remoteUsers.Open();
            string query1 = "SELECT hostAlias as 'Alias', ipAddress as 'Ip', userName as 'User', userPassword as 'Password', userGroup as 'Group', connectionType as 'Type' FROM " + RdpConstant.tableBookmarks + " ORDER BY hostAlias ASC";

            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, remoteUsers);
            dt1 = new System.Data.DataTable();
            SDA1.Fill(dt1);
            dgv_bookmark.DataSource = dt1;
            foreach(DataGridViewRow row in dgv_bookmark.Rows)
            {
            dgv_bookmark.Rows[row.Index].Cells[3].Value = new String('●', 8);
            }
            remoteUsers.Close();

            DeleteRowBTN();


        }
        private void DeleteRowBTN()
        {
            
            deletePicture = new PictureBox[dgv_bookmark.Rows.Count];
            DataGridViewImageColumn col = new DataGridViewImageColumn();
            col.Name = "image";
            col.HeaderText = " ";

            dgv_bookmark.Columns.Insert(6, col);
            col.Width = 25;

            for (int i = 0; i < deletePicture.Length; i++)
            {
                var picture = new PictureBox();
                deletePicture[i] = picture;
                deletePicture[i].Name = "img" + i;
                deletePicture[i].Image = img;
                deletePicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                dgv_bookmark.Rows[i].Cells[6].Value = deletePicture[i].Image;

                deletePicture[i].Visible = true;
            }
        }



        public int firstColumnIndex;
        public int lastColumnIndex;
        int index;
        int[] selectedColumns = new int[1];



        private void removeAllBTN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete all connections?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                remoteUsers.Open();
                String query2 = "DELETE FROM " + RdpConstant.tableBookmarks + "";

                SqlCommand command = new SqlCommand(query2, remoteUsers);
                command.ExecuteNonQuery();
                remoteUsers.Close();
            }
            else
            {

            }
            LoadToBookmarks();
        }

        private void dgv_bookmark_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadToBookmarks();

            /*for (int i = 0; i < deletePicture.Length; i++)
            {
                var picture = new PictureBox();
                deletePicture[i] = picture;
                deletePicture[i].Name = "img" + i;
                deletePicture[i].Image = img;
                deletePicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                dgv_bookmark.Rows[i].Cells[4].Value = deletePicture[i].Image;

                deletePicture[i].Visible = true;
            }
            return;*/
        }
        int dcRowIndex;
        private void dgv_bookmark_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RdpConstant.isOpenRDPStatementTrue = true;

            RdpConstant._bookmarksRowIndex = dgv_bookmark.Rows[dgv_bookmark.CurrentCell.RowIndex].Index;
            
            if (e.RowIndex != -1 && editModeClickCount == 0 && selectCol != true )
            {
                _rdpBookmarksBool = true;

                
                RdpConstant._alias = dgv_bookmark.Rows[index].Cells[0].Value.ToString();
                RdpConstant._server = dgv_bookmark.Rows[index].Cells[1].Value.ToString();
                RdpConstant._userName = dgv_bookmark.Rows[index].Cells[2].Value.ToString();
                //_password = dgv_bookmark.Rows[index].Cells[3].Value.ToString();
                RdpConstant._groupName = dgv_bookmark.Rows[index].Cells[4].Value.ToString();
                RdpConstant._conType = dgv_bookmark.Rows[index].Cells[5].Value.ToString();

                GetPassword();


                MainWindow1 frm = (MainWindow1)this.Owner;
                SmartRDP sRDP;
                if (frm != null)
                {
                    frm.NewConBTN.PerformClick();
                    
                    //frm.Refresh();
                }
                
              


                    /*    SmartRDP sRDP;
                     sRDP = new SmartRDP(this);
                     sRDP.UpdateEventHandler += UpdateEventHandler1;
                     sRDP.Show();
                     */
                }
            
            //MessageBox.Show(editModeClickCount.ToString());
        }
        public void UpdateEventHandler1(object sender, SmartRDP.UpdateEventArgs args)
        {
            LoadToBookmarks();
        }



            int groupNameExist;
        private void saveEditBTN_Click(object sender, EventArgs e)
        {
            
            remoteUsers.Open();
            String query = "SELECT COUNT(*) FROM " + RdpConstant.tableBookmarks + "";
            SqlCommand cmd = new SqlCommand(query, remoteUsers);
            Int32 sqlCount = (Int32)cmd.ExecuteScalar();
            
            remoteUsers.Close();
            if (dgv_bookmark.Rows.Count > sqlCount)
            {
                //int result = (dgv_bookmark.Rows.Count - 1) - sqlCount;
                int result = dgv_bookmark.Rows.Count - 1;
                
                for (int i = result; i < dgv_bookmark.Rows.Count ; i++)
                {
           
                    remoteUsers.Open();
                    string query1 = "INSERT INTO " + RdpConstant.tableBookmarks + " ( hostAlias, ipAddress, userName, userPassword, userGroup, connectionType) VALUES (@hostAlias, @ipAddress, @userName, @userPassword, @userGroup, @connectionType)";

                    SqlCommand cmd2 = new SqlCommand(query1, remoteUsers);

                    cmd2.Parameters.AddWithValue("@hostAlias", dgv_bookmark.Rows[i].Cells[0].Value.ToString());
                    cmd2.Parameters.AddWithValue("@ipAddress", dgv_bookmark.Rows[i].Cells[1].Value.ToString());
                    cmd2.Parameters.AddWithValue("@userName", dgv_bookmark.Rows[i].Cells[2].Value.ToString());
                    cmd2.Parameters.AddWithValue("@userPassword", dgv_bookmark.Rows[i].Cells[3].Value.ToString());
                    cmd2.Parameters.AddWithValue("@userGroup", dgv_bookmark.Rows[i].Cells[4].Value.ToString()); //VYTVOŘIT COMBOBOX PRO PŘEPÍNÁNÍ 
                    cmd2.Parameters.AddWithValue("@connectionType", dgv_bookmark.Rows[i].Cells[5].Value.ToString());



                    //else if(UC_Groups.gImageStored == null)
                    //cmd1.Parameters.AddWithValue("@groupColor", DBNull.Value);

                    cmd2.ExecuteNonQuery();

                    remoteUsers.Close();
                }


            }else if (dgv_bookmark.Rows.Count <= sqlCount)
            {
               
                    for (int i = 0; i < dgv_bookmark.Rows.Count; i++)
                    {

                        remoteUsers.Open();
                        String query2 = "SELECT id FROM " + RdpConstant.tableBookmarks + "";

                        SqlDataAdapter SDA1 = new SqlDataAdapter(query2, remoteUsers);
                        dt1 = new System.Data.DataTable(); //Tabulka pro vypsání Id z SQL
                        SDA1.Fill(dt1);
                        remoteUsers.Close();

                        _id = Int32.Parse(dt1.Rows[i].ItemArray[0].ToString());

                        RdpConstant._alias = dgv_bookmark.Rows[i].Cells[0].Value.ToString();
                        RdpConstant._server = dgv_bookmark.Rows[i].Cells[1].Value.ToString();
                        RdpConstant._userName = dgv_bookmark.Rows[i].Cells[2].Value.ToString();
                        //_password = dgv_bookmark.Rows[index].Cells[3].Value.ToString();
                        RdpConstant._groupName = dgv_bookmark.Rows[i].Cells[4].Value.ToString();
                        RdpConstant._conType = dgv_bookmark.Rows[i].Cells[5].Value.ToString();

                    remoteUsers.Open();
                        string queryy = "UPDATE " + RdpConstant.tableBookmarks + " SET hostAlias=@hostAlias, ipAddress=@ipAddress, userName=@userName, userGroup=@userGroup, connectionType=@connectionType WHERE id= '" + _id + "'";
                        SqlCommand cmd2 = new SqlCommand(queryy, remoteUsers);


                        cmd2.Parameters.AddWithValue("@hostAlias", RdpConstant._alias);
                        cmd2.Parameters.AddWithValue("@ipAddress", RdpConstant._server);
                        cmd2.Parameters.AddWithValue("@userName", RdpConstant._userName);
                        //cmd2.Parameters.AddWithValue("@userPassword", _password);
                        cmd2.Parameters.AddWithValue("@userGroup", RdpConstant._groupName); //VYTVOŘIT COMBOBOX PRO PŘEPÍNÁNÍ 
                        cmd2.Parameters.AddWithValue("@connectionType", RdpConstant._conType);


                        //cmd.Parameters.AddWithValue("@conType", "RDP");

                        cmd2.ExecuteNonQuery();
                        remoteUsers.Close();
                    }

            }

                  
             
            





                this.Close();

            /*foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }*/
        }


            bool editOn = false;
        int editModeClickCount = 0;
        public void mode_Edit()
        {
            alowDelete = true;

            dgv_bookmark.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //dgv_bookmark.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgv_bookmark.ReadOnly = false;
            //dgv_bookmark.Columns[0].ReadOnly = true;
            DataGridViewCell selectedCell = dgv_bookmark.Rows[0].Cells[0];
            dgv_bookmark.CurrentCell = selectedCell;
            dgv_bookmark.BeginEdit(true);
            dgv_bookmark.GridColor = Color.LightGray;
            dgv_bookmark.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv_bookmark.MultiSelect = true;
            dgv_bookmark.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            dgv_bookmark.Columns[3].ReadOnly = true; //password
            //dgv_bookmark.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;
            dgv_bookmark.Columns[3].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgv_bookmark.Columns[3].DefaultCellStyle.SelectionBackColor = Color.White;
            dgv_bookmark.Columns[3].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

            dgv_bookmark.Columns[5].ReadOnly = true;
            //dgv_bookmark.Columns[5].DefaultCellStyle.BackColor = Color.LightGray;
            dgv_bookmark.Columns[5].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgv_bookmark.Columns[5].DefaultCellStyle.SelectionBackColor = Color.White;
            dgv_bookmark.Columns[5].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

            dgv_bookmark.Columns[6].ReadOnly = true;
            dgv_bookmark.Columns[6].DefaultCellStyle.SelectionBackColor = Color.White;



            editModeBTN.Text = "Normal mode";
        }
        
        private void mode_Normal()
        {
            alowDelete = true;

            dgv_bookmark.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_bookmark.ReadOnly = true;
            dgv_bookmark.MultiSelect = false;
            dgv_bookmark.CurrentRow.Cells[0].Selected = true;
            dgv_bookmark.GridColor = Color.White;
            dgv_bookmark.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv_bookmark.Columns[3].ReadOnly = true; //password
            //dgv_bookmark.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;
            dgv_bookmark.Columns[3].DefaultCellStyle.ForeColor = Color.Black;
            dgv_bookmark.Columns[3].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv_bookmark.Columns[3].DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_bookmark.Columns[5].ReadOnly = true;
            //dgv_bookmark.Columns[5].DefaultCellStyle.BackColor = Color.LightGray;
            dgv_bookmark.Columns[5].DefaultCellStyle.ForeColor = Color.Black;
            dgv_bookmark.Columns[5].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv_bookmark.Columns[5].DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_bookmark.Columns[6].ReadOnly = true;
            dgv_bookmark.Columns[6].DefaultCellStyle.SelectionBackColor = Color.LightGray;

            editModeClickCount = 0;
            editModeBTN.Text = "Edit mode";
        }
        private void mode_SelectColumns()
        {
            alowDelete = false;

            for (int i = 0; i < dgv_bookmark.Columns.Count; i++)
                dgv_bookmark.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv_bookmark.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_bookmark.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;

            //dgv_bookmark.GridColor = Color.FromArgb(215, 215, 215);
            //dgv_bookmark.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv_bookmark.MultiSelect = true;




            dgv_bookmark.ClearSelection();
        }
        private void editModeBTN_Click(object sender, EventArgs e)
        {
            editModeClickCount++;
            if (editModeClickCount == 1)
            {
                mode_Edit();


            }
            else if (editModeClickCount > 1)
            {
                mode_Normal();
            }

        }
        
        private void dgv_bookmark_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = new String('●', 8); //DOT
            }*/
        }
        /*System.Windows.Forms.CheckBox AliasCheckB;
        System.Windows.Forms.CheckBox IpCheckB;
        System.Windows.Forms.CheckBox UserCheckB;
        System.Windows.Forms.CheckBox PasswordCheckB;
        System.Windows.Forms.CheckBox GroupCheckB;*/
        
        
        private void addCheckboxToDgv()
        {

            
                checkb0 = new System.Windows.Forms.CheckBox();
            checkb0.Checked = false;
            checkb0.Location = new System.Drawing.Point(95, 7);
            checkb0.Name = "checkb0";
            checkb0.TextAlign = ContentAlignment.MiddleRight;
            checkb0.BackColor = Color.Transparent;
            checkb0.Size = new Size(55, 55);
            checkb0.AutoSize = true;
                this.dgv_bookmark.Controls.Add(checkb0);

            checkb1 = new System.Windows.Forms.CheckBox();
            checkb1.Checked = false;
            checkb1.Name = "checkb1";
            checkb1.Location = new System.Drawing.Point(187, 7);
            checkb1.TextAlign = ContentAlignment.MiddleRight;
            checkb1.BackColor = Color.Transparent;
            checkb1.Size = new Size(55, 55);
            checkb1.AutoSize = true;
                this.dgv_bookmark.Controls.Add(checkb1);

            checkb2 = new System.Windows.Forms.CheckBox();
            checkb2.Checked = false;
            checkb2.Name = "checkb2";
            checkb2.Location = new System.Drawing.Point(281, 7);
            checkb2.TextAlign = ContentAlignment.MiddleRight;
            checkb2.BackColor = Color.Transparent;
            checkb2.Size = new Size(55, 55);
            checkb2.AutoSize = true;
                this.dgv_bookmark.Controls.Add(checkb2);

            checkb3 = new System.Windows.Forms.CheckBox();
            checkb3.Checked = false;
            checkb3.Name = "checkb3";
            checkb3.Location = new System.Drawing.Point(393, 7);
            checkb3.TextAlign = ContentAlignment.MiddleRight;
            checkb3.BackColor = Color.Transparent;
            checkb3.Size = new Size(55, 55);
            checkb3.AutoSize = true;
                this.dgv_bookmark.Controls.Add(checkb3);

            checkb4 = new System.Windows.Forms.CheckBox();
            checkb4.Checked = false;
            checkb4.Name = "checkb4";
            checkb4.Location = new System.Drawing.Point(485, 7);
            checkb4.TextAlign = ContentAlignment.MiddleRight;
            checkb4.BackColor = Color.Transparent;
            checkb4.Size = new Size(55, 55);
            checkb4.AutoSize = true;
                this.dgv_bookmark.Controls.Add(checkb4);
            
            /*foreach (var c in this.Controls.OfType<System.Windows.Forms.CheckBox>())
            {
                c.Visible = visibleOn;
            }*/

        }

        private void dgv_bookmark_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgv_bookmark.BeginEdit(true);
        }


        Microsoft.Office.Interop.Excel.Application excel;
        Workbook wb; //Workbook
        Worksheet ws; //Worksheet
        SaveFileDialog sfd; //Save dialog
        //int selectedColumn;
        private void exportPB1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {//POKUD BUDE SELECTED COLUMN == TRUE EXPORTUJE VYBRANÉ SLOUPCE // JINAK EXPORTUJE CELOU TABULKU
                case MouseButtons.Left:
                    {
                        if (dgv_bookmark.SelectedColumns.Count == 0)
                        {
                          
                            try
                            {
                                /*excel = new Microsoft.Office.Interop.Excel.Application();
                                wb = excel.Workbooks.Add(Type.Missing);
                                ws = (Worksheet)excel.ActiveSheet;
                                excel.Visible = false;
                                // ws = wb.Sheets["Sheet1"];
                                ws = wb.ActiveSheet;*/

                                app = new Microsoft.Office.Interop.Excel.Application();
                                app.DisplayAlerts = false;
                                workbook = app.Workbooks.Add(Type.Missing);
                                worksheet = null;
                                //app.Visible = true;
                                worksheet = workbook.Sheets["List1"];
                                worksheet = workbook.ActiveSheet;
                                worksheet.Name = "Exported from dataGridView1";

                                // ws.Name = "Bookmarks";

                                for (int i = 1; i < dgv_bookmark.Columns.Count; i++)
                                {
                                    worksheet.Cells[1, i] = dgv_bookmark.Columns[i - 1].HeaderText; //HEADER i - axis X
                                }
                                for (int i = 0; i < dgv_bookmark.Rows.Count; i++) //i - axis Y
                                {
                                    for (int j = 0; j < dgv_bookmark.Columns.Count - 1; j++) //j - axis X
                                    {
                                        worksheet.Cells[i + 2, j + 1] = dgv_bookmark.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                worksheet.Columns.AutoFit();

                                sfd = new SaveFileDialog();
                                sfd.FileName = "SmartRDP-Bookmarks";
                                sfd.InitialDirectory = @"Desktop";
                                sfd.DefaultExt = ".xlsx";
                                sfd.Filter = "Excel Files(.xlsx)| *.xlsx| Excel Files(.xls)|*.xls | Excel Files(*.xlsm) | *.xlsm";



                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    string filePath = Path.GetFullPath(sfd.FileName);

                                    workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                                    app.Quit();
                                    //return;
                                }


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }else if (dgv_bookmark.SelectedColumns.Count > 0)
                        {
                            
                            ////HERE
                            excel = new Microsoft.Office.Interop.Excel.Application();
                            wb = excel.Workbooks.Add(Type.Missing);
                            ws = (Worksheet)excel.ActiveSheet;

                            excel.Visible = false;
                            // ws = wb.Sheets["Sheet1"];
                            ws = wb.ActiveSheet;

                            try
                            {


                                app = new Microsoft.Office.Interop.Excel.Application();
                                workbook = app.Workbooks.Add(Type.Missing);
                                worksheet = null;
                                //app.Visible = true;
                                worksheet = workbook.Sheets["List1"];
                                worksheet = workbook.ActiveSheet;
                                worksheet.Name = "Exported from dataGridView1";


                                foreach (DataGridViewColumn col in dgv_bookmark.Columns)
                                {
                                    if (col.Selected)
                                    {
                                        worksheet.Cells[1, col.Index + 1] = dgv_bookmark.Columns[col.Index].HeaderText;
                                    }
                                }

                                int rowIndex = 2;
                                try
                                {

                                    for (int row = 0; row <= dgv_bookmark.Rows.Count - 1; row++)
                                    {
                                        foreach (DataGridViewColumn col in dgv_bookmark.Columns)
                                        {

                                            if (col.Selected)
                                            {


                                                worksheet.Cells[rowIndex, col.Index + 1] = dgv_bookmark.Rows[row].Cells[ColumnsToInclude[col.Index]].Value.ToString();
                                                worksheet.Columns.AutoFit();

                                            }

                                        }
                                        rowIndex++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }


                                workbook.SaveAs("C:\\Users\\Pavel\\Desktop\\output.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);




                            
                                //Marshal.ReleaseComObject(app);
                                //Marshal.ReleaseComObject(workbook);
                                //Marshal.ReleaseComObject(worksheet);
                            }
                            catch
                            {
                                //MessageBox.Show("Není vybraný žádný sloupec.");
                            }

                            worksheet = null;

                            workbook.Close();
                            workbook = null;

                            app.Quit();
                            app = null;

                            foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                            {
                                process.Kill();
                            }

                        }
                    }
                    break;

                case MouseButtons.Right:
                    {

                        try
                        {
                            rightClickMenuStripExport.Items.Clear();
                            rightClickMenuStripExport.Items.Add("Select columns");
                            //rightClickMenuStrip.ShowCheckMargin = true;

                            //rightClickMenuStrip.Checked = true;
                            //rightClickMenuStrip.CheckState = System.Windows.Forms.CheckState.Checked;
                            rightClickMenuStripExport.Items.Add("Item2");


                            rightClickMenuStripExport.Show(exportPB1, new System.Drawing.Point(e.X, e.Y));//places the menu at the pointer position
                       
                            //rightClickMenuStripExport.ItemClicked += new ToolStripItemClickedEventHandler(rightClickMenuStripExport_ItemClicked);


                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
        }
       
        private void importPB1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (dgv_bookmark.SelectedColumns.Count == 0)
                        {
                           

                            string file = "";   //variable for the Excel File Location
                            System.Data.DataTable dt = new System.Data.DataTable();   //container for our excel data
                            DataRow row;

                            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                            openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                            openFileDialog1.FilterIndex = 3;

                            openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                            openFileDialog1.Title = "Import bookmarks";   //define the name of openfileDialog
                            openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

                            if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                            {

                                file = openFileDialog1.FileName; //get the filename with the location of the file
                                try

                                {

                                    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file

                                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                                    Workbook excelWorkbook = excelApp.Workbooks.Open(file);

                                    _Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                                    Range excelRange = excelWorksheet.UsedRange;


                                    excelRowCount = excelRange.Rows.Count;

                                    int colCount = excelRange.Columns.Count;


                                    for (int i = 1; i <= excelRowCount; i++)
                                    {
                                        for (int j = 1; j <= colCount; j++)
                                        {
                                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                                        }
                                        break;
                                    }

                                    int rowCounter;
                                    for (int i = 2; i <= excelRowCount; i++)
                                    {
                                        
                                        row = dt.NewRow();
                                        rowCounter = 0;
                                        for (int j = 1; j <= colCount; j++)
                                        {
                                            
                                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                                            {
                                                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                                            }
                                            else
                                            {
                                                //row[i] = "";
                                            }

                                            rowCounter++;

                                        }
                                        dt.Rows.Add(row);
                                    }
                                    try
                                    {
                                        if (dgv_bookmark.Columns.Contains("image"))
                                        {
                                            dgv_bookmark.Columns.Remove("image");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }

                                    dgv_bookmark.DataSource = dt;

                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                    Marshal.ReleaseComObject(excelRange);
                                    Marshal.ReleaseComObject(excelWorksheet);
                                    excelWorkbook.Close();
                                    Marshal.ReleaseComObject(excelWorkbook);

                                    //quit 
                                    excelApp.Quit();
                                    Marshal.ReleaseComObject(excelApp);

                                    DeleteRowBTN();

                                    remoteUsers.Open();
                                    string querry = "DELETE FROM " + RdpConstant.tableBookmarks + "";
                                    SqlCommand cmd = new SqlCommand(querry, remoteUsers);
                                    cmd.ExecuteNonQuery();
                                    remoteUsers.Close();
                                    ///////////////////////
                                    ///
                                    for (int i = 0; i < dgv_bookmark.Rows.Count; i++)
                                    {

                                        RdpConstant._alias = dgv_bookmark.Rows[i].Cells[0].Value.ToString();
                                        RdpConstant._server = dgv_bookmark.Rows[i].Cells[1].Value.ToString();
                                        RdpConstant._userName = dgv_bookmark.Rows[i].Cells[2].Value.ToString();
                                        RdpConstant._userPassword = dgv_bookmark.Rows[i].Cells[3].Value.ToString();
                                        RdpConstant._groupName = dgv_bookmark.Rows[i].Cells[4].Value.ToString();
                                        RdpConstant._conType = dgv_bookmark.Rows[i].Cells[5].Value.ToString();

                                        remoteUsers.Open();
                                        string query1 = "INSERT INTO " + RdpConstant.tableBookmarks + " (hostAlias, ipAddress, userName , userPassword,userGroup, connectionType) VALUES ( @hostAlias, @computerIp, @userName, @userPassword, @userGroup, @connectionType)";

                                        SqlCommand cmd1 = new SqlCommand(query1, remoteUsers);
                                        cmd1.Parameters.AddWithValue("@hostAlias", RdpConstant._alias);
                                        cmd1.Parameters.AddWithValue("@computerIp", RdpConstant._server);
                                        cmd1.Parameters.AddWithValue("@userName", RdpConstant._userName);
                                        cmd1.Parameters.AddWithValue("@userPassword", RdpConstant._userPassword);
                                        cmd1.Parameters.AddWithValue("@userGroup", RdpConstant._groupName);
                                        cmd1.Parameters.AddWithValue("@connectionType", RdpConstant._conType);
                                        cmd1.ExecuteNonQuery();

                                        remoteUsers.Close();
                                    }

                                    main.LoadTrayMenu();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else if (dgv_bookmark.SelectedColumns.Count > 0)
                        {
                           // if ((ModifierKeys & Keys.Control) == Keys.Control)
                           // {
                                app = new Microsoft.Office.Interop.Excel.Application();
                                workbook = app.Workbooks.Open(@"C:\Users\Pavel\Desktop\output.xlsx");
                                worksheet = workbook.ActiveSheet;

                                rcount = worksheet.UsedRange.Rows.Count;

                                int difference;

                                difference = (rcount - 1) - dgv_bookmark.Rows.Count;
                                System.Data.DataTable dataTable = (System.Data.DataTable)dgv_bookmark.DataSource;


                                for (int i = 0; i < difference; i++)
                                {

                                    dgv_bookmark.AllowUserToAddRows = true;
                                    drToAdd = dataTable.NewRow();
                                    dataTable.Rows.Add(drToAdd);


                                }
                                foreach (var item in ColumnsToInclude)
                                {
                                    if (item >= 0)
                                    {

                                        dgv_bookmark.Columns[ColumnsToInclude[item]].Selected = true;
                                    }
                                }

                                int rowIndex = 0;
                                int columnIndex = 0;
                                for (int row = 0; row < rcount - 1; row++)
                                {
                                    foreach (DataGridViewColumn col in dgv_bookmark.Columns)
                                    {
                                        if (col.Selected)
                                        {
                                            dgv_bookmark.Rows[rowIndex].Cells[ColumnsToInclude[col.Index]].Value = worksheet.Cells[rowIndex + 2, col.Index + 1].Value;
                                        }
                                    }
                                    rowIndex++;
                                }
                                dgv_bookmark.AllowUserToAddRows = false;
                                dgv_bookmark.ClearSelection();
                                deletePicture = new PictureBox[dgv_bookmark.Rows.Count];

                                for (int i = 0; i < deletePicture.Length; i++)
                                {
                                    var picture = new PictureBox();
                                    deletePicture[i] = picture;
                                    deletePicture[i].Name = "img" + i;
                                    deletePicture[i].Image = img;
                                    deletePicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                                    dgv_bookmark.Rows[i].Cells[6].Value = deletePicture[i].Image;

                                    deletePicture[i].Visible = true;
                                }

                           // }
                        }
                        break;
                    }
                case MouseButtons.Right:
                    {
                        rightClickMenuStripImport.Items.Clear();
                        rightClickMenuStripImport.Items.Add("Select columns2");
                        rightClickMenuStripImport.Items.Add("Item2");


                        rightClickMenuStripImport.Show(importPB1, new System.Drawing.Point(e.X, e.Y));//places the menu at the pointer position
                        
                        //rightClickMenuStripImport.ItemClicked += new ToolStripItemClickedEventHandler(rightClickMenuStripImport_ItemClicked);
                        

                    }
                    break;
            }
        }
        
        int rightClickCount = 0;
        bool selectCol = false;

        bool exportActive = false;
        private void rightClickMenuStripExport_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            e.ClickedItem.Enabled = false;
            importActive = false;
            exportActive = true;
            if (e.ClickedItem.Text == "Select columns")
            {
                
                if (selectCol == false)
                {
                    selectColImp = false;
                    //MessageBox.Show(selectCol.ToString());
                    //addCheckboxToDgv();
                    mode_SelectColumns();

                    selectCol = true;
                 

                }
                else if(selectCol == true)
                {
                    //MessageBox.Show(selectCol.ToString());
                    exportColCount.Text = "";
                    importColCount.Text = "";
                    mode_Normal();
                dgv_bookmark.Controls.Remove(checkb0);
                dgv_bookmark.Controls.Remove(checkb1);
                dgv_bookmark.Controls.Remove(checkb2);
                dgv_bookmark.Controls.Remove(checkb3);
                dgv_bookmark.Controls.Remove(checkb4);

                    selectCol = false;
                  
                }
             
            }

           
        }
        bool selectColImp = false;

        bool importActive = false;
        private void rightClickMenuStripImport_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            e.ClickedItem.Enabled = false;
            
            

            if (e.ClickedItem.Text == "Select columns2")
            {
                exportActive = false;
                importActive = true;
                if (selectColImp == false)
                {
                    selectCol = false;
                    //addCheckboxToDgv();
                    mode_SelectColumns();

                    selectColImp = true;
                    

                }
                else if(selectColImp == true)
                {
                    exportColCount.Text = "";
                    importColCount.Text = "";
                    mode_Normal();

                dgv_bookmark.Controls.Remove(checkb0);
                dgv_bookmark.Controls.Remove(checkb1);
                dgv_bookmark.Controls.Remove(checkb2);
                dgv_bookmark.Controls.Remove(checkb3);
                dgv_bookmark.Controls.Remove(checkb4);

                selectColImp = false;
                  
                }
               // textBox2.Text = rightClickCount.ToString();
                
                // MessageBox.Show(rightClickCount.ToString());
                
            }

           
        }
        int rcount;
        System.Data.DataTable dataTable;
        DataRow drToAdd;
        
        

        public int excelRowCount;
  
        private void exportPB1_MouseMove(object sender, MouseEventArgs e)
        {
            toolInfo.SetToolTip(exportPB1, "Export data");
        }
        private void importPB1_MouseMove(object sender, MouseEventArgs e)
        {
            toolInfo.SetToolTip(importPB1, "Import data");
        }
        int columnsCount = 0;

        Microsoft.Office.Interop.Excel._Application app;
        Microsoft.Office.Interop.Excel._Workbook workbook;
        Microsoft.Office.Interop.Excel._Worksheet worksheet;
        
        int[] columnsSelected;

        int selectedColumnCount;

        Int32 selectedCellCount;
        

        private void dgv_bookmark_SelectionChanged(object sender, EventArgs e)
        {
            selectedCellCount = dgv_bookmark.GetCellCount(DataGridViewElementStates.Selected);

            if (dgv_bookmark.SelectedColumns.Count > 0)
            {
                if (importActive == true)
                {

                    exportColCount.Text = "";
                    importColCount.Text = dgv_bookmark.SelectedColumns.Count.ToString();
                }
                else if (exportActive == true)
                {
                    importColCount.Text = "";
                    exportColCount.Text = dgv_bookmark.SelectedColumns.Count.ToString();
                }
            }
            else
            {
                
            }
            foreach (DataGridViewColumn col in dgv_bookmark.Columns)
            {
                if (col.Selected && col.Index <=4)
                {
                    ColumnsToInclude[col.Index] = col.Index;
                }
                else
                {
                    //ColumnsToInclude[col.Index] = -1;
                }
            }


        }
       
        public bool mouseDown = false;
        public bool mouseUp = false;
        public bool controlHold = false;
        private void dgv_bookmark_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            mouseDown = true;
            //MessageBox.Show(e.RowIndex.ToString());
        }

        private void dgv_bookmark_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            mouseUp = true;
        }

        
        private void dgv_bookmark_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
           

            //if (Control.ModifierKeys == Keys.Shift)
            //{

            //    //MessageBox.Show(columnArray.Length.ToString());
            //    if (mouseUp == true)
            //    {
            //        lastColumnIndex = dgv_bookmark.Columns[e.ColumnIndex].Index;
            //        textBox3.Text = lastColumnIndex.ToString();

            //        dgv_bookmark.Rows[e.RowIndex].Cells[lastColumnIndex].Selected = true;
            //        //dgv_bookmark.CurrentCell.Selected = true;
            //        foreach (System.Windows.Forms.CheckBox allcheck in dgv_bookmark.Controls.OfType<System.Windows.Forms.CheckBox>())
            //        {
            //            //if (allcheck.Checked == true)
            //            allcheck.Checked = false;
            //        }
            //        if (firstColumnIndex < lastColumnIndex)
            //        {
            //            for (int i = firstColumnIndex; i <= lastColumnIndex; i++)
            //            {
            //                string _i = "checkb" + i.ToString();

            //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
            //                {
            //                    ctrl.Checked = true;
            //                }

            //            }
            //        }
            //        else if(firstColumnIndex > lastColumnIndex)
            //        {
            //            for (int i = lastColumnIndex; i <= firstColumnIndex; i++)
            //            {
            //                string _i = "checkb" + i.ToString();

            //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
            //                {
            //                    ctrl.Checked = true;
            //                }

            //            }
            //        }else if(firstColumnIndex == lastColumnIndex)
            //        {
            //            for (int i = firstColumnIndex; i <= firstColumnIndex; i++)
            //            {
            //                string _i = "checkb" + i.ToString();

            //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
            //                {
            //                    ctrl.Checked = true;
            //                }

            //            }
            //        }


            //        mouseUp = false;


            //    }
            //}

            //if (Control.ModifierKeys == Keys.Control)
            //{


            //    //MessageBox.Show(columnArray.Length.ToString());
            //    /*if (mouseUp == true)
            //    {


            //        //MessageBox.Show(columnArray.Length.ToString());
            //        firstColumnIndex = dgv_bookmark.Columns[e.ColumnIndex].Index;
            //        textBox2.Text = firstColumnIndex.ToString();
            //        if (firstColumnIndex == 0)
            //        {
            //            //Array.Resize<int>(ref columnArray, 0);

            //            //DÉLKA DROW[] MUSÍ BÝT STEJNÁ JAKO POČET SELECTED POLÍ
            //            if (checkb0.Checked == false)
            //            {
            //                //MessageBox.Show(checkClick0.ToString());
            //                checkb0.Checked = true;
            //                dgv_bookmark.CurrentCell.Selected = true;

            //                columnArray[0] = 0;
            //                //MessageBox.Show(columnArray[0].ToString());
            //            }
            //            else if (checkb0.Checked == true)
            //            {
            //                checkb0.Checked = false;
            //                dgv_bookmark.CurrentCell.Selected = false;

            //                //Array.Clear(columnArray, 0, 3);
            //                columnArray[0] = -1;
            //                //MessageBox.Show(columnArray[0].ToString());
            //            }
            //        }
            //        else if (firstColumnIndex == 1)
            //        {



            //            if (checkb1.Checked == false)
            //            {
            //                columnArray[1] = 1;
            //                checkb1.Checked = true;

            //                //MessageBox.Show(columnArray[1].ToString());
            //            }
            //            else if (checkb1.Checked == true)
            //            {
            //                checkb1.Checked = false;
            //                dgv_bookmark.CurrentCell.Selected = false;
            //                columnArray[1] = -1;

            //                //MessageBox.Show(columnArray[1].ToString());
            //            }
            //        }
            //        else if (firstColumnIndex == 2)
            //        {


            //            if (checkb2.Checked == false)
            //            {
            //                columnArray[2] = 2;
            //                //MessageBox.Show(checkClick2.ToString());
            //                checkb2.Checked = true;
            //                //MessageBox.Show(columnArray[2].ToString());
            //            }
            //            else if (checkb2.Checked == true)
            //            {
            //                checkb2.Checked = false;
            //                dgv_bookmark.CurrentCell.Selected = false;
            //                columnArray[2] = -1;
            //                //MessageBox.Show(columnArray[2].ToString());
            //                //MessageBox.Show(checkClick2.ToString());
            //            }
            //        }
            //        else if (firstColumnIndex == 3)
            //        {


            //            if (checkb3.Checked == false)
            //            {
            //                //MessageBox.Show(checkClick3.ToString());
            //                checkb3.Checked = true;
            //            }
            //            else if (checkb3.Checked == true)
            //            {
            //                checkb3.Checked = false;
            //                dgv_bookmark.CurrentCell.Selected = false;

            //                //MessageBox.Show(checkClick3.ToString());
            //            }
            //            else
            //            {

            //            }
            //        }
            //        else if (firstColumnIndex == 4)
            //        {



            //            if (checkb4.Checked == false)
            //            {
            //                //MessageBox.Show(checkClick4.ToString());
            //                checkb4.Checked = true;
            //            }
            //            else if (checkb4.Checked == true)
            //            {
            //                checkb4.Checked = false;
            //                dgv_bookmark.CurrentCell.Selected = false;

            //                //MessageBox.Show(checkClick4.ToString());
            //            }
            //        }

            //        mouseUp = false;
            //    }*/
                //}
                //else
                //{


                //    if (mouseUp == true)
                //    {

                //        lastColumnIndex = dgv_bookmark.Columns[e.ColumnIndex].Index;
                //        textBox3.Text = lastColumnIndex.ToString();


                //        foreach (System.Windows.Forms.CheckBox allcheck in dgv_bookmark.Controls.OfType<System.Windows.Forms.CheckBox>())
                //        {
                //            //if (allcheck.Checked == true)
                //            allcheck.Checked = false;
                //        }

                //        /*if (firstColumnIndex == 0)
                //        {*/

                //        if (firstColumnIndex < lastColumnIndex)
                //        {
                //            for (int i = firstColumnIndex; i <= lastColumnIndex; i++)
                //            {
                //                string _i = "checkb" + i.ToString();

                //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
                //                {
                //                    ctrl.Checked = true;
                //                }

                //            }
                //        }
                //        else if (firstColumnIndex > lastColumnIndex)
                //        {
                //            for (int i = lastColumnIndex; i <= firstColumnIndex; i++)
                //            {
                //                string _i = "checkb" + i.ToString();

                //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
                //                {
                //                    ctrl.Checked = true;
                //                }

                //            }
                //        }
                //        else if (firstColumnIndex == lastColumnIndex)
                //        {
                //            for (int i = firstColumnIndex; i <= firstColumnIndex; i++)
                //            {
                //                string _i = "checkb" + i.ToString();

                //                foreach (System.Windows.Forms.CheckBox ctrl in dgv_bookmark.Controls.Find(_i, true))
                //                {
                //                    ctrl.Checked = true;
                //                }

                //            }
                //        }
                //        mouseUp = false;
                //        /*checkClick1 = 0;
                //        checkClick2 = 0;
                //        checkClick3 = 0;
                //        checkClick4 = 0;
                //        checkb1.Checked = false;
                //        checkb2.Checked = false;
                //        checkb3.Checked = false;
                //        checkb4.Checked = false;
                //        checkClick0++;

                //        if (checkClick0 == 1)
                //        {

                //            checkb0.Checked = true;
                //        }
                //        else if (checkClick0 > 1)
                //        {
                //            checkb0.Checked = false;
                //            dgv_bookmark.CurrentCell.Selected = false;
                //            checkClick0 = 0;
                //        }*/
                //    }
                //       /* else if (firstColumnIndex == 1)
                //        {
                //            checkClick0 = 0;
                //            checkClick2 = 0;
                //            checkClick3 = 0;
                //            checkClick4 = 0;
                //            checkb0.Checked = false;
                //            checkb2.Checked = false;
                //            checkb3.Checked = false;
                //            checkb4.Checked = false;

                //            checkClick1++;
                //            if (checkClick1 == 1)
                //            {
                //                checkb1.Checked = true;
                //            }
                //            else if (checkClick1 > 1)
                //            {
                //                checkb1.Checked = false;
                //                dgv_bookmark.CurrentCell.Selected = false;
                //                checkClick1 = 0;
                //            }
                //        }
                //        else if (firstColumnIndex == 2 && dgv_bookmark.CurrentCell.Selected)
                //        {
                //            checkClick0 = 0;
                //            checkClick1 = 0;
                //            checkClick3 = 0;
                //            checkClick4 = 0;
                //            checkb0.Checked = false;
                //            checkb1.Checked = false;

                //            checkb3.Checked = false;
                //            checkb4.Checked = false;

                //            checkClick2++;
                //            if (checkClick2 == 1)
                //            {
                //                checkb2.Checked = true;
                //            }
                //            else if (checkClick2 > 1)
                //            {
                //                checkb2.Checked = false;
                //                dgv_bookmark.CurrentCell.Selected = false;
                //                checkClick2 = 0;
                //            }
                //        }
                //        else if (firstColumnIndex == 3 && dgv_bookmark.CurrentCell.Selected)
                //        {
                //            checkClick0 = 0;
                //            checkClick1 = 0;
                //            checkClick2 = 0;
                //            checkClick4 = 0;
                //            checkb0.Checked = false;
                //            checkb1.Checked = false;
                //            checkb2.Checked = false;

                //            checkb4.Checked = false;

                //            checkClick3++;
                //            if (checkClick3 == 1)
                //            {
                //                checkb3.Checked = true;
                //            }
                //            else if (checkClick3 > 1)
                //            {
                //                checkb3.Checked = false;
                //                dgv_bookmark.CurrentCell.Selected = false;
                //                checkClick3 = 0;
                //            }
                //        }
                //        else if (firstColumnIndex == 4 && dgv_bookmark.CurrentCell.Selected)
                //        {
                //            checkClick0 = 0;
                //            checkClick1 = 0;
                //            checkClick2 = 0;
                //            checkClick3 = 0;
                //            checkb0.Checked = false;
                //            checkb1.Checked = false;
                //            checkb2.Checked = false;
                //            checkb3.Checked = false;


                //            checkClick4++;
                //            if (checkClick4 == 1)
                //            {
                //                checkb4.Checked = true;
                //            }
                //            else if (checkClick4 > 1)
                //            {
                //                checkb4.Checked = false;
                //                dgv_bookmark.CurrentCell.Selected = false;
                //                checkClick4 = 0;
                //            }
                //        }



                //        mouseUp = false;
                //    }*/
                //}

            }

        private void rdpBookmarks_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rdpBookmarksBool = false;
        }

        private void dgv_bookmark_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dgv_bookmark_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < deletePicture.Length; i++)
            {
                var picture = new PictureBox();
                deletePicture[i] = picture;
                deletePicture[i].Name = "img" + i;
                deletePicture[i].Image = img;
                deletePicture[i].BackgroundImageLayout = ImageLayout.Zoom;
                dgv_bookmark.Rows[i].Cells[6].Value = deletePicture[i].Image;

                deletePicture[i].Visible = true;
            }
        }





        /*
try
{

}
catch (SecurityException ex)
{
MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
$"Details:\n\n{ex.StackTrace}");
}*/

    }
}

