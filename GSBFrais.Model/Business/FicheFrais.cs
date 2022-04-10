using GSBFrais.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Business
{
    public class FicheFrais
    {
        private Visiteur unVisiteur;
        private string mois;
        private Etat unEtat;
        private decimal montantValide;
        private int nbJustificatifs;
        private DateTime dateModif;
        private DateTime dateTime;



        public FicheFrais(string unMois, int unNbJustificatifs, decimal unMontantValide, DateTime uneDateModif, Etat unEtat, Visiteur Visiteur, FicheFrais FicheFrais)
        {
            
            this.Mois = unMois;
            this.NbJustificatifs = unNbJustificatifs;
            this.montantValide = unMontantValide;
            this.dateTime = uneDateModif;
            this.unEtat = unEtat;
            this.UnVisiteur = Visiteur;
        }
        public FicheFrais(string unMois, int unNbJustificatifs, decimal unMontantValide, DateTime uneDateModif, Etat unEtat, Visiteur Visiteur)
        {

            this.Mois = unMois;
            this.NbJustificatifs = unNbJustificatifs;
            this.montantValide = unMontantValide;
            this.dateTime = uneDateModif;
            this.unEtat = unEtat;
            this.UnVisiteur = Visiteur;
        }

   
        public Etat UnEtat { get; set; }
        public decimal MontantValide { get; set; }
        public int NbJustificatifs { get; set; }
        public DateTime DateModif { get; set; }
        

        public List<LigneFraisForfait> LesLignesFraisForfait { get; set; }
        public List<LigneFraisHorsForfait> LesLigneFraisHorsForfait { get; set; }

        public Visiteur UnVisiteur
        {
            get
            {
                return unVisiteur;
            }

            set
            {
                unVisiteur = value;
            }
        }

        public string Mois
        {
            get
            {
                return mois;
            }

            set
            {
                mois = value;
            }
        }

        public override string ToString()
        {
            return UnVisiteur.Nom + " - " + UnVisiteur.Prenom + " - " + Mois;
        }
    }
}
