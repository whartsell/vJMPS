using System;
using System.Collections.Generic;
using System.Text;
using F5E3.Models;

namespace F5E3.ViewModels
{
    public class LandingViewModel : TOLDViewModel
    {
        private readonly LandingModel landingModel;
        public LandingViewModel(LandingModel model) : base(model)
        {
            landingModel = model;
        }

    }
}
