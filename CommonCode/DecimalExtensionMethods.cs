using System.Globalization;

namespace CommonCode
{
    public static class DecimalExtensionMethods
    {
        [AssumeIsPure]
        public static string AsString(this decimal dec) => dec.ToString(NumberFormatInfo.InvariantInfo);
    }
}