// See https://aka.ms/new-console-template for more information
Console.WriteLine(" > 2차원 배열 : arrA[2, 3]");
int[,] arrA = new int[2,3] {{10, 20, 30}, {40, 50, 60 }};

for(int i = 0; i < 2; i++)
{
    for(int j = 0; j < 3; j++)
    {
        Console.Write("{0,5}", arrA[i,j]);
    }
    Console.WriteLine();
}