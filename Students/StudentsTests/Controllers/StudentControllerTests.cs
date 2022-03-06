using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Students.Commons;
using Students.Models;
using Students.Services;

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
        public void WhenTryAddRepeteadStudent_ShouldResponseWithBarRequest_Test()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.New(student)).Throws<StudentRepeteadException>();
            var target = new StudentController(servicesMock.Object);

            var result = target.Post(student) as BadRequestResult;

            Assert.AreEqual(400, result?.StatusCode);
        }

        [TestMethod()]
        public void WhenTryToAddInvalidStudent_ShouldResponseWithBarRequest_Test()
        {
            var student = new Student { document = "123456789", name = "a name", email = "mail@email.com" };
            var servicesMock = new Mock<IStudentService>();
            servicesMock.Setup(x => x.New(student)).Throws<StudentInvalidException>();
            var target = new StudentController(servicesMock.Object);

            var result = target.Post(student) as BadRequestResult;

            Assert.AreEqual(400, result?.StatusCode);
        }
    }
}