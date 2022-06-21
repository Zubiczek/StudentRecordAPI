using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StudentRecordAPI.IntegrationTests.ControllersTests.FakePolicies;
using StudentRecordAPI.Models.AddDTO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentRecordAPI.IntegrationTests.ControllersTests.TeacherFeatures
{
    public class AttendanceControllerTeacherTests : IClassFixture<WebApplicationFactory<StudentRecordAPI.Startup>>
    {
        private readonly HttpClient _client;
        public AttendanceControllerTeacherTests(WebApplicationFactory<StudentRecordAPI.Startup> application)
        {
            _client = application.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient<IPolicyEvaluator, TeacherFakePolicyEvaluator>();
                });
            }).CreateClient();
        }
        [Fact]
        public async Task AddAttendance_201Created()
        {
            AttendanceAddDTO newattendance = new AttendanceAddDTO();
            newattendance.Present = true;
            newattendance.Student_Id = "26056e9c-0d61-4a4d-9260-e1d6a561ac6e";
            newattendance.Schedule_Id = 1;
            var response = await _client.PostAsync("/api/Attendance/add", new StringContent(JsonConvert.SerializeObject(newattendance),
                Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            });
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task AddAttendance_400NullObject()
        {
            AttendanceAddDTO newattendance = null;
            var response = await _client.PostAsync("/api/Attendance/add", new StringContent(JsonConvert.SerializeObject(newattendance),
                Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            });
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task AddAttendance_400InvalidStudentid()
        {
            string invalidStudent_id = "wefuui3453";
            AttendanceAddDTO newattendance = new AttendanceAddDTO();
            newattendance.Present = true;
            newattendance.Student_Id = invalidStudent_id;
            newattendance.Schedule_Id = 1;
            var response = await _client.PostAsync("/api/Attendance/add", new StringContent(JsonConvert.SerializeObject(newattendance),
                Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            });
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            string responsejson = await response.Content.ReadAsStringAsync();
            ResponseMessage responseobject = JsonConvert.DeserializeObject<ResponseMessage>(responsejson);
            Assert.Equal("Incorrect Student_id!", responseobject.Message);
        }
    }
}
