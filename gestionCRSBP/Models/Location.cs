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

        public Membre unMembre;
        public Employe unEmploye;
        public List<Livre> listeLivre = new List<Livre>();

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
