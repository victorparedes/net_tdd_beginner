using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Students.Commons;
using Students.Models;
using Students.Services;
using System.Collections.Generic;

namespace Students.Controllers.Tests
{
    [TestClass()]
    public class StudentControllerTests
    {
        [TestMethod()]
        public void WhenAddNewStudent_ShouldResponseHttpStatusCreated_Test()
        {
            var servicesMock = new Mock<IStudentService>();
            var target = new StudentController(servicesMock.Object);
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };

            var result = target.Post(student) as CreatedResult;

            servicesMock.Verify(x => x.New(student), Times.Once());
            Assert.AreEqual(201, result?.StatusCode);
        }

        [TestMethod()]
        public void WhenAddNewStudent_ShouldResponseWithUrlAndValueCreated_Test()
        {
            var servicesMock = new Mock<IStudentService>();
            var target = new StudentController(servicesMock.Object);
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };

            var result = target.Post(student) as CreatedResult;

            Assert.AreEqual("/student/123456789", result?.Location);
            Assert.AreEqual(student, result?.Value);
        }

        [TestMethod()]
        public void WhenTryAddRepeteadStudent_ShouldResponseWithBadRequest_Test()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.New(student)).Throws<StudentRepeteadException>();
            var target = new StudentController(servicesMock.Object);

            var result = target.Post(student) as BadRequestResult;

            Assert.AreEqual(400, result?.StatusCode);
        }

        [TestMethod()]
        public void WhenTryToAddInvalidStudent_ShouldResponseWithBadRequest_Test()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.New(student)).Throws<StudentInvalidException>();
            var target = new StudentController(servicesMock.Object);

            var result = target.Post(student) as BadRequestResult;

            Assert.AreEqual(400, result?.StatusCode);
        }

        [TestMethod()]
        public void WhenGetAllStudents_ShouldReturnListOfStudents_Test()
        {
            var students = new List<Student>();
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.GetAll()).Returns(students);
            var target = new StudentController(servicesMock.Object);

            var result = target.Get() as OkObjectResult;

            Assert.AreEqual(200, result?.StatusCode);
            Assert.AreEqual(students, result.Value);
        }

        [TestMethod()]
        public void WhenFindStudentAndExist_ShouldReturnStudent_Test()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.Get("123456789")).Returns(student);
            var target = new StudentController(servicesMock.Object);

            var result = target.Get("123456789") as OkObjectResult;

            Assert.AreEqual(200, result?.StatusCode);
            Assert.AreEqual(student, result?.Value);
        }

        [TestMethod()]
        public void WhenFindStudentAndNotExist_ShouldReturnNotfound_Test()
        {
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.Get("123456789")).Throws(new StudentNotFoundException());
            var target = new StudentController(servicesMock.Object);

            var result = target.Get("123456789") as NotFoundResult;

            Assert.AreEqual(404, result?.StatusCode);
        }
    }
}