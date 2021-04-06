/*
 * Classe : Livre
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente nos livres.  La classe contient ses infos (no de serie, titre, quantite, date de publication, auteur(e))  
 */

using System;

/// <summary>
/// Namespace pour les Modèles de l'application
/// </summary>
namespace gestionCRSBP.Models
{
    /// <summary>
    /// Classe qui permet de représenter un livre
    /// </summary>
    public class Livre
    {
        /// <summary>
        /// Chaîne de caractère représentant le no de serie
        /// </summary>
        private string noSerie;
        /// <summary>
        /// Propriété permettant d'accéder au no de serie (GETTER/SETTER)
        /// </summary>
        public string NoSerie
        {
            get { return (noSerie); }
            set { noSerie = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant le titre
        /// </summary>
        private string titre;
        /// <summary>
        /// Propriété permettant d'accéder au titre (GETTER/SETTER)
        /// </summary>
        public string Titre
        {
            get { return (titre); }
            set { titre = value; }
        }

        /// <summary>
        /// Integer représentant la quantite
        /// </summary>
        private int qte;
        /// <summary>
        /// Propriété permettant d'accéder à la quantite (GETTER/SETTER)
        /// </summary>
        public int Qte
        {
            get { return (qte); }
            set { qte = value; }
        }

        /// <summary>
        /// DateTime représentant la date de publication
        /// </summary>
        private DateTime datePublication;
        /// <summary>
        /// Propriété permettant d'accéder à la date de publication(GETTER/SETTER)
        /// </summary>
        public DateTime DatePublication
        {
            get { return (datePublication); }
            set { datePublication = value; }
        }

        /// <summary>
        /// Chaîne de caractère représentant l'auteur(e)
        /// </summary>
        private string auteur;
        /// <summary>
        /// Propriété permettant d'accéder à l'auteur(e) (GETTER/SETTER)
        /// </summary>
        public string Auteur
        {
            get { return (auteur); }
            set { auteur = value; }
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode()
        /// </summary>
        /// <returns>le code hash</returns>
        public override int GetHashCode()
        {
            return NoSerie.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals
        /// </summary>
        /// <returns>true si unique, sinon false</returns>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Livre) && (NoSerie.Equals((obj as Livre).NoSerie)));
        }
    }
}
