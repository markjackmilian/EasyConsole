using System;

namespace EasyConsole.Core.Plus.Classes
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

       
    }
}