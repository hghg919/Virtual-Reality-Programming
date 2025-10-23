// See https://aka.ms/new-console-template for more information
Random r = new Random();
int[] a = new int[6];

// 6개의 랜덤값 생성하여 저장 
for (int i = 0; i < 6; i++)
{
    a[i] = r.Next(1, 46);
}

Console.WriteLine(" > 생성된 6개의 랜덤 숫자 출력 ");
foreach (int value in a)
{
    Console.Write("{0, 8}", value);  // 5자리로 출력
}