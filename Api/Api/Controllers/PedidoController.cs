using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Entity;
using Api.Services;
using Dapper;
using WebGrease.Css.Extensions;

namespace Api.Controllers
{
    public class PedidoController : ApiController
    {
        private AppContext _context;
        private string _conString;
        private readonly LioService _lioService;

        public PedidoController()
        {
            _context = new AppContext();
            _conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _lioService = new LioService();
        }

        [HttpPost]
        [Route("api/pedido", Name = "Pedido")]
        public async Task<IHttpActionResult> Post(LioOrder pedido)
        {

            _context.Orders.Add(pedido);

            foreach (var itemPedido in pedido.items)
            {
                itemPedido.OrderId = pedido.id;
                _context.OrderItens.Add(itemPedido);
            }
            var response = _lioService.CriarPedido(pedido);
            pedido.LioResponseId = response.Id ?? "nulo";
            await _context.SaveChangesAsync();
            return Content(HttpStatusCode.Created, pedido);
        }

        [Route("api/pedido", Name = "Pedidos")]
        [HttpGet]
        public async Task<IEnumerable<LioOrder>> GetPedido()
        {
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var query = @"select * from LioOrders lo inner join Users u on u.Id = lo.UserId";
                var pedidos = await con.QueryAsync<LioOrder, User, LioOrder>(query,
                    (a, g) =>
                    {
                        a.User = g;
                        return a;
                    });

                query = "select * from LioOrderItems where OrderId In @pedidoIds";
                var pedidoIds = pedidos.Select(x => x.id);
                var itens = await con.QueryAsync<LioOrderItem>(query, new { pedidoIds });
                foreach (var ped in pedidos)
                {
                    if (ped.User != null)
                    {
                        var queryAd = @"select * from Addresses where UserId = @Id";
                        var addresses = con.Query<Address>(queryAd, new { Id = ped.User.Id });
                        ped.User.Addresses = addresses.ToList();
                    }

                    ped.items = itens.Where(x => x.OrderId == ped.id).ToList();
                    itens.Where(x => x.OrderId == ped.id).ForEach(x =>
                     {
                         ped.price += x.unit_price * x.quantity;
                     });
                }


                return pedidos;
            }
        }

        [Route("api/pedido/{id}", Name = "GetPedido")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var query = @"select * from LioOrders lo inner join Users u on u.Id = lo.UserId where lo.Id = @Id";
                var pedido = con.Query<LioOrder, User, LioOrder>(query,
                    (a, g) =>
                    {
                        a.User = g;
                        return a;
                    }, new { Id = id }).FirstOrDefault();

                if (pedido == null)
                {
                    return NotFound();
                }

                if (pedido.User != null)
                {
                    var queryAd = @"select * from Addresses where UserId = @Id";
                    var addresses = con.Query<Address>(queryAd, new { Id = pedido.User.Id });
                    pedido.User.Addresses = addresses.ToList();
                }

                query = "select * from LioOrderItems where OrderId = @Id";
                var itens = await con.QueryAsync<LioOrderItem>(query, new { Id = id });
                pedido.items = itens.ToList();
                foreach (var lioOrderItem in pedido.items)
                {
                    pedido.price += lioOrderItem.quantity * lioOrderItem.unit_price;
                }


                return Ok(pedido);
            }
        }
    }
}
