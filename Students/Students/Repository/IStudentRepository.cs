using Students.Models;

namespace Students.Repository
{
    public interface IStudentRepository
    {
        public void New(Student student);
        public bool Exist(string document);
        public IEnumerable<Student> GetAll();
        public Student GetByDocument(string document);
    }
}
