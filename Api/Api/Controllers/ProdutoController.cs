using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Entity;
using Dapper;

namespace Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private AppContext _context;
        private string _conString;

        public ProdutoController()
        {
            _context = new AppContext();
            _conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Produto item)
        {
            _context.Produtos.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetProduto", item.Id, item);
        }

        [Route("api/produto", Name = "GetProdutos")]
        [HttpGet]
        public async Task<IEnumerable<Produto>> GetItems()
        {
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var produto = await con.QueryAsync<Produto>(@"select * from Produtoes");

                return produto;
            }
        }

        [Route("api/produto/{id}", Name = "GetProduto")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var produto = await con.QueryAsync<Produto>(@"select * from Produtoes where Id = @Id", new { Id = id });

                if (produto == null)
                    return NotFound();

                return Ok(produto.FirstOrDefault());
            }
        }
    }
}
