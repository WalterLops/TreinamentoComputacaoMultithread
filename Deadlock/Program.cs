using System;
using System.Threading;
using System.Diagnostics;

namespace Deadlock
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o teste de deadlock.");
            var stopwatch = Stopwatch.StartNew(); // Inicia um cronômetro para medir a duração do deadlock.
            try
            {
                SimulateDeadlock();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                stopwatch.Stop(); // Para o cronômetro após a conclusão ou falha
                Console.WriteLine($"Tempo total em deadlock: {stopwatch.ElapsedMilliseconds} ms");
            }
            
            Console.WriteLine("Programa concluído.");
        }

        private static void SimulateDeadlock()
        {
            var resource1 = new object();
            var resource2 = new object();

            var thread1 = new Thread(() =>
            {
                try
                {
                    lock (resource1)
                    {
                        Console.WriteLine("Thread 1 adquiriu o recurso 1");
                        Thread.Sleep(1000); // Espera para garantir que o deadlock ocorra
                        Console.WriteLine("Thread 1 tentando adquirir o recurso 2");
                        lock (resource2)
                        {
                            Console.WriteLine("Thread 1 adquiriu o recurso 2");
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Thread 1 cancelada: {e.Message}"); 
                }
            });

            var thread2 = new Thread(() =>
            {
                try
                {
                    lock (resource2)
                    {
                        Console.WriteLine("Thread 2 adquiriu o recurso 2");
                        Thread.Sleep(1000);
                        Console.WriteLine("Thread 2 tentando adquirir o recurso 1");
                        lock (resource1)
                        {
                            Console.WriteLine("Thread 2 adquiriu o recurso 1");
                        }
                    }
                }
                catch(Exception e)
                {
                   Console.WriteLine($"Thread 2 cancelada: {e.Message}"); 
                }
            });

            thread1.Start();
            thread2.Start();

            Thread.Sleep(4500); // Dá tempo suficiente para o deadlock ocorrer

            if (thread1.IsAlive && thread2.IsAlive) // Escopo de detecção de deadlock 
            {
                Console.WriteLine("Deadlock detectado!");
                Console.WriteLine("Tentando interromper os threads...");

                // Tentativa falha de resolver o deadlock
                thread1.Interrupt();
                thread2.Interrupt();

                Thread.Sleep(500); // Aguarda para ver se os threads conseguem se recuperar
                if (thread1.IsAlive || thread2.IsAlive)
                {
                    Console.WriteLine("Não foi possível resolver o deadlock automaticamente.");
                }
            }

            thread1.Join(); // Espera o thread 1 terminar
            thread2.Join(); // Espera o thread 2 terminar
        }
    }
}
