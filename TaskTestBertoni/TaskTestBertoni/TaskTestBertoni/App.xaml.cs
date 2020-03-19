using System;
using TaskTestBertoni.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTestBertoni
{
    public partial class App : Application
    {
        static DB database;
        public static DB DB
        {
            get
            {
                if (database == null)
                {
                    database = new DB(DependencyService.Get<IFileHelper>().GetLocalFilePath("TaskBertoniApp.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
