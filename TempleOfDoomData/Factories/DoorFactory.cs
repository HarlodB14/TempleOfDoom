using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Doors.Decorators;
using TempleOfDoomModel.Doors;
using TempleOfDoomModel;

namespace TempleOfDoomData.Factories
{
    public class DoorFactory
    {
        public Door CreateDoor(List<DoorDTO> doorDTOs, Room room1, Room room2)
        {
            Door door = new BasicDoor(room1, room2);

            // Track the color for colored doors
            string doorColor = null;

            foreach (var doorDTO in doorDTOs)
            {
                switch (doorDTO.type.ToLower())
                {
                    case "colored":
                        door = new ColoredDoorDecorator(door, room1, room2, doorDTO.color);
                        doorColor = doorDTO.color;
                        break;
                    case "toggle":
                        door = new ToggleDoorDecorator(door, room1, room2);
                        break;
                    case "closing gate":
                        door = new ClosingGateDecorator(door, room1, room2);
                        break;
                    case "open on odd":
                        door = new OpenOnOddDoorDecorator(door, room1, room2);
                        break;
                    case "open on stones in room":
                        door = new OpenOnStonesInRoomDoorDecorator(door, room1, room2, doorDTO.no_of_stones);
                        break;
                }
            }

            // Apply the color to the final door object
            if (!string.IsNullOrEmpty(doorColor))
            {
                door.DoorColor = doorColor;
            }

            return door;
        }


    }

}
