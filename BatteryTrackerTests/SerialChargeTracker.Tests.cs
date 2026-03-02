using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SerialChargeTracker.Tests
{
    [TestClass]
    public class VirtualSystemTests
    {
        private const string TestLog = "virtual_test_log.txt";

        [TestInitialize]
        public void Init()
        {
            if (File.Exists(TestLog)) File.Delete(TestLog);
        }

        [TestMethod]
        public async Task SystemController_ShouldReceiveMultiplePoints_FromVirtualMonitor()
        {
            // Arrange
            var controller = new SystemController(TestLog);
            int receivedCount = 0;
            var receivedData = new List<BatteryData>();

            // Подписываемся на событие новых данных
            controller.NewDataReady += (data) =>
            {
                receivedData.Add(data);
                receivedCount++;
            };

            // Act
            controller.Start(); // Запускаем виртуальный порт (раз в 1 сек)

            // Ждем 3.5 секунды (должно прийти 3-4 посылки)
            await Task.Delay(3500);

            controller.Stop();

            // Assert
            Assert.IsTrue(receivedCount >= 3, $"Ожидалось минимум 3 посылки, получено: {receivedCount}");
            Assert.IsTrue(File.Exists(TestLog), "Файл лога не был создан");

            // Проверяем, что в файле столько же строк, сколько пришло событий
            var fileLines = File.ReadAllLines(TestLog);
            Assert.AreEqual(receivedCount, fileLines.Length, "Количество строк в файле не совпадает с количеством событий");

            Console.WriteLine($"Успешно получено и сохранено {receivedCount} виртуальных записей.");
        }

        [TestMethod]
        public async Task VirtualMonitor_ShouldStopSending_AfterStopCalled()
        {
            // Arrange
            var monitor = new VirtualBatteryMonitor();
            int countAfterStop = 0;
            monitor.RawLineReceived += (s) => countAfterStop++;

            // Act
            monitor.Start();
            await Task.Delay(1100); // Получаем первую посылку
            monitor.Stop();

            int countAtStop = countAfterStop;
            await Task.Delay(1500); // Ждем еще, не придет ли что-то лишнее

            // Assert
            Assert.AreEqual(countAtStop, countAfterStop, "Монитор продолжил слать данные после остановки!");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Оставляем файл для визуального осмотра, если нужно, 
            // или удаляем:
            // if (File.Exists(TestLog)) File.Delete(TestLog);
        }
    }
}