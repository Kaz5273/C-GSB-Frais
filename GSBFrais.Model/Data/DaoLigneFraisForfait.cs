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
    public class DaoLigneFraisForfait
    {
        private Dbal unDbal;
        private DaoVisiteurs _daoVisiteur;
        private DaoFraisForfait _daoFraisForFait;

        public DaoLigneFraisForfait(Dbal myDbal, DaoVisiteurs unDaoVisiteurs, DaoFraisForfait unDaoFraisForfait)
        {
            this.unDbal = myDbal;
            this._daoVisiteur = unDaoVisiteurs;
            this._daoFraisForFait = unDaoFraisForfait;
        }

        public void Insert(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quantite) VALUES ('" + uneLigneFraisForfait.Fichefrais + "','" + uneLigneFraisForfait.Fichefrais + "','" + uneLigneFraisForfait.Fraisforfait+ "','" + uneLigneFraisForfait.Quantite + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " ligneFraisForfait SET idVisiteur = '" + uneLigneFraisForfait.Fichefrais.UnVisiteur.Id + "', mois = '" + uneLigneFraisForfait.Fichefrais.Mois + "', idFraisForfait = '" + uneLigneFraisForfait.Fraisforfait.Id + "', quantite = '" + uneLigneFraisForfait.Quantite + "' WHERE idVisiteur = '" + uneLigneFraisForfait.Fichefrais.UnVisiteur.Id + "' AND mois = '" + uneLigneFraisForfait.Fichefrais.Mois + "' AND idFraisForfait = '" + uneLigneFraisForfait.Fraisforfait.Id + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " visiteur WHERE idVisiteur ='" + uneLigneFraisForfait.Fichefrais + "'AND idFraitForfait ='"+ uneLigneFraisForfait.Fraisforfait + "'";
            this.unDbal.Delete(query);
        }

        public List<LigneFraisForfait> SelectAll()
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisForfait");
            

            foreach (DataRow r in myTable.Rows)
            {
                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                listLigneFraisForfait.Add(new LigneFraisForfait((int)r["quantite"], (FraisForfait)r["unFraisForfait"], (FicheFrais)r["uneFichefrais"]));
            }
            return listLigneFraisForfait;
        }

      

        public List<LigneFraisForfait> SelectByFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectByComposedFK2("lignefraisforfait", "idVisiteur", uneFicheFrais.UnVisiteur.Id, "mois", uneFicheFrais.Mois );
            

            foreach (DataRow r in myTable.Rows)
            {
                Visiteur leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                FraisForfait leFraisForfait = this._daoFraisForFait.SelectById((string)r["idFraisForfait"]);
                listLigneFraisForfait.Add(new LigneFraisForfait((int)r["quantite"], leFraisForfait, uneFicheFrais));
            }
            return listLigneFraisForfait;


        }
    }
}
