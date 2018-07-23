using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            string xWords = xTerm.Text;
            string numWords = numExpansion.Text;
            double x = Double.Parse(xWords);
            double num = Double.Parse(numWords);
            double seriesSum = 0.0;
            mathResult.Text = "";
            expandResult.Text = "";
            for (int j = 0; j < num; j++)
            {
                int fact = factorialize(j);
                double seriesTerm = Math.Pow(x, j)/fact;
                seriesSum += seriesTerm;
                if (j != 0)
                {
                    if (seriesTerm < 0)
                    {
                        mathResult.Text += " - ";
                        expandResult.Text += " - ";
                        seriesTerm = Math.Abs(seriesTerm);
                    }
                    else
                    {
                        mathResult.Text += " + ";
                        expandResult.Text += " + ";
                    }
                }
                mathResult.Text += seriesTerm.ToString();
                expandResult.Text += $"({Math.Abs(x)}^{j})/{fact}";
            }
            mathResult.Text += $" = {seriesSum}";
            expandResult.Text += $" = {seriesSum}";

        }

        private int factorialize(int i)
        {
            if ((i == 0) || (i == 1))
            {
                return 1;
            }
            else
            {
                int multiple = 1;
                for (int w = 1; w <= i; w++)
                {
                    multiple *= w;
                }
                return multiple;
            }
        }
    }
}
