using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using GSBFrais.Model.Data;
using GSBFrais.Model;
using GSBFrais.Model.Business;


namespace GSBFrais.Model.Data
{
    public class DaoFicheFrais
    {
        private Dbal _dbal;
        private DaoVisiteurs _daoVisiteur;
        private DaoEtat _daoEtat;
        private DaoLigneFraisForfait _daoLigneFraisForfait;
        private DaoLigneFraisHorsForfait _daoLigneFraisHorsForfait;


        public DaoFicheFrais(Dbal unDbal, DaoVisiteurs unDaoVisiteurs, DaoEtat unDaoEtat, DaoLigneFraisForfait unDaoLigneFraisForfait, DaoLigneFraisHorsForfait unDaoLigneFraisHorsForfait)
        {
            this._dbal = unDbal;
            this._daoVisiteur = unDaoVisiteurs;
            this._daoEtat = unDaoEtat;
            this._daoLigneFraisForfait = unDaoLigneFraisForfait;
            this._daoLigneFraisHorsForfait = unDaoLigneFraisHorsForfait;

        }

        public void Insert(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais (idVisiteur, mois, nbJustificatifs, montantValide, dateModif) VALUES ('" + uneFicheFrais.UnVisiteur.Id + "', '" + uneFicheFrais.Mois + "', " + uneFicheFrais.NbJustificatifs + ", " + uneFicheFrais.MontantValide.ToString(CultureInfo.GetCultureInfo("en-GB")) + ", '" + uneFicheFrais.DateModif.Date.ToString("yyyy-MM-dd") + "')";
            this._dbal.Insert(query);
        }
        public void Delete(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais where idVisiteur = '" + uneFicheFrais.UnVisiteur.Id + "' and mois = '" + uneFicheFrais.Mois + "'";
            this._dbal.Delete(query);
        }
        public void Update(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais SET " + "idVisiteur = '" + uneFicheFrais.UnVisiteur.Id + "' , mois = '" + uneFicheFrais.Mois + "' , nbJustificatifs = '" + uneFicheFrais.NbJustificatifs + "' , montantValide = '" + uneFicheFrais.MontantValide + "' , dateModif = '" + uneFicheFrais.DateModif + "' , idEtat = '" + uneFicheFrais.UnEtat.Id;
            this._dbal.Update(query);
        }
        public List<FicheFrais> SelectAll()
        {
            List<FicheFrais> listeFicheFrais = new List<FicheFrais>();
            DaoVisiteurs daoVisiteur = new DaoVisiteurs(_dbal);
            DataTable maTable = this._dbal.SelectAll("fichefrais");
            foreach (DataRow r in maTable.Rows)
            {

                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                Etat unEtat = _daoEtat.SelectById((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["nbJustificatifs"], (decimal)r["montantValide"], (DateTime)r["dateModif"], unEtat, leVisiteur);
                List<LigneFraisForfait> lesLignesFraisForfaits = new List<LigneFraisForfait>(this._daoLigneFraisForfait.SelectByFicheFrais(uneFicheFrais));
                List<LigneFraisHorsForfait> lesLignesFraisHorsForfaits = new List<LigneFraisHorsForfait>(this._daoLigneFraisHorsForfait.SelectByFicheFrais(uneFicheFrais));
                uneFicheFrais.LesLignesFraisForfait = lesLignesFraisForfaits;
                uneFicheFrais.LesLigneFraisHorsForfait = lesLignesFraisHorsForfaits;
                listeFicheFrais.Add(uneFicheFrais);
            }
            return listeFicheFrais;
        }
        //SELECT DISTINCT(mois) FROM Fichefrais OrderBY mois desc
        public List<FicheFrais> SelectByMonth(string moisFiche)
        {
            List<FicheFrais> listeFicheFrais = new List<FicheFrais>();
            DataTable maTable = new DataTable();
            DaoVisiteurs daoVisiteur = new DaoVisiteurs(_dbal);
            maTable = this._dbal.SelectByField("fichefrais", "mois = '" + moisFiche + "'");
            foreach (DataRow r in maTable.Rows)
            {

                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                Etat unEtat = _daoEtat.SelectById((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["nbJustificatifs"], (decimal)r["montantValide"], (DateTime)r["dateModif"], unEtat, leVisiteur);
                List<LigneFraisForfait> lesLignesFraisForfaits = new List<LigneFraisForfait>(this._daoLigneFraisForfait.SelectByFicheFrais(uneFicheFrais));
                List<LigneFraisHorsForfait> lesLignesFraisHorsForfaits = new List<LigneFraisHorsForfait>(this._daoLigneFraisHorsForfait.SelectByFicheFrais(uneFicheFrais));
                uneFicheFrais.LesLignesFraisForfait = lesLignesFraisForfaits;
                uneFicheFrais.LesLigneFraisHorsForfait = lesLignesFraisHorsForfaits;
                listeFicheFrais.Add(uneFicheFrais);
            }
            return listeFicheFrais;
        }

        public FicheFrais SelectByVisiteurMois(Visiteur unVisiteur, string moisFiche)
        {
            DataRow r = this._dbal.SelectByPK2("fichefrais ", "idVisiteur", unVisiteur.Id, "mois", moisFiche);
            if(r != null)
            {
                Etat unEtat = _daoEtat.SelectByName((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["NbJustificatifs"], (decimal)r["unMontantValide"], (DateTime)r["uneDateModif"], (Etat)r["leEtat"], (Visiteur)r["Visiteur"]);
                return uneFicheFrais;
            }else
            {
                return null;

            }

            

        }
        public List<string> SelectListMois()
        {
            List<string> listeMois = new List<string>();

            DataTable maTable = this._dbal.SelectDistinctByField("mois", "fichefrais", "desc");
            foreach (DataRow r in maTable.Rows)
            {

                listeMois.Add((string)r["mois"]);
            }
            return listeMois;

        }

    }
}
