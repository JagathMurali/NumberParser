using System;
using System.Collections.Generic;

namespace NumberParser.Dependency
{
    public interface IDependencyScope : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}
