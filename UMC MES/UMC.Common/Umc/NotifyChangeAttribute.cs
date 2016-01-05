using System;

namespace Umc
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class NotifyChangeAttribute : Attribute
    {
    }

}