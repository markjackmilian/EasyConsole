using Demo.Core.Pages;
using EasyConsole.Core;
using EasyConsole.Core.Plus;

namespace Demo.Core
{
    class DemoProgram : Program
    {
        public DemoProgram()
            : base("EasyConsole Demo", breadcrumbHeader: true)
        {
            this.AddPage(new MainPage(this));
            this.AddPage(new Page1(this));
            this.AddPage(new Page1A(this));
            this.AddPage(new Page1Ai(this));
            this.AddPage(new Page1B(this));
            this.AddPage(new Page2(this));
            this.AddPage(new InputPage(this));

            this.SetPage<MainPage>();
        }
    }
}
