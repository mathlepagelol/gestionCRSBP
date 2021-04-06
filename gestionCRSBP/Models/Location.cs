/*
 * Classe : Location
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente nos locations.  La classe contient ses infos (no de location, date de debut, date de fin), un membre, un employe et une liste  de livre.  
 */

using System;
using System.Collections.Generic;

/// <summary>
/// Namespace pour les Modèles de l'application
/// </summary>
namespace gestionCRSBP.Models
{
    /// <summary>
    /// Classe qui permet de représenter une location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Chaîne de caractère représentant le no de location
        /// </summary>
        private string noLocation;
        /// <summary>
        /// Propriété permettant d'accéder au no de location (GETTER/SETTER)
        /// </summary>
        public string NoLocation
        {
            get { return (noLocation); }
            set { noLocation = value; }
        }

        /// <summary>
        /// DateTime représentant la date de debut
        /// </summary>
        private DateTime dateDebut;
        /// <summary>
        /// Propriété permettant d'accéder la date de debut (GETTER/SETTER)
        /// </summary>
        public DateTime DateDebut
        {
            get { return (dateDebut); }
            set { dateDebut = value; }
        }

        /// <summary>
        /// DateTime représentant la date de fin
        /// </summary>
        private DateTime dateFin;
        /// <summary>
        /// Propriété permettant d'accéder la date de fin (GETTER/SETTER)
        /// </summary>
        public DateTime DateFin
        {
            get { return (dateFin); }
            set { dateFin = value; }
        }

        /// <summary>
        /// Objet qui représente notre membre
        /// </summary>
        public Membre unMembre { get; set; }
        /// <summary>
        /// Objet qui représente notre employe
        /// </summary>
        public Employe unEmploye { get; set; }

        /// <summary>
        /// List<Livre> représentant la liste des livres de la location
        /// </summary>
        public List<Livre> listeLivre = new List<Livre>();

        /// <summary>
        /// Permet de retourner le membre de la location
        /// </summary>
        /// <returns>Membre this.membre</returns>
        public Membre ObtenirMembre()
        {
            return unMembre;
        }

        /// <summary>
        /// Permet de retourner l'employe de la location
        /// </summary>
        /// <returns>Employe this.employe</returns>
        public Employe ObtenirEmploye()
        {
            return unEmploye;
        }

        /// <summary>
        /// Permet de retourner la liste de livre d'une location
        /// </summary>
        /// <returns>Livre[] listeLivre</returns>
        public Livre[] ObtenirListeLivre()
        {
            return listeLivre.ToArray();
        }

        /// <summary>
        /// Permet d'ajouter un livre à la liste d'une location
        /// </summary>
        /// <param name="unLivre"></param>
        public void AjouterLivre(Livre unLivre)
        {
            //if (SiLivrePresent(unLivre))
            //    return false;
            listeLivre.Add(unLivre);
        }

        /// <summary>
        /// Permet d'obtenir un livre spécifique dans la liste de livre d'une location
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
        /// Permet de supprimer un livre d'une liste de location
        /// </summary>
        /// <param name="unLivre"></param>
        public void EnleverLivre(Livre unLivre)
        {
            //if (!SiLivrePresent(unLivre))
            //    return false;
            listeLivre.Remove(unLivre);
        }

        //public bool SiLivrePresent(Livre unLivre)
        //{
        //    foreach (Livre livre in listeLivre)
        //    {
        //        if (livre.Equals(unLivre))
        //            return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Redéfinition de la méthode GetHashCode()
        /// </summary>
        /// <returns>le code hash</returns>
        public override int GetHashCode()
        {
            return NoLocation.GetHashCode();
        }
        /// <summary>
        /// Redéfinition de la méthode Equals()
        /// </summary>
        /// <returns>true si unique, sinon false</returns>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Location) && (NoLocation.Equals((obj as Location).NoLocation)));
        }
    }
}
