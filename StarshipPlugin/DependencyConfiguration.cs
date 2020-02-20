using Autofac;
using Interfaces;
using Shared;
using System.IO;
using System.Reflection;

namespace StarshipPlugin
{
    public class DependencyConfiguration
    {
        public IContainer container;
        private readonly string _pluginsDirectory;
        private ContainerBuilder builder;
        public DependencyConfiguration(string pluginsDirectory)
        {
            _pluginsDirectory = pluginsDirectory;
            builder = new ContainerBuilder();
            RegisterDefaultDependencies();
            RegisterPlugins();
            container = builder.Build();
        }
        
        private void RegisterDefaultDependencies()
        {
            builder.RegisterType<StarDestroyer.StarDestroyer>().As<IShip>();
            builder.RegisterType<ShipState>().As<IShipState>().SingleInstance();
            builder.RegisterType<WeaponFactory>().As<IWeaponFactory>().SingleInstance();
            builder.RegisterType<StarDestroyer.NK7IonCannon>().As<IWeapon>();
            builder.RegisterType<StarDestroyer.Gemon4IonEngine>().As<IEngine>();
        }

        private void RegisterPlugins()
        {
            if (Directory.Exists(_pluginsDirectory))
            {
                var plugins = Directory.GetFiles(_pluginsDirectory, "*.dll");
                foreach (var plugin in plugins)
                {
                    var loadedAssembly = Assembly.LoadFrom(plugin);
                    builder.RegisterAssemblyTypes(loadedAssembly).AsImplementedInterfaces().AsSelf();
                }
            }
        }
    }
}