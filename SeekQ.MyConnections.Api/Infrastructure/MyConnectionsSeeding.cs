using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeekQ.MyConnections.Api.Domain.ConnectionsAggregate;
using System;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Infrastructure
{
    public class MyConnectionsSeeding
    {
        public static readonly Guid ID_CONNECTION_TEST = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D0");
        public static readonly Guid ID_USER_JOSE = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D7");
        public static readonly Guid ID_USER_DANIEL = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D9");
        public static readonly Guid ID_USER_JORGE = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D8");
        public static readonly Guid ID_USER_LLIUR = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D7");
        public static readonly Guid ID_USER_JULIAN = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D6");
        public static readonly Guid ID_USER_CARLOS = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D5");
        public static readonly Guid ID_USER_ANDRES = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D4");
        public static readonly Guid ID_USER_DAVID = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D3");

        public async Task SeedAsync(MyConnectionsDbContext context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<MyConnectionsSeeding>>();

            context.Database.EnsureCreated();

            if (await context.Connections.AnyAsync())
            {
                return;
            }

            // Add connections of ID_USER_JOSE with others users blocked
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "dany",
                ConnectionFirstName = "Daniel",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Gallo",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 34,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_DANIEL,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "jorge",
                ConnectionFirstName = "Jorge",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Puerta",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 36,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_JORGE,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "Lliur",
                ConnectionFirstName = "Lliur",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Mejía",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 35,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_LLIUR,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "Lliur",
                ConnectionFirstName = "Julian",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Romero",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 33,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_JULIAN,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "ingeniero",
                ConnectionFirstName = "Carlos",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Osorio",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 32,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_CARLOS,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "andres",
                ConnectionFirstName = "Andres",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Concha",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 30,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_ANDRES,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_JOSE,
                ConnectionNickName = "david",
                ConnectionFirstName = "David",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Valencia",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 40,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_DAVID,
                Blocked = true
            });

            // Add connections of ID_USER_DANIEL with others users blocked
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_DANIEL,
                ConnectionNickName = "jose",
                ConnectionFirstName = "Jose",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Carvajal",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 36,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_JOSE,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                IdUser = ID_USER_DANIEL,
                ConnectionNickName = "juli",
                ConnectionFirstName = "Julian",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Romero",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 33,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_JULIAN,
                Blocked = true
            });
            context.Connections.Add(new Connection
            {
                Id = ID_CONNECTION_TEST,
                IdUser = ID_USER_DANIEL,
                ConnectionNickName = "carlos",
                ConnectionFirstName = "Carlos",
                ConnectionIsFirstNameVisible = true,
                ConnectionLastName = "Osorio",
                ConnectionIsLastNameVisible = true,
                ConnectionAge = 33,
                ConnectionIsAgeVisible = true,
                ConnectionAvatar = "https://www.confuturolaboral.com/Ellipse%2027.png",
                ConnectionIsAvatar = true,
                ConnectionUserId = ID_USER_CARLOS,
                Blocked = true
            });

            await context.SaveChangesAsync();
        }
    }
}
