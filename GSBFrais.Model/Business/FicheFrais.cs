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



        public FicheFrais(string unMois, int unNbJustificatifs, decimal unMontantValide, DateTime uneDateModif, Etat leEtat, Visiteur Visiteur, FicheFrais FicheFrais)
        {
            
            this.Mois = unMois;
            this.NbJustificatifs = unNbJustificatifs;
            this.MontantValide = unMontantValide;
            this.DateModif = uneDateModif;
            this.UnEtat = leEtat;
            this.UnVisiteur = Visiteur;
        }
        public FicheFrais(string unMois, int unNbJustificatifs, decimal unMontantValide, DateTime uneDateModif, Etat leEtat, Visiteur Visiteur)
        {

            this.Mois = unMois;
            this.NbJustificatifs = unNbJustificatifs;
            this.MontantValide = unMontantValide;
            this.DateModif = uneDateModif;
            this.UnEtat = leEtat;
            this.UnVisiteur = Visiteur;
        }

   
        public Etat UnEtat { get; set; }
        public decimal MontantValide { get; set; }
        public int NbJustificatifs { get; set; }
        public DateTime DateModif { get; set; }
        

        public List<LigneFraisForfait> LesLignesFraisForfait { get; set; }
        public List<LigneFraisHorsForfait> LesLigneFraisHorsForfait { get; set; }

        public Visiteur UnVisiteur { get; set; }
       
        public string Mois { get; set; }
       
        public override string ToString()
        {
            return UnVisiteur.Nom + " - " + UnVisiteur.Prenom + " - " + Mois;
        }
    }
}
