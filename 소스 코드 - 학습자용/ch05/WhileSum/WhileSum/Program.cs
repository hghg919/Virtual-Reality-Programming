// See https://aka.ms/new-console-template for more information
int count, sum = 0;

count = 1;

while(count <= 100)
{
    sum += count;  // sum = sum + count;
    count++;       // 증감값
}
Console.WriteLine("while 반복문 종료 후 결과값 ");
Console.WriteLine(" > 누적 합계 : 1 + 2 + ... + 99 + 100 = " + sum);
Console.WriteLine(" > 카운트 변수값 : " + count);