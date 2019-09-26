using System;

namespace EasyConsole.Core.Classes
{
    public static class Extensions
    {
        public static void Prompt(this string text)
        {
            Output.WriteLine(text);
        }
        
        public static void Prompt(this string text, ConsoleColor color)
        {
            Output.WriteLine(color,text);
        }

        public static void PromptWarning(this string text)
        {
            Output.WriteLine(ConsoleColor.Yellow,text);
        }
        
        public static void PromptError(this string text)
        {
            Output.WriteLine(ConsoleColor.Red,text);
        }
        
        public static void PromptSuccess(this string text)
        {
            Output.WriteLine(ConsoleColor.Green,text);
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        public static T Cast<T>(this object obj)
        {
            return (T) obj;
        }
    }
}