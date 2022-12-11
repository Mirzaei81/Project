namespace mergesort;
public class mergesort<T>
{
	private readonly T[] _array;
	public  mergesort(T[] array,int count,int size)
	{
		 _array = array;
	}


	public T[,] split(T[,] arrays,int length,int step)
	{
		if(length==1)
			return arrays;
		T[,] Temp = new T[step,length];
		for(int i=0;i<=step;i++)
		{
			Temp[step,i] = Temp[step,length/2];
		}
		return split(Temp,length/2,step);
	}

}
