using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Business
{
    public class LigneFraisForfait
    {

        private int quantite;
        private FraisForfait fraisforfait;
        private FicheFrais fichefrais;

        public LigneFraisForfait(int uneQuantite, FraisForfait unFraisForfait, FicheFrais uneFichefrais)
        {
            this.quantite = uneQuantite;
            this.Fraisforfait = unFraisForfait;
            this.Fichefrais = uneFichefrais;
        }

      

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
        }

       

        public FraisForfait Fraisforfait
        {
            get
            {
                return fraisforfait;
            }

            set
            {
                fraisforfait = value;
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