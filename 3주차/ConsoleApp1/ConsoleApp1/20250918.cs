// See https://aka.ms/new-console-template for more information

// Console.Write("1. 문자열 입력 : ");
// s = Console.ReadLine();

// Console.WriteLine("2. 입력한 문자열 출력 : " + s);

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

// int a, choice;

// Console.Write("정수 입력 : ");
// a = int.Parse(Console.ReadLine());
// choice = a % 2;

// if (choice == 0)
// {
//     Console.WriteLine("짝수");
// }
// else
// {
//     Console.WriteLine("홀수");
// }

// int c;
// char cparse;

// Console.Write("문자입력:");
// c = Console.Read();
// cparse = Convert.ToChar(c);

// if (cparse >= 'A' && cparse <= 'Z')
// {
//     Console.WriteLine(" > 입력한알파벳 : " + cparse);
//     Console.WriteLine(" > 판변결과 : 대문자 ");
// }
// else
// {
//     Console.WriteLine(" > 입력한알파벳 : " + cparse);
//     Console.WriteLine(" > 판변결과 : 소문자 ");
// }

// int a;
// char choice;

// Console.WriteLine("법학과 : A 또는 a");
// Console.WriteLine("행정학과 : S 또는 s");
// Console.WriteLine("소비자학과 : D 또는 d");
// Console.WriteLine("데이터사이언스학과 : F 또는 f");
// Console.WriteLine("그 이외의 알파벳 : 에러 메시지 출력");
// Console.WriteLine();

// Console.Write("알파벳 입력 : ");
// a = Console.Read();
// choice = Convert.ToChar(a);

// Console.Write("선택학과 : ");

// if (choice == 'A' || choice == 'a')
// {
//     Console.WriteLine("법학과");
// }
// else if (choice == 'S' || choice == 's')
// {
//     Console.WriteLine("행정학과");
// }
// else if (choice == 'D' || choice == 'd')
// {
//     Console.WriteLine("소비자학과");
// }
// else if (choice == 'F' || choice == 'f')
// {
//     Console.WriteLine("데이터사이언스학과");
// }
// else
// {
//     Console.WriteLine();
//     Console.WriteLine(" > 유효하지 않은 알파벳입니다.");
//     Console.WriteLine(" > 프로그램 종료!");
// }


// int socre;

// Console.Write("점수입력: ");
// socre = int.Parse(Console.ReadLine());

// if (socre >= 90)
// {
//     Console.WriteLine(" > 입력한 점수 : " + socre);
//     Console.WriteLine(" > 등급 : A 학점");
// }
// else if (socre >= 80)
// {
//     Console.WriteLine(" > 입력한 점수 : " + socre);
//     Console.WriteLine(" > 등급 : B 학점");
// }
// else if (socre >= 70)
// {
//     Console.WriteLine(" > 입력한 점수 : " + socre);
//     Console.WriteLine(" > 등급 : C 학점");
// }
// else if (socre >= 60)
// {
//     Console.WriteLine(" > 입력한 점수 : " + socre);
//     Console.WriteLine(" > 등급 : D 학점");
// }
// else
// {
//     Console.WriteLine(" > 입력한 점수 : " + socre);
//     Console.WriteLine(" > 등급 : F 학점");
// }


// int socre;
// 
// Console.Write("점수입력: ");
// socre = int.Parse(Console.ReadLine());
// if (socre > 100 || socre < 0)
// {
//     Console.WriteLine(" > 입력한점수 : " + socre);
//     Console.WriteLine(" > 허용하지 않는 점수로 프로그램 종료! ");
// }
// else
// {
//     if (socre >= 90)
//     {
//         Console.WriteLine(" > 입력한 점수 : " + socre);
//         Console.WriteLine(" > 등급 : A 학점");
//     }
//     else if (socre >= 80)
//     {
//         Console.WriteLine(" > 입력한 점수 : " + socre);
//         Console.WriteLine(" > 등급 : B 학점");
//     }
//     else if (socre >= 70)
//     {
//         Console.WriteLine(" > 입력한 점수 : " + socre);
//         Console.WriteLine(" > 등급 : C 학점");
//     }
//     else if (socre >= 60)
//     {
//         Console.WriteLine(" > 입력한 점수 : " + socre);
//         Console.WriteLine(" > 등급 : D 학점");
//     }
//     else
//     {
//         Console.WriteLine(" > 입력한 점수 : " + socre);
//         Console.WriteLine(" > 등급 : F 학점");
//     }
// }


// int score, mok;
// char grade;
// 
// Console.Write("점수 입력 : ");
// score = int.Parse(Console.ReadLine());
// mok = score / 10;
// 
// switch(mok)
// {
//     case 10:
//     case 9:
//         grade = 'A';
//         break;
//     case 8:
//         grade = 'B';
//         break;
//     case 7:
//         grade = 'C';
//         break;
//     case 6:
//         grade = 'D';
//         break;
//     default:
//         grade = 'F';
//         break;
// }
// Console.WriteLine(" > 입력한점수 : " + score);
// Console.WriteLine(" > 등급 : " + grade + " 학점 ");

// int a;
// char choice;
// 
// Console.WriteLine("A형 : A 또는 a");
// Console.WriteLine("B형 : S 또는 s");
// Console.WriteLine("O형 : D 또는 d");
// Console.WriteLine("AB형 : F 또는 f");
// Console.WriteLine("그 이외의 알파벳 : 에러 메시지 출력");
// Console.WriteLine();
// 
// Console.Write("알파벳 입력 : ");
// a = Console.Read();
// choice = Convert.ToChar(a);
// 
// Console.Write(" > 혈액형 성격 : ");
// 
// switch(choice)
// {
//     case 'a':
//     case 'A':
//         Console.WriteLine("차분한 성격 ");
//         break;
//     case 'B':
//     case 'b':
//         Console.WriteLine("예술적 성격 ");
//         break;
//     case 'C':
//     case 'c':
//         Console.WriteLine("예술적 성격 ");
//         break;
//     case 'D':
//     case 'd':
//         Console.WriteLine("활발한 성격 ");
//         break;
//     case 'F':
//     case 'f':
//         Console.WriteLine("창의적 성격 ");
//         break;
//     default:
//         Console.WriteLine();
//         Console.WriteLine(" > 유효하지 않은 알파벳입니다.");
//         Console.WriteLine(" > 프로그램 종료!");
//         break;
// }



