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

Console.Write(" > 이진탐색할 숫자 입력 : ");
int choice = int.Parse(Console.ReadLine());

int count = 0;    // 탐색 횟수
int low = 0;
int high = v.Length - 1;

while(low <= high)
{
    count++;
    int mid = (low + high) / 2;   // 중간 위치 산출

    if (choice == v[mid])
    {
        Console.WriteLine(" > 인덱스 : [{0}] = {1}", mid, choice);
        Console.WriteLine(" > 탐색 횟수 : {0}회", count);
        break;
    }
    else if (choice > v[mid])   // 중간 배열 요소값보다 클 경우
        low = mid + 1;
    else                        // 값을 찾지 못하거나 중간 배열 요소 값보다 크지 않을 경우
        high = mid - 1;         // high 변수값을 새로운 값으로 설정
}