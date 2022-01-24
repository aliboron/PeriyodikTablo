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
        public static List<Button>btnNonMetal;

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


                if (elNeg == 0)
                {
                    btn.Background = Brushes.MediumPurple;
                }else

                {
                    SolidColorBrush solidColorBrush = new(Color.FromArgb((byte)AlphaForElectroNeg(elNeg), 220, 20, 60));

                    btn.Background = solidColorBrush;
                }



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
                Button bton = new();

                Grid.SetColumn(bton, elements[i].Xpos);
                Grid.SetRow(bton, elements[i].Ypos);

                bton.Margin = new Thickness(0.5);
                bton.BorderThickness = new Thickness(0);
                bton.FontWeight = FontWeights.Bold;


                BrushConverter bc = new();

                decimal elNeg = ConvertWithFraction(elements[i].ElectronegativityPauling);


                bton.Background = ColorForCategory(elements[i].Category);



                bton.Content = elements[i].Symbol;
                bton.HorizontalContentAlignment = HorizontalAlignment.Center;
                bton.VerticalContentAlignment = VerticalAlignment.Center;
                bton.Tag = i;

                bton.Click += MainWindow.ElBtnClick;

                grid.Children.Add(bton);

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
                "Aktinit" => Brushes.Crimson,
                "Alkali Metal" => Brushes.SandyBrown,
                "Toprak Alkali Metal" => Brushes.SaddleBrown,
                "Lantanit" => Brushes.Tomato,
                "Yarı Metal" => Brushes.SeaGreen,
                "Soygaz" => Brushes.MediumPurple,
                "Ametal" => Brushes.DodgerBlue,
                "Halojen" => Brushes.LimeGreen,
                "Zayıf Metal" => Brushes.SlateGray,
                "Geçiş Metali" => Brushes.DarkSlateGray,
                _ => Brushes.Gray,
            };
            ;
        }


    }
}
