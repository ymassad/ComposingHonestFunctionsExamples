using System;

namespace CommonCode
{
    public static class PureLambda
    {
        public static Func<T> Create<T>(Func<T> func) => func;
    }
}