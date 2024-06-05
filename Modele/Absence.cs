using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEDIATEK86.Modele
{
   
    /// <summary>
    /// Classe modélisant une absence
    /// </summary>


    public class Absence
    {

        private int IDABSENCE;
        private int IDPERSONNEL;
        private DateTime DATEDEBUT;
        private DateTime DATEFIN;
        private int IDMOTIF; 
        private string NONMOTIF;

        /// <summary>
        /// Classe représenant une absence dans le modèle
        /// </summary>

        public Absence(int IDABSENCE,int IDPERSONNEL,DateTime DATEDEBUT, DateTime DATEFIN,int IDMOTIF,string NOMMOTIF)
        {
            this.IDABSENCE = IDABSENCE;
            this.IDPERSONNEL = IDPERSONNEL;
            this.DATEDEBUT = DATEDEBUT;
            this.DATEFIN = DATEFIN;
            this.IDMOTIF = IDMOTIF;
            this.NONMOTIF = NOMMOTIF;
        }

        

        public int Idpersonnel { get => IDPERSONNEL; set => IDPERSONNEL = value; }
        public DateTime Datedebut { get => DATEDEBUT; set => DATEFIN = value; } 
        public DateTime Datefin { get => DATEFIN; set => DATEFIN = value; }
        public int Idmotif { get => IDMOTIF; set => IDMOTIF = value; }

        public int IdAbsence { get => IDABSENCE; set => IDABSENCE = value ; }

        public int IdMotif { get => IDMOTIF; set => IDMOTIF = value; }

        public string NomMotif { get => NONMOTIF; set => NONMOTIF = value; }

    }
}
