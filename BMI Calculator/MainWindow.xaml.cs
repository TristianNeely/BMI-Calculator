using System;
using System.Collections.Generic;
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
using System.Windows.Forms;

namespace BMI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double BMIvar;
        public double Heightvar;
        public double Weightvar;
        public string result1;





        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Clear Cick 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lastname.Text = "";
            firstname.Text = "";
            phonenumber.Text = "";
            Height.Text = "";
            Weight.Text = "";
            BMI.Text = "";
            result.Text = "";
        }

        private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Heightvar = double.Parse(Height.Text);
            Weightvar = double.Parse(Weight.Text);

            BMIvar = Weightvar / Heightvar / Heightvar * 703;

            // No Decimal code
            //BMI.Text = Convert.ToString(Convert.ToInt32(BMIvar));

            // v has decimals
            BMI.Text = Convert.ToString(BMIvar);

            if (BMIvar <= 18.5)
            {
                result.Text = "According to CDC.gov BMI Calculator you are underweight.";
                //System.Windows.MessageBox.Show("According to CDC.gov BMI Calculator you are underweight.");
            }
            else if (BMIvar >= 18.5 && BMIvar <= 24.9)
            {
                result.Text = "According to CDC.gov BMI Calculator you are Normal or Healthy.";
                //System.Windows.MessageBox.Show("According to CDC.gov BMI Calculator you are Normal or Healthy.");
            }
            else if (BMIvar >= 25.0 && BMIvar <= 29.9)
            {
                result.Text = "According to CDC.gov BMI Calculator you are Overweight.";
                //System.Windows.MessageBox.Show("According to CDC.gov BMI Calculator you are Overweight.");
            }
            else if (BMIvar >= 30.0 && BMIvar <= 49.9)
            {
                result.Text = "According to CDC.gov BMI Calculator you are Obese.";
                //System.Windows.MessageBox.Show("According to CDC.gov BMI Calculator you are Obese.");
            }
            else if (BMIvar >= 50.0 && BMIvar <= 100)
            {
                result.Text = "oof";
                //System.Windows.MessageBox.Show("oof");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}