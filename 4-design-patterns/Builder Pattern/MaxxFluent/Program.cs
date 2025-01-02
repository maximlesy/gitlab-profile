using MaxxFluent.Domain;
using System;
using System.Collections.Generic;

namespace MaxxFluent
{
    class Program
    {
        static void Main(string[] args)
        {

            var appartment = AppartmentBuilder
                .CreateAppartment()
                .ConfigureFloors(configuration =>
                {
                    configuration.Add(new Floor { Capacity = 100, Surface = 200 });
                    configuration.Add(new Floor { Capacity = 200, Surface = 300 });
                })
                .HasParkingLot(true)
                .WithCapacity(5);

            for (int i = 0; i < appartment.Floors.Count; i++)
            {
                Floor floor = appartment.Floors[i];
                Console.WriteLine($"floor {i}: surface {floor.Surface}m2, capacity: {floor.Capacity}");
            }

            Console.WriteLine($"Parking capacity: {appartment.ParkingLot?.Capacity ?? 0}");
        }
    }
}
