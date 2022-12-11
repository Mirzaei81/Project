using System.Text;
namespace ArrayList;

class Program
{
    static void Main(string[] args)
    {
        ArrayListObj<int> arr = new();
        for(int i=0;i<10;i++)
        {
            arr.add(i);
        }
        Console.WriteLine(arr.ToString());
        arr.add(3);
        arr.remove(4);
        Console.WriteLine(arr.ToString());
        arr.insert(4,22);
        Console.WriteLine(arr.ToString());

    }
}

public class ArrayListObj<T>
{
    private T[] _array;
    public int size=10;
    public int count = 0;

    public ArrayListObj()
    {
        _array = new T[size];
    }

    public void add(T newint)
    {
        if(count<size)
        {
            _array[count] = newint;
            ++count;
        }
        else
        {
            Array.Resize<T>(ref _array,size*=2);
            _array[count] = newint;
            ++count;
        }
        

    }

    private void shiftright(int idx)
    {
        for(int i=count+1;i>idx;i--)
        {
            _array[i] = _array[i-1];
        }
    }

    private void shiftleft(int idx)
    {
        for(;idx+1<this.count;idx++)
        {
            _array[idx] = _array[idx+1];
        }
    }
    public void insert(int idx,T item)
    {
        if(count%10==0)Array.Resize<T>(ref _array,size*=2);
        this.shiftright(idx);
        _array[idx] = item;
        ++this.count;
    }

    public void remove(int idx)
    {
        this.shiftleft(idx);
        if(count%10==1)Array.Resize<T>(ref _array,size/=2);
        --this.count;
    }

    public void clean()
    {
        this._array = new T[size];
    }
//    public T IndexOf(T item)
//    {
//        return this;
//    }



    public override string ToString()
    {
        var builder = new StringBuilder();
        Array.ForEach(_array, x=>builder.Append(x + " "));
        return builder.ToString();
    }

}
