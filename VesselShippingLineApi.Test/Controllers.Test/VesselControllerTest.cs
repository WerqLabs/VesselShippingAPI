namespace VesselShippingLineApi.Test.Controllers.Test
{
    /// <summary>
    /// Test Vessel Controller Functions
    /// </summary>
    public class VesselControllerTest
    {
        [Fact]
        public void AddShipTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.AddShips(null)).Returns(new AddShipResponse());

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.AddShip(null);

            // Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }

        [Fact]
        public void AddShipFailedTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.AddShips(null)).Returns(new AddShipResponse() { ErrorDetail = "Error Test"});

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.AddShip(null);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }


        [Fact]
        public void ShowAllShipsTest()
        {

            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.ShowAllShips()).Returns(new List<VesselDTO>());

            var controller = new VesselController(mockRepo.Object);

            var result = controller.ShowAllShips();
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }


        [Fact]
        public void UpdateShipVelocityTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.UpdateShipVelocity(null)).Returns("");

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.UpdateShipVelocity(null);

            // Assert
            var actionresult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(204, actionresult.StatusCode);
        }

        [Fact]
        public void UpdateShipVelocityFaliedTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.UpdateShipVelocity(null)).Returns("Error from DB");

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.UpdateShipVelocity(null);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }


        [Fact]
        public void GetNearestPortForShipFaliedTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.GetNearestPortForShip(0)).Returns(new VesselETAReponseModel());

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.GetNearestPortForShip(0);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }

        [Fact]
        public void GetNearestPortForShipTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.GetNearestPortForShip(1)).Returns(new VesselETAReponseModel() { Velocity=1});

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.GetNearestPortForShip(1);

            // Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }

        [Fact]
        public void GetNearestPortForShipDBFaliedTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.GetNearestPortForShipDB(0)).Returns(new VesselDBOutputResponse());

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.GetNearestPortForShipDB(0);

            // Assert
            var actionresult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionresult.StatusCode);
        }

        [Fact]
        public void GetNearestPortForShipDBTest()
        {
            // Arrange
            var mockRepo = new Mock<IVesselDataManager>();
            mockRepo.Setup(repo => repo.GetNearestPortForShipDB(1)).Returns(new VesselDBOutputResponse());

            var controller = new VesselController(mockRepo.Object);

            // Act
            var result = controller.GetNearestPortForShipDB(1);

            // Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionresult.StatusCode);
        }

    }
}
