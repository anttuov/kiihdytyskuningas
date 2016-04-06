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
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });
            motors.Add(new Motor { price = 10, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, power = 800, weight = 550, name = "Nyt PäriZee" });

            MotorListBox.ItemsSource = motors;
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), player);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = e.Parameter as Player;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            chosenmotor = (Motor)e.ClickedItem;
            ResultTextBlock.Text = "Selected motor: " + chosenmotor.name;

        }

        private void buybutton_Click(object sender, RoutedEventArgs e)
        {
            player.car.motor = chosenmotor;
            player.money = player.money - chosenmotor.price;
        }
    }
}
