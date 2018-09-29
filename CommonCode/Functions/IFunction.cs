public interface IFunction<TInput, TOutput>
{
    TOutput Invoke(TInput input);
}