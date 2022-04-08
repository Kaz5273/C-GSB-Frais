using GSBFrais.Model.Business;
using GSBFrais.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGSBFrais.viewModel;
using WpfVeriFrais.viewModel;

namespace WpfGSBFrais.viewModel
{
    class ViewModelVeriFrais : viewModelBase
    {
        private DaoFicheFrais unDaoFicheFrais;
        private DaoLigneFraisHorsForfait unDaoLigneFraisHorsForFait;
        private DaoLigneFraisForfait unDaoLigneFraisForFait;
        private DaoVisiteurs unDaoVisiteur;
        private DaoEtat unDaoEtat;

        private ObservableCollection<FicheFrais> listFicheFrais;
        private ObservableCollection<string> moisFicheFrais;
        private string selectedMois;
        private FicheFrais selectedFicheFrais;
        private string repas;
        private string nuite;
        private string fraiskm;
        private string forfaitetape;
        private ObservableCollection<LigneFraisHorsForfait> listLigneFraisHorsForfait;
        private bool isCree = false;
        private bool isCloture = false;
        private bool isValid = false;
        private bool isRefund = false;
        private ICommand buttonEnregistrer;
        private ICommand buttonModifier;
        private ICommand buttonSupprimer;
        private LigneFraisHorsForfait selectedLFHF;

        public ViewModelVeriFrais(DaoFicheFrais theDaoFichefrais, DaoLigneFraisForfait theDaoLigneFraisForfait, DaoLigneFraisHorsForfait theDaoLigneFraisHorsForfait, DaoEtat theDaoEtat)
        {

            this.unDaoFicheFrais = theDaoFichefrais;
            this.unDaoLigneFraisForFait = theDaoLigneFraisForfait;
            this.unDaoLigneFraisHorsForFait = theDaoLigneFraisHorsForfait;
            this.unDaoEtat = theDaoEtat;

            listFicheFrais = new ObservableCollection<FicheFrais>(theDaoFichefrais.SelectAll());
            moisFicheFrais = new ObservableCollection<string>(theDaoFichefrais.SelectListMois());



        }



        public ObservableCollection<FicheFrais> ListFicheFrais
        {
            get
            {
                return listFicheFrais;
            }

            set
            {
                listFicheFrais = value;
            }
        }

        public ObservableCollection<string> MoisFicheFrais
        {
            get
            {
                return moisFicheFrais;
            }

            set
            {
                moisFicheFrais = value;
            }
        }

        public string SelectedMois
        {
            get
            {
                return selectedMois;
            }

            set
            {
                selectedMois = value;
                OnPropertyChanged("SelectedMois");
                ListFicheFrais = new ObservableCollection<FicheFrais>(unDaoFicheFrais.SelectByMonth(SelectedMois));
                OnPropertyChanged("ListFicheFrais");

            }
        }

        public FicheFrais SelectedFicheFrais
        {
            get
            {
                return selectedFicheFrais;
            }

            set
            {
                selectedFicheFrais = value;

                if (selectedFicheFrais != null )
                {
                    switch (selectedFicheFrais.UnEtat.Id)
                    {
                        case "CL":
                            IsCloture = true;
                            break;
                        case "CR":
                            IsCree = true;
                            break;
                        case "RB":
                            IsRefund= true;
                            break;
                        case "VA":
                            IsValid = true;
                            break;

                    }

                    foreach (LigneFraisForfait uneLigneFraisForfait in selectedFicheFrais.LesLignesFraisForfait)
                    {
                        switch (uneLigneFraisForfait.Fraisforfait.Id)
                        {
                            case "REP":
                                Repas = uneLigneFraisForfait.Quantite.ToString();
                                break;

                            case "NUI":
                                Nuite = uneLigneFraisForfait.Quantite.ToString();
                                break;

                            case "KM":
                                Fraiskm = uneLigneFraisForfait.Quantite.ToString();
                                break;
                        
                     
                            case "ETP":
                                Forfaitetape = uneLigneFraisForfait.Quantite.ToString();
                                break;
                        }
                    }
                    ListLigneFraisHorsForfait = new ObservableCollection<LigneFraisHorsForfait>(selectedFicheFrais.LesLigneFraisHorsForfait);
                }
            }
        }





        public string Repas
        {
            get
            {
                return repas;
            }

            set
            {
                repas = value;
                OnPropertyChanged("Repas");
            }
        }

        public string Nuite
        {
            get
            {
                return nuite;
                
            }

            set
            {
                nuite = value;
                OnPropertyChanged("Nuite");
            }
        }

        public string Fraiskm
        {
            get
            {
                return fraiskm;
            }

            set
            {
                fraiskm = value;
                OnPropertyChanged("Fraiskm");
            }
        }

        public string Forfaitetape
        {
            get
            {
                return forfaitetape;
            }

            set
            {
                forfaitetape = value;
                OnPropertyChanged("Forfaitetape");
            }
        }

        public ObservableCollection<LigneFraisHorsForfait> ListLigneFraisHorsForfait
        {
            get
            {
                return listLigneFraisHorsForfait;
            }

            set
            {
                listLigneFraisHorsForfait = value;
                OnPropertyChanged("ListLigneFraisHorsForfait");
            }
        }

        public bool IsCree
        {
            get
            {
                return isCree;
            }

            set
            {
                isCree = value;
                OnPropertyChanged("IsCree");
            }
        }

        public bool IsCloture
        {
            get
            {
                return isCloture;
            }

            set
            {
                isCloture = value;
                OnPropertyChanged("IsCloture");
            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
                isValid = value;
                OnPropertyChanged("IsValid");
            }
        }

        public bool IsRefund
        {
            get
            {
                return isRefund;
            }

            set
            {
                isRefund = value;
                OnPropertyChanged("IsRefund");
            }
        }

        public ICommand ButtonEnregistrer
        {
            get
            {
                this.buttonEnregistrer = new RelayCommand(() => EnregistrerFicheFrais(), () => true);
                return buttonEnregistrer;
            }


        }

        public ICommand ButtonReporter
        {
            get
            {
                this.buttonModifier = new RelayCommand(() => ReporterFicheFrais(), () => true);
                return buttonModifier;
                
            }
        }

        public ICommand ButtonSupprimer
        {
            get
            {
               
                this.buttonSupprimer = new RelayCommand(() => SupprimerFicheFrais(), () => true);
                return buttonSupprimer;
            }
        }

        public LigneFraisHorsForfait SelectedLFHF
        {
            get
            {
                return selectedLFHF;
            }

            set
            {
                selectedLFHF = value;
            }
        }


        private void SupprimerFicheFrais()
        {

            unDaoLigneFraisHorsForFait.Delete(SelectedLFHF);
            ListLigneFraisHorsForfait.Remove(SelectedLFHF);

        }

        private void ReporterFicheFrais()
        {
            string mois = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
            FicheFrais uneFicheFrais = unDaoFicheFrais.SelectByVisiteurMois(SelectedFicheFrais.UnVisiteur, mois);
           
            if (uneFicheFrais == null)
            {
               Etat EtatCree = unDaoEtat.SelectById("CR");
               uneFicheFrais = new FicheFrais(mois, 0, 0, DateTime.Now, EtatCree, SelectedFicheFrais.UnVisiteur);
                unDaoFicheFrais.Insert(uneFicheFrais);
            }
            SelectedLFHF.Fichefrais = uneFicheFrais;
            unDaoLigneFraisHorsForFait.Update(SelectedLFHF);
            ListLigneFraisHorsForfait.Remove(SelectedLFHF);


        }

        private void EnregistrerFicheFrais()
        {
            foreach (LigneFraisForfait uneLigneFraisForFait in selectedFicheFrais.LesLignesFraisForfait)
            {
                switch (uneLigneFraisForFait.Fraisforfait.Id)
                {
                    case "REP":
                        if (uneLigneFraisForFait.Quantite.ToString() != Repas)
                        {
                            uneLigneFraisForFait.Quantite = Int32.Parse(Repas);
                            unDaoLigneFraisForFait.Update(uneLigneFraisForFait);
                        }
                        break;

                    case "NUI":
                        if (uneLigneFraisForFait.Quantite.ToString() != Nuite)
                        {
                            uneLigneFraisForFait.Quantite = Int32.Parse(Nuite);
                            unDaoLigneFraisForFait.Update(uneLigneFraisForFait);
                        }
                        break;

                    case "KM":
                        if (uneLigneFraisForFait.Quantite.ToString() != Fraiskm)
                        {
                            uneLigneFraisForFait.Quantite = Int32.Parse(Fraiskm);
                            unDaoLigneFraisForFait.Update(uneLigneFraisForFait);
                        }
                        break;


                    case "ETP":
                        if (uneLigneFraisForFait.Quantite.ToString() != Forfaitetape)
                        {
                            uneLigneFraisForFait.Quantite = Int32.Parse(Forfaitetape);
                            unDaoLigneFraisForFait.Update(uneLigneFraisForFait);
                        }
                        break;
                }

                
               
                
               

            }
            
        }

    }
}
