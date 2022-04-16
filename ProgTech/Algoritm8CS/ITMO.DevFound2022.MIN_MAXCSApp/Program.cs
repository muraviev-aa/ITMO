using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.DevFound2022.MIN_MAXCSApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int Finish = 99999;
            int Max = 9999;
            int Min = -9999;

            Console.WriteLine("Введите значение T");
            int T = int.Parse(Console.ReadLine());        

            while (T != Finish)
            {
                Finish --;
                if (T > Max)
                {
                    Max = T;
                }

                if (T < Min)
                {
                    Min = T;
                }

            }

            Console.WriteLine("Max " + Max);
            Console.WriteLine("Min " + Min);

        }
    }
}
