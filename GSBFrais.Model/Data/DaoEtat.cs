using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBFrais.Model.Data;
using GSBFrais.Model.Business;
using System.Data;
using GSBFrais.Model.Data;

namespace GSBFrais.Model.Data
{
    public class DaoEtat
    {
        private Dbal unDbal;

        public DaoEtat(Dbal myDbal)
        {
            this.unDbal = myDbal;
        }

        public void Insert(Etat unEtat)
        {
            string query = " Etat (id, libelle) VALUES ('" + unEtat.Id + "',' " + unEtat.Libelle.Replace("'", "''") + "')";
            this.unDbal.Insert(query);
        }

        public void Update(Etat unEtat)
        {
            string query = " Etat (id, libelle) SET '" + unEtat.Libelle.Replace("'", "''") + "'";
            this.unDbal.Update(query);
        }

        public void Delete(Etat unEtat)
        {
            string query = " visiteur WHERE id ='" + unEtat.Id + "'";
            this.unDbal.Delete(query);
        }

        public List<Etat> SelectAll()
        {
            List<Etat> listEtat = new List<Etat>();
            DataTable myTable = this.unDbal.SelectAll("Etat");

            foreach (DataRow r in myTable.Rows)
            {
                listEtat.Add(new Etat((string)r["id"], (string)r["libelle"]));
            }
            return listEtat;
        }

        public Etat SelectByName(string nameEtat)
        {
            DataTable result = new DataTable();
            result = this.unDbal.SelectByField("Etat", "libelle = '" + nameEtat.Replace("'", "''") + "'");
            Etat foundEtat = new Etat((string)result.Rows[0]["id"], (string)result.Rows[0]["libelle"]);
            return foundEtat;
        }

        public Etat SelectById(string idEtat)
        {
            DataRow result = this.unDbal.SelectById("Etat", idEtat);
            return new Etat((string)result["id"], (string)result["libelle"]);
        }
    }
}