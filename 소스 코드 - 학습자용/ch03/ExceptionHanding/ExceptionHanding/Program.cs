// See https://aka.ms/new-console-template for more information

Console.Write("정수 입력 : ");
string input = Console.ReadLine();

try
{
    int a = int.Parse(input);
    Console.WriteLine("입력값 : " + input);
}
catch (Exception exception)
{
    Console.WriteLine("\n예외 상황 발생!!");
    Console.WriteLine("정수값을 입력해야 합니다.");
}
finally
{
    Console.WriteLine("\n프로그램을 종료합니다.");
}