using AutoMapper;
using CourseDb.DTO;
using CourseDb.Models;
using CourseDb.Repository;

namespace CourseDb.Service
{
    public class CourseService : ICourseService
    {
        private IMapper _mapper;
        private ICourseRepo _courseRepo;

        public CourseService(IMapper mapper, ICourseRepo courseRepo)
        {
            _mapper = mapper; 
            _courseRepo = courseRepo;
        }

        public async Task<List<Course>> GetCourse()
        { 
            var course = await _courseRepo.GetCourse();
            var records = _mapper.Map<List<Course>>(course);

            return records;
        }
        public async Task<Course> AddCourse(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepo.AddCourse(course);

            return course;
        }

        public async Task<CourseDto> DeleteCourse(int id)
        {
            var result = await _courseRepo.DeleteCourse(id);
            var record = _mapper.Map<CourseDto>(result);
            return record;
        }
        public async Task<CourseDto> UpdateCourse(int id, CourseDto courseDto)
        {
            var result = await _courseRepo.UpdateCourse(id, courseDto);

            var record = _mapper.Map<CourseDto>(result);

            return record;
        }
    }
}
