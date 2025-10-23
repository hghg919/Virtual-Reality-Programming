// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;  // CultureInfo 클래스 사용에 필요함

namespace DateTimeFormat
{
    class Solution
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;

            Console.WriteLine(today.
                ToString("오늘 : " + "yyyy년 MM월 dd일"));
            Console.WriteLine(string.
                Format("Format : " + "{0:yyyy년 MM월 dd일}",
                today));
            Console.WriteLine(today.
                ToString("미국식 : " + "MMMM dd, yyyy ddd",
                CultureInfo.CreateSpecificCulture("en-US")));

            Console.WriteLine(today.
                ToString("프랑스식 : " + "MMMM dd, yyyy ddd",
                new CultureInfo("fr-FR")));

            Console.WriteLine("d : " + 
                today.ToString("d"));

            Console.WriteLine("D : " + 
                string.Format("{0:D}", today));

            Console.WriteLine("t : " +
                string.Format("{0:t}", today));

            Console.WriteLine("T : " +
                string.Format("{0:T}", today));

            Console.WriteLine("g : " +
                string.Format("{0:g}", today));

            Console.WriteLine("G : " + 
                string.Format("{0:G}", today));

            Console.WriteLine("f : " +
                string.Format("{0:f}", today));

            Console.WriteLine("F : " + 
                string.Format("{0:F}", today));

            Console.WriteLine("s : " +
                string.Format("{0:s}", today));

            Console.WriteLine("o : " +
                string.Format("{0:o}", today));

            Console.WriteLine("O : " + 
                string.Format("{0:O}", today));

            Console.WriteLine("r : " +
                string.Format("{0:r}", today));

            Console.WriteLine("R : " +
                string.Format("{0:R}", today));

            Console.WriteLine("u : " +
                string.Format("{0:u}", today));
        }
    }
}