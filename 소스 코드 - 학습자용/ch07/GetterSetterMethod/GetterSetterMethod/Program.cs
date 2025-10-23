// See https://aka.ms/new-console-template for more information
class Solution
{
    private int start;    // 멤버 변수 생성
    public int width      // 속성 생성
    {
        get { return start; }
        set 
        {
            if (value > 0) { start = value; }
            else 
            { 
                Console.WriteLine("시작 : 양의 정수만 입력 "); 
            }
        }
    }

    private int end;     // 멤버 변수 생성
    public int height    // 속성 생성
    {
        get { return end; }
        set
        {
            if (value > 0) { end = value; }
            else
            {
                Console.WriteLine("종료 : 양의 정수만 입력 ");
            }
        }
    }

    public Solution(int start, int end)  // 생성자 생성
    {
        width = start;
        height = end;
    }

    // 인스턴스 메서드
    public int Area()
    {
        return this.width = this.height;
    }

    static void Main(string[] args)
    {
        Solution box = new Solution(-38, -23);
        Console.WriteLine();

        box.width = -73;
        box.height = - 88;
    }
}