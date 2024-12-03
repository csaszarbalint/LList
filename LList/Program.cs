using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LList
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[]
            {
                "Anna", "Balázs", "Bence", "Barbara", "Dániel",
                "Eszter", "Gábor", "Gabriella", "István", "József",
                "Katalin", "Krisztián", "László", "Lilla", "Máté",
                "Nóra", "Réka", "Tamás", "Veronika", "Zoltán"
            };
            var list = new LinkedList<string>();

            foreach (var name in names)
            {
                list.Add(name);
            }

            Console.WriteLine(list);

            list.Insert(0, "Aladár");
            var ix = list.IndexOf("Lilla");
            list.Insert(ix, "Miklós");
            list.Insert(-1, "Zsófia");
            Console.WriteLine(list);

            list.Remove("Miklós");
            Console.WriteLine(list);

            ix = list.IndexOf("Lilla");
            list.RemoveAt(ix);
            Console.WriteLine(list);

        }
    }
}
