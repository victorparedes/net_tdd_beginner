using MongoDB.Driver;
using Students.Models;

namespace Students.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private IMongoCollection<Student> _collection;
        public StudentRepository(IMongoCollection<Student> collection)
        {
            _collection = collection;
        }
        public bool Exist(string document)
        {
            var aasd = _collection.Find(x => x.document == document);
            return aasd.Any();
        }

        public IEnumerable<Student> GetAll()
        {
            return _collection.Find(x => true).ToList<Student>();
        }

        public Student GetByDocument(string document)
        {
            return _collection.Find(x => x.document == document).FirstOrDefault();
        }

        public void New(Student student)
        {
            _collection.InsertOne(student);
        }
    }
}
