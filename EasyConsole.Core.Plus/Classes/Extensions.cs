using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
            Output.WriteLine(color, text);
        }

        public static void PromptWarning(this string text)
        {
            Output.WriteLine(ConsoleColor.Yellow, text);
        }

        public static void PromptError(this string text)
        {
            Output.WriteLine(ConsoleColor.Red, text);
        }

        public static void PromptSuccess(this string text)
        {
            Output.WriteLine(ConsoleColor.Green, text);
        }


        public static void NonBlockingPrompt(this string text)
        {
            Task.Run(text.Prompt);
        }

        public static void NonBlockingPrompt(this string text, ConsoleColor color)
        {
            Task.Run(() => text.Prompt(color));
        }

        public static void NonBlockingPromptWarning(this string text)
        {
            Task.Run(text.PromptWarning);
        }

        public static void NonBlockingPromptError(this string text)
        {
            Task.Run(text.PromptError);
        }

        public static void NonBlockingPromptSuccess(this string text)
        {
            Task.Run(text.PromptSuccess);
        }
    }
}