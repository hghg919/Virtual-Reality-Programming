// See https://aka.ms/new-console-template for more information
int su, count, sum = 0;

count = 1;

Console.Write("누적합을 어디까지 구할까요 : ");
su = int.Parse(Console.ReadLine());

while(count <= su)  // 입력한 수까지 반복문 수행
{
    sum += count;
    count++;
}
Console.WriteLine(" > 1부터 " + su + "까지 누적 합계 : " + sum);
Console.WriteLine(" > 카운트 변수값 : " + count);