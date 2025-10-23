// See https://aka.ms/new-console-template for more information
int a;
char choice;

Console.WriteLine("법학과 : A 또는 a ");
Console.WriteLine("행정학과 : S 또는 s ");
Console.WriteLine("소비자학과 : D 또는 d ");
Console.WriteLine("데이터사이언스학과 : F 또는 f ");
Console.WriteLine("그 이외의 알파벳 : 에러 메시지 출력 ");
Console.WriteLine();

Console.Write("알파벳 입력 : ");
a = Console.Read();
choice = Convert.ToChar(a);

Console.Write(" > 선택 학과 : ");

if (choice == 'A' || choice == 'a')
{
    Console.WriteLine("법학과 ");
}
else if(choice == 'S' || choice == 's')
{
    Console.WriteLine("행정학과 ");
}
else if (choice == 'D' || choice == 'd')
{
    Console.WriteLine("소비자학과 ");
}
else if (choice == 'F' || choice == 'f')
{
    Console.WriteLine("데이터사이언스학과 ");
}
else
{
    Console.WriteLine();
    Console.WriteLine(" > 유효하지 않은 알파벳입니다. ");
    Console.WriteLine(" > 프로그램 종료! ");
}