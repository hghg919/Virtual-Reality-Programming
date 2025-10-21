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

Console.WriteLine("윤년인지 아닌지 판별하는 프로그램입니다.");
Console.Write("연도를 입력하세요: ");

year = int.Parse(Console.ReadLine());

if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
    Console.WriteLine("윤년입니다.");
else
    Console.WriteLine("윤년이 아닙니다.");


// 문제 5: 삼각형 판별
int x, y, z;

Console.WriteLine("삼각형을 만들 수 있는지 판별하는 프로그램입니다.");
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

Console.WriteLine("BMI를 계산하고 비만도를 판정하는 프로그램입니다.");
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


// 4주차

// See https://aka.ms/new-console-template for more information

// 문제 1: While 루프 – 홀수 항목의 총 가격

int A, B;
int sum = 0;

Console.Write("A값을 입력하시오 : ");
A = int.Parse(Console.ReadLine());

while (true)
{
    Console.Write("B값을 입력하시오(B는 A보다 크거나 같아야합니다.) : ");
    B = int.Parse(Console.ReadLine());
    if (B >= A)
    {
        break;
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다. B는 A보다 크거나 같아야 합니다.");
    }
}

Console.WriteLine("입력 값 : " + A + " " + B);

int currentNumber = A;

while (currentNumber <= B)
{
    if (currentNumber % 2 != 0)
    {
        sum += currentNumber;
    }
    currentNumber++;
}

Console.WriteLine("결과: " + sum);


//문제 2 : While 루프 – 자동차 연료 공급

int T, gas;
int full = 0;

Console.Write("목표 연료량 설정 : ");
T = int.Parse(Console.ReadLine());
Console.WriteLine("목표 연료량(T) = " + T);

while (full < T)
{
    Console.Write("연료 공급 : ");
    gas = int.Parse(Console.ReadLine());
    full += gas;
    Console.WriteLine("연료량 : " + full);
}

Console.WriteLine("연료가 완성되었습니다. 총 연료: " + full);


//문제 3 : While 루프 – 대출금 상환

int loanAmount, payment;

Console.Write("대출금액을 입력하시오 : ");
loanAmount = int.Parse(Console.ReadLine());

while (loanAmount > 0)
{
    Console.Write("상환금액을 입력하시오 : ");
    payment = int.Parse(Console.ReadLine());
    loanAmount -= payment;
    if (loanAmount > 0)
    {
        Console.WriteLine("남은 대출 : " + loanAmount);
    }
}

Console.WriteLine("대출 상환 완료!");


//문제 4: For 루프 – 주차장에 있는 자동차 수 세기

int totalHours;
int totalCars = 0;

Console.Write("추적시간 : ");
totalHours = int.Parse(Console.ReadLine());

for (int i = 0; i < totalHours; i++)
{
    Console.Write($"{i + 1}시간째 차량 수 : ");
    int carsThisHour = int.Parse(Console.ReadLine());

    totalCars += carsThisHour;
}

// 최종 결과 출력
Console.WriteLine($"총 차량 수 : {totalCars}");


//문제 5 : For문과 If문 – 유통기한이 지난 제품 확인하기

Console.Write("제품의 개수: ");
int productCount = int.Parse(Console.ReadLine());

for (int i = 1; i <= productCount; i++)
{
    Console.Write($"{i}번째 제품의 유통기한(일): ");
    int daysLeft = int.Parse(Console.ReadLine());

    if (daysLeft <= 0)
    {
        Console.WriteLine($"{i}번째 제품은 유통기한이 지났습니다.");
    }
}

//문제 6 : For문과 If문 – 비 오는 날 수 세기

int rainyDayCount = 0;

for (int i = 1; i <= 7; i++)
{
    Console.Write($"{i}번째 날의 날씨를 입력하세요: ");
    string weather = Console.ReadLine();

    if (weather == "비")
    {
        rainyDayCount++;
    }
}

Console.WriteLine($"비가 온 날은 총 {rainyDayCount}일입니다.");

//문제7: 입력한 숫자만큼 별을 출력

Console.Write("정수를 입력하세요(1 ≤ N ≤ 100): ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write("☆");
    }
    Console.WriteLine();
}


//문제8: 다중For문 - 주사위의 합

Console.Write("세 주사위 눈의 합 N을 입력하세요 (3~18): ");
int n = int.Parse(Console.ReadLine());

int caseCount = 0;

for (int die1 = 1; die1 <= 6; die1++)
{
    for (int die2 = 1; die2 <= 6; die2++)
    {
        for (int die3 = 1; die3 <= 6; die3++)
        {
            if (die1 + die2 + die3 == n)
            {
                Console.WriteLine($"({die1}, {die2}, {die3})");
                caseCount++;
            }
        }
    }
}

Console.WriteLine($"경우의 수: {caseCount}");