using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();// Delegetase elçidir. paramtre almaz ve bişey döndürmez 
    public delegate void MyDelegate2(string Message);
    public delegate int MyDelegate3(int numb1, int numb2);
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage; // Özel Elçi
            myDelegate += customerManager.ShowAlert; // +iki operasyonu birleştirdi

            myDelegate -= customerManager.SendMessage;
            myDelegate();
            

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("Hello");

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var result = myDelegate3(2, 3);
            Console.WriteLine(result);

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

            Console.WriteLine(getRandomNumber);
            Thread.Sleep(10);
            Console.WriteLine(getRandomNumber2);

            Console.ReadLine();
        }
    }
    public class CustomerManager
        {
            public void SendMessage()
            {
            Console.WriteLine("Hello");
            }
            public void ShowAlert()
            {
            Console.WriteLine("Be Careful");
            }
        public void SendMessage2(string message)
        {
            Console.WriteLine("Hello", message);
        }
        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }
    public class Matematik
    {
        public int Topla(int numb1, int numb2) 
        {
            return numb1 + numb2;
        }
        public int Carp(int numb1, int numb2)
        {
            return numb1 * numb2;
        }
    }
}
