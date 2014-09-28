using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(3);
            Console.WriteLine(list);
            Console.WriteLine();

            list[4] = 5;
            Console.WriteLine(list);
            Console.WriteLine();

            list.Add(-5);
            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine("list[2] = " + list[2]);
            Console.WriteLine();

            list.RemoveByIndex(1);
            Console.WriteLine(list);
            Console.WriteLine();

            list.Insert(20, 8);
            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine(list.IndexOf(5));
            Console.WriteLine();
            Console.WriteLine(list.Contains(5));
            Console.WriteLine();

            Console.WriteLine("Max = " + list.Max());
            Console.WriteLine();
            Console.WriteLine("Min = " + list.Min());
            Console.WriteLine();

            list.Clear();
            Console.WriteLine(list);
            Console.WriteLine();

            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("GenericList's version is {0}", ((VersionAttribute)allAttributes[0]).Version);
            Console.WriteLine();
        }
    }
}
