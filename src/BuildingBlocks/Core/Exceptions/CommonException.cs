using System.Globalization;

namespace Core.Exceptions
{
    public class CommonException : Exception
    {
        public const string ErrorCode = "error_code";
        public CommonException()
        {

        }
        public CommonException(string message) : base(message)
        {
        }

        public CommonException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,
            message, args))
        {
        }

        public CommonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CommonException(string message, int code) : base(message)
        {
            Data.Add(ErrorCode, code);
        }
    }
}
