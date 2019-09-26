using EasyConsole.Core;
using EasyConsole.Core.Plus;

namespace Demo.Core.Pages
{
    class Page1B : Page
    {
        public Page1B(Program program)
            : base("Page 1B", program)
        {
        }

        public override void Display(object data = null)
        {
            base.Display(data);

            Output.WriteLine("Hello from Page 1B");

            Input.ReadString("Press [Enter] to navigate home");
            this.Program.NavigateHome();
        }
    }
}
