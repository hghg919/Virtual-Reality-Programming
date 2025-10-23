// -----------------------------------------------------------------
// 3주차 문제
// -----------------------------------------------------------------

// --- 문제 1: 영화 등급 판별기 ---
int age;

Console.WriteLine("상영 가능한 영화 등급을 알려줍니다.");
Console.Write("나이를 입력하세요: ");
age = int.Parse(Console.ReadLine());

// [수정] 원본 코드는 if (age > 18) { if (age >= 65) ... } 처럼
// 중첩 if 문을 사용했는데, 이 경우 "청소년 관람 불가" 코드가 중복됩니다.
// 또한, 원본 코드는 '18살'일 경우 '전체관람가'로 빠지는 논리적 오류가 있습니다.
//
// 아래처럼 조건을 나이 많은 순서대로 'else if'로 묶으면
// 코드가 더 간결해지고 중복이 제거되며, 18살(15세 이상) 케이스도 정확히 처리됩니다.
if (age >= 65)
{
    Console.WriteLine("청소년 관람 불가");
    Console.WriteLine("시니어 할인이 적용됩니다.");
}
else if (age > 18) // 19세~64세
{
    Console.WriteLine("청소년 관람 불가");
}
else if (age >= 15) // 15세~18세
{
    Console.WriteLine("15세 이상 관람가");
}
else // 14세 이하
{
    Console.WriteLine("전체관람가");
}


// --- 문제 2: 큰 수 판단 ---
int a, b, c;

Console.WriteLine("세 개의 정수를 입력받아 가장 큰 수를 출력하는 프로그램입니다.");
Console.Write("첫 번째 정수: ");
a = int.Parse(Console.ReadLine());
Console.Write("두 번째 정수: ");
b = int.Parse(Console.ReadLine());
Console.Write("세 번째 정수: ");
c = int.Parse(Console.ReadLine());

// [수정] if-else if-else 로직도 맞지만,
// 이 방식이 더 직관적이고 확장성(만약 4개, 5개가 되어도)이 좋습니다.
// 1. 일단 a를 가장 큰 수(max)라고 가정합니다.
// 2. b가 max보다 크면, max를 b로 바꿉니다.
// 3. c가 (현재 max값보다) 크면, max를 c로 바꿉니다.
// 4. 최종 max를 출력합니다.
int max = a;
if (b > max)
{
    max = b;
}
if (c > max)
{
    max = c;
}
Console.WriteLine("가장 큰 수: " + max);


// --- 문제 3: 할인율 계산기 ---
int amount;
bool isVip; 

Console.Write("구매 금액을 입력하세요: ");
amount = int.Parse(Console.ReadLine());

Console.Write("VIP 회원이신가요? (true/false): ");
isVip = Convert.ToBoolean(Console.ReadLine());

// [수정] 원본 코드는 금액 조건(if, else if, else)마다
// 'if (isVip)' 확인 코드가 중복으로 들어가 있습니다. (DRY 원칙 위배)
//
// 아래처럼 '할인율(discountRate)' 변수를 하나 만들고,
// 조건에 따라 할인율 값만 정해준 뒤,
// 마지막에 한 번만! 할인율을 적용하고 출력하는 것이 훨씬 깔끔합니다.
double discountRate = 0.0; // 0.0 = 0%

if (amount >= 100000)
{
    // 3항 연산자: (isVip가 true이면) ? 0.15 : (아니면) 0.10
    discountRate = isVip ? 0.15 : 0.10; // 15% 또는 10%
}
else if (amount >= 50000)
{
    discountRate = isVip ? 0.10 : 0.05; // 10% 또는 5%
}
else
{
    discountRate = isVip ? 0.05 : 0.0; // 5% 또는 0%
}

// 할인율과 최종 금액 계산 (계산 로직은 한 곳에만)
int discountPercent = (int)(discountRate * 100);
int finalAmount = (int)(amount * (1 - discountRate)); // 15% 할인이면 0.85를 곱함

Console.WriteLine($"총 할인율: {discountPercent}%, 할인된 금액: {finalAmount}원");



// --- 문제 4: 윤년 판단 ---
int year;

Console.WriteLine("윤년인지 아닌지 판별하는 프로그램입니다.");
Console.Write("연도를 입력하세요: ");
year = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// 1. 4로 나누어 떨어지고(year % 4 == 0)
// 2. 100으로 나누어 떨어지지 않거나(year % 100 != 0)
// 3. 400으로 나누어 떨어지면 윤년
if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
    Console.WriteLine("윤년입니다.");
else
    Console.WriteLine("윤년이 아닙니다.");



// --- 문제 5: 삼각형 판별 ---
int x, y, z;

Console.WriteLine("삼각형을 만들 수 있는지 판별하는 프로그램입니다.");
Console.Write("첫 번째 변의 길이: ");
x = int.Parse(Console.ReadLine());
Console.Write("두 번째 변의 길이: ");
y = int.Parse(Console.ReadLine());
Console.Write("세 번째 변의 길이: ");
z = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// 삼각형의 결정 조건: "가장 긴 변의 길이는 나머지 두 변의 길이의 합보다 작아야 한다."
// 이 코드는 그 조건을 (x + y > z), (x + z > y), (y + z > x) 세 가지로 모두 확인한 것입니다.
if (x + y > z && x + z > y && y + z > x)
    Console.WriteLine("삼각형을 만들 수 있습니다.");
else
    Console.WriteLine("삼각형을 만들 수 없습니다.");


Console.WriteLine(); // 문제 구분을 위한 줄바꿈

// --- 문제 6: 비만도 판정 ---
double height, weight;

Console.WriteLine("BMI를 계산하고 비만도를 판정하는 프로그램입니다.");
Console.Write("키(cm)를 입력하세요: ");
height = double.Parse(Console.ReadLine());
Console.Write("체중(kg)을 입력하세요: ");
weight = double.Parse(Console.ReadLine());

// [수정] BMI 계산식(cm -> m 변환)과 if-else if-else 범위 지정 모두 완벽합니다.
double bmi = weight / ((height / 100) * (height / 100));

if (bmi < 18.5)
    Console.WriteLine("저체중");
else if (bmi < 25) // 18.5 <= bmi < 25
    Console.WriteLine("정상");
else if (bmi < 30) // 25 <= bmi < 30
    Console.WriteLine("과체중");
else // 30 <= bmi
    Console.WriteLine("비만");



// --- 문제 7: 월별 날짜 수 계산 ---
int month;

Console.Write("월 번호를 입력하세요 (1-12): ");
month = int.Parse(Console.ReadLine());

// [수정] if (month == 1 || month == 3 || ...) 처럼
// || (OR) 연산자를 길게 쓰는 것도 작동은 하지만,
// 이처럼 '하나의 변수(month)'가 '여러 개의 특정 값' 중 하나인지 확인할 때는
// 'switch' 문을 쓰는 것이 훨씬 깔끔하고 가독성이 좋습니다.
switch (month)
{
    case 1:
    case 3:
    case 5:
    case 7:
    case 8:
    case 10:
    case 12: // 1, 3, 5, 7, 8, 10, 12월은 모두 이 코드를 실행
        Console.WriteLine("31일");
        break; // switch 문 종료
    case 4:
    case 6:
    case 9:
    case 11: // 4, 6, 9, 11월은 이 코드를 실행
        Console.WriteLine("30일");
        break;
    case 2: // 2월은 이 코드를 실행
        Console.WriteLine("28일 또는 29일");
        break;
    default: // 1~12 사이의 숫자가 아니면 (else)
        Console.WriteLine("잘못된 입력입니다.");
        break;
}



// -----------------------------------------------------------------
// 4주차 문제
// -----------------------------------------------------------------

// --- 문제 1: While 루프 – 홀수 항목의 총 가격 ---
int A, B;
int sum = 0;

Console.Write("A값을 입력하시오 : ");
A = int.Parse(Console.ReadLine());

// B가 A보다 클 때까지 무한 반복 (입력 유효성 검사) -> 좋습니다.
while (true)
{
    Console.Write("B값을 입력하시오(B는 A보다 크거나 같아야합니다.) : ");
    B = int.Parse(Console.ReadLine());
    if (B >= A)
    {
        break; // B가 A보다 크거나 같으면 무한 루프 탈출
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다. B는 A보다 크거나 같아야 합니다.");
    }
}

Console.WriteLine("입력 값 : " + A + " " + B);

// [수정] 'currentNumber' 변수를 만들어서 while(currentNumber <= B)로
// 1씩 증가시키는 로직은 'for' 문으로 완벽하게 대체할 수 있습니다.
// 'for' 문이 "정해진 횟수/범위(A부터 B까지)"를 반복할 때 더 명확합니다.
// int currentNumber = A; (초기값)
// currentNumber <= B; (조건)
// currentNumber++; (증감)
for (int currentNumber = A; currentNumber <= B; currentNumber++)
{
    if (currentNumber % 2 != 0) // 홀수이면
    {
        sum += currentNumber; // sum = sum + currentNumber
    }
}

Console.WriteLine("결과: " + sum);


// --- 문제 2 : While 루프 – 자동차 연료 공급 ---
int T, gas;
int full = 0;

Console.Write("목표 연료량 설정 : ");
T = int.Parse(Console.ReadLine());
Console.WriteLine("목표 연료량(T) = " + T);

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// "목표치(T)에 도달할 때까지" 반복하는 것은 while 문이 어울립니다.
while (full < T)
{
    Console.Write("연료 공급 : ");
    gas = int.Parse(Console.ReadLine());
    full += gas;
    Console.WriteLine("연료량 : " + full);
}

Console.WriteLine("연료가 완성되었습니다. 총 연료: " + full);



// --- 문제 3 : While 루프 – 대출금 상환 ---
int loanAmount, payment;

Console.Write("대출금액을 입력하시오 : ");
loanAmount = int.Parse(Console.ReadLine());

// [수정] 원본 코드는 상환 완료 메시지가 while 루프 '밖'에 있었습니다.
// 아래처럼 '안'으로 가져오면, 0원이나 마이너스가 되는 '즉시'
// "대출 상환 완료!"가 뜨고 루프가 종료되어 더 자연스럽습니다.
while (loanAmount > 0)
{
    Console.Write("상환금액을 입력하시오 : ");
    payment = int.Parse(Console.ReadLine());
    loanAmount -= payment; // 대출금에서 상환액을 뺀다

    if (loanAmount > 0)
    {
        Console.WriteLine("남은 대출 : " + loanAmount);
    }
    else
    {
        Console.WriteLine("대출 상환 완료!");
        // (이후 while 조건(loanAmount > 0)이 false가 되므로 루프 자연 종료)
    }
}



// --- 문제 4: For 루프 – 주차장에 있는 자동차 수 세기 ---
int totalHours;
int totalCars = 0;

Console.Write("추적시간 : ");
totalHours = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// "정해진 시간(totalHours) 만큼" 반복하므로 for 문이 적절합니다.
for (int i = 0; i < totalHours; i++)
{
    // ${...} (문자열 보간법) 사용 -> 좋습니다.
    Console.Write($"{i + 1}시간째 차량 수 : ");
    int carsThisHour = int.Parse(Console.ReadLine());

    totalCars += carsThisHour;
}

Console.WriteLine($"총 차량 수 : {totalCars}");


// --- 문제 5 : For문과 If문 – 유통기한이 지난 제품 확인하기 ---
Console.Write("제품의 개수: ");
int productCount = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// 1부터 시작해서 productCount '이하(<=)'까지 반복 -> 좋습니다.
for (int i = 1; i <= productCount; i++)
{
    Console.Write($"{i}번째 제품의 유통기한(일): ");
    int daysLeft = int.Parse(Console.ReadLine());

    if (daysLeft <= 0) // 0일(오늘까지) 또는 마이너스(이미 지남)
    {
        Console.WriteLine($"{i}번째 제품은 유통기한이 지났습니다.");
    }
}



// --- 문제 6 : For문과 If문 – 비 오는 날 수 세기 ---
int rainyDayCount = 0;

// 7일 동안으로 고정
for (int i = 1; i <= 7; i++)
{
    Console.Write($"{i}번째 날의 날씨를 입력하세요: ");

    // [수정] .Trim() 을 추가했습니다.
    // 만약 사용자가 실수로 " 비 " (앞뒤 공백)라고 입력해도
    // Trim()이 공백을 제거해서 "비"로 만들어주기 때문에
    // 프로그램이 더 안정적으로(Robust) 동작합니다.
    string weather = Console.ReadLine().Trim();

    if (weather == "비")
    {
        rainyDayCount++;
    }
}

Console.WriteLine($"비가 온 날은 총 {rainyDayCount}일입니다.");


// --- 문제 7: 입력한 숫자만큼 별을 출력 ---

// [수정] 문제 8번의 변수 'n'과 이름이 겹치므로 'n_stars'로 변경했습니다.
Console.Write("정수를 입력하세요(1 ≤ N ≤ 100): ");
int n_stars = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다.
// 중첩 for 문 (바깥 루프는 '줄', 안쪽 루프는 '줄 안의 별')의 정석입니다.
for (int i = 1; i <= n_stars; i++) // i: 현재 줄 번호 (1 ~ N)
{
    for (int j = 1; j <= i; j++) // j: 현재 줄(i)에서 몇 번째 별 (1 ~ i)
    {
        Console.Write("☆");
    }
    Console.WriteLine(); // 한 줄 다 찍고 줄바꿈
}



// --- 문제 8: 다중For문 - 주사위의 합 ---

// [수정] 문제 7번의 변수 'n'과 이름이 겹치므로 'n_diceSum'으로 변경했습니다.
Console.Write("세 주사위 눈의 합 N을 입력하세요 (3~18): ");
int n_diceSum = int.Parse(Console.ReadLine());

int caseCount = 0;

// [수정] 코드는 완벽합니다.
// 주사위 3개의 모든 경우의 수(6 * 6 * 6 = 216)를
// 3중 for 문으로 모두 확인(Brute force)하는 좋은 코드입니다.
for (int die1 = 1; die1 <= 6; die1++)
{
    for (int die2 = 1; die2 <= 6; die2++)
    {   
        for (int die3 = 1; die3 <= 6; die3++)
        {
            if (die1 + die2 + die3 == n_diceSum) // 합이 N과 같다면
            {
                Console.WriteLine($"({die1}, {die2}, {die3})");
                caseCount++;
            }
        }
    }
}

Console.WriteLine($"경우의 수: {caseCount}");