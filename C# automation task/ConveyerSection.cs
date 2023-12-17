using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТЗ
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class ConveyorSystem
    {
        private const string ConfigFilePath = "config.json";
        private const int N = 5; // Количество секций

        // Класс для хранения конфигурации секции
        public class SectionConfig
        {
            public bool Input { get; set; }
            public bool Output { get; set; }
        }

        // Список конфигураций секций
        public List<SectionConfig> Sections { get; set; }

        public ConveyorSystem()
        {
            // Загрузка конфигурации из файла
            LoadConfig();
        }

        public void RebuildSystem()
        {
            // Обновление конфигурации системы
            Sections = new List<SectionConfig>();
            for (int i = 0; i < N; i++)
            {
                Sections.Add(new SectionConfig { Input = true, Output = false });
            }

            // Сохранение новой конфигурации в файл
            SaveConfig();
        }

        public void StartSystem()
        {
            foreach (var section in Sections)
            {
                if (section.Input)
                {
                    // Включение текущей секции и передача груза на следующую секцию
                    section.Output = true;
                    section.Input = false;
                }
            }

            // Сохранение изменений в конфигурации
            SaveConfig();
        }

        public void StopSystem()
        {
            foreach (var section in Sections)
            {
                // Отключение всех секций
                section.Input = true;
                section.Output = false;
            }

            // Сохранение изменений в конфигурации
            SaveConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                Sections = JsonConvert.DeserializeObject<List<SectionConfig>>(json);
            }
            else
            {
                // Создание новой конфигурации по умолчанию, если файла нет
                RebuildSystem();
            }
        }

        private void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(Sections);
            File.WriteAllText(ConfigFilePath, json);
        }
    }
}
