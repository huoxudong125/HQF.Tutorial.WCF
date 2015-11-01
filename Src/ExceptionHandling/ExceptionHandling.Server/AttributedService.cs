using System;
using WcfExtensions;

namespace Server
{
    /// <summary>
    /// This service uses an attribute to apply <see cref="ExceptionMarshallingBehavior"/>
    /// </summary>
    [ExceptionMarshallingBehavior]
    public class AttributedService: Service
    {
    }
}
