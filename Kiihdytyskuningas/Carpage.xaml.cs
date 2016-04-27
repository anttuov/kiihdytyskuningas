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
    public sealed partial class Carpage : Page
    {
        Player player;
        Car chosencar;

        public Carpage()
        {
            this.InitializeComponent();
            List<Car> cars = new List<Car>();
            Car tmpcar = new Car { name = "Datsun 100A", price = 2000, weight = 600, img = "Assets/datsun100a.png" };
            tmpcar.SetMotor(new Motor { price = 0, power = 59, weight = 100, name = "Datsun 998cc 8v i4" });
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 4, name = "Datsun 100A Vaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 15, weight = 25, name = "Datsun peltivanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "Mercedes-Benz 200D W124", price = 3000, weight = 1300, img = "Assets/w124.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 72, weight = 160, name = "Mercedes 2.0 Diesel" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 4, name = "Mercedes 200D Vaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 20, weight = 30, name = "Mercedes peltivanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "Ford Taunus 1.6GL", price = 3500, weight = 1000, img = "Assets/taunus.png" };
            tmpcar.SetMotor(new Motor { price = 0, power = 71, weight = 120, name = "Ford 1.6 8v i4" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 4, name = "Ford Taunus Vaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 30, weight = 30, name = "Ford peltivanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "Audi 80", price = 4000, weight = 1100, img = "Assets/audi80.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 105, weight = 130, name = "Audi 2.0E 8v i4" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 5, name = "Audi 80 Vaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 40, weight = 30, name = "Audi peltivanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "BMW 318is e36", price = 4500, weight = 1100, img = "Assets/e36.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 140, weight = 155, name = "BMW 1.8E 16v i4" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 5, name = "BMW 318is Vaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 60, weight = 20, name = "e36 aluvanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "Opel Omega 3000", price = 5000, weight = 1300, img = "Assets/omega3000.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 204, weight = 240, name = "Opel 3.0E 24v i6" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 5, name = "Opel vakiogetrag" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 60, weight = 20, name = "Opel aluvanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "BMW 535i e34", price = 7000, weight = 1400, img = "Assets/e34.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 210, weight = 260, name = "BMW 3.5E 12v i6" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 5, name = "BMW vakiogetrag" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 60, weight = 20, name = "e34 aluvanteet + ensiasennuskumet" });
            cars.Add(tmpcar);

            tmpcar = new Car { name = "Toyota Sprinter Trueno Apex", price = 9000, weight = 800, img = "Assets/hachiroku.png" };
            tmpcar.SetMotor( new Motor { price = 0, power = 130, weight = 130, name = "Toyota 1.6E 16v i4" } );
            tmpcar.SetGearbox(new Gearbox { price = 0, gears = 5, name = "Toyota vakiovaihteisto" });
            tmpcar.SetWheel(new Wheel { price = 0, traction = 70, weight = 15, name = "RS-Watanabe + vakiokumet" });
            cars.Add(tmpcar);


            CarListBox.ItemsSource = cars;
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
            chosencar = (Car)e.ClickedItem;
            ResultTextBlock.Text = "Selected car: " + chosencar.name;

        }

        private void buybutton_Click(object sender, RoutedEventArgs e)
        {
            if (player.money > chosencar.price)
            {
                player.InstallPart(chosencar);
                player.money = player.money - chosencar.price;
            }
        }
    }
}
