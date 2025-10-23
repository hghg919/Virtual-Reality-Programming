// See https://aka.ms/new-console-template for more information
int c;
char cparse;

Console.Write("문자 입력: ");
c = Console.Read();
cparse = Convert.ToChar(c);

if (cparse >= 'A' && cparse <= 'Z')
{
    Console.WriteLine(" > 입력한 알파벳 : " + cparse);
    Console.WriteLine(" > 판별 결과 : 대문자 ");
}
else
{
    Console.WriteLine(" > 입력한 알파벳 : " + cparse);
    Console.WriteLine(" > 판별 결과 : 소문자 ");
}