using System;
using System.Linq;

namespace EasyConsole.Core.Plus
{
    public abstract class Page
    {
        public string Title { get; protected set; }

        public Program Program { get; set; }

        public Page(Program program)
        {
            this.Program = program;
        }

        public Page(string title, Program program) : this(program)
        {
            this.Title = title;
        }

        public virtual void Display(object data = null)
        {
            if (this.Program.History.Count > 1 && this.Program.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in this.Program.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                Console.WriteLine(breadcrumb);
            }
            else
            {
                Console.WriteLine(this.Title);
            }
            Console.WriteLine("---");
        }
    }
}
