using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class HelpPage : Page
	{
		public HelpPage()
		{
			this.InitializeComponent();

			ApplicationView.GetForCurrentView().Title = "Version " + GetAppVersion() + " ";


			Window.Current.SizeChanged += Current_SizeChanged;



			Uri j = new Uri("http://www.essentialsoftwareproducts.org/essential-time-keeper/");
			HelpView.Navigate(j);
			HelpView.Visibility = Visibility.Visible;
			HelpView.Width = Window.Current.Bounds.Width;
			HelpView.Height = Window.Current.Bounds.Height - 80;
			/*	Window.Current.Closed += (ss, ee) =>
				{
					Frame.Navigate(typeof(MainPage));
				};
				*/


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



		private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{


			HelpView.Width = e.Size.Width;
			HelpView.Height = e.Size.Height - 80;
			// GetTheVideo.Width = e.Size.Width;
			//GetTheVideo.Height = e.Size.Height;


		}


		private void Menu_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (Chronograph.IsSelected)
			{
				Frame Parental = (Frame)this.Parent;

				Parental.Content = new StopWatch();



			}
			else if (Clock.IsSelected)
			{
				Frame Parental = (Frame)this.Parent;

				Parental.Content = new Clocker();

			}
			else if (MakeDonation.IsSelected)
			{
				Frame Parental = (Frame)this.Parent;

				Parental.Content = new Donate();
			}
			else if (Help.IsSelected)
			{
				MySplitView.IsPaneOpen = false;
				return;
			}


		}
		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{

			MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

		}
	}
}
