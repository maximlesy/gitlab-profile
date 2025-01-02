using MaxxFluent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxxFluent.Domain
{
    public class AppartmentBuilder : IFloorsStage, IParkingLotStage, IParkingLotCapacityStage
    {
        private List<Floor> floors;
        private bool hasParkingLot;
        private int parkingLotCapacity;

        private AppartmentBuilder() 
        {
            floors = new List<Floor>();
            hasParkingLot = false;
            parkingLotCapacity = 10;
        }

        public static IFloorsStage CreateAppartment()
        {
            return new AppartmentBuilder();
        }

        
        public IParkingLotStage ConfigureFloors(Action<List<Floor>> floors)
        {
            List<Floor> floorsToCreate = new List<Floor>();
            floors?.Invoke(floorsToCreate);
            this.floors = floorsToCreate;
            return this;
        }

        public IParkingLotCapacityStage HasParkingLot(bool hasParkingLot)
        {
            this.hasParkingLot = hasParkingLot;
            return this;
        }

        public Appartment WithCapacity(int capacity)
        {
            this.parkingLotCapacity = capacity;
            return Build();
        }

        public Appartment Build()
        {
            return new Appartment
            {
                Floors = floors,
                ParkingLot = hasParkingLot ? new ParkingLot { Capacity = parkingLotCapacity } : null
            };
        }
    }
}
