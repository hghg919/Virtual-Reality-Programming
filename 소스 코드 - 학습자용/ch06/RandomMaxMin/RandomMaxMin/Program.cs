// See https://aka.ms/new-console-template for more information
Random r = new Random();
int[] v = new int[10];

// 10개의 랜덤값 저장
for (int i = 0; i < v.Length; i++) 
    v[i] = r.Next(100);    // 0~99까지 랜덤값

Console.WriteLine(" > 랜덤값 출력 ");
foreach (int a in v)
    Console.Write("{0, 5}", a);
Console.WriteLine();

// 랜덤값 중 최대값 
int max = v[0];
for(int i = 1; i < v.Length; i++)
    if(v[i] > max)
        max = v[i];
Console.Write(" > 최대값 : ");
Console.WriteLine("{0, 3}", max);

// 랜덤값 중 최소값
int min = v[0];
for (int i = 1; i < v.Length; i++)
    if (v[i] < min)
        min = v[i];
Console.Write(" > 최소값 : ");
Console.WriteLine("{0, 3}", min);