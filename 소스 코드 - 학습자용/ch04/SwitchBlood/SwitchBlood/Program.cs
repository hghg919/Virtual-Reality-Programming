// See https://aka.ms/new-console-template for more information
int a;
char choice;

Console.WriteLine("A형 : A 또는 a ");
Console.WriteLine("B형 : S 또는 s ");
Console.WriteLine("O형 : D 또는 d ");
Console.WriteLine("AB형 : F 또는 f ");
Console.WriteLine("그 이외의 알파벳 : 에러 메시지 출력 ");
Console.WriteLine();

Console.Write("알파벳 입력 : ");
a = Console.Read();
choice = Convert.ToChar(a);

Console.Write(" > 혈액형 성격 : ");

switch(choice)
{
    case 'a':
    case 'A':
        Console.WriteLine("차분한 성격 ");
        break;
    case 's':
    case 'S':
        Console.WriteLine("예술적 성격 ");
        break;
    case 'd':
    case 'D':
        Console.WriteLine("활발한 성격 ");
        break;
    case 'f':
    case 'F':
        Console.WriteLine("창의적 성격 ");
        break;
    default:
        Console.WriteLine();
        Console.WriteLine(" > 유효하지 않은 알파벳입니다. ");
        Console.WriteLine(" > 프로그램 종료! ");
        break;
}