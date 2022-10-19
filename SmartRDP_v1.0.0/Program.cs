using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRDP_v1._0._0
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        
        [STAThread]
        //[HandleProcessCorruptedStateExceptions, SecurityCritical]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
                //Application.Run(new SmartRDP());
                Application.Run(new MainWindow1());
           
        }
    }
}
