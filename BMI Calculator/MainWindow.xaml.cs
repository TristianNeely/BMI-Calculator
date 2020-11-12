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
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;

namespace BMI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    [XmlRoot("BMI_Calculator", Namespace = "www.bmicalc.ninja")]
    public partial class MainWindow : Window
    {
       public string FilePath = "C:\\Users\\neely_tristian\\Documents\\";
        public string FileName = "yourBMI.xml";

        //public Customer customer1 = new Customer();



        public double BMIvar;
        public double Heightvar;
        public double Weightvar;
        public string result1;

        public class Customer
        {
            [XmlAttribute("Last Name")]
            public string lastName { get; set; }

            [XmlAttribute("First Name")]
            public string firstName { get; set; }

            [XmlAttribute("Phone Number")]
            public string phoneNumber { get; set; }

            [XmlAttribute("Height")]
            public int heightInches { get; set; }

            [XmlAttribute("Weight")]
            public int weightLbs { get; set; }

            [XmlAttribute("Customer BMI")]
            public string custBMI { get; set; }

            [XmlAttribute("Status")]
            public string statusTitle { get; set; }




        }


        public MainWindow()
        {
            InitializeComponent();

            OnLoadStats();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Clear Cick 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lastnamebox.Text = "";
            firstnamebox.Text = "";
            phonenumberbox.Text = "";
            Height2.Text = "";
            Weight.Text = "";
            BMI.Text = "";
            result.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Customer customer1 = new Customer();




            customer1.lastName = lastnamebox.Text;
            customer1.firstName = firstnamebox.Text;
            customer1.phoneNumber = phonenumberbox.Text;
            customer1.heightInches = Convert.ToInt32(Height2.Text);
            customer1.weightLbs = Convert.ToInt32(Weight.Text);
            customer1.custBMI = Convert.ToString(BMI.Text);








            Heightvar = double.Parse(Height2.Text);
            Weightvar = double.Parse(Weight.Text);

            BMIvar = Weightvar / Heightvar / Heightvar * 703;


            // No Decimal code
            BMI.Text = Convert.ToString(Convert.ToInt32(BMIvar));

            // v has decimals
            //BMI.Text = Convert.ToString(BMIvar);

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


            TextWriter writer = new StreamWriter(FilePath + FileName);
            XmlSerializer ser = new XmlSerializer(typeof(Customer));
            ser.Serialize(writer, customer1);
            writer.Close();





        }


        private void OnLoadStats()
        {
            Customer cust = new Customer();

            XmlSerializer des = new XmlSerializer(typeof(Customer));
            using (XmlReader reader = XmlReader.Create(FilePath + FileName))
            {
                cust = (Customer)des.Deserialize(reader);

                lastnamebox.Text = cust.lastName;
                firstnamebox.Text = cust.firstName;
                phonenumberbox.Text = cust.phoneNumber;
                Height2.Text = Convert.ToString(cust.heightInches);
                Weight.Text = Convert.ToString(cust.weightLbs);
                BMI.Text = Convert.ToString(cust.custBMI);


            }

            DataSet xmlData = new DataSet();
            xmlData.ReadXml(FilePath + FileName, XmlReadMode.Auto);
            datagridlol.ItemsSource = xmlData.Tables[0].DefaultView;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
