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
    public sealed partial class Gearpage : Page
    {
        Player player;
        Gearbox chosengearbox;
        public Gearpage()
        {
            this.InitializeComponent();
            List<Gearbox> gearboxes = new List<Gearbox>();
            gearboxes.Add(new Gearbox { price = 0, gears = 1, name = "Shimano" });
            gearboxes.Add(new Gearbox { price = 150, gears = 2, name = "GM Powerglide" });
            gearboxes.Add(new Gearbox { price = 250, gears = 3, name = "Mopar 727" });
            gearboxes.Add(new Gearbox { price = 550, gears = 4, name = "Toyota G40" });
            gearboxes.Add(new Gearbox { price = 800, gears = 5, name = "Getrag 240" });
            gearboxes.Add(new Gearbox { price = 1500, gears = 6, name = "Toyota V160" });
            gearboxes.Add(new Gearbox { price = 4000, gears = 8, name = "Jortsun serkun Imprezasta nyysitty Sekventaali-ihme" });

            GearboxListBox.ItemsSource = gearboxes;
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
            chosengearbox = (Gearbox)e.ClickedItem;
            ResultTextBlock.Text = "Selected gearbox: " + chosengearbox.name;

        }

        private void buybutton_Click(object sender, RoutedEventArgs e)
        {
            player.InstallPart(chosengearbox);
            player.money = player.money - chosengearbox.price;
        }
    }
}
