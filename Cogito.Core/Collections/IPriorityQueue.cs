namespace Cogito.Collections
{

    public interface IPriorityQueue<T> :
        IQueue<T>
    {

        void Update(T value);

    }

}
