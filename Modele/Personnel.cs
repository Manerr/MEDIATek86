using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEDIATEK86.Modele
{

    /// <summary>
    /// Classe modélisant un personnel
    /// </summary>

    public class Personnel
    {
        private int IDPERSONNEL;
        private int IDSERVICE;
        private string NOM;
        private string PRENOM;
        private string TEL;
        private string MAIL;
        private string service;

        /// <summary>
        /// Classe représenant un personnel dans le modèle
        /// </summary>

        public Personnel(int IDPERSONNEL, int IDSERVICE, string NOM, string PRENOM, string TEL, string MAIL, string service)
        {
            this.IDPERSONNEL = IDPERSONNEL;
            this.IDSERVICE = IDSERVICE;
            this.NOM = NOM;
            this.PRENOM = PRENOM;
            this.TEL = TEL;
            this.MAIL = MAIL;
            this.service = service;
        }

 

        public int IDpersonnel { get => IDPERSONNEL; set => IDPERSONNEL = value; }
        public int IDservice { get => IDSERVICE; set => IDSERVICE = value; }
        public string Nom { get => NOM; set => NOM = value; }
        public string Prénom { get => PRENOM; set => PRENOM = value ; }
        public string Téléphone { get => TEL; set => TEL = value;  }
        public string Mail { get => MAIL; set => MAIL = value; }
        public string Services { get => service; set => service = value;  }

    }

}
