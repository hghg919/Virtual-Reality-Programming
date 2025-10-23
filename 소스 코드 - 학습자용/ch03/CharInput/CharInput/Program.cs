// See https://aka.ms/new-console-template for more information
int c;
char cparse;

Console.Write("1. 문자 입력 : ");
c = Console.Read();

Console.WriteLine("2. 문자의 아스키코드값이 출력 : " + c);
cparse = Convert.ToChar(c);

Console.WriteLine("3. 문자 변환 메서드를 적용하여 출력 : " + cparse);