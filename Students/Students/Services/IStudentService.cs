using Students.Models;

namespace Students.Services
{
    public interface IStudentService
    {
        public void New(Student student);
        public IEnumerable<Student> GetAll();  
        public Student Get(string document);
    }
}
