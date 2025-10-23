// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(" > 윤년 리스트 ");
        for (int year = 2020; year <= 2050; year++)
        {
            if (IsLeapYear(year))
            {
                Console.Write("{0, 7}", year);
            }
        }
        Console.WriteLine();
    }

    private static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }
}