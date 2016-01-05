using System;

namespace Umc
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class NotifyRelatedChangeAttribute : Attribute
    {
        // Fields
        private readonly string _name_ = string.Empty;

        // Methods
        public NotifyRelatedChangeAttribute(string name)
        {
            this._name_ = name;
        }

        // Properties
        public string Name
        {
            get
            {
                return this._name_;
            }
        }
    }


}