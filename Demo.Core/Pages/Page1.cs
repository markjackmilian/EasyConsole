using EasyConsole.Core;
using EasyConsole.Core.Plus;
using EasyConsole.Core.Plus.Classes;
using mjm.nethelpers.Extensions;

namespace Demo.Core.Pages
{
    class Page1 : MenuPage
    {
        public Page1(Program program)
            : base("Page 1", program,
                  new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  new Option("Page 1B", () => program.NavigateTo<Page1B>()))
        {
        }

        public override void Display(object data)
        {
            if(data.IsNotNull() && data.Is<string>())
                data.Cast<string>().PromptSuccess();
            
            base.Display(data);
        }
    }
}
