using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vJMPS.Pages;
using Xamarin.Forms;

namespace vJMPS
{
	public partial class App : Application
	{
		public App (IOCSetup setup)
		{
			InitializeComponent();
            AppContainer.Container = setup.CreateContainer();
            MainPage = AppContainer.Container.Resolve<RootPage>();

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
