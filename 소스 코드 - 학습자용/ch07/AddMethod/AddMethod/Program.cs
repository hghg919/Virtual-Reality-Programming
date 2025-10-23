// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.Write(" >   1~10 까지 누적 합계 : ");
        Console.WriteLine("{0, 5}", AddMethod(1, 10));

        Console.Write(" > 51~100 까지 누적 합계 : ");
        Console.WriteLine("{0, 5}", AddMethod(51, 100));
    }

    private static int AddMethod(int n, int m)
    {
        int sum = 0;
        for(int count = n; count <= m; count++)
        {
            sum += count;      // sum = sum + count
        }
        return sum;
    }
}