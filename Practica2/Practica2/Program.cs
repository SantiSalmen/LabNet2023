using System;
using Practica2.Excepciones;

namespace Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dividendo, divisor;

            Console.WriteLine("Introduzca un numero para que este sea dividido por 0");

            dividendo = int.Parse(Console.ReadLine()); 

            DividirCero(dividendo);

            Console.WriteLine("A continuación introuzca dos numero,primero el dividendo y luego el divisor");



            try
            {
                dividendo = int.Parse(Console.ReadLine());
                divisor = int.Parse(Console.ReadLine());
                Dividir(dividendo, divisor);

            }
            catch (Exception)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }


            try
            {
                Logica.Excepcion(null, 3);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


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

       private static int DividirCero(int dividendo)
        {
            try
            {
                return dividendo /= 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);

                return-1;
            }
            finally
            {
                Console.WriteLine("La operacón fue realizada");
            }


        }
            
        public static double Dividir(int dividendo, int divisor) 
        {
            double resultado;
            try
            {
               return resultado = dividendo / divisor;
            }
            catch (DivideByZeroException ex)
            {   

                //TODO : Mensaje creativo
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                return-1;
            }
            finally
            {
                Console.WriteLine("La operacón fue realizada");
            }
      
        }
    
    }
}
