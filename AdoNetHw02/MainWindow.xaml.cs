using System;
using System.Windows;

namespace AdoNetHw02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();



        }


        private void PrintEquipment_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("EquipmentTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintManufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("ManufacturerTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintTrackMeter_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("TrackMeterTable.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
