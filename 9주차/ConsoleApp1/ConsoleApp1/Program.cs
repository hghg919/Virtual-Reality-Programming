//DateTime now = DateTime.Now;
//Console.WriteLine("로컬 시간 : " + now);

//DateTime utc = now.ToUniversalTime();
//Console.WriteLine("UTC 시간 : " + utc);

//DateTime backToLocal = now.ToLocalTime();
//Console.WriteLine("다시 로컬 시간으로 변환 : " + backToLocal);


//class Solution
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine(" > 오늘 : {0}", DateTime.Today);

//        DateTime y = DateTime.Today.AddDays(-1);
//        Console.WriteLine(" > 어제 : {0}",y.ToShortDateString());

//        DateTime t = DateTime.Today.AddDays(+1);
//        Console.WriteLine(" > 내일 : {0}", t.ToShortDateString());
//    }
//}


//class Solution
//{
//    static void Main(string[] args)
//    {
//        DateTime d1 = new DateTime(2000, 3, 2, 9, 30, 0);
//        DateTime d2 = new DateTime(2035, 12, 25, 23, 59, 38);

//        Console.WriteLine(" > 입사일자 : {0}", d1);
//        Console.WriteLine(" > 경력기준 : {0}", d2);

//        Console.WriteLine(" > {0}과 {1}의 차이는 {2} 일입니다.",
//            d1.ToString("yyyy년 MM월 dd일"),
//            d2.ToString("yyyy년 MM월 dd일"),
//            d2.Subtract(d1).Days);
//    }
//}


//class Solution
//{
//    static void Main(string[] args)
//    {
//        DateTime sT = new DateTime(2023, 3, 15, 10, 33, 0);
//        DateTime eT = new DateTime(2023, 3, 20, 7, 15, 0);
//        TimeSpan tTime = eT - sT;
//        Console.WriteLine(" > 2023. 3. 15 ~ 2023. 3. 20일의 시간 간격");
//        Console.WriteLine(" > 여행기간 : {0, 10}", tTime);
//        Console.WriteLine(" {0, 14} 일", tTime.Days);
//        Console.WriteLine(" {0, 14} 시간", tTime.TotalHours);
//        Console.WriteLine(" {0, 14} 분", tTime.TotalMinutes);
//        Console.WriteLine(" {0, 14} 초", tTime.TotalSeconds);
//    }
//}


//using System;
//using System.Globalization;

//namespace DateTimeFormat
//{
//    class Solution
//    {
//        static void Main(string[] args)
//        {
//            DateTime today = DateTime.Now;

//            Console.WriteLine(today.
//                ToString("오늘 : " + "yyyy년 MM월 dd일") );
//            Console.WriteLine(string.
//                Format("Format : " + "{0:yyyy년 MM월 dd일}",
//                today));
//            Console.WriteLine(today.
//                ToString("미국식 : " + "MMMM dd, yyyy ddd",
//                CultureInfo.CreateSpecificCulture("en-us")));

//            Console.WriteLine(today.
//                 ToString("프랑스식 : " + "MMMM dd, yyyy ddd",
//                 new CultureInfo("fr-FR")));

//            Console.WriteLine("d : " +
//                today.ToString("d"));

//            Console.WriteLine("D : " +
//                string.Format("{0:D}", today));

//            Console.WriteLine("t : " +
//                string.Format("{0:t}", today));

//            Console.WriteLine("T : " +
//                string.Format("{0:T}", today));

//            Console.WriteLine("g : " +
//                string.Format("{0:g}", today));
//        }
//    }
//}


