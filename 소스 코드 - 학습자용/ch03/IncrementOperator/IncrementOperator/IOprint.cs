// See https://aka.ms/new-console-template for more information
int a, b;

a = 10;
b = ++a;
Console.Write("a = 10, b = ++a 일 때 : ");
Console.WriteLine("a = " + a + ", b = " + b);

a = 10;  // 누적값을 배제하기 위한 변수의 데이터값 초기화 선언
b = a++;
Console.Write("a = 10, b = a++ 일 때 : ");
Console.WriteLine("a = " + a + ", b = " + b);

a = 10;  // 누적값을 배제하기 위한 변수의 데이터값 초기화 선언
b = --a;
Console.Write("a = 10, b = --a 일 때 : ");
Console.WriteLine("a = " + a + ", b = " + b);

a = 10;  // 누적값을 배제하기 위한 변수의 데이터값 초기화 선언
b = a--;
Console.Write("a = 10, b = a-- 일 때 : ");
Console.WriteLine("a = " + a + ", b = " + b);