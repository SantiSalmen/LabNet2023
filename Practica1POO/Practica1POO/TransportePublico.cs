namespace Practica1POO
{
    public abstract class TransportePublico
    {
        public TransportePublico(int Pasajeros, int Id)
        {
            this.Pasajeros = Pasajeros;

            this.Id = Id;
        }

        public int Pasajeros { get; }

        protected int Id {get;}

        protected int Velocidad { get; }

        protected int MaxPasajeros { get; }

        protected int MinPasajeros { get; }

        public abstract string Avanzar(int Pasajeros);


    }
}
