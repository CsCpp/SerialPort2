using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SerialChargeTracker.Hardware;
using SerialChargeTracker.Models;
using SerialChargeTracker.Services;
using SerialChargeTracker.DataRepositories;

namespace SerialChargeTracker.Tests
{
    [TestClass]
    public class SystemControllerTests
    {
        private const string TestLog = "integration_test_log.txt";

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(TestLog)) File.Delete(TestLog);
        }

        [TestMethod]
        public async Task Controller_ShouldProcessData_FromVirtualMonitor()
        {
            // 1. Создаем зависимость (Виртуальный монитор)
            IBatteryMonitor vMonitor = new VirtualBatteryMonitor();

            // 2. Внедряем её в контроллер
            var controller = new SystemController(vMonitor, TestLog);

            int receivedCount = 0;
            controller.NewDataReady += (data) => receivedCount++;

            // 3. Запуск
            controller.Start();

            // Ждем 2.5 секунды (должно прийти 3 посылки: сразу при старте, через 1с и через 2с)
            await Task.Delay(2500);

            controller.Stop();

            // Assert
            Assert.IsTrue(receivedCount >= 2, $"Ожидалось >= 2 посылок, получено: {receivedCount}");
            Assert.IsTrue(File.Exists(TestLog), "Файл лога не был создан контроллером");
        }

        [TestMethod]
        public void Controller_ManualInput_ShouldSaveToHistory()
        {
            // Для теста логики файла можно передать даже "пустой" монитор (Mock)
            // Но мы используем виртуалку для простоты
            var controller = new SystemController(new VirtualBatteryMonitor(), TestLog);

            // Act
            controller.ProcessManualInput("$12.0,1.0,20.0");
            controller.ProcessManualInput("$13.0,2.0,21.0");

            var history = controller.GetHistory();

            // Assert
            Assert.AreEqual(2, history.Count);
            Assert.AreEqual(12.0, history[0].Voltage);
            Assert.AreEqual(13.0, history[1].Voltage);
        }

        [TestCleanup]
        public void Teardown()
        {
            // Очистка после тестов
            if (File.Exists(TestLog)) File.Delete(TestLog);
        }
    }
}