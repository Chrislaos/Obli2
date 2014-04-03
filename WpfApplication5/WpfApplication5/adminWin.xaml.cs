﻿using System;
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
using System.Threading.Tasks;
using System.Threading;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for adminWin.xaml
    /// </summary>
    public partial class adminWin : UserControl
    {
        

        public adminWin(MainWindow mainVindu)
        {
            InitializeComponent();
            refreshList();
            
            
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
            listboxRegister.Items.Clear();
            foreach (String n in MainWindow.username) { listboxRegister.Items.Add(n); }

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
        //private static System.Timers.Timer aTimer;
        //private void clock()
        //{
        //    aTimer = new System.Timers.Timer(1000);
        //    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    aTimer.Enabled = true;
        //}
        //public void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    clockBox.Text = e.SignalTime.ToString();
        //}
        private void listViewBrukere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

    }
}