// See https://aka.ms/new-console-template for more information
Random r = new Random();
int[] v = new int[13];

// 13개의 랜덤값 저장
for (int i = 0; i < v.Length; i++)
    v[i] = r.Next(100);    // 0~99까지 랜덤값

Console.WriteLine(" > 랜덤값 출력 ");
foreach (int a in v)
    Console.Write("{0, 5}", a);
Console.WriteLine();

// 랜덤값 총점 
int sum = 0;
for (int i = 0; i < v.Length; i++)
    sum += v[i];
Console.Write(" > 총점 : ");
Console.WriteLine("{0, 3}", sum);

// 랜덤값 평균
double avg = 0;
avg = (double)sum / v.Length;

Console.Write(" > 평균 : ");
Console.WriteLine("{0, 3}", avg);