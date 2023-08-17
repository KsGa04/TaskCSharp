//using NUnit.Framework;
//using System.Threading.Tasks;
//using Moq;
//using Microsoft.Extensions.Configuration;
//using TaskCSharp;

//namespace TaskCSharp.Tests
//{
//    public class RequestCounterServiceTests
//    {
//        private RequestCounterService _counterService;

//        [SetUp]
//        public void Setup()
//        {
//            var configMock = new Mock<IConfiguration>();
//            configMock.Setup(config => config["Settings:ParallelLimit"]).Returns("10");

//            _counterService = new RequestCounterService(configMock.Object);
//        }

//        [Test]
//        public async Task TryAcquireRequestSlot_WhenSemaphoreIsNotFull_ShouldReturnTrue()
//        {
//            // Act
//            var result = await _counterService.TryAcquireRequestSlot();

//            // Assert
//            Assert.IsTrue(result);
//        }


//        [Test]
//        public void ReleaseRequestSlot_ShouldReleaseOneSlot()
//        {
//            // Arrange
//            var semaphoreInitialCount = _counterService.GetSemaphoreCurrentCount();
//            var expectedCount = semaphoreInitialCount + 1;

//            // Act
//            _counterService.ReleaseRequestSlot();
//            var currentCount = _counterService.GetSemaphoreCurrentCount();

//            // Assert
//            Assert.AreEqual(expectedCount, currentCount);
//        }
//    }
//}