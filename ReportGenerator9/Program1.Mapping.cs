using System;



namespace ReportGenerator9
{
    public static class HonestlyInjectExtensionMethods
    {
        public static Func<(TInput1, TInput2, TNewInput1), TOutput> HonestlyInject<TInput1, TInput2, TNewInput1, TFuncInput1, TFuncOutput, TOutput>(this Func<(TInput1, Func<TFuncInput1, TFuncOutput>, TInput2), TOutput> f1, Func<(TNewInput1, TFuncInput1), TFuncOutput> f2)
        {
            return new HonestlyInject3FF1I1F2SF_N_1<TInput1, TInput2, TNewInput1, TFuncInput1, TFuncOutput, TOutput>(f1, f2).Invoke;
        }

        private sealed class HonestlyInject3FF1I1F2SF_N_1<TInput1, TInput2, TNewInput1, TFuncInput1, TFuncOutput, TOutput>
        {
            private sealed class FuncImpl
            {
                private readonly Func<(TNewInput1, TFuncInput1), TFuncOutput> f2;
                private readonly TNewInput1 newInput1;
                public FuncImpl(Func<(TNewInput1, TFuncInput1), TFuncOutput> f2, TNewInput1 newInput1)
                {
                    this.f2 = f2;
                    this.newInput1 = newInput1;
                }

                public TFuncOutput Invoke(TFuncInput1 input)
                {
                    return f2.Invoke((newInput1, input));
                }
            }

            private readonly Func<(TInput1, Func<TFuncInput1, TFuncOutput>, TInput2), TOutput> f1;
            private readonly Func<(TNewInput1, TFuncInput1), TFuncOutput> f2;
            public HonestlyInject3FF1I1F2SF_N_1(Func<(TInput1, Func<TFuncInput1, TFuncOutput>, TInput2), TOutput> f1, Func<(TNewInput1, TFuncInput1), TFuncOutput> f2)
            {
                this.f1 = f1;
                this.f2 = f2;
            }

            public TOutput Invoke((TInput1, TInput2, TNewInput1)input)
            {
                return f1.Invoke((input.Item1, new FuncImpl(f2, input.Item3).Invoke, input.Item2));
            }
        }

        public static Func<(TInput1, TNewInput1, TNewInput2), TOutput> HonestlyInject<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>(this Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1, Func<(TNewInput1, TFuncInput1, TNewInput2), TFuncOutput> f2)
        {
            return new HonestlyInject2FF0I1F3SF_N_1_N<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>(f1, f2).Invoke;
        }

        private sealed class HonestlyInject2FF0I1F3SF_N_1_N<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>
        {
            private sealed class FuncImpl
            {
                private readonly Func<(TNewInput1, TFuncInput1, TNewInput2), TFuncOutput> f2;
                private readonly TNewInput1 newInput1;
                private readonly TNewInput2 newInput2;
                public FuncImpl(Func<(TNewInput1, TFuncInput1, TNewInput2), TFuncOutput> f2, TNewInput1 newInput1, TNewInput2 newInput2)
                {
                    this.f2 = f2;
                    this.newInput1 = newInput1;
                    this.newInput2 = newInput2;
                }

                public TFuncOutput Invoke(TFuncInput1 input)
                {
                    return f2.Invoke((newInput1, input, newInput2));
                }
            }

            private readonly Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1;
            private readonly Func<(TNewInput1, TFuncInput1, TNewInput2), TFuncOutput> f2;
            public HonestlyInject2FF0I1F3SF_N_1_N(Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1, Func<(TNewInput1, TFuncInput1, TNewInput2), TFuncOutput> f2)
            {
                this.f1 = f1;
                this.f2 = f2;
            }

            public TOutput Invoke((TInput1, TNewInput1, TNewInput2)input)
            {
                return f1.Invoke((new FuncImpl(f2, input.Item2, input.Item3).Invoke, input.Item1));
            }
        }

        public static Func<(TInput1, TNewInput1, TNewInput2), TOutput> HonestlyInject<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>(this Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1, Func<(TFuncInput1, TNewInput1, TNewInput2), TFuncOutput> f2)
        {
            return new HonestlyInject2FF0I1F3SF_1_N_N<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>(f1, f2).Invoke;
        }

        private sealed class HonestlyInject2FF0I1F3SF_1_N_N<TInput1, TNewInput1, TNewInput2, TFuncInput1, TFuncOutput, TOutput>
        {
            private sealed class FuncImpl
            {
                private readonly Func<(TFuncInput1, TNewInput1, TNewInput2), TFuncOutput> f2;
                private readonly TNewInput1 newInput1;
                private readonly TNewInput2 newInput2;
                public FuncImpl(Func<(TFuncInput1, TNewInput1, TNewInput2), TFuncOutput> f2, TNewInput1 newInput1, TNewInput2 newInput2)
                {
                    this.f2 = f2;
                    this.newInput1 = newInput1;
                    this.newInput2 = newInput2;
                }

                public TFuncOutput Invoke(TFuncInput1 input)
                {
                    return f2.Invoke((input, newInput1, newInput2));
                }
            }

            private readonly Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1;
            private readonly Func<(TFuncInput1, TNewInput1, TNewInput2), TFuncOutput> f2;
            public HonestlyInject2FF0I1F3SF_1_N_N(Func<(Func<TFuncInput1, TFuncOutput>, TInput1), TOutput> f1, Func<(TFuncInput1, TNewInput1, TNewInput2), TFuncOutput> f2)
            {
                this.f1 = f1;
                this.f2 = f2;
            }

            public TOutput Invoke((TInput1, TNewInput1, TNewInput2)input)
            {
                return f1.Invoke((new FuncImpl(f2, input.Item2, input.Item3).Invoke, input.Item1));
            }
        }
    }
}

namespace ReportGenerator9
{
    public static class PartiallyInvokeExtensionMethods
    {
        public static Func<TInput1, TOutput> PartiallyInvoke<TInput1, TInput2, TInput3, TOutput>(this Func<(TInput1, TInput2, TInput3), TOutput> function, TInput3 input3, TInput2 input2)
        {
            return new PartiallyInvoke3And2In3<TInput1, TInput2, TInput3, TOutput>(function, input3, input2).Invoke;
        }

        private class PartiallyInvoke3And2In3<TInput1, TInput2, TInput3, TOutput>
        {
            private readonly Func<(TInput1, TInput2, TInput3), TOutput> function;
            private readonly TInput3 input3;
            private readonly TInput2 input2;
            public PartiallyInvoke3And2In3(Func<(TInput1, TInput2, TInput3), TOutput> function, TInput3 input3, TInput2 input2)
            {
                this.function = function;
                this.input3 = input3;
                this.input2 = input2;
            }

            public TOutput Invoke(TInput1 input)
            {
                return function.Invoke((input, input2, input3));
            }
        }
    }
}