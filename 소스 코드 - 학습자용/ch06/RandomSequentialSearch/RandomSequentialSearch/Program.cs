// See https://aka.ms/new-console-template for more information
Random r = new Random();
int[] v = new int[10];

// 10개의 랜덤값 저장
for (int i = 0; i < v.Length; i++)
    v[i] = r.Next(100);    // 0~99까지 랜덤값

Console.WriteLine(" > 정렬 전 랜덤값 ");
foreach (int a in v)
    Console.Write("{0, 5}", a);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine(" > 정렬 후 랜덤값 ");
Array.Sort(v);
foreach (int a in v)
    Console.Write("{0, 5}", a);

Console.WriteLine();
Console.WriteLine();

Console.Write(" > 순차탐색할 숫자 입력 : ");
int choice = int.Parse(Console.ReadLine());
int count = 0;    // 탐색 횟수

for (int i = 0; i < v.Length - 1; i++)
{
    count++;
    if(v[i] == choice)
    {
        Console.WriteLine(" > 인덱스 : [{0}] = {1}", i, choice);
        Console.WriteLine(" > 탐색 횟수 : {0}회", count);
        break;
    }
}