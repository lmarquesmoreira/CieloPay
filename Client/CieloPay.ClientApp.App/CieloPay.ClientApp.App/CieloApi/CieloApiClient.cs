using CieloPay.ClientApp.App.CieloApi.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace CieloPay.ClientApp.App.CieloApi
{
    public class CieloApiClient
    {
        public Sale PostSaleAsync(Sale sale)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("***************");
                client.DefaultRequestHeaders.Add("MerchantId", "***************");
                client.DefaultRequestHeaders.Add("MerchantKey", "***************");

                var json = JsonConvert.SerializeObject(sale);

                var response = client.PostAsync("***************", new StringContent(json, Encoding.UTF8, "text/json")).Result;
                var strResponse = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Sale>(strResponse);
                }

                return sale;
            }
        }

        public LioOrder PostOrder(LioOrder sale)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("***************");

                var json = JsonConvert.SerializeObject(sale);

                var response = client.PostAsync("", new StringContent(json, Encoding.UTF8, "text/json")).Result;
                var strResponse = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<LioOrder>(strResponse);
                }

                return sale;
            }
        }
    }
}
