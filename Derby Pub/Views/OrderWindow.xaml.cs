﻿using Derby_Pub.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow(Dictionary<string, int> productDictionaryList)
        {
            InitializeComponent();
            ((OrderViewModel)this.DataContext).ProductDictionaryList = productDictionaryList;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}