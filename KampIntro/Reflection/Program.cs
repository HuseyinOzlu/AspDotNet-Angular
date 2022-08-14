﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3); -->A
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 4));

            var type = typeof(DortIslem);

            /*DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type);  *///--A ile aynı çalışma anında yapar
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance = Activator.CreateInstance(type, 6, 7);

            MethodInfo methodInfo =  instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance,null));

            Console.ReadLine();
        }
    }

    class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public int Topla(int sayi1,int sayi2)
        { return sayi1 + sayi2; }
        public int Carp(int sayi1,int sayi2)
        { return sayi1 * sayi2;}
        public int Topla2()
        { return _sayi1 + _sayi2; }
        public int Carp2()
        { return _sayi1 * _sayi2; }

    }
}
