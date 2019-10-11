using System;
using System.Collections.Generic;

namespace EasyConsole.Core.Plus
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            var value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            var input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Select between a list of string
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string ReadStrings(IEnumerable<string> strings)
        {
            string choice = null;
            var menu = new Menu();
            foreach (var value in strings)
                menu.Add(value, () => { choice = value; });
            menu.Display();
            return choice;
        }

        /// <summary>
        /// Read object
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="title"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ReadObject<T>(IEnumerable<T> objects, Func<T, string> title = null)
        {
            var menu = new Menu();
            var choice = default(T);
            foreach (var value in objects)
                menu.Add(title == null ? value.ToString() : title.Invoke(value), () => { choice = value; });
            menu.Display();

            return choice;
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            var menu = new Menu();

            var choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}
