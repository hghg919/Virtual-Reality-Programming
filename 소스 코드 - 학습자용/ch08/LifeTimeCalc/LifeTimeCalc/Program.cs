// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.Write(" > 생일 입력(년-월-일 시:분) : ");
        DateTime d1 = DateTime.Parse(Console.ReadLine());
        DateTime d2 = DateTime.Now;

        TimeSpan interval = d2 - d1;
        Console.WriteLine(" > 출생 시각 : {0}", d1);
        Console.WriteLine(" > 현재 시각 : {0}", d2);
        Console.WriteLine(" > 생존 시간 : {0}",
            interval.ToString());
        Console.WriteLine(" > 지금까지 {0}일 {1}시간" +
            " {2}분 {3}초를 생활하였습니다.",
            interval.Days, interval.Hours,
            interval.Minutes, interval.Seconds);
    }
}