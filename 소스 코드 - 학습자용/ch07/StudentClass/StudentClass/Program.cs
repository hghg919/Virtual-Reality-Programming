// See https://aka.ms/new-console-template for more information
class Student
{
    public int year, month, day;
}

class Program
{
    static void Main(string[] args)
    {
        Student sDay = new Student();
        sDay.year = 2035;
        sDay.month = 3;
        sDay.day = 2;

        Console.Write(" > 입학 일자 : ");
        Console.Write(sDay.year + "/");
        Console.Write(sDay.month + "/");
        Console.WriteLine(sDay.day);
    }
}