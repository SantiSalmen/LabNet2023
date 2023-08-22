using System;

namespace Practica2
{
    public class ExepcionCustomizada : Exception
    {
        private string mensaje;

        public ExepcionCustomizada(string mensaje) : base("Esta es una exepcion customizada")
        {
            this.mensaje = mensaje;
        }

        public string Mensaje()
        {


            return $"su mensaje es {mensaje}";
        }
    }
}

