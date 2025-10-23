// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(" > 2024년은 {0} 입니다.",
            DateTime.IsLeapYear(2024) ? "[윤년]" : "[평년]");
        Console.WriteLine(" > 2024년 2월은 {0}일 입니다. \n",
            DateTime.DaysInMonth(2024, 2));

        Console.WriteLine(" > 2030년은 {0} 입니다.",
            DateTime.IsLeapYear(2030) ? "[윤년]" : "[평년]");
        Console.WriteLine(" > 2030년 2월은 {0}일 입니다. \n",
            DateTime.DaysInMonth(2030, 2));
    }
}