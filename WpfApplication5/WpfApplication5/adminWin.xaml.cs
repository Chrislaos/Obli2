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
        private Panel tempPanel;
        static public ObservableCollection<User> _userCollection = new ObservableCollection<User>();
        

        public adminWin(Grid thePanel)
        {
            
            tempPanel = thePanel;
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            clockBox.Text = DateTime.Now.ToString();
            checkForExpired();
            refreshList();
            
        }
        private void removeUser()
        {
            _userCollection.RemoveAt(listviewReg.SelectedIndex);
            adminUser.Text = listviewReg.SelectedIndex.ToString();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addUser();
        }

        private void refreshList()
        {
            listviewReg.Items.Refresh();
        }
        public void addUser()
        {
            refreshList();
            _userCollection.Add(new User { Username = adminUser.Text, Password = adminPass.Password, passExpires = passwordExpires() });
        }
        public ObservableCollection<User> userCollection
        {
            get { return _userCollection; }
        }
        static public DateTime passwordExpires()
        {
            DateTime minutes = DateTime.Now;
            return minutes.AddSeconds(10);
        }
        public UserControl ParentControl;

        
        private void Logout_Click_Click(object sender, RoutedEventArgs e)
        {
            tempPanel.Children.Remove(this);
        }
        private void checkForExpired()
        {
            foreach (User user in adminWin._userCollection)
            {

                if (user.passExpires < DateTime.Now) { user.passExpired = true; }
            }
        }
        private void adminUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            removeUser();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_password();
        }
        private void Reset_password()
        {
            _userCollection[listviewReg.SelectedIndex].Password = reset_box.Password;
            _userCollection[listviewReg.SelectedIndex].passExpires = passwordExpires();
            _userCollection[listviewReg.SelectedIndex].passExpired = false;
        }

    }
}