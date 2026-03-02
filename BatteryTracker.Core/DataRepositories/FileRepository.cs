using BatteryTracker.Core.Models;
using BatteryTracker.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace BatteryTracker.Core.DataRepositories
{
    public class FileRepository
    {
        private readonly string _path;

        public FileRepository(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Запись данных в файл
        /// </summary>
        /// <param name="rawLine">Сырые данные из МК</param>

        public void AppendRaw(string rawLine, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(rawLine)) return ;

            string processedLine = rawLine.Trim();

            // Если строка начинается с $, вставляем дату сразу после него
            if (processedLine.StartsWith("$"))
            {
                // Формат: $2023-10-25 12:00:00,12.5,1.2,25
                // Используем ToString("s") для ISO формата или "yyyy-MM-dd HH:mm:ss"

                string timestamp = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                processedLine = "$" + timestamp + "," + processedLine.Substring(1);
            }

            File.AppendAllLines(_path, new[] { processedLine });
           
        }
        // МЕТОД ЧТЕНИЯ
        public List<BatteryData> ReadAll()
        {
            var dataList = new List<BatteryData>();

            // 1. Проверяем, существует ли файл вообще
            if (!File.Exists(_path)) return dataList;

            try
            {
                // 2. Читаем файл построчно (эффективно для больших файлов)
                foreach (string line in File.ReadLines(_path))
                {
                    // 3. Используем ВАШ парсер для каждой строки
                    BatteryData data = BatteryParser.Parse(line);

                    // 4. Если строка корректна — добавляем в список
                    if (data != null)
                    {
                        dataList.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                // Тут можно логировать ошибку доступа к файлу
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return dataList;
        }
    }

}


