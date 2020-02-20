using System;
using Autofac;
using Interfaces;

namespace StarshipPlugin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dependencyConfig = new DependencyConfiguration("Plugins");
            using (var lifetimeScope = dependencyConfig.container.BeginLifetimeScope())
            {
                InputParser inputParser = new InputParser(lifetimeScope.Resolve<IShip>());
                Console.WriteLine("Welcome to the starship controller application. Please choose an option...");
                while (true)
                {
                    var rawInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(rawInput))
                        inputParser.ParseInput(rawInput.Split(' '));
                }
            }
        }
    }
}
