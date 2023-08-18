namespace Practica1POO
{
    internal class Omnibus : TransportePublico
    {

    public Omnibus(int Pasajeros, int Id) : base (Pasajeros, Id)
        {

            
        }


        public new const int MaxPasajeros = 100;

        public new const int MinPasajeros = 0;

        protected new int Velocidad = 60;


        public override string Avanzar(int Pasajeros)
        {
            if (Pasajeros > (MaxPasajeros / 2))
            {
                Velocidad -= 10;
            }
            return $"Avanza a {Velocidad}km/h";
        }

        public override string ToString()
        {
            return $"El Omnibus_{Id} lleva {Pasajeros} pasajeros.";
        }

        
    }
}
