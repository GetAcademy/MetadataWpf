using System;

namespace WpfApp1.Operations
{
    public class EmitEventOperation<T> : Operation<T>
    {
        public event EventHandler<SuperFormEventArgs<T>> ActionDone;

        public override void Do(T valueObject)
        {
            ActionDone?.Invoke(this, new SuperFormEventArgs<T>()
            {
                ValueObject = valueObject,
                Operation = this
            });
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
