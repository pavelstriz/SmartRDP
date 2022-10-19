using SmartRDP_v1._0._0;
using SmartRDP_v1._0._0.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace RDP
{
    class RdpConstant
    {
        public static readonly string IpaddressPatten= @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

        public static string FilePath = @"C:\temp\SmartRDP\rdp.rdp";

        public static string templatePath=@"C:/Program Files (x86)/SmartRDP 1.1.5/SmartRDP/encryption/TemplateRDP.txt"; //../../encryption/TemplateRDP.txt"

        public static string rdpSavesFolder= @"C:\temp\SmartRDP\";

        //TABLES
        public static string tableRecently = "tbl_Recently3";//"tbl_rdpRecently2";
        public static string tableBookmarks = "tbl_rdpBookmarks3"; //tbl_rdpBookmarks1
        public static string _tableSaveCredentials = "tbl_saveCred3";
        public static string tableSaveCredentials
        {
            get { return _tableSaveCredentials; }
        }
        public static string tableGroups = "tbl_Groups5";//"tbl_Groups2"; tbl_Groups1";
        public static string tableGroupUsers = "tbl_GroupUsers1";
        //VARIABLES
        public static int maxRecentlyUsers = 10; //Maximální počet uživatelů v Recently tabulce (Naposledy přidaní)
        public static string defaultGroup = "<None>";
        public static int maxGroups = 20;
        public static int maxUsers = 200;
        public static int pingMachinesAfterSeconds = 3; //Seconds
        public static string dateFormat = "yyyy-MM-dd";
        public static string timeFormat = "HH:mm:ss";

        public static int connectTestAfter = 1000;  //1000 ms default

        public static bool isOpenRDPStatementTrue = false;

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
        public static string _conType;
        public static string conTypeStored
        {
            get { return _conType; }
            set { _conType = value; }
        }
        public static Image _groupFlag;
        public static Image groupFlagStored
        {
            get { return _groupFlag; }
            set { _groupFlag = value; }
        }



        /*public static bool _saveCred;
        public static bool saveCredStored
        {
            get { return _saveCred; }
            set { _saveCred = value; }
        }*/
        public static int _bookmarksRowIndex;
        public static int bookmarksRowIndexStored
        {
            get { return _bookmarksRowIndex; }
            set { _bookmarksRowIndex = value; }
        }

        //FUNCTIONS
        public static void GridSettings(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.0F, FontStyle.Regular);
            

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 25;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 151, 218); //52,151,218 HEADER
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 151, 218); //52,151,218 HEADER
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //52,151,218

            //dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 215, 215);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            //dgv.RowTemplate.Height = 20;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            //dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void _mstsc(String cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
        }



        //IMAGES

        //public static Image statusOnline = Image.FromFile(@"D:\Projekty\C#\Program\Ikony\SmartRDP\");
        //public static Image statusOnline = Image.FromFile(@"D:\Projekty\C#\Program\Ikony\SmartRDP\statusOnline12x12.png");
        //public static Image statusOnline = Image.FromFile(@"D:\Projekty\C#\Program\Ikony\SmartRDP\statusOnline12x12.png");
        public static Image statusTrying = Resources.statusTrying12x12_2;
        public static Image statusOnline = Resources.statusOnline12x12;
        public static Image statusOffline = Resources.statusOffline12x12;
        //public static object groupFlag = 
    }
}
