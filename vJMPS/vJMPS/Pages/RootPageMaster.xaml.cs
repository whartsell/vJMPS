﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public ListView ListView;

        public RootPageMaster()
        {
            InitializeComponent();

            BindingContext = new RootPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class RootPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootPageMenuItem> MenuItems { get; set; }
            private Type test;
            public RootPageMasterViewModel()
            {
                Debug.WriteLine("Yo mamma");
                var a = Assembly.Load(AssemblyName.GetAssemblyName("F5E3.dll"));
                foreach (Type t in a.GetTypes())
                {
                    if (typeof(ILoadout).IsAssignableFrom(t) )
                    {
                        Debug.WriteLine("i found it");
                        Console.WriteLine("i found it");
                        test = t;
                    }
                }
                MenuItems = new ObservableCollection<RootPageMenuItem>(new[]
                {
                    new RootPageMenuItem { Id = 0, Title = "Setup", TargetType = typeof(SetupPage) },
                    new RootPageMenuItem { Id = 1, Title = "Loadout" , TargetType = test},
                    new RootPageMenuItem { Id = 2, Title = "Page 3" },
                    new RootPageMenuItem { Id = 3, Title = "Page 4" },
                    new RootPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}