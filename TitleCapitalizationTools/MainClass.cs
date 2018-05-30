using System;
using System.Globalization;
using System.Text;

namespace TitleCapitalizationTool
{
	public class MainClass
	{
		public static StringBuilder Capitalization(string text)
		{
			text = text.Trim();
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}
			text = CultureInfo.CurrentCulture.TextInfo.ToLower(text);
			string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
			string[] separator = titleCase.Split(new char[] { ' ' });
			string[] prepositions = { "A", "An", "At", "But", "By", "For", "In", "Nor", "Of", "On", "Or", "Out", "So", "The", "To", "Up", "Yet" };

			for (int i = 0; i < separator.Length; ++i)
			{
				foreach (string newSeparator in prepositions)
				{
					if (separator[i].Equals(newSeparator) && i != 0 && i != separator.Length - 1)
					{
						separator[i] = separator[i].ToLower();
					}
				}
			}
			titleCase = string.Join(" ", separator);
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
			return builder;
		}
		public static void Main(string[] text)
		{
			if (text.Length != 0)
			{
				for (int i = 0; i < text.Length; ++i)
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("Original title: ");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("Capitalized title: ");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(Capitalization(text[i]));
					Console.Write("\n");
				}
			}
			else
			{
				while (true)
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("Enter title to capitalization: ");
					Console.ForegroundColor = ConsoleColor.Red;
					string newText = Console.ReadLine();
					while (newText.Length == 0)
					{
						Console.SetCursorPosition(31, Console.CursorTop - 1);
						newText = Console.ReadLine();
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("Capitalized title: ");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(Capitalization(newText));
					Console.Write("\n");
				}
			}
		}
	}
}