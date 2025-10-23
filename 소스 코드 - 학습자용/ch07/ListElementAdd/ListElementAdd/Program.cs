// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();

        // 리스트에 요소 추가
        list.Add(23);
        list.Add(85);
        list.Add(16);
        list.Add(95);

        Console.WriteLine(" > 반복문으로 요소 출력 ");
        foreach(var item in list)
        {
            Console.WriteLine(" 요소 : {0}", item);
        }
        Console.WriteLine(" > 리스트 요소 개수 : {0}", list.Count);
    }
}