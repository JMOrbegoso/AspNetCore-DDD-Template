namespace DDD_Template.Domain.Base
{
    public abstract record ValueObject<T>
    {
        public T Value { get; }

        protected ValueObject(T value)
        {
            this.Validate(value);

            this.Value = value;
        }

        protected abstract void Validate(T value);
    }
}