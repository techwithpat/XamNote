using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamNote.Data;
using XamNote.Views;

namespace XamNote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.Initialize();

            InitializeRepository();

            InitializeMainPage();

        }

        private void InitializeMainPage()
        {
            MainPage = new NavigationPage(Locator.Resolve<HomeView>());
        }

        private static void InitializeRepository()
        {
            INoteRepository repository = Locator.Resolve<INoteRepository>();
            repository.Initialize();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
