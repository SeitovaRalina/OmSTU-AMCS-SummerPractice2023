namespace spacebattleservice;
public class Pool<T> where T : new()
{
    Stack<T> poolslot = new Stack<T>();
    private int bufferSize;
    private int maxCapacity;
    public Pool(int _bufferSize, int _maxCapacity)
    {
        bufferSize = _bufferSize;
        maxCapacity = _maxCapacity;
        if (_bufferSize > _maxCapacity)
            throw new IndexOutOfRangeException();
        for (int i = 0; i < bufferSize; i++)
        {
            poolslot.Push(new T());
        }
    }

    public T Take()
    { 
        bufferSize--;
        return poolslot.Pop();
    }

    public void Release(T objct)
    {
        if (poolslot.Count > maxCapacity)
            throw new InvalidOperationException("Вместимость пула достигла максимального значения!");
        poolslot.Push(objct);
    }
}