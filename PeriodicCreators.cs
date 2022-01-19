using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PeriyodikTablo
{
    class PeriodicCreators
    {

        public static void CreateByElectroNeg(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                Button btn = new();

                Grid.SetColumn(btn, elements[i].Xpos);
                Grid.SetRow(btn, elements[i].Ypos);

                btn.Margin = new Thickness(0.5);
                btn.BorderThickness = new Thickness(0);
                btn.FontWeight = FontWeights.Bold;


                BrushConverter bc = new();

                decimal elNeg = ConvertWithFraction(elements[i].ElectronegativityPauling);

                SolidColorBrush solidColorBrush = new(Color.FromArgb((byte)AlphaForElectroNeg(elNeg), 220, 20, 60));

                btn.Background = solidColorBrush;

                if (elNeg == 0)
                {
                    btn.Background = Brushes.MediumPurple;
                }
                else;



                btn.Content = $"{elements[i].Symbol}\n{elNeg}";
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.VerticalContentAlignment = VerticalAlignment.Center;
                btn.Tag = i;

                btn.Click += MainWindow.ElBtnClick;

                grid.Children.Add(btn);

            }

        }


        public static void CreateByCategory(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                Button btn = new();

                Grid.SetColumn(btn, elements[i].Xpos);
                Grid.SetRow(btn, elements[i].Ypos);

                btn.Margin = new Thickness(0.5);
                btn.BorderThickness = new Thickness(0);
                btn.FontWeight = FontWeights.Bold;


                BrushConverter bc = new();

                decimal elNeg = ConvertWithFraction(elements[i].ElectronegativityPauling);


                btn.Background = ColorForCategory(elements[i].Category);



                btn.Content = elements[i].Symbol;
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.VerticalContentAlignment = VerticalAlignment.Center;
                btn.Tag = i;

                btn.Click += MainWindow.ElBtnClick;

                grid.Children.Add(btn);

            }
        }




        static decimal ConvertWithFraction(string str)
        {
            return Convert.ToDecimal(str, new CultureInfo("en-GB"));
        }

        static decimal AlphaForElectroNeg(decimal electronegativity)
        {

            decimal x = electronegativity * (255 / 3.98m);

            return x;
        }

        public static Brush ColorForCategory(string category)
        {

            return category switch
            {
                "actinide" => Brushes.Crimson,
                "alkali metal" => Brushes.Green,
                "alkaline earth metal" => Brushes.ForestGreen,
                "diatomic nonmetal" => Brushes.MediumSeaGreen,
                "lanthanide" => Brushes.Tomato,
                "metalloid" => Brushes.Silver,
                "noble gas" => Brushes.MediumPurple,
                "polyatomic nonmetal" => Brushes.DarkOliveGreen,
                "post-transition metal" => Brushes.DarkGray,
                "transition metal" => Brushes.DarkSlateGray,
                _ => Brushes.Gray,
            };
            ;
        }


    }
}
