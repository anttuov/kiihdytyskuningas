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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kiihdytyskuningas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Motorpage : Page
    {
        Player player;
        Motor chosenmotor;

        public Motorpage()
        {
            this.InitializeComponent();
            List<Motor> motors = new List<Motor>();
            motors.Add(new Motor { price = 0, power = 26, weight = 90, name = "Trabant 600CC 2t i2" });
            motors.Add(new Motor { price = 300, power = 40, weight = 100, name = "Trabant 600CC 2t i2 + tehoputki + säätösuutin" });
            motors.Add(new Motor { price = 800, power = 72, weight = 160, name = "Mercedes OM601 2.0 Diesel i4" });
            motors.Add(new Motor { price = 800, power = 71, weight = 120, name = "Ford 1.6 8v i4" });
            motors.Add(new Motor { price = 1000, power = 105, weight = 130, name = "Audi 2.0 8v i4" });
            motors.Add(new Motor { price = 1500, power = 130, weight = 130, name = "Toyta 4A-GE 1.6 16V i4" });
            motors.Add(new Motor { price = 1600, power = 140, weight = 180, name = "Mercedes OM601 2.0 Diesel i4T, Naapurin Teron turboviritelmä " });
            motors.Add(new Motor { price = 1600, power = 140, weight = 155, name = "BMW M44B19 1.8 16V i4" });
            motors.Add(new Motor { price = 1800, power = 160, weight = 135, name = "Toyta 4A-GE Black Top 1.6 20V i4" });
            motors.Add(new Motor { price = 2000, power = 204, weight = 240, name = "Opel C30SE 3.0 24V i6" });
            motors.Add(new Motor { price = 2000, power = 210, weight = 260, name = "BMW M30B34 3.5 12V i6" });
            motors.Add(new Motor { price = 2000, power = 230, weight = 290, name = "Mopar 318 5.2 OHV V8" });
            motors.Add(new Motor { price = 2200, power = 220, weight = 190, name = "Ford Cosworth 2.0 16v i4t" });
            motors.Add(new Motor { price = 2500, power = 230, weight = 140, name = "Toyta 4A-GE 1.6 16V i4 Group A" });
            motors.Add(new Motor { price = 2800, power = 280, weight = 250, name = "Opel C40SE Mantzel 4.0 24V i6" });
            motors.Add(new Motor { price = 3000, power = 140, weight = 270, name = "Toyota 2JZ-GTE 3.0 24V i6TT" });
            motors.Add(new Motor { price = 4000, power = 290, weight = 300, name = "Mopar 340 Six-Barrel 5.4 OHV V8" });

            MotorListBox.ItemsSource = motors;
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).player = player;
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null) return;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = (App.Current as App).player;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            chosenmotor = (Motor)e.ClickedItem;
            ResultTextBlock.Text = "Selected motor: " + chosenmotor.name;

        }

        private void buybutton_Click(object sender, RoutedEventArgs e)
        {
            if (player.money > chosenmotor.price)
            { 
            player.InstallPart(chosenmotor);
            player.money = player.money - chosenmotor.price;
            }
        }
    }
}
