using Newtonsoft.Json;
using Resto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Resto.ViewModels
{
  public  class PizzaViewModel
  {
        public  ObservableCollection<Pizza> pizzorB;
        public  ObservableCollection<Pizza> pizzor { get; set; }
        public ObservableCollection<Order> Ordrar { get; set; }

        static HttpClient httpClient = new HttpClient();
        static string url = "http://localhost:57638/api/";

        public PizzaViewModel()
        {
            pizzorB = new ObservableCollection<Pizza>();
            pizzor = new ObservableCollection<Pizza>();
            Ordrar = new ObservableCollection<Order>();
        }
        public async Task<ObservableCollection<Pizza>> GetPizzorAsync()
        {
            ObservableCollection<Pizza> pizzorr = new ObservableCollection<Pizza>();
            var jsonPizzor = await httpClient.GetStringAsync(url + "PizzaMenus");
            pizzorr = JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(jsonPizzor);
            return pizzorr;

        }


        public async Task<ObservableCollection<Order>> GetOrdersAsync()
        {
            ObservableCollection<Order> Orders = new ObservableCollection<Order>();
            var jasonOrder = await httpClient.GetStringAsync(url + "Orders");
            Orders = JsonConvert.DeserializeObject<ObservableCollection<Order>>(jasonOrder);
            return Orders;
        }
        //public static async Task<int> DeleteOrderAsync(int id)
        //{
        //    var httpClient = new System.Net.Http.HttpClient(); 
        //    var result = await httpClient.DeleteAsync(url + "Orders" + id);
        //    return int.Parse(await result.Content.ReadAsStringAsync());

        //}

        public async  Task DeleteOrderAsync(int id)
        {
            
            var httpClient = new System.Net.Http.HttpClient();

            await httpClient.DeleteAsync(url + "Orders" + id);
          
        }
        //private static HttpResponseMessage ClientDeleteRequest(string RequestURI)
        //{
        //    HttpClient client = new HttpClient();
          
        //    client.DefaultRequestHeaders.Accept.Clear();

        //    HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
        //    return response;
        //}
        //public HttpResponseMessage DeleteEmployee(int id)
        //{

        //   Order or =  GetOrdersAsync();
        //    if (or == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    Ordrar.Remove(or);
        //    var response = new HttpResponseMessage();
        //    response.Headers.Add("DeleteMessage", "Succsessfuly Deleted!!!");
        //    return response;
        //}
        public static async Task<int> AddOrderAsync(Order o)
        {
            using (HttpClient client = new HttpClient())
            {
                var order = JsonConvert.SerializeObject(o);
                HttpContent httpContent = new StringContent(order);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(url + "Orders", httpContent);
                return int.Parse(await result.Content.ReadAsStringAsync());
            }
        }
        public static async Task<List<Pizza>> AddPizzasAsync(List<Pizza> po)
        {
            List<Pizza> response = new List<Pizza>();

            using (HttpClient client = new HttpClient())
            {
                var order = JsonConvert.SerializeObject(po);
                HttpContent httpContent = new StringContent(order);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(url + "Pizzas", httpContent);
                var pizzas = await result.Content.ReadAsStringAsync();

                if (pizzas != null)
                {
                    response = JsonConvert.DeserializeObject<List<Pizza>>(pizzas);
                }

                return response;

            }

        }
        public static async Task AddPizzaOrderAsync(int a, List<Pizza> pizzalist)

        {
            List<PizzaOrder> temp = new List<PizzaOrder>();

            foreach (var piz in pizzalist)
            {
                temp.Add(new PizzaOrder() { OrderId = a, PizzaId = piz.Id });
            }
            var order = JsonConvert.SerializeObject(temp);
            HttpContent httpContent = new StringContent(order);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await httpClient.PostAsync(url + "PizzaOrders", httpContent);

        }
        internal  void AddPizza(Pizza pizza)
        {
            pizzorB.Add(pizza);
        }
        internal  void RemovePizza(Pizza pizza)
        {
            pizzorB.Remove(pizza);
        }
       
  }
}
