using Autofac;
using Microsoft.Extensions.Configuration;
using PrivateLessons.Infrastructure.Extensions;
using PrivateLessons.Infrastructure.Settings;
using System.Reflection;

namespace PrivateLessons.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
        }

    }
}
