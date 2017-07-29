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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EssentialTimeKeeper
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{

		public StopWatch stopAlot = null;
		public Size holdSmallSize = new Size();

		public MainPage()
		{
			this.InitializeComponent();
			getSmall();
			FrameWork.Content = new Clocker();
			var av = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			var bounds = av.VisibleBounds;

			holdSmallSize = new Size(av.VisibleBounds.Width, av.VisibleBounds.Height);

		}
		private void getSmall()
		{
			var viewer = ApplicationView.GetForCurrentView();
			Size j = new Size(125, 125);
			viewer.SetPreferredMinSize(j);
			

		}
		public void getSmallAgain()
		{
			var viewer = ApplicationView.GetForCurrentView();
			viewer.TryResizeView(holdSmallSize);
		}
		public void getBig()
		{

			//https://stackoverflow.com/questions/35247320/how-to-maximize-a-uwp-window-not-fullscreen/45388536#45388536
			/*
			var viewer = ApplicationView.GetForCurrentView();
			viewer.TryEnterFullScreenMode();
			*/


			var av = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			var di = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
			var bounds = av.VisibleBounds;

			holdSmallSize = new Size(av.VisibleBounds.Width, av.VisibleBounds.Height);



			var factor = di.RawPixelsPerViewPixel;
			Size size = new Size(di.ScreenWidthInRawPixels, di.ScreenHeightInRawPixels);
			size.Height -= 100;
			size.Width -= 100;
			av.TryResizeView(size);



		}
		public void holderOfChronograph(StopWatch j)
		{
			stopAlot = j;
		}

	}	
}
