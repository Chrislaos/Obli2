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
            adminWin._userCollection.Add(new User { Username = "admin", Password = "fotball", passExpires = adminWin.passwordExpires() });
        }
        public void SwitchControls(Control removeCtrl, Control addControl)
        {
           
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

            if (User.Text == "admin" && Password.Password == "fotball")
            {
                
                adminWin AdminWindow = new adminWin(Panel1);
                Panel1.Children.Add(AdminWindow);

            }
            else if(checkUser()){
                MessageBox.Show("YIPIKAYEY");
            }
            else
            {
                MessageBox.Show("SHIT");
            }
            clearBoxes();
        }
        private void clearBoxes(){
            User.Text = null;
            Password.Password = null;
        }

        public bool checkUser()
        {
            bool tempBool = false;
            foreach (User user in adminWin._userCollection)
            {

                if (user.Username == User.Text)
                {
                    if (user.Password == Password.Password) { 
                        tempBool = true;
                        if (user.passExpired) { }
                        else
                        {

                        }
                    }
                }
            }
            return tempBool;
        }
        
    }
}
