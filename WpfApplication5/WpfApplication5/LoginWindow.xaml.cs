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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private Panel _parent;

        public LoginWindow(Panel parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            logging_in();
        }
        private void logging_in()
        {

            if (User.Text == "admin" && Password.Password == "fotball")
            {
                this.Content = new adminWin(this);

            }
            else
            {

            }
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logging_in();
            }
        }

    }
}
