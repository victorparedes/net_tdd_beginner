using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Students.Commons;
using Students.Models;
using Students.Repository;
using System.Collections.Generic;

namespace Students.Services.Tests
{
    [TestClass()]
    public class StudentServiceTests
    {
        [TestMethod()]
        public void WhenTryToSaveExistingStudent_ShouldThrowErrorTest()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.Exist("123456789")).Returns(true);
            var target = new StudentService(mockRepo.Object);

            Assert.ThrowsException<StudentRepeteadException>(() => target.New(student));

            mockRepo.Verify(x => x.New(student), Times.Never());
        }

        [TestMethod()]
        public void WhenTryToSaveInvalidStudent_ShouldThrowErrorTest()
        {
            var student = new Student { document = "", name = "a name", email = "mail@email.com" };
            var mockRepo = new Mock<IStudentRepository>();
            var target = new StudentService(mockRepo.Object);

            Assert.ThrowsException<StudentInvalidException>(() => target.New(student));

            mockRepo.Verify(x => x.Exist(It.IsAny<string>()), Times.Never());
            mockRepo.Verify(x => x.New(student), Times.Never());
        }

        [TestMethod()]
        public void WhenTryToSaveStudent_ShouldSaveStudentTest()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.Exist("123456789")).Returns(false);
            var target = new StudentService(mockRepo.Object);

            target.New(student);

            mockRepo.Verify(x => x.New(student), Times.Once());
        }

        [TestMethod()]
        public void WhenGetAllStudents_ShouldReturnAllStudentsTest()
        {
            var students = new List<Student>();
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.GetAll()).Returns(students);
            var target = new StudentService(mockRepo.Object);

            var result = target.GetAll();

            Assert.AreEqual(students, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(StudentNotFoundException))]
        public void WhenFindNotExistStudents_ShouldThrowErrorTest()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.GetByDocument("123456789")).Returns((Student)null);
            var target = new StudentService(mockRepo.Object);

            var result = target.Get("123456789");
        }

        [TestMethod()]
        public void WhenFindExistingStudents_ShouldReturnStudentTest()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.GetByDocument("123456789")).Returns(student);
            var target = new StudentService(mockRepo.Object);

            var result = target.Get("123456789");

            Assert.AreEqual(student, result);
        }
    }
}