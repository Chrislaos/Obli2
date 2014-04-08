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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for NewPasswordWin.xaml
    /// </summary>
    public partial class NewPasswordWin : UserControl
    {
        int bigIndex; Panel tempPanel;

        public NewPasswordWin(Grid panel, int index)
        {
            bigIndex = index; tempPanel = panel;
            InitializeComponent();
            usernameDisplay.Text = adminWin._userCollection[bigIndex].Username;

        }
        // Checks if input password is a match with old password.
        private bool checkOldPassword()
        {
            if (oldPassword.Password == adminWin._userCollection[bigIndex].Password) { return true; }
            else { return false; }
        }
        // Checks if used typed the new password two times correct.
        private bool checkNewPassword()
        {
            if (newPasswordBox.Password == newPasswordBox2.Password) { return true; }
            else { return false; }
        }
        // Checks if new password is same as old.
        private bool checkNewEqualsNotOld()
        {
            if (oldPassword.Password != newPasswordBox.Password) { return true; }
            else { return false; }
        }
        // Event for done button.
        private void done_button_Click(object sender, RoutedEventArgs e)
        {
            processDone();
        }
        // Closes this panel.
        private void closeNewPasswordWin() { tempPanel.Children.Remove(this); }
        // Event for exit button.
        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        // Method that checks that everything is ok, adds password if it is or gives back an error message in a messagebox if it is not.
        private void processDone(){
            if (checkOldPassword())
            {
                if (checkNewPassword())
                {
                    if (checkNewEqualsNotOld())
                    {
                        if (notToShort())
                        {
                            adminWin._userCollection[bigIndex].Password = newPasswordBox.Password;
                            adminWin._userCollection[bigIndex].passExpires = adminWin.passwordExpires();
                            adminWin._userCollection[bigIndex].accountStatus = "Valid";
                            closeNewPasswordWin();
                        }
                        else { MessageBox.Show("Username and password need to be equal or more then 4 characters."); }
                    }
                    else { MessageBox.Show("You can not have the same password twice in a row for security reasons."); }

                }
                else { MessageBox.Show("Your password did not match. please try again."); }
            }
            else { MessageBox.Show("Your old password was a mismatch. Please try again."); }
        }
        // Checks if password is to short.
        private bool notToShort()
        {
            if (newPasswordBox.Password.Length > 3 && newPasswordBox2.Password.Length > 3) { return true; }
            else { return false; }
        }
        // A event that runs processDone after "enter" key, this is linked up with the three textboxes.
        private void Enter_press(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                processDone();
            }
        }
        // Event for exiting the program.
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            tempPanel.Children.Remove(this);
        }
    }
}

