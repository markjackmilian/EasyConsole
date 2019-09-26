using System;
using System.Linq;

namespace EasyConsole.Core.Plus
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            this.Title = title;
            this.Program = program;
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
