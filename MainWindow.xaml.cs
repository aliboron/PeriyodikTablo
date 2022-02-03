using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.IO;
using CsvHelper;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Animation;

namespace PeriyodikTablo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int sendInd { get; set; }

        public static MainWindow mainWindow;

        public static List<Element> ElementList;

        PeriodicCreators Creators = new();



        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;

            

            // Verileri csv dosyasına yazmak için
            //
            //List<Element> sortedByNumber = ElementList.OrderBy(x => Convert.ToByte(x.Number)).ToList();
            //using (TextWriter writer = new StreamWriter(@"C:\test.csv", false, System.Text.Encoding.UTF8))
            //{
            //    var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            //    csv.Context.RegisterClassMap<ElementClassMap>();
            //    csv.WriteRecords(sortedByNumber); // where values implements IEnumerable
            //}

        }

        public static void ElBtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            mainWindow.BlackOverlay.Visibility = Visibility.Visible;

            Periyodikgrafik pg = new();
            pg.brush = btn.Background;
            sendInd = int.Parse(btn.Tag.ToString());
            
            pg.ShowDialog();
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MainGrid.Children.Remove(PeriodicCreators.buttons[1]);

            string path = AppDomain.CurrentDomain.BaseDirectory;


            if (File.Exists(path + "dataDir\\data.csv"))
            {
                using (var reader = new StreamReader(path + "dataDir\\data.csv"))
                using (var csv = new CsvReader(reader, new CultureInfo("en-GB")))
                {
                    csv.Context.RegisterClassMap<ElementClassMap>();
                    ElementList = csv.GetRecords<Element>().ToList();
                }
                Creators.CreateByCategoryOnStart(ElementList, MainGrid);
            }
            else
            {
                MessageBox.Show("Veri dosyası yok veya geçerli değil.", "UYARI", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }

        }

        public void SolidFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterSolid(ElementList, MainGrid);

        }

        public void LiquidFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterLiquid(ElementList, MainGrid);

        }

        public void GasFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterGas(ElementList, MainGrid);

        }

        public void NAFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterNA(ElementList, MainGrid);

        }

        public void MetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterMetals(ElementList, MainGrid);

        }

        public void NonMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterNonMetals(ElementList, MainGrid);

        }

        public void AlkaliMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterAlkaliMetals(ElementList, MainGrid);

        }
        public void EarthAlkaliMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterEarthAlkaliMetals(ElementList, MainGrid);

        }
        public void TransitionMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterTransMetal(ElementList, MainGrid);

        }
        public void PostTransMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterPostTransMetal(ElementList, MainGrid);

        }
        public void ActinidesFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterActinides(ElementList, MainGrid);

        }
        public void LanthanidesFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterLanthanides(ElementList, MainGrid);

        }

        public void MetalloidsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterMetalloids(ElementList, MainGrid);

        }
        public void OtherNonMetalsFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterOtherNonMetals(ElementList, MainGrid);

        }
        public void HalogensFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterHalogens(ElementList, MainGrid);

        }
        public void NobleGasesFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterNobleGases(ElementList, MainGrid);

        }

        public void NonCategorizedFilterToggle(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByFilterNonCategorized(ElementList, MainGrid);

        }


        private void ResetImageMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Image img = sender as Image;

            img.Opacity = 0.7;
        }
        private void ResetImageMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Image img = sender as Image;

            img.Opacity = 1;
        }

        private void ResetImageMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainGrid.Children.Clear();
            Creators.CreateByCategory(ElementList, MainGrid);
        }
    }

}
