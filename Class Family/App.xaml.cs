namespace Class_Family
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.Page_Login());
        }
    }
}
