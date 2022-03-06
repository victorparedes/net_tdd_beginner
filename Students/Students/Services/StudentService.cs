using Students.Commons;
using Students.Models;
using Students.Repository;

namespace Students.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }    

        public Student Get(string document)
        {
            var result = _repository.GetByDocument(document);

            if(result == null)
                throw new StudentNotFoundException();

            return result;
        }

        public IEnumerable<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public void New(Student student)
        {
            if (string.IsNullOrEmpty(student.document))
                throw new StudentInvalidException();

            if (_repository.Exist(student.document))
                throw new StudentRepeteadException();

            _repository.New(student);
        }
    }
}
