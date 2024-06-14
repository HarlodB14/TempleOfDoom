using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public class BasicDoor : Door
    {
        public BasicDoor(Room connectedRoom1, Room connectedRoom2)
            : base(connectedRoom1, connectedRoom2)
        {
            IsOpen = true; // BasicDoor is always open
        }

        public override bool CanEntityPass(Player player)
        {
            return IsOpen; // Player can pass if the door is open
        }


    }
}
