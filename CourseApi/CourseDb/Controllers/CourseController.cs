using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseDb.Models;
using CourseDb.DTO;
using CourseDb.Service;

namespace CourseDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;
        //ILogger _logger;
        public CourseController(ICourseService courseService /*ILogger<CourseController> logger*/)
        {
            _courseService = courseService;
            //_logger = logger;
        }

        [HttpGet("/GetCourse")]
        public async Task<ActionResult<List<Course>>> GetCourse()
        {
            var courseData = await _courseService.GetCourse();
            if (courseData == null)
            {
                //_logger.LogInformation("Failed to Fetch Course Data!");
                return BadRequest();
            }
            else 
            {
                //_logger.LogInformation("Success to Fetch Course Data!");

                return Ok(courseData);
            }
        }

        [HttpPost("/PostCourse")]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto c) 
        {
            try
            {
                var CourseResult = await _courseService.AddCourse(c);

                //_logger.LogInformation("Success to Add Course Data!");

                return Ok(CourseResult);
            }
            catch (Exception e)
            {
                //_logger.LogInformation("Failed to Add Course Data!");

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/DeleteCourse")]

        public async Task<ActionResult<CourseDto>> DeleteCourse(int id)
        {
            try
            {
                var CourseResult = await _courseService.DeleteCourse(id);

                //_logger.LogInformation("Success to Delete Course Data!");

                return Ok(CourseResult);
            }
            catch (Exception e)
            {
                //_logger.LogInformation("Failed to Delete Course Data!");

                return BadRequest();
            }
        }

        [HttpPut("/UpdateCourse")]
        public async Task<ActionResult<CourseDto>> UpdateCourse(int id, CourseDto courseDto)
        {
            try
            {
                var CourseResult = await _courseService.UpdateCourse(id, courseDto);

                //_logger.LogInformation("Success to Delete Course Data!");

                return Ok(CourseResult);
            }
            catch (Exception e)
            {
                //_logger.LogInformation("Failed to Delete Course Data!");

                return BadRequest();
            }
        }

    }
}
