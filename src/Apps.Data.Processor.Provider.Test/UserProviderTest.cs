using Apps.Data.Processor.Infrastructure;
using Apps.DataProcessor.DataAccess.Entities;
using Apps.DataProcessor.DataAccess.Interfaces;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;

namespace Apps.Data.Processor.Provider.Test
{
    [TestClass]
    public class UserProviderTest
    {
        private Mock<IUserRepository> _mockUserRepository;

        [TestInitialize] 
        public void Initialize() 
        {
            _mockUserRepository = new Mock<IUserRepository>();
        }

        [TestCategory("CI"), TestMethod]
        public async Task GetLastUpdatedUser_ShouldMap_Data()
        {
            //Arrange
            var mockUserRecord = Builder<UserModel>
                .CreateListOfSize(1)
                .Build();

            _mockUserRepository.Setup(a => a.GetLastUpdatedUsers(It.IsAny<int>()))
                .ReturnsAsync(mockUserRecord);

            var userProvider = new UserProvider(_mockUserRepository.Object);

            //Act
            var actualUserRecord = await userProvider.GetLastUpdatedUsers(It.IsAny<int>());

            var actualUsers= actualUserRecord.ToList();

            //Assert
            actualUserRecord.Count().Should().Be(1);
            _mockUserRepository.Verify(a => a.GetLastUpdatedUsers(It.IsAny<int>()), Times.Exactly(1));

            actualUserRecord.Should().BeEquivalentTo(mockUserRecord);


        }

        [TestCategory("CI"), TestMethod]
        public async Task GetLastUpdatedUser_ShouldCall_Repositories_GetLastUpdatedUsers_Once()
        {
            //Arrange
            var mockUserRecord = Builder<UserModel>
                .CreateListOfSize(1)
                .Build();

            _mockUserRepository.Setup(a => a.GetLastUpdatedUsers(It.IsAny<int>()))
                .ReturnsAsync(mockUserRecord);

            var userProvider = new UserProvider(_mockUserRepository.Object);

            //Act
            var actualUserRecord = await userProvider.GetLastUpdatedUsers(It.IsAny<int>());

            //Assert
            _mockUserRepository.Verify(a => a.GetLastUpdatedUsers(It.IsAny<int>()), Times.Exactly(1));


        }
    }
}