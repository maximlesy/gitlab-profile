using MaxxFluent.Domain;
using System;
using System.Collections.Generic;

namespace MaxxFluent
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCompletelyConfiguredApparment();

            CreateApparmentWithOnlyFloors();

            CreateApparmentWithDefaultParkingLot();

            //TryCreateAppartmentWithImpossibleConfigurationSteps();
        }
        private static void CreateCompletelyConfiguredApparment()
        {
            var appartment = AppartmentBuilder
                .CreateAppartment()
                .ConfigureFloors(configuration =>
                {
                    configuration.Add(new Floor { Capacity = 100, Surface = 200 });
                    configuration.Add(new Floor { Capacity = 200, Surface = 300 });
                })
                .HasParkingLot(true)
                .WithCapacity(5); // We used all possibilities of the building process, no need to call Build() method

            DisplayTitle("Fully configured apparment:");
            DisplayAppartment(appartment);
        }

        private static void CreateApparmentWithOnlyFloors()
        {
            var appartment = AppartmentBuilder
                .CreateAppartment()
                .ConfigureFloors(configuration =>
                {
                    configuration.Add(new Floor { Capacity = 10, Surface = 200 });
                    configuration.Add(new Floor { Capacity = 20, Surface = 300 });
                    configuration.Add(new Floor { Capacity = 30, Surface = 250 });
                })
                .Build();

            DisplayTitle("Appartment with only floors configured:");
            DisplayAppartment(appartment);
        }


        private static void CreateApparmentWithDefaultParkingLot()
        {
            var appartment = AppartmentBuilder
                .CreateAppartment()
                .ConfigureFloors(configuration =>
                {
                    configuration.Add(new Floor { Capacity = 44, Surface = 88 });
                    configuration.Add(new Floor { Capacity = 33, Surface = 66 });
                })
                .HasParkingLot(true)
                .Build();

            DisplayTitle("Appartment with default parking lot:");
            DisplayAppartment(appartment);
        }

        //private static void TryCreateAppartmentWithImpossibleConfigurationSteps()
        //{
        //    var appartment = AppartmentBuilder
        //        .CreateAppartment()
        //        .ConfigureFloors(configuration =>
        //        {
        //            configuration.Add(new Floor { Capacity = 44, Surface = 88 });
        //            configuration.Add(new Floor { Capacity = 33, Surface = 66 });
        //        })
        //        .WithCapacity(); // Impossible: missing HasParkingLot() call
        //        .Build();

        //    DisplayTitle("Appartment with default parking lot:");
        //    DisplayAppartment(appartment);
        //}

        private static void DisplayAppartment(Appartment appartment)
        {
            for (int i = 0; i < appartment.Floors.Count; i++)
            {
                Floor floor = appartment.Floors[i];
                Console.WriteLine($"floor {i}: surface {floor.Surface}m2, capacity: {floor.Capacity}");
            }

            Console.WriteLine($"Parking capacity: {appartment.ParkingLot?.Capacity ?? 0} \n");
        }

        private static void DisplayTitle(string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("===============================");
        }
    }
}
