using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Entities;
using Apps.DataProcessor.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using System.Collections.Generic;

namespace Apps.DataProcessor.DataAccess.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestCategory("CI"), TestMethod]
        public async Task Should_GetData_Updated_Within_The_Given_Interval()
        {
            //Arrange
            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var dbOptions = new DbContextOptionsBuilder<UserDBContext>()
                           .UseInMemoryDatabase(databaseName: "TestDB")
                           .Options;

            var userDBContext = new UserDBContext(dbOptions);
            userDBContext.Users.AddRange(GetMockUsers());
            userDBContext.SaveChanges();

            UserRepository userRepository = new UserRepository(userDBContext);

            //Act
            var userRecords = await userRepository.GetLastUpdatedUsers(-15);

            //Assert
            userRecords.Count().Should().Be(1);
        }

        private static List<UserRecord> GetMockUsers()
        {
            return new List<UserRecord>
            {

                new UserRecord
                {
                    RecordId = 456,
                    UserId = "abcd-1234",
                    UserName = "Vijay",
                    UserEmail = "vijay@test.com",
                    DataValue = "test data",
                    NotificationFlag = true,
                    CreatedDateTime = Convert.ToDateTime("2022-10-24"),
                    LastUpdatedDateTime = Convert.ToDateTime("2022-10-25")
                },
                new UserRecord
                {
                RecordId = 123,
                UserId = "efgh-567",
                UserName = "Joe",
                UserEmail = "Joe@test.com",
                DataValue = "Joes test data",
                NotificationFlag = true,
                CreatedDateTime = DateTime.Now,
                LastUpdatedDateTime = DateTime.Now
                }
            };
        }
    }
}