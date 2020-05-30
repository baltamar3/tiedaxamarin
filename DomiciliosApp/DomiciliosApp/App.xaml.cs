using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DomiciliosApp.Views;
using DomiciliosApp.Contexts;
using DomiciliosApp.Interfaces;

namespace DomiciliosApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            MainPage = new MainPage();
        }

        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("Domi.db");
            return new AppDbContext(DbPath);
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
