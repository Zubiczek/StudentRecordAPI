using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.IntegrationTests.ControllersTests.FakePolicies;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace StudentRecordAPI.IntegrationTests.ControllersTests.StudentFeatures
{
    public class AttendanceControllerStudentTests : IClassFixture<WebApplicationFactory<StudentRecordAPI.Startup>>
    {
        private readonly HttpClient _client;
        public AttendanceControllerStudentTests(WebApplicationFactory<StudentRecordAPI.Startup> application)
        {
            _client = application.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient<IPolicyEvaluator, StudentFakePolicyEvaluator>();
                });
            }).CreateClient();
        }
        [Fact]
        public async Task GetAttendanceList_200OK()
        {
            var result = await _client.GetAsync("/api/Attendance/schedule/1");
            result.EnsureSuccessStatusCode();
            string resultstring = await result.Content.ReadAsStringAsync();
            Assert.Contains("\"attendance_Id\":1,\"present\":true,\"createdOn\":\"2022-06-13T08:03:31\",\"subject\":\"Matematyka\"", resultstring);
            Assert.Contains("\"attendance_Id\":2,\"present\":false,\"createdOn\":\"2022-06-06T08:02:56\",\"subject\":\"Matematyka\"", resultstring);
            Assert.Contains("\"attendance_Id\":3,\"present\":true,\"createdOn\":\"2022-05-30T08:04:34\",\"subject\":\"Matematyka\"", resultstring);
        }
    }
}
