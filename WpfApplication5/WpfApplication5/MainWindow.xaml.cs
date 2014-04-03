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
using System.Threading;
using System.Timers;
using System.ComponentModel;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String[] username = new String[10];
        public static String[] password = new String[10];
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            logging_in();
        }
        
        

        private void bruker_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Enter_login(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logging_in();
            }
        }
        private void logging_in()
        {
            if (bruker.Text == "admin" && pass.Password == "fotball")
            {
                this.Content = new adminWin(this);

            }
            else
            {

            }
        }
    }
}
