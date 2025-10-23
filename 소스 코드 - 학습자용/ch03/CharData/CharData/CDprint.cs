// See https://aka.ms/new-console-template for more information
char a, b;

a = 'A';  // 아스키코드값 65
b = 'B';  // 아스키코드값 66

Console.Write("알파벳 : " + a);
Console.WriteLine(" → 아스키코드값 : " + (int)a);

Console.Write("알파벳 : " + b);
Console.WriteLine(" → 아스키코드값 : " + (int)b);

Console.WriteLine("덧셈 결과 : " + (a + b)); 
Console.WriteLine("밸셈 결과 : " + (a - b)); 
Console.WriteLine("곱셈 결과 : " + (a * b));
Console.WriteLine("나눗셈 결과 : " + (a / b));