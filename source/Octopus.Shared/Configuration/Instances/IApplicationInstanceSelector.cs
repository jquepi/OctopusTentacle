using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Octopus.Shared.Configuration.Instances
{
    public interface IApplicationInstanceSelector
    {
        ApplicationName ApplicationName { get; }
        
        LoadedApplicationInstance GetCurrentInstance();

        IList<ApplicationInstanceRecord> ListInstances();
        
        bool TryGetCurrentInstance([NotNullWhen(true)] out LoadedApplicationInstance? instance);
    }
}