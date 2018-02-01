using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskOne
{
    class Program
    {
        static double count = 0;
        static void Main(string[] args)
        {
            double x, y;
            int size = 6;
            int[] arr = new int[size];

            try
            {
                FileStream fs = new FileStream("input.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string buf = sr.ReadLine();
                string[] mas = new string[size];
                mas = buf.Split(' ');
                for (int i = 0; i < mas.Length; i++)
                    arr[i] = Convert.ToInt32(mas[i]);
                sr.Close();
                fs.Close();
            }

            catch
            {
                Console.WriteLine("Файл input.txt не существует или его содержимое не удовлетворяет требованиям программы!");
                Console.ReadLine();
                return;
            }

            double AB = Math.Sqrt((arr[2] - arr[0]) * (arr[2] - arr[0]) + (arr[3] - arr[1]) * (arr[3] - arr[1]));
            double AC = Math.Sqrt((arr[0] - arr[4]) * (arr[0] - arr[4]) + (arr[1] - arr[5]) * (arr[1] - arr[5]));
            double BC = Math.Sqrt((arr[4] - arr[2]) * (arr[4] - arr[2]) + (arr[5] - arr[3]) * (arr[5] - arr[3]));

            if (AB >= AC + BC || AC >= AB + BC || BC >= BC + AC)
            {
                Console.WriteLine("Тр-ка не сущ-ет.");
                Console.ReadLine();
                return;
            }

            double xmax, xmin;

            if (arr[0] > arr[2])
            {
                xmax = arr[0];
                xmin = arr[2];
            }
            else
            {
                xmax = arr[2];
                xmin = arr[0];
            }

            for (x = xmin + 1; x < xmax; x++)
            {
                y = (x - arr[0]) * (arr[3] - arr[1]) / (arr[2] - arr[0]) + arr[1];
                if (y == Math.Round(y)) count++;
            }
            if (arr[0] == arr[2])
                count = count + Math.Abs(arr[1] - arr[3]) - 1;

            if (arr[0] > arr[4])
            {
                xmax = arr[0];
                xmin = arr[4];
            }
            else
            {
                xmax = arr[4];
                xmin = arr[0];
            }

            for (x = xmin + 1; x < xmax; x++)
            {
                y = (x - arr[4]) * (arr[1] - arr[5]) / (arr[0] - arr[4]) + arr[5];
                if (y == Math.Round(y)) count++;
            }
            if (arr[0] == arr[4])
                count = count + Math.Abs(arr[1] - arr[5]) - 1;

            if (arr[4] > arr[2])
            {
                xmax = arr[4];
                xmin = arr[2];
            }
            else
            {
                xmax = arr[2];
                xmin = arr[4];
            }

            for (x = xmin + 1; x < xmax; x++)
            {
                y = (x - arr[2]) * (arr[5] - arr[3]) / (arr[4] - arr[2]) + arr[3];
                if (y == Math.Round(y)) count++;
            }
            if (arr[4] == arr[2])
                count = count + Math.Abs(arr[5] - arr[3]) - 1;

            try
            {
                FileStream fs = new FileStream("output.txt", FileMode.Open);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(count + 3);
                sw.Close();
                fs.Close();
            }

            catch
            {
                Console.WriteLine("Файл output.txt не существует!");
                Console.ReadLine();
                return;
            }
        }
    }
}