using ClientService.Data;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimeManagment.IntegrationTest
{
    public class CountryApiIntegrationTest
    {
        [Fact]
        public async Task Test_Get()
        {
            using (HttpClient client = new TestClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync("/api/teams");

                ////response.EnsureSuccessStatusCode();
                //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                HttpContent a = response.Content;
            }
        }

        [Fact]
        public async Task Test_Post()
        {
            using (HttpClient client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync(
                    "/api/teams",
                    new StringContent(JsonConvert.SerializeObject(
                        new TeamEntity()
                        {
                            Id = 100,
                            Name = "Test"
                        }),
                    Encoding.UTF8,
                    "application/json"));

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                var a = response.Content;
            }
        }
    }
}
