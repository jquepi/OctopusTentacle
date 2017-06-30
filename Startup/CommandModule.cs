using System;
using Autofac;

namespace Octopus.Shared.Startup
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterCommand<HelpCommand>("help", "Prints this help text", "h", "?");
            builder.RegisterType<CommandLocator>().As<ICommandLocator>().SingleInstance();
#if WINDOWS_SERVICE
            builder.RegisterType<ServiceInstaller>().As<IServiceInstaller>();
#endif
        }
    }
}