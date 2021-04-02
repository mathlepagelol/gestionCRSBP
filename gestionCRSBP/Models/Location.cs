using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCRSBP.Models
{
    class Location
    {
        private string noLocation;
        public string NoLocation
        {
            get { return (noLocation); }
            set { noLocation = value; }
        }

        private string dateDebut;
        public string DateDebut
        {
            get { return (dateDebut); }
            set { dateDebut = value; }
        }

        private string dateFin;
        public string DateFin
        {
            get { return (dateFin); }
            set { dateFin = value; }
        }

        public Membre unMembre;
        public Employe unEmploye;
        public List<Livre> listeLivre = new List<Livre>();
    }
}
