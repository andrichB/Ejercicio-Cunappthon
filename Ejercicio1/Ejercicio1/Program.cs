using System.Diagnostics;
using System;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {//Nota personal: esto es una retroalimentación y "corrección" del desastre lógico, crítico y técnico que fuí en Bogotá. Sigo pensado que no merezco el premio y más que ganar me regalaron la beca
            Console.WriteLine("Leéme, no seas flojo: \n\nJuan y María están jugando pares e impares (ambos sacan al tiempo con los dedos de la mano entre 0 y 5 dedos,\ndependiendo de la sumatoria gana uno o el otro) María elige impares y Juan pares. A medida de que van jugando\nse anota los resultados de María en tarjetas rojas y los de Juan en tarjetas azules.\nEl problema está en que el imbécil de Juan deja caer las tarjetas y ahora no sabemos el orden.\nNuestra tarea es determinar cuantas veces con certeza gana María.\n\nAhora he aquí el fruto de la frustración,la desesperación y el autodesprecio.\n");
            bool bandera = true;
            do
            {
                int numeroDeJuegos = 0, contadorMaria = 0, contadorJuan = 0;

                Console.WriteLine("Ingrese el numero de veces jugadas");
                numeroDeJuegos = esNumero(0,100, "El numero debe ser entre 0 y 100 (0 es para salir)");
                
                if (numeroDeJuegos != 0)
                {
                    //Llenar datos María
                    Console.WriteLine("Ingrese los resultados de María separados por un salto de linea (enter)");

                    int[] juegoMaria = new int[numeroDeJuegos];

                    for (int i = 0; i < numeroDeJuegos; i++)
                    {
                        juegoMaria[i] = esNumero(0,6, "El dato debe ser entre 0 y 6.");
                    }
                    //Llenar datos Juan
                    Console.WriteLine("Ingrese los resultados de Juan separados por un salto de linea (enter)");

                    int[] juegoJuan = new int[numeroDeJuegos];
                    for (int i = 0; i < numeroDeJuegos; i++)
                    {
                        juegoJuan[i] = esNumero(0,6,"El dato debe ser entre 0 y 6.");
                    }
                    //Maria posiblemente gana
                    for (int i = 0; i < numeroDeJuegos; i++)
                    {
                        if (juegoMaria[i] % 2 != 0)
                        {
                            contadorMaria++;
                        }
                    }
                    //Juan posiblemente gana
                    for (int i = 0; i < numeroDeJuegos; i++)
                    {
                        if (juegoJuan[i] % 2 == 0)
                        {
                            contadorJuan++;
                        }
                    }
                    contadorMaria = contadorJuan - contadorMaria;
                    if (contadorMaria < 0)// Esto es un truquito por si el resultado da negativo BUM!!! ahora es 0 y el usuario no quede: WTF?!!!!
                    {
                        contadorMaria = 0;
                    }
                    Console.WriteLine($"María como mínimo ganó {contadorMaria} veces"); // Aquí reciclo una variable para mostrar el resultado
                    Console.Write("Para dejar de usar el software escriba 0, ó. ");
                }
                else
                {
                    bandera = false;
                }
            } while (bandera);
            Console.WriteLine("\nQuien diría que con esto se puede llegar a ganar una especialización completa (º-º )\nEste código fue retocado porque el original era tremenda shit\n\nAndrich del futuro si ves esto, espero ahora seas un programador competente y si no, aplica la de Canserbero.\nEscribe 'si' para ver la referencia.");
            string url = "https://www.youtube.com/shorts/hgR9zEPQauk";
            
            if (Console.ReadLine().ToLower()=="si") {
                try
                {
                    Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "index.html");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nFuck, no abre el navegador.\nSi quieres ver el video para entender el chiste aquí está el link:\n --> {url} <--");
                }
            }
            else
            {
                Console.WriteLine("Bueno allá tu. Presiona enter para cerrar.");
            }
        }
         public static int esNumero(int menorQUe, int mayorQue, string mensajeError) // Verifica que el numero ingresado sea número y cumpla con los parámetros requeridos
        {
            int retornar = 0;
            bool bandera = false;
            do
            {
                try
                {
                    retornar = Convert.ToInt32(Console.ReadLine());
                    if (retornar < menorQUe || retornar > mayorQue)
                    {
                        bandera = true;
                        Console.WriteLine($"{mensajeError}\nVuelve a intentarlo.");
                    }
                    else
                    {
                        bandera = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lo que ingresaste no es un número entero.\nVuelve a intentarlo.");
                    bandera = true;
                }
            } while (bandera);
           return retornar;
        }
    }
}
