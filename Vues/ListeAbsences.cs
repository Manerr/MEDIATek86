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
    /// Classe représentant la fenêtre des absences.
    /// </summary>
    


    public partial class ListeAbsences : Form
    {

        private Controleur controle;

        


        /// <summary>
        /// Classe/Objet représentant la fenêtre des absences.
        /// </summary>
        /// <param name="controle"></param>


        public ListeAbsences(Controleur controle)
        {

            InitializeComponent();

            this.controle = controle;

            this.buttonFermerAbsences.Click += controle.FermerAbsences;

            this.dataGridView1.Click += controle.AfficherAbsenceDataEntry;

            this.dataGridView1.SelectionChanged += controle.AfficherAbsenceDataEntry;

            this.buttonsuppr.Click += controle.SupprAbsence;

            this.buttonajouter.Click += controle.AjouterAbsence;

            this.buttonmodifier.Click += this.controle.EditerUneAbsence;

            this.dataGridView1.Focus();

            SendKeys.Send("%+{DOWN}");

            SendKeys.Send("Return");


        }


        //Fonctions générées automatiquement par Designer

        private void ListeAbsences_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
