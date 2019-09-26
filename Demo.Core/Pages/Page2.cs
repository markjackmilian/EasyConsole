using EasyConsole.Core;
using EasyConsole.Core.Plus;

namespace Demo.Core.Pages
{
    class Page2 : Page
    {
        public Page2(Program program)
            : base("Page 2", program)
        {
        }

        public override void Display(object data = null)
        {
            base.Display(data);

            Output.WriteLine("Hello from Page 2");

            Input.ReadString("Press [Enter] to navigate home");
            this.Program.NavigateHome();
        }
    }
}
