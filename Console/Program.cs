using GSBFrais.Model.Business;
using GSBFrais.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dbal unDbal = new Dbal();
            DaoEtat unDaoEtat = new DaoEtat(unDbal);
            DaoVisiteurs unDaoVisiteurs = new DaoVisiteurs(unDbal);
            DaoFraisForfait unDaoFraisForFait = new DaoFraisForfait(unDbal);
            DaoLigneFraisForfait unDaoLigneFraisForfait = new DaoLigneFraisForfait(unDbal, unDaoVisiteurs, unDaoFraisForFait);


            //List<FicheFrais> ListFicheFrais = unDaoFicheFrais.SelectByMonth("202108");
            //foreach(FicheFrais moisFiche in ListFicheFrais)
            //{
            //    Console.WriteLine(moisFiche);
            //}
            //Console.ReadKey();

            //List<string> uneListMois = unDaoFicheFrais.SelectListMois();

            //foreach(string s in uneListMois)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadKey();



        }
    }
}
