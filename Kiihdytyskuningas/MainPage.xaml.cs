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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Kiihdytyskuningas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        Player player = new Player();

        

        public MainPage()
        {

            this.InitializeComponent();





        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = (App.Current as App).player;
            
            playertext.Text = player.ToString();
        }

        private void motorbutton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).player = player;
            this.Frame.Navigate(typeof(Motorpage), player);
        }

        private void gearbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Gearpage));
        }

        private void wheelbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Wheelspage));
        }

        private void carbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Carpage));
        }
    }
}
