// See https://aka.ms/new-console-template for more information

// 문제 1: While 루프 – 홀수 항목의 총 가격

//int A, B;
//int sum = 0;

//Console.Write("A값을 입력하시오 : ");
//A = int.Parse(Console.ReadLine());

//while (true)
//{
//    Console.Write("B값을 입력하시오(B는 A보다 크거나 같아야합니다.) : ");
//    B = int.Parse(Console.ReadLine());
//    if (B >= A)
//    {
//        break;
//    }
//    else
//    {
//        Console.WriteLine("잘못된 입력입니다. B는 A보다 크거나 같아야 합니다.");
//    }
//}

//Console.WriteLine("입력 값 : " + A + " " + B);

//int currentNumber = A;

//while (currentNumber <= B)
//{
//    if (currentNumber % 2 != 0)
//    {
//        sum += currentNumber;
//    }
//    currentNumber++;
//}

//Console.WriteLine("결과: " + sum);


// 문제 2 : While 루프 – 자동차 연료 공급

//int T, gas;
//int full = 0;

//Console.Write("목표 연료량 설정 : ");
//T = int.Parse(Console.ReadLine());
//Console.WriteLine("목표 연료량(T) = " + T);

//while (full < T)
//{
//    Console.Write("연료 공급 : ");
//    gas = int.Parse(Console.ReadLine());
//    full += gas;
//    Console.WriteLine("연료량 : " + full);
//}

//Console.WriteLine("연료가 완성되었습니다. 총 연료: " + full);


// 문제 3 : While 루프 – 대출금 상환

//int loanAmount, payment;

//Console.Write("대출금액을 입력하시오 : ");
//loanAmount = int.Parse(Console.ReadLine());

//while (loanAmount > 0)
//{
//    Console.Write("상환금액을 입력하시오 : ");
//    payment = int.Parse(Console.ReadLine());
//    loanAmount -= payment;
//    if (loanAmount > 0)
//    {
//        Console.WriteLine("남은 대출 : " + loanAmount);
//    }
//}

//Console.WriteLine("대출 상환 완료!");


// 문제 4: For 루프 – 주차장에 있는 자동차 수 세기

//int totalHours;
//int totalCars = 0;

//Console.Write("추적시간 : ");
//totalHours = int.Parse(Console.ReadLine());

//for (int i = 0; i < totalHours; i++)
//{
//    Console.Write($"{i + 1}시간째 차량 수 : ");
//    int carsThisHour = int.Parse(Console.ReadLine());

//    totalCars += carsThisHour;
//}

//// 최종 결과 출력
//Console.WriteLine($"총 차량 수 : {totalCars}");


//문제 5 : For문과 If문 – 유통기한이 지난 제품 확인하기

//Console.Write("제품의 개수: ");
//int productCount = int.Parse(Console.ReadLine());

//for (int i = 1; i <= productCount; i++)
//{
//    Console.Write($"{i}번째 제품의 유통기한(일): ");
//    int daysLeft = int.Parse(Console.ReadLine());

//    if (daysLeft <= 0)
//    {
//        Console.WriteLine($"{i}번째 제품은 유통기한이 지났습니다.");
//    }
//}

//문제 6 : For문과 If문 – 비 오는 날 수 세기

//int rainyDayCount = 0;

//for (int i = 1; i <= 7; i++)
//{
//    Console.Write($"{i}번째 날의 날씨를 입력하세요: ");
//    string weather = Console.ReadLine();

//    if (weather == "비")
//    {
//        rainyDayCount++;
//    }
//}

//Console.WriteLine($"비가 온 날은 총 {rainyDayCount}일입니다.");

// 문제7: 입력한 숫자만큼 별을 출력

//Console.Write("정수를 입력하세요(1 ≤ N ≤ 100): ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= n; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {
//        Console.Write("☆");
//    }
//    Console.WriteLine();
//}


// 문제8: 다중For문 - 주사위의 합

//Console.Write("세 주사위 눈의 합 N을 입력하세요 (3~18): ");
//int n = int.Parse(Console.ReadLine());

//int caseCount = 0; 

//for (int die1 = 1; die1 <= 6; die1++)
//{
//    for (int die2 = 1; die2 <= 6; die2++)
//    {
//        for (int die3 = 1; die3 <= 6; die3++)
//        {
//            if (die1 + die2 + die3 == n)
//            {
//                Console.WriteLine($"({die1}, {die2}, {die3})");
//                caseCount++;
//            }
//        }
//    }
//}

//Console.WriteLine($"경우의 수: {caseCount}");