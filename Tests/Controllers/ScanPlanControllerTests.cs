using asset_management.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using waypoint_generator.Models.ScanPlan;

namespace waypoints.Tests
{
    [TestFixture]
    public class ScanPlanControllerTests
    {
        private Mock<IScanPlanService> _scanPlanServiceMock;
        private ScanPlanController _scanPlanController;

        [SetUp]
        public void Setup()
        {
            _scanPlanServiceMock = new Mock<IScanPlanService>();
            _scanPlanController = new ScanPlanController(_scanPlanServiceMock.Object);
        }

        [Test]
        public void GetAllScanPlansTest()
        {
            var scanpPlansList = new List<BaseScanPlan>
            {
                new SinglePointPlan { MissionID = 1, Name = "Scan Plan 1", Comment= "",
                                      Duration = 42, OffsetAzimuth = 0, OffsetElevation = 0, Radius = 0,
                                      Polarization = SinglePointPlan.PolarizationEnum.Cross },

                new PrincipalPlan { MissionID = 1, Name = "Principal Scan Plan 1", Comment= "",
                                    Start = 100, Step = 10, Stop = 200, Speed = 5, Radius = 12, Roll = 0,
                                    Plane = PrincipalPlan.PlaneEnum.Elevation,
                                    Direction = PrincipalPlan.DirectionEnum.Increasing,
                                    Polarization = PrincipalPlan.PolarizationEnum.Cross},

                new RasterPlan { MissionID = 1, Name = "Raster Scan Plan 1", Comment= "",
                                 AzimuthStart = 100, AzimuthStep = 10, AzimuthStop = 200,
                                 ElevationStart = 0, ElevationStep = 0, ElevationStop = 0,
                                 Speed = 5, Radius = 12,
                                 Plane = RasterPlan.PlaneEnum.Elevation,
                                 Direction = RasterPlan.DirectionEnum.Increasing,
                                 Polarization = RasterPlan.PolarizationEnum.Cross},
            };
            _scanPlanServiceMock.Setup(service => service.GetAll()).Returns(scanpPlansList);

            var result = _scanPlanController.Get() as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;
            var EXPECTED_COUNT = 3;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var scanPlans = result.Value as List<BaseScanPlan>;
            Assert.IsNotNull(scanPlans);
            Assert.That(EXPECTED_COUNT, Is.EqualTo(scanPlans.Count));
            _scanPlanServiceMock.Verify(service => service.GetAll(), Times.Once);
        }
        [Test]
        public void PostScanPlanTest()
        {
            var scanPlanCreateRequest = new ScanPlanCreateRequest
            {
                MissionID = 1,
                Name = "Scan Plan 1",
                Comment = "",
                Type = (int)ScanType.SinglePoint,
                Duration = 42,
                OffsetAzimuth = 0,
                OffsetElevation = 0,
                Radius = 0,
                Polarization = (int)SinglePointPlan.PolarizationEnum.Cross
            };
            var createdScanPlan = new SinglePointPlan
            {
                Id = 2,
                MissionID = 1,
                Name = "Scan Plan 1",
                Comment = "",
                Type = ScanType.SinglePoint,
                Duration = 42,
                OffsetAzimuth = 0,
                OffsetElevation = 0,
                Radius = 0,
                Polarization = SinglePointPlan.PolarizationEnum.Cross
            };

            _scanPlanServiceMock.Setup(service => service.Create(scanPlanCreateRequest)).Returns(createdScanPlan);
            var result = _scanPlanController.Post(scanPlanCreateRequest) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            var scanPlan = result.Value as BaseScanPlan;

            Assert.IsNotNull(scanPlan);
            Assert.That(createdScanPlan.Id, Is.EqualTo(scanPlan.Id));
            _scanPlanServiceMock.Verify(service => service.Create(scanPlanCreateRequest), Times.Once);
        }

        [Test]
        public void PutScanPlanTest()
        {
            int scanPlanId = 1;
            var scanPlanUpdateRequest = new ScanPlanUpdateRequest {
                Name = "Scan Plan 1",
                Comment = "",
                Type = (int)ScanType.SinglePoint,
                Duration = 42,
                Radius = 0,
                Polarization = (int)SinglePointPlan.PolarizationEnum.Cross
            };
            var updatedScanPlan = new SinglePointPlan {
                Name = "Scan Plan 1",
                Comment = "",
                Type = ScanType.SinglePoint,
                Duration = 42,
                Radius = 0,
                Polarization = SinglePointPlan.PolarizationEnum.Cross
            };
            _scanPlanServiceMock.Setup(service => service.Update(scanPlanId, scanPlanUpdateRequest)).Returns(updatedScanPlan);

            var result = _scanPlanController.Put(scanPlanId, scanPlanUpdateRequest) as OkObjectResult;

            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var scanPlan = result.Value as SinglePointPlan;
            Assert.IsNotNull(scanPlan);
            Assert.That(updatedScanPlan.Id, Is.EqualTo(scanPlan.Id));
            _scanPlanServiceMock.Verify(service => service.Update(scanPlanId, scanPlanUpdateRequest), Times.Once);
        }

        [Test]
        public void DeleteScanPlanTest()
        {
            int scanPlanId = 1;
            _scanPlanServiceMock.Setup(service => service.Delete(scanPlanId));
            var result = _scanPlanController.Delete(scanPlanId) as OkObjectResult;


            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            _scanPlanServiceMock.Verify(service => service.Delete(scanPlanId), Times.Once);
        }
    }
}