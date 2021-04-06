/*
 * Classe : Membre
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente nos membres.  La classe contient ses infos personnelles (no membre, nom, prenom, adresse, telephone, code postal). 
 */

/// <summary>
/// Namespace pour les Modèles de l'application
/// </summary>
namespace gestionCRSBP.Models
{
    /// <summary>
    /// Classe qui permet de représenter un membre
    /// </summary>
    public class Membre
    {
        /// <summary>
        /// Chaîne de caractère représentant le no du membre
        /// </summary>
        private string noMembre;
        /// <summary>
        /// Propriété permettant d'accéder au no du membre (GETTER/SETTER)
        /// </summary>
        public string NoMembre
        {
            get { return (noMembre); }
            set { noMembre = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le nom du membre
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété permettant d'accéder au nom du membre (GETTER/SETTER)
        /// </summary>
        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le prenom du membre
        /// </summary>
        private string prenom;
        /// <summary>
        /// Propriété permettant d'accéder au prenom du membre (GETTER/SETTER)
        /// </summary>
        public string Prenom
        {
            get { return (prenom); }
            set { prenom = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant l'adresse du membre
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété permettant d'accéder à l'adresse du membre (GETTER/SETTER)
        /// </summary>
        public string Adresse
        {
            get { return (adresse); }
            set { adresse = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le telephone du membre
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété permettant d'accéder au telephone du membre (GETTER/SETTER)
        /// </summary>
        public string Telephone
        {
            get { return (telephone); }
            set { telephone = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le code postal du membre
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété permettant d'accéder au code postal du membre (GETTER/SETTER)
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
            return NoMembre.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals
        /// </summary>
        /// <returns>true si unique, sinon false</returns>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Membre) && (NoMembre.Equals((obj as Membre).NoMembre)));
        }
    }
}
