using System;

namespace Practica2.Excepciones
{
    public class Logica
    {
        public static void Excepcion(int? a, int b) 
        {

				int result = a.Value + b;
			
        }

		public static void ExcepcionCustom() 
		{

			throw new ExepcionCustomizada("Alakazam");

        }
    }
}
