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
    public sealed partial class Wheelspage : Page
    {
        Player player;
        Wheel chosenwheel;
        public Wheelspage()
        {
            this.InitializeComponent();
            List<Wheel> wheels = new List<Wheel>();
            wheels.Add(new Wheel { price = 0, traction = 10, weight = 10, name = "Speed Hakkapeliitta + Pinnavanteet" });
            wheels.Add(new Wheel { price = 100, traction = 20, weight = 25, name = "TM -testihäviäjä Goodridet + Teräsvanteet" });
            wheels.Add(new Wheel { price = 250, traction = 40, weight = 20, name = "LingLong kesäkumet + kromimangelssit" });
            wheels.Add(new Wheel { price = 400, traction = 60, weight = 15, name = "BF Goodrich Radial T/A + 885 -BBS replikat" });
            wheels.Add(new Wheel { price = 600, traction = 80, weight = 10, name = "Pirelli matalaprofiilit + Enkeit" });
            wheels.Add(new Wheel { price = 1000, traction = 100, weight = 5, name = "Kemorasta nyysityt sliksit + BBS hiilikuituvanteet" });
            WheelListBox.ItemsSource = wheels;
            ResultTextBlock.Text = "JEEOOOOOE";
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
            chosenwheel = (Wheel)e.ClickedItem;
            ResultTextBlock.Text = "Selected wheel: " + chosenwheel.name;

        }

        private void buybutton_Click(object sender, RoutedEventArgs e)
        {
            player.InstallPart(chosenwheel);
            player.money = player.money - chosenwheel.price;
        }
    }
}
