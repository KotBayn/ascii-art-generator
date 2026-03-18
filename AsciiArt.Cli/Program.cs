using System;
using System.Collections.Generic;
using System.Linq;
using AsciiArt.Core;

namespace ANSI_art_gen
{
    class Program
    {
        // 1. Хранилище шрифтов. 
        // Ключ - название стиля, Значение - словарь (Буква -> Рисунок)
        static Dictionary<string, Dictionary<char, string[]>> fonts = new Dictionary<string, Dictionary<char, string[]>>();

        static void Main(string[] args)
        {
            AsciiRenderer.Debug_PrintFonts(); // Временная функция для проверки загрузки шрифтов
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== ASCII ART GENERATOR v1.1 ===");
            Console.ResetColor();
            // Показываем меню выбора шрифта
            var fonts = AsciiRenderer.GetFontKeys();
            Console.WriteLine("Выбери шрифт:");
            for (int i = 0; i < fonts.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {fonts[i]}");
            }

            Console.Write("\nНомер шрифта (1-" + fonts.Length + "): ");
            string fontChoice = Console.ReadLine();

            // Парсим выбор
            int fontIndex;
            if (!int.TryParse(fontChoice, out fontIndex) || fontIndex < 1 || fontIndex > fonts.Length)
            {
                Console.WriteLine("Неверный номер, используем первый шрифт.");
                fontIndex = 1;
            }
            string selectedFont = fonts[fontIndex - 1]; // Индекс массива с 0, а меню с 1

            // Ввод текста
            Console.Write("Введи текст: ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text)) text = "HELLO";

            Console.Write("Спецсимволы █? (y/n): ");
            bool special = Console.ReadLine()?.ToLower() == "y";

            // Генерация
            string result = AsciiRenderer.Render(text, selectedFont, special);

            Console.WriteLine("\n--- РЕЗУЛЬТАТ ---\n");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Нужна ли рамка
            Console.Write("Добавить рамку? (y/n): ");
            bool addBox = Console.ReadLine()?.ToLower() == "y";

            if (addBox)
            {
                Console.Write("Двойная рамка? (y/n): ");
                bool doubleLine = Console.ReadLine()?.ToLower() == "y";

                result = AsciiRenderer.WrapInBox(result, doubleLine);
            }

            Console.WriteLine(result);
            Console.ResetColor();

            // Сохранение
            Console.Write("Сохранить в art.txt? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                System.IO.File.WriteAllText("art.txt", result);
                Console.WriteLine("Сохранено.");
            }

            Console.WriteLine("\nНажми любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
 }