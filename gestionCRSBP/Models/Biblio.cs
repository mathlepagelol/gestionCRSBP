/*
 * Classe : Traversier 
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente notre bibliothèque.  La classe contient ses infos personnelles (nom, adresse, telephone, code postal, province)
 *        une liste de tous ses membres, ses employes et de ses livres en inventaire.    
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    public class Biblio
    {
        private string nom;
        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
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

        public List<Employe> listeEmploye;
        public List<Membre> listeMembre;
        public List<Livre> listeLivre;
        public List<Location> listeLocation;

        public Biblio()
        { }

        public Biblio(string unNom, string uneAdresse, string unTelephone, string unCodePostal)
        {
            this.Nom = unNom;
            this.Adresse = uneAdresse;
            this.Telephone = unTelephone;
            this.CodePostal = unCodePostal;
            this.listeEmploye = new List<Employe>();
            this.listeMembre = new List<Membre>();
            this.listeLivre = new List<Livre>();
            this.listeLocation = new List<Location>();
        }

        public Membre ObtenirMembre(Membre unMembre)
        {
            foreach (Membre membre in listeMembre)
            {
                if (membre.Equals(unMembre))
                    return membre;
            }
            return null;
        }

        public Membre[] ObtenirListeMembre()
        {
            return listeMembre.ToArray();
        }

        public Employe ObtenirEmploye(Employe unEmploye)
        {
            foreach (Employe employe in listeEmploye)
            {
                if (employe.Equals(unEmploye))
                    return employe;
            }
            return null;
        }

        public Employe[] ObtenirListeEmploye()
        {
            return listeEmploye.ToArray();
        }

        public Livre ObtenirLivre(Livre unLivre)
        {
            foreach (Livre livre in listeLivre)
            {
                if (livre.Equals(unLivre))
                    return livre;
            }
            return null;
        }

        public Livre[] ObtenirListeLivre()
        {
            return listeLivre.ToArray();
        }

        public Location[] ObtenirListeLocation()
        {
            return listeLocation.ToArray();
        }

        public Location ObtenirLocation(Location uneLocation)
        {
            foreach (Location location in listeLocation)
            {
                if (location.Equals(uneLocation))
                    return location;
            }
            return null;
        }

        public bool EnleverEmploye(Employe unEmploye)
        {
            if (!SiEmployePresent(unEmploye))
                return false;
            listeEmploye.Remove(unEmploye);
            return !SiEmployePresent(unEmploye);
        }

        public bool EnleverMembre(Membre unMembre)
        {
            if (!SiMembrePresent(unMembre))
                return false;
            listeMembre.Remove(unMembre);
            return !SiMembrePresent(unMembre);
        }

        public bool EnleverLivre(Livre unLivre)
        {
            if (!SiLivrePresent(unLivre))
                return false;
            listeLivre.Remove(unLivre);
            return !SiLivrePresent(unLivre);
        }

        public bool EnleverLocation(Location uneLocation)
        {
            if (!SiLocationPresent(uneLocation))
                return false;
            listeLocation.Remove(uneLocation);
            return !SiLocationPresent(uneLocation);
        }

        public bool SiEmployePresent(Employe unEmploye)
        {
            foreach (Employe employe in listeEmploye)
            {
                if (employe.Equals(unEmploye))
                    return true;
            }
            return false;
        }

        public bool SiMembrePresent(Membre unMembre)
        {
            foreach (Membre membre in listeMembre)
            {
                if (membre.Equals(unMembre))
                    return true;
            }
            return false;
        }

        public bool SiLivrePresent(Livre unLivre)
        {
            foreach (Livre livre in listeLivre)
            {
                if (livre.Equals(unLivre))
                    return true;
            }
            return false;
        }

        public bool SiLocationPresent(Location uneLocation)
        {
            foreach (Location location in listeLocation)
            {
                if (location.Equals(uneLocation))
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Telephone.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Biblio) && (Telephone.Equals((obj as Biblio).Telephone)));
        }
    }
}
