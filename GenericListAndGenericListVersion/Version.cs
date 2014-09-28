using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Struct |
                AttributeTargets.Class | 
                AttributeTargets.Interface |
                AttributeTargets.Enum |
                AttributeTargets.Method, 
                AllowMultiple = true)]

class VersionAttribute : System.Attribute
{
    public VersionAttribute(double version)
    {
        this.Version = string.Format("{0:#.###}", version);
    }

    public string Version { get; private set; }
}
