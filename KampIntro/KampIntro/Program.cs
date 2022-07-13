using System;


namespace KampIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            for(int i = 0; i < 10; i++) { Console.WriteLine(i); }
            String durum = 6 == 5 ? "esit" : "esit degil";
            Console.WriteLine(durum);
        }
    }
}
