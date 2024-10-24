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
            Application.Run(new main_ban_hang());
=======
            Application.Run(new MainPage());
>>>>>>> c413fa3141a52373e59ef2aa43a7de150e50cc71
        }
    }
}
