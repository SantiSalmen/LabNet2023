using System;

namespace Practica2.Extensions
{
    public static class DivisionesExtensions
    {

        public static int Dividir(this int dividendo2, int divisor)
        {
            int resultado;
            try
            {
                return resultado = dividendo2 / divisor;
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("Intentaste dividir por 0...estás bien?");
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                Console.WriteLine("La operacón fue realizada");
            }

        }

        public static int Dividir(this int dividendo1)
        {
            try
            {
                return dividendo1 / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);

                return -1;
            }
            finally
            {
                Console.WriteLine("La operacón fue realizada");
            }


        }
    }
}