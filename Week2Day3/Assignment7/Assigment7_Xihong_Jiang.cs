//1
using System.Reflection;

public class MyStack<T> 
{
    private List<T> stack;

    public MyStack() 
    {
        stack = new List<T>();
    }

    public int Count() { return stack.Count; } 
    public T Pop() 
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }
        else 
        {
            T top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return top;
        }
    }

    public void Push(T item)
    {
        stack.Add(item);
    }
}



//2
public class MyList<T> 
{
    private T[] list;
    private int pointer;

    public MyList()
    {
        list = new T[10];
        pointer = 0;
    }

    public int Count() { return pointer;}

    public void Add(T element) 
    {
        if (pointer == list.Length) { Array.Resize(ref list, pointer + 10); }
        list[pointer] = element;
        pointer++;
    }

    public T Remove(int index) 
    {
        if (index < 0 || index >= pointer)
        {
            throw new IndexOutOfRangeException();
        }
        else 
        {
            T element = list[index];
            pointer--;
            for (int i = index; i < pointer; i++) 
            {
                list[i] = list[i + 1];
            }
            Array.Clear(list, pointer, pointer);
            return element;
        }
        
    }

    public bool Contains(T element) 
    {
        if (pointer == 0) 
        {
            return false;
        }
        for (int i = 0; i < pointer; i++) 
        {
            if (list[i].Equals(element)) 
            {
                return true;
            }
        }
        return false;
    }

    public void Clear() 
    {        
        Array.Clear(list, 0, pointer);
        pointer = 0;
    }

    public void InsertAt(T element, int index) 
    {
        if (index < 0 || index >= pointer)
        {
            throw new IndexOutOfRangeException();
        }
        
        if (pointer == list.Length) { Array.Resize(ref list, pointer + 10); }
        
        for (int i = pointer; i > index; i--)
        {
            list[i] = list[i - 1];
        }
        list[index] = element;
        pointer--;
    }

    public void DeleteAt(int index) 
    {
        Remove(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= pointer)
        {
            throw new IndexOutOfRangeException();
        }

        return list[index];
    }
}



//3
public abstract class Entity 
{
    public int Id { get; set; }
}

public interface IRepository<T> where T : Entity 
{
    abstract void Add(T item);
    abstract void Remove(T item);
    abstract void Save();
    abstract IEnumerable<T> GetAll();
    abstract T GetById(int id);
}

public class GenericRepository<T> : IRepository<T> where T : Entity 
{
    private List<T> list;

    public GenericRepository() 
    {
        list = new List<T>();
    }

    public void Add(T item) 
    {
        list.Add(item);
    }

    public void Remove(T item)
    {
        list.Remove(item);
    }

    public void Save() 
    {
        //context.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return list.AsEnumerable<T>();
    }

    public T GetById(int id) 
    {
        return list.Where(x => x.Id == id).FirstOrDefault();
    }
}