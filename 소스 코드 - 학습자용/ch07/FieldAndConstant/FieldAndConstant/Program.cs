// See https://aka.ms/new-console-template for more information
class Owner
{
    public string name;                    // 인스턴스 필드 선언
}

class Exchange
{
    public static double P = 0.3025;       // 클래스 정적 필드 선언
    public const int Q = 100;              // 상수 선언

    public static double result = P * Q;   // 평방미터를 평으로 환산
}
class Program
{
    static void Main(string[] args)
    {
        Owner s = new Owner();    // Owner 클래스의 속성을 가진 객체 s 생성
        s.name = "홍길동";

        Console.WriteLine(" > 성명 : " + s.name);
        Console.WriteLine(" > 기준 : 1 평방미터 -> " + Exchange.P + " 평");
        Console.WriteLine(" > 대상 : " + Exchange.Q + " 평방미터");
        Console.WriteLine(" > 결과 : " + Exchange.result + " 평 ");
    }
}  