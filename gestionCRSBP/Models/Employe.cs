using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    public class Employe
    {
        private string noEmploye;
        public string NoEmploye
        {
            get { return (noEmploye); }
            set { noEmploye = value; }
        }
        private string nom;
        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
        }
        private string prenom;
        public string Prenom
        {
            get { return (prenom); }
            set { prenom = value; }
        }

        private string adresse;
        public string Adresse
        {
            get { return (adresse); }
            set { adresse = value; }
        }

        private string telephone;
        public string Telephone
        {
            get { return (telephone); }
            set { telephone = value; }
        }

        private string codePostal;
        public string CodePostal
        {
            get { return (codePostal); }
            set { codePostal = value; }
        }

        public override int GetHashCode()
        {
            return NoEmploye.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Employe) && (NoEmploye.Equals((obj as Employe).NoEmploye)));
        }
    }
}
