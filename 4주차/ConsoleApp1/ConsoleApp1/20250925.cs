// See https://aka.ms/new-console-template for more information
// int su, count, sum = 0;
// 
// count = 1;
// 
// Console.Write("누적합을 어디까지 구할까요 : ");
// su = int.Parse(Console.ReadLine());
// 
// while(count <= su) // 입력한 수까지 반복문 수행
// {
//     sum += count;
//     count++;
// }
// Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
// Console.WriteLine(" > 카운터 변수값 : " + count);


// int su, count, sum = 0;

// count = 1;

// Console.Write("누적합을 어디까지 구할까요 : ");
// su = int.Parse(Console.ReadLine());

// if(su < 0)
// {
//     Console.WriteLine(" > 유효하지 않은 데이터값!");
//     Console.WriteLine(" > 프로그램 종료!");
// }
// else
// {
//     while (count <= su) // 입력한 수까지 반복문 수행
//     {
//         sum += count;
//         count++;
//     }
//     Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
//     Console.WriteLine(" > 카운터 변수값 : " + count);
// }


// int count = 1;
// string s;

// Console.WriteLine("문자열 exit가 입력되면 종료");

// do
// {
//     Console.WriteLine(" > " + count + "회 문자열 입력 : ");
//     s = Console.ReadLine();
//     count++;
// }while (s != "exit");

// Console.WriteLine(" > 반복 수행 횟수 : " + (count - 1) + "회 ");


// int count, su, sum = 0;

// Console.WriteLine("누적합을 어디까지 구할까요 : ");
// su = int.Parse(Console.ReadLine());

// for(count = 1;  count <= su; count++)
// {
//     sum += count; // sum = sum + count;
// }

// Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
// Console.WriteLine(" > 카운트 변수값 : " + count);


// int count, su, sum = 0;

// Console.WriteLine("누적합을 어디까지 구할까요 : ");
// su = int.Parse(Console.ReadLine());

// if (su < 0)
// {
//     Console.WriteLine(" > 유효하지 않은 데이터값!");
//     Console.WriteLine(" > 프로그램 종료!");
// }
// else
// {
//     for (count = 1; count <= su; count++)
//     {
//         sum += count; // sum = sum + count;
//     }

//     Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
//     Console.WriteLine(" > 카운트 변수값 : " + count);
// }


// int dan, count, gob;

// Console.WriteLine("출력할 구구단 : ");
// dan = int.Parse(Console.ReadLine());

// if (dan < 2 ||  dan > 99)
// {
//     Console.WriteLine(" > 유효하지 않은 데이터값!");
//     Console.WriteLine(" > 프로그램 종료!");
// }
// else
// {
//     for (count = 1;  count <= 9; count++)
//     {
//         gob = dan * count;
//         Console.WriteLine(dan + " * " + count + " = " + gob);
//     }
// }


// int dan, count, gob;

// for (dan = 2; dan <= 9 ; dan++)
// {
//     for (count = 1; count <= 9; count++)
//     {
//         gob = dan * count;
//         Console.WriteLine(dan + " * " + count + " = " + gob);
//     }
//     Console.WriteLine();
// }


//int star, count;

//for (count = 1; count <=5; count++)
//{
//    for (star = 5; star >= count; star--)
//    {
//        Console.Write("☆");
//    }
//    Console.WriteLine();
//}

// int star, count, n;

// n = 5;
// for (count = 1; count <= n; count++)
// {
//     for (star = 1; star <= n - count; star++)
//     {
//         Console.Write(" ");
//     }
//     for (star = 1; star <= count; star++)
//     {
//         Console.Write("☆");
//     }
//     Console.WriteLine();
// }


// int count = 1, sum = 0;

// Console.WriteLine("누적합이 500을 넘으면 프로그램 종료");

// do
// {
//     if(sum > 500)
//     {
//         Console.WriteLine(" > 누적합 500 초과! ");
//         break;
//     }
//     else
//     {
//         sum += count; // sum = sum + count;
//     }
//     count++;
// }while (count <=  100); // 또는 while (true) -> 무한 반복문 구현 가능

// Console.WriteLine(" > 누적 합계 : " + sum);


//int count;

//Console.WriteLine("홀수만 출력하는 프로그램");
//Console.Write(" > ");

//for (count = 1; count <= 10; count++)
//{
//    if (count % 2 == 0)
//    {
//        continue;
//    }
//    Console.Write(count + " ");
//}


int su, count, sum = 0;

count = 1;

replay:
Console.Write("누적합을 어디까지 구할까요 : ");
su = int.Parse(Console.ReadLine());

if (su < 0)
{
    Console.WriteLine(" > 유효하지 않은 데이터값! ");
    Console.WriteLine();
    goto replay;
}
else
{
    while (count <= su) // 입력한 수까지 반복문 수행
    {
        sum += count;
        count++;
    }
    Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
    Console.WriteLine(" > 카운트변수값 : " + count);
}