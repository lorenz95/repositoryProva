namespace WpfApp0.StartUpHelpers
{
    public interface IAbstractFactory<T>
    {
        public T Create();
    }
}