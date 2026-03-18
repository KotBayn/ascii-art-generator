using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiArt.Core
{
    public static class AsciiRenderer
    {
        // Хранилище шрифтов: Стиль -> (Буква -> Строки)
        // private, чтобы снаружи не сломались данные
        private static Dictionary<string, Dictionary<char, string[]>> _fonts = new();

        // Статический конструктор: сработает сам при первом запуске
        static AsciiRenderer()
        {
            LoadFonts();
        }

        // Выбор по индексу
        public static string[] GetFontKeys()
        {
            return new List<string>(_fonts.Keys).ToArray();
        }

        // Что загрузилось
        public static void Debug_PrintFonts()
        {
            Console.WriteLine($"[DEBUG] Загружено шрифтов: {_fonts.Count}");
            foreach (var key in _fonts.Keys)
            {
                Console.WriteLine($"[DEBUG] Шрифт '{key}': букв в словаре = {_fonts[key].Count}");
            }
        }

        // ГЛАВНЫЙ МЕТОД: Возвращает готовый строковый арт
        public static string Render(string text, string fontName = "Standard", bool useSpecialChars = false)
        {
            // Проверка: есть ли такой шрифт?
            if (!_fonts.TryGetValue(fontName, out Dictionary<char, string[]>? font))
                return $"[ERROR] Font '{fontName}' not found";

            text = text.ToUpper(); // Работаем только с заглавными

            // Узнаем высоту шрифта (по первой попавшейся известной букве)
            int height = 5;
            foreach (char c in text)
            {
                if (font.ContainsKey(c))
                {
                    height = font[c].Length;
                    break;
                }
            }

            // StringBuilder - это как конструктор строк
            var result = new StringBuilder();

            // Рендеринг ПОСТРОЧНО
            for (int lineIndex = 0; lineIndex < height; lineIndex++)
            {
                foreach (char c in text)
                {
                    if (font.ContainsKey(c))
                    {
                        string line = font[c][lineIndex];

                        // Замена символов, если "Спецсимволы" стиль
                        if (useSpecialChars)
                            line = line.Replace('#', '█');

                        result.Append(line + " "); // Пробел между буквами
                    }
                    else
                    {
                        // Если буква неизвестна - рисуем пустоту
                        result.Append("     ");
                    }
                }
                result.AppendLine(); // Переход на новую строку после отрисовки ряда
            }

            return result.ToString();
        }

        // Метод загрузки шрифтов
        private static void LoadFonts()
        {
            // --- ШРИФТ 1: Standard ---
            var standard = new Dictionary<char, string[]>();


            // Буква A
            standard['A'] = new string[] {
                "  #  ",
                " # # ",
                "#####",
                "#   #",
                "#   #"
            };

            // Буква B
            standard['B'] = new string[] {
                "#### ",
                "#   #",
                "#### ",
                "#   #",
                "#### "
            };

            // Буква C
            standard['C'] = new string[] {
                "#####",
                "#    ",
                "#    ",
                "#    ",
                "#####"
            };

            // Буква D
            standard['D'] = new string[] {
                "#### ",
                "#   #",
                "#   #",
                "#   #",
                "#### "
            };

            // Буква E
            standard['E'] = new string[] {
                "#####",
                "#    ",
                "#### ",
                "#    ",
                "#####"
            };

            // Буква F
            standard['F'] = new string[] {
                "#####",
                "#    ",
                "#### ",
                "#    ",
                "#    "
            };

            // Буква G
            standard['G'] = new string[] {
                "#### ",
                "#    ",
                "# ## ",
                "#  # ",
                "#### "
            };

            // Буква H
            standard['H'] = new string[] {
                "#   #",
                "#   #",
                "#####",
                "#   #",
                "#   #"
            };

            // Буква I
            standard['I'] = new string[] {
                "#####",
                "  #  ",
                "  #  ",
                "  #  ",
                "#####"
            };

            // Буква J
            standard['J'] = new string[] {
                "#####",
                "    #",
                "    #",
                "#   #",
                " ### "
            };

            // Буква K
            standard['K'] = new string[] {
                "#   #",
                "#  # ",
                "###  ",
                "#  # ",
                "#   #"
            };

            // Буква L
            standard['L'] = new string[] {
                "#    ",
                "#    ",
                "#    ",
                "#    ",
                "#####"
            };

            // Буква M
            standard['M'] = new string[] {
                "#    #",
                "##  ##",
                "# ## #",
                "#    #",
                "#    #"
            };

            // Буква N
            standard['N'] = new string[] {
                "#   #",
                "##  #",
                "# # #",
                "#  ##",
                "#   #"
            };

            // Буква O
            standard['O'] = new string[] {
                "#####",
                "#   #",
                "#   #",
                "#   #",
                "#####"
            };

            // Буква P
            standard['P'] = new string[] {
                "#### ",
                "#   #",
                "#### ",
                "#    ",
                "#    "
            };

            // Буква Q
            standard['Q'] = new string[] {
                "##### ",
                "#   # ",
                "#   # ",
                "#   # ",
                "######"
            };

            // Буква R
            standard['R'] = new string[] {
                "#### ",
                "#   #",
                "#### ",
                "#   #",
                "#   #"
            };

            // Буква S
            standard['S'] = new string[] {
                " ### ",
                " #   ",
                "  #  ",
                "   # ",
                " ### "
            };

            // Буква T
            standard['T'] = new string[] {
                "#####",
                "  #  ",
                "  #  ",
                "  #  ",
                "  #  "
            };

            // Буква U
            standard['U'] = new string[] {
                "#   #",
                "#   #",
                "#   #",
                "#   #",
                " ### "
            };

            // Буква V
            standard['V'] = new string[] {
                "#   #",
                "#   #",
                " # # ",
                " # # ",
                "  #  "
            };

            // Буква W
            standard['W'] = new string[] {
                "#     #",
                "#     #",
                "#  #  #",
                " # # # ",
                "  # #  "
            };

            // Буква X
            standard['X'] = new string[] {
                "#   #",
                " # # ",
                "  #  ",
                " # # ",
                "#   #"
            };

            // Буква Y
            standard['Y'] = new string[] {
                "#   #",
                "#   #",
                " # # ",
                "  #  ",
                "  #  "
            };

            // Буква Z
            standard['Z'] = new string[] {
                "#####",
                "   # ",
                "  #  ",
                " #   ",
                "#####"
            };

            // Цифры 0-9
            standard['0'] = new string[] {
                " ### ",
                "#   #",
                "#   #",
                "#   #",
                " ### "
            };
            
            standard['1'] = new string[] {
                "  #  ",
                " ##  ",
                "  #  ",
                "  #  ",
                "#####",
            };
            
            standard['2'] = new string[] {
                " ### ",
                "#   #",
                "  ## ",
                " #   ",
                "#####",
            };
            
            standard['3'] = new string[] {
                " ### ",
                "#   #",
                " ### ",
                "    #",
                " ### ",
            };
            
            standard['4'] = new string[] {
                "#   #",
                "#   #",
                "#####",
                "    #",
                "    #",
            };
            
            standard['5'] = new string[] {
                "#####",
                "#    ",
                "#### ",
                "    #",
                " ####",
            };
            
            standard['6'] = new string[] {
                "  ## ",
                " #   ",
                "#### ",
                "#   #",
                " ### ",
            };
            
            standard['7'] = new string[] {
                "#####",
                "    #",
                "   # ",
                "  #  ",
                "  #  ",
            };
            
            standard['8'] = new string[] {
                " ### ",
                "#   #",
                " ### ",
                "#   #",
                " ### ",
            };
            
            standard['9'] = new string[] {
                " ### ",
                "#   #",
                " ####",
                "    #",
                "###  ",
            };

            // Знаки препинания
            standard[' '] = new string[] {  // Пробел
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
            };
            
            standard['!'] = new string[] {
                "  #  ",
                "  #  ",
                "  #  ",
                "     ",
                "  #  ",
            };
            
            standard['?'] = new string[] {
                " ### ",
                "#   #",
                "  ## ",
                "     ",
                "  #  ",
            };
            
            standard['.'] = new string[] {
                "     ",
                "     ",
                "     ",
                "     ",
                "  #  ",
            };
            
            standard[','] = new string[] {
                "     ",
                "     ",
                "     ",
                "   # ",
                "  #  ",
            };
             
            standard['-'] = new string[] {
                "     ",
                "     ",
                "#####",
                "     ",
                "     ",
            };
                        
            standard[':'] = new string[] {
                "     ",
                "  #  ",
                "     ",
                "  #  ",
                "     ",
            };
                        
            standard['\''] = new string[] {  // Апостроф
                "  #  ",
                "  #  ",
                "     ",
                "     ",
                "     ",
            };


            // Добавляем стиль в общий список
            _fonts["Standard"] = standard;

            // --- ШРИФТ 2: Bold ---
            var bold = new Dictionary<char, string[]>();

            // Буква A
            bold['A'] = new string[] {
                "  ###  ",
                " ## ## ",
                "#######",
                "#######",
                "##   ##",
                "##   ##"
            };

            // Буква B
            bold['B'] = new string[] {
                "##### ",
                "##  ##",
                "##### ",
                "##  ##",
                "##  ##",
                "##### "
            };

            // Буква C
            bold['C'] = new string[] {
                "######",
                "##    ",
                "##    ",
                "##    ",
                "##    ",
                "######"
            };

            // Буква D
            bold['D'] = new string[] {
                "##### ",
                "##  ##",
                "##  ##",
                "##  ##",
                "##  ##",
                "##### "
            };

            // Буква E
            bold['E'] = new string[] {
                "######",
                "##    ",
                "##    ",
                "##### ",
                "##    ",
                "######"
            };

            // Буква F
            bold['F'] = new string[] {
                "######",
                "##    ",
                "##### ",
                "##    ",
                "##    ",
                "##    "
            };

            // Буква G
            bold['G'] = new string[] {
                "######",
                "##    ",
                "##    ",
                "##  # ",
                "##  ##",
                "##### "
            };

            // Буква H
            bold['H'] = new string[] {
                "##  ##",
                "##  ##",
                "######",
                "######",
                "##  ##",
                "##  ##"
            };

            // Буква I
            bold['I'] = new string[] {
                "######",
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "######"
            };

            // Буква J
            bold['J'] = new string[] {
                "######",
                "    ##",
                "    ##",
                "    ##",
                "#   ##",
                " #### "
            };

            // Буква K
            bold['K'] = new string[] {
                "##  ##",
                "## ## ",
                "####  ",
                "####  ",
                "## ## ",
                "##  ##"
            };

            // Буква L
            bold['L'] = new string[] {
                "##    ",
                "##    ",
                "##    ",
                "##    ",
                "##    ",
                "######"
            };

            // Буква M
            bold['M'] = new string[] {
                "##    ##",
                "###  ###",
                "## ## ##",
                "## ## ##",
                "##    ##",
                "##    ##"
            };

            // Буква N
            bold['N'] = new string[] {
                "##   ##",
                "###  ##",
                "## # ##",
                "## # ##",
                "##  ###",
                "##   ##"
            };

            // Буква O
            bold['O'] = new string[] {
                "######",
                "##  ##",
                "##  ##",
                "##  ##",
                "##  ##",
                "######"
            };

            // Буква P
            bold['P'] = new string[] {
                "##### ",
                "##  ##",
                "##### ",
                "##    ",
                "##    ",
                "##    "
            };

            // Буква Q
            bold['Q'] = new string[] {
                "######",
                "##  ##",
                "##  ##",
                "##  ##",
                "######",
                "    ##"
            };

            // Буква R
            bold['R'] = new string[] {
                "##### ",
                "##  ##",
                "##### ",
                "##  ##",
                "##  ##",
                "##  ##"
            };

            // Буква S
            bold['S'] = new string[] {
                " #### ",
                " ##   ",
                "  ##  ",
                "  ##  ",
                "   ## ",
                " #### "
            };

            // Буква T
            bold['T'] = new string[] {
                "######",
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "  ##  "
            };

            // Буква U
            bold['U'] = new string[] {
                "##  ##",
                "##  ##",
                "##  ##",
                "##  ##",
                "##  ##",
                " #### "
            };

            // Буква V
            bold['V'] = new string[] {
                "##   ##",
                "##   ##",
                "##   ##",
                " ## ## ",
                " ## ## ",
                "   #   "
            };

            // Буква W
            bold['W'] = new string[] {
                "##     ##",
                "##     ##",
                "##  #  ##",
                " ## # ## ",
                "  # # #  ",
                "  # # #  "
            };

            // Буква X
            bold['X'] = new string[] {
                "##    ##",
                " ##  ## ",
                "   ##   ",
                "   ##   ",
                " ##  ## ",
                "##    ##"
            };

            // Буква Y
            bold['Y'] = new string[] {
                "##    ##",
                " ##  ## ",
                "  #  #  ",
                "   ##   ",
                "   ##   ",
                "   ##   "
            };

            // Буква Z
            bold['Z'] = new string[] {
                "######",
                "    ##",
                "   ## ",
                "  ##  ",
                " ##   ",
                "######"
            };

            // Цифры 0-9
            bold['0'] = new string[] {
                " #### ",
                "##  ##",
                "##  ##",
                "##  ##",
                "##  ##",
                " #### "
            };

            bold['1'] = new string[] {
                "  ##  ",
                " ###  ",
                "# ##  ",
                "  ##  ",
                "  ##  ",
                "######"
            };

            bold['2'] = new string[] {
                " #### ",
                "#   ##",
                "  ##  ",
                " ##   ",
                "##    ",
                "######"
            };

            bold['3'] = new string[] {
                " #### ",
                "     #",
                "     #",
                " #### ",
                "     #",
                " #### "
            };

            bold['4'] = new string[] {
                "##  ##",
                "##  ##",
                "######",
                "    ##",
                "    ##",
                "    ##"
            };

            bold['5'] = new string[] {
                "######",
                "##    ",
                "##### ",
                "    ##",
                "    ##",
                "##### "
            };

            bold['6'] = new string[] {
                "  ### ",
                " ##   ",
                "##    ",
                "##### ",
                "##  ##",
                " #### "
            };

            bold['7'] = new string[] {
                "######",
                "    ##",
                "   ## ",
                "  ##  ",
                "  ##  ",
                "  ##  "
            };

            bold['8'] = new string[] {
                " #### ",
                "##  ##",
                " #### ",
                " #### ",
                "##  ##",
                " #### "
            };

            bold['9'] = new string[] {
                " #### ",
                "##  ##",
                " #####",
                "    ##",
                "   ## ",
                "####  "
            };

            // Знаки препинания
            bold[' '] = new string[] {  // Пробел
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                "     "
            };

            bold['!'] = new string[] {
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "  ##  ",
                "      ",
                "  ##  "
            };

            bold['?'] = new string[] {
                " #### ",
                "##  ##",
                "  ##  ",
                "  ##  ",
                "      ",
                "  ##  "
            };

            bold['.'] = new string[] {
                "      ",
                "      ",
                "      ",
                "      ",
                "      ",
                "  ##  "
            };

            bold[','] = new string[] {
                "      ",
                "      ",
                "      ",
                "      ",
                "   ## ",
                "  ##  "
            };

            bold['-'] = new string[] {
                "      ",
                "      ",
                "######",
                "      ",
                "      ",
                "      "
            };

            bold[':'] = new string[] {
                "      ",
                "  ##  ",
                "      ",
                "      ",
                "  ##  ",
                "      "
            };

            bold['\''] = new string[] {  // Апостроф
                "  ##  ",
                "  ##  ",
                "      ",
                "      ",
                "      ",
                "      "
            };

            _fonts["Bold"] = bold;

            // --- ШРИФТ 1: Standard ---
            var small = new Dictionary<char, string[]>();


            // Буква A
            small['A'] = new string[] {
                " ^ ",
                "'-'",
                "| |"
            };

            // Буква B
            small['B'] = new string[] {
                "|-,",
                "|-|",
                "|_'"
            };

            // Буква C
            small['C'] = new string[] {
                ",--",
                "|  ",
                "`--"
            };

            // Буква D
            small['D'] = new string[] {
                "|-,",
                "| |",
                "|_'"
            };

            // Буква E
            small['E'] = new string[] {
                "|--",
                "|--",
                "|--"
            };

            // Буква F
            small['F'] = new string[] {
                "|--",
                "|- ",
                "|  "
            };

            // Буква G
            small['G'] = new string[] {
                ",- ",
                "| _",
                "|_|"
            };

            // Буква H
            small['H'] = new string[] {
                "| |",
                "|-|",
                "| |"
            };

            // Буква I
            small['I'] = new string[] {
                "---",
                " | ",
                "---"
            };

            // Буква J
            small['J'] = new string[] {
                " -|",
                "  |",
                "(_'"
            };

            // Буква K
            small['K'] = new string[] {
                "| /",
                "|< ",
                "| |"
            };

            // Буква L
            small['L'] = new string[] {
                "|  ",
                "|  ",
                "|__"
            };

            // Буква M
            small['M'] = new string[] {
                "| |",
                "|V|",
                "| |"
            };

            // Буква N
            small['N'] = new string[] {
                "| |",
                "|%|",
                "| |"
            };

            // Буква O
            small['O'] = new string[] {
                ",_,",
                "( )",
                "'-'"
            };

            // Буква P
            small['P'] = new string[] {
                "|-,",
                "|-'",
                "|  "
            };

            // Буква Q
            small['Q'] = new string[] {
                ",_, ",
                "( ) ",
                "'-'~"
            };

            // Буква R
            small['R'] = new string[] {
                "|`]",
                "|< ",
                "| |"
            };

            // Буква S
            small['S'] = new string[] {
                "/-`",
                "'-,",
                "--'"
            };

            // Буква T
            small['T'] = new string[] {
                "-+-",
                " | ",
                " | "
            };

            // Буква U
            small['U'] = new string[] {
                "| |",
                "| |",
                "'_'"
            };

            // Буква V
            small['V'] = new string[] {
                "| |",
                "| |",
                " V "
            };

            // Буква W
            small['W'] = new string[] {
                "|   |",
                "| M |",
                " V V "
            };

            // Буква X
            small['X'] = new string[] {
                "* *",
                " X ",
                "* *"
            };

            // Буква Y
            small['Y'] = new string[] {
                "! /",
                " | ",
                " | "
            };

            // Буква Z
            small['Z'] = new string[] {
                "---",
                " / ",
                "---"
            };

            // Цифры 0-9
            small['0'] = new string[] {
                "   ",
                " 0 ",
                "   "
            };

            small['1'] = new string[] {
                "   ",
                " 1 ",
                "   "
            };

            small['2'] = new string[] {
                "   ",
                " 2 ",
                "   "
            };

            small['3'] = new string[] {
                "   ",
                " 3 ",
                "   "
            };

            small['4'] = new string[] {
                "   ",
                " 4 ",
                "   "
            };

            small['5'] = new string[] {
                "   ",
                " 5 ",
                "   "
            };

            small['6'] = new string[] {
                "   ",
                " 6 ",
                "   "
            };

            small['7'] = new string[] {
                "   ",
                " 7 ",
                "   "
            };

            small['8'] = new string[] {
                "   ",
                " 8 ",
                "   "
            };

            small['9'] = new string[] {
                "   ",
                " 9 ",
                "   "
            };

            // Знаки препинания
            small[' '] = new string[] {  // Пробел
                "     ",
                "     ",
                "     "
            };

            small['!'] = new string[] {
                " | ",
                " | ",
                " * "
            };

            small['?'] = new string[] {
                " __",
                "' |",
                " * "
            };

            small['.'] = new string[] {
                "   ",
                "   ",
                " * "
            };

            small[','] = new string[] {
                "   ",
                "   ",
                " *,"
            };

            small['-'] = new string[] {
                "   ",
                "***",
                "   "
            };

            small[':'] = new string[] {
                " * ",
                "   ",
                " * "
            };

            small['\''] = new string[] {  // Апостроф
                " * ",
                "   ",
                "   "
            };


            // Добавляем стиль в общий список
            _fonts["Small"] = small;
        }

        // Метод для создания рамки вокруг текста
        public static string WrapInBox(string content, bool doubleLine = false)
        {
            // Выбираем символы для рамки
            char hLine = doubleLine ? '═' : '─';
            char vLine = doubleLine ? '║' : '│';
            char tl = doubleLine ? '╔' : '┌';  // top-left
            char tr = doubleLine ? '╗' : '┐';  // top-right
            char bl = doubleLine ? '╚' : '└';  // bottom-left
            char br = doubleLine ? '╝' : '┘';  // bottom-right

            var lines = content.Split('\n');

            // Находим самую длинную строку
            int maxWidth = 0;
            foreach (var line in lines)
            {
                int len = line.TrimEnd('\r').Length;
                if (len > maxWidth) maxWidth = len;
            }

            var result = new StringBuilder();

            // Верхняя рамка
            result.Append(tl);
            for (int i = 0; i < maxWidth; i++) result.Append(hLine);
            result.Append(tr).AppendLine();

            // Строки контента с боковыми рамками
            foreach (var line in lines)
            {
                string cleanLine = line.TrimEnd('\r');
                result.Append(vLine);
                result.Append(cleanLine);

                // Добиваем пробелами до maxWidth
                for (int i = cleanLine.Length; i < maxWidth; i++)
                    result.Append(' ');

                result.Append(vLine).AppendLine();
            }

            // Нижняя рамка
            result.Append(bl);
            for (int i = 0; i < maxWidth; i++) result.Append(hLine);
            result.Append(br).AppendLine();

            return result.ToString();
        }

        // Вспомогательный метод: узнать, какие шрифты есть
        public static IEnumerable<string> GetAvailableFonts()
        {
            return _fonts.Keys;
        }
    }
}