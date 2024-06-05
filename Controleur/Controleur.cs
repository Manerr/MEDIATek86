using MEDIATEK86.Dal;
using MEDIATEK86.Vues;
using MEDIATEK86;

using MEDIATEK86.Modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MEDIATEK86
{



    /// <summary>
    /// Classe/objet unique représentant le controleur , qui agit entre les actions de l'utilisateur 
    /// et la gestion/accès des données
    /// </summary>


    public class Controleur
    {

        /// <summary>
        /// Variable peu utilisée pour savoir si le tableau est vide.
        /// </summary>

        public bool empty = true;

        public bool emptyabsences = true;

        private Connexion viewConnexion;
        private App viewAppli;
        private ListeAbsences viewAbsences;


        private List<Personnel> listePersonnel = new List<Personnel>();
        private List<Absence> listeAbsences = new List<Absence>();


        static int cntr;




        /// <summary>
        /// Classe/objet unique représentant le controleur , qui agit entre les actions de l'utilisateur 
        /// et la gestion/accès des données
        /// </summary>

        public Controleur()
        {

            OpenLoginWindow();

        }



        /// <summary>
        /// Ouvre la fenêtre de connexion
        /// Appelé par défaut lors de l'éxecution de l'app
        /// </summary>

        public void OpenLoginWindow()
        {
            viewConnexion = new Connexion(this);
            viewConnexion.ShowDialog();

        }

        /// <summary>
        /// Ouvre la fenêtre principale
        /// </summary>

        public void CreateMainWindow()
        {

            viewAppli = new App(this);

            //viewAppli.dataGridView1.ClearSelection();

            AfficherData();

            viewAppli.ShowDialog();




            //viewAppli.dataGridView1.Fill();
        }



        /// <summary>
        /// Efface le tableau pour le reremplir
        /// </summary>

        public void NettoyerData()
        {
            this.viewAppli.dataGridView1.Rows.Clear();
            //this.viewAppli.dataGridView1.ClearSelection();
            //this.viewAppli.dataGridView1.Rows.Clear();

            CacherButtonAbsences();

        }


        /// <summary>
        /// Affiche les données dans le tableau
        /// </summary>

        public void AfficherData()
        {

            CacherButtonAbsences();



            listePersonnel = AccesDonnees.GetLesPersonnels();

            if (listePersonnel.Count == 0)
            {
                this.empty = true;
            }
            else
            {
                this.empty = false;
            }

            


            foreach (Personnel ElementPersonnel in listePersonnel)
            {
                viewAppli.dataGridView1.Rows.Add(ElementPersonnel.IDpersonnel, ElementPersonnel.Nom, ElementPersonnel.Prénom, ElementPersonnel.Services, ElementPersonnel.Téléphone, ElementPersonnel.Mail);

            }





        }


        /// <summary>
        /// Controle la connexion et renvoie un booléen
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>


        public Boolean ControleAuthentification(string login, string pwd)
        {
            try
            {

                if (AccesDonnees.TesterConnexion(login, pwd))
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                MessageBox.Show("La base de donnée MySQL distante ne semble pas active.", "Alerte");
                return false;
            }

        }




        /// <summary>
        /// Appelé lorsqu'une ligne (une personne) est sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void LigneSelectionnee(object sender, EventArgs e)
        {


            if (this.empty)
            {
                CacherButtonAbsences();
                return;
            }

            //Si on sélectionne la dernière ligne alors on ne fait rien (ligne inutile générée par vsstudio)







            if (this.viewAppli.dataGridView1.SelectedCells.Count > 0)
            {
                int PersonnelID = (int)((System.Windows.Forms.DataGridView)sender).SelectedCells[0].Value;



                

                AfficherContenuDansEntry(PersonnelID);

                AfficherButtonAbsences();

                

            }
        }


        /// <summary>
        /// Affiche (ou plutôt active) le bouton permettant d'afficher les absences
        /// </summary>

        public void AfficherButtonAbsences()
        {
            this.viewAppli.Afficherabsences.Enabled = true;
        }

        /// <summary>
        /// Cache (ou plutôt désactive) le bouton permettant d'afficher les absences
        /// </summary>


        public void CacherButtonAbsences()
        {
            this.viewAppli.Afficherabsences.Enabled = false;

        }


        /// <summary>
        /// Effacer le formulaire de modification, 
        /// lorsque par exemple on ajoute ou modifie un contact (pour éviter des erreurs)
        /// </summary>


        public void EffacerEntry()
        {
            viewAppli.TextPrenom.Text = "";
            viewAppli.TextNom.Text = "";
            viewAppli.TextService.Text = "";
            viewAppli.TextEmail.Text = "";
            viewAppli.TextTelephone.Text = "";
        }


        /// <summary>
        /// Affiche dans le formulaire de modification (à droite) 
        /// Les données sélectionnées
        /// </summary>
        /// <param name="index"></param>


        public void AfficherContenuDansEntry(int index)
        {

            Personnel PersonnelAEditer = AccesDonnees.GetUnPersonnel(index);

            viewAppli.TextPrenom.Text = PersonnelAEditer.Prénom;
            viewAppli.TextNom.Text = PersonnelAEditer.Nom;
            viewAppli.TextService.Text = PersonnelAEditer.Services;
            viewAppli.TextEmail.Text = PersonnelAEditer.Mail;
            viewAppli.TextTelephone.Text = PersonnelAEditer.Téléphone;



        }

        /// <summary>
        /// Appelle la modification des données quand l'utilisateur clique sur ajouter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        public void AjouterContact(object sender, EventArgs e)
        {
            string Prenom = viewAppli.TextPrenom.Text;
            string Nom = viewAppli.TextNom.Text;
            string Service = viewAppli.TextService.Text;
            string Email = viewAppli.TextEmail.Text;
            string Telephone = viewAppli.TextTelephone.Text;



            if (!Prenom.Equals("") && !Nom.Equals("") && !Service.Equals("") && !Email.Equals("") && !Telephone.Equals(""))
            {

                Personnel PersonnelAAjouter = new Personnel(this.viewAppli.dataGridView1.RowCount, -1, Nom, Prenom, Telephone, Email, Service);

                AccesDonnees.AddUnPersonnel(PersonnelAAjouter);



                NettoyerData();
                AfficherData();

                EffacerEntry();
            }

            else
            {
                MessageBox.Show("Champs manquants.");

            }



        }

        /// <summary>
        /// Appelle la modification des données quand l'utilisateur clique sur modifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void EditerContact(object sender, EventArgs e)
        {
            string Prenom = viewAppli.TextPrenom.Text;
            string Nom = viewAppli.TextNom.Text;
            string Service = viewAppli.TextService.Text;
            string Email = viewAppli.TextEmail.Text;
            string Telephone = viewAppli.TextTelephone.Text;

            if (viewAppli.dataGridView1.SelectedCells.Count == 0) { return; }



            if (!Prenom.Equals("") && !Nom.Equals("") && !Service.Equals("") && !Email.Equals("") && !Telephone.Equals(""))
            {



                int index = (int)viewAppli.dataGridView1.SelectedRows[0].Cells[0].Value;


                Personnel PersonnelAEditer = new Personnel(index, -1, Nom, Prenom, Telephone, Email, Service);

                if (MessageBox.Show("Souhaitez-vous confirmer la modification?", "Etes vous sur ?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AccesDonnees.EditerUnPersonnel(PersonnelAEditer);
                    NettoyerData();
                    AfficherData();
                }

            }

            else
            {
                MessageBox.Show("Champs manquants.");
                NettoyerData();
                AfficherData();

            }

        }


        /// <summary>
        /// Procédure qui permet de supprimer la ligne sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void SupprContact(object sender, EventArgs e)
        {
            if (viewAppli.dataGridView1.RowCount == 0)
            {
                return;
            }


            if (MessageBox.Show("Souhaitez-vous confirmer la suppression?", "Etes vous sur ?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                int id = (int)(viewAppli.dataGridView1.SelectedCells[0].Value);

                AccesDonnees.SupprUnPersonnel(id);

                NettoyerData();
                AfficherData();

                EffacerEntry();

            }

        }


        /// <summary>
        /// Affiche la fenêtre des absences pour un personnel donné (récupéré dynamiquement avec viewAppli)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        public void AfficherFenetreAbsences(object sender, EventArgs e)
        {


            viewAbsences = new ListeAbsences(this);

            int idPersonnel = (int)(viewAppli.dataGridView1.SelectedCells[0].Value);

            AfficherDataAbsences(idPersonnel);

            viewAbsences.ShowDialog();

        }

        /// <summary>
        /// Ferme la fenêtre des absences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void FermerAbsences(object sender, EventArgs e)
        {

            viewAbsences.Hide();

        }




        /// <summary>
        /// Remplit la fenêtre des absences avec un id donné -> id du personnel sélectionné
        /// </summary>
        /// <param name="idPersonnel"></param>

        public void AfficherDataAbsences(int idPersonnel)
        {
            listeAbsences = AccesDonnees.GetLesAbsences(idPersonnel);

            if (listeAbsences.Count == 0)
            {
                this.emptyabsences = true;
            }
            else
            {
                this.emptyabsences = false;
            }

            

            viewAbsences.dataGridView1.Rows.Clear();

            foreach (Absence ElementAbsences in listeAbsences)
            {


                viewAbsences.dataGridView1.Rows.Add(ElementAbsences.IdAbsence, ElementAbsences.Datedebut.ToShortDateString(), ElementAbsences.Datefin.ToShortDateString(), ElementAbsences.NomMotif);

            }


            if (viewAbsences.dataGridView1.SelectedRows.Count > 0)
            {
                viewAbsences.dataGridView1.SelectedRows[0].Selected = false;
            }



        }



        

        /// <summary>
        /// Fonction qui évite d'appeler une table non "séléctionnée" - Pour une table d'absence.
        /// </summary>
        /// <returns></returns>

        public bool LigneSelectionnee()
        {
            if (this.viewAbsences.dataGridView1.SelectedCells.Count == 0) { return false; }
            return true;
        }


        /// <summary>
        /// Affiche dans le formulaire à droite l'absence sélectionnée
        /// </summary>
        /// <param name="ABSID"></param>

        public void AfficherAbsenceDataEntry(object sender, EventArgs e)
        {


            if (this.emptyabsences)
            {   
                return;
            }

            //Si on sélectionne la dernière ligne alors on ne fait rien (ligne inutile générée par vsstudio)




            if (LigneSelectionnee() == false || this.viewAbsences.dataGridView1.SelectedRows[0].Index > viewAppli.dataGridView1.RowCount - 1)
            {
                return;
            }


            int ABSID = (int)this.viewAbsences.dataGridView1.SelectedCells[0].Value;

            Absence AbsenceAEditer = AccesDonnees.GetUneAbsence(ABSID);

            viewAbsences.datedebut.Text = AbsenceAEditer.Datedebut.ToShortDateString();
            viewAbsences.datefin.Text = AbsenceAEditer.Datefin.ToShortDateString();

            viewAbsences.motifentry.Text = AbsenceAEditer.NomMotif;



        }

        /// <summary>
        /// Suppression d'une absence, appellé par un événement utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        public void SupprAbsence(object sender, EventArgs e)
        {

            if (LigneSelectionnee() == false) { return; }
            if (MessageBox.Show("Souhaitez-vous confirmer la suppression?", "Etes vous sur ?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                int ABSID = (int)this.viewAbsences.dataGridView1.SelectedCells[0].Value;

                AccesDonnees.SupprAbsencePersonnel(ABSID);

                AfficherDataAbsences(this.listeAbsences[0].Idpersonnel);
            }
        }


        /// <summary>
        /// Donne la validité entre deux créneaux (si le nouveau, passé avec les deux derniers arguments est valide)
        /// </summary>
        /// <param name="datedebutabsence"></param>
        /// <param name="datefinabsence"></param>
        /// <param name="datedebutnouvelleabsence"></param>
        /// <param name="finnouvelleabsence"></param>
        /// <returns></returns>

        public bool ValiderDate(DateTime datedebutabsence, DateTime datefinabsence, DateTime datedebutnouvelleabsence, DateTime datefinnouvelleabsence)
        {
            
            int cmp1 = DateTime.Compare(datefinabsence, datedebutnouvelleabsence);
            int cmp2 = DateTime.Compare(datefinnouvelleabsence, datedebutabsence);

            // Les créneaux se chevauchent si cmp1 > 0 et cmp2 > 0
            return (cmp1 >= 0 && cmp2 >= 0) == false;

        }


        /// <summary>
        /// Vérifie que le créneau n'a pas une date de fin antérieure au début
        /// </summary>
        /// <param name="debut"></param>
        /// <param name="fin"></param>
        /// <returns></returns>

        public bool CréneauValide(DateTime debut, DateTime fin)
        {
            return debut <= fin;
        }


        /// <summary>
        /// Modification d'une absence, appellée par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void AjouterAbsence(object sender, EventArgs e)
        {




            DateTime Datedebut = (DateTime)viewAbsences.datedebut.Value;
            DateTime Datefin = (DateTime)viewAbsences.datefin.Value;

            if (CréneauValide(Datedebut,Datefin) == false)
            {
                MessageBox.Show("Dates non valides (Exemple: date de fin antérieure).", "Erreur de saisie");
                return;
            }


            int idpersonnel = (int)this.viewAppli.dataGridView1.SelectedCells[0].Value;

            string motif = viewAbsences.motifentry.Text;


            foreach (Absence absenceexistante in listeAbsences)
            {
                DateTime datedebutexistant = absenceexistante.Datedebut;
                DateTime datefinexistant = absenceexistante.Datefin;

                //Comparer avec chaque date en absence

                bool valid = ValiderDate(datedebutexistant, datefinexistant, Datedebut, Datefin);

                if (valid == false)
                {
                    MessageBox.Show("La/les dates saisies sont déjà incluses dans un/des créneau(x).", "Erreur de saisie");
                    return;
                }


            }




            AccesDonnees.AddUneAbsence(new Absence(-1, idpersonnel, Datedebut, Datefin, 1, motif));


            AfficherDataAbsences(idpersonnel);





        }


        /// <summary>
        /// Édite une absence 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void EditerUneAbsence(object sender, EventArgs e)
        {
            if (LigneSelectionnee() == false) { return; }

            

            

            DateTime Datedebut = (DateTime)viewAbsences.datedebut.Value;
            DateTime Datefin = (DateTime)viewAbsences.datefin.Value;

            if (CréneauValide(Datedebut, Datefin) == false)
            {
                MessageBox.Show("Dates non valides (Exemple: date de fin antérieure).", "Erreur de saisie");
                return;
            }

            int idpersonnel = (int)this.viewAppli.dataGridView1.SelectedCells[0].Value;

            int motif = viewAbsences.motifentry.SelectedIndex + 1;

            string nommotif = viewAbsences.motifentry.Text;

            int ID = (int)this.viewAbsences.dataGridView1.SelectedCells[0].Value;

            foreach (Absence absenceexistante in listeAbsences)
            {



                DateTime datedebutexistant = absenceexistante.Datedebut;
                DateTime datefinexistant = absenceexistante.Datefin;
                //Comparer avec chaque date en absence sauf celle existante bien sur! dans ce cas on "saute"

                if( absenceexistante.IdAbsence == ID ){ continue;  }

                bool valid = ValiderDate(datedebutexistant, datefinexistant, Datedebut, Datefin);

                if (valid == false)
                {
                    MessageBox.Show("La/les dates saisies sont déjà incluses dans un/des créneau(x).", "Erreur de saisie");
                    return;
                }


            }




            

            AccesDonnees.EditUneAbsence(new Absence(ID, idpersonnel, Datedebut, Datefin, motif, nommotif));



            AfficherDataAbsences(idpersonnel);





        }

    }
}
