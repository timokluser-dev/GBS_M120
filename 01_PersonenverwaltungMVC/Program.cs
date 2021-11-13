using System;
using System.Windows.Forms;

namespace TimoKluser.PersonenverwaltungMVC
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PersonenModel model = new PersonenModel();
            Application.Run(new PersonenView(model));
        }
    }
}
