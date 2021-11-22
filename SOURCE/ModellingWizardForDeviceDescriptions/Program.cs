using Aml.Engine.CAEX;
using Aml.Engine.CAEX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    static class Program
    {
        public static Boolean expertMode = true;
        public static CAEXDocument caexDocument;
        public static String filepath = string.Empty;
        public static String filetype = null;
        public static Boolean unsavedChanges = false;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            form.switchMode(false);
            Application.Run(form);
        }
    }
}
