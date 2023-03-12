using CourseDb.DTO;
using CourseDb.Service;
using Microsoft.AspNetCore.Mvc;
using CourseDb.Models;
using Moq;
using Microsoft.Extensions.Logging;
using CourseDb.Controllers;

namespace CourseUnitTest
{
    public class CourseController_unitTest
    {
        private Mock<ICourseService> courseService;
        public CourseController_unitTest()
        {
            courseService = new Mock<ICourseService>();
        }
        [Fact]
        public void InsertData_ReturnIsNotNull()
        {
            var data = new Course()
            {
                CourseId = 3,
                CourseName = "Information",
                Description = "Sample Description",
                DurationDays = 1,
                StartDate = new DateTime(),

            };
            var dataDto = new CourseDto()
            {

                CourseName = "Information",
                Description = "Sample Description",
                DurationDays = 1,
                StartDate = new DateTime(),

            };

            courseService.Setup(x => x.AddCourse(dataDto)).Returns(Task.Run(() => data));
            var courseController = new CourseDb.Controllers.CourseController(courseService.Object);

            var result = courseController.AddCourse(dataDto).Result.Result as OkObjectResult;
            var infoResult = result.Value as Course;
        
            Assert.NotNull(infoResult);
        }
    }
}