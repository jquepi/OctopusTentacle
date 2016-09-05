using System;
using System.Threading;
using Octopus.Server.Extensibility.Time;

namespace Octopus.Shared.Time
{
    public class Sleep : ISleep
    {
        public void For(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}