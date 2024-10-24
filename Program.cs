using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_Final_Project.view;
using DBMS_Final_Project.view.ChucNangBanHang;

namespace DBMS_Final_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new MainPage());

=======
            Application.Run(new Fmanager());
>>>>>>> eef1b8a63abbf6f707caba420b04ac3a412e8c77
        }
    }
}
