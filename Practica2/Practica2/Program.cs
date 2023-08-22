using System;
using Practica2.Excepciones;
using Practica2.Extensions;

namespace Practica2
{
    class Program 
    {
        static void Main(string[] args)
        {
            int dividendo1 = 0;
            double dividendo2, divisor;
            bool seguir = true;

            Console.WriteLine("Ejercicio n°1\n");
            while (seguir)
            {

                Console.WriteLine("Introduzca un numero para que este sea dividido por 0");
                try
                {
                    dividendo1 = int.Parse(Console.ReadLine());
                    seguir = false;

                }
                catch (FormatException)
                {

                    Console.WriteLine("Eso no es un numero!"); 
                }
                
            }
            

            Console.WriteLine(dividendo1.Dividir());

            Console.WriteLine("\nEjercicio n°2\n");

            Console.WriteLine("A continuación introuzca dos numero,primero el dividendo y luego el divisor");



            try
            {
                dividendo2 = double.Parse(Console.ReadLine());
                divisor = double.Parse(Console.ReadLine());
                Console.WriteLine(dividendo2.Dividir(divisor));

            }
            catch (Exception)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }

            Console.WriteLine("\nEjercicio n°3\n");

            try
            {
                Logica.Excepcion(null, 3);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("\nEjercicio n°4\n");

            try
            {
                Logica.ExcepcionCustom();
            }
            catch (ExepcionCustomizada e)
            {
                
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Mensaje());
            }


            Console.ReadKey();

        }
    }
}
