using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private User _user;

        [SetUp]
        public void Setup()
        {
            _controller = new UserController();
            _user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
            UserController.userlist[_user.Id] = _user;
        }

        [Test]
        public void Index_ReturnsCorrectView()
        {
            var result = _controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Details_ReturnsCorrectView()
        {
            var result = _controller.Details(_user.Id) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void Create_ReturnsCorrectView()
        {
            var result = _controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void Edit_ReturnsCorrectView()
        {
            var result = _controller.Edit(_user.Id) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void Delete_ReturnsCorrectView()
        {
            var result = _controller.Delete(_user.Id) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [Test]
        public void Search_ReturnsCorrectView()
        {
            var result = _controller.Search("Test") as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        public void Search_ReturnsCorrectUsers()
        {
            var result = _controller.Search("Test") as ViewResult;
            var model = result.Model as IEnumerable<User>;
            Assert.IsTrue(model.All(u => u.Name.Contains("Test") || u.Email.Contains("Test")));
        }

    }
}
