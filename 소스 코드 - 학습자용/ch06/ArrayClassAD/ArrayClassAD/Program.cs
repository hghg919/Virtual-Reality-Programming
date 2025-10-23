// See https://aka.ms/new-console-template for more information
int[] a = { 10, 50, 30 };
Array.Sort(a);
Console.Write("> 오름차순 정렬 : ");

foreach (int cnt in a)
{
    Console.Write(cnt + " ");
}

Console.WriteLine();
Array.Reverse(a);
Console.Write("> 내림차순 정렬 : ");

foreach (int cnt in a)
{
    Console.Write(cnt + " ");
}