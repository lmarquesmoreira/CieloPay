using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CieloPay.ClientApp.App.ViewModel;
using Newtonsoft.Json;

namespace CieloPay.ClientApp.App
{
    public class RestService
    {
        HttpClient client; 

        public RestService()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("***************");
        }

        public List<FoodMenuItemViewModel> RefreshFoodMenu()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("***************");

                var response = client.GetAsync("produto").Result;

                var content = response.Content.ReadAsStringAsync().Result;
                return  JsonConvert.DeserializeObject<List<FoodMenuItemViewModel>>(content);

            }
        }
            
		public List<MyOrdersViewModel> Orders()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("***************");

				var response = client.GetAsync("pedido").Result;
				var content = response.Content.ReadAsStringAsync().Result;
				return JsonConvert.DeserializeObject<List<MyOrdersViewModel>>(content);
			}
		}

		public User User()
        {

            using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("***************");

				var response = client.GetAsync("user/1").Result;
				var content = response.Content.ReadAsStringAsync().Result;
				return JsonConvert.DeserializeObject<User>(content);
			}
        }
    }
}