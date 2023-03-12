using CourseDb.DTO;
using CourseDb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseDb.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private CourseContext _courseContext;

        public CourseRepo(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public async Task<List<Course>> GetCourse()
        {
            return await _courseContext.Courses.ToListAsync();
        }
        public async Task AddCourse(Course course)
        {
            await _courseContext.Courses.AddAsync(course);
            await _courseContext.SaveChangesAsync();
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var courseData = await _courseContext.Courses.SingleOrDefaultAsync(found => found.CourseId == id);
            _courseContext.Courses.Remove(courseData);
            await _courseContext.SaveChangesAsync();

            return courseData;
        }
        public async Task<Course> UpdateCourse(int id, CourseDto courseDto)
        {
            var _courseData = await _courseContext.Courses.SingleOrDefaultAsync(found => found.CourseId == id);
            _courseData.CourseName = courseDto.CourseName;
            _courseData.Description = courseDto.Description;
            _courseData.DurationDays = courseDto.DurationDays;
            _courseData.StartDate = courseDto.StartDate;
            await _courseContext.SaveChangesAsync();

            return _courseData;

        }
    }
}
