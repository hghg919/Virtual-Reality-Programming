// See https://aka.ms/new-console-template for more information
int count, su, sum = 0;

Console.Write("누적합을 어디까지 구할까요 : ");
su = int.Parse(Console.ReadLine());

for(count = 1; count <= su; count++)
{
    sum += count;  // sum = sum + count;
}

Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
Console.WriteLine(" > 카운트 변수값 : " + count);