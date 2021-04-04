using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    public class Location
    {
        private string noLocation;
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
