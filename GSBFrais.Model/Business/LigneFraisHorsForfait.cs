using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Business
{
    public class LigneFraisHorsForfait
    {
        private int id;
        private string libelle;
        private DateTime date;
        private decimal montant;
        private FicheFrais fichefrais;

        public LigneFraisHorsForfait(int unId, string unLibelle, DateTime uneDate, decimal unMontant)
        {
            this.Id = unId;
            this.Libelle = unLibelle;
            this.Date = uneDate;
            this.Montant = unMontant;
        }
        public LigneFraisHorsForfait(FicheFrais uneFicheFrais, int unId, string unLibelle, DateTime uneDate, decimal unMontant)
        {

            this.fichefrais = uneFicheFrais;
            this.Id = unId;
            this.Libelle = unLibelle;
            this.Date = uneDate;
            this.Montant = unMontant;
            
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        

        

        public string Libelle
        {
            get
            {
                return libelle;
            }

            set
            {
                libelle = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public decimal Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
            }
        }

        public FicheFrais Fichefrais
        {
            get
            {
                return fichefrais;
            }

            set
            {
                fichefrais = value;
            }
        }
    }
}
