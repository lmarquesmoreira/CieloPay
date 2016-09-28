using System;
using Api.Entity;
using RestSharp;

namespace Api.Services
{
    public class LioService
    {
        public LioResponse CriarPedido(LioOrder pedido)
        {
            var restClient = new RestClient("***************");
            var request = new RestRequest(Method.POST);
            request.AddHeader("client-id", "***************");
            request.AddHeader("merchant_id", "***************");
            request.AddHeader("access-token", "***************");
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddJsonBody(pedido);
            var response = restClient.Execute<LioResponse>(request);
            return response.Data ?? new LioResponse { Id = "nulo" };
        }

        public LioOrder GetPedido(string id)
        {
            var restClient = new RestClient("***************" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("client-id", "***************");
            request.AddHeader("merchant_id", "***************");
            request.AddHeader("access-token", "***************");
            var response = restClient.Execute<LioOrder>(request);
            return response.Data;
        }
    }

    public class LioResponse
    {
        public string Id { get; set; }
    }
}