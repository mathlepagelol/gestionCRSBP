using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    public class Membre
    {
        private string noMembre;
        public string NoMembre
        {
            get { return (noMembre); }
            set { noMembre = value; }
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

        public List<Location> listeLocation = new List<Location>();

        public override int GetHashCode()
        {
            return NoMembre.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Membre) && (NoMembre.Equals((obj as Membre).NoMembre)));
        }
    }
}
