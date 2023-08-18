using System;
using System.Collections.Generic;

namespace Practica1POO
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<TransportePublico> transportePublicos = new List<TransportePublico>();

            Console.WriteLine(" Usted tiene a su disposición 5 Omnibus y 5 Taxis, por favor, indique por que medio de transporte desea comenzar.");

            int TipoVehiculo = SeleccionarVehiculo();

           
            if (TipoVehiculo == 1)
            {
                IngresarTaxis(false, transportePublicos, Taxi.MaxPasajeros, Taxi.MinPasajeros);

                IngresarOmnibus(true, transportePublicos,Omnibus.MaxPasajeros, Omnibus.MinPasajeros);
            } 
            
            else
            {
                IngresarOmnibus(false, transportePublicos, Omnibus.MaxPasajeros, Omnibus.MinPasajeros);

                IngresarTaxis(true, transportePublicos,Taxi.MaxPasajeros, Taxi.MinPasajeros);
            }


            Console.WriteLine("A continuación se le mostrará la lista con todos los vehiculos y sus respectivos pasajeros, además,, de su velocidad."); 

            MostrarLista(transportePublicos);


            Console.WriteLine("\n Gracias por prestarnos su servicio, presione una tecla para salir del programa");

            Console.ReadKey();

        }

        private static void MostrarLista(List<TransportePublico> transportePublicos)
        {
            string Velocidad;
            foreach (var item in transportePublicos)
            {
                Velocidad = item.Avanzar(item.Pasajeros);
                Console.WriteLine( item + " " + Velocidad);
            }
        }

        private static void IngresarOmnibus(bool IngresoTaxi, List<TransportePublico> transportePublicos, int MaxPasajeros, int MinPasajeros)
        {
            int Cont = 1;
            int NumPasajeros = 0;
            int NumRequerido = 5;
            if (IngresoTaxi)
            {
                Console.WriteLine(" Ahora vamos con los Omnibus, a continuación, indique la cantidad de pasajeros que llevará en cada uno");
            }
            else
            {
                Console.WriteLine(" Usted ha seleccionado Omnibus, a continuación, indique la cantidad de pasajeros que llevará en cada uno");
            }

            Console.WriteLine($" Recuerde que estos vehiculos tienen una capaciad maxima de {MaxPasajeros} pasajeros cada uno.");

            while (Cont <= NumRequerido)
            {
                Console.WriteLine("Ingrese Omnibus {0}", Cont);

                try
                {
                    NumPasajeros = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }

                if (NumPasajeros <= MaxPasajeros && NumPasajeros >= MinPasajeros)
                {
                    transportePublicos.Add(new Omnibus(NumPasajeros,Cont));
                    
                    Cont++;
                }
                else
                {
                    Console.WriteLine("Ingrese un numero valido");
                }

            }
        }
         

        private static void IngresarTaxis(bool IngresoOmnibus, List<TransportePublico> transportePublicos, int MaxPasajeros, int MinPasajeros)
        {
            int Cont = 1;
            int NumPasajeros = 0;
            int NumRequerido = 5;

            if (IngresoOmnibus)
            {
                Console.WriteLine(" Ahora vamos con los Taxis, a continuación, indique la cantidad de pasajeros que llevará en cada uno");
            }
            else
            {
                Console.WriteLine(" Usted ha seleccionado Taxi, a continuación, indique la cantidad de pasajeros que llevará en cada uno");
            }
            Console.WriteLine(" Recuerde que estos vehiculos tienen una capaciad maxima de 4 pasajeos cada uno.");

            while (Cont <= NumRequerido)
            {
                Console.WriteLine("Ingrese Taxi {0}", Cont);

                try
                {
                    NumPasajeros = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }

                if (NumPasajeros <= MaxPasajeros && NumPasajeros >= MinPasajeros)
                {
                    transportePublicos.Add(new Taxi(NumPasajeros,Cont));
                    Cont++;
                }
                else
                {
                    Console.WriteLine("Ingrese un numero valido");
                }

            }

        }

        private static int SeleccionarVehiculo()
        {
            int TipoVehiculo = 0;
            while (TipoVehiculo == 0)
            {

                Console.WriteLine(" Taxi = 1  Omnibus = 2");
                try
                {
                    TipoVehiculo = int.Parse(Console.ReadLine());

                    if (TipoVehiculo < 1 || TipoVehiculo > 2)
                    {
                        Console.WriteLine("No existe ese vehiculo");
                        TipoVehiculo = 0;
                    }
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }

            }

            return TipoVehiculo;
        }
    }
}
