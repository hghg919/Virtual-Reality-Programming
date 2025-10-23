// See https://aka.ms/new-console-template for more information
int score;

Console.Write("점수 입력: ");
score = int.Parse(Console.ReadLine());


if(score >= 90)
{
    Console.WriteLine(" > 입력한 점수 : " + score);
    Console.WriteLine(" > 등급 : A 학점 ");
}
else if(score >= 80)
{
    Console.WriteLine(" > 입력한 점수 : " + score);
    Console.WriteLine(" > 등급 : B 학점 ");
}
else if (score >= 70)
{
    Console.WriteLine(" > 입력한 점수 : " + score);
    Console.WriteLine(" > 등급 : C 학점 ");
}
else if (score >= 60)
{
    Console.WriteLine(" > 입력한 점수 : " + score);
    Console.WriteLine(" > 등급 : D 학점 ");
}
else

{
     Console.WriteLine(" > 입력한 점수 : " + score);
     Console.WriteLine(" > 등급 : F 학점 ");
}