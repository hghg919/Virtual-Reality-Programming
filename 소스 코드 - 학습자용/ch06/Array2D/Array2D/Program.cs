// See https://aka.ms/new-console-template for more information
int[,] b = new int[3, 2] { { 1, 3 }, { 5, 7 }, { 9, 11 } };
foreach(int cnt in b)
{
    Console.Write(cnt + " ");
}