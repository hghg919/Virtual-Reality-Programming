// See https://aka.ms/new-console-template for more information
int a, choice;

Console.Write("정수 입력 : ");
a = int.Parse(Console.ReadLine());
choice = a % 2;

if (choice == 0)
{
    Console.WriteLine("짝수");
}
else
{
    Console.WriteLine("홀수");
}