using System;
using Api.Entity;

namespace Api.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Api.Entity.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Api.Entity.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(new User
            {
                Id = 1,
                Email = "bill@microsoft.com",
                Name = "Tio Bill Gates",
                OauthToken = "token",
                ImagemUrl = "https://pbs.twimg.com/profile_images/558109954561679360/j1f9DiJi.jpeg",
                Telefone = "2133445566"
            });

            context.Address.AddOrUpdate(new Address
            {
                UserId = 1,
                Number = "171",
                Street = "Rua dos Bobos",
                ZipCode = "20080080"
            });


            context.Produtos.AddOrUpdate(new Produto
            {
                Name = "BirlBurguer",
                Price = 18.30m,
                Rate = 4,
                Description = "Hamburguer do bambam.",
                Image = "http://www.villaburguer.com.br/images/burguer-home.png"
            },
            new Produto
            {
                Name = "HackBurguer",
                Price = 15.00m,
                Rate = 5,
                Description = "Hamburguer da hackathon.",
                Image = "http://www.bossame.com.br/wp-content/uploads/2015/10/Riso-Burguer_Riso_Alta_CredTomasRangel_menor.jpg"
            },
            new Produto
            {
                Name = "GordoCombo",
                Price = 30.00m,
                Rate = 5,
                Description = "Combo de Hamburguer Gourmer + Stella",
                Image = "https://media-cdn.tripadvisor.com/media/photo-s/09/67/6e/dc/hell-s-burguer.jpg"
            },
            new Produto
            {
                Name = "BigBurguer",
                Price = 10.50m,
                Rate = 2,
                Description = "Hamburguer de 2 carnes + coca.",
                Image = "http://clubevipmais.com/wp-content/uploads/logotipo-lanchonete-big-burguer-opt.jpg"
            },
            new Produto
            {
                Name = "Batata Fusion",
                Price = 33.50m,
                Rate = 1,
                Description = "Batata Frita com bacon",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_VRxdK6Cm3jGqeaTuDLL88phxgfb-HjbxN8TOeJvhgBRYMp0B"
            },
            new Produto
            {
                Name = "Pizza Elite Grande",
                Price = 45.00m,
                Rate = 2,
                Description = "Pizza sabor da casa ",
                Image = "http://elitepizzari.com/wp-content/uploads/2013/03/Spinach-Feta-Pizza-main-slide.jpg"
            });

            var orderID = Guid.NewGuid();
            context.Orders.AddOrUpdate(new LioOrder
            {
                id = orderID,
                UserId = 1
            });

            context.OrderItens.AddOrUpdate(new LioOrderItem
            {
                OrderId = orderID,
                name = "Teste",
                unit_price = 123,
                sku = new Random(132).ToString()

            });

        }
    }
}
