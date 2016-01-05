using System;

namespace Umc
{
    [Serializable]
    public sealed class UnexpectedException : Exception
    {
        // Fields
        private readonly object[] _args_;

        // Methods
        public UnexpectedException(string message, params object[] args)
            : base(message)
        {
            this._args_ = args ?? new object[0];
        }

        // Properties
        public object[] Arguments
        {
            get
            {
                return this._args_;
            }
        }
    }


}