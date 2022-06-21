using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Services.ValidationService;
using Xunit;

namespace StudentRecordAPI.UnitTests.UnitTests
{
    public class ModelValidationMethodTests
    {
        private readonly IValidationService _validationService;
        public ModelValidationMethodTests(IValidationService validationService)
        {
            _validationService = validationService;
        }
        [Fact]
        public void ValidateGradeModel_Success()
        {
            GradeEntity grade = new GradeEntity() 
            {
                Grade = 5,
                Description = "Test",
                Student_Id = "testid",
                Subject_Id = 1
            };
            var result = _validationService.Validate(grade);
            Assert.True(result.Item1);
            Assert.Null(result.Item2);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(21.4)]
        public void ValidateGradeModel_InvalidGrade(float value)
        {
            GradeEntity grade = new GradeEntity()
            {
                Grade = value,
                Description = "Test",
                Student_Id = "testid",
                Subject_Id = 1
            };
            var result = _validationService.Validate(grade);
            Assert.False(result.Item1);
            Assert.Equal("Grade's range is between 1 and 6", result.Item2);
        }
    }
}
