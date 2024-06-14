using System;
using System.Collections.Generic;
using System.Linq;
using TempleOfDoomModel.Doors;
using TempleOfDoomModel.Doors.Decorators;

namespace TempleOfDoomModel.Items
{
    public class PressurePlate : Item, IInteractable
    {
        public bool IsPressed { get; private set; }

        public void Interact(Player player)
        {
            // Find all doors in the current room
            var doors = player.CurrentRoom.GetAllDoors();

            foreach (var door in doors)
            {
                // Check if the door is a ToggleDoorDecorator or contains one in its decorator chain
                var toggleDoor = FindToggleDoorDecorator(door);
                if (toggleDoor != null)
                {
                    // Toggle the door's state
                    toggleDoor.Toggle();
                }
            }

            // Update the pressure plate's state
            IsPressed = !IsPressed;
        }

        private ToggleDoorDecorator FindToggleDoorDecorator(Door door)
        {
            while (door is DoorDecorator decorator)
            {
                if (decorator is ToggleDoorDecorator toggleDoor)
                {
                    return toggleDoor;
                }
                door = decorator.DecoratedDoor;
            }
            return null;
        }
    }
}
