using System;
using System.Windows.Forms;




namespace MEDIATEK86.Vues
{


    /// <summary>
    /// Classe de la fenêtre principale
    /// </summary>
    public partial class App : Form
    {

        private Controleur controle;


        /// <summary>
        /// Classe de la fenêtre principale
        /// </summary>
        /// <param name="controle">représente le controle unique qui créé la fenêtre principale</param>


        public App(Controleur controle)
        {
            InitializeComponent();

            this.controle = controle;


            this.dataGridView1.CellClick += this.controle.LigneSelectionnee;

            this.dataGridView1.SelectionChanged += this.controle.LigneSelectionnee;


            this.ButtonAdd.Click += this.controle.AjouterContact;

            this.ButtonEdit.Click += this.controle.EditerContact;

            this.ButtonDelete.Click += this.controle.SupprContact;

            this.Afficherabsences.Click += this.controle.AfficherFenetreAbsences;




            //Code qui fait en sorte que le champ à éditer ''service'' ne soit pas vide au démarrage

            this.TextService.Focus();

            SendKeys.Send("%+{DOWN}");


        }



        //Fonctions générées automatiquement par Designer

        private void App_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
