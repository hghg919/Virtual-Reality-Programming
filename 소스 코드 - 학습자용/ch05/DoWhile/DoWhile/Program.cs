// See https://aka.ms/new-console-template for more information
int count = 1;
string s;

Console.WriteLine("문자열 exit가 입력되면 종료 ");

do
{
    Console.Write(" > " + count + "회 문자열 입력 : ");
    s = Console.ReadLine();
    count++;
}while (s != "exit");

Console.WriteLine(" > 반복 수행 횟수 : " + (count - 1) + "회 ");