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


        private DateTime dateDebut;
        public DateTime DateDebut
        {
            get { return (dateDebut); }
            set { dateDebut = value; }
        }


        private DateTime dateFin;
        public DateTime DateFin
        {
            get { return (dateFin); }
            set { dateFin = value; }
        }

        public Membre unMembre { get; set; }
        public Employe unEmploye { get; set; }

        public List<Livre> listeLivre = new List<Livre>();

        public Membre ObtenirMembre()
        {
            return unMembre;
        }

        public Employe ObtenirEmploye()
        {
            return unEmploye;
        }

        public Livre[] ObtenirListeLivre()
        {
            return listeLivre.ToArray();
        }

        public void AjouterLivre(Livre unLivre)
        {
            //if (SiLivrePresent(unLivre))
            //    return false;
            listeLivre.Add(unLivre);
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

        public override int GetHashCode()
        {
            return NoLocation.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Location) && (NoLocation.Equals((obj as Location).NoLocation)));
        }
    }
}
