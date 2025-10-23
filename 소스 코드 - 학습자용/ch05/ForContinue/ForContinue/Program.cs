// See https://aka.ms/new-console-template for more information
int count;

Console.WriteLine("홀수만 출력하는 프로그램 ");
Console.Write(" > ");

for (count = 0; count <= 10; count++)
{
    if(count % 2 != 0)
    {
        continue;
    }
    Console.Write(count + " ");
}