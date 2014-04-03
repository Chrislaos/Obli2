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


namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String[] username = new String[10];
        public static String[] password = new String[10];
        private static System.Timers.Timer aTimer;


        public MainWindow()
        {
            Thread clockThread = new Thread(clock);
            InitializeComponent();
            clockThread.Start();
            

            username[0] = "admin"; password[0] = "fotball";
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            if (bruker.Text == "admin" && pass.Password == "fotball")
            {
                this.Content = new adminWin(this);
                    
            }
            else
            {
               
            }
        }

        private void bruker_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        public void clock()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            String Text = e.SignalTime.ToString();
            MessageBox.Show(Text);
            
            //Text = e.SignalTime.ToString();
        }
    }
}
