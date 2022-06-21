using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.IntegrationTests.ControllersTests.FakePolicies;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using StudentRecordAPI.Models.DTO;
using Newtonsoft.Json;
using System.Net;

namespace StudentRecordAPI.IntegrationTests.ControllersTests.TeacherFeatures
{
    public class ClassControllerTeacherTests : IClassFixture<WebApplicationFactory<StudentRecordAPI.Startup>>
    {
        private readonly HttpClient _client;
        public ClassControllerTeacherTests(WebApplicationFactory<StudentRecordAPI.Startup> application)
        {
            _client = application.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient<IPolicyEvaluator, TeacherFakePolicyEvaluator>();
                });
            }).CreateClient();
        }
        [Theory]
        [InlineData(8)]
        [InlineData(9)]
        public async Task GetListOfStudents_200OK(int Class_id)
        {
            var response = await _client.GetAsync("/api/Class/"+Class_id+"/students");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetListOfStudents_200OK_checkdata()
        {
            var response = await _client.GetAsync("/api/Class/9/students");
            response.EnsureSuccessStatusCode();
            var responsestring = await response.Content.ReadAsStringAsync();
            Assert.Contains("3a0e288a-2e9a-44fc-9ec3-81367ffddc66", responsestring);
        }
        [Fact]
        public async Task GetListOfStudents_404NotFound()
        {
            var response = await _client.GetAsync("/api/Class/457/students");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
