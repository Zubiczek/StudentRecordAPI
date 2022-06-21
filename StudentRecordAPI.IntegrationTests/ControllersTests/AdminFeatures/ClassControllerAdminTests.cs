using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StudentRecordAPI.IntegrationTests.ControllersTests.FakePolicies;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace StudentRecordAPI.IntegrationTests.ControllersTests.AdminFeatures
{
    public class ClassControllerAdminTests : IClassFixture<WebApplicationFactory<StudentRecordAPI.Startup>>
    {
        private readonly HttpClient _client;
        public ClassControllerAdminTests(WebApplicationFactory<StudentRecordAPI.Startup> application)
        {
            _client = application.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient<IPolicyEvaluator, AdminFakePolicyEvaluator>();
                });
            }).CreateClient();
        }
        [Fact]
        public async Task AddNewStudent_200OK()
        {
            var response = await _client.GetAsync("/api/Class/10/addstudent/26056e9c-0d61-4a4d-9260-e1d6a561ac6e");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task AddNewStudent_404Classid()
        {
            var response = await _client.GetAsync("/api/Class/0/addstudent/26056e9c-0d61-4a4d-9260-e1d6a561ac6e");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            string responsejson = await response.Content.ReadAsStringAsync();
            ResponseMessage responseobject = JsonConvert.DeserializeObject<ResponseMessage>(responsejson);
            Assert.Equal("Class not found! Invalid id", responseobject.Message);
        }
        [Fact]
        public async Task AddNewStudent_404Studentid()
        {
            var response = await _client.GetAsync("/api/Class/10/addstudent/fake-id-23");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            string responsejson = await response.Content.ReadAsStringAsync();
            ResponseMessage responseobject = JsonConvert.DeserializeObject<ResponseMessage>(responsejson);
            Assert.Equal("Student not found! Invalid id", responseobject.Message);
        }
    }
}
