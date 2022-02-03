using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace PeriyodikTablo
{
    class PeriodicCreators
    {

        DoubleAnimation heightAnimation = new(40,63.5, TimeSpan.FromSeconds(0.3));
        DoubleAnimation widthAnimation = new(40, 63.5, TimeSpan.FromSeconds(0.3));

        SolidColorBrush[] lastElementColor = new SolidColorBrush[118];

        //------------------Diğer------------------//

        public void CreateByElectroNeg(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                Button btn = CreateBaseButton(elements, i);

                decimal elNeg = ConvertWithFraction(elements[i].ElectronegativityPauling);


                if (elNeg == 0)
                {
                    btn.Background = Brushes.MediumPurple;
                }else

                {
                    SolidColorBrush solidColorBrush = new(Color.FromArgb((byte)AlphaForElectroNeg(elNeg), 220, 20, 60));
                    

                    btn.Background = solidColorBrush;
                }


                grid.Children.Add(btn);

            }

        }

        //------------------KATERGORİ------------------//

        public void CreateByCategoryOnStart(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                Button btn = CreateBaseButton(elements, i);

                btn.Background = ColorForCategory(elements[i].Category);

                DoubleAnimation doubleAnimation = new(0.4, 1, TimeSpan.FromSeconds(0.5));
                

                switch (elements[i].Phase)
                {
                    case "Katı":
                        btn.Foreground = Brushes.White;
                        break;
                    case "Sıvı":
                        btn.Foreground = Brushes.RoyalBlue;
                        break;
                    case "Gaz":
                        btn.Foreground = Brushes.Red;
                        break;
                    case "Belirsiz":
                        break;
                }

                grid.Children.Add(btn);

                btn.BeginAnimation(Button.OpacityProperty, doubleAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByCategory(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());
                DoubleAnimation doubleAnimation = new(1, TimeSpan.FromSeconds(0.5));

                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));


                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                switch (elements[i].Phase)
                {
                    case "Katı":
                        btn.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "Sıvı":
                        btn.Foreground = new SolidColorBrush(Colors.RoyalBlue);
                        break;
                    case "Gaz":
                        btn.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    case "Belirsiz":
                        btn.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                }

                grid.Children.Add(btn);

                btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                btn.Foreground.BeginAnimation(SolidColorBrush.OpacityProperty, doubleAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;

            }
        }

        //------------------FAZ------------------//

        public void CreateByFilterSolid(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                
                Button btn = CreateBaseButton(elements, i);

                ColorAnimation mainColorAnimation = new(Colors.DarkSlateGray, TimeSpan.FromSeconds(0.5));
                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);


                if (elements[i].Phase == "Katı")
                {
                    btn.Foreground = Brushes.White;
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, mainColorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;

            }
        }

        public void CreateByFilterLiquid(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                ColorAnimation mainColorAnimation = new(Colors.RoyalBlue, TimeSpan.FromSeconds(0.5));
                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);


                if (elements[i].Phase == "Sıvı")
                {
                    btn.Foreground = Brushes.White;
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, mainColorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;

            }
        }

        public void CreateByFilterGas(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                ColorAnimation mainColorAnimation = new(Colors.OrangeRed, TimeSpan.FromSeconds(0.5));
                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);


                if (elements[i].Phase == "Gaz")
                {
                    btn.Foreground = Brushes.White;
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, mainColorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;

            }
        }

        public void CreateByFilterNA(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                ColorAnimation mainColorAnimation = new(Colors.Crimson, TimeSpan.FromSeconds(0.5));
                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);


                if (elements[i].Phase == "Belirsiz")
                {
                    btn.Foreground = Brushes.White;
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, mainColorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;

            }
        }

        //------------------METALLER------------------//

        public void CreateByFilterMetals(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (!(!elements[i].Category.Contains("Metal") && elements[i].Category != "Aktinit" && elements[i].Category != "Lantanit") && elements[i].Category != "Ametal" && elements[i].Category != "Yarı Metal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterAlkaliMetals(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Alkali Metal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterEarthAlkaliMetals(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Toprak Alkali Metal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterLanthanides(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Lantanit")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterActinides(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Aktinit")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterTransMetal(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Geçiş Metali")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterPostTransMetal(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Zayıf Metal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        //------------------YARI METALLER------------------//

        public void CreateByFilterMetalloids(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category == "Yarı Metal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        //------------------AMETALLER------------------//

        public void CreateByFilterNonMetals(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category is "Ametal" or "Halojen" or "Soygaz")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterOtherNonMetals(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category is "Ametal")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterHalogens(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category is "Halojen")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        public void CreateByFilterNobleGases(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category is "Soygaz")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }

        //------------------Belirsizler------------------//

        public void CreateByFilterNonCategorized(List<Element> elements, Grid grid)
        {

            for (int i = 0; i < elements.Count; i++)
            {

                Button btn = CreateBaseButton(elements, i);

                Color categoryColor = (Color)ColorConverter.ConvertFromString(ColorForCategory(elements[i].Category).ToString());

                ColorAnimation otherColorAnimation = new(Colors.LightGray, TimeSpan.FromSeconds(0.2));
                ColorAnimation colorAnimation = new(categoryColor, TimeSpan.FromSeconds(0.5));

                btn.Background = new SolidColorBrush(lastElementColor[i].Color);

                grid.Children.Add(btn);



                if (elements[i].Category is "Belirsiz")
                {
                    btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
                else btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, otherColorAnimation);

                lastElementColor[i] = (SolidColorBrush)btn.Background;
            }
        }






        private Button CreateBaseButton(List<Element> elements, int index)
        {
            Button btn = new();

            Grid.SetColumn(btn, elements[index].Xpos);
            Grid.SetRow(btn, elements[index].Ypos);

            btn.Margin = new Thickness(0.5);
            btn.BorderThickness = new Thickness(0);
            btn.FontSize = 15;
            btn.FontWeight = FontWeights.SemiBold;
            btn.Content = elements[index].Symbol;
            btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            btn.VerticalContentAlignment = VerticalAlignment.Center;
            btn.Click += MainWindow.ElBtnClick;
            btn.Tag = index;

            return btn;
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
                "Alkali Metal" => Brushes.SandyBrown,
                "Toprak Alkali Metal" => Brushes.SaddleBrown,
                "Geçiş Metali" => Brushes.DarkSlateGray,
                "Zayıf Metal" => Brushes.SteelBlue,
                "Yarı Metal" => Brushes.SeaGreen,
                "Ametal" => Brushes.DodgerBlue,
                "Halojen" => Brushes.LimeGreen,
                "Soygaz" => Brushes.MediumPurple,
                "Lantanit" => Brushes.Tomato,
                "Aktinit" => Brushes.Crimson,
                _ => Brushes.LightSlateGray,
            };
            ;
        }


    }
}
