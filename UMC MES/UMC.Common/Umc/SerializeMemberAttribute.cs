using System;

namespace Umc
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class SerializeMemberAttribute : Attribute
    {
        // Fields
        private readonly string _name_ = string.Empty;

        // Methods
        public SerializeMemberAttribute(string name)
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