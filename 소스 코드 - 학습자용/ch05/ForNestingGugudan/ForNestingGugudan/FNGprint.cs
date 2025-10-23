// See https://aka.ms/new-console-template for more information
int dan, count, gob;

for (dan = 2; dan <= 9; dan++)
{
    for(count = 1; count <= 9; count++)
    {
        gob = dan * count;
        Console.WriteLine(dan + " * " + count + " = " + gob);
    }
    Console.WriteLine();
}