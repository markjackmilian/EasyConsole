namespace EasyConsole.Core
{
    public abstract class MenuPage : Page
    {
        protected Menu Menu { get; set; }

        public MenuPage(string title, Program program, params Option[] options)
            : base(title, program)
        {
            this.Menu = new Menu();

            foreach (var option in options)
                this.Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();

            if (this.Program.NavigationEnabled && !this.Menu.Contains("Go back"))
                this.Menu.Add("Go back", () => { this.Program.NavigateBack(); });

            this.Menu.Display();
        }
    }
}
