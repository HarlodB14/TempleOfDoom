using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public class ToggleDoorDecorator : DoorDecorator
    {
        public ToggleDoorDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2)
            : base(decoratedDoor, connectedRoom1, connectedRoom2) { }

        public override bool CanEntityPass(Player player)
        {
            return DecoratedDoor.IsOpen && base.CanEntityPass(player);
        }

        public void Toggle()
        {
            DecoratedDoor.ToggleOpenState();
        }
    }
}

