using System;
using EasyConsole.Core;
using EasyConsole.Core.Plus;
using EasyConsole.Core.Plus.Classes;

namespace Demo.Core.Pages
{
    class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display(object data = null)
        {
            base.Display(data);

            var input2 = Input.ReadStrings(new[] {"A", "B", "C"});
            $"You select {input2}".Prompt();

            var input = Input.ReadEnum<Fruit>("Select a fruit");
            Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);

            Input.ReadString("Press [Enter] to navigate home");
            this.Program.NavigateHome();
        }
    }

    enum Fruit
    {
        Apple,
        Banana,
        Coconut
    }
}
