using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using ContactsDirectory.Domain.Application;
using ContactsDirectory.Infastructure;
using ContactsDirectory.Infastructure.Repositories;
using ContactsDirectory.Ui.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace ContactsDirectory.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ContactsDatabase"].ConnectionString;

            var builder = new ContainerBuilder();
            builder.Register((c) => new ContactContext(connectionString));
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<MainWindowViewModel>();

            var csl = new AutofacServiceLocator(builder.Build());
            ServiceLocator.SetLocatorProvider(() => csl);
            
            this.InitDatabase();
        }

        private void InitDatabase()
        {
            var context = ServiceLocator.Current.GetInstance<ContactContext>();
            context.Database.EnsureCreated();
            
         
        }
    }
}
