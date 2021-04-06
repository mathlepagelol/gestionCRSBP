/*
 * Classe : Employe
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente nos employes.  La classe contient ses infos personnelles (no d'employe, nom, adresse, telephone, code postal)  
 */

/// <summary>
/// Namespace pour les Modèles de l'application
/// </summary>
namespace gestionCRSBP.Models
{
    /// <summary>
    /// Classe qui permet de représenter un employe
    /// </summary>
    public class Employe
    {
        /// <summary>
        /// Chaîne de caractère représentant le no de l'employe
        /// </summary>
        private string noEmploye;
        /// <summary>
        /// Propriété permettant d'accéder au no de l'employe (GETTER/SETTER)
        /// </summary>
        public string NoEmploye
        {
            get { return (noEmploye); }
            set { noEmploye = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le nom de l'employe
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété permettant d'accéder au nom de l'employe (GETTER/SETTER)
        /// </summary>
        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le prenom de l'employe
        /// </summary>
        private string prenom;
        /// <summary>
        /// Propriété permettant d'accéder au prenom de l'employe (GETTER/SETTER)
        /// </summary>
        public string Prenom
        {
            get { return (prenom); }
            set { prenom = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant l'adresse de l'employe
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété permettant d'accéder à l'adresse de l'employe (GETTER/SETTER)
        /// </summary>
        public string Adresse
        {
            get { return (adresse); }
            set { adresse = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le telephone de l'employe
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété permettant d'accéder au telephone de l'employe (GETTER/SETTER)
        /// </summary>
        public string Telephone
        {
            get { return (telephone); }
            set { telephone = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le code postal de l'employe
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété permettant d'accéder au code postal de l'employe (GETTER/SETTER)
        /// </summary>
        public string CodePostal
        {
            get { return (codePostal); }
            set { codePostal = value; }
        }

        /// <summary>
        /// Redéfinition de la méthode ToSring()
        /// </summary>
        /// <returns>return le string de l'objet</returns>
        public override string ToString()
        {
            return (Prenom+" "+Nom);
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode()
        /// </summary>
        /// <returns>le code hash</returns>
        public override int GetHashCode()
        {
            return NoEmploye.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals
        /// </summary>
        /// <returns>true si unique, sinon false</returns>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Employe) && (NoEmploye.Equals((obj as Employe).NoEmploye)));
        }
    }
}
