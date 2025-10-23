// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        DateTime sT = new DateTime(2023, 3, 15, 10, 33, 0);
        DateTime eT = new DateTime(2023, 3, 20, 7, 15, 0);
        TimeSpan tTime = eT - sT;

        Console.WriteLine(" > 2023. 3. 15 ~ 2023. 3. 20일의 시간 간격 ");
        Console.WriteLine(" > 여행기간 : {0, 10}", tTime);
        Console.WriteLine(" {0, 14} 일", tTime.Days);
        Console.WriteLine(" {0, 14} 시간", tTime.TotalHours);
        Console.WriteLine(" {0, 14} 분", tTime.TotalMinutes);
        Console.WriteLine(" {0, 14} 초", tTime.TotalSeconds);
    }
}