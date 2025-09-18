// 문제1: 영화 등급 판별기
//int age;
//
//Console.WriteLine("상영 가능한 영화 등급을 알려줍니다.");
//Console.Write("나이를 입력하세요: ");
//age = int.Parse(Console.ReadLine());
//
//if (age > 18)
//{
//    if (age >= 65)
//    {
//        Console.WriteLine("청소년 관람 불가");
//        Console.WriteLine("시니어 할인이 적용됩니다.");
//    }
//    else
//    {
//        Console.WriteLine("청소년 관람 불가");
//    }
//}
//else if (age < 18 && age >= 15)
//{
//    Console.WriteLine("15세 이상 관람가");
//}
//else
//{
//    Console.WriteLine("전체관람가");
//}


// 문제 2: 큰 수 판단
//int a, b, c;
//
//Console.WriteLine("세 개의 정수를 입력받아 가장 큰 수를 출력하는 프로그램입니다.");
//Console.Write("첫 번째 정수: ");
//a = int.Parse(Console.ReadLine());
//Console.Write("두 번째 정수: ");
//b = int.Parse(Console.ReadLine());
//Console.Write("세 번째 정수: ");
//c = int.Parse(Console.ReadLine());
//
//if ( a > b && a > c)
//{
//    Console.WriteLine("가장 큰 수: " + a);
//}
//else if (b > a && b > c)
//{
//    Console.WriteLine("가장 큰 수: " + b);
//}
//else
//{
//    Console.WriteLine("가장 큰 수: " + c);
//}

// 문제3: 할인율 계산기 (수정필요)
//int amount;
//
//Console.Write("구매 금액을 입력하세요: ");
//amount = int.Parse(Console.ReadLine());
//
//Console.Write("VIP 회원이신가요? (true/false): ");
//bool isVip = Convert.ToBoolean(Console.ReadLine());
//
//double discountRate = 0;
//
//if (amount >= 100000)
//{
//    discountRate = 10;
//}
//else if (amount >= 50000)
//{
//    discountRate = 5;
//}
//if (isVip)
//{
//    discountRate += 5;
//}
//
//double discountedPrice = amount * (1 - discountRate / 100);
//
//Console.WriteLine($"총 할인율: {discountRate}%, 할인된 금액: {discountedPrice}원");


//문제 4: 윤년 판단
int age;

Console.WriteLine("윤년인지 아닌지 판별하는 프로그램입니다.");
Console.Write("연도를 입력하세요: ");
age = int.Parse(Console.ReadLine());

if (age % 4 == 0)
{

}



