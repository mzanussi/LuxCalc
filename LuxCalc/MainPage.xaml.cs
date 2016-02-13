using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace LuxCalc
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Power.xaml", UriKind.Relative));
        }

        private void btnBeam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Beam.xaml", UriKind.Relative));
        }

        private void btnConversions_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Conversions.xaml", UriKind.Relative));
        }

        private void image1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}