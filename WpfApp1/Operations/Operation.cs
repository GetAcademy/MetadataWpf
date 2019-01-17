namespace WpfApp1.Operations
{
    public abstract class Operation<T>
    {
        public string Name;
        public abstract void Do(T valueObject);
    }
}
