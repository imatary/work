namespace Umc
{
    public static class Guard
    {
        // Methods
        public static void Argument(bool condition, string message)
        {
            if (condition)
            {
                throw Error.Argument(message);
            }
        }

        public static void ArgumentNull(bool condition, string paramName)
        {
            if (condition)
            {
                throw Error.ArgumentNull(paramName);
            }
        }

        public static void ArgumentNull(object obj, string objName)
        {
            if (obj == null)
            {
                throw Error.ArgumentNull(objName);
            }
        }

        public static void ArgumentOutOfRange(bool condition, string paramName)
        {
            if (condition)
            {
                throw Error.ArgumentOutOfRange(paramName);
            }
        }

        public static void InvalidOperation(bool condition, string message)
        {
            if (condition)
            {
                throw Error.InvalidOperation(message);
            }
        }

        public static void Unexpected(bool condition, string message)
        {
            if (condition)
            {
                throw Error.Unexpected(message, new object[0]);
            }
        }

        public static void Unexpected(bool condition, string message, object arg)
        {
            if (condition)
            {
                throw Error.Unexpected(message, arg);
            }
        }

        public static void Unexpected(bool condition, string message, params object[] args)
        {
            if (condition)
            {
                throw Error.Unexpected(message, args);
            }
        }

        public static void Unexpected(bool condition, string message, object arg1, object arg2)
        {
            if (condition)
            {
                throw Error.Unexpected(message, arg1, arg2);
            }
        }
    }

}