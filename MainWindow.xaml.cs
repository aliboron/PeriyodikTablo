using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.IO;
using CsvHelper;
using Microsoft.Win32;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using System.Windows.Controls;
using System.Windows.Media;

namespace PeriyodikTablo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPropActive = false;

        public static int sendInd { get; set; }
        int crMethodSwitch = 1;

        public static List<Element> ElementList;
        List<Element> sortedByElectroNegativity;

        decimal x;


        public MainWindow()
        {
            InitializeComponent();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            Element ElementInfo = new();
            

            using (var reader = new StreamReader(path + "dataDir\\data.csv"))
            using (var csv = new CsvReader(reader, new CultureInfo("en-GB")))
            {
                csv.Context.RegisterClassMap<ElementClassMap>();
                ElementList = csv.GetRecords<Element>().ToList();
            }

            /*sortedByElectroNegativity = ElementList.OrderBy(x => Double.Parse(x.ElectronegativityPauling)).ToList();
            sortedByElectroNegativity.Reverse();*/

            PeriodicCreators.CreateByElectroNeg(ElementList, MainGrid);

        }

        public static void ElBtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            Periyodikgrafik pg = new();
            sendInd = int.Parse(btn.Tag.ToString());
            pg.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MainGrid.Children.Remove(PeriodicCreators.buttons[1]);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();

            Button button = new();
            button.Click += Button_Click;
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 0);
            button.Background = Brushes.BurlyWood;
            button.Margin = new Thickness(3);
            button.BorderThickness = new Thickness(0);

            MainGrid.Children.Add(button);

            switch (crMethodSwitch)
            {
                case 0:
                    PeriodicCreators.CreateByElectroNeg(ElementList, MainGrid);
                    crMethodSwitch = 1;
                    button.Content = "EN";
                    break;
                case 1:
                    PeriodicCreators.CreateByCategory(ElementList, MainGrid);
                    crMethodSwitch = 0;
                    button.Content = "Category";
                    break;

            }
        }

    }

}
