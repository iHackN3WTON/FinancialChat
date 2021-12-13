using System;
using FinancialChat.StockBot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialChat.Tests
{
    [TestClass]
    public class StockBotUnitTest
    {
        [TestMethod]
        public void TestApiConsumer()
        {
            // Arrange
            ApiConsumer apiConsumer = new ApiConsumer();

            // Act
            var dataTable = apiConsumer.StockDataTable("AAPL.US");

            // Assert
            Assert.AreEqual("AAPL.US", dataTable.Select()[0].ItemArray[0].ToString(), "Command invalid");
        }

        [TestMethod]
        public void TestRequestStock()
        {
            // Arrange
            var stockBot = new StockBot.StockBot();

            // Act
            var result = stockBot.RequestStock("btc.v");

            // Assert
            Assert.AreNotEqual("", result, "Result empty");


        }
    }
}
