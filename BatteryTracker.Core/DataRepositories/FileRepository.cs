using BatteryTracker.Core.Models;
using BatteryTracker.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BatteryTracker.Core.DataRepositories
{
    public class FileRepository
    {
        private readonly string _logDirectory;
        private const string Header = "DateTime,Voltage,Current,Temperature";

        public FileRepository(string logDirectory)
        {
            // Сохраняем путь к папке, а не к конкретному файлу
            _logDirectory = logDirectory;
            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        // Метод для генерации имени файла на текущую дату
        private string GetCurrentFilePath()
        {
            string fileName = $"Log_{DateTime.Now:yyyy-MM-dd}.csv";
            return Path.Combine(_logDirectory, fileName);
        }

        public void WriteBatch(IEnumerable<string> lines)
        {
            if (lines == null || !lines.Any()) return;

            try
            {
                // Вычисляем путь ПРЯМО СЕЙЧАС (если наступил новый день, имя изменится)
                string currentPath = GetCurrentFilePath();

                if (!File.Exists(currentPath))
                {
                    File.WriteAllText(currentPath, Header + Environment.NewLine);
                }

                File.AppendAllLines(currentPath, lines);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка записи: {ex.Message}");
            }
        }

        public List<BatteryData> ReadAll()
        {
            var dataList = new List<BatteryData>();
            string currentPath = GetCurrentFilePath();

            if (!File.Exists(currentPath)) return dataList;

            try
            {
                foreach (string line in File.ReadLines(currentPath))
                {
                    if (line.StartsWith("DateTime")) continue;
                    var data = BatteryParser.Parse(line);
                    if (data != null) dataList.Add(data);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка чтения: {ex.Message}");
            }

            return dataList;
        }
    }
}
