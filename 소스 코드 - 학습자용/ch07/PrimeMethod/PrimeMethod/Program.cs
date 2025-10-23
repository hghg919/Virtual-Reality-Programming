// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        // 2~50까지 숫자 중 소수 판별 프로그램
        int count = 0;
        for (int i = 2; i <= 50; i++)
        {
            if (IsPrime(i))
            {
                Console.Write("{0, 3}", i);               // 3자리로 소수 출력
                count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine(" > 소수 개수 : " + count);
    }
    private static bool IsPrime(int s)
    {
        int num = (int)Math.Sqrt(s);
        for (int i = 2; i <= num; i++)
        {
            if (s % i == 0)
                return false;
        }
        return true;
    }
}