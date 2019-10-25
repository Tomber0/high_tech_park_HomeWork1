using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace high_tech_park_HomeWork1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Out.WriteLine("Введите номер нужной ф-ции: ");
            int chooseChosenNumber = Convert.ToInt32(Console.In.ReadLine());
            switch (chooseChosenNumber)
            {
                case 1:
                    firstSplitAndSum();
                    break;
                case 2:
                    secondBrickFitIntoHole();
                    break;
                case 3:
                    thirdSort();
                    break;
                default:
                    Console.Out.WriteLine("Проверьте ввод ");
                    break;
            }
            //TODO: 
            //1)сумма цифр числа +
            //2)определить: пролезет ли кирпич, заданный в 3 измерениях в прямоугольное отверстие, заданное в 2 измерениях +
            //3)сортировка + 

        }
        /// <summary>
        //разбивает число на цифры и находит их сумму
        /// </summary>
        static void firstSplitAndSum() {

            Console.Out.WriteLine("Введите число...");
            int rawNumber;
            int sum = 0;

            rawNumber = Convert.ToInt32(Console.In.ReadLine());
            int oldNumBuf = rawNumber;
            while (rawNumber > 0){

                sum += (rawNumber % 10);

                rawNumber /= 10;
            
            }
            Console.Out.WriteLine("Сумма цифр числа {0} равна  {1}", oldNumBuf,sum);
            
        }
        //проверяет входит ли кирпич в дырку
        static void secondBrickFitIntoHole() {
            //кирпич сможет пройти если хотябы 2 его размера меньше 2 сторон отверстия
            int[] brickSizes = new int[3];
            //int brickSizeL, brickSizeH, brickSizeW;
            int[] brickSizeArea = new int[3];
            Console.Out.WriteLine("Введите длину, ширину, высоту кирпича");
            for (int i = 0; i < 3; i++)
            {

                brickSizes[i] = Convert.ToInt32(Console.In.ReadLine());
                if (brickSizes[i] <= 0)
                {
                    Console.Out.WriteLine("Недопустимое значение! попробуйте еще раз");
                    i--;
                }
            }
            //полщади граней кирпича
            brickSizeArea[0] = brickSizes[0] * brickSizes[1];
            brickSizeArea[1] = brickSizes[0] * brickSizes[2];
            brickSizeArea[2] = brickSizes[1] * brickSizes[2];

            int holeSizeH = 0 , holeSizeV = 0;
            while (holeSizeH <=0)
            {
                Console.Out.WriteLine("Введите первую сторону отверстия");
                holeSizeH = Convert.ToInt32(Console.In.ReadLine());

                if (holeSizeH <= 0){
                    Console.Out.WriteLine("Проверьте ввод");
                    continue;
                }

            }
            while (holeSizeV <= 0)
            {
                Console.Out.WriteLine("Введите вторую сторону отверстия");
                holeSizeV = Convert.ToInt32(Console.In.ReadLine());

                if (holeSizeV <= 0)
                {
                    Console.Out.WriteLine("Проверьте ввод");
                    continue;
                }

            }

            //find 2 smallest sides of brick
            //Проверяем на входимость n вместо n^2

            int holeSquareSizeArea = holeSizeH * holeSizeV;
            for (int i = 0; i < brickSizeArea.Length; i++)
            {
                if (brickSizeArea[i] < holeSquareSizeArea)
                {
                    break;
                }
                else if (i + 1 == brickSizeArea.Length) {
                    Console.Out.WriteLine("Кирпич не сможет поместиться!");
                    return;//
                }
            }

            int[] smallestSidesOfBrick = new int[3];
            int bufFindSmallestSide = brickSizes[0];
            int[] brickSortBufferArray = brickSizes;
            int brickSortBuffer;
            //сортировка массива для нахождения 2 наименьших сторон
            for (int i = 0; i < brickSortBufferArray.Length; i++)
            {
                for (int j = 0; j < brickSortBufferArray.Length  - i - 1; j++)
                {
                    if (brickSortBufferArray[j] > brickSortBufferArray[j + 1])
                    { 
                        brickSortBuffer = brickSortBufferArray[j];
                    brickSortBufferArray[j] = brickSortBufferArray[j + 1];
                    brickSortBufferArray[j + 1] = brickSortBuffer;
                    }
                }

            }

            if (Math.Min(holeSizeH, holeSizeV) >= brickSortBufferArray[0] &&
                Math.Max(holeSizeH, holeSizeV) >= brickSortBufferArray[1])
                Console.Out.WriteLine("Кирпич помешается в отверстие");
            else
                Console.Out.WriteLine("Кирпич не помешается в отверстие");

        }
        static void thirdSort() {

            int[] mass = new int[] { 1, 23, 1, 13, 3 };

            Console.Out.WriteLine("Неотсортированный массив:");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Out.Write("{0}\t",mass[i]);
            }
            int buf;
            int size = mass.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (mass[j] > mass[j + 1])
                    {
                        buf = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = buf;
                    }
                }

            }
            Console.Out.WriteLine("\nПолученный массив: ");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Out.Write("{0}\t", mass[i]);
            }
            
        }
    }
}
