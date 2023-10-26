using Apps.Data.Processor.Infrastructure;
using Apps.Data.Processor.Provider.Interface;
using Apps.Dataprocessor.Servicebus.Publisher.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using FizzWare.NBuilder;
using FluentAssertions;

namespace Apps.Data.Processor.Test
{
    [TestClass]
    public class DataProcessorTest
    {
        private Mock<IUserProvider> _mockUserProvider;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IServiceBusMessagePublisher> _mockServiceBusMessagePublisher;
        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void Setup()
        {
            _mockUserProvider = new Mock<IUserProvider>();
            _mockServiceBusMessagePublisher = new Mock<IServiceBusMessagePublisher>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger>();

            //Mocking IConfiguration to avoid appsettings.json dependency
            _mockConfiguration.SetupGet(a => a[It.Is<string>(b => b == "DataRetrievalWindowInMinutes")]).Returns("15");


        }
        [TestCategory("CI"), TestMethod]
        public async Task ServicePublisher_ShouldSendMessageToServiceBus_WhenThereIsUserData()
        {
            //Arrange
            DataProcessor dataProcessor = new DataProcessor(_mockUserProvider.Object, _mockConfiguration.Object,_mockServiceBusMessagePublisher.Object);
            List<UserModel> mockUserData = Builder<UserModel>.CreateListOfSize(1)
                .Build().ToList();
            int timeInterval = 15;

            var timer = default(TimerInfo);
            _mockUserProvider.Setup(a => a.GetLastUpdatedUsers(timeInterval))
                .ReturnsAsync(mockUserData);


            //Act
            await dataProcessor.Run(timer, _mockLogger.Object);

            //Assert
            _mockServiceBusMessagePublisher.Verify(a => a.PublishMessageAsync(mockUserData), Times.Exactly(1));
                
        }

        [TestCategory("CI"), TestMethod]
        public async Task ServicePublisher_ShouldNotSendMessageToServiceBus_WhenThereIsUserData()
        {
            //Arrange
            DataProcessor dataProcessor = new DataProcessor(_mockUserProvider.Object, _mockConfiguration.Object, _mockServiceBusMessagePublisher.Object);

            List<UserModel> mockUserData = new List<UserModel>();
            int timeInterval = 15;

            var timer = default(TimerInfo);
            _mockUserProvider.Setup(a => a.GetLastUpdatedUsers(timeInterval))
               .ReturnsAsync(new List<UserModel>());


            //Act
            await dataProcessor.Run(timer, _mockLogger.Object);

            //Assert
            _mockServiceBusMessagePublisher.Verify(a => a.PublishMessageAsync(mockUserData), Times.Exactly(0));

        }
    }
}