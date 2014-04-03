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
using System.Timers;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;
using System.Collections.ObjectModel;


namespace WpfApplication5
{
    
    public partial class adminWin : UserControl
    {
        ObservableCollection<User> _userCollection = new ObservableCollection<User>();

        public adminWin(MainWindow mainVindu)
        {
            
            InitializeComponent();
            refreshList();
            
            _userCollection.Add(new User{ Username = "admin", Password = "fotball", passExpires = passwordExpires()});

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            clockBox.Text = DateTime.Now.ToString();
        }
        private void adminUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        // Testing if possible while adding user and password to list through button click.
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
            bool test1 = addRegister(adminUser.Text, adminPass.Password);
            refreshList();
            if (test1) { adminUser.Text = "Success"; }
            else { adminUser.Text = "Unable"; }
        }
        // Updating listbox window
        public void refreshList()
        {
            _userCollection.Add(new User { Username = adminUser.Text, Password = adminPass.Password, passExpires = passwordExpires() });
        }
        public ObservableCollection<User> userCollection
        {
            get { return _userCollection; }
        }
        public DateTime passwordExpires()
        {
            DateTime minutes = DateTime.Now;
            return minutes.AddMinutes(2);
        }
        // Function for adding user and password
        public bool addRegister(String x, String y)
        {
            bool boolCheck = true;
            for (int i = 1; i < 10; i++)
            {

                if (MainWindow.username[i] == null)
                {
                    MainWindow.username[i] = x;
                    MainWindow.password[i] = y;
                    i = 10;
                    boolCheck = true;
                }
                else
                {
                    boolCheck = false;
                }
            }
            return boolCheck;
            
        }
        private void listViewBrukere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

    }
}