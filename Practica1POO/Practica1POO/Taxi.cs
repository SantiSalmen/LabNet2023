namespace Practica1POO
{
    internal class Taxi : TransportePublico
    {
       
        public Taxi(int Pasajeros, int Id) : base(Pasajeros, Id)
        {

        }

        new public const int MaxPasajeros = 4;

        new public const int MinPasajeros = 1;

        new protected int Velocidad = 60;




        public override string Avanzar(int Pasajeros)
        {
            if (Pasajeros > (MaxPasajeros / 2))
            {
                Velocidad -= 5;
            }

            return $"Avanza a {Velocidad}km/h";
        }


        public override string ToString()
        {
            return $"El taxi_{Id} lleva {Pasajeros} pasajeros.";
        }
    }
}
