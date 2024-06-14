using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public class OpenOnOddDoorDecorator : DoorDecorator
    {
        public OpenOnOddDoorDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2)
            : base(decoratedDoor, connectedRoom1, connectedRoom2) { }

        public override bool CanEntityPass(Player player)
        {
            return base.CanEntityPass(player) && player._lives % 2 != 0;
        }
    }
}

