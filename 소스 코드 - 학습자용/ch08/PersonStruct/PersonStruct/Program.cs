// See https://aka.ms/new-console-template for more information
struct Person
{
    public int year, month, day;
}

class Program
{
    static void Main(string[] args)
    {
        Person pDay;
        pDay.year = 2020;
        pDay.month = 12;
        pDay.day = 25;

        Console.Write(" > 생년월일 : ");
        Console.Write(pDay.year + "/");
        Console.Write(pDay.month + "/");
        Console.WriteLine(pDay.day);
    }
}