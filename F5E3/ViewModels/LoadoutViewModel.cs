using System;
using System.Collections.Generic;
using System.Text;

namespace F5E3.ViewModels
{
    public class LoadoutViewModel
    {
        private readonly GrossWeightAndCGPositionChart cGPositionChart;

       public LoadoutViewModel()
        {
            cGPositionChart = new GrossWeightAndCGPositionChart();
        }

        public double CenterLineWeight
        {
            get { return cGPositionChart.CenterStoresWeight; }
            set { cGPositionChart.CenterStoresWeight = value; }
        }

        public double CG
        {
            get { return cGPositionChart.CG; }
        }
    }
}
