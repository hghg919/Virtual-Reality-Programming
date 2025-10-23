// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(" > 5개로 구성된 피라미드 ");
        DrawPyramid(5);

        Console.WriteLine(" > 8개로 구성된 피라미드 ");
        DrawPyramid(8);
    }

    static void DrawPyramid(int n)
    {
        for(int count = 1; count <= n; count++) 
        {
            for(int s = 1; s <= n - count; s++)
                Console.Write(" ");
                for (int star = 1; star <= 2 * count - 1; star++)
                    Console.Write("*");
                Console.WriteLine();
        }
        Console.WriteLine();
    }
}