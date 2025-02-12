﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsole.Core
{
    public class Menu
    {
        private IList<Option> Options { get; set; }

        public Menu()
        {
            this.Options = new List<Option>();
        }

        public void Display()
        {
            for (int i = 0; i < this.Options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, this.Options[i].Name);
            }
            int choice = Input.ReadInt("Choose an option:", min: 1, max: this.Options.Count);

            this.Options[choice - 1].Callback();
        }

        public Menu Add(string option, Action callback)
        {
            return this.Add(new Option(option, callback));
        }

        public Menu Add(Option option)
        {
            this.Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return this.Options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
        }
    }
}
