using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel;
using TempleOfDoomModel.Doors.Decorators;
using TempleOfDoomModel.Doors;

namespace TempleOfDoomData.Factories
{
    public class ConnectionFactory
    {
        private readonly DoorFactory _doorFactory;

        public ConnectionFactory(DoorFactory doorFactory)
        {
            _doorFactory = doorFactory;
        }

        public void CreateConnections(List<Room> rooms, List<ConnectionDTO> connectionDTOs)
        {
            foreach (var connectionDTO in connectionDTOs)
            {
                // Handle North-South connections
                if (connectionDTO.NORTH > 0 && connectionDTO.SOUTH > 0)
                {
                    SetupRoomConnection(rooms, connectionDTO.NORTH, connectionDTO.SOUTH, connectionDTO.doors, "North", "South");
                }

                // Handle East-West connections
                if (connectionDTO.EAST > 0 && connectionDTO.WEST > 0)
                {
                    SetupRoomConnection(rooms, connectionDTO.EAST, connectionDTO.WEST, connectionDTO.doors, "East", "West");
                }
            }
        }

        private void SetupRoomConnection(List<Room> rooms, int room1Index, int room2Index, List<DoorDTO> doorDTOs, string direction1, string direction2)
        {
            Room room1 = rooms[room1Index - 1];
            Room room2 = rooms[room2Index - 1];

            Door door = _doorFactory.CreateDoor(doorDTOs, room1, room2);
            room1.AddConnection(direction2, door);
            room2.AddConnection(direction1, door);
        }

    }

}
