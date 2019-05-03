using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mass = new int[3, 3];
            int[,] winner = new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Random r = new Random();
            int[] except = new int[9] { 0, 1, 2 , 3, 4, 5 , 6, 7, 8 };
            int a = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    M: mass[i, j] = r.Next(9);

                    if (!except.Contains(mass[i, j]))
                    {
                        goto M;
                    }

                    while ((mass[i, j] != except[a]))
                    {           
                        if (a > 9)
                        {
                           break;
                        }
                        a++;
                    } 
                    Console.Write($"{mass[i, j]} ");
                    except[a] = 10;
                    a = 0;
                }
                Console.WriteLine();
            }

            Console.Write("Ввод:");
            int change;
            move:
   
                for (int i = 0; i < 3; i++)
                {                    
                    for (int j = 0; j < 3; j++)
                    {
                        if (mass[i, j] == 0)
                        {
                            switch (Console.ReadKey().KeyChar)
                            {
                                case 'w':
                                if(i!=2)
                                {  
                                change = mass[i, j];
                                mass[i, j] = mass[i + 1, j];
                                mass[i + 1, j] = change;
                                }
                               // if (i == 2)
                               // {
                                //    Console.WriteLine(" Неверный ход!");
                               // }
                                break;

                                case 's':
                                if (i != 0)
                                {
                                    change = mass[i, j];
                                    mass[i, j] = mass[i - 1, j];
                                    mass[i - 1, j] = change;
                                }
                               // if (i == 0)
                               // {
                                //    Console.WriteLine(" Неверный ход!");
                                //}
                                break;

                                case 'a':
                                if (j != 2)
                                {
                                    change = mass[i, j];
                                    mass[i, j] = mass[i, j+1];
                                    mass[i, j+1] = change;
                                }
                              //  if (j == 2)
                               // {
                               //     Console.WriteLine(" Неверный ход!");
                               // }
                                break;

                                case 'd':
                                if (j != 0)
                                {
                                    change = mass[i, j];
                                    mass[i, j] = mass[i, j - 1];
                                    mass[i, j - 1] = change;
                                }
                               // if (j == 0)
                               // {
                               //     Console.WriteLine(" Неверный ход!");
                               // }
                                break;
                            }  
                        }
                    }
                }

                Console.Clear();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"{mass[i, j]} ");
                    }
                    Console.WriteLine();
                }
            
                if (mass==winner)
                {
                   Console.WriteLine("Победа!");
                   Console.ReadKey();
                   Environment.Exit(0);
                }     

                Console.Write("Ввод:");
                goto move;
        }
    }
 }

