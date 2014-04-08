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
using System.Collections.ObjectModel;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public bool passExpired = false;
        
        public MainWindow()
        {
            InitializeComponent();
            // Creates admin user with password expiring date 99 years head of time.
            adminWin._userCollection.Add(new User { Username = "admin", Password = "fotball", passExpires = DateTime.Now.AddYears(99), accountStatus = "Veteran" });
        }
        // Login Button
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            logging_in();
        }
        // A event that runs login function after "enter" button, this is linked up with the two textboxes.
        private void Enter_login(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logging_in();
            }
        }
        // Starts off checking for admin, then users. This function will open usercontrols or messageboxes.
        private void logging_in()
        {

            if (User.Text == "admin" && Password.Password == "fotball")
            {
                
                adminWin AdminWindow = new adminWin(Panel1);
                Panel1.Children.Add(AdminWindow);

            }
            else if(checkUser()){
                MessageBox.Show("ONLINE");
            }
            else
            {
                MessageBox.Show("Mismatch");
            }
            clearBoxes();
        }
        // Emptying textboxes.
        private void clearBoxes(){
            User.Text = null;
            Password.Password = null;
        }
        // Checking if user is part of the collection and returns a bool based on that. Also checks if the users password is "temporary" or "expired", and might open a new password window if needed.
        public bool checkUser()
        {
            bool tempBool = false; int index = -1;
            foreach (User user in adminWin._userCollection)
            {
                index++;
                if (user.Username == User.Text)
                {
                    if (user.Password == Password.Password) { 
                        tempBool = true;
                        if (user.accountStatus != "Valid") { 
                            NewPasswordWin newPassword = new NewPasswordWin(Panel1, index);
                            Panel1.Children.Add(newPassword);
                        }
                        else
                        {

                        }
                    }
                }
            }
            return tempBool;
        }
        // Event for exiting the program.
        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        
    }
}
