namespace ТЗ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Пример использования:
            ConveyorSystem system = new ConveyorSystem();

            system.StartSystem();
            Console.WriteLine("Система запущена");

            // Логика для определения наличия груза на датчике и активации соответствующей секции
            for (int i = 0; i < system.Sections.Count; i++)
            {
                bool isCargoDetected = DetermineCargoPresence(); // Здесь необходимо реализовать логику определения наличия груза на датчике
                if (isCargoDetected)
                {
                    if (i < system.Sections.Count - 1)
                    {
                        // Активируем текущую секцию и передаем груз на следующую
                        system.Sections[i].Output = true;
                        system.Sections[i].Input = false;
                        system.Sections[i + 1].Input = true;
                    }
                    else
                    {
                        // Груз достиг конца конвейера
                        system.Sections[i].Output = true;
                        system.Sections[i].Input = false;
                    }
                }
                else
                {
                    // Нет груза на текущем датчике, отключаем текущую секцию
                    system.Sections[i].Output = false;
                    system.Sections[i].Input = true;
                }
            }

            system.StopSystem();
            Console.WriteLine("Система остановлена");
        }

        static bool DetermineCargoPresence()
        {
            // Здесь можно добавить логику для определения наличия груза на датчике
            return true; // Возвратим true для примера, что груз обнаружен
        }
    }
}