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

        public static int SendInd;

        public static List<Element> ElementList;

        public MainWindow()
        {
            InitializeComponent();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            Element ElementInfo = new Element();
            

            using (var reader = new StreamReader(path + "dataDir\\data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ElementClassMap>();
                ElementList = csv.GetRecords<Element>().ToList();
            }


            for (int i = 0; i < ElementList.Count; i++)
            {
                Button btn = new Button();

                Grid.SetColumn(btn, ElementList[i].Xpos);
                Grid.SetRow(btn, ElementList[i].Ypos);

                btn.Margin = new Thickness(0.5);
                btn.BorderThickness = new Thickness(0);
                btn.FontWeight = FontWeights.Bold;


                BrushConverter bc = new BrushConverter();
                btn.Background = colorForCategory(ElementList[i].Category);
                btn.FontFamily = new FontFamily("Miriam");
                btn.Content = ElementList[i].Symbol;
                btn.Tag = i;

                btn.Click += ElBtnClick;

                MainGrid.Children.Add(btn);

                
            }


        }

        private void ElBtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            periyodikgrafik pg = new periyodikgrafik();
            SendInd = int.Parse(btn.Tag.ToString());
            pg.Show();
        }

        public static Brush colorForCategory(string category)
        {

            switch (category)
            {
                case "actinide":
                    return Brushes.Crimson;
                case "alkali metal":
                    return Brushes.Green;
                case "alkaline earth metal":
                    return Brushes.ForestGreen;
                case "diatomic nonmetal":
                    return Brushes.MediumSeaGreen;
                case "lanthanide":
                    return Brushes.Tomato;
                case "metalloid":
                    return Brushes.Silver;
                case "noble gas":
                    return Brushes.MediumPurple;
                case "polyatomic nonmetal":
                    return Brushes.DarkOliveGreen;
                case "post-transition metal":
                    return Brushes.DarkGray;
                case "transition metal":
                    return Brushes.DarkSlateGray;
                default:
                    return Brushes.Gray;
            };
        }
    }

}
