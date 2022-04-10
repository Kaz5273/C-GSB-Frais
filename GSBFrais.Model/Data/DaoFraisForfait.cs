using GSBFrais.Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Data
{
    public class DaoFraisForfait
    {

        private Dbal unDbal;

        public DaoFraisForfait(Dbal myDbal)
        {
            this.unDbal = myDbal;
        }

        public void Insert(FraisForfait unFraisForfait )
        {
            string query = " fraisforfait (id, libelle, montant) VALUES ('" + unFraisForfait.Id + "',' " + unFraisForfait.Libelle + "',' "+ unFraisForfait.Montant +  "')";
            this.unDbal.Insert(query);
        }

        public void Update(FraisForfait unFraisForfait)
        {
            string query = " fraisforfait (id, libelle, montant) VALUES ('" + unFraisForfait.Id + "',' " + unFraisForfait.Libelle + "',' " + unFraisForfait.Montant + "')";
            this.unDbal.Update(query);
        }

        public void Delete(FraisForfait unFraisForfait)
        {
            string query = " fraisforfait WHERE id =" + unFraisForfait.Id + "'";
            this.unDbal.Delete(query);
        }

        public List<FraisForfait> SelectAll()
        {
            List<FraisForfait> listFraisForfait= new List<FraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("FraisForfait");

            foreach (DataRow r in myTable.Rows)
            {
                listFraisForfait.Add(new FraisForfait((string)r["id"], (string)r["libelle"], (decimal)r["montant"]));
            }
            return listFraisForfait;
        }

        public FraisForfait SelectById(string idFraisForfait)
        {
            DataRow result = this.unDbal.SelectById("fraisforfait", idFraisForfait);
            return new FraisForfait((string)result["id"], (string)result["libelle"], (decimal)result["montant"]);
        }
    }
    }


