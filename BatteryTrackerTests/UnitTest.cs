using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using SerialChargeTracker;

namespace SerialChargeTracker.Tests
{
    [TestClass]
    public class BatteryTrackerTests
    {
        private const string TestFileName = "BatteryTrackerTests_log.txt";

        // Очищаем файл перед каждым тестом
        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(TestFileName)) File.Delete(TestFileName);
        }

        [TestMethod]
        public void Parser_ShouldParseCorrectString()
        {
            // Arrange (Подготовка)
            string raw = "$12.5,1.2,25";

            // Act (Действие)
            var result = BatteryParser.Parse(raw);

            // Assert (Проверка)
            Assert.IsNotNull(result);
            Assert.AreEqual(12.5, result.Voltage);
            Assert.AreEqual(1.2, result.Current);
            Assert.AreEqual(25, result.Temperature);
        }

        [TestMethod]
        public void FileRepository_ShouldSaveAndReadBack()
        {
            // Arrange
            var repo = new FileRepository(TestFileName);
            string rawInput = "$14.2,0.5,30";

            // Act
            repo.AppendRaw(rawInput);
            List<BatteryData> history = repo.ReadAll();

            // Assert
            Assert.AreEqual(1, history.Count, "Запись должна быть сохранена и прочитана");
            Assert.AreEqual(14.2, history[0].Voltage);
            // Проверяем, что дата добавилась (она должна быть сегодняшней)
            Assert.AreEqual(DateTime.Now.Date, history[0].Timestamp.Date);
        }

        [TestMethod]
        public void Parser_ShouldReturnNull_OnGarbageInput()
        {
            // Act
            var result = BatteryParser.Parse("$сломанные,данные,123");

            // Assert
            Assert.IsNull(result, "Парсер должен возвращать null при некорректных данных");
        }

        [TestMethod]
        public void SystemController_FullCycleTest()
        {
            // Arrange
            var controller = new SystemController(TestFileName);
            string raw1 = "$10.0,1.0,20";
            string raw2 = "$11.0,2.0,21";

            // Act
            controller.ProcessManualInput(raw1);
            controller.ProcessManualInput(raw2);
            var history = controller.GetHistory();

            // Assert
            Assert.AreEqual(2, history.Count);
            Assert.AreEqual(10.0, history[0].Voltage);
            Assert.AreEqual(11.0, history[1].Voltage);
        }

        // Удаляем файл после тестов
        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestFileName)) File.Delete(TestFileName);
        }
    }
}