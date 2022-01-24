using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PeriyodikTablo
{
    /// <summary>
    /// Interaction logic for periyodikgrafik.xaml
    /// </summary>
    public partial class Periyodikgrafik : Window
    {
        Element cloneElement = new();

        public Brush brush;

        public Periyodikgrafik()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TitleBorder.Background = brush;

            cloneElement = MainWindow.ElementList[MainWindow.sendInd];

            elNumber.Foreground = brush;
            elNumber.Content = cloneElement.Number.ToString();
            elSymbol.Foreground = brush;
            elSymbol.Content = cloneElement.Symbol.ToString();
            elName.Foreground = brush;
            elName.Content = cloneElement.Name.ToString();

            elCategory.Content += cloneElement.Category.ToString();
            elPhase.Content += cloneElement.Phase.ToString();
            elAtomicMass.Content += cloneElement.AtomicMass.ToString();
            elDensity.Content += cloneElement.Density.ToString();
            elElectroNeg.Content += cloneElement.ElectronegativityPauling.ToString();
            elElectroAff.Content += cloneElement.ElectronAffinity.ToString();
            elFounder.Content += cloneElement.DiscoveredBy.ToString();
            elElectroConfigSemantic.Content += cloneElement.ElectronConfigurationSemantic.ToString();


            rectEl.Fill = brush;

            for (int i = 5; i < 13; i +=2)
            {
                Border borderBG = new();
                borderBG.Background = brush;
                Grid.SetRow(borderBG, i);
                borderBG.Opacity = 0.3;
                propGrid.Children.Add(borderBG);

                Border borderBG2 = new();
                borderBG2.Background = brush;
                Grid.SetRow(borderBG2, i + 1);
                borderBG2.Opacity = 0.6;
                propGrid.Children.Add(borderBG2);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show();

            Process.Start("explorer", cloneElement.Source);
        }

        private void Ellipse_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Ellipse_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;

            ellipse.Opacity = 0.7;
        }

        private void Ellipse_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;

            ellipse.Opacity = 1;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void OpenWiki(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer", cloneElement.Source);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Opacity = 0.7;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Opacity = 1;
        }
    }
}
