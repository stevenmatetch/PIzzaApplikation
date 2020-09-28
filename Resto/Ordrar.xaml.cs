using Resto.Models;
using Resto.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Resto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ordrar : Page
    {
        private PizzaViewModel pizzaViewModel;
        
        public Ordrar()
        {
            this.InitializeComponent();
            pizzaViewModel = new PizzaViewModel();

            start();
        }
        public async void start()
        {
            ListOrdrar.ItemsSource = await pizzaViewModel.GetOrdersAsync();
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Pizza.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                Frame.Navigate(typeof(MainPage));
            }
            if (Orders.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                Frame.Navigate(typeof(Ordrar));

            }
        }


        private  void HamburgerButton_Click_1(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var select = ListOrdrar.SelectedItems;
            foreach (Order order in select)
            {
                await pizzaViewModel.DeleteOrderAsync(order.Id);


            }

        }

        private async void ListOrdrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var select = ListOrdrar.SelectedItems;
            foreach (Order order in select)
            {
                await pizzaViewModel.DeleteOrderAsync(order.Id);


            }
           
        }
    }
}
