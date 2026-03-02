using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using SerialChargeTracker;
using SerialChargeTracker.Services;
using SerialChargeTracker.DataRepositories;
using SerialChargeTracker.Models;
using SerialChargeTracker.Hardware; // Добавили для IBatteryMonitor

namespace SerialChargeTracker.Tests
{
    [TestClass]
    public class BatteryTrackerTests
    {
        private const string TestFileName = "BatteryTrackerTests_log.txt";

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(TestFileName)) File.Delete(TestFileName);
        }

        [TestMethod]
        public void Parser_ShouldParseCorrectString()
        {
            string raw = "$12.5,1.2,25";
            var result = BatteryParser.Parse(raw);

            Assert.IsNotNull(result);
            Assert.AreEqual(12.5, result.Voltage);
            Assert.AreEqual(1.2, result.Current);
            Assert.AreEqual(25, result.Temperature);
        }

        [TestMethod]
        public void FileRepository_ShouldSaveAndReadBack()
        {
            var repo = new FileRepository(TestFileName);
            string rawInput = "$14.2,0.5,30";

            repo.AppendRaw(rawInput);
            List<BatteryData> history = repo.ReadAll();

            Assert.AreEqual(1, history.Count, "Запись должна быть сохранена и прочитана");
            Assert.AreEqual(14.2, history[0].Voltage);
            Assert.AreEqual(DateTime.Now.Date, history[0].Timestamp.Date);
        }

        [TestMethod]
        public void Parser_ShouldReturnNull_OnGarbageInput()
        {
            var result = BatteryParser.Parse("$сломанные,данные,123");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SystemController_FullCycleTest()
        {
            // Arrange: теперь передаем монитор (реализация интерфейса) и путь
            IBatteryMonitor mockMonitor = new VirtualBatteryMonitor();
            var controller = new SystemController(mockMonitor, TestFileName);
            
            string raw1 = "$10.0,1.0,20";
            string raw2 = "$11.0,2.0,21";

            // Act
            controller.ProcessManualInput(raw1);
            controller.ProcessManualInput(raw2);
            var history = controller.GetHistory();

            // Assert
            Assert.AreEqual(2, history.Count);
            // Обращаемся к элементам списка по индексу
            Assert.AreEqual(10.0, history[0].Voltage);
            Assert.AreEqual(11.0, history[1].Voltage);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestFileName)) File.Delete(TestFileName);
        }
    }
}
