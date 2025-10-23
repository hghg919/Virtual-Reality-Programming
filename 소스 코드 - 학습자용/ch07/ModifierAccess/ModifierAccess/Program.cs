// See https://aka.ms/new-console-template for more information
class Solution
{
    class Car
    {
        private void PrivateM() { }
        public void PublicM() { }
        protected void ProtectedM() { }

        public void TestA()  // 자신의 클래스에서는 모두 사용 가능
        {
            PrivateM();
            PublicM();
            ProtectedM();    
        }
    }
    class Sedan : Car        // Car 클래스를 상속 받음
    {
        public void TestB()
        {
            // private 접근 제한자는 자신의 클래스에서만 사용 가능
            PublicM();
            ProtectedM();      
        }
    }
    
    static void Main(string[] args)
    {
        Sedan sd = new Sedan();
        sd.PublicM();   // Car 클래스 외부에서는 public 만 허용
    }
}