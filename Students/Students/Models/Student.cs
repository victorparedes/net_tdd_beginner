using MongoDB.Bson.Serialization.Attributes;

namespace Students.Models
{
    public class Student
    {
        [BsonId]
        public string document { get; set; }
        public string name { get; set; } 
        public string email { get; set; }   
    }
}
