// See https://aka.ms/new-console-template for more information
int dan, count, gob;

Console.Write("출력할 구구단 : ");
dan = int.Parse(Console.ReadLine());

if (dan < 2 || dan > 99)
{
    Console.WriteLine(" > 유효하지 않은 데이터값! ");
    Console.WriteLine(" > 프로그램 종료! ");
}
else
{
    for (count = 1; count <= 9; count++)
    {
        gob = dan * count;
        Console.WriteLine(dan + " * " + count + " = " + gob);
    }
}