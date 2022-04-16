using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.DevFound2022.StrengthCSApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "no";
            do
            {
                Console.WriteLine("Введите значение N в т");
                double N = double.Parse(Console.ReadLine());         //Растягивающее усилие

                Console.WriteLine("Введите значение Mx в т*см");
                double Mx = double.Parse(Console.ReadLine());        //Изгибающий момент относительно оси x-x

                Console.WriteLine("Введите значение My в т*см");
                double My = double.Parse(Console.ReadLine());        //Изгибающий момент относительно оси y-y

                Console.WriteLine("Введите значение yc");
                double yc = double.Parse(Console.ReadLine());        //Коэффициент условий работы

                Console.WriteLine("Введите значение Ry в т/см2");
                double Ry = double.Parse(Console.ReadLine());        //Расчетное сопротивление стали

                double An = 27.17f;                                  //Площадь сечения нетто двутавра 20Б1
                double Wx = 184.4f;                                  //Момент сопротивления сечения относительно оси x-x
                double Wy = 26.78f;                                  //Момент сопротивления сечения относительно оси y-y
                double Cx = 1.049f;                                  //Коэф. для двутавра 20Б1 по табл. Е1 СП 16.13330.2017
                double Cy = 1.47f;                                   //Коэф. для двутавра 20Б1 по табл. Е1 СП 16.13330.2017
                double n = 1.5f;                                     //Коэф. для двутавра 20Б1 по табл. Е1 СП 16.13330.2017
                double R = 4.48f;                                    //Расчетное сопротивление для сравнения из условия


                if (Ry <= R & N / (An * Ry) > 0.1)
                {
                    double a = Math.Pow((N / (An * yc)), n) + (Mx / (Cx * Wx * yc)) + (My / (Cy * Wy * yc)); //Учет пластической работы стали

                    if (a <= Ry)
                    {
                        Console.WriteLine("Прочность обеспечена. Нормальные напряжения " + a + " т/см2");
                    }
                    else
                    {
                        Console.WriteLine("Прочность не обеспечена. Нормальные напряжения " + a + " т/см2");
                    }
                }
                else
                {
                    double a = ((N / An) + (Mx / Wx) + (My / Wy)) * yc;                                    //Учет упругой работы стали

                    if (a <= Ry)
                    {
                        Console.WriteLine("Прочность обеспечена. Нормальные напряжения " + a + " т/см2");
                    }
                    else
                    {
                        Console.WriteLine("Прочность не обеспечена. Нормальные напряжения " + a + " т/см2");
                    }
                }

                Console.WriteLine("Продолжать?");
                repeat = Console.ReadLine();
            }
            while (repeat != "no");

        }
    }
}
