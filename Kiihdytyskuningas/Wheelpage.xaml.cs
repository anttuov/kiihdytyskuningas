﻿using System;
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
    public sealed partial class Wheelpage : Page
    {
        public Wheelpage()
        {
            this.InitializeComponent();
            List<Wheel> wheels = new List<Wheel>();
            wheels.Add(new Wheel { price = 10, traction = 10, weight = 500, name = "Vanhat kumit" });
            wheels.Add(new Wheel { price = 440, traction = 30, weight = 600, name = "Pysyy kuival" });
            wheels.Add(new Wheel { price = 9001, traction = 100, weight = 550, name = "TOPTIER" });
            WheelListBox.ItemsSource = wheels;
            ResultTextBlock.Text = "JEEOOOOOE";
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

            Wheel wheel = (Wheel) e.ClickedItem;
            ResultTextBlock.Text = "Selected wheel: " + wheel.name;

        }
    }
}