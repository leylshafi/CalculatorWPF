using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Source
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_calc.Text.Length > 1)
            {
                if ((txt_calc.Text.ToString()[txt_calc.Text.Length - 1] == '*' || txt_calc.Text.ToString()[txt_calc.Text.Length - 1] == '+' || txt_calc.Text.ToString()[txt_calc.Text.Length - 1] == '/' || txt_calc.Text.ToString()[txt_calc.Text.Length - 1] == '-') && ((sender as Button)?.Tag.ToString() == "*" || ((sender as Button)?.Tag.ToString() == "+" || (sender as Button)?.Tag.ToString() == "/" || (sender as Button)?.Tag.ToString() == "-")))
                                    {

                    return;
                }
            }
                
            if (txt_calc.Text.Contains('.') && (sender as Button)?.Tag.ToString() == ".")
                return;
            
            else
            {
                if (!((sender as Button)?.Tag.ToString() == "." && txt_calc.Text.Length == 0))
                    txt_calc.Text += (sender as Button)?.Tag;
                else
                    txt_calc.Text += "0.";

            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string formattedCalculation = txt_calc.Text;

            try
            {
                double result = double.Parse(new DataTable().Compute(formattedCalculation, null).ToString()!);

                if (result.ToString() == "∞")
                    throw new DivideByZeroException();

                txt_calc.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect please try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txt_calc.Text = string.Empty;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal.TryParse(txt_calc.Text, out decimal num);
                num *= -1;
                txt_calc.Text=num.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect please try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txt_calc.Text = string.Empty;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txt_calc.Text = txt_calc?.Text.Substring(0, txt_calc.Text.Length - 1);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            txt_calc.Text=String.Empty;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            double.TryParse((string)txt_calc.Text, out double num);
            if (sender is Button b)
            {
                switch (b.Tag.ToString())
                {
                    case "%":
                        num /= 100;
                        break;
                    case "sqrt":
                        num = Math.Sqrt(num);
                        break;
                    case "pow":
                        num = Math.Pow(num, 2);
                        break;
                    case "1/x":
                        num = 1 / num;
                        break;
                    default:
                        break;
                }
            }
           
           
            txt_calc.Text = num.ToString();
        }

       
    }
}
