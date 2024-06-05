using gestionbdd;
using MEDIATEK86.Dal;
using MEDIATEK86;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MEDIATEK86.Vues
{
    /// <summary>
    /// Classe view de la fenêtre de connexion
    /// </summary>
    

    public partial class Connexion : Form
    {



        private Controleur controle;


        /// <summary>
        /// Classe de la fenêtre de connexion
        /// </summary>
        /// <param name="controle">représente le controle unique qui créé la fenêtre principale</param>

        public Connexion(Controleur controle)
        {


            InitializeComponent();

            this.controle = controle;


            this.button1.Click += ClickConnexion;

            this.textBox1.KeyPress += ClavierConnexion;
            this.textBox2.KeyPress += ClavierConnexion;

        }




        /// <summary>
        /// Fonction appellée si l'utilisateur presse une touche 
        /// Si il s'agit d'entrée, on considère que l'utilisateur valide le formulaire de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ClavierConnexion(object sender, System.EventArgs e)
        {


            //Pas très propre, mais détecte si la touche pressée par l'utilisateur correspond à entrée -> permet de valider 

            if (((System.Windows.Forms.KeyPressEventArgs)e).KeyChar == 13)
            {
                ClickConnexion(sender, e);
            }
        }

        private void ClickConnexion(object sender, System.EventArgs e)
        {




            string login = textBox1.Text;
            string pwd = textBox2.Text;

            bool champs_remplis = true;

            if (login.Length == 0 && pwd.Length == 0)
            {
                MessageBox.Show("Identifiant et mot de passe absents.", "Alerte");
                champs_remplis = false;

            }
            else if (login.Length == 0)
            {
                MessageBox.Show("Identifiant absent.", "Alerte");
                champs_remplis = false;

            }
            else if (pwd.Length == 0)
            {
                MessageBox.Show("Mot de passe absent.", "Alerte");
                champs_remplis = false;
            }
            //On sort de la pahse d'authentification si les champs sont "vides",
            //Sinon on compare avec controleAythentification:

            

            if (!champs_remplis) { return; }


            if (controle.ControleAuthentification(login, pwd))
            {
                MessageBox.Show("Authentification correcte", "Alerte");
                this.Hide();

                controle.CreateMainWindow();
            }
            else
            {
                MessageBox.Show("Authentification incorrecte ou vous n'êtes pas admin", "Alerte");
            }
        }



        //Fonctions générées automatiquement par Designer

        private void Form1_Load(object sender, EventArgs e)
        {



        }


    }
}
