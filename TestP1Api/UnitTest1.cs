using Xunit;
using Moq;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestP1Api
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //Arrange
            List<StoreDtos> storeList = new()
            {
                new()
                {
                    StoreID = 80,
                    StoreLocation = "Seattle"
                },
                new()
                {
                    StoreID = 81,
                    StoreLocation = "Portland"
                },
                new()
                {
                    StoreID = 82,
                    StoreLocation = "Sacramento"
                }
            };
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.ReadStoreMenu()).Returns(Task.FromResult(storeList));
            var controller = new StoreController(moq.Object);
            
            //Act
            var expected = await controller.DisplayStoreOptions();

            //Assert
            for(int i = 0; i < storeList.Count; i++)
            { Assert.Equal(storeList[i].StoreID, expected[i].StoreID); 
             Assert.Equal(storeList[i].StoreLocation, expected[i].StoreLocation); }
        }
    }
}