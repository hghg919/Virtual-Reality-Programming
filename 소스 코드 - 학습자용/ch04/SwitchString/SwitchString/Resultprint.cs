// See https://aka.ms/new-console-template for more information
string choice;

Console.Write("한글 요일 입력 : ");
choice = Console.ReadLine();

Console.Write(" > 영문 요일 출력 : ");
switch (choice)
{
    case "일":
        Console.WriteLine("Sunday ");
        break;
    case "월":
        Console.WriteLine("Monday ");
        break;
    case "화":
        Console.WriteLine("Tuesday ");
        break;
    case "수":
        Console.WriteLine("Wednesday ");
        break;
    case "목":
        Console.WriteLine("Thursday ");
        break;
    case "금":
        Console.WriteLine("Friday ");
        break;
    case "토":
        Console.WriteLine("Saturday ");
        break;
    default:
        Console.WriteLine("유효하지 않은 요일입니다. ");
        Console.WriteLine(" > 프로그램 종료! ");
        break;
}