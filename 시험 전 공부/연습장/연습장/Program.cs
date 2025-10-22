// --- 문제 5 : For문과 If문 – 유통기한이 지난 제품 확인하기 ---
Console.Write("제품의 개수: ");
int productCount = int.Parse(Console.ReadLine());

// [수정] 코드는 완벽합니다. 수정할 필요 없습니다.
// 1부터 시작해서 productCount '이하(<=)'까지 반복 -> 좋습니다.
for (int i = 1; i <= productCount; i++)
{
    Console.Write($"{i}번째 제품의 유통기한(일): ");
    int daysLeft = int.Parse(Console.ReadLine());

    if (daysLeft <= 0) // 0일(오늘까지) 또는 마이너스(이미 지남)
    {
        Console.WriteLine($"{i}번째 제품은 유통기한이 지났습니다.");
    }
}