﻿using System;
using EasyConsole.Core;

namespace Demo.Core.Pages
{
    class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Fruit input = Input.ReadEnum<Fruit>("Select a fruit");
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
