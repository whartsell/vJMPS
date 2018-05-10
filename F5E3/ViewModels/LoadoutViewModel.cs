using F5E3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Core;

namespace F5E3.ViewModels
{
    public class LoadoutViewModel : ViewModelBase
    {
        private LoadoutModel loadoutModel;

        public LoadoutViewModel()
        {
            loadoutModel = new LoadoutModel();
            CalcAndNotify();
        }
        public double CenterLineWeight
        {
            get { return loadoutModel.CenterStoresWeight; }
            set
            {
                loadoutModel.CenterStoresWeight = value;
                CalcAndNotify();

            }
        }

        public double OutboardStoresWeight
        {
            get { return loadoutModel.OutbaordStoresWeight; }
            set
            {
                loadoutModel.OutbaordStoresWeight = value;
                CalcAndNotify();
            }
        }

        public double InboardStoresWeight
        {
            get { return loadoutModel.InboardStoresWeight; }
            set
            {
                loadoutModel.InboardStoresWeight = value;
                CalcAndNotify();
            }
        }

        public bool HasMissiles
        {
            get { return loadoutModel.HasMissiles; }
            set
            {
                loadoutModel.HasMissiles = value;
                CalcAndNotify();
            }
        }

        public double Ammo
        {
            get { return loadoutModel.Ammo; }
            set
            {
                loadoutModel.Ammo = value;
                CalcAndNotify();
            }
        }


        public double CG
        {
            get { return loadoutModel.CG.SigFigs(3); }
        }

        public double GrossWeight
        {
            get { return loadoutModel.GrossWeight; }
            set
            {
                loadoutModel.GrossWeight = value;
                CalcAndNotify();
            }
        }

        private void CalcAndNotify()
        {
            loadoutModel.CalculateGWandCG();
            OnPropertyChanged("CG");
            OnPropertyChanged("GrossWeight");
        }
    }



}
