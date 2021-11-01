using System;
using System.IO;
using Xunit;

namespace NuGet.Test
{
    public static class ExceptionAssert
    {
        public static void Throws<TException>(Action act) where TException : Exception
        {
            Throws<TException>(act, ex => { });
        }

        public static void Throws<TException>(Action act, Action<TException> condition) where TException : Exception
        {
            TException ex = Assert.ThrowsAny<TException>(act);
            condition(ex);
        }

        public static void Throws<TException>(Action action, string expectedMessage) where TException : Exception
        {
            Throws<TException>(action, ex => Assert.Equal(expectedMessage, ex.Message));
        }

        public static void ThrowsArgNull(Action act, string paramName)
        {
            Throws<ArgumentNullException>(act, ex => Assert.Equal(paramName, ex.ParamName));
        }

        public static void ThrowsArgNullOrEmpty(Action act, string paramName)
        {
            ThrowsArgumentException<ArgumentException>(act, paramName, CommonResources.Argument_Cannot_Be_Null_Or_Empty);
        }

        public static void ThrowsArgOutOfRange(Action act, string paramName, object minimum, object maximum, bool equalAllowed)
        {
            ThrowsArgumentException<ArgumentOutOfRangeException>(act, paramName, BuildOutOfRangeMessage(paramName, minimum, maximum, equalAllowed));
        }

        private static string BuildOutOfRangeMessage(string paramName, object minimum, object maximum, bool equalAllowed)
        {
            if (minimum == null)
            {
                return String.Format(equalAllowed ? CommonResources.Argument_Must_Be_LessThanOrEqualTo : CommonResources.Argument_Must_Be_LessThan, maximum);
            }
            else if (maximum == null)
            {
                return String.Format(equalAllowed ? CommonResources.Argument_Must_Be_GreaterThanOrEqualTo : CommonResources.Argument_Must_Be_GreaterThan, minimum);
            }
            else
            {
                return String.Format(CommonResources.Argument_Must_Be_Between, minimum, maximum);
            }
        }

        public static void ThrowsArgumentException(Action act, string message)
        {
            ThrowsArgumentException<ArgumentException>(act, message);
        }

        public static void ThrowsArgumentException<TArgException>(Action act, string message) where TArgException : ArgumentException
        {
            Throws<TArgException>(act, ex => Assert.Equal(message, ex.Message));
        }

        public static void ThrowsArgumentException(Action act, string paramName, string message)
        {
            ThrowsArgumentException<ArgumentException>(act, paramName, message);
        }

        public static void ThrowsArgumentException<TArgException>(Action act, string paramName, string message) where TArgException : ArgumentException
        {
            Throws<TArgException>(act, $"{message} (Parameter '{paramName}')");
        }
    }
}
