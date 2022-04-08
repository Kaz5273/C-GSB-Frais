using GSBFrais.Model.Business;
using GSBFrais.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Data
{
    public class DaoLigneFraisHorsForfait
    {
        private Dbal unDbal;
        private DaoFraisForfait _daoFraisForfait;
        private DaoVisiteurs _daoVisiteur;
        private DaoFicheFrais _daoFicheFrais;

        public DaoLigneFraisHorsForfait(Dbal myDbal, DaoFraisForfait unDaoFraisForfait, DaoVisiteurs unDaoVisiteur, DaoFicheFrais unDaoFicheFrais)
        {
            this.unDbal = myDbal;
            this._daoFraisForfait = unDaoFraisForfait;
            this._daoVisiteur = unDaoVisiteur;
            this._daoFicheFrais = unDaoFicheFrais;
        }

        public void Insert(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quantite) VALUES ('" + LigneFraisHorsForfait.Id + "',' " + LigneFraisHorsForfait.Fichefrais+ "','" + LigneFraisHorsForfait.Fichefrais+ "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quantite) SET '" + LigneFraisHorsForfait.Fichefrais + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisHorsForfait  WHERE idVisiteur = '" + LigneFraisHorsForfait.Fichefrais.UnVisiteur.Id + "' AND id ='" + LigneFraisHorsForfait.Id + "'";
            this.unDbal.Delete(query);
        }

        public List<LigneFraisHorsForfait> SelectAll()
        {
            List<LigneFraisHorsForfait> listLigneFraisForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisHorsForfait");


            foreach (DataRow r in myTable.Rows)
            {
                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                listLigneFraisForfait.Add(new LigneFraisHorsForfait((int)r["id"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"]));
            }
            return listLigneFraisForfait;
        }



        public List<LigneFraisHorsForfait> SelectByFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisHorsForfait> listLigneFraisHorsForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectByComposedFK2("lignefraishorsforfait", "idVisiteur", uneFicheFrais.UnVisiteur.Id, "mois", uneFicheFrais.Mois);



            foreach (DataRow r in myTable.Rows)
            {
                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                listLigneFraisHorsForfait.Add(new LigneFraisHorsForfait(uneFicheFrais, (int)r["id"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"]));
            }
            return listLigneFraisHorsForfait;
        }
    }
}

