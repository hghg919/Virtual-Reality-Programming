// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>() { 123, 35, 78, 98 };

        Console.WriteLine(" > 리스트 요소 제거 전 ");
        foreach (var item in list)
        {
            Console.WriteLine(" 요소 : {0, 3}", item);
        }
        Console.WriteLine(" > 리스트 요소 개수 : {0}", list.Count);
        Console.WriteLine();

        list.Remove(35);  // 특정 요소 35를 리스트에서 제거
        Console.WriteLine(" > 리스트 요소 35 제거 후 ");
        foreach (var item in list)
        {
            Console.WriteLine(" 요소 : {0, 3}", item);
        }
        Console.WriteLine(" > 리스트 요소 개수 : {0}", list.Count);
    }
}