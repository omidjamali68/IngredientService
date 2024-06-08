using System.Reflection;

namespace Ingredient.Api.Configs
{
    public class ConfigurationHelper
    {
        public static void Init(string[] args)
        {
            var baseDirectory = Directory.GetCurrentDirectory();
            var appSettings = ReadAppSettings(args, baseDirectory);
            var environment = appSettings.GetValue("environment", "Development");

            var configs =
                GetConfiguratorsFromAssembly(typeof(Program).Assembly, args, appSettings, baseDirectory);
        }

        private static IConfiguration ReadAppSettings(string[] args, string baseDirectory)
        {
            return new ConfigurationBuilder()
                .SetBasePath(baseDirectory)
                .AddJsonFile(Path.Combine(baseDirectory, "..", "config", "appsettings.json"), true, true)
                .AddJsonFile(Path.Combine(baseDirectory, "appsettings.json"), true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        private static MyConfiguration[] GetConfiguratorsFromAssembly(
                    Assembly assembly,
                    string[] args,
                    IConfiguration appSettings,
                    string baseDirectory)
        {
            void SetPropertyValue<T>(object obj, string name, object value)
            {
                typeof(T).GetProperty(name)?.SetValue(obj, value);
            }

            return assembly.GetTypes()
                .Where(_ => _.IsAbstract == false)
                .Where(typeof(MyConfiguration).IsAssignableFrom)
                .Select(configuratorType => new
                {
                    Type = configuratorType,
                    Config = configuratorType.GetCustomAttribute<ConfigurationAttribute>()
                })
                .Where(_ => _.Config?.Disabled != true)
                .OrderBy(_ => _.Config?.Order ?? 0)
                .Select(_ =>
                {
                    var configurator = Activator.CreateInstance(_.Type) as MyConfiguration;
                    SetPropertyValue<MyConfiguration>(configurator, nameof(MyConfiguration.CommandLineArgs), args);
                    SetPropertyValue<MyConfiguration>(configurator, nameof(MyConfiguration.BaseDirectory), baseDirectory);
                    SetPropertyValue<MyConfiguration>(configurator, nameof(MyConfiguration.AppSettings), appSettings);
                    return configurator;
                })
                .ToArray();
        }
    }
}
