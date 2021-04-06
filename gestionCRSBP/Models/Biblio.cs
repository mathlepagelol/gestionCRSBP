/*
 * Classe : Biblio
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

using System.Collections.Generic;

/// <summary>
/// Namespace pour les Modèles de l'application
/// </summary>
namespace gestionCRSBP.Models
{
    /// <summary>
    /// Classe qui permet de représenter une biblio 
    /// </summary>
    public class Biblio
    {
        /// <summary>
        /// Chaîne de caractère représentant le nom de la bibliothèque
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété permettant d'accéder au nom de la biblio (GETTER/SETTER)
        /// </summary>
        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant l'adresse de la bibliothèque
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété permettant d'accéder à l'adresse de la biblio (GETTER/SETTER)
        /// </summary>
        public string Adresse
        {
            get { return (adresse); }
            set { adresse = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le téléphone de la bibliothèque
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété permettant d'accéder au téléphone de la biblio (GETTER/SETTER)
        /// </summary>
        public string Telephone
        {
            get { return (telephone); }
            set { telephone = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le code postal de la bibliothèque
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété permettant d'accéder au code postal de la biblio (GETTER/SETTER)
        /// </summary>
        public string CodePostal
        {
            get { return (codePostal); }
            set { codePostal = value; }
        }

        /// <summary>
        /// List<Employe> représentant la liste des employes de la bibliothèque
        /// </summary>
        public List<Employe> listeEmploye;

        /// <summary>
        /// List<Membre> représentant la liste des membres de la bibliothèque
        /// </summary>
        public List<Membre> listeMembre;

        /// <summary>
        /// List<Livre> représentant la liste des livres de la bibliothèque
        /// </summary>
        public List<Livre> listeLivre;

        /// <summary>
        /// List<Location> représentant la liste des locations de la bibliothèque
        /// </summary>
        public List<Location> listeLocation;

        /// <summary>
        /// Constructeur vide nécessaire à la serialization XML
        /// </summary>
        public Biblio() { }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="unTelephone"></param>
        /// <param name="unCodePostal"></param>
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

        /// <summary>
        /// Permet d'obtenir un membre par son NoMembre
        /// </summary>
        /// <param name="unMembre"></param>
        /// <returns>Membre unMembre</returns>
        public Membre ObtenirMembre(Membre unMembre)
        {
            foreach (Membre membre in listeMembre)
            {
                if (membre.Equals(unMembre))
                    return membre;
            }
            return null;
        }

        /// <summary>
        /// Permet d'obtenir la liste des membres
        /// </summary>
        /// <returns>Membre[] lesMembres</returns>
        public Membre[] ObtenirListeMembre()
        {
            return listeMembre.ToArray();
        }

        /// <summary>
        /// Permet d'obtenir un employe par son NoEmploye
        /// </summary>
        /// <param name="unEmploye"></param>
        /// <returns>Employe unEmploye</returns>
        public Employe ObtenirEmploye(Employe unEmploye)
        {
            foreach (Employe employe in listeEmploye)
            {
                if (employe.Equals(unEmploye))
                    return employe;
            }
            return null;
        }

        /// <summary>
        /// Permet d'obtenir la liste des employes
        /// </summary>
        /// <returns>Employe[] mesEmployes</returns>
        public Employe[] ObtenirListeEmploye()
        {
            return listeEmploye.ToArray();
        }
        
        /// <summary>
        /// Permet d'obtenir un live par son NoSerie
        /// </summary>
        /// <param name="unLivre"></param>
        /// <returns>Livre unLivre</returns>
        public Livre ObtenirLivre(Livre unLivre)
        {
            foreach (Livre livre in listeLivre)
            {
                if (livre.Equals(unLivre))
                    return livre;
            }
            return null;
        }

        /// <summary>
        /// Permet d'obtenir la liste des livres
        /// </summary>
        /// <returns>Livre[] mesLivres</returns>
        public Livre[] ObtenirListeLivre()
        {
            return listeLivre.ToArray();
        }

        /// <summary>
        /// Permet d'obtenir la liste de locations
        /// </summary>
        /// <returns>Location[] mesLocations</returns>
        public Location[] ObtenirListeLocation()
        {
            return listeLocation.ToArray();
        }

        /// <summary>
        /// Permet d'obtenir une location par son NoLocation
        /// </summary>
        /// <param name="uneLocation"></param>
        /// <returns>Location[] mesLocations</returns>
        public Location ObtenirLocation(Location uneLocation)
        {
            foreach (Location location in listeLocation)
            {
                if (location.Equals(uneLocation))
                    return location;
            }
            return null;
        }

        /// <summary>
        /// Permet d'enlever un employe de la liste
        /// </summary>
        /// <param name="unEmploye"></param>
        /// <returns>true si l'ajout a été fait sinon false</returns>
        public bool EnleverEmploye(Employe unEmploye)
        {
            if (!SiEmployePresent(unEmploye))
                return false;
            listeEmploye.Remove(unEmploye);
            return !SiEmployePresent(unEmploye);
        }

        /// <summary>
        /// Permet d'enlever un membre de la liste
        /// </summary>
        /// <param name="unMembre"></param>
        /// <returns>true si la supression a été fait sinon false</returns>
        public bool EnleverMembre(Membre unMembre)
        {
            if (!SiMembrePresent(unMembre))
                return false;
            listeMembre.Remove(unMembre);
            return !SiMembrePresent(unMembre);
        }

        /// <summary>
        /// Permet d'enlever un livre de la liste
        /// </summary>
        /// <param name="unLivre"></param>
        /// <returns>true si la surpression a été fait, sinon false</returns>
        public bool EnleverLivre(Livre unLivre)
        {
            if (!SiLivrePresent(unLivre))
                return false;
            listeLivre.Remove(unLivre);
            return !SiLivrePresent(unLivre);
        }

        /// <summary>
        /// Permet d'enlever un livre de la liste
        /// </summary>
        /// <param name="uneLocation"></param>
        /// <returns>true si la supression a été fait, sinon false</returns>
        public bool EnleverLocation(Location uneLocation)
        {
            if (!SiLocationPresent(uneLocation))
                return false;
            listeLocation.Remove(uneLocation);
            return !SiLocationPresent(uneLocation);
        }

        /// <summary>
        /// Permet de vérifier si un employe est présent dans la liste
        /// </summary>
        /// <param name="unEmploye"></param>
        /// <returns>true si présent sinon false</returns>
        public bool SiEmployePresent(Employe unEmploye)
        {
            foreach (Employe employe in listeEmploye)
            {
                if (employe.Equals(unEmploye))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de vérifier si un membre est présent dans la liste
        /// </summary>
        /// <param name="unMembre"></param>
        /// <returns>true si présent, sinon false</returns>
        public bool SiMembrePresent(Membre unMembre)
        {
            foreach (Membre membre in listeMembre)
            {
                if (membre.Equals(unMembre))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de vérifier si un livre est présent dans la liste
        /// </summary>
        /// <param name="unLivre"></param>
        /// <returns>true si présent, sinon false</returns>
        public bool SiLivrePresent(Livre unLivre)
        {
            foreach (Livre livre in listeLivre)
            {
                if (livre.Equals(unLivre))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de vérifier si une location est présente dans la liste
        /// </summary>
        /// <param name="uneLocation"></param>
        /// <returns>true si présente, sinon false</returns>
        public bool SiLocationPresent(Location uneLocation)
        {
            foreach (Location location in listeLocation)
            {
                if (location.Equals(uneLocation))
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Redéfinition de la méthode GetHashCode()
        /// </summary>
        /// <returns>le code hash</returns>
        public override int GetHashCode()
        {
            return Telephone.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si unique, sinon false</returns>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Biblio) && (Telephone.Equals((obj as Biblio).Telephone)));
        }
    }
}
