using vJMPS.ViewModels;
namespace F5E3.Models
{
    public class WandBModel : ViewModelBase
    {
        private double _outboardStoresWeght;
        public double OutboardStoresWeight
        {
            get { return _outboardStoresWeght; }
            set
            {
                _outboardStoresWeght = value;
                
            }

        }

        private double _inbaordStoresWeight;

        public double InboardStoresWeight
        {
            get { return _inbaordStoresWeight; }
            set
            {
                _inbaordStoresWeight = value;
                
            }
        }

        private double _centerStoresWeight;

        public double CenterStoresWeight
        {
            get { return _centerStoresWeight; }
            set
            {
                _centerStoresWeight = value;
                
            }
        }

        private bool _hasMissiles;

        public bool HasMissiles
        {
            get { return _hasMissiles; }
            set
            {
                _hasMissiles = value;
                
            }
        }

        private double _ammo;

        public double Ammo
        {
            get { return _ammo; }
            set { _ammo = value;
                
            }
        }

        private double _cg;

        public double CG
        {
            get { return _cg; }
            internal set { _cg = value;
                
            }
        }

        private double _grossweight;

        public double GrossWeight
        {
            get { return _grossweight; }
            internal set
            {
                _grossweight = value;
                
            }
        }

        

    }
}