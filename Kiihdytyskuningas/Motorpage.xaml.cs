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
        public Motorpage()
        {
            this.InitializeComponent();
            List<Motor> motors = new List<Motor>();
            motors.Add(new Motor { price = 10, rpm = 3000, power = 100, weight = 500, name = "Melko huono DX" });
            motors.Add(new Motor { price = 100, rpm = 5000, power = 300, weight = 500, name = "TäysShitti Sport" });
            motors.Add(new Motor { price = 1000, rpm = 9001, power = 800, weight = 550, name = "Nyt PäriZee" });
            MotorListBox.ItemsSource = motors;
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            // get root frame (which show pages)
            Frame rootFrame = Window.Current.Content as Frame;
            // did we get it correctly
            if (rootFrame == null) return;
            // navigate back if possible
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Motor motor = (Motor)e.ClickedItem;
            ResultTextBlock.Text = "Selected motor: " + motor.name;
        }
    }
}
