using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    public class Livre
    {
        private string noSerie;
        public string NoSerie
        {
            get { return (noSerie); }
            set { noSerie = value; }
        }
        private string titre;
        public string Titre
        {
            get { return (titre); }
            set { titre = value; }
        }
        private string qte;
        public string Qte
        {
            get { return (qte); }
            set { qte = value; }
        }

        private string datePublication;
        public string DatePublication
        {
            get { return (datePublication); }
            set { datePublication = value; }
        }

        private string auteur;
        public string Auteur
        {
            get { return (auteur); }
            set { auteur = value; }
        }

        public override int GetHashCode()
        {
            return NoSerie.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ((obj != null) && (obj is Livre) && (NoSerie.Equals((obj as Livre).NoSerie)));
        }
    }
}
