using GSBFrais.Model.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGSBFrais
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoEtat thedaoetat;
        private DaoFicheFrais thedaofichefrais;
        private DaoLigneFraisForfait thedaolignefraisforfait;
        private DaoLigneFraisHorsForfait thedaofraishorsforfait;
        private DaoVisiteurs thedaovisiteurs;
        private DaoFraisForfait thedaofraisforfait;


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            thedbal = new Dbal("gsb_frais");
            thedaoetat = new DaoEtat(thedbal);
            thedaovisiteurs = new DaoVisiteurs(thedbal);
            thedaofraisforfait = new DaoFraisForfait(thedbal);
            thedaolignefraisforfait = new DaoLigneFraisForfait(thedbal, thedaovisiteurs, thedaofraisforfait);
            thedaofraishorsforfait = new DaoLigneFraisHorsForfait(thedbal, thedaofraisforfait, thedaovisiteurs, thedaofichefrais);
            thedaofichefrais = new DaoFicheFrais(thedbal, thedaovisiteurs, thedaoetat, thedaolignefraisforfait, thedaofraishorsforfait);
            
            
            


            // Create the startup window
            VeriFrais wnd = new VeriFrais(thedaofichefrais);
            //MainWindow wnd = new MainWindow(thedaopays, thedaofromage);
            wnd.Show();

        }
    }

   
}
