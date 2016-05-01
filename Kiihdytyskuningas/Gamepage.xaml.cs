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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kiihdytyskuningas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Gamepage : Page
    {
        private DispatcherTimer timer;
        private DispatcherTimer timercountdown;
        double speed = 0;
        double speed2 = 0;
        double accel;
        double accel2;
        public int pos;
        private int countdown = 3;
        int gear = 1;
        double rpms = 0;
        Player player;
        double position = 0;
        double position2 = 0;
        public Gamepage()
        {
            this.InitializeComponent();

            timercountdown = new DispatcherTimer();
            timercountdown.Tick += Countdown_Tick;
            timercountdown.Interval = new TimeSpan(0, 0, 0, 1, 0);

            timercountdown.Start();


        }
        // 3..2..1.. 
        private void Countdown_Tick(object sender, object e)
        {
            countdown = countdown - 1;
            debugtext.Text = ""+countdown;
            if(countdown == 0)
            {
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);

                timer.Start();
                timercountdown.Stop();
            }

        }
        //after countdown race is on
        private void Timer_Tick(object sender, object e)
        {
            if (rpms < 80)
            { 
            speed = speed + accel;
            }
            speed2 = speed2 + accel2;
            rpms = rpms+accel*(20/gear);
            if (gear == player.Car.Gearbox.gears && rpms > 80)
                rpms = 80;
            position = position + speed;
            position2 = position2 + speed2;
            Canvas.SetLeft(this.background, -position);
            Canvas.SetLeft(this.carimg2, 40-(position - position2));
            rpm.Value = rpms;
            //debugtext.Text = "speed: " + speed + " rpms:" + rpms + " gear: " + gear + " position: "+position;
            debugtext.Text = "";

            if (position > 6000)
            {
                player.money = player.money + 1000;
                timer.Stop();
                (App.Current as App).player = player;
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null) return;
                if (rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                }
            }

            if (position2 > 6000)
            {
                timer.Stop();
                (App.Current as App).player = player;
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null) return;
                if (rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                }
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = (App.Current as App).player;
            accel = player.Car.PowerFunction();
            accel2 = accel + 0.002;
            //load car images
            carimg.Source = new BitmapImage( new Uri("ms-appx:///"+player.Car.img, UriKind.Absolute));
            carimg2.Source = new BitmapImage(new Uri("ms-appx:///Assets/hachiroku.png", UriKind.Absolute));


        }


        private void shift_Click(object sender, RoutedEventArgs e)
        {
            //very realistic shifting math
            if(gear < player.Car.Gearbox.gears)
            {

             
            double shiftvalue = Math.Abs((80 - rpms));
            if (shiftvalue < 2)
                accel = accel + 0.02;
            else if (shiftvalue < 4)
                accel = accel + 0.01;
            else
                accel = accel - 0.01;

            if (accel < 0.01)
                accel = 0.01;

            rpms = 0;
            gear = gear + 1;
            }

        }
    }
}
