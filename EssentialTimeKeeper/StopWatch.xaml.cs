using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.UI.ViewManagement;
using Windows.UI;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EssentialTimeKeeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StopWatch : Page
    {
		static DateTime StartTime = new DateTime();
		DateTime WhenPaused = new DateTime();
		TimeSpan PausedFor = new TimeSpan(0);
		DateTime CurrentTime = new DateTime();
		bool RunningOn = false;
		bool pausable = false;

		public StopWatch()
        
		{
			this.InitializeComponent();
			ApplicationView.GetForCurrentView().Title = "Version " + GetAppVersion() + " ";
			Window.Current.SizeChanged += Current_SizeChanged;
			btnReset.Loaded += ClockerOutput_Loaded1;
		}

		private void ClockerOutput_Loaded1(object sender, RoutedEventArgs e)

		{

			/*Window.Current.Bounds.Width = 1000;
			Window.Current.Bounds.Height = 1000;
			ClockerOutput.Width = 425;
			ClockerOutput.Height = 425;
			*/


			ClockerOutput.Width = Window.Current.Bounds.Width;
			btnStart.Width = (ClockerOutput.Width / 5);
			btnPause.Width = (ClockerOutput.Width / 5);
			btnReset.Width = (ClockerOutput.Width / 5);



			if (Window.Current.Bounds.Height < 175) ClockerOutput.Height = Window.Current.Bounds.Height - 57;
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

			btnStart.Height = (ClockerOutput.Height / 3) + 14;
			btnPause.Height = (ClockerOutput.Height / 3) + 14;
			btnReset.Height = (ClockerOutput.Height / 3) + 14;
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

		private void setScreen(object sender, RoutedEventArgs e)
		{


			ClockerOutput.Width = this.Width - 50;

			btnStart.Width = (ClockerOutput.Width / 5);
			btnPause.Width = (ClockerOutput.Width / 5);
			btnReset.Width = (ClockerOutput.Width / 5);



			if (this.Height < 175) ClockerOutput.Height = this.Height - 57;
			else
			{
				ClockerOutput.Height = (this.Height - (58 + ((this.Height - 48) / 2)));

			}
			if ((ClockerOutput.Height < 175) || (ClockerOutput.Width < 650)) ClockerOutput.FontSize = 89;
			else
				//ClockerOutput.FontSize = (ClockerOutput.Width + ClockerOutput.Height) / 7;
				//	ClockerOutput.FontSize = 89 + ((ClockerOutput.Width + ClockerOutput.Height - 824) /15);
				ClockerOutput.FontSize = 89 + ((ClockerOutput.Width - 650) / 6);

			//if (ClockerOutput.Height < 175) ClockerOutput.FontSize = 89;

			btnStart.Height = (ClockerOutput.Height / 3) + 14;
			btnPause.Height = (ClockerOutput.Height / 3) + 14;
			btnReset.Height = (ClockerOutput.Height / 3) + 14;



		}
		private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{


			ClockerOutput.Width = e.Size.Width - 50;

			btnStart.Width = (ClockerOutput.Width / 5);
			btnPause.Width = (ClockerOutput.Width / 5);
			btnReset.Width = (ClockerOutput.Width / 5);



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

			btnStart.Height = (ClockerOutput.Height / 3) + 14;
			btnPause.Height = (ClockerOutput.Height / 3) + 14;
			btnReset.Height = (ClockerOutput.Height / 3) + 14;
		}


		private void btnStart_Tapped(object sender, TappedRoutedEventArgs e)
		{

			RunningOn = true;
			if (!pausable)
			{
				StartTime = DateTime.Now;
				pausable = true;
			}
			else
			{
				PausedFor = PausedFor + DateTime.Now.Subtract(WhenPaused);
			}
			TickTock();
			btnStart.Visibility = Visibility.Collapsed;
			btnPause.Visibility = Visibility.Visible;



		}
		private void btnPause_Tapped(object sender, TappedRoutedEventArgs e)
		{
			//pausable = true;
			//PausedFor = PausedFor + DateTime.Now.Subtract(WhenPaused);
			RunningOn = false;
			WhenPaused = DateTime.Now;
			//pausable = true;
			//}
			btnStart.Visibility = Visibility.Visible;
			btnPause.Visibility = Visibility.Collapsed;

		}


		private async void TickTock()
		{
			while (RunningOn)
			{
				await Task.Delay(10);
				DateTime q = DateTime.Now;

				TimeSpan j = q.Subtract(StartTime);
				j = j - PausedFor;
				ClockerOutput.Text = j.ToString("c").Substring(0, j.ToString("c").IndexOf(".") + 3);



			}
		}


		private async void btnReset_Tapped(object sender, TappedRoutedEventArgs e)
		{

			RunningOn = false;
			await Task.Delay(35);
			//btnStart.Content = "Start";
			ClockerOutput.Text = "00:00:00.00";
			PausedFor = TimeSpan.Zero;
			StartTime = DateTime.Now;
			WhenPaused = StartTime;
			pausable = false;
			btnPause.Visibility = Visibility.Collapsed;
			btnStart.Visibility = Visibility.Visible;


		}

		private void ColorRotator(object sender, TappedRoutedEventArgs e)
		{
			Random rnd = new Random();
			Byte[] b = new Byte[4];
			rnd.NextBytes(b);
			Color color = Color.FromArgb(b[0], b[1], b[2], b[3]);
			Color color2 = Color.FromArgb(b[0], b[3], b[2], b[1]);

			MainGrid.Background = new SolidColorBrush(color);
			ClockerOutput.Background = new SolidColorBrush(color);


		}

		private void Menu_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (Chronograph.IsSelected)
			{
				MySplitView.IsPaneOpen = false;
				return;



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
				Frame Parental = (Frame)this.Parent;

				Parental.Content = new HelpPage();
			}


		}

		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{
			
				MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
			
		}
	}
}
