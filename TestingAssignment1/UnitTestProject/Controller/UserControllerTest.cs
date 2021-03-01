using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.Controllers;
using TestingAssignment1.Database;
using TestingAssignment1.Repository.Interface;
using Xunit;
using Moq;
using System.Web.Http.Results;

namespace UnitTestProject.Controller
{
    
    public class UserControllerTest
    {
        private readonly Mock<IPassengerManager> mockRepository = new Mock<IPassengerManager>();
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _userController = new UserController(mockRepository.Object);
        }

        [Fact]
        public void GetPassenger_ShouldReturnPassenger()
        {
            //Arrange
            int id = 1;
            var setup = mockRepository.Setup(x => x.GetPassenger(id)).Returns(GetPassenger(id));
            var expected = GetPassenger(id);

            //Act
            var result = _userController.Get(id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPassenger_ShouldReturnNoPassenger()
        {
            //Arrange
            int id = 0;
            var setup = mockRepository.Setup(x => x.GetPassenger(id));
            var expected = GetPassenger(id);

            //Act
            var result = _userController.Get(id);

            //Assert
            Assert.Null(result);
        }

        

        [Fact]
        public void PutPassenger_ShouldReturnOk()
        {
            //Arrange
            var passenger = new Passenger() { FirstName = "First", LastName = "Last", Phone = 982578035 };
            var setup = mockRepository.Setup(x => x.UpdatePassenger(1, passenger)).Returns(1);

            //Act
            var result = _userController.Edit(1, passenger);

            //Assert
            Assert.Equal(HttpStatusCode.OK, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public void PutPassenger_ShouldReturnBadRequest()
        {
            //Arrange
            var passenger = new Passenger();
            var setup = mockRepository.Setup(x => x.UpdatePassenger(1, passenger)).Returns(0);

            //Act
            var result = _userController.Edit(1, passenger);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        

        [Fact]
        public void PostPassenger_ShouldReturnSuccess()
        {
            //Arrange
            var passenger = new Passenger() { FirstName = "Test", LastName = "Test", Phone =123456789};
            var setup = mockRepository.Setup(x => x.CreatePassenger(passenger)).Returns(1);

            //Act
            var result = _userController.Create(passenger);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void PostPassenger_ShouldReturnError()
        {
            //Arrange
            var passenger = new Passenger() { FirstName = "Test", LastName = "Test", Phone = 123456789 };
            var setup = mockRepository.Setup(x => x.CreatePassenger(passenger));

            //Act
            var result = _userController.Create(passenger);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeletePassenger_ShouldReturnSuccess()
        {
            //Arrange
            var setup = mockRepository.Setup(x => x.DeletePassenger(1)).Returns(1);

            //Act
            var result = _userController.Delete(1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeletePassenger_ShouldReturnBadRequest()
        {
            //Arrange
            var setup = mockRepository.Setup(x => x.DeletePassenger(-1)).Returns(0);

            //Act
            var result = _userController.Delete(-1);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        

        private static Passenger GetPassenger(int id)
        {
            List<Passenger> passengers = new List<Passenger>()
            {
                new Passenger() {Id = 1, FirstName = "Test", LastName = "Last", Phone = 123456789 },
                new Passenger() {Id = 2, FirstName = "Test", LastName = "Last", Phone = 123456789 },
                new Passenger() {Id = 3, FirstName = "Test", LastName = "Last", Phone = 123456789 },
            };

            return passengers.Where(u => u.Id == id).First();
        }
    }

}
