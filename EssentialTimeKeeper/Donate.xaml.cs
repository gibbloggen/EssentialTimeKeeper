using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Store;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EssentialTimeKeeper
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Donate : Page
	{

		private StoreContext context = null;

		public Donate()
		{
			this.InitializeComponent();
			ApplicationView.GetForCurrentView().Title = "Version " + GetAppVersion() + " ";
			Window.Current.SizeChanged += Current_SizeChanged;
			//ManyThanks.Visibility = Visibility.Visible;
			Clock.Loaded += Clock_Loaded1;


		}

		private void Clock_Loaded1(object sender, RoutedEventArgs e)

		{

			return;
			/*double Heigher = Window.Current.Bounds.Height / 5;
			double Wider = Window.Current.Bounds.Width / 5;
			//double Fonter = 21 + ((makeDonation.Width - 450) / 24);

			Donation1.Height = Heigher;
			Donation1.Width = Wider;
			Donation1.FontSize = Fonter;

			Donation2.Height = Heigher;
			Donation2.Width = Wider;
			Donation2.FontSize = Fonter;

			Donation3.Height = Heigher;
			Donation3.Width = Wider;
			Donation3.FontSize = Fonter;

			storeResult.Height = Heigher;
			storeResult.Width = makeDonation.Width / 2;
			storeResult.FontSize = Fonter / 2;

			ManyThanks.Height = storeResult.Height;
			ManyThanks.Width = storeResult.Width;
			ManyThanks.FontSize = storeResult.FontSize + 25;


			return;
			*/



			
		}

		private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{
			return;
			/*
			makeDonation.Height = Window.Current.Bounds.Height / 5;
			makeDonation.Width = Window.Current.Bounds.Width - 125;
			makeDonation.FontSize = 41 + ((makeDonation.Width - 450) / 24);

			double Heigher = Window.Current.Bounds.Height / 5;
			double Wider = Window.Current.Bounds.Width / 5  ;
			double Fonter = 21 + ((makeDonation.Width - 450) / 24);

			Donation1.Height = Heigher;
			Donation1.Width = Wider;
			Donation1.FontSize = Fonter;

			Donation2.Height = Heigher;
			Donation2.Width = Wider;
			Donation2.FontSize = Fonter;

			Donation3.Height = Heigher;
			Donation3.Width = Wider;
			Donation3.FontSize = Fonter;

			storeResult.Height = Heigher ;
			storeResult.Width = makeDonation.Width / 2;
			storeResult.FontSize = Fonter / 2;

			ManyThanks.Height = storeResult.Height;
			ManyThanks.Width = storeResult.Width;
			ManyThanks.FontSize = storeResult.FontSize + 25;


			return;

	

			//ClockerOutput.Width = e.Size.Width - 50;

			//btnStart.Width = (ClockerOutput.Width / 5);
			//btnPause.Width = (ClockerOutput.Width / 5);
			//btnReset.Width = (ClockerOutput.Width / 5);



			if (e.Size.Height < 175) makeDonation.Height = e.Size.Height - 57;
			else
			{
				makeDonation.Height = (e.Size.Height - (58 + ((e.Size.Height - 48) / 2)));

			}
			if ((makeDonation.Height < 175) || (makeDonation.Width < 650)) makeDonation.FontSize = 89;
			else
				//ClockerOutput.FontSize = (ClockerOutput.Width + ClockerOutput.Height) / 7;
				//	ClockerOutput.FontSize = 89 + ((ClockerOutput.Width + ClockerOutput.Height - 824) /15);
				makeDonation.FontSize = 89 + ((makeDonation.Width - 650) / 6);

			//if (ClockerOutput.Height < 175) ClockerOutput.FontSize = 89;

			//btnStart.Height = (ClockerOutput.Height / 3) + 14;
			//btnPause.Height = (ClockerOutput.Height / 3) + 14;
			//btnReset.Height = (ClockerOutput.Height / 3) + 14; */
		}

		//This was copied form this Stack Overflow Entry
		//https://stackoverflow.com/questions/28635208/retrieve-the-current-app-version-from-package/28635481#28635481
		public static string GetAppVersion()
		{

			Package package = Package.Current;
			PackageId packageId = package.Id;
			PackageVersion version = packageId.Version;

			return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

		}


	
		//This came from some sort of Microsoft Tutorial
		public async void PurchaseAddOn(string storeId)
		{


			try
			{


				if (context == null)
				{
					context = StoreContext.GetDefault();

				}

				workingProgressRing.IsActive = true;
				StorePurchaseResult result = await context.RequestPurchaseAsync(storeId);
				workingProgressRing.IsActive = false;



				switch (result.Status)
				{
					case StorePurchaseStatus.AlreadyPurchased:
						storeResult.Text = "The user has already purchased the product.";
						storeResult.Visibility = Visibility.Visible;
						break;

					case StorePurchaseStatus.Succeeded:
						//storeResult.Text = "The purchase was successful.";
						ManyThanks.Visibility = Visibility.Visible;
						break;

					case StorePurchaseStatus.NotPurchased:
						storeResult.Text = "The user cancelled the purchase.";
						storeResult.Visibility = Visibility.Visible;
						break;

					case StorePurchaseStatus.NetworkError:
						storeResult.Text = "The purchase was unsuccessful due to a network error.";
						storeResult.Visibility = Visibility.Visible;
						break;

					case StorePurchaseStatus.ServerError:
						storeResult.Visibility = Visibility.Visible;
						storeResult.Text = "The purchase was unsuccessful due to a server error.";
						break;

					default:
						storeResult.Text = "The purchase was unsuccessful due to an unknown error.";
						storeResult.Visibility = Visibility.Visible;
						break;
				}
			}
			catch (Exception ex)
			{
				storeResult.Text = "The purchase was unsuccessful due to an unknown error.";
				storeResult.Visibility = Visibility.Visible;
			}
		}

		//These codes are set per app.  They will only run from the given app.

		private void Donation1_Tapped(object sender, TappedRoutedEventArgs e)
		{
			PurchaseAddOn("9p9slzmj0f8v");

			Donator.Visibility = Visibility.Collapsed;
		}

		private void Donation2_Tapped(object sender, TappedRoutedEventArgs e)
		{
			PurchaseAddOn("9n2wrrr7jmfr");
			Donator.Visibility = Visibility.Collapsed;
		}

		private void Donation3_Tapped(object sender, TappedRoutedEventArgs e)
		{
			PurchaseAddOn("9n6mjcjt7pvd");
			Donator.Visibility = Visibility.Collapsed;
		}

		private void Clock_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Frame Parental = (Frame)this.Parent;
			


			Parental.Content = new Clocker();

			//Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;
			k.getSmallAgain();




		}


		private void Help_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;
			k.getBig();
			Parental.Content = new HelpPage();


		}

		private void Chronograph_Tapped(object sender, TappedRoutedEventArgs e)
		{


			Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;

			


			if (k.stopAlot != null) Parental.Content = k.stopAlot;
			else Parental.Content = new StopWatch();

			k.getSmallAgain();
		}
	}
}
