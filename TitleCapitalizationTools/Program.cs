﻿using System;
using System.Globalization;
using System.Text;
namespace TitCapTool
{
    class MainClass
    {
        public static void Main()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Please, Enter a String in English:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                string text = Console.ReadLine();
                text = text.Trim();
                string[] preposition = new string[] { "A", "An", "The", "But", "For", "Nor", "So", "Yet", "At", "By", "In", "On", "Or", "Out", "To", "Up" };
                while (text.Contains("  "))
                {
                    text = text.Replace("  ", " ");
                }
                string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
                string[] split = titleCase.Split(new char[] { ' ' });
                for (int i = 0; i < split.Length; ++i)
                {
                    foreach (string newSplit in preposition)
                    {
                        if (split[i].Equals(newSplit))
                            split[i] = split[i].ToLower();
                    }
                }
                titleCase = string.Join(" ", split);
                StringBuilder builder = new StringBuilder();

                char[] punctuation = { ',', ':', ';', '?', '.', '!', '-' };
                for (int i = 0; i < titleCase.Length; ++i)
                {
                    bool space = false;
                    for (int j = 0; j < punctuation.Length; ++j)
                    {
                        if (titleCase[i] == ' ' && titleCase[i + 1] == punctuation[j])
                        {
                            i++;
                        }

                        if (titleCase[i] == punctuation[j] && i + 1 != titleCase.Length)
                        {
                            space = true;
                        }
                    }
                    if (titleCase[i] == '-')
                    {
                        builder.Append(' ');
                    }
                    builder.Append(titleCase[i]);
                    if (space)
                    {
                        builder.Append(' ');
                        builder.Append(titleCase[i + 1].ToString().ToUpper());
                        i++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Output String: \t");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(builder);
                Console.WriteLine("\n");
            }
            while (true);
        }
    }
}