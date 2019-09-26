using EasyConsole.Core;

namespace Demo.Core.Pages
{
    class Page1Ai : Page
    {
        public Page1Ai(Program program)
            : base("Page 1Ai", program)
        {
        }

        public override void Display(object data = null)
        {
            base.Display(data);

            Output.WriteLine("Hello from Page 1Ai");

            Input.ReadString("Press [Enter] to navigate home");
            this.Program.NavigateHome();
        }
    }
}
