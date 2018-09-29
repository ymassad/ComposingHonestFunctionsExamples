namespace CommonCode.Functions
{
    public static class FunctionExtensionMethods
    {
        public static object HonestlyInject<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object HonestlyInject<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object HonestlyInjectLast<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object HonestlyInjectLast<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object HonestlyInjectOne<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object HonestlyInjectOne<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object function2)
        {
            throw new System.Exception("This method should never be called");
        }

        public static object JoinInputs<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object typeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object JoinInputs<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object typeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object PartiallyInvoke<TInput, TOutput>(
            this IFunction<TInput, TOutput> function,
            params object[] objects)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object PartiallyInvoke<TInput, TOutput>(
            this System.Func<TInput, TOutput> function,
            params object[] objects)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object MakeOutputIndirect<TInput, TOutput>(
            this IFunction<TInput, TOutput> function,
            params object[] objects)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object MakeOutputIndirect<TInput, TOutput>(
            this System.Func<TInput, TOutput> function,
            params object[] objects)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object AddDummyParams<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object typeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object AddDummyParams<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object typeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object TagInputs<TInput, TOutput>(
            this IFunction<TInput, TOutput> function1,
            object inputTypeSpecifier,
            object tagTypeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
        public static object TagInputs<TInput, TOutput>(
            this System.Func<TInput, TOutput> function1,
            object inputTypeSpecifier,
            object tagTypeSpecifier)
        {
            throw new System.Exception("This method should never be called");
        }
    }
}