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
            // Starts a DispatchTimer. Further down you find the event that hapens every second.
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        // Event to be run every second. It shows the clock and date in a textbox, then checks if any of the passwords are expired and refreshes the listview.
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            clockBox.Text = DateTime.Now.ToString();
            checkForExpired();
            refreshList();
        }
        // Takes the index from listview and removes the targeted user from the collection.
        private void removeUser()
        {
            try
            {
                _userCollection.RemoveAt(listviewReg.SelectedIndex);
                MessageBox.Show("User removed.");
            }
            catch (Exception e) { MessageBox.Show("Please choose a user from the list."); } 
        }
        // Event for adding users when clicking add button.
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addUser();
        }
        // Refreshed the listview.
        private void refreshList()
        {
            listviewReg.Items.Refresh();
        }
        // Adds user to collection if criteria is met.
        public void addUser()
        {
            refreshList();
            if (adminUser.Text.Length > 3 && adminPass.Password.Length > 3)
            {
                _userCollection.Add(new User { Username = adminUser.Text, Password = adminPass.Password, passExpires = passwordExpires(), accountStatus = "Temporary" });
            }
            else { MessageBox.Show("Username and password need to be equal or more then 4 characters."); }
            adminUser.Text = null;
            adminPass.Password = null;
        }
        public bool checkEqualUser(string x)
        {
            
        }
        // Needed for the listview binding with collection to work.
        public ObservableCollection<User> userCollection
        {
            get { return _userCollection; }
        }
        // Method that returns a time and date 30 seconds from when called.
        static public DateTime passwordExpires()
        {
            DateTime minutes = DateTime.Now;
            return minutes.AddSeconds(30);
        }
        // Event for logout button admin panel.
        private void Logout_Click_Click(object sender, RoutedEventArgs e)
        {
            tempPanel.Children.Remove(this);
        }
        // Checks if any passwords are expired and sets the account status to outdated if they are.
        private void checkForExpired()
        {
            foreach (User user in adminWin._userCollection)
            {

                if (user.passExpires < DateTime.Now) { user.accountStatus = "Outdated"; }
            }
        }
        // Event for delete button.
        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            removeUser();
        }
        // Event for reset button.
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_password();
        }
        // Resets password by changing it, giving it new expiring date and changing account status to "temporary".
        private void Reset_password()
        {
            if (reset_box.Password.Length > 3)
            {
                try
                {
                    _userCollection[listviewReg.SelectedIndex].Password = reset_box.Password;
                    _userCollection[listviewReg.SelectedIndex].passExpires = passwordExpires();
                    _userCollection[listviewReg.SelectedIndex].accountStatus = "Temporary";
                    reset_box.Password = null;
                    MessageBox.Show("Success.");
                }
                catch (Exception e) { MessageBox.Show("Please choose a user from the list."); }
            }
            else { MessageBox.Show("Username and password need to be equal or more then 4 characters."); }
        }
        // Event for the Username header, sorts the collection/listview after usernames.
        private void GridViewColumnHeader_Username(object sender, RoutedEventArgs e)
        {
            List<User> templist = new List<User>(_userCollection.OrderBy(a => a.Username));
            _userCollection.Clear();
            foreach (User c in templist)
                _userCollection.Add(c);
            refreshList();
        }
        // Event for the New Password header, sorts the collection/listview after passExpires.
        private void GridViewColumnHeader_NewPassword(object sender, RoutedEventArgs e)
        {
            List<User> templist = new List<User>(_userCollection.OrderBy(a => a.passExpires));
            _userCollection.Clear();
            foreach (User c in templist)
                _userCollection.Add(c);
            refreshList();
        }
        // Event for the Account Status header, sorts the collection/listview after accountStatus.
        private void GridViewColumnHeader_AccountStatus(object sender, RoutedEventArgs e)
        {
            List<User> templist = new List<User>(_userCollection.OrderBy(a => a.accountStatus));
            _userCollection.Clear();
            foreach (User c in templist)
                _userCollection.Add(c);
            refreshList();
        }
        // A event that runs addUser function after "enter" key, this is linked up with the two textboxes.
        private void Enter_addUser(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addUser();
            }
        }
        // Event for Search button.
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            searchForUser();
        }
        // This method searches through the user collection for the string in search_box, uses the index it finds to select item in listview and scrolls to it.
        private void searchForUser()
        {
            var q = _userCollection.IndexOf(_userCollection.Where(a => a.Username == search_box.Text).FirstOrDefault());
            listviewReg.SelectedIndex = q;
            listviewReg.ScrollIntoView(listviewReg.SelectedItem);
            search_box.Text = null;
        }
        // Event for exiting the program.
        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        // Event for enter key in searchbox.
        private void Enter_Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchForUser();
            }
        }
        // Event for enter key in resetBox.
        private void Enter_Reset(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Reset_password();
            }
        }

    }
}