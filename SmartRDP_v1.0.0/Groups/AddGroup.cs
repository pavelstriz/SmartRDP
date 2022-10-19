using RDP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SmartRDP_v1._0._0
{
    public partial class addGroup : Form
    {
        public addGroup()
        {
            InitializeComponent();
        }
        public SqlConnection remoteGroups = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");
        public SqlConnection remoteUsers = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=SmartRDP;Integrated Security=True");


        public static string _groupName;
        public static string groupNameStored
        {
            get { return _groupName; }
            set { _groupName = value; }// groupNameTXT.Text = value; }
        }
        public static string _groupType;
        public static string groupTypeStored
        {
            get { return _groupType; }
            set { _groupType = value; }
        }
        public static string _groupShortCut;
        public static string groupShortCutStored
        {
            get { return _groupShortCut; }
            set { _groupShortCut = value; }
        }
        Bitmap bmp;
        Bitmap b2;
        private void addGroup_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = Properties.Resources.groupFlag1_6;
           
            //pictureBox1.Image = Image.FromFile(@"D:\Projekty\C#\SmartRDP\remmina\rpg.jpg");

            bmp = (Bitmap)pictureBox1.Image;

            b2 = new Bitmap(bmp, new Size(bmp.Width / 2, bmp.Height / 2));
            pictureBox1.Image = b2;

            groupShortCutTXT.Text = UC_Groups.gShortcutStored;
            groupNameTXT.Text = UC_Groups.gNameStored;
            groupTypeCB1.SelectedItem = UC_Groups.gTypeStored;
            //pictureBox1.Image = UC_Groups.gImageStored;

            try
            {
                MemoryStream mem = new MemoryStream(UC_Groups.gImageStored);
                pictureBox1.Image = Image.FromStream(mem);
            }
            catch
            {

            }


            //groupTypeCB1.SelectedItem = "<None>";
        }
        private void groupShortCutTXT_TextChanged(object sender, EventArgs e)
        {
            _groupShortCut = groupShortCutTXT.Text;
        }
        private void groupNameTXT_TextChanged(object sender, EventArgs e)
        {
            _groupName = groupNameTXT.Text;
        }
        private void groupTypeCB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _groupType = groupTypeCB1.Text;
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);

        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }

        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand checkGroupName = new SqlCommand("SELECT COUNT(*) FROM " + RdpConstant.tableGroups + " WHERE (id = @id)", remoteGroups);
                remoteGroups.Open();
                checkGroupName.Parameters.AddWithValue("@id", UC_Groups.selectedId);

                int groupNameExist = (int)checkGroupName.ExecuteScalar();
                remoteGroups.Close();

                if (groupNameExist > 0)
                {
                    groupTypeCB1.SelectedItem = UC_Groups.gTypeStored;
                    DialogResult dialogResult = MessageBox.Show("Update existing group?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        byte[] arr;
                        ImageConverter converter = new ImageConverter();
                        arr = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));

                        remoteGroups.Open();
                        string queryy = "UPDATE " + RdpConstant.tableGroups + " SET groupShortcut=@groupShortcut , groupName=@groupName, groupType=@groupType, groupColor=@groupColor  WHERE groupName = '" + UC_Groups.selectedGroupName + "' AND groupType = '" + UC_Groups.selectedGroupType + "' AND id = '"+ UC_Groups.gIdStored + "'";
                        SqlCommand cmd = new SqlCommand(queryy, remoteGroups);
                        cmd.Parameters.AddWithValue("@groupShortcut", groupShortCutTXT.Text);
                        cmd.Parameters.AddWithValue("@groupName", groupNameTXT.Text);
                        cmd.Parameters.AddWithValue("@groupType", UC_Groups.gTypeStored);
                        cmd.Parameters.AddWithValue("@groupColor", arr);

                        cmd.ExecuteNonQuery();
                        remoteGroups.Close();

                        //Projde všechny záznamy ve sloupci userGroup s filtrem selectedGroupName a pokud hodnota existuje vypíšed ji
                        remoteUsers.Open();
                        String query2 = "SELECT userGroup FROM " + RdpConstant.tableBookmarks + " WHERE userGroup = '" + UC_Groups.gNameStored + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, remoteUsers);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        
                        while (dr2.Read())
                        {
                            //Updatuje všem uživatelům upravenou skupinu na "newGroup"
                            remoteGroups.Open();
                            string query3 = "UPDATE " + RdpConstant.tableBookmarks + " SET userGroup=@newGroup WHERE userGroup=@defaultGroup";
                            SqlCommand cmd3 = new SqlCommand(query3, remoteGroups);
                            cmd3.Parameters.AddWithValue("@newGroup", groupNameTXT.Text); 
                            cmd3.Parameters.AddWithValue("@defaultGroup", UC_Groups.gNameStored);
                            cmd3.ExecuteNonQuery();
                            remoteGroups.Close();
                           

                        }
                        remoteUsers.Close();


                        insert();

                        




                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (groupNameExist == 0)
                {

                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));

                    remoteGroups.Open();
                    string query1 = "INSERT INTO " + RdpConstant.tableGroups + " ( groupShortcut, groupName, groupType, groupColor) VALUES (@groupShortcut, @groupName, @groupType, @groupColor)";

                    SqlCommand cmd1 = new SqlCommand(query1, remoteGroups);
                    //cmd1.Parameters.AddWithValue("@id", rdpName.Text);
                    cmd1.Parameters.AddWithValue("@groupShortcut", groupShortCutTXT.Text);
                    cmd1.Parameters.AddWithValue("@groupName", groupNameTXT.Text);
                    cmd1.Parameters.AddWithValue("@groupType", groupTypeCB1.SelectedItem.ToString());
                    //if (UC_Groups.gImageStored != null && UC_Groups.gImageStored.Length > 0)
                        cmd1.Parameters.AddWithValue("@groupColor", arr);
                    //else if(UC_Groups.gImageStored == null)
                    //cmd1.Parameters.AddWithValue("@groupColor", DBNull.Value);

                    cmd1.ExecuteNonQuery();

                    remoteGroups.Close();

                    // groupNameExist = 0;
                    //insert();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        Color argb;
        PictureBox pp;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();

            if (c.ShowDialog() == DialogResult.OK)
            {
                pp = sender as PictureBox;

                //pp.BackColor = c.Color;

                Color color = c.Color;
                byte A = color.A;
                byte R = color.R;
                byte G = color.G;
                byte B = color.B;

                //MessageBox.Show(A.ToString() + ", " + R.ToString()+ ", " + G.ToString() + ", " + B.ToString());


                Bitmap CustBMP = new Bitmap(b2.Width, b2.Height);

                for (int i = 0; i < b2.Width; i++)
                {
                    for (int j = 0; j < b2.Height; j++)
                    {

                        Color p = b2.GetPixel(j, i);

                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;

                        CustBMP.SetPixel(j, i, Color.FromArgb(a, R, G, B));

                    }
                }
                pictureBox1.Image = CustBMP;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
