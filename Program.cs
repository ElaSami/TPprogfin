using System;
using System.Windows.Forms;

namespace Generateur_de_Mot_de_passe
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal pour l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
