using System;

namespace Sushi.ObjectDiffer
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property, AllowMultiple=false)]
    public class CloneObjectPlaceholderAttribute : Attribute
    {
    }
}
