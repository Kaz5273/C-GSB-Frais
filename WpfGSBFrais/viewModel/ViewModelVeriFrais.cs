﻿using GSBFrais.Model.Business;
using GSBFrais.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfClubFromage.viewModel;

namespace WpfGSBFrais.viewModel
{
    class ViewModelVeriFrais : viewModelBase
    {
        private DaoFicheFrais unDaoFicheFrais;

        private ObservableCollection<FicheFrais> listFicheFrais;
        private ObservableCollection<string> moisFicheFrais;
        private string selectedMois;
        private FicheFrais selectedFicheFrais;
        private string repas;
        private string nuite;
        private string fraiskm;
        private string forfaitetape;
        private ObservableCollection<LigneFraisHorsForfait> listLigneFraisHorsForfait;
        private bool cree = false;
        private bool cloture = false;
        private bool valid = false;
        private bool rembourser = false;


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
                            Cloture = true;
                            break;
                        case "CR":
                            Cree = true;
                            break;
                        case "RB":
                            Rembourser = true;
                            break;
                        case "VA":
                            Valid = true;
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

        public bool Cree
        {
            get
            {
                return cree;
            }

            set
            {
                cree = value;

                OnPropertyChanged("IsCree");
            }
        }

        public bool Cloture
        {
            get
            {
                return cloture;
            }

            set
            {
                cloture = value;
                OnPropertyChanged("IsCloture");
            }
        }

        public bool Valid
        {
            get
            {
                return valid;
            }

            set
            {
                valid = value;
                OnPropertyChanged("IsValid");
            }
        }

        public bool Rembourser
        {
            get
            {
                return rembourser;
            }

            set
            {
                rembourser = value;
                OnPropertyChanged("IsRefund");
            }
        }

       

        

        public ViewModelVeriFrais(DaoFicheFrais theDaoFichefrais )
        {

            this.unDaoFicheFrais = theDaoFichefrais;

            listFicheFrais = new ObservableCollection<FicheFrais>(theDaoFichefrais.SelectAll());
            moisFicheFrais = new ObservableCollection<string>(theDaoFichefrais.SelectListMois());
            




        }


    }
}
