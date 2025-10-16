//See https://aka.ms/new-console-template for more information

//class student
//{
//    public int year, month, day;
//}

//class program
//{
//    static void Main(string[] args)
//    {
//        student sDay = new student();
//        sDay.year = 2035;
//        sDay.month = 3;
//        sDay.day = 2;

//        Console.Write("> 입학 일자 : ");
//        Console.Write(sDay.year + "/");
//        Console.Write(sDay.month + "/");
//        Console.WriteLine(sDay.day);
//    }
//}


//class Owner
//{
//    public string name;
//}

//class Exchange
//{
//    public static double P = 0.3025;
//    public const int Q = 100;

//    public static double result = P * Q;
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Owner s = new Owner();
//        s.name = "홍길동";

//        Console.WriteLine(" > 성명 : " + s.name);
//        Console.WriteLine(" > 기준 : 1 평방미터 -> " + Exchange.P + " 평");
//        Console.WriteLine(" > 대상 : " + Exchange.Q + " 평방미터");
//        Console.WriteLine(" > 결과 : " + Exchange.result + " 평 ");
//    }
//}


//class Solution
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine(" > 윤년 리스트 ");
//        for (int year = 2020; year <= 2050; year++)
//        {
//            if (IsLeapYear(year))
//            {
//                Console.Write("{0, 7}", year);
//            }
//        }
//        Console.WriteLine();
//    }

//    private static bool IsLeapYear(int year)
//    {
//        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
//    }
//}


//class Solution
//{
//    private int start;
//    public int width
//    {
//        get { return start; }
//        set
//        {
//            if (value > 0) { start = value; }
//            else
//            {
//                Console.WriteLine("시작 : 양의 정수만 입력");
//            }
//        }
//    }


//    private int end;
//    public int height
//    {
//        get { return end; }
//        set
//        {
//            if (value > 0) { end = value; }
//            else
//            {
//                Console.WriteLine("종료 : 양의 정수만 입력");
//            }
//        }
//    }

//    public Solution(int start, int end)
//    {
//        width = start;
//        height = end;
//    }

//    public int Area()
//    {
//        return this.width = this.height;
//    }

//    static void Main(string[] args)
//    {
//        Solution box = new Solution(-38, -23);
//        Console.WriteLine();

//        box.width = -73;
//        box.height = -88;
//    }
//}


//public class Box<T>
//{
//    private T item;

//    public void SetItem(T newItem)
//    {
//        item = newItem;
//    }
//    public T GetItem()
//    {
//        return GetItem();
//    }
//}

//class Progaram
//{
//    static void Main(string[] args)
//    {
//        Box<int> intBox = new Box<int>();
//        intBox.SetItem(10);
//        Console.WriteLine(intBox.GetItem());

//        Box<string> stringBox = new Box<string>();
//        stringBox.SetItem("Hello");
//        Console.WriteLine(stringBox.GetItem());
//    }
//}


//class Soultion
//{
//    static void Main(string[] args)
//    {
//        List<int> list = new List<int>() { 123, 35 ,78, 98};

//        Console.WriteLine(" > 리스트 요소 제거 전 ");
//        foreach (var item in list)
//        {
//            Console.WriteLine(" 요소 : {0, 3}", item);
//        }
//        Console.WriteLine(" > 리스트 요소 개수 : {0}", list.Count);
//        Console.WriteLine();

//        list.Remove(35);
//        Console.WriteLine(" > 리스트 요소 제거 후 ");
//        foreach (var item in list)
//        {
//            Console.WriteLine(" 요소 : {0, 3}", item);
//        }
//        Console.WriteLine(" > 리스트 요소 개수 : {0}", list.Count);
//    }
//}


//class Solution
//{
//    static void Main(string[] args)
//    {
//        Console.Write(" > -35의 Math.Abs : ");
//        Console.WriteLine(Math.Abs(-35));

//        Console.Write(" > (10,20)의 Math.Max : ");
//        Console.WriteLine(Math.Max(10,20));

//        Console.Write(" > (10,20)의 Math.Min : ");
//        Console.WriteLine(Math.Min(200, 300));

//        Console.Write(" > 23.5789의 Math.Round : ");
//        Console.WriteLine(Math.Round(23.5789));

//        Console.Write(" > 53.9563의 Math.Ceiling : ");
//        Console.WriteLine(Math.Round(53.9563));

//        Console.Write(" > 53.9563의 Math.Floor : ");
//        Console.WriteLine(Math.Floor(53.9563));
//    }
//}


//class Solution
//{
//    class Product
//    {
//        public static int count = 0;
//        public int id;
//        public string name;
//        public int price;

//        public Product(string name, int price)
//        {
//            Product.count = count + 1;
//            this.id = count;
//            this.name = name;
//            this.price = price;
//        }
//    }

//    static void Main(string[] args)
//    {
//        Product pA = new Product("세단", 3000);
//        Product pB = new Product("트럭", 2300);
//        Product pC = new Product("SCV", 3500);

//        Console.WriteLine(" " + pA.id + ":" + pA.name);
//        Console.WriteLine(" " + pB.id + ":" + pB.name);
//        Console.WriteLine(" " + pC.id + ":" + pC.name);

//        Console.WriteLine(" > 인스턴스 " + Product.count + "개 생성");
//    }
//}


//class Solution
//{
//    class Car
//    {
//        private void PrivateM()
//        {
//            Console.WriteLine("Car의 Private 메서드");
//        }
//        public void PublicM()
//        {
//            Console.WriteLine("Car의 Public 메서드");
//        }
//        protected void ProtectedM()
//        {
//            Console.WriteLine("Car의 Protected 메서드");
//        }

//    }
//}