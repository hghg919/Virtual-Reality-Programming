// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        DateTime d1 = new DateTime(2000, 3, 2, 9, 30, 0);
        DateTime d2 = new DateTime(2035, 12, 25, 23, 59, 38);

        Console.WriteLine(" > 입사일자 : {0}", d1);
        Console.WriteLine(" > 경력기준 : {0}", d2);

        Console.WriteLine(" > {0}과 {1}의 차이는 {2} 일입니다.",
            d1.ToString("yyyy년 MM월 dd일"),    // 월과 일은 2자리로 설정
            d2.ToString("yyyy년 MM월 dd일"),
            d2.Subtract(d1).Days);
    }
}