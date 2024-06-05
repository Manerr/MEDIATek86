using gestionbdd;
using MEDIATEK86.Modele;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MEDIATEK86.Dal
{





    /// <summary>
    /// Classe unique qui sert d'intermédiaire entre le controle et la base de données (en faisant appel à bddmanager)
    /// 
    /// </summary>

    public class AccesDonnees
    {

        private BddManager ConnexionBDD;

        private static string connStr = "server=localhost;user=compteacces;database=gestionperso;port=3306;password=Cnedmdp2003!";





        /// <summary>
        /// Teste la connexion pour les identifiants donnés
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>

        public static bool TesterConnexion(string login, string pwd)
        {
            

            string req = "SELECT * FROM responsable WHERE login=@login AND pwd=sha2(@pwd,256)";

            

            Dictionary<string, object> parametres = new Dictionary<string, object>();
            parametres.Add("@login", login);
            parametres.Add("@pwd", pwd);
            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);
            List<object[]> l = curseur.ReqSelect(req, parametres);

            


            if (l.Count() > 0) { return true; }
            else { return false; }
        }


        /// <summary>
        /// Retourne une liste des personnels. 
        /// </summary>
        /// <returns></returns>

        public static List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            string req = "SELECT p.ID as ID, p.IDSERVICE AS IDSERVICE, p.NOM AS NOM, p.PRENOM AS PRENOM, p.TEL AS TEL, p.EMAIL AS EMAIL, s.NOM AS service ";
            req += "FROM personnel p JOIN service s USING (IDSERVICE)";
            req += "ORDER BY NOM, PRENOM;";

            

            gestionbdd.BddManager curseurconnexion = BddManager.GetInstance(connStr);
            List<Object[]> contenu = curseurconnexion.ReqSelect(req, null);

            List<Personnel> listePersonnel = new List<Personnel>();

            foreach (Object[] row in contenu)
            {
                listePersonnel.Add(new Personnel(
                    (int)row[0],
                    (int)row[1],
                    (string)row[2],
                    (string)row[3],
                    (string)row[4],
                    (string)row[5],
                    (string)row[6]

                    ));
            }

            return listePersonnel;
        }


        /// <summary>
        /// Retourne un personnel pour une id donné.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public static Personnel GetUnPersonnel(int index)
        {



            string req = "SELECT p.ID as ID, p.IDSERVICE AS IDSERVICE, p.NOM AS NOM, p.PRENOM AS PRENOM, p.TEL AS TEL, p.EMAIL AS EMAIL, s.NOM AS service ";
            req += "FROM personnel p JOIN service s USING (IDSERVICE) ";
            req += "WHERE p.ID=" + index.ToString() + ";";

            


            gestionbdd.BddManager curseurconnexion = BddManager.GetInstance(connStr);
            Object[] contenu = curseurconnexion.ReqSelect(req, null)[0];

            return new Personnel(
               (int)contenu[0],
               (int)contenu[1],
               (string)contenu[2],
               (string)contenu[3],
               (string)contenu[4],
               (string)contenu[5],
               (string)contenu[6]
               );




        }



        /// <summary>
        /// Retourne l'identifiant du service dans la table service pour un personnel donné.
        /// </summary>
        /// <param name="personnel"></param>
        /// <returns></returns>

        public static int GetIDService(Personnel personnel)
        {
            string req = "SELECT IDSERVICE FROM service ";
            req += "WHERE NOM='" + personnel.Services.ToString() + "';";

            

            gestionbdd.BddManager curseurconnexion = BddManager.GetInstance(connStr);
            List<Object[]> resultat = curseurconnexion.ReqSelect(req, null);

            if (resultat.Count() > 0)
            {
                Object[] contenu = resultat[0];
                return
                    (int)contenu[0];
            }

            else
            {

                //Sinon on renvoie -1 -> le nom de service n'existe pas...

                return -1;
            }



        }


        /// <summary>
        /// Ajoute un personnel dans la base de données.
        /// </summary>
        /// <param name="personnel"></param>

        public static void AddUnPersonnel(Personnel personnel)
        {


            string req = "INSERT INTO personnel VALUES (NULL,@IDSERVICE,@NOM,@PRENOM,@TEL,@EMAIL)";

            Dictionary<string, object> parametres = new Dictionary<string, object>();


            int IDService = GetIDService(personnel);


            

            if (IDService > 0)
            {
                parametres.Add("@IDSERVICE", IDService);
            }
            else
            {
                parametres.Add("@IDSERVICE", 3);

            }

            parametres.Add("@NOM", personnel.Nom);
            parametres.Add("@PRENOM", personnel.Prénom);
            parametres.Add("@TEL", personnel.Téléphone);
            parametres.Add("@EMAIL", personnel.Mail);
            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);
            curseur.ReqUpdate(req, parametres);



        }


        /// <summary>
        /// Édite le personnel dans la base de donnée -> requête UDPATE
        /// </summary>
        /// <param name="personnel"></param>

        public static void EditerUnPersonnel(Personnel personnel)
        {
            int index = personnel.IDpersonnel;


            string req = "UPDATE personnel SET NOM = @NOM, PRENOM = @PRENOM , TEL = @TEL, EMAIL = @EMAIL,IDSERVICE = @IDSERVICE ";
            req += "WHERE ID = @ID";

            

            Dictionary<string, object> parametres = new Dictionary<string, object>();
            parametres.Add("@ID", personnel.IDpersonnel);

            int IDService = GetIDService(personnel);




            if (IDService > 0)
            {
                parametres.Add("@IDSERVICE", IDService);
            }
            else
            {
                parametres.Add("@IDSERVICE", 3);

            }

            parametres.Add("@NOM", personnel.Nom);
            parametres.Add("@PRENOM", personnel.Prénom);
            parametres.Add("@TEL", personnel.Téléphone);
            parametres.Add("@EMAIL", personnel.Mail);
            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);
            curseur.ReqUpdate(req, parametres);
        }


        /// <summary>
        /// Supprime le personnel pour un id donné dans la base de donnée -> requête DELETE
        /// </summary>
        /// <param name="id"></param>

        public static void SupprUnPersonnel(int id)
        {
            string req = "DELETE FROM personnel ";

            req += "WHERE ID = " + id.ToString() + ";";

            


            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@IDPERSONNEL", id);
            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);

            curseur.ReqUpdate(req);

        }



        





        /// <summary>
        /// Renvoie la liste des absences pour une id donnée.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public static List<Absence> GetLesAbsences(int id)
        {


            string req = "SELECT absences.IDABSENCE,absences.IDPERSONNEL,absences.DATEDEBUT,absences.DATEFIN,motif.IDMOTIF ,motif.NOM ";

            req += "FROM absences ";
            req += "JOIN motif ON motif.IDMOTIF = absences.IDMOTIF ";
            
            req += " WHERE absences.IDPERSONNEL = " + id.ToString() + ";";

            

            gestionbdd.BddManager curseurconnexion = BddManager.GetInstance(connStr);
            List<Object[]> contenu = curseurconnexion.ReqSelect(req, null);

            List<Absence> listeAbsences = new List<Absence>();

            foreach (Object[] row in contenu)
            {

                listeAbsences.Add(new Absence((int)row[0], id, (DateTime)row[2], (DateTime)row[3], (int)row[4], (string)row[5]));


            }

            

            return listeAbsences;
        }



        /// <summary>
        /// Renvoie une absence pour un id donné.
        /// </summary>
        /// <param name="idabsence"></param>
        /// <returns></returns>

        public static Absence GetUneAbsence(int idabsence)
        {


            string req = "SELECT absences.IDABSENCE,absences.IDPERSONNEL,absences.DATEDEBUT,absences.DATEFIN,motif.IDMOTIF ,motif.NOM ";

            req += "FROM absences ";
            req += "JOIN motif ON motif.IDMOTIF = absences.IDMOTIF ";
            
            req += " WHERE absences.IDABSENCE = " + idabsence.ToString() + ";";

            

            

            gestionbdd.BddManager curseurconnexion = BddManager.GetInstance(connStr);
            Object[] contenu = curseurconnexion.ReqSelect(req, null)[0];

            return new Absence((int)contenu[0], (int)contenu[1], (DateTime)contenu[2], (DateTime)contenu[3], (int)contenu[4], (string)contenu[5]);



        }


        /// <summary>
        /// Supprimer une absence dont l'ID est donné
        /// </summary>
        /// <param name="idabsence"></param>


        public static void SupprAbsencePersonnel(int idabsence)
        {
            string req = "DELETE FROM absences ";
            req += "WHERE IDABSENCE = ";
            req += idabsence.ToString();

            

            gestionbdd.BddManager connexion = BddManager.GetInstance(connStr);
            connexion.ReqUpdate(req);



        }


        /// <summary>
        /// Modifie une absence existante
        /// Vérifie si le créneau est valide et ne chevauche aucun créneau.
        /// </summary>
        /// <param name="absence"></param>


        public static void AddUneAbsence(Absence absence)
        {

            string req = "INSERT INTO absences VALUES ( NULL , @IDPERSONNEL , @IDMOTIF , @DATEDEBUT , @DATEFIN );";

            string correctFormatDEBUT = absence.Datedebut.ToString("yyyy-MM-dd");
            string correctFormatFIN = absence.Datefin.ToString("yyyy-MM-dd");


            Dictionary<string, object> parametres = new Dictionary<string, object>();
            parametres.Add("@IDPERSONNEL", absence.Idpersonnel);
            parametres.Add("@IDMOTIF", absence.Idmotif);
            parametres.Add("@DATEDEBUT", correctFormatDEBUT);
            parametres.Add("@DATEFIN", correctFormatFIN);



            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);
            
            curseur.ReqUpdate(req,parametres);






        }


        /// <summary>
        /// Modifie une absence existante
        /// Vérifie si le créneau est valide et ne chevauche aucun créneau.
        /// </summary>
        /// <param name="absence"></param>
        public static void EditUneAbsence(Absence absence)
        {

            string req = "UPDATE absences SET IDMOTIF=@IDMOTIF , IDPERSONNEL=@IDPERSONNEL , IDMOTIF=@IDMOTIF , DATEDEBUT=@DATEDEBUT , DATEFIN=@DATEFIN  ";
            req += " WHERE IDABSENCE=@IDABSENCE";

            string correctFormatDEBUT = absence.Datedebut.ToString("yyyy-MM-dd");
            string correctFormatFIN = absence.Datefin.ToString("yyyy-MM-dd");


            Dictionary<string, object> parametres = new Dictionary<string, object>();
            parametres.Add("@IDABSENCE", absence.IdAbsence); 
            parametres.Add("@IDPERSONNEL", absence.Idpersonnel);
            parametres.Add("@IDMOTIF", absence.Idmotif);
            parametres.Add("@DATEDEBUT", correctFormatDEBUT);
            parametres.Add("@DATEFIN", correctFormatFIN);



            gestionbdd.BddManager curseur = BddManager.GetInstance(connStr);

            curseur.ReqUpdate(req, parametres);



        }




    }
}
