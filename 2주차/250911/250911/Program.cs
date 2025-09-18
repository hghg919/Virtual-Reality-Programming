// See https://aka.ms/new-console-template for more information
// Console.Write("문자 출력 : ");
// Console.WriteLine("A");
// Console.Write("문자열 출력 : ");
// Console.WriteLine("반갑습니다.");

// Console.WriteLine("대한민국"[3]);
// Console.WriteLine("대한민국"[0]);
// Console.WriteLine("대한민국"[1]);
// Console.WriteLine("대한민국"[2]);

// Console.WriteLine(!false);
// Console.WriteLine(true || false);
// Console.WriteLine(true && false);

// int a, b, hap, cha, gob, na;
// a = 10;
// b = 20;

// hap = a + b;
// cha = a - b;
// gob = a * b;
// na = a / b;

// Console.WriteLine("a=10, b=20일때, 사칙 연산 결과");
// Console.WriteLine("a + b = " + hap);
// Console.WriteLine("a + b = " + cha);
// Console.WriteLine("a + b = " + gob);
// Console.WriteLine("a + b = " + na);

// int a, b, result;
// a = 10;
// b = 2;

// result = a % b;

// Console.WriteLine("a=10, b=2일때, 나머지 연산 결과");
// Console.WriteLine("a % b = " + result);

// float a, b, result1;
// double result2;
// a = 2;
// b = 3;
// result1 = a / b;
// result2 = a / b;

// Console.WriteLine("float = " + result1);
// Console.WriteLine("double = " + result2);

// char a, b;

// a = 'A';
// b = 'B';

// Console.Write("알파벳 : " + a);
// Console.WriteLine(" -> 아스키코드값 : " + (int)a);

// Console.Write("알파벳 : " + b);
// Console.WriteLine(" -> 아스키코드값 : " + (int)b);

// Console.WriteLine("덧셈결과 : " + (a + b));
// Console.WriteLine("뺄셈결과 : " + (a - b));
// Console.WriteLine("곱셉결과 : " + (a * b));
// Console.WriteLine("나눗셈결과 : " + (a / b));

// string a, b, c;

// a = "Space Zone";
// b = a.ToUpper();
// c = a.ToLower();

// Console.WriteLine("주어진 문자열 : " + a);
// Console.WriteLine(" > 소문자로 변환 : " + c);
// Console.WriteLine(" > 대문자로 변환 : " + b);

// Console.WriteLine("short 형식\t : " + sizeof(short) + " 바이트");
// Console.WriteLine("int 형식\t : " + sizeof(int) + " 바이트");
// Console.WriteLine("long 형식\t : " + sizeof(long) + " 바이트");
// Console.WriteLine("float 형식\t : " + sizeof(float) + " 바이트");
// Console.WriteLine("double 형식\t : " + sizeof(double) + " 바이트");
// Console.WriteLine("char 형식\t : " + sizeof(char) + " 바이트");
// Console.WriteLine("bool 형식\t : " + sizeof(bool) + " 바이트");

// int a = 123;
// long b = 1234567890123456;

// Console.WriteLine(a.GetType());
// Console.WriteLine(b.GetType());


// int a, b;
// float result;

// a = 5;
// b = 2;

// result = a / b;
// Console.WriteLine("강제 자료형 변환 전 : " + result);

// result = (float)a /b;
// Console.WriteLine("강제 자료형 변환 전 : " + result);

// int count = 100;

// Console.WriteLine("주어진 데이터 값이 count = 100 일 때");
// count += 5;
// Console.WriteLine("count += 5 : " + count);

// count -= 3;
// Console.WriteLine("count -= 3 : " + count);

// count *= 2;
// Console.WriteLine("count *= 2 : " + count);

// count /= 10;
// Console.WriteLine("count /= 10 : " + count);


// int a, b;

// a = 10;
// b = ++a;
// Console.Write("a = 10, b = ++a 일때 : ");
// Console.WriteLine("a = " + a + ", b = " + b);

// a = 10;
// b = a++;
// Console.Write("a = 10, b = a++ 일때 : ");
// Console.WriteLine("a = " + a + ", b = " + b);

// a = 10;
// b = --a;
// Console.Write("a = 10, b = --a 일때 : ");
// Console.WriteLine("a = " + a + ", b = " + b);

// a = 10;
// b = a--;
// Console.Write("a = 10, b = a-- 일때 : ");
// Console.WriteLine("a = " + a + ", b = " + b);


// int a;

// Console.Write("1. 정수 입력 : ");
// a = int.Parse(Console.ReadLine());

// Console.WriteLine("2. 입력한 정수값 출력 : " + a);

// float a;

// Console.Write("1. 실수 입력 : ");
// a = float.Parse(Console.ReadLine());

// Console.WriteLine("2. 입력한 실수값 출력 : " + a);

// int c;
// char cparse;

// Console.Write("1. 문자 입력 : ");
// c = Console.Read();

// Console.WriteLine("2. 문자의 아스키코드값이 출력 : " + c);
// cparse = Convert.ToChar(c);

// Console.WriteLine("3. 문자 변환 메서드를 적용하여 출력 : " + cparse);

//string s;

//Console.Write("1. 문자열 입력 : ");
//s = Console.ReadLine();

//Console.WriteLine("2. 입력한 문자열 출력 : " + s);

// Console.Write("정수입력 : ");
// string input = Console.ReadLine();

// try
// {
//     int a = int.Parse(input);
//     Console.WriteLine("입력값 : " + input);
// }
// catch (Exception exception)
// { Console.WriteLine("\n예외 상황 발생!!");
//   Console.WriteLine("정수값이 아닙니다.");
// }
// finally
// {
//     Console.WriteLine("\n프로그램 종료!");
// }

