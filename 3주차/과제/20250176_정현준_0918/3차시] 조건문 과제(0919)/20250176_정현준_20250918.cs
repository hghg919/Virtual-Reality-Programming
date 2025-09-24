// 문제1: 영화 등급 판별기
int age;

Console.WriteLine("상영 가능한 영화 등급을 알려줍니다.");
Console.Write("나이를 입력하세요: ");
age = int.Parse(Console.ReadLine());

if (age > 18)
{
    if (age >= 65)
    {
        Console.WriteLine("청소년 관람 불가");
        Console.WriteLine("시니어 할인이 적용됩니다.");
    }
    else
    {
        Console.WriteLine("청소년 관람 불가");
    }
}
else if (age < 18 && age >= 15)
{
    Console.WriteLine("15세 이상 관람가");
}
else
{
    Console.WriteLine("전체관람가");
}


// 문제 2: 큰 수 판단
int a, b, c;

Console.WriteLine("세 개의 정수를 입력받아 가장 큰 수를 출력하는 프로그램입니다.");
Console.Write("첫 번째 정수: ");
a = int.Parse(Console.ReadLine());
Console.Write("두 번째 정수: ");
b = int.Parse(Console.ReadLine());
Console.Write("세 번째 정수: ");
c = int.Parse(Console.ReadLine());

if (a > b && a > c)
{
    Console.WriteLine("가장 큰 수: " + a);
}
else if (b > a && b > c)
{
    Console.WriteLine("가장 큰 수: " + b);
}
else
{
    Console.WriteLine("가장 큰 수: " + c);
}


// 문제 3: 할인율 계산기
int amount;
bool isVip;

Console.Write("구매 금액을 입력하세요: ");
amount = int.Parse(Console.ReadLine());

Console.Write("VIP 회원이신가요? (true/false): ");
isVip = Convert.ToBoolean(Console.ReadLine());

if (amount >= 100000)
{
    if (isVip)
        Console.WriteLine("총 할인율: 15%, 할인된 금액: " + (int)(amount * 0.85) + "원");
    else
        Console.WriteLine("총 할인율: 10%, 할인된 금액: " + (int)(amount * 0.90) + "원");
}
else if (amount >= 50000)
{
    if (isVip)
        Console.WriteLine("총 할인율: 10%, 할인된 금액: " + (int)(amount * 0.90) + "원");
    else
        Console.WriteLine("총 할인율: 5%, 할인된 금액: " + (int)(amount * 0.95) + "원");
}
else
{
    if (isVip)
        Console.WriteLine("총 할인율: 5%, 할인된 금액: " + (int)(amount * 0.95) + "원");
    else
        Console.WriteLine("총 할인율: 0%, 할인된 금액: " + amount + "원");
}


// 문제 4: 윤년 판단
int year;

Console.Write("연도를 입력하세요: ");
year = int.Parse(Console.ReadLine());

if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
    Console.WriteLine("윤년입니다.");
else
    Console.WriteLine("윤년이 아닙니다.");


// 문제 5: 삼각형 판별
int x, y, z;

Console.Write("첫 번째 변의 길이: ");
x = int.Parse(Console.ReadLine());
Console.Write("두 번째 변의 길이: ");
y = int.Parse(Console.ReadLine());
Console.Write("세 번째 변의 길이: ");
z = int.Parse(Console.ReadLine());

if (x + y > z && x + z > y && y + z > x)
    Console.WriteLine("삼각형을 만들 수 있습니다.");
else
    Console.WriteLine("삼각형을 만들 수 없습니다.");


// 문제 6: 비만도 판정
double height, weight;

Console.Write("키(cm)를 입력하세요: ");
height = double.Parse(Console.ReadLine());
Console.Write("체중(kg)을 입력하세요: ");
weight = double.Parse(Console.ReadLine());

double bmi = weight / ((height / 100) * (height / 100));

if (bmi < 18.5)
    Console.WriteLine("저체중");
else if (bmi < 25)
    Console.WriteLine("정상");
else if (bmi < 30)
    Console.WriteLine("과체중");
else
    Console.WriteLine("비만");


// 문제 7: 월별 날짜 수 계산
int month;

Console.Write("월 번호를 입력하세요 (1-12): ");
month = int.Parse(Console.ReadLine());

if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
    Console.WriteLine("31일");
else if (month == 4 || month == 6 || month == 9 || month == 11)
    Console.WriteLine("30일");
else if (month == 2)
    Console.WriteLine("28일 또는 29일");
else
    Console.WriteLine("잘못된 입력입니다.");
