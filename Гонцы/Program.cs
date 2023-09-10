using System;
using System.Collections.Generic;

namespace Гонцы
{
    internal class Program
    {
        public static void Main(string [] args)
        {
            // Считываем количество городов из консоли
            int n = Convert.ToInt32(Console.ReadLine());
            // Создаём матрицу смежности
            int[,] graf = new int[n, n];
            // Считываем количество дорог из консоли в обоих направлениях.
            int m = Convert.ToInt32(Console.ReadLine());
            
            // Заполняем матрицу
            for (int i = 0; i < m; i++)
            {   // Из какого города идет дорога
                int city1 = Convert.ToInt32(Console.ReadLine()) - 1; // Вычитаем 1, чтобы индексы начинались с 0
                int city2 = Convert.ToInt32(Console.ReadLine()) - 1;
                // Заполняем матрицу смежности, предполагая, что дороги одинаково важны (значение 1)
                graf[city1, city2] = 1;
                graf[city2, city1] = 1;
                
            }
            // Считываем, из cтолицу из которой стартуем
            int capital = Convert.ToInt32(Console.ReadLine()) - 1;
            
            bool[] visited = new bool[n];
            visited[capital] = true; // Начинаем с столицы
            
            // Создали очередь для обхода городов
            Queue<int> queue = new Queue<int>();
            //начинаем с столицы
            queue.Enqueue(capital);
            //для подсчета недостижимых городов.
            int unreachableCount = 0;
            
            // до тех пор пока цикл не станет пустой
            while (queue.Count > 0)
            {
                // извлекаем каждый первый элемент из очереди
                int currentCity = queue.Dequeue();
                
                //цикл по всем городам (i)
                for (int i = 0; i < n; i++)
                {
                    //проверка есть ли дорога и посещен ли город ?
                    if (graf[currentCity, i] == 1 && !visited[i])
                    {
                        // город отмечается как посещенный 
                        visited[i] = true;
                        // город и добавляетсья в очередб для следующей обратоки 
                        queue.Enqueue(i);
                    }
                }
            }
            
            // Подсчет недостижимых городов
            for (int i = 0; i < n; i++)
            {
                //сли visited[i] равно false значит город не был посещен 
                if (!visited[i])
                {
                    unreachableCount++;
                }
            }
            
            Console.WriteLine(unreachableCount);

        }
        
    }
}