//이진탐색

Random r = new Random();
int[] v = new int[10];

for (int i = 0; i < v.Length; i++)
    v[i] = r.Next(100);

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

Console.Write(" > 이진탐색 할 숫자 입력 : ");
int choice = int.Parse(Console.ReadLine());

int count = 0;
int low = 0;
int high = v.Length - 1;

while (low <= high)
{
    count++;
    int mid = (low + high) / 2;

    if (choice == v[mid])
    {
        Console.WriteLine(" > 인덱스 : [{0}] = {1}", mid, choice);
        Console.WriteLine(" > 탐색횟수 : {0}회", count);
        break;
    }
    else if (choice > v[mid])
        low = mid + 1;
    else
        high = mid - 1;
}