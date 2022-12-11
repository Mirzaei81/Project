// See https://aka.ms/new-console-template for more information
public class program
{
    static void Main()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        recursive("test", 0, 8);
        watch.Stop();
        Console.WriteLine($"Excuation time : {watch.ElapsedMilliseconds} ms");
    }

    public static void print(string s,int l,int m,int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
        Console.Write(s);
        Console.Write(" Length 1 : "+n1);
        Console.Write(" Length 2 : "+n2);
        Console.Write(" first : " + l);
        Console.Write(" middle : "+m);
        Console.Write(" Last : " + r);

        Console.Write("\n");
    }

    public static void recursive(string s,int l,int r)
    {
        if (l < r)
        {

            int m = l + (r - l) / 2;
            recursive("hello", l, m);
            recursive("world", m + 1, r);
            print(s,l,m,r);
       }
       
    }

}
