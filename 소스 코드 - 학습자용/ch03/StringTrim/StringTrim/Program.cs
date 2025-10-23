// See https://aka.ms/new-console-template for more information
string a, b, c, d;

a = "  welcome     ";
b = a.Trim();           // 모든 공백 제거
c = a.TrimStart();      // 앞의 공백만 제거
d = a.TrimEnd();        // 뒤의 공백만 제거

Console.WriteLine("주어진 문자열 : " + "|" + a + "|");
Console.WriteLine(" > 공백 모두 제거 : " + "|" + b + "|");
Console.WriteLine(" > 앞의 공백만 제거 : " + "|" + c + "|");
Console.WriteLine(" > 뒤의 공백만 제거 : " + "|" + d + "|");