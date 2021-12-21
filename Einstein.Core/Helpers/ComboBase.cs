namespace Einstein.Core.Helpers
{
    public record ComboBase<T>
    {
        public T Value { get; init; } = default!;
        public string Text { get; init; } = default!;
    }
}
