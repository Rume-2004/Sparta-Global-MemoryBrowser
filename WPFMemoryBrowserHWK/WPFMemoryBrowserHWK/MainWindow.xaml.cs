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
using System.IO;

namespace WPFMemoryBrowserHWK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> ComboBoxDataSource = new List<string>();
        public MainWindow()
        {

            InitializeComponent();
           

            populateCombo();
            foreach (var item in ComboBoxDataSource)
            {
                ComboBox.Items.Add(item);
                BRWControlApp.Navigate("https://www.spartaglobal.com");

            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string item = combo1.SelectedItem.ToString();
            //BRWControl.Navigate(item);
            
        }
        public void populateCombo()
        {
            ComboBoxDataSource.Add("https://www.google.com");
            ComboBoxDataSource.Add("https://www.yahoo.com");
            ComboBoxDataSource.Add("https://www.aws.com");
            ComboBoxDataSource.Add("https://www.microsoft.com");
        }
        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BRWControlApp.Navigate(ComboBox.Text);
                if (File.Exists("savedurl.txt"))
                {
                    string str = "savedurl.txt";
                    using(StreamWriter sw = File.AppendText(str))
                    {
                        sw.WriteLine(ComboBox.Text);
                        Read();
                    }   
                }
            }
        }

        private void Read()
        {
            string x = "C:/Users/tech-w86.LAPTOP-3ALVMOF3/Documents/Engineering26/Week6/Day3/Sparta-Global-MemoryBrowser/savedurl.txt";
            string[] url = File.ReadAllLines(x);
            {
                BRWControlApp.Navigate(url[0]);
            }
        }

    }
}
