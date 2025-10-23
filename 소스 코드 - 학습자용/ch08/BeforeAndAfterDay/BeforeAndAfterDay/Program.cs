// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(" > 오늘 : {0}", DateTime.Today);

        DateTime y = DateTime.Today.AddDays(-1);  // 어제
        Console.WriteLine(" > 어제 : {0}", y.ToShortDateString());

        DateTime t = DateTime.Today.AddDays(+1);  // 내일
        Console.WriteLine(" > 내일 : {0}", t.ToShortDateString());
    }
} 