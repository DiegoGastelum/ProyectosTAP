using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int sumaTotal = 0;
    static object lockObject = new object();

    static void CalcularPrimos(object rango)
    {
        (int inicio, int fin) = ((int, int))rango;
        int suma = 0;

        for (int i = inicio; i <= fin; i++)
        {
            if (EsPrimo(i)) 
            {
                suma += i; // Si es primo, lo suma a la suma local del hilo
            }
        }

        // Se bloquea el acceso a la variable compartida para evitar problemas de concurrencia
        lock (lockObject)
        {
            sumaTotal += suma;
        }
    }

    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false; // Un número menor a 2 no es primo

        for (int i = 2; i * i <= numero; i++)
        {
            if (numero % i == 0) return false; // Si es divisible, no es primo
        }
        return true; 
    }

    static void Main()
    {
        // Solicita al usuario ingresar un número límite para el cálculo de primos
        Console.WriteLine("Ingrese el número límite:");
        int N = int.Parse(Console.ReadLine()); 

        int M = 4; // Define el número de hilos a utilizar
        int rango = N / M; 
        Thread[] hilos = new Thread[M];

        Stopwatch stopwatch = Stopwatch.StartNew();

        // Crea e inicia los hilos, dividiendo el rango de números en partes iguales
        for (int i = 0; i < M; i++)
        {
            int inicio = i * rango + 1; // Calcula el inicio del rango del hilo
            int fin = (i == M - 1) ? N : inicio + rango - 1; // Calcula el final del rango del hilo

            hilos[i] = new Thread(CalcularPrimos); 
            hilos[i].Start((inicio, fin)); // Inicia el hilo pasando el rango como argumento
        }

        // Espera a que todos los hilos terminen su ejecución
        foreach (var hilo in hilos)
        {
            hilo.Join();
        }

        stopwatch.Stop();
        Console.WriteLine($"Suma total de números primos hasta {N}: {sumaTotal}");
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
    }
}