using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Clocker : Page
    {
        public Clocker()
        {
            this.InitializeComponent();
			ApplicationView.GetForCurrentView().Title = "Version " + GetAppVersion() + " ";
			Window.Current.SizeChanged += Current_SizeChanged;
			ClockerOutput.Loaded += ClockerOutput_Loaded1;
			ColorRotator();
			RunClock();

        }

		private void ClockerOutput_Loaded1(object sender, RoutedEventArgs e)

		{

		

			ClockerOutput.Height = Window.Current.Bounds.Height;
			ClockerOutput.Width = Window.Current.Bounds.Width;
			ClockerOutput.FontSize = 79 + ((ClockerOutput.Width - 450) / 6);

			Chronograph.Width = 28 + (ClockerOutput.Width / 17);
			Help.Width = 28 + (ClockerOutput.Width / 17);
			MakeDonation.Width = 28 + (ClockerOutput.Width / 17);

			double higher = 14 + (Window.Current.Bounds.Height / 5);

			Chronograph.Height = higher;
			Help.Height = higher;
			MakeDonation.Height = higher;

			double fsize2 = 22 + ((ClockerOutput.Width - 250) / 18);
			Chronograph.FontSize = fsize2;
			Help.FontSize = fsize2;
			MakeDonation.FontSize = fsize2;



			return;


			/*Window.Current.Bounds.Width = 1000;
			Window.Current.Bounds.Height = 1000;
			ClockerOutput.Width = 425;
			ClockerOutput.Height = 425;
			*/


			ClockerOutput.Width = Window.Current.Bounds.Width;
			//btnStart.Width = (ClockerOutput.Width / 5);
			//btnPause.Width = (ClockerOutput.Width / 5);
			//btnReset.Width = (ClockerOutput.Width / 5);



			if (Window.Current.Bounds.Height < 175) ClockerOutput.Height = Window.Current.Bounds.Height;
			else
			{
				ClockerOutput.Height = (Window.Current.Bounds.Height - (58 + ((Window.Current.Bounds.Height - 48) / 2)));

			}
			if ((ClockerOutput.Height < 175) || (ClockerOutput.Width < 650)) ClockerOutput.FontSize = 89;
			else
				//ClockerOutput.FontSize = (ClockerOutput.Width + ClockerOutput.Height) / 7;
				//	ClockerOutput.FontSize = 89 + ((ClockerOutput.Width + ClockerOutput.Height - 824) /15);
				ClockerOutput.FontSize = 89 + ((ClockerOutput.Width - 650) / 6);

			//if (ClockerOutput.Height < 175) ClockerOutput.FontSize = 89;

		//	btnStart.Height = (ClockerOutput.Height / 3) + 14;
		//	btnPause.Height = (ClockerOutput.Height / 3) + 14;
		//	btnReset.Height = (ClockerOutput.Height / 3) + 14;
		}

		private async void  RunClock()
		{
			while (true)
			{
				Random j = new Random();
				int z = j.Next(25, 700);
				bool getColor = false;

				while (!getColor)
				{
					if (--z == 0)
					{
						ColorRotator();
						getColor = true;
					}
						await Task.Delay(10);
						DateTime q = DateTime.Now;


						ClockerOutput.Text = q.TimeOfDay.ToString().Substring(0, q.TimeOfDay.ToString().IndexOf(".") + 3);
					}

				}
			
		}

		private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{
			ClockerOutput.Height = Window.Current.Bounds.Height;
			ClockerOutput.Width = Window.Current.Bounds.Width;
			ClockerOutput.FontSize = 79 + ((ClockerOutput.Width - 450) / 6);

		
			Chronograph.Width = 28 + (ClockerOutput.Width / 17);
			Help.Width = 28 + (ClockerOutput.Width / 17);
			MakeDonation.Width = 28 + (ClockerOutput.Width / 17);

			double higher = 14 + (Window.Current.Bounds.Height / 5);

			Chronograph.Height = higher;
			Help.Height = higher;
			MakeDonation.Height = higher;

			double fsize2 = 22 + ((ClockerOutput.Width - 250) / 18);
			Chronograph.FontSize = fsize2;
			Help.FontSize = fsize2;
			MakeDonation.FontSize = fsize2;






			return;

			//ClockerOutput.Width = e.Size.Width - 50;

			//btnStart.Width = (ClockerOutput.Width / 5);
			//btnPause.Width = (ClockerOutput.Width / 5);
			//btnReset.Width = (ClockerOutput.Width / 5);



			if (e.Size.Height < 175) ClockerOutput.Height = e.Size.Height - 57;
			else
			{
				ClockerOutput.Height = (e.Size.Height - (58 + ((e.Size.Height - 48) / 2)));

			}
			if ((ClockerOutput.Height < 175) || (ClockerOutput.Width < 650)) ClockerOutput.FontSize = 89;
			else
				//ClockerOutput.FontSize = (ClockerOutput.Width + ClockerOutput.Height) / 7;
				//	ClockerOutput.FontSize = 89 + ((ClockerOutput.Width + ClockerOutput.Height - 824) /15);
				ClockerOutput.FontSize = 89 + ((ClockerOutput.Width - 650) / 6);

			//if (ClockerOutput.Height < 175) ClockerOutput.FontSize = 89;

			//btnStart.Height = (ClockerOutput.Height / 3) + 14;
			//btnPause.Height = (ClockerOutput.Height / 3) + 14;
			//btnReset.Height = (ClockerOutput.Height / 3) + 14;
		}

		private void ColorRotator()
		{
			Random rnd = new Random();
			Byte[] b = new Byte[4];
			rnd.NextBytes(b);
			Color color = Color.FromArgb(b[0], b[1], b[2], b[3]);
			Color color2 = Color.FromArgb(b[0], b[3], b[2], b[1]);

			MainGrid.Background = new SolidColorBrush(color);
			ClockerOutput.Background = new SolidColorBrush(color);
			Icons.Background = new SolidColorBrush(color);
			MainStack.Background = new SolidColorBrush(color);

		}


		/*	private void Menu_Tapped(object sender, TappedRoutedEventArgs e)
			{
				if (Chronograph.IsSelected)
				{
					Frame Parental = (Frame)this.Parent;

					Parental.Content = new StopWatch();



				}
				else if (Clock.IsSelected)
				{
					MySplitView.IsPaneOpen = false;
					return;
				}
				else if (MakeDonation.IsSelected)
				{
					Frame Parental = (Frame)this.Parent;

					Parental.Content = new Donate();
				}
				else if (Help.IsSelected)
				{
					Frame Parental = (Frame)this.Parent;

					Parental.Content = new HelpPage();
				}


			}
			private void HamburgerButton_Click(object sender, RoutedEventArgs e)
			{

				MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

			}
			*/
		//This was copied form this Stack Overflow Entry
		//https://stackoverflow.com/questions/28635208/retrieve-the-current-app-version-from-package/28635481#28635481
		public static string GetAppVersion()
		{

			Package package = Package.Current;
			PackageId packageId = package.Id;
			PackageVersion version = packageId.Version;

			return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

		}

		private void MakeDonation_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;
			k.getBig();
			Parental.Content = new Donate();

		}

		private void Chronograph_Tapped(object sender, TappedRoutedEventArgs e)
		{
			

			Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;


			if (k.stopAlot != null ) Parental.Content = k.stopAlot;
			else  Parental.Content = new StopWatch();
		}

		private void Help_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Frame Parental = (Frame)this.Parent;
			Grid j = (Grid)Parental.Parent;
			MainPage k = (MainPage)j.Parent;
			k.getBig();
			Parental.Content = new HelpPage();


		}
	}
}
