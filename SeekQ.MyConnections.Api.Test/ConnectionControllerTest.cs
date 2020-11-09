using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SeekQ.MyConnections.Api.Application.Queries;
using SeekQ.MyConnections.Api.Domain.ConnectionsAggregate;
using SeekQ.MyConnections.Api.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SeekQ.MyConnections.Api.Test
{
    public class ConnectionControllerTest : BaseIntegrationTest<Startup>
    {
        public ConnectionControllerTest(WebApplicationFactory<Startup> factory)
            : base(factory)
        {

        }

        [Fact]
        public async void GetBlockedUsers_GetExpectedConnectionsList()
        {

            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"api/v1/connection/{MyConnectionsSeeding.ID_USER_JOSE}/blockedusers");

            // Assert
            response.EnsureSuccessStatusCode();
            var notificationsSettingsList = JsonConvert
                               .DeserializeObject<IEnumerable<GetBlockedUsersrViewModel>>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(notificationsSettingsList.Count() == 7, "Connections list where not loaded");
        }

        [Theory]
        [InlineData("/api/v1/connection/unblock")]
        public async void UnblockUser_unblockedUser(string url)
        {
            var client = Factory.CreateClient();

            Connection connection = new Connection
            {
                Id = MyConnectionsSeeding.ID_CONNECTION_TEST
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(connection), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, httpContent);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var unblockCourse = JsonConvert.DeserializeObject<Connection>(await response.Content.ReadAsStringAsync());
            Assert.True(unblockCourse.Blocked == false, "User blocked does not have been unblock");

            // Clean up
            var responseBlock = await client.PostAsync("/api/v1/connection/block", httpContent);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var blockCourse = JsonConvert.DeserializeObject<Connection>(await responseBlock.Content.ReadAsStringAsync());
            Assert.True(blockCourse.Blocked == true, "User unblock does not have been blocked");
        }
    }
}
