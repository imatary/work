using System;

namespace UMC.Runtime
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class ModuleLoaderAttribute : Attribute
    {
        // Fields
        private readonly Type _type_;

        // Methods
        public ModuleLoaderAttribute(Type type)
        {
            this._type_ = type;
        }

        // Properties
        public Type Type
        {
            get
            {
                return this._type_;
            }
        }

    }
}