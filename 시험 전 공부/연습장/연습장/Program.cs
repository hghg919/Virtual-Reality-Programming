
// --- 01번 문제 ---
Console.WriteLine("--- 01번 문제 결과 ---");

// 문자 자료형 변수를 선언합니다.
char c1 = '안';
char c2 = '전';
char c3 = '운';

// Console.Write는 줄바꿈 없이 출력합니다.
Console.Write(c1);
// Console.WriteLine은 출력 후 한 줄을 띄웁니다.
Console.WriteLine(c2);

Console.Write(c3);
Console.WriteLine(c2); // '전' 변수를 재사용합니다.

Console.WriteLine(); // 문제 구분을 위해 한 줄 띄웁니다.

// --- 02번 문제 ---
Console.WriteLine("--- 02번 문제 결과 ---");

// (1) 알파벳 대문자 'Q'를 char 변수에 대입합니다.
char alphabet = 'Q';

// (2) 'Q'에 해당하는 아스키코드값을 출력합니다.
// char 변수를 (int)로 형변환하면 아스키코드(정수)값을 얻을 수 있습니다.
Console.WriteLine($"알파벳 {alphabet} -> 아스키코드값 : {(int)alphabet}");

// (3) Q+5의 연산을 수행 후 해당 알파벳을 출력합니다.
// 'Q' + 5 연산의 결과(81 + 5 = 86)를
// (char)로 다시 형변환하여 문자 'V'를 얻습니다.
char resultAlphabet = (char)(alphabet + 5);

Console.WriteLine($"Q + 5 : -> 해당 알파벳 : {resultAlphabet}");


// 3번
// (1) 콘솔 창에서 2개의 정수값을 변수에 대입

Console.Write("1. 첫번째 정수 입력 : ");
// Console.ReadLine()으로 입력받은 문자열을 int(정수)로 변환합니다.
int num1 = int.Parse(Console.ReadLine());

Console.Write("2. 두번째 정수 입력 : ");
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine(); // 결과와 구분을 위해 한 줄 띄우기

// (2) 2개 정수를 대상으로 사칙 연산을 수행 후 결과값 출력

// 덧셈
int sum = num1 + num2;
Console.WriteLine($"덧셈 : {sum}");

// 뺄셈
int diff = num1 - num2;
Console.WriteLine($"뺄셈 : {diff}");

// 곱셈
int prod = num1 * num2;
Console.WriteLine($"곱셈 : {prod}");

// (3) 나눗셈 (캐스트 연산자 사용)
// 정수(num1)를 실수(double)로 캐스팅(형변환)한 뒤 나누어야
// 소수점까지 유효한 값이 나옵니다.
double div = (double)num1 / num2;
Console.WriteLine($"나눗셈 : {div}");

//4
// (1) 콘솔 창에서 문자 입력
Console.Write("문자 입력 : ");
// Console.ReadLine()으로 문자열을 입력받고, [0]을 사용해 첫 번째 '문자'를 가져옵니다.
char inputChar = Console.ReadLine()[0];

Console.WriteLine(); // 실행 결과의 포맷에 맞게 한 줄 띄웁니다.

// --- 1. 연산 수행 전 ---
Console.WriteLine("1. 연산 수행 전");

// 입력받은 문자를 (int)로 형변환(캐스팅)하여 아스키코드 값을 구합니다.
int originalAscii = (int)inputChar;
Console.WriteLine($" - 아스키코드값 : {originalAscii}");

// 원본 문자 출력
Console.WriteLine($" - 변환된 문자 출력 : {inputChar}");


// --- 2. 연산 수행 후 ---
Console.WriteLine("2. 연산 수행 후");

// (2) 입력한 문자에 정수값 5을 더함 (정확히는 아스키코드 값에 5를 더함)
int newAscii = originalAscii + 5;

// (3) 문자에 정수값 5가 더해진 아스키코드 정수값 출력
Console.WriteLine($" - 아스키코드값 : {newAscii}");

// (4) 정수값 5가 더해진 문자를 대상으로 변환(캐스팅) 후 문자 출력
// 새로운 아스키코드 값(newAscii)을 (char)로 형변환하여 문자를 구합니다.
char newChar = (char)newAscii;
Console.WriteLine($" - 변환된 문자 출력 : {newChar}");


//4-1
// (1) 콘솔 창에서 키(cm)와 체중(kg) 입력
Console.Write("신장(cm) : ");
// 키는 실수일 수 있으므로 double로 받습니다.
double heightCm = double.Parse(Console.ReadLine());

Console.Write("체중(kg) : ");
double weightKg = double.Parse(Console.ReadLine());

// (2) 체질량지수 BMI = 체중(kg) / 키(m)² 산출
// cm를 m로 변환합니다 (예: 188cm -> 1.88m)
double heightM = heightCm / 100.0;
double bmi = weightKg / (heightM * heightM);

// BMI 값 먼저 출력
Console.WriteLine($"> 본인 BMI : {bmi}");

// (3) if...else if...else 조건문으로 메시지 출력
if (bmi < 18.5)
{
    Console.WriteLine("> 처방 : 체력 보강 필요");
}
else if (bmi <= 22.9) // 18.5 ~ 22.9
{
    Console.WriteLine("> 처방 : 정상 유지 필요");
}
else if (bmi <= 40) // 23 ~ 40
{
    Console.WriteLine("> 처방 : 다이어트 필요");
}
else // 40 초과
{
    // 40 초과 시에는 "> 처방 :" 없이 "프로그램 종료!"만 출력
    Console.WriteLine("프로그램 종료!");
}

//4-2
// (1) 콘솔 창에서 월을 입력
Console.Write("월 입력 : ");
int month = int.Parse(Console.ReadLine());

// (2) if...else 조건문으로 1~12월에 해당하는 숫자인지 판별
if (month >= 1 && month <= 12)
{
    // (3) switch...case 조건문으로 해당 월의 날짜 수 출력
    string daysMessage;
    switch (month)
    {
        case 2:
            daysMessage = "평년 기준 28일";
            break;

        // 4, 6, 9, 11월은 30일
        case 4:
        case 6:
        case 9:
        case 11:
            daysMessage = "30일";
            break;

        // 나머지 (1, 3, 5, 7, 8, 10, 12월)
        default:
            daysMessage = "31일";
            break;
    }
    Console.WriteLine($"> {month}월은 {daysMessage}까지 있습니다.");
}
else
{
    // 1~12월 범위 밖의 숫자를 입력한 경우
    Console.WriteLine($"> {month}월은 없습니다.");
    Console.WriteLine($"> 프로그램 종료!");
}

//5-1
// (1) 정수형 변수 2개 선언 (i, j)
// (2) 중첩 for 반복문

// 바깥쪽 for문: 1부터 5까지 5번 반복 (총 5줄을 의미)
for (int i = 1; i <= 5; i++)
{
    // 안쪽 for문: 1부터 현재 줄 번호(i)까지 반복
    // (i가 1일 때 1번, i가 3일 때 3번 실행)
    for (int j = 1; j <= i; j++)
    {
        // (3) 기호 ★을 줄바꿈 없이 출력
        Console.Write("★");
    }

    // 안쪽 for문이 한 줄의 별을 모두 출력한 후,
    // Console.WriteLine()을 호출하여 한 줄을 띄웁니다.
    Console.WriteLine();
}

//5-2
// 2~9 이외의 값이 입력됐을 때 goto로 돌아올 위치(레이블)
InputPrompt:

Console.Write("출력할 구구단(2~9) : ");
string input = Console.ReadLine();

// 입력받은 문자열(input)을 정수(dan)로 변환 시도
// isSuccess 변수에는 변환 성공 여부(true/false)가 저장됨
bool isSuccess = int.TryParse(input, out int dan);

// (1) if...else 조건문으로 2~9단 유효성 판별
// (isSuccess가 true이고) (dan이 2 이상이고) (dan이 9 이하)
if (isSuccess && dan >= 2 && dan <= 9)
{
    // (3) 입력한 숫자에 해당하는 구구단을 for 반복문으로 출력
    Console.WriteLine(); // 실행 결과와 같이 한 줄 띄우기
    for (int i = 1; i <= 9; i++)
    {
        // 서식에 맞게 구구단 출력
        Console.WriteLine($"{dan} * {i} = {dan * i}");
    }
}
else
{
    // (2) 2~9 이외의 숫자나 문자가 입력되면 goto 문으로 점프
    Console.WriteLine("> 유효하지 않은 데이터값!");
    Console.WriteLine("> 다시 입력하세요...");
    goto InputPrompt; // InputPrompt 레이블로 점프
}

//6-1
// --- 01번 문제 ---
Console.WriteLine("> 2차원 배열 선언 후 요소 출력");

// (1) 2차원 배열 생성
int[,] numbers2D = { { 3, 5, 9 }, { 10, 20, 30 } };

// (2) foreach 반복문으로 배열 요소 출력
foreach (int num in numbers2D)
{
    // (3) {0, 5} 설정은 5칸의 공간을 잡고 오른쪽 정렬하여 출력
    // C# 6.0 이상에서는 $"{변수,칸수}"로 쉽게 표현 가능
    Console.Write($"{num,5}");
}

// Console.WriteLine()으로 한 줄 띄워서 다음 문제와 구분
Console.WriteLine();
Console.WriteLine(); // 한 줄 더 띄워서 가독성 확보


// --- 02번 문제 ---
Console.WriteLine("> 생성된 5개의 랜덤 숫자 출력");

// (2) Random 클래스의 객체 r 생성
Random r = new Random();

// 5개의 숫자를 저장할 정수 배열 선언
int[] randomNumbers = new int[5];

// (3) for 반복문으로 5개의 랜덤 숫자 저장
for (int i = 0; i < randomNumbers.Length; i++)
{
    // (1) 1부터 100까지의 숫자 중 랜덤 숫자 추출 (Next(1, 101) -> 1 이상 101 미만)
    randomNumbers[i] = r.Next(1, 101);
}

// (4) foreach 반복문으로 5개의 랜덤 숫자 출력
foreach (int num in randomNumbers)
{
    // (5) {0, 7} 설정은 7칸의 공간을 잡고 오른쪽 정렬하여 출력
    Console.Write($"{num,7}");
}

Console.WriteLine(); // 마무리 줄바꿈
