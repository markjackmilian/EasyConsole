using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyConsole.Core.Plus
{
    public abstract class Program
    {
        protected string Title { get; set; }

        public bool BreadcrumbHeader { get; private set; }

        protected Page CurrentPage
        {
            get
            {
                return (this.History.Any()) ? this.History.Peek() : null;
            }
        }

        private Dictionary<Type, Lazy<Page>> Pages { get; set; }

        public Stack<Page> History { get; private set; }

        public bool NavigationEnabled { get { return this.History.Count > 1; } }

        protected Program(string title, bool breadcrumbHeader)
        {
            this.Title = title;
            this.Pages = new Dictionary<Type, Lazy<Page>>();
            this.History = new Stack<Page>();
            this.BreadcrumbHeader = breadcrumbHeader;
        }

        public virtual void Run(object data = null)
        {
            try
            {
                Console.Title = this.Title;

                this.CurrentPage.Display(data);
            }
            catch (Exception e)
            {
                Output.WriteLine(ConsoleColor.Red, e.ToString());
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Input.ReadString("Press [Enter] to exit");
                }
            }
        }

        public void AddPage<T>(Func<T> page) where T : Page
        {
            var pageType = typeof(T);
            
            if (this.Pages.ContainsKey(pageType))
                this.Pages[pageType] = new Lazy<Page>(page);
            else
                this.Pages.Add(pageType, new Lazy<Page>(page));
        }

        public void NavigateHome(object data = null)
        {
            while (this.History.Count > 1)
                this.History.Pop();

            Console.Clear();
            this.CurrentPage.DisplayBack(data);
        }

        public T SetPage<T>() where T : Page
        {
            var pageType = typeof(T);

            if (this.CurrentPage != null && this.CurrentPage.GetType() == pageType)
                return this.CurrentPage as T;

            // leave the current page

            // select the new page
            if (!this.Pages.TryGetValue(pageType, out var nextPage))
                throw new KeyNotFoundException($"The given page \"{pageType}\" was not present in the program");

            // enter the new page
            this.History.Push(nextPage.Value);

            return this.CurrentPage as T;
        }

        public T NavigateTo<T>(object data = null) where T : Page
        {
            this.SetPage<T>();

            Console.Clear();
            this.CurrentPage.Display(data);
            return this.CurrentPage as T;
        }

        public Page NavigateBack(object data = null)
        {
            this.History.Pop();

            Console.Clear();
            this.CurrentPage.DisplayBack(data);
            return this.CurrentPage;
        }
    }
}
