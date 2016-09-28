using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Api.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;

namespace Api.Controllers
{
    public class UserController : ApiController
    {
        private AppContext _context;
        private string _conString;
        public UserController()
        {
            _context = new AppContext();
            _conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(User user)
        {
            this._context.Users.Add(user);

            await this._context.SaveChangesAsync();

            return this.CreatedAtRoute("GetUser", user.Id, user);
        }

        [Route("api/user/{id}", Name = "GetUser")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var user = await con.QueryAsync<User>(@"select * from Users where Id = @Id", new { Id = id });

                if (user == null)
                    return NotFound();

                var addresses =
                    await con.QueryAsync<Address>(@"select * from Addresses where UserId = @Id", new { Id = id });
                user.FirstOrDefault().Addresses = addresses.ToList();

                return Ok(user.FirstOrDefault());
            }
        }

        [Route("api/user", Name = "GetUsers")]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var user = await con.QueryAsync<User>(@"select * from Users");

                var userIds = user.Select(x => x.Id);
                var itens = await con.QueryAsync<Address>(@"select * from Addresses where UserId In @userIds", new { userIds });

                foreach (var u in user)
                {
                    u.Addresses = itens.Where(x => x.UserId == u.Id).ToList();
                }

                return user;
            }
        }
    }
}
