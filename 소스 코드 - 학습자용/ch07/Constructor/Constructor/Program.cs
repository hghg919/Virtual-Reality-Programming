// See https://aka.ms/new-console-template for more information
class Solution
{
    class Product
    {
        public static int count = 0;
        public int id;
        public string name;
        public int price;

        public Product(string name, int price)
        {
            Product.count = count + 1;  // 생성자에서 카운트
            this.id = count;     // this 키워드는 클래스 자신을 의미
            this.name = name;    // 자신의 이름
            this.price = price;  // 자신의 가격
        }
    }

    static void Main(string[] args)
    {
        Product pA = new Product("세단", 3000);
        Product pB = new Product("트럭", 2300);
        Product pC = new Product("SCV", 3500);

        Console.WriteLine(" " + pA.id + ":" + pA.name);
        Console.WriteLine(" " + pB.id + ":" + pB.name);
        Console.WriteLine(" " + pC.id + ":" + pC.name);

        Console.WriteLine(" > 인스턴스 " + Product.count + "개 생성");
    }
}