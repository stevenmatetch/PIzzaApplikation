using Resto.Models;
using Resto.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Resto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {



        private PizzaViewModel pizzaViewModel;


        public double _totalPris;
        double Totalpris
        {
            get
            {
                return _totalPris;
            }
            set
            {
                _totalPris = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Totalpris"));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;






        public MainPage()
        {

            this.InitializeComponent();


            BackButton.Visibility = Visibility.Collapsed;
            pizzaViewModel = new PizzaViewModel();
        

            start();
        }
        public async void start()
        {
            Grid.ItemsSource = await pizzaViewModel.GetPizzorAsync();
        }

        private void Grid_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            pizzaViewModel.AddPizza((Pizza)e.ClickedItem);
            AddPris(((Pizza)e.ClickedItem).Pris);
         
        }
        public void AddPris(double sum)
        {
            Totalpris += sum;
        }
        //public void SubPris(double sum)
        //{
        //    Totalpris -= sum;
        //}


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

        private void HamburgerButton_Click_1(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

        }



        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            Order o = new Order(DateTime.Now);
            int x = await PizzaViewModel.AddOrderAsync(o);
            List<Pizza> li = await PizzaViewModel.AddPizzasAsync(pizzaViewModel.pizzorB.ToList());
            await PizzaViewModel.AddPizzaOrderAsync(x, li);


            var dialog = new ContentDialog1();
            var result = dialog.ShowAsync();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           




        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SubPris(((Pizza)ListView.SelectedItems).Pris);
            var select = ListView.SelectedItems;
            foreach (Pizza piz in select)
            {

                pizzaViewModel.RemovePizza(piz);

            }

           
        }
    }
}
