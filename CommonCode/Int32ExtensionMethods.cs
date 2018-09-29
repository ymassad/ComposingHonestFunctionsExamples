using System.Globalization;

namespace CommonCode
{
    public static class Int32ExtensionMethods
    {
        [AssumeIsPure]
        public static string AsString(this int integer) => integer.ToString(NumberFormatInfo.InvariantInfo);
    }
}