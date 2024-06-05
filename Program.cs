//using Appli.bddmanager;
using MEDIATEK86; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MEDIATEK86

{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



           
            // Appelle (mais ne stocke pas) un nouveau "controleur" -> vu que le controleur
            // a besoin d'avoir accès a la fenêtre de connexion, celle ci est "appellée" dans 
            // la méthode de création de controleur.

            new Controleur();

            
        }
    }
}
