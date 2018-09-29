using System;



namespace ReportGenerator7
{
    public static class PartiallyInvokeExtensionMethods
    {
        public static Func<TInput2, TOutput> PartiallyInvoke<TInput1, TInput2, TOutput>(this Func<(TInput1, TInput2), TOutput> function, TInput1 input1)
        {
            return new PartiallyInvoke1In2<TInput1, TInput2, TOutput>(function, input1).Invoke;
        }

        private class PartiallyInvoke1In2<TInput1, TInput2, TOutput>
        {
            private readonly Func<(TInput1, TInput2), TOutput> function;
            private readonly TInput1 input1;
            public PartiallyInvoke1In2(Func<(TInput1, TInput2), TOutput> function, TInput1 input1)
            {
                this.function = function;
                this.input1 = input1;
            }

            public TOutput Invoke(TInput2 input)
            {
                return function.Invoke((input1, input));
            }
        }

        public static Func<TInput3, TOutput> PartiallyInvoke<TInput1, TInput2, TInput3, TOutput>(this Func<(TInput1, TInput2, TInput3), TOutput> function, TInput2 input2, TInput1 input1)
        {
            return new PartiallyInvoke2And1In3<TInput1, TInput2, TInput3, TOutput>(function, input2, input1).Invoke;
        }

        private class PartiallyInvoke2And1In3<TInput1, TInput2, TInput3, TOutput>
        {
            private readonly Func<(TInput1, TInput2, TInput3), TOutput> function;
            private readonly TInput2 input2;
            private readonly TInput1 input1;
            public PartiallyInvoke2And1In3(Func<(TInput1, TInput2, TInput3), TOutput> function, TInput2 input2, TInput1 input1)
            {
                this.function = function;
                this.input2 = input2;
                this.input1 = input1;
            }

            public TOutput Invoke(TInput3 input)
            {
                return function.Invoke((input1, input2, input));
            }
        }
    }
}